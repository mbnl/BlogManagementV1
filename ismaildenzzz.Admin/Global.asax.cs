using ismaildenzzz.Admin.App_Start;
using ismaildenzzz.Admin.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ismaildenzzz.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootStrapper.RunConfig();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
