using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolIntEls.Web
{
    public partial class frmError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            if (Request.QueryString["error"] != null)
            {
                lblError.Text = Request.QueryString["error"].ToString();
            }
        }
        protected void BotonAtras1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect("frmInicio.aspx", true);
        }
    }
}