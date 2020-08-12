using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //This is to handle requests for .axd files like trace.axd
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                //Default route for MVC applications
                url: "{controller}/{action}/{id}",
                //Provides default controller and action values.Also id parameter is otpitonal
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
