namespace Data.Gateway.Iltec
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal class IltecClient : IIltecClient
    {
        private readonly Uri baseUrl;

        public IltecClient(string baseUrl)
        {
            this.baseUrl = new Uri(baseUrl);
        }

        public async Task<string> Search(string word)
        {
            var query = string.Concat("simplesearch.php?sel=exact&action=simplesearch&base=form&sel=exact&query=", word);

            return await this.GetStringAsync(query).ConfigureAwait(false);
        }

        public async Task<string> SearchLemma(string lemmaHref)
        {
            return await this.GetStringAsync(lemmaHref).ConfigureAwait(false);
        }

        private async Task<string> GetStringAsync(string relativePath)
        {
            var searchUri = string.Concat(this.baseUrl, relativePath);

            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(searchUri).ConfigureAwait(false);
            }
        }
    }
}