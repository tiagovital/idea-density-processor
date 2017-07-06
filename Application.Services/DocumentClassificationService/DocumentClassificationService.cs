namespace Application.Services.DocumentClassificationService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Gateway;
    using Data.Repository.Repositories;
    using Domain.Model;
    using Dto;
    using Infrastructure.CrossCutting.Extensions;

    public class DocumentClassificationService : IDocumentClassificationService
    {
        private readonly IWordClassificatorGateway gateway;
        private readonly IWordClassificationRepository repository;

        public DocumentClassificationService(
            IWordClassificatorGateway gateway,
            IWordClassificationRepository repository)
        {
            this.gateway = gateway;
            this.repository = repository;
        }

        public async Task<WordDto> Classificate(string wordValue)
        {
            var word = await this.GetOrLoad(wordValue);

            return Mapper.Map<WordDto>(word);
        }

        public async Task Classificate(Document document)
        {
            var sentences = document.Content.SplitIntoSentences();

            foreach (var st in sentences)
            {
                var wordsValues = st
                                    .SplitIntoWords()
                                    .Where(w => !string.IsNullOrEmpty(w))
                                    .ToList();

                var sentence = new Sentence
                {
                    Words = await Classificate(wordsValues).ConfigureAwait(false)
                };

                document.Sentences.Add(sentence);
            }
        }

        private async Task<IList<Word>> Classificate(List<string> wordsValues)
        {
            var words = new List<Word>();

            wordsValues.ForEach(async w =>
            {
                var word = await this.GetOrLoad(w).ConfigureAwait(false);

                words.Add(word);
            });

            return words;
        }

        private async Task<Word> GetOrLoad(string wordValue)
        {
            var loweredWord = wordValue.ToLowerInvariant();

            var word = await this.repository.Get(loweredWord).ConfigureAwait(false);

            if (word == null)
            {
                word = await this.gateway.Classificate(loweredWord).ConfigureAwait(false);

                await this.repository.Save(word).ConfigureAwait(false);
            }

            return word;
        }
    }
}