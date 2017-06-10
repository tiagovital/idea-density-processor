using Application.Dto;
using AutoMapper;
using Data.Repository;
using Domain.Model;

namespace Application.Services
{
    public class DocumentService
    {
        private readonly IDocumentRepository repository;

        public DocumentService(IDocumentRepository repository)
        {
            this.repository = repository;
        }

        public void Save(DocumentDto documentDto)
        {
            var document = Mapper.Map<Document>(documentDto);

            this.repository.Add(document);
        }
    }
}