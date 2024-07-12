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
    public partial class frmReporteRecuperacionEfectiva : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();

        public frmReporteRecuperacionEfectiva()
        {
            InitializeComponent();
        }

        private void frmReporteRecuperacionEfectiva_Load(object sender, EventArgs e)
        {
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MMMM yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem;
            dtpPeriodo.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            
            DataTable dtCreditos = new DataTable(); ;
            if (chcReporteEnLinea.Checked)
            {
                dtCreditos = cnReportes.ListarRecuperacionesEfectivas(clsVarGlobal.dFecSystem);
            }
            else
            {
                DateTime dFechaSeleccionada = Convert.ToDateTime(dtpPeriodo.Value);

                dFechaSeleccionada = new DateTime(dFechaSeleccionada.Year, dFechaSeleccionada.Month, 1).AddMonths(1);
                dFechaSeleccionada = dFechaSeleccionada.AddDays(-1);
                dtCreditos = cnReportes.HistoricoRecuperacionesEfectivas(dFechaSeleccionada);
            }
            
            if (dtCreditos.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                dtslist.Add(new ReportDataSource("dsCreditosRecuperados", dtCreditos));

                string reportpath = "rptRecuperacionesEfectivas.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el reporte", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chcReporteEnLinea_CheckedChanged(object sender, EventArgs e)
        {
            grbDatos.Enabled = !chcReporteEnLinea.Checked;

            if (chcReporteEnLinea.Checked)
            {
                dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem; 
                dtpPeriodo.Value = clsVarGlobal.dFecSystem;                
            }
            else
            {
                dtpPeriodo.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
                dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem.AddMonths(-1);                
            }
        }


    }
}
