namespace Application.Services.IoC
{
    using Data.Repository.IoC;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            RegisterDataServices(serviceCollection);
            RegisterApplicationServices(serviceCollection);
        }

        private static void RegisterDataServices(IServiceCollection serviceCollection)
        {
            var repositoryServiceProvider = new DataServiceProviderBuilder();
            repositoryServiceProvider.RegisterServices(serviceCollection);
        }

        private static void RegisterApplicationServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentService, DocumentService>();
        }
    }
}