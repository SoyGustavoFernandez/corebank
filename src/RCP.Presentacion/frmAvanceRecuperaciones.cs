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
    public partial class frmAvanceRecuperaciones : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();
        String cPeriodo = "";
        public frmAvanceRecuperaciones()
        {
            InitializeComponent();
        }

        private void frmAvanceRecuperaciones_Load(object sender, EventArgs e)
        {
            cboPeriodo1.cargarPeriodoSinTodos();
            cPeriodo = clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year;
            cboPeriodo1.SelectedValue = cPeriodo;
            cboListaPerfil1.cargarPerfilRecuperadores();
            dtpFecha.MaxDate = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtAvanceRecuperaciones = cnReportes.AvanceRecuperaciones(Convert.ToString(cboPeriodo1.SelectedValue), Convert.ToInt32(cboListaPerfil1.SelectedValue), Convert.ToDateTime(dtpFecha.Value));

            if (dtAvanceRecuperaciones.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cPerfil", cboListaPerfil1.Text, false));
                if (cPeriodo == Convert.ToString(cboPeriodo1.SelectedValue))
                {
                    paramlist.Add(new ReportParameter("dFecIni", new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("dFecFin", Convert.ToDateTime(dtpFecha.Value).ToString("dd/MM/yyyy"), false));
                }
                else
                {
                    DateTime dFechaInicial = new DateTime(Convert.ToInt32(Convert.ToString(cboPeriodo1.SelectedValue).Substring(2, 4)), Convert.ToInt32(Convert.ToString(cboPeriodo1.SelectedValue).Substring(0, 2)), 1);
                    DateTime dFechaFin = dFechaInicial.AddMonths(1).AddDays(-1);
                    paramlist.Add(new ReportParameter("dFecIni", dFechaInicial.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("dFecFin", Convert.ToDateTime(dtpFecha.Value).ToString("dd/MM/yyyy"), false));
                }
                dtslist.Add(new ReportDataSource("dsAvancesRecuperacion", dtAvanceRecuperaciones));

                string reportpath = "rptAvanceRecuperaciones.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el reporte", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void cboPeriodo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodo1.SelectedIndex >= 0)
            {
                int nAño = Convert.ToInt32(cboPeriodo1.SelectedValue.ToString().Substring(2, 4));
                int nMes = Convert.ToInt32(cboPeriodo1.SelectedValue.ToString().Substring(0, 2));
                DateTime dFechaIniMes = new DateTime(nAño, nMes, 1);
                dtpFecha.MaxDate = new DateTime(nAño + 1, 1, 1);
                dtpFecha.MinDate = new DateTime(nAño - 1, 1, 1);


                dtpFecha.MaxDate = dFechaIniMes.AddMonths(1).AddDays(-1);
                dtpFecha.MinDate = dFechaIniMes;
            }
        }
    }
}
