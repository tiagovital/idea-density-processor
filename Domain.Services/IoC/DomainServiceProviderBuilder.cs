namespace Domain.Services.IoC
{
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class DomainServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentService, DocumentService>();
        }
    }
}