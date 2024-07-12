using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.IO;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmRptReporteMEF : frmBase
    {
        public frmRptReporteMEF()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (rbtCreditoAdeudado.Checked)
            {
                imprimirCeditoAdeudado();
            }
            if (rbtDesembolsoAdeudado.Checked)
            {
                imprimirDesembolsoAdeudado();   
            }
            if (rbtPagoAdeudado.Checked)
            {
                imprimirPagoAdeudado();
            }
            if (rbtCalendarioAdeudado.Checked)
            {
                imprimirCalendarioAdeuado();
            }
        }
        void imprimirCeditoAdeudado()
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());


            paramlist.Add(new ReportParameter("dfechaProceso", dFechaProceso.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "Logo", false));
            
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsMEFAdeudadoCredito", new clsRPTCNCaja().CNRepMEFCreditoAdeudado(dFechaProceso)));
            string reportpath = "rptMEFCreditoAdeudado.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
        void imprimirDesembolsoAdeudado()
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());


            paramlist.Add(new ReportParameter("dfechaProceso", dFechaProceso.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "Logo", false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsDesembolsoAde", new clsRPTCNCaja().CNRepMEFDesembolsoAdeudado(dFechaProceso)));
            string reportpath = "rptMEFDesembolsoAdeudado.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
        void imprimirPagoAdeudado()
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());


            paramlist.Add(new ReportParameter("dfechaProceso", dFechaProceso.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "Logo", false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsPagoAdeudado", new clsRPTCNCaja().CNRepMEFPagoAdeudado(dFechaProceso)));
            string reportpath = "rptMEFPagoAdeudado.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
        void imprimirCalendarioAdeuado()
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());


            paramlist.Add(new ReportParameter("dfechaProceso", dFechaProceso.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "Logo", false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsMEFCalendarioAdeudado", new clsRPTCNCaja().CNRepMEFCalendarioAdeudado(dFechaProceso)));
            string reportpath = "rptMEFCalendarioAdeudado.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());
            clsRPTCNCaja dtrpt = new clsRPTCNCaja();
            if (rbtCreditoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFCreditoAdeudado(dFechaProceso), @"c:\Reportes\Creditos");
            }
            if (rbtDesembolsoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFDesembolsoAdeudado(dFechaProceso), @"c:\Reportes\Desembolsos");
            }
            if (rbtPagoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFPagoAdeudado(dFechaProceso), @"c:\Reportes\Pagos");
            }
            if (rbtCalendarioAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFCalendarioAdeudado(dFechaProceso), @"c:\Reportes\Calendario");
            }
            
        }
        void exportarTxt(DataTable dt, String path)
        {
           String[] texto;
           texto = new String[dt.Rows.Count + 1];
           //Rellenamos la cabecera del fichero
          // texto[0] = String.Empty;
           //for (int i = 0; i < dt.Columns.Count; i++)
           //{
           //   texto[0] += dt.Columns[i].ColumnName + ";";
           //}
           //Rellenamos el detalle del fichero
           String linea;
           for (int i = 0; i < dt.Rows.Count; i++)
           {
              linea = String.Empty;
              for (int j = 0; j < dt.Columns.Count; j++)
              {
                 linea += dt.Rows[i][j].ToString() + ";";
              }
              texto[i + 1] = linea;
           }
           File.WriteAllLines(path + ".txt", texto);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFechaProceso = Convert.ToDateTime(this.dtpFechaProceso.Value.ToShortDateString());
            clsRPTCNCaja dtrpt = new clsRPTCNCaja();
            if (rbtCreditoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFCreditoAdeudado(dFechaProceso), @"c:\Reportes\Creditos");
            }
            if (rbtDesembolsoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFDesembolsoAdeudado(dFechaProceso), @"c:\Reportes\Desembolsos");
            }
            if (rbtPagoAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFPagoAdeudado(dFechaProceso), @"c:\Reportes\Pagos");
            }
            if (rbtCalendarioAdeudado.Checked)
            {
                exportarTxt(dtrpt.CNRepMEFCalendarioAdeudado(dFechaProceso), @"c:\Reportes\Calendario");
            }
        }

        private void frmRptReporteMEF_Load(object sender, EventArgs e)
        {

        }
    }
}
