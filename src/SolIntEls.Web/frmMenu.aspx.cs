using GEN.CapaNegocio;
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EntityLayer;

namespace SolIntEls.Web
{
    public partial class frmMenu : System.Web.UI.Page
    {
        #region Variables Globales
        
        clsCNMenu cnmenu = new clsCNMenu();
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
                if (objVarGlobal.User == null)
                {
                    throw new Exception("La sesión de usuario terminó, vuelva a ingresar");
                }
                if (objVarGlobal.PerfilUsu == null)
                {
                    throw new Exception("Usuario no tiene perfil asignado, consulte al TI");
                }

                lblUsuario.Text = objVarGlobal.User.cWinUser;

                cargarMenu();
            }
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

        private void cargarMenu()
        {
            var perfil = objVarGlobal.PerfilUsu;
            var dtMenu = cnmenu.LisTreeMenByPer(perfil.idPerfil);
            HtmlGenericControl html_li;
            HtmlGenericControl html_a;

            //MÓDULO DE CRÉDITOS//3,4 opciones web
            var nMenuCre=dtMenu.AsEnumerable().Where(x => (int)x["idModulo"] == 1 && ((int)x["idTipoMenu"]).In(3, 4)).Count();
            if (nMenuCre > 0) 
            {
                menucre.Visible = true;
                var dtMenuCre = dtMenu.AsEnumerable().Where(x => (int)x["idModulo"] == 1 && ((int)x["idTipoMenu"]).In(3, 4));
                foreach (var item in dtMenuCre)
                {
                    if (item["idTipoMenu"].ToString() == "3")
                    {
                        html_li = new HtmlGenericControl("li");
                        html_a = new HtmlGenericControl("a");
                        html_li.Attributes.Add("class", "list-group-item");
                        html_li.Attributes.Add("id", item["idMenu"].ToString());
                        html_a.Attributes.Add("href", item["cFormMenu"].ToString());
                        html_a.InnerText =" - "+ item["cMenu"].ToString();
                        html_li.Controls.Add(html_a);
                        listacre.Controls.Add(html_li);
                    }
                }
            }
            else
            {
                menucre.Visible = false;
            }

            //MÓDULO ADMINISTRACIÓN//3,4 opciones web
            var nMenuAdm = dtMenu.AsEnumerable().Where(x => (int)x["idModulo"] == 8 && ((int)x["idTipoMenu"]).In(3, 4)).Count();
            if (nMenuAdm > 0) 
            {
                menuadm.Visible = true;
                var dtMenuCre = dtMenu.AsEnumerable().Where(x => (int)x["idModulo"] == 8 && ((int)x["idTipoMenu"]).In(3, 4));
                foreach (var item in dtMenuCre)
                {
                    if (item["idTipoMenu"].ToString() == "3")
                    {
                        html_li = new HtmlGenericControl("li");
                        html_a = new HtmlGenericControl("a");
                        html_li.Attributes.Add("class", "list-group-item");
                        html_li.Attributes.Add("id", item["idMenu"].ToString());
                        html_a.Attributes.Add("href", item["cFormMenu"].ToString());
                        html_a.InnerText = " - " + item["cMenu"].ToString();
                        html_li.Controls.Add(html_a);
                        listaadm.Controls.Add(html_li);
                    }
                }
            }
            else
            {
                menuadm.Visible = false;
            }
        }

        #endregion
    }
}