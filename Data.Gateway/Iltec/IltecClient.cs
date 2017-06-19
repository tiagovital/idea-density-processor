using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data.Gateway.Iltec
{
    internal class IltecClient : IIltecClient
    {
        private readonly Uri baseUrl;

        public IltecClient(string baseUrl)
        {
            this.baseUrl = new Uri(baseUrl);
        }

        public async Task<string> Search(string word)
        {
            var urlBuilder = new UriBuilder(baseUrl);
            urlBuilder.Query = string.Concat("simplesearch.php?sel=exact&action=simplesearch&base=form&sel=exact&query=", word);

            var searchUri = urlBuilder.Uri;

            var client = new HttpClient();

            return await client.GetStringAsync(searchUri).ConfigureAwait(false);
        }
    }
}