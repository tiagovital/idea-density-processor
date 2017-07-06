namespace Presentation.API.IoC
{
    using Application.Services.IoC;
    using Controllers.v1;
    using Infrastructure.CrossCutting.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public class RegistrationService : IRegistrationService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            //register Application Service Provider
            var appServiceProvider = new ApplicationRegistrationService();

            appServiceProvider.RegisterServices(serviceCollection);

            serviceCollection.AddTransient(typeof(DocumentsController));
        }
    }
}