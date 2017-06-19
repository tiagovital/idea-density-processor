namespace Data.Gateway
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model;

    public class IltecGateway : IWordClassificatorGateway
    {
        private readonly IIltecAdapterFactory adapterFactory;
        private readonly IIltecClient client;

        public IltecGateway(IIltecClient client, IIltecAdapterFactory iltecAdapterFactory)
        {
            this.client = client;
            this.adapterFactory = iltecAdapterFactory;
        }

        public async Task<Word> Classificate(string word)
        {
            string htmlResult = await this.client.Search(word);

            var adapter = this.adapterFactory.From(htmlResult);

            var result = adapter.Adapt(htmlResult);

            // Guard.Against<Exception>(result.HasError, "An error ocurred while getting terms
            // classification from Iltec site");

            return new Word
            {
                Value = word,
                Class = result.Class,
                AlternativeClasses = result.AlternativeClasses.ToList()
            };
        }
    }
}