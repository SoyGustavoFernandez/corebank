using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmInformacionFinanc : frmBase
    {
        public frmInformacionFinanc()
        {
            InitializeComponent();
        }

        private void frmInformacionFinanc_Load(object sender, EventArgs e)
        {
            this.dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;

            DataTable dtEmplSocios = new clsRPTCNContabilidad().CNEmpleadosySocios(dFecProceso);
            DataTable dtCalifCartera = new clsRPTCNContabilidad().CNCalifCartera(dFecProceso);
            DataTable dtProvisionProc = new clsRPTCNContabilidad().CNProvisionProc(dFecProceso);
            DataTable dtCreTipoSector = new clsRPTCNContabilidad().CNCreTipoSector(dFecProceso);
            DataTable dtSaldosCreVenc = new clsRPTCNContabilidad().CNSaldosCreVenc(dFecProceso);
            DataTable dtNroCreVenc = new clsRPTCNContabilidad().CNNroCreVenc(dFecProceso);
            
            if (dtEmplSocios.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Información Financiera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dAnio", dFecProceso.Year.ToString(), false));
                paramlist.Add(new ReportParameter("x_dMes", dFecProceso.ToString("MMMM"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));


                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsEmpleSocios", dtEmplSocios));
                dtslist.Add(new ReportDataSource("dsCalifCartera", dtCalifCartera));
                dtslist.Add(new ReportDataSource("dsProvProc", dtProvisionProc));
                dtslist.Add(new ReportDataSource("dsCreditoTipoSector", dtCreTipoSector));
                dtslist.Add(new ReportDataSource("dsSaldosCreVenc", dtSaldosCreVenc));
                dtslist.Add(new ReportDataSource("dsNroCreVenc", dtNroCreVenc));

                string reportpath = "rptInforFinanciera.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = this.dtpFechaProceso.Value.Date;
            DataTable dtEmplSocios = new clsRPTCNContabilidad().CNEmpleadosySocios(dFecProceso);
            DataTable dtCalifCartera = new clsRPTCNContabilidad().CNCalifCartera(dFecProceso);
            DataTable dtProvisionProc = new clsRPTCNContabilidad().CNProvisionProc(dFecProceso);
            DataTable dtCreTipoSector = new clsRPTCNContabilidad().CNCreTipoSector(dFecProceso);
            DataTable dtSaldosCreVenc = new clsRPTCNContabilidad().CNSaldosCreVenc(dFecProceso);
            DataTable dtNroCreVenc = new clsRPTCNContabilidad().CNNroCreVenc(dFecProceso);

            if (dtEmplSocios.Rows.Count > 0)
            {
                
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dAnio", dFecProceso.Year.ToString(), false));
                paramlist.Add(new ReportParameter("x_dMes", dFecProceso.ToString("MMMM"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsEmpleSocios", dtEmplSocios));
                dtslist.Add(new ReportDataSource("dsCalifCartera", dtCalifCartera));
                dtslist.Add(new ReportDataSource("dsProvProc", dtProvisionProc));
                dtslist.Add(new ReportDataSource("dsCreditoTipoSector", dtCreTipoSector));
                dtslist.Add(new ReportDataSource("dsSaldosCreVenc", dtSaldosCreVenc));
                dtslist.Add(new ReportDataSource("dsNroCreVenc", dtNroCreVenc));

                string reportpath = "rptInforFinanciera.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Reporte 6A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }
    }
}
