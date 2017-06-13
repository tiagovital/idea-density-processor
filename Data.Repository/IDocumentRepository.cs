using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace Data.Repository
{
    public interface IDocumentRepository
    {
        Task Add(Document document);

        Task<IEnumerable<Document>> Get(int page, int pageSize);

        Task<IEnumerable<Document>> Get(string[] tags);

        Task<Document> Get(Guid documentId);
    }
}