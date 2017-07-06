[assembly: Microsoft.Owin.OwinStartup(typeof(Presentation.API.Startup))]

namespace Presentation.API
{
    using System.Web.Http;
    using AutoMapper;
    using Infrastructure.CrossCutting.Automapper;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            //webapi
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);

            //Swagger
            SwaggerConfig.Register(config);

            //Automapper
            var profilesLoader = new StaticLoadingStrategy(new Profile[] {
                //new Presentation.API.MapperProfiles.DocumentsProfile(),
                new Application.Services.MapperProfiles.DocumentProfile()
            });

            MapperInitializer.Initialize(profilesLoader);
        }
    }
}