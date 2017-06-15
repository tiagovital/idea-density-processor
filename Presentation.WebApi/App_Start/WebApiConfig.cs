using System.Web.Http;
using System.Web.Http.Dependencies;
using Presentation.API.App_Start;

namespace Presentation.API
{
    public static class WebApiConfig
    {
        private static readonly IDependencyResolver resolver = IoCConfig.GetResolver();

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = resolver;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

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