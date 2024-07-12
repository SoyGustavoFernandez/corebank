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
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RPT.Presentacion
{
    public partial class frmReporte21 : frmBase
    {
        public frmReporte21()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }
        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dFecPro = dtpFecProceso.Value.Date;

            DataTable dsReporte20A = new clsRPTCNContabilidad().CNReporte20A(dFecPro);
            if (dsReporte20A.Rows.Count > 0)
            {
                string cDesFecha = "Información al: ";

                cDesFecha = cDesFecha + clsVarGlobal.dFecSystem.Day.ToString() + " de ";
                cDesFecha = cDesFecha + new clsCNMeses().listarMeses().AsEnumerable().Where(x=>(int)x["idMeses"]==clsVarGlobal.dFecSystem.Month).ToList()[0]["cMes"].ToString() + " de ";
                cDesFecha = cDesFecha + clsVarGlobal.dFecSystem.Year.ToString() ;

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsReporte20A", dsReporte20A));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cDesFecha", cDesFecha, false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));


                string reportpath = "rptReporte21.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 20A", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblBase2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

        private void btn20A_Click(object sender, EventArgs e)
        {
            DateTime dFecPro = dtpFecProceso.Value.Date;

            DataTable dsReporte21A = new clsRPTCNContabilidad().CNReporte21A(dFecPro);
            if (dsReporte21A.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 21A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cDesFecha = "Información al: ";

                cDesFecha = cDesFecha + dFecPro.Day.ToString() + " de ";
                cDesFecha = cDesFecha + new clsCNMeses().listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == dFecPro.Month).ToList()[0]["cMes"].ToString() + " de ";
                cDesFecha = cDesFecha + dFecPro.Year.ToString();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cDesFecha", cDesFecha, false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte21A", dsReporte21A));

                string reportpath = "rptReporte21A.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            DateTime dFecPro = dtpFecProceso.Value.Date;

            DataSet dsReporte21 = new clsRPTCNContabilidad().CNReporte21(dFecPro);
            DataTable dtReporte21 = dsReporte21.Tables[0];
            DataTable dtReporte21Res = dsReporte21.Tables[1];

            if (dtReporte21.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte 21", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("x_dFecha", dFecPro.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsReporte21", dtReporte21));
                dtslist.Add(new ReportDataSource("dtsReporte21Res", dtReporte21Res));

                string reportpath = "RptReporte21.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }
    }
}
