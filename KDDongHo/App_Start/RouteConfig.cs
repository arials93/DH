using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KDDongHo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Webhome
            routes.MapRoute(
                name: "WebIndex",
                url: "{controller}/{action}",
                defaults: new { controller = "WebHome", action = "Index" }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "AdminDashboard", action = "Index" }
            );

            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}",
                defaults: new { controller = "AdminDashboard", action = "Product" }
            );

            routes.MapRoute(
                name: "AddProduct",
                url: "{controller}/{action}",
                defaults: new { controller = "AdminDashboard", action = "AddProduct" }
            );

            routes.MapRoute(
               name: "Brand",
               url: "{controller}/{action}",
               defaults: new { controller = "AdminDashboard", action = "Brand" }
           );

            routes.MapRoute(
              name: "Series",
              url: "{controller}/{action}",
              defaults: new { controller = "AdminDashboard", action = "Series" }
          );
        }
    }
}
