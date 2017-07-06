namespace Presentation.API.App_Start
{
    using System.Web.Http.Dependencies;
    using Application.Services.DocumentClassificationService;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.API.IoC;

    public static class IoCConfig
    {
        public static IDependencyResolver GetResolver()
        {
            var services = new ServiceCollection();

            var crossCuttingRegistrationService = new Infrastructure.CrossCutting.IoC.RegistrationService();
            crossCuttingRegistrationService.RegisterServices(services);

            var registrationService = new RegistrationService();
            registrationService.RegisterServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var subscribers = serviceProvider.GetService<ClassificationStrategy>();

            return new DefaultDependencyResolver(serviceProvider);
        }
    }
}