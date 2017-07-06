namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dto;
    using AutoMapper;
    using Data.Repository.Repositories;
    using Domain.Model;
    using Events;
    using Infrastructure.CrossCutting.EventAggregator;
    using DomainServices = Domain.Services;

    public class DocumentService : IDocumentService
    {
        private readonly DomainServices.IDocumentService domainService;
        private readonly IEventAggregator eventAggregator;
        private readonly IDocumentRepository repository;

        public DocumentService(
            IDocumentRepository repository,
            DomainServices.IDocumentService domainService,
            IEventAggregator eventAggregator)
        {
            this.repository = repository;
            this.domainService = domainService;
            this.eventAggregator = eventAggregator;
        }

        public async Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize)
        {
            var documents = await this.repository.GetAll(page, pageSize).ConfigureAwait(false);

            return Mapper.Map<IEnumerable<DocumentDto>>(documents);
        }

        public async Task Save(string documentId, AddOrUpdateDocumentDto dto)
        {
            var document = new Document
            {
                Id = documentId,
                Author = dto.Author,
                Content = dto.Content
            };

            this.domainService.Validate(document);

            this.eventAggregator.GetEvent<DocumentCreatingEvent>().Publish(document);

            await this.repository.Save(document).ConfigureAwait(false);
        }
    }
}