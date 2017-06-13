namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dto;

    public interface IDocumentService
    {
        Task Save(DocumentDto documentDto);

        Task<IEnumerable<DocumentDto>> GetAll(int page, int pageSize);
    }
}