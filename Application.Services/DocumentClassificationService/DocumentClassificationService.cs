namespace Application.Services.DocumentClassificationService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Data.Gateway;
    using Domain.Model;

    public class DocumentClassificationService
    {
        private readonly IWordClassificatorGateway gateway;

        public DocumentClassificationService(IWordClassificatorGateway gateway)
        {
            this.gateway = gateway;
        }

        public async Task Classificate(Document document)
        {
            var sentencesMatches = Regex.Split(document.Content, @"(?<=[\.!\?])\s+");

            document.Sentences = await Task.WhenAll(sentencesMatches
                .Select(async st => new Sentence() { Words = await ParseWords(st).ConfigureAwait(false) }))
                .ConfigureAwait(false);

            var count = document.Sentences.Count();
        }

        private async Task<IList<Word>> ParseWords(string sentence)
        {
            var wordsMatches = Regex.Matches(sentence, @"\b[\w']*\b");

            return await Task.WhenAll(wordsMatches.Cast<Match>()
                          .Where(w => !string.IsNullOrEmpty(w.Value))
                          .Select(async w => await this.gateway.Classificate(w.Value).ConfigureAwait(false)))
                          .ConfigureAwait(false);
        }
    }
}