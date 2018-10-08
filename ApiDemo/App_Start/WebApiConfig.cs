using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // An extension method from OWIN: Ignore default authentication of HTTP Server
            config.SuppressDefaultHostAuthentication();
            // Add filter Bearer token
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // WebAPI when dealing with JSON & JavaScript!  
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            // Setup json serialization to serialize classes to camel (std. Json format)  (.NET object <-> JSON)
            formatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // Adding JSON type web api formatting.  
            config.Formatters.Clear();
            config.Formatters.Add(formatter);
        }
    }
}
