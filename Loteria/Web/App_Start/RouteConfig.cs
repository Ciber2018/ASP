using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Tarjeta",
                url: "Tarjeta/",
                defaults: new { controller = "Tarjeta", action = "CreateTarjeta", id = UrlParameter.Optional }              
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evento", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
