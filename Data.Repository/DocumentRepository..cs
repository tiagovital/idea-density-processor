using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public async Task Add(Document document)
        {
            throw new NotImplementedException();
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
    }
}