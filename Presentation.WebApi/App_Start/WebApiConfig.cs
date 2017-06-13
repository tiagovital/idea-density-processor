using System.Web.Http;
using System.Web.Http.Dependencies;
using Presentation.API.App_Start;

namespace Presentation.WebApi
{
    public static class WebApiConfig
    {
        private static readonly IDependencyResolver resolver = IoCConfig.GetResolver();

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = resolver;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}