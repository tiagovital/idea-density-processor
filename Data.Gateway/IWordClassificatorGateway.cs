namespace Data.Gateway
{
    using System.Threading.Tasks;
    using Domain.Model;

    public interface IWordClassificatorGateway
    {
        Task<Word> Classificate(string word);
    }
}