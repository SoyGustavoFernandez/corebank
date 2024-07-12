using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmReporteReducciones : frmBase
    {
        clsCNCondonacion CNCondonacion = new clsCNCondonacion();
        int nMaxDiasBusqueda = 15;
        public frmReporteReducciones()
        {
            InitializeComponent();
        }

        private void frmReporteReducciones_Load(object sender, EventArgs e)
        {
             dtpHasta.Value = dtpDesde.Value = clsVarGlobal.dFecSystem;
             dtpHasta.Format = DateTimePickerFormat.Long;
             dtpDesde.Format = DateTimePickerFormat.Long;
             cboEstadosAprobacion1.getEstadosAprobacion(TipoOperacionRecuperacion.condonacion);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtpHasta.Value < dtpDesde.Value)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((dtpHasta.Value - dtpDesde.Value).Days > nMaxDiasBusqueda - 1)
            {
                MessageBox.Show("El rango entre las fechas de búsqueda inicial y final solo puede ser en un máximos de " + nMaxDiasBusqueda + " Días.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dtCondonaciones = CNCondonacion.ListarCondonaciones(Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value), Convert.ToInt32(cboEstadosAprobacion1.SelectedValue), Convert.ToInt32(cboAgencia1.SelectedValue));
            if (dtCondonaciones.Rows.Count<=0)
            {
                MessageBox.Show("No se tiene datos para mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            GEN.Funciones.clsNumLetras numLetras = new GEN.Funciones.clsNumLetras();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsCondonaciones", dtCondonaciones));
            string reportpath = "rptReduccionesCob.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();


        }
    }
}
