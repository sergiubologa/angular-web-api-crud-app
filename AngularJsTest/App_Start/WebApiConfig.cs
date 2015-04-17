using AmgularJsTest.Data.Repositories;
using AngularJsTest.Infrastructure;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AngularJsTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // IoC configuration
            var container = new UnityContainer();
            container.RegisterType<IItemsRepository, ItemsRespository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfMeasuresRepository, UnitOfMeasuresRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

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
