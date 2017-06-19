namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dto;

    public interface IDocumentService
    {
        Task Save(Guid documentId, DocumentDto documentDto);

        Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize);
    }
}