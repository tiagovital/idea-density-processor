namespace Data.Repository
{
    using Data.Repository.Mappings;
    using Domain.Model;
    using MongoDB.Driver;
    using Repositories;

    public class DocumentRepository : MongoRepository<Document>, IDocumentRepository
    {
        #region Ctors

        static DocumentRepository()
        {
            DocumentMappings.MapEntites();
        }

        public DocumentRepository(IMongoClient client)
            : base(client)
        {
        }

        #endregion Ctors
    }
}