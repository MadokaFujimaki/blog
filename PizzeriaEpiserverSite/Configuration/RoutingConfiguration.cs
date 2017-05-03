using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PizzeriaEpiserverSite.Configuration
{
    public class RoutingConfiguration : IRequiresConfigurationOnStartup
    {
        public void Configure()
        {
            Register(RouteTable.Routes);
        }

        public static void Register(RouteCollection routes)
        {
            routes.MapRoute(
                name: "start",
                url: "",
                defaults: new
                {
                    controller = "BlogPage",
                    action = "Index"
                });
}
    }
}