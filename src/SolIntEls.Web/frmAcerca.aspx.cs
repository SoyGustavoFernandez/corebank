using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolIntEls.Web
{
    public partial class frmAcerca : System.Web.UI.Page
    {
        #region Variable Globales

        public clsVarGlobalClone objVarGlobal
        {
            set { Session["VarGlobal"] = value; }
            get { return Session["VarGlobal"] == null ? new clsVarGlobalClone() : (clsVarGlobalClone)Session["VarGlobal"]; }
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Asignar título de la opción    
                lblTitulo.Text = "Core Bank Web";
            }
        }

        protected void lnkIngresar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void lnkSalir_ServerClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect("frmInicio.aspx", true);
        }

        protected void click_Logo(object sender, EventArgs e)
        {
            if (objVarGlobal.User == null)
            {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                Response.Redirect("frmInicio.aspx", true);
            }
            else
            {
                Response.Redirect("frmMenu.aspx", true);
            }
        }

        #endregion

        #region Métodos


        #endregion      

    }


}