namespace Application.Services.DocumentClassificationService
{
    using System.Threading.Tasks;
    using Domain.Model;
    using Dto;

    public interface IDocumentClassificationService
    {
        Task Classificate(Document document);

        Task<WordDto> Classificate(string wordValue);
    }
}