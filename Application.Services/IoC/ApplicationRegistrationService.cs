namespace Application.Services.IoC
{
    using DocumentClassificationService;
    using Domain.Services.IoC;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationRegistrationService : IRegistrationService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            RegisterDataServices(serviceCollection);
            RegisterDomainServices(serviceCollection);
            RegisterApplicationServices(serviceCollection);
        }

        private static void RegisterDataServices(IServiceCollection serviceCollection)
        {
            var repositoryServiceProvider = new Data.Repository.IoC.RepositoryRegistrationService();
            repositoryServiceProvider.RegisterServices(serviceCollection);

            var gatewayServiceProvider = new GatewayRegistrationService();
            gatewayServiceProvider.RegisterServices(serviceCollection);
        }

        private void RegisterDomainServices(IServiceCollection serviceCollection)
        {
            var domainServiceProvider = new DomainRegistrationService();
            domainServiceProvider.RegisterServices(serviceCollection);
        }

        private static void RegisterApplicationServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentService, DocumentService>();

            serviceCollection.AddTransient<IDocumentClassificationService, DocumentClassificationService>();
            serviceCollection.AddTransient<ClassificationStrategy, SyncClassificationStrategy>();
        }
    }
}