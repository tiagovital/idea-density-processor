using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repository.Extensions;
using Data.Repository.Mappings;
using Domain.Model;
using MongoDB.Driver;

namespace Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        #region Private members

        private const string databaseName = "IDP";

        private readonly IMongoClient client;

        #endregion Private members

        #region Ctors

        static DocumentRepository()
        {
            DocumentMappings.MapEntites();
        }

        public DocumentRepository(IMongoClient client)
        {
            this.client = client;
        }

        #endregion Ctors

        #region IDocumentRepository Methods

        public async Task AddOrUpdate(Document document)
        {
            var opts = new UpdateOptions { IsUpsert = true };

            await this.GetDatabase()
                .GetCollectionFor<Document>()
                .ReplaceOneAsync(d => d.Id == document.Id, document, opts);
        }

        public async Task<Document> Get(Guid documentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document>> Get(string[] tags)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document>> Get(int page, int pageSize)
        {
            return await Task.FromResult(new List<Document>
            {
                new Document { CreatedAt = DateTime.Now, Author = "Tiago Vital", Title = "Document 1" },

                new Document { CreatedAt = DateTime.Now, Author = "Tiago Vital", Title = "Document 2" },

                new Document { CreatedAt = DateTime.Now, Author = "Tiago Vital", Title = "Document 3" },
            });
        }

        #endregion IDocumentRepository Methods

        #region Private Methods

        private IMongoDatabase GetDatabase()
        {
            return this.client.GetDatabase(databaseName);
        }

        #endregion Private Methods
    }
}