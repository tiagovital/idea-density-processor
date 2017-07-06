namespace Data.Repository.IoC
{
    using System;
    using System.Configuration;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;
    using MongoDB.Driver;
    using Repositories;

    public class RepositoryRegistrationService : IRegistrationService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentRepository, DocumentRepository>();
            serviceCollection.AddTransient<IWordClassificationRepository, WordClassificationRepository>();
            serviceCollection.AddTransient<IMongoClient, MongoClient>(CreateMongoClient);
        }

        private MongoClient CreateMongoClient(IServiceProvider arg)
        {
            var connString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            return new MongoDB.Driver.MongoClient(connString);
        }
    }
}