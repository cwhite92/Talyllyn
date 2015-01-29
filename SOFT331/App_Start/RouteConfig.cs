using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SOFT331
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Used for the booking page for a certain timetable
            routes.MapRoute(
               "Date",
               "{controller}/{action}/{day}/{month}/{year}",
               new { controller = "Traveller", action = "Book"},
               new { day = @"\d{2}", month = @"\d{2}", year = @"\d{4}" }
           );
        }
    }
}
