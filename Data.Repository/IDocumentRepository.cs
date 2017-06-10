using System;
using System.Collections.Generic;
using Domain.Model;

namespace Data.Repository
{
    public interface IDocumentRepository
    {
        Document Add(Document document);

        IEnumerable<Document> Get(string[] tags);

        Document Get(Guid documentId);
    }
}