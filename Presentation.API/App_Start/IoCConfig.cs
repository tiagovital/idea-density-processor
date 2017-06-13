namespace Presentation.API.App_Start
{
    using System.Web.Http.Dependencies;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.API.IoC;

    public static class IoCConfig
    {
        public static IDependencyResolver GetResolver()
        {
            var services = new ServiceCollection();

            var serviceProviderBuilder = new ServiceProviderBuilder();
            serviceProviderBuilder.RegisterServices(services);

            var serviceProvider = services.BuildServiceProvider();

            return new DefaultDependencyResolver(serviceProvider);
        }
    }
}