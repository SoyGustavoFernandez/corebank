using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRE.Presentacion
{
    public partial class frmRankingOtorgamientoCred : frmBase
    {
        private clsCNMonitorOtorgamientoCred objCNMonitorOtorgCred = new clsCNMonitorOtorgamientoCred(); 
        public frmRankingOtorgamientoCred()
        {
            InitializeComponent();

            this.cboZona.AgregarTodos();
        }


        #region Eventos

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            this.GraficarRanking();
        }

        private void btnSegColocaciones_Click(object sender, EventArgs e)
        {
            //int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            //int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idAgencia = 0;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            //if (idZona <= 0) { MessageBox.Show("Seleccione una región especifica"); return; }
            DateTime dFechaSistema = clsVarGlobal.dFecSystem.Date;
            //int nIndiceTabla = e.ColumnIndex;


            DataSet dsRes = objCNMonitorOtorgCred.RptSeguimientoDiarioColocaciones(dFechaSistema, idAgencia, idZona);

            if (dsRes.Tables[0].Rows.Count == 0 && dsRes.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte seguimiento diario de colocaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            //paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            //paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsMeta", dsRes.Tables[0]));
            dtslist.Add(new ReportDataSource("dsDesembolso", dsRes.Tables[1]));

            string reportpath = "rptSeguimientoDiarioColocaciones.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnAmortizacionesEsp_Click(object sender, EventArgs e)
        {
            //int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            //int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idAgencia = 0;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);

            //if (idZona <= 0) { MessageBox.Show("Seleccione una región especifica"); return; }
            DateTime dFechaSistema = clsVarGlobal.dFecSystem.Date;
            //int nIndiceTabla = e.ColumnIndex;


            DataTable dtRes = objCNMonitorOtorgCred.RptAmortizacionesEsperadas(dFechaSistema, idAgencia, idZona);

            if (dtRes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            paramlist.Add(new ReportParameter("nPorcentAmortNoEsperada", clsVarApl.dicVarGen["nPorcentAmortNoEsperada"].ToString(), false)); 
            //paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtRes));

            string reportpath = "rptAmortizacionesEsperadas.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelacionesEsp_Click(object sender, EventArgs e)
        {
            //int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            //int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idAgencia = 0;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            //if (idZona <= 0) { MessageBox.Show("Seleccione una región especifica"); return; }
            DateTime dFechaSistema = clsVarGlobal.dFecSystem.Date;
            //int nIndiceTabla = e.ColumnIndex;


            DataTable dtRes = objCNMonitorOtorgCred.RptCancelacionesEsperadas(dFechaSistema, idAgencia, idZona);

            if (dtRes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Cancelaciones Esperadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            paramlist.Add(new ReportParameter("nPorcentCancelNoEsperada", clsVarApl.dicVarGen["nPorcentCancelNoEsperada"].ToString(), false));
            //paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtRes));

            string reportpath = "rptCancelacionesEsperadas.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintControl(this.tbcBase1);
        }

        #endregion

        #region Metodos
        private void GraficarRanking()
        {
            //int idZona = 1;
            int idZona = Convert.ToInt32(this.cboZona.SelectedValue);
            DataSet dsRes = this.objCNMonitorOtorgCred.ObtenerRanksOtorgaminetoCreditos(idZona);


            this.chtRnkDesembolso.DataSource = dsRes.Tables[2];
            this.chtRnkDesembolso.Series["Series1"].XValueMember = "cNomCorto";
            this.chtRnkDesembolso.Series["Series1"].YValueMembers = "nCapital";
            this.chtRnkDesembolso.Series["Series1"].ChartType = SeriesChartType.Bar;
            this.chtRnkDesembolso.Titles.Clear();
            this.chtRnkDesembolso.Titles.Add("Ranking de Desembolso");
            this.chtRnkDesembolso.DataBind();

            this.chtRnkAprobado.DataSource = dsRes.Tables[1];
            this.chtRnkAprobado.Series["Series1"].XValueMember = "cNomCorto";
            this.chtRnkAprobado.Series["Series1"].YValueMembers = "nCapital";
            this.chtRnkAprobado.Series["Series1"].ChartType = SeriesChartType.Bar;
            this.chtRnkAprobado.Titles.Clear();
            this.chtRnkAprobado.Titles.Add("Ranking de Aprobado");
            this.chtRnkAprobado.DataBind();


            this.chtRnkComite.DataSource = dsRes.Tables[0];
            this.chtRnkComite.Series["Series1"].XValueMember = "cNomCorto";
            this.chtRnkComite.Series["Series1"].YValueMembers = "nCapital";
            this.chtRnkComite.Series["Series1"].ChartType = SeriesChartType.Bar;
            this.chtRnkComite.Titles.Clear();
            this.chtRnkComite.Titles.Add("Ranking de Comite");
            this.chtRnkComite.DataBind();
        }

        private static void PrintControl(Control control)
        {
            var bitmap = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));

            Bitmap imagen = new Bitmap(bitmap, new Size(Convert.ToInt32(bitmap.Width*0.83), Convert.ToInt32(bitmap.Height*0.90)));

            var pd = new PrintDocument();
            //pd.Portrait=
            pd.PrintPage += (s, e) => e.Graphics.DrawImage(imagen, 10, 60);
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 794, 1123);
            pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            

            PrintDialog printdlg = new PrintDialog();
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();


            // preview the assigned document or you can create a different previewButton for it
            printPrvDlg.ClientSize = new Size(1123, 794);
            printPrvDlg.Document = pd;
            printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below

            printdlg.Document = pd;

            if (printdlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            //pd.Print();            
        }
        #endregion
    }
}
