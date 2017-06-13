using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.IoC
{
    public interface IServiceProviderBuilder
    {
        void RegisterServices(IServiceCollection serviceCollection);
    }
}