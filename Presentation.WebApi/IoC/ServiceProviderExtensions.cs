﻿namespace Presentation.WebApi.IoC
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}