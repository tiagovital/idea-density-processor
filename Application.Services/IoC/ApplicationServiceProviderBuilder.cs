namespace Application.Services.IoC
{
    using Data.Repository.IoC;
    using Domain.Services.IoC;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            RegisterDataServices(serviceCollection);
            RegisterDomainServices(serviceCollection);
            RegisterApplicationServices(serviceCollection);
        }

        private static void RegisterDataServices(IServiceCollection serviceCollection)
        {
            var repositoryServiceProvider = new RepositoryServiceProviderBuilder();
            repositoryServiceProvider.RegisterServices(serviceCollection);

            var gatewayServiceProvider = new GatewayServiceProviderBuilder();
            gatewayServiceProvider.RegisterServices(serviceCollection);
        }

        private void RegisterDomainServices(IServiceCollection serviceCollection)
        {
            var domainServiceProvider = new DomainServiceProviderBuilder();
            domainServiceProvider.RegisterServices(serviceCollection);
        }

        private static void RegisterApplicationServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentService, DocumentService>();
        }
    }
}