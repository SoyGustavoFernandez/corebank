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

namespace CRE.Presentacion
{
    public partial class frmRptCampania : frmBase
    {
        int idPro = 1;
        public frmRptCampania()
        {
            InitializeComponent();
            cboTipCredito.CargarProducto(idPro);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
            int nAtrasoMax = Convert.ToInt32(txtAtrMaximo.Text);
            int nPromedioAtraso = Convert.ToInt32(nudPorCuoPagada.Value);
            decimal nPorceCuoPagada = Convert.ToInt32(txtPromedioAtraso.Text);

            DataTable dtCampania = new clsRPTCNCredito().CNDetalleCampania(idProducto, nPorceCuoPagada, nAtrasoMax, nPromedioAtraso);
            if (dtCampania.Rows.Count==0)
            {
                MessageBox.Show("No existen datos para reporte", "Reporte Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cProducto", cboSubProducto.Text, false));
            paramlist.Add(new ReportParameter("x_nAtrasoMax", txtAtrMaximo.Text, false));
            paramlist.Add(new ReportParameter("x_nPromedioAtr", txtPromedioAtraso.Text, false));
            paramlist.Add(new ReportParameter("x_nPorcentaje", Convert.ToString(nudPorCuoPagada.Value), false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCampania", dtCampania));

            string reportpath = "RptCampania.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void cboTipCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipCredito.SelectedIndex > 0)
            {
                cboSubTipo.CargarProducto(Convert.ToInt32(cboTipCredito.SelectedValue));
            }
        }

        private void cboSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipo.SelectedIndex > 0)
            {
                cboProducto.CargarProducto(Convert.ToInt32(cboSubTipo.SelectedValue));
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                cboSubProducto.CargarProducto(Convert.ToInt32(cboProducto.SelectedValue));
            }
        }
    }
}
