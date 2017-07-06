namespace Infrastructure.CrossCutting.IoC
{
    using EventAggregator;
    using Microsoft.Extensions.DependencyInjection;

    public class RegistrationService : IRegistrationService

    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
        }
    }
}