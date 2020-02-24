using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

using System.Web.Routing;

namespace wwwroot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //  WebApiConfig.Register(GlobalConfiguration.Configuration);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            Exception exc = Server.GetLastError().GetBaseException();

            ErrorLog.ExceptionUtility.LogException(exc, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.Url.Host);
            Server.ClearError();
            string redURL = ConfigurationManager.AppSettings["customerror"];
            Response.Redirect(redURL);
        }
    }
}