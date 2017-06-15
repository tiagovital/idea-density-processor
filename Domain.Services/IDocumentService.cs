namespace Domain.Services
{
    using Domain.Model;

    public interface IDocumentService
    {
        void Validate(Document document);
    }
}