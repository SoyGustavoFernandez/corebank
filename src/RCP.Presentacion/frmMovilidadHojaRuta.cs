using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmMovilidadHojaRuta : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();
        public frmMovilidadHojaRuta()
        {
            InitializeComponent();
        }

        private void frmMovilidadHojaRuta_Load(object sender, EventArgs e)
        {
            cboUsuRecuperadores1.cargarTodosGestoresUnicos();
            dtpFechaInicio.Value = dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni = (DateTime)dtpFechaInicio.Value;
            DateTime dFechaFin = (DateTime)dtpFechaFin.Value;
            DataTable dtMovilidadHojaRuta = cnReportes.MovilidadHojaRuta(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), dFechaIni, dFechaFin);
            if (dtMovilidadHojaRuta.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                paramlist.Add(new ReportParameter("cGestor", cboUsuRecuperadores1.Text, false));
                paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));

                dtslist.Add(new ReportDataSource("dsHojaRutaMovilidad", dtMovilidadHojaRuta));

                string reportpath = "rptHojaDeRutaMovilidad.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos a mostrar en el reporte.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
