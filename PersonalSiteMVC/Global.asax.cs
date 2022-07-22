using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonalSiteMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string app = "PersonalSiteMVC";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                PSDataLayer psdl = new PSDataLayer();
                psdl.ErrorMessageWriter(ex, Request.Url.PathAndQuery, Environment.MachineName, psdl.ApplicationName);
            }
        }
    }
}
//TODO Add connection string to web.config and appUser to DB Users