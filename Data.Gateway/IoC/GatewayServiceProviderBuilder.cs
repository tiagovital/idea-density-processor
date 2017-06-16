namespace Application.Services.IoC
{
    using System.Configuration;
    using Data.Gateway;
    using Data.Gateway.Iltec;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class GatewayServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IIltecClient, IltecClient>((sp) => new IltecClient(ConfigurationManager.AppSettings["iltecBaseUri"]));
            serviceCollection.AddTransient<IWordClassificatorGateway, IltecGateway>();
            serviceCollection.AddTransient<IIltecAdapterFactory, IltecAdapterFactory>();
        }
    }
}