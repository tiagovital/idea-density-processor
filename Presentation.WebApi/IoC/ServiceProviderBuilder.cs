namespace Presentation.API.IoC
{
    using Application.Services.IoC;
    using Controllers.v1;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            //register Application Service Provider
            var appServiceProvider = new ApplicationServiceProviderBuilder();

            appServiceProvider.RegisterServices(serviceCollection);

            //register controllers
            serviceCollection.AddControllersAsServices(new[]
            {
                typeof(DocumentsController)
            });
        }
    }
}