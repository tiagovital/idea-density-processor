namespace Data.Repository.Repositories
{
    using Domain.Model;
    using MongoDB.Driver;

    public class WordClassificationRepository : MongoRepository<Word>, IWordClassificationRepository
    {
        public WordClassificationRepository(IMongoClient client)
            : base(client)
        {
        }
    }
}