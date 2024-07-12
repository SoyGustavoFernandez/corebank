using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EntityLayer;

namespace SolIntEls.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            clsVarGlobal.IConectionGen = new ConnectionWeb();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string cError = "";
            var exError = (SolIntEls.Web.Global)sender;
            if (exError.Context.AllErrors.Count() > 0)
            {
                if ( exError.Context.AllErrors[0].InnerException != null)
                {
                    cError = exError.Context.AllErrors[0].InnerException.Message;
                }
                else
                {
                    cError = "Error de la aplicación";
                }
            }
            Response.Redirect("~\\frmError.aspx?error=" + cError);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}