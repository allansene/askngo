using AskNGo.ElasticSearch;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AskNGo.Api.IoC
{
    public class DependencyResolver
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IElasticService, ElasticService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Other Web API configuration not shown.
        }
    }
}