﻿using System.Web.Http;

namespace Presentation.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SwaggerConfig.Register();
        }
    }
}