using EntityLayer;
using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolIntEls.Web
{
    public partial class frmInicio : System.Web.UI.Page
    {
        #region Variable Globales

        clsAutenticacion autenticacion = new clsAutenticacion();
        clsCNPerfilUsu cnperfilusu = new clsCNPerfilUsu();

        public clsVarGlobalClone objVarGlobal
        {
            set { Session["VarGlobal"] = value; }
            get { return Session["VarGlobal"] == null ? new clsVarGlobalClone() : (clsVarGlobalClone)Session["VarGlobal"]; }
        }

        public clsVarAplClone objVarApl
        {
            set { Session["VarApl"] = value; }
            get { return Session["VarApl"] == null ? new clsVarAplClone() : (clsVarAplClone)Session["VarApl"]; }
        }

        public List<clsPerfilUsu> lstPerfiles
        {
            set { Session["lstPerfiles"] = value; }
            get { return Session["lstPerfiles"] == null ? new List<clsPerfilUsu>() : (List<clsPerfilUsu>)Session["lstPerfiles"]; }
        }

        public List<clsAgencia> lstAgencias
        {
            set { Session["lstAgencias"] = value; }
            get { return Session["lstAgencias"] == null ? new List<clsAgencia>() : (List<clsAgencia>)Session["lstAgencias"]; }
        }
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Asignar título de la opción
                Session.Clear();
                txtUsuario.Focus();
            }
        }

        protected void lnkIngresar_ServerClick(object sender, EventArgs e)
        {
            
        }

        protected void lnkSalir_ServerClick(object sender, EventArgs e)
        {

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

        private bool validar()
        {
            bool lval = false;

            if (txtUsuario.Text == "")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ingrese un usuario por favor";
                return lval;
            }
            if (txtClave.Text == "")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ingrese la clave por favor";
                return lval;
            }

            
            lval = true;
            return lval;
        }

        private void habilitar()
        {

        }

        private void limpiar()
        {

        }

        #endregion

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            List<clsPerfilUsu> lisPerfiles = null;
            List<clsAgencia> lisAgencias = null;
            clsUsuario user = null;

            Session.Clear();
            objVarGlobal = new clsVarGlobalClone();
            if (!objVarGlobal.lEstLogeado)
            {
                if (!validar())
                {
                    return;
                }

                if (autenticacion.AutenticarWeb(txtUsuario.Text.Trim(), txtClave.Text.Trim(), ref user))
                {
                    objVarGlobal = objVarGlobal.obtnerClase();
                    lblMensaje.Visible = false;
                    objVarGlobal.User = user;
                    lisPerfiles = cnperfilusu.ListarPerUsu(user.idUsuario);
                    lisAgencias = new clsCNAgenciaUsu().CNListarAgenciasUsuario(user.idUsuario);

                    if (lisAgencias.Count() > 1)
                    {
                        cboAgencias.Visible = true;
                        BtnCancelar1.Visible = true;
                        txtUsuario.Enabled = false;
                        txtClave.Enabled = false;
                        cboAgencias.DataValueField = "idAgencia";
                        cboAgencias.DataTextField = "cNombreAge";
                        cboAgencias.DataSource = lisAgencias;
                        cboAgencias.DataBind();
                        lstAgencias = lisAgencias;
                        cboAgencias.SelectedIndex = -1;
                        btnIngPerfil.Visible = true;
                        btnIngresar.Visible = false;
                        objVarGlobal.lEstLogeado = true;
                    }
                    else
                    {
                        if (lisAgencias.Count > 0)
                        {
                            objVarGlobal.nIdAgencia = lisAgencias.First().idAgencia;
                            objVarGlobal.cNomAge = lisAgencias[0].cNombreAge;
                            objVarGlobal.lEstLogeado = true;
                        }
                        else
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = "Usuario no tiene acceso a ninguna agencia.";
                            objVarGlobal.lEstLogeado = false;
                            return;
                        }
                    }

                    if (lisPerfiles.Count() > 1)
                    {
                        cboPerfiles.Visible = true;
                        BtnCancelar1.Visible = true;
                        txtUsuario.Enabled = false;
                        txtClave.Enabled = false;
                        cboPerfiles.DataValueField = "idPerfil";
                        cboPerfiles.DataTextField = "cPerfil";
                        cboPerfiles.DataSource = lisPerfiles;
                        cboPerfiles.DataBind();
                        lstPerfiles = lisPerfiles;
                        cboPerfiles.SelectedIndex = -1;
                        btnIngPerfil.Visible = true;
                        btnIngresar.Visible = false;
                        objVarGlobal.lEstLogeado = true;
                    }
                    else
                    {
                        if (lisPerfiles.Count > 0)
                        {
                            objVarGlobal.PerfilUsu = lisPerfiles.First();
                            objVarGlobal.lEstLogeado = true;
                        }
                        else
                        {
                            lblMensaje.Visible = true;
                            this.lblMensaje.Text = "Usuario no tiene perfil asignado.";
                            objVarGlobal.lEstLogeado = false;
                            return;
                        }
                    }

                    if (objVarGlobal.lEstLogeado && objVarGlobal.PerfilUsu != null && objVarGlobal.nIdAgencia > 0)
                    {
                        objVarApl = new clsVarAplClone();
                        new clsCNVarGen().LisVar(objVarGlobal.nIdAgencia);
                        new clsCNVarGen().GetVarGlobal(objVarGlobal.nIdAgencia, objVarGlobal);
                        new clsCNVarApl().GetVarApl(objVarGlobal.nIdAgencia, objVarApl);
                        Response.Redirect("frmMenu.aspx", true);
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    objVarGlobal.User = null;
                    this.lblMensaje.Text = "Usuario o clave incorrecta";
                    return;
                }
            }
        }

        protected void BtnCancelar1_Click(object sender, EventArgs e)
        {
            cboPerfiles.Visible = false;
            cboAgencias.Visible = false;
            BtnCancelar1.Visible = false;
            txtUsuario.Enabled = true;
            txtClave.Enabled = true;
            txtUsuario.Text = String.Empty;
            txtClave.Text = String.Empty;
            btnIngPerfil.Visible = false;
            btnIngresar.Visible = true;
            Page.Session.Clear();
        }

        protected void btnIngPerfil_Click(object sender, EventArgs e)
        {
            if (objVarGlobal.lEstLogeado == true && 
                    (cboPerfiles.Visible == cboPerfiles.SelectedIndex >= 0) && 
                    (cboAgencias.Visible == cboAgencias.SelectedIndex >= 0))
            {
                if (cboAgencias.Visible)
                {
                    int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                    clsAgencia objAgencia = lstAgencias.Where(x => x.idAgencia == idAgencia).First();
                    objVarGlobal.nIdAgencia = objAgencia.idAgencia;
                    objAgencia.cNombreAge = objAgencia.cNombreAge;
                }

                if (cboPerfiles.Visible)
                {
                    int idPerfil = Convert.ToInt32(cboPerfiles.SelectedValue);
                    clsPerfilUsu objPerfil = lstPerfiles.Where(x => x.idPerfil == idPerfil).First();
                    objVarGlobal.PerfilUsu = objPerfil;
                }
                objVarApl = new clsVarAplClone();
                new clsCNVarGen().LisVar(objVarGlobal.nIdAgencia);
                new clsCNVarGen().GetVarGlobal(objVarGlobal.nIdAgencia, objVarGlobal);
                new clsCNVarApl().GetVarApl(objVarGlobal.nIdAgencia, objVarApl);
                Session.Remove("lstPerfiles");
                Session.Remove("lstAgencias");
                Response.Redirect("frmMenu.aspx", true);
            }
        }

    }
}