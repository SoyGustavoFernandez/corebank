using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmSIGSaldoProvTraMora : frmBase
    {
        #region Variable Globales

        private string cRutaReporte = "";
        private string cNombreDataSetRpt = "";
        private int nNroRptImprime = 0;
        private bool lEjecutandoSIGOnline = false;

        #endregion

        public frmSIGSaldoProvTraMora()
        {
            InitializeComponent();
            cboAgencias1.AgenciasYTodos();
            cargarOpcionImprime(1);
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
            cboCalificacion1.cboCalificaTodos();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            imprimirReporte();
        }

        private void rbtOficina_CheckedChanged(object sender, EventArgs e)
        {
            cargarOpcionImprime(1);
        }

        private void rbtProducto_CheckedChanged(object sender, EventArgs e)
        {
            cargarOpcionImprime(2);
        }

        private void rbtCarteraPotencial_CheckedChanged(object sender, EventArgs e)
        {
            cargarOpcionImprime(3);
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked)
            {
                dtpFecha.Value = clsVarGlobal.dFecSystem;
                dtpFecha.Enabled = false;
            }
            else
            {
                dtpFecha.Enabled = true;
                dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
            }
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            imprimirReporte(true);
        }
        #endregion

        #region Métodos
        
        private void imprimirReporte(bool lDetalle = false)
        {
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            int idCalificacion = Convert.ToInt32(cboCalificacion1.SelectedValue);

            DateTime dFechaSel = dtpFecha.Value;
            DataTable dtRpt;
            clsCNCierreCredito EjeSpCierre = new clsCNCierreCredito();


            clsRPTCNCredito cnCredito = new clsRPTCNCredito();

            switch (nNroRptImprime)
            {
                case 1:

                    if (chcBase1.Checked)
                    {
                        this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Inicio - Ejecución de escripts para el SIG 1 saldos", btnImprimir1);

                        cnCredito.CNActualizaSIGOnline(clsVarGlobal.User.idUsuario, 1);
                        lEjecutandoSIGOnline = true;

                        EjeSpCierre.ProcesoCieDia("CRE_HistoricoSaldosContablesFin_sp", 0);
                        EjeSpCierre.ProcesoCieDia("CRE_HistoricoSaldos_sp", 0);
                        EjeSpCierre.ProcesoCieDia("CRE_HistoricoCartaFianzaDia_sp", 0);
                        EjeSpCierre.ProcesoCieDia("CRE_CalificaRCCFechaMaestro_sp", 0);
                        EjeSpCierre.ProcesoCieDia("CRE_CalculoProvision_sp", 0);

                        this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Fin - Ejecución de escripts para el SIG 1 saldos", btnImprimir1);

                        dtRpt = cnCredito.CNRpt001Hist(dFechaSel, true, idAgencia);

                        cnCredito.CNActualizaSIGOnline(clsVarGlobal.User.idUsuario, 0);
                        lEjecutandoSIGOnline = false;
                        //dtRpt = cnCredito.CNRpt001(dFechaSel, idAgencia);
                    }
                    else 
                    {
                        dtRpt = cnCredito.CNRpt001Hist(dFechaSel, false,  idAgencia);
                    }

                    break;
                case 2:
                    if (lDetalle)
                    {
                        cRutaReporte = "rptSIGProvisionDetalle.rdlc";
                        cNombreDataSetRpt = "dsProvisiones";
                        dtRpt = cnCredito.CNRpt002(dFechaSel, idAgencia, idCalificacion);
                    }
                    else
                    {
                        cRutaReporte = "rptSIGProvision.rdlc";
                        cNombreDataSetRpt = "dsProvisiones";
                        dtRpt = cnCredito.CNRpt002(dFechaSel, idAgencia, idCalificacion);
                    }
                    
                    break;
                case 3:
                    dtRpt = cnCredito.CNRptLibEfectRecup(dFechaSel,idAgencia);
                    break;
                default:
                    dtRpt = cnCredito.CNRpt001(dFechaSel, idAgencia);
                    break;
            }

            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource(cNombreDataSetRpt, dtRpt));
                paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("dFechaSel", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                

                string reportPath = cRutaReporte;
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos para esta propuesta", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validar()
        {
            bool lValida = true;

            if (!rbtRpt1.Checked && !rbtRpt2.Checked && !rbtRpt3.Checked)
            {
                MessageBox.Show("Seleccione un reporte para imprimir", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboAgencias1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un agencia o TODOS", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!chcBase1.Checked && dtpFecha.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("En el reporte histórico, la fecha no puede ser igual o posterior a la fecha del sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbtRpt2.Checked && cboCalificacion1.SelectedIndex == -1) 
            {
                MessageBox.Show("Para el reporte de provisiones, debe seleccionar la calidicación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsCNMantenimiento objMant = new clsCNMantenimiento();
            var dtVariables = objMant.ListarVariables(0);
            var drVariable = dtVariables.AsEnumerable().FirstOrDefault(x => Convert.ToString(x["cVariable"]).Equals("lProcesandoCierre"));
            if (drVariable != null)
            {
                int lProcesandoCierre = Convert.ToInt32(drVariable["cValVar"]);
                if (lProcesandoCierre > 0)
                {
                    MessageBox.Show("Se esta procesando el cierre del sistema. No puede generar el reporte hasta que termine dicho proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            string cPerfiles = Convert.ToString(clsVarApl.dicVarGen["cPerfilSIGSinBloqueo"]);
            String[] cPerfil;
            int[] nPerfil;
            cPerfil = cPerfiles.Split(',');
            nPerfil = Array.ConvertAll<string, int>(cPerfil, int.Parse);

            if (!clsVarGlobal.PerfilUsu.idPerfil.In(nPerfil))
            {
                if (chcBase1.Checked)
                {
                    drVariable = null;
                    drVariable = dtVariables.AsEnumerable().FirstOrDefault(x => Convert.ToString(x["cVariable"]).Equals("cInicioSIGIniOnline"));
                    if (drVariable != null)
                    {
                        string ProcesandoSIGOnline = Convert.ToString(drVariable["cValVar"]);
                        if (!string.IsNullOrEmpty(ProcesandoSIGOnline))
                        {
                            MessageBox.Show(ProcesandoSIGOnline, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }

            return lValida;
        }

        private void cargarOpcionImprime(int nNroRpt)
        {
            nNroRptImprime = nNroRpt;
            switch(nNroRpt)
            {
                case 1: 
                    cRutaReporte = "rptSIGSaldoMoraCliente.rdlc";
                    cNombreDataSetRpt = "dsRpt";
                    chcBase1.Enabled = true;
                    chcBase1.Checked = false;
                    lblCalificacion.Visible = false;
                    cboCalificacion1.Visible = false;
                    btnImprimir2.Visible = false;
                    break;
                case 2: 
                    chcBase1.Enabled = false;
                    chcBase1.Checked = false;
                    lblCalificacion.Visible = true;
                    cboCalificacion1.Visible = true;
                    btnImprimir2.Visible = true;
                    break;
                case 3:
                    cRutaReporte = "RptEfectLibRecup.rdlc";
                    cNombreDataSetRpt = "dsData";
                    chcBase1.Enabled = false;
                    chcBase1.Checked = true;
                    lblCalificacion.Visible = false;
                    cboCalificacion1.Visible = false;
                    btnImprimir2.Visible = false;
                    break;
            }
        }

        #endregion

        private void frmSIGSaldoProvTraMora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lEjecutandoSIGOnline)
            {
                clsRPTCNCredito cnCredito = new clsRPTCNCredito();
                cnCredito.CNActualizaSIGOnline(clsVarGlobal.User.idUsuario, 0);
            }
        }

    }
}
