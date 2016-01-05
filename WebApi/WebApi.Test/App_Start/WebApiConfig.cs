using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Cutomers",
                routeTemplate: "api/customers/{id}",
                defaults: new { controller = "customers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "AutoPouring",
                routeTemplate: "api/autopouring/{id}",
                defaults: new { controller = "AutoPouring", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
