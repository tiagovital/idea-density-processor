[assembly: Microsoft.Owin.OwinStartup(typeof(Presentation.WebApi.Startup))]

namespace Presentation.WebApi
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

            //Automapper
            var profilesLoader = new StaticProfileLoader(new Profile[] {
                new Application.Services.MapperProfiles.DocumentProfile()
            });

            MapperConfig.Initialize(profilesLoader);
        }
    }
}