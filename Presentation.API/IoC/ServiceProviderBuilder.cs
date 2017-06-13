namespace Presentation.API.IoC
{
    using Application.Services.IoC;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            var appServiceProvider = new ApplicationServiceProviderBuilder();
            appServiceProvider.RegisterServices(serviceCollection);
        }
    }
}