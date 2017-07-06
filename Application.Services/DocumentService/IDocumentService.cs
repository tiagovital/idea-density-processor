namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dto;

    public interface IDocumentService
    {
        Task Save(string documentId, AddOrUpdateDocumentDto dto);

        Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize);
    }
}