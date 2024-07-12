using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CLI.CapaNegocio;
using RPT.CapaNegocio;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptPlanillaMovilidad : frmBase
    {
        public frmRptPlanillaMovilidad()
        {
            InitializeComponent();            
        }      

        private void frmRptPlanillaMovilidad_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem; 
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCol1.txtNom.Text) && chcTodosColab.Checked==false)
            {
                MessageBox.Show("Deber de Seleccionar datos de Colaborador", "Reporte Planilla de Movilidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           

            int idCliente = Convert.ToInt32(conBusCol1.idCliPer);
            string dFecIni = this.dtpFecIni.Value.ToShortDateString();
            string dFecFin = this.dtpFecFin.Value.ToShortDateString();

            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            int idAgencia = clsVarGlobal.nIdAgencia;
            int nNumUsuario = clsVarGlobal.User.idUsuario;
            decimal nSueldoMinVital = clsVarApl.dicVarGen["nSueldoMinVital"];

            DataTable dtDatosRpt = new clsRPTCNAgencia().CNAgenciaUsuario(idAgencia, nNumUsuario);
            DataTable dtRptPlanillaMov = new clsCNComprobantes().CNRptPlanillaMov(idCliente, Convert.ToDateTime(dFecIni), Convert.ToDateTime(dFecFin));

            if (dtRptPlanillaMov.Rows.Count <= 0)
            {
                MessageBox.Show("No se encontraton registros para el reporte.", "Reporte Planilla de Movilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cVarVal, false));
                paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("nNumAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("nNumUsuario", nNumUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false)); // enviar el codigo de cliente
                paramlist.Add(new ReportParameter("dFechaIni", dFecIni, false));
                paramlist.Add(new ReportParameter("dFechaFin", dFecFin, false));
                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsDatosEmpresa", dtDatosRpt));
                dtslist.Add(new ReportDataSource("dtsGastoMovilidad", dtRptPlanillaMov));

                if (idCliente==0)
                {
                    string reportpath = "rptPlanillaMovilidadGeneral.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                {
                    paramlist.Add(new ReportParameter("nSueldoMinVital", nSueldoMinVital.ToString(), false));

                    string reportpath = "rptPlanillaMovilidadxColab.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }                
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void chcTodosColab_CheckedChanged(object sender, EventArgs e)
        {
            conBusCol1.txtCod.Enabled = !chcTodosColab.Checked;
            conBusCol1.btnConsultar.Enabled = !chcTodosColab.Checked;            
            if (chcTodosColab.Checked)
            {
                conBusCol1.txtCod.Clear();
                conBusCol1.txtCargo.Clear();
                conBusCol1.txtNom.Clear();
                conBusCol1.idCliPer = "0";
            }            
        }

        private void Limpiar()
        {
            conBusCol1.txtCod.Clear();
            conBusCol1.txtCargo.Clear();
            conBusCol1.txtNom.Clear();
            chcTodosColab.Checked = false;
            if (!chcTodosColab.Checked)
            {
                conBusCol1.txtCod.Enabled = !chcTodosColab.Checked;
                conBusCol1.btnConsultar.Enabled = !chcTodosColab.Checked;
            } 

            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }
    }
}
