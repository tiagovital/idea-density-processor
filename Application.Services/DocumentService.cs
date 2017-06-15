using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Data.Repository;
using Domain.Model;
using DomainServices = Domain.Services;

namespace Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly DomainServices.IDocumentService domainService;
        private readonly IDocumentRepository repository;

        public DocumentService(IDocumentRepository repository, DomainServices.IDocumentService domainService)
        {
            this.repository = repository;
            this.domainService = domainService;
        }

        public async Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize)
        {
            var documents = await this.repository.Get(page, pageSize).ConfigureAwait(false);

            return Mapper.Map<IEnumerable<DocumentDto>>(documents);
        }

        public async Task Save(Guid documentId, DocumentDto documentDto)
        {
            documentDto.Id = documentId;
            var document = Mapper.Map<Document>(documentDto);

            this.domainService.Validate(document);

            await this.repository.AddOrUpdate(document);
        }
    }
}