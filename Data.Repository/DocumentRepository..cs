using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;

namespace Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public Document Add(Document document)
        {
            return document;
        }

        public Document Get(Guid documentId)
        {
            return null;
        }

        public IEnumerable<Document> Get(string[] tags)
        {
            return Enumerable.Empty<Document>();
        }
    }
}