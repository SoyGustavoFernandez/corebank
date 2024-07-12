using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WCF.KasNet
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        private void RegisterRoutes(RouteCollection routes)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {            
            if (HttpContext.Current.Request.Headers["Origin"] == null)
            {
                return;
            }

            String domainname = HttpContext.Current.Request.Headers["Origin"].ToString();
            if (IsAllowedDomain(domainname))
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", domainname);
            String allowedmethods = "POST, PUT, DELETE, GET";
            //String headers = HttpContext.Current.Request.Headers["Access-Control-Request-Headers"].ToString();
            String headers = "User-Agent,Content-Type,Authorization,X-RequestDigest,X-ClientService-ClientTag";
            String accesscontrolmaxage = "1728000";
            String contenttypeforoptionsrequest = "application/json";

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", allowedmethods);
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", headers);
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", accesscontrolmaxage);
                HttpContext.Current.Response.AddHeader("ContentType", contenttypeforoptionsrequest);
                HttpContext.Current.Response.End();
            }
        }

        private bool IsAllowedDomain(String Domain)
        {
            //Rapido
            return true;

            //Real
            if (string.IsNullOrEmpty(Domain)) return false;
            string[] alloweddomains = { "http://10.4.12.15:8081", "https://api.cajalosandes.pe" };
            foreach (string alloweddomain in alloweddomains)
            {
                if (Domain.ToLower() == alloweddomain.ToLower())
                    return true;
            }
            return false;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}