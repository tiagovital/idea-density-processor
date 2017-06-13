using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Data.Repository;
using Domain.Model;

namespace Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository repository;

        public DocumentService(IDocumentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize)
        {
            var documents = await this.repository.Get(page, pageSize).ConfigureAwait(false);

            return Mapper.Map<IEnumerable<DocumentDto>>(documents);
        }

        public async Task Save(DocumentDto documentDto)
        {
            var document = Mapper.Map<Document>(documentDto);

            await this.repository.Add(document);
        }
    }
}