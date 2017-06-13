﻿namespace Presentation.API.IoC
{
#pragma warning disable S3881 // "IDisposable" should be implemented correctly

    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Microsoft.Extensions.DependencyInjection;

    public class DefaultDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider provider;

        public DefaultDependencyResolver(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public object GetService(Type serviceType)
        {
            return provider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return provider.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            // Method intentionally left empty.
        }
    }
}