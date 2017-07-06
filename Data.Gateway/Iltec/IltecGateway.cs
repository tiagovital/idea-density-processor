namespace Data.Gateway
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Model;
    using JackLeitch.RateGate;

    public class IltecGateway : IWordClassificatorGateway
    {
        private readonly IIltecAdapterFactory adapterFactory;
        private readonly IIltecClient client;
        private static readonly RateGate rateGate = new RateGate(1, TimeSpan.FromSeconds(15));

        public IltecGateway(IIltecClient client, IIltecAdapterFactory iltecAdapterFactory)
        {
            this.client = client;
            this.adapterFactory = iltecAdapterFactory;
        }

        public async Task<Word> Classificate(string word)
        {
            rateGate.WaitToProceed();

            string htmlResult = await this.client.Search(word);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlResult);

            if (this.IsRedirectResult(htmlResult))
            {
                var href = htmlDoc.DocumentNode.Descendants("a")
                       .Select(x => x.GetAttributeValue("href", string.Empty))
                       .FirstOrDefault();

                htmlResult = await this.client.SearchLemma(href).ConfigureAwait(false);

                htmlDoc.LoadHtml(htmlResult);
            }

            var adapter = this.adapterFactory.From(htmlDoc);

            var result = adapter.Adapt(htmlDoc);

            return new Word
            {
                Id = word,
                Value = word,
                Class = result.Class,
                AlternativeClasses = result.AlternativeClasses.ToList(),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = this.GetType().Name
            };
        }

        private bool IsRedirectResult(string htmlResult)
        {
            return htmlResult.Contains("redirecting to:");
        }
    }
}