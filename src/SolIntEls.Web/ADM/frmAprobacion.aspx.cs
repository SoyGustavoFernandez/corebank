using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using SolIntEls.Web.utiles;

namespace SolIntEls.Web.ADM
{
    public partial class frmAprobacion : Page
    {

        #region Variables Globales

        readonly clsCNAprobacion _objAprobacion = new clsCNAprobacion();
        readonly clsUtilitarios _utiles = new clsUtilitarios();

        public clsVarGlobalClone ObjVarGlobal
        {
            set { Session["VarGlobal"] = value; }
            get { return Session["VarGlobal"] == null ? new clsVarGlobalClone() : (clsVarGlobalClone)Session["VarGlobal"]; }
        }

        public DataTable DtSolicitudes
        {
            set { ViewState["dtSolicitudes"] = value; }
            get { return ViewState["dtSolicitudes"] == null ? new DataTable() : (DataTable)ViewState["dtSolicitudes"]; }
        }

        public int IdTipoOpe
        {
            get { return (int?)ViewState["idTipOpe"] ?? 0; }
            set { ViewState["idTipOpe"] = value; }
        }

        public int IdNivelAprRanOpe
        {
            get { return (int?)ViewState["idNivelAprRanOpe"] ?? 0; }
            set { ViewState["idNivelAprRanOpe"] = value; }
        }

        public int IdDocument
        {
            get { return (int?)ViewState["idDocument"] ?? 0; }
            set { ViewState["idDocument"] = value; }
        }

        public clsEvalCredComite ObjEvalCred
        {
            set { Session["objEvalCred"] = value; }
            get { return Session["objEvalCred"] == null ? new clsEvalCredComite() : (clsEvalCredComite)Session["objEvalCred"]; }
        }

        public List<clsObservacion> LstObservaciones
        {
            set { Session["lstObservaciones"] = value; }
            get { return Session["lstObservaciones"] == null ? new List<clsObservacion>() : (List<clsObservacion>)Session["lstObservaciones"]; }
        }
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ObjVarGlobal.User == null)
            {
                throw new Exception("La sesión de usuario terminó, vuelva a ingresar");
            }

            if (!IsPostBack)
            {
                lblUsuario.Text = ObjVarGlobal.User.cWinUser;
                CargarSolicitudes();
            }
        }

        protected void GRID_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ViewDetail"))
            {
                int idSolAproba = Convert.ToInt32(e.CommandArgument);

                DataRow dr = DtSolicitudes.AsEnumerable()
                    .FirstOrDefault(x => x.Field<int>("idSolAproba") == idSolAproba);

                CleanControls();
                if (dr != null)
                {
                    IdNivelAprRanOpe = Convert.ToInt32(dr["idNivelAprRanOpe"]);
                    IdTipoOpe = Convert.ToInt32(dr["idTipoOperacion"]);
                    IdDocument = Convert.ToInt32(dr["idDocument"]);
                    txtNumSolicitud.Text = dr["idSolAproba"].ToString();
                    txtCliente.Text = dr["cNomCliente"].ToString();
                    txtProducto.Text = dr["cProducto"].ToString();
                    txtOperacion.Text = dr["cTipoOperacion"].ToString();
                    txtNumDocumento.Text = IdDocument.ToString();
                    txtMoneda.Text = dr["cMoneda"].ToString();
                    txtValor.Text = string.Format("{0:#,0.00}", dr["nValAproba"]);
                    txtMotivo.Text = dr["cMotivo"].ToString();
                    txtFecSolicita.Text = Convert.ToDateTime(dr["dFecSolici"].ToString()).ToString("dd/MMM/yyyy");
                    txtSustento.Text = dr["cSustento"].ToString();

                    LstObservaciones = new clsCNObservaciones().CNGetObservaciones(IdDocument, IdTipoOpe).ToList();
                    if (IdTipoOpe == 55)
                    {
                        ObjEvalCred = new clsCNEvalCred().CNGetEvalCredSolCred(IdDocument);
                    }

                    pnlDetalle.Visible = true;
                    pnlSolicitudes.Visible = false;
                    txtOpinion.Focus();
                }
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../frmMenu.aspx", true);
        }

        protected void btnCancelarApro_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!Validar(2))
                return;
            var objCreditoProp = IdTipoOpe.In(55, 120) ? new clsCNSolCre().GetCreditoPropSol(IdDocument) : new clsCreditoProp();
            string xmlPropCred = objCreditoProp.GetXml();

            var dtAprobaSolicitud = _objAprobacion.CNRegAprobaSolicitud(Convert.ToInt32(txtNumSolicitud.Text), 
                                                                        IdNivelAprRanOpe, 
                                                                        ObjVarGlobal.User.idUsuario,
                                                                        2, 
                                                                        txtOpinion.Text.Trim(), 
                                                                        ObjVarGlobal.dFecSystem, 
                                                                        ObjVarGlobal.PerfilUsu.idPerfil, 
                                                                        xmlPropCred);

            _utiles.Mensaje(dtAprobaSolicitud.Rows[0]["cMensage"].ToString());
            InitForm();
        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            if (!Validar(4))
                return;
            clsCreditoProp objCreditoProp;
            if (IdTipoOpe.In(55, 120))
            {
                objCreditoProp = new clsCNSolCre().GetCreditoPropSol(IdDocument);
                objCreditoProp.idMotRechazo = Convert.ToInt32(cboMotivoDenegacion.SelectedValue);
            }
            else
            {
                objCreditoProp = new clsCreditoProp();
            }
            string xmlPropCred = objCreditoProp.GetXml();

            var dtAprobaSolicitud = _objAprobacion.CNRegAprobaSolicitud(Convert.ToInt32(txtNumSolicitud.Text), 
                                                                        IdNivelAprRanOpe,
                                                                        ObjVarGlobal.User.idUsuario,
                                                                        4, 
                                                                        txtOpinion.Text.Trim(),
                                                                        ObjVarGlobal.dFecSystem,
                                                                        ObjVarGlobal.PerfilUsu.idPerfil, 
                                                                        xmlPropCred);
            _utiles.Mensaje(dtAprobaSolicitud.Rows[0]["cMensage"].ToString());
            InitForm();
        }

        protected void lnkSalir_ServerClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect("../frmInicio.aspx", true);
        }

        protected void click_Logo(object sender, EventArgs e)
        {
            if (ObjVarGlobal.User == null)
            {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                Response.Redirect("../frmInicio.aspx", true);
            }
            else
            {
                Response.Redirect("../frmMenu.aspx", true);
            }
        }

        #endregion

        #region Metodos

        private void CargarSolicitudes()
        {
            DtSolicitudes = _objAprobacion.CNLisSoliciAprobaPendiente(ObjVarGlobal.User.idUsuario,
                                                                        ObjVarGlobal.PerfilUsu.idPerfil,
                                                                        ObjVarGlobal.dFecSystem, ObjVarGlobal.nIdAgencia);
            GRID.DataSource = DtSolicitudes;
            GRID.DataBind();
            lblMensaje.Text = DtSolicitudes.Rows.Count > 0 ? string.Empty : "No existe solicitudes pendientes";
            lblMensaje.Visible = DtSolicitudes.Rows.Count == 0;
            GRID.Visible = DtSolicitudes.Rows.Count > 0;
        }

        private void CleanControls()
        {
            txtNumSolicitud.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtOperacion.Text = string.Empty;
            txtNumDocumento.Text = string.Empty;
            txtMoneda.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtMotivo.Text = string.Empty;
            txtFecSolicita.Text = string.Empty;
            txtSustento.Text = string.Empty;
            txtOpinion.Text = string.Empty;
        }

        private void InitForm()
        {
            pnlDetalle.Visible = false;
            pnlSolicitudes.Visible = true;
            CargarSolicitudes();
        }

        private bool Validar(int idEstado)
        {
            if (string.IsNullOrEmpty(txtOpinion.Text.Trim()))
            {
                _utiles.Mensaje("Registrar Opinión");
                txtOpinion.Focus();
                return false;
            }
            if (IdTipoOpe == 55 && ObjEvalCred != null)
            {
                if (!ObjEvalCred.lFinalizoComite)
                {
                    _utiles.Mensaje("El comité de la evaluación no finalizó. No se puede aprobar ni denegar.");
                    return false;
                }
                if (ObjEvalCred.lEditar)
                {
                    _utiles.Mensaje("La evaluación aun no fue devuelta para aprobación.");
                    return false;
                }
            }

            if (idEstado == 4)
            {
                if (IdTipoOpe.In(55, 120))
                {
                    if (!pnlRechazoCred.Visible)
                    {
                        pnlRechazoCred.Visible = true;
                        btnAceptar.Enabled = false;
                        return false;
                    }

                    if (string.IsNullOrEmpty(cboMotivoDenegacion.SelectedValue.Trim()))
                    {
                        _utiles.Mensaje("Seleccione el motivo del rechazo del crédito.");
                        cboMotivoDenegacion.Focus();
                        return false;
                    }
                }
            }

            if (idEstado==2)
            {
                if (LstObservaciones.Count(x => !x.lSubsanado) > 0)
                {
                    _utiles.Mensaje("Para aprobar la solicitud debe de subsanar todas las observaciones. Ingrese al aplicativo Core Bank para windows.");
                    return false;
                }
            }
            return true;
        }

        #endregion

    }

}