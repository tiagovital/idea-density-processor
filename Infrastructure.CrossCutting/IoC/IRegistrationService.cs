using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.IoC
{
    public interface IRegistrationService
    {
        void RegisterServices(IServiceCollection serviceCollection);
    }
}