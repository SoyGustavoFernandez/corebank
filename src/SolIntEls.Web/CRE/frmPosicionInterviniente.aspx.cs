using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using SolIntEls.Web.utiles;
using System.Web.Security;

namespace SolIntEls.Web.CRE
{
    public partial class frmPosicionInterviniente : System.Web.UI.Page
    {
        #region Variables Globales

        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        clsCNBuscarCli cncliente = new clsCNBuscarCli();
        clsUtilitarios cnutiles = new clsUtilitarios();

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

                lblUsuario.Text = objVarGlobal.User.cWinUser;
                this.txtDocumento.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            }
        }

        protected void lnkSalir_ServerClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect("../frmInicio.aspx", true);
        }

        protected void BtnConsultar1_Click(object sender, EventArgs e)
        {
            clsUsuario usuario = null;

            if (objVarGlobal.User != null)
            {
                usuario = (clsUsuario)objVarGlobal.User;
            }
            else
            {
                throw new Exception("La sesión de usuario terminó, vuelva a ingresar");
            }

            if (validar())
            {
                string cCriterio = "", cNombre = "";
                var cDocumento = this.txtDocumento.Text.Trim();
                bool lCliente = false;
                int idCli = 0;

                if (cDocumento.Length == 8)
                {
                    cCriterio = "1";
                }
                if (cDocumento.Length == 11)
                {
                    cCriterio = "3";
                }
                var dtCliente = cncliente.ListarClientes(cCriterio, cDocumento);

                if (dtCliente.Rows.Count > 0)
                {
                    cNombre = dtCliente.Rows[0]["cNombre"].ToString();
                    idCli = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                    lCliente = true;
                }
                else
                {
                    var dtPersonaSBS = cninterviniente.ValidaExistePersonaSBS(cDocumento);
                    if (dtPersonaSBS.Rows.Count > 0)
                    {
                        cNombre = dtPersonaSBS.Rows[0]["cNombre"].ToString();
                    }
                    else
                    {
                        pnlMensaje.Visible = true;
                        ReportViewer1.Visible = false;
                        lblMensaje.Text = "Documento ingresado no contiene registros históricos ni base de datos de RCC";
                        return;
                    }
                }

                ReportViewer1.Visible = true;
                pnlMensaje.Visible = false;

                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = @"REPORTES/RptPosInterv.rdlc";
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.DisplayName = cDocumento;
                ReportViewer1.LocalReport.DataSources.Clear();

                #region Asignacion de Tablas y parametros

                var clsvarglobal = objVarGlobal;

                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("cNumDocuId", cDocumento));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("cNomInterv", cNombre));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("dFechaSis", clsvarglobal.dFecSystem.ToString("dd/MM/yyyy")));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("cNomAgen", clsvarglobal.dFecSystem.ToString("dd/MM/yyyy")));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("cRutaLogo", objVarApl.dicVarGen["CRUTALOGO"]));


                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsSaldosRCD", cninterviniente.CNdtLisSalRCC(cDocumento)));
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsCalifiRCD", cninterviniente.CNdtLisCalifiRCDSBS(cDocumento)));
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsBaseNegativa", cninterviniente.CNdtLisDatBaseNegativa(cDocumento)));
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsPEP", cninterviniente.CNdtLisDatPEP(cDocumento)));
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsRastreo", cninterviniente.CNdtLstRastreo(cDocumentoID: cDocumento)));
               
                if (lCliente)
                {
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCrexCli", cninterviniente.CNdtLisCrexCli(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisGarxCli", cninterviniente.CNdtLisGarxCli(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCreGarxCli", cninterviniente.CNdtLisCreGarxCli(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisGarOtrUtixCli", cninterviniente.CNdtLisGarOtrUtixCli(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCtaAhoxCli", cninterviniente.CNdtLisCtaAhoxCli(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliCreMismaDire", cninterviniente.CNdtLisCliCreMismaDire(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisVinculadosaCli", cninterviniente.CNdtLisVinculadosaCli(cDocumento)));

                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliMismaGar", cninterviniente.CNdtLisCliMismaGar(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono", cninterviniente.CNdtLisCliRelaGrupoEcono(cDocumento)));
                    //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsSolCreCli", cninterviniente.CNdtLisSolCreCli(cDocumento)));
                }
                else
                {
                    DataTable dtNoCliente = new DataTable();//Se envia una tabla vacia para que no realice búsquedas en la base de datos interna

                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCrexCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisGarxCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCreGarxCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisGarOtrUtixCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCtaAhoxCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliCreMismaDire", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisVinculadosaCli", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliMismaGar", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsLisCliRelaGrupoEcono", dtNoCliente));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtsSolCreCli", dtNoCliente));
                }

                #endregion

                cnutiles.registrarRastreo(1,2,usuario,idCli, 0, "Consulta - Posición integral de intervinientes", this.BtnConsultar1, cDocumento);

                this.ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                pnlMensaje.Visible = true;
                ReportViewer1.Visible = false;
            }
        }

        protected void click_Logo(object sender, EventArgs e)
        {
            if (objVarGlobal.User == null)
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

        #region Métodos

        private bool validar()
        {
            bool lEstado = false;

            var cDocumento = this.txtDocumento.Text.Trim().Replace(".", "").Replace(",", "");

            if (cDocumento == "")
            {
                lblMensaje.Text="Debe de ingresar el número de documento";
                return lEstado;
            }

            if (cDocumento.Length < 8)
            {
                lblMensaje.Text = "Debe de ingresar el número de documento válido";
                return lEstado;
            }

            lEstado = true;
            return lEstado;
        }

        #endregion
    }
}