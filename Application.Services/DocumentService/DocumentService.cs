namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dto;
    using AutoMapper;
    using Data.Gateway;
    using Data.Repository.Repositories;
    using Domain.Model;
    using DomainServices = Domain.Services;

    public class DocumentService : IDocumentService
    {
        private readonly DomainServices.IDocumentService domainService;
        private readonly IWordClassificatorGateway gateway;
        private readonly IDocumentRepository repository;

        public DocumentService(IDocumentRepository repository, DomainServices.IDocumentService domainService, IWordClassificatorGateway gateway)
        {
            this.repository = repository;
            this.domainService = domainService;
            this.gateway = gateway;
        }

        public async Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize)
        {
            var documents = await this.repository.GetAll(page, pageSize).ConfigureAwait(false);

            return Mapper.Map<IEnumerable<DocumentDto>>(documents);
        }

        public async Task Save(Guid documentId, DocumentDto documentDto)
        {
            documentDto.Id = documentId;
            var document = Mapper.Map<Document>(documentDto);

            var classificator = new DocumentClassificationService.DocumentClassificationService(this.gateway);

            await classificator.Classificate(document);

            this.domainService.Validate(document);

            await this.repository.Save(document).ConfigureAwait(false);
        }
    }
}