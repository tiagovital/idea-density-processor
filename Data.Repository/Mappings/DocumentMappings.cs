namespace Data.Repository.Mappings
{
    using Domain.Model;
    using MongoDB.Bson.Serialization;

    public static class DocumentMappings
    {
        public static void MapEntites()
        {
            BsonClassMap.RegisterClassMap<Document>();
            BsonClassMap.RegisterClassMap<Sentence>();
            BsonClassMap.RegisterClassMap<Word>();
            BsonClassMap.RegisterClassMap<WordClass>();
        }
    }
}