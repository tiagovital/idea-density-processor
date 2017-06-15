namespace Data.Repository.Extensions
{
    using MongoDB.Driver;

    public static class IMongoDatabaseExtensions
    {
        public static IMongoCollection<T> GetCollectionFor<T>(this IMongoDatabase database)
        {
            return database.GetCollection<T>(typeof(T).Name);
        }
    }
}