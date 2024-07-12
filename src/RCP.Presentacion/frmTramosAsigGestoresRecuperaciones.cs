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
    public partial class frmTramosAsigGestoresRecuperaciones : frmBase
    {
        #region Variables
        clsCNReportes cnreportes = new clsCNReportes();
        #endregion

        #region constructor
        public frmTramosAsigGestoresRecuperaciones()
        {
            InitializeComponent();
        }
        #endregion

        #region eventos
        private void frmTramosAsigGestoresRecuperaciones_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void cboPeriodo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioPeriodo();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void chbInicioMeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInicioMeta.Checked)
            {
                dtpFecha.Enabled = false;
            }
            else
            {
                dtpFecha.Enabled = true;
            }
        }
        #endregion

        #region metodos
        private void cambioPeriodo()
        {
            if (cboPeriodo1.SelectedIndex >= 0)
            {
                String cPeriodo = Convert.ToString(cboPeriodo1.SelectedValue);
                DateTime dtFecha = new DateTime(Convert.ToInt32(cPeriodo.Substring(2, 4)), Convert.ToInt32(cPeriodo.Substring(0, 2)), 1);
                dtpFecha.MinDate = new DateTime(1990, 1, 1);
                dtpFecha.MaxDate = new DateTime(2200, 1, 1);
                dtpFecha.MinDate = dtFecha;
                dtpFecha.MaxDate = dtFecha.AddMonths(1).AddDays(-1);
                dtpFecha.Value = dtFecha;
            }
        }

        private void imprimir()
        {
            string cPeriodo = Convert.ToString(cboPeriodo1.SelectedValue);

            string cTitulo = (chbInicioMeta.Checked) ? "REPORTE DE INICIO DE META DEL PERIODO: " + cboPeriodo1.Text + " - TRAMOS ASIGNADOS A " + cboListaPerfil1.Text.ToUpper()
                                                     : "TRAMOS ASIGNADOS A " + cboListaPerfil1.Text.ToUpper() + " DEL PERIODO: " + cboPeriodo1.Text + " A LA FECHA " + Convert.ToDateTime(dtpFecha.Value).ToString("dd/MM/yyyy");

            DataTable dtTramosRecuperaciones = cnreportes.AsignacionTramosCredGestorRecuperaciones(Convert.ToString(cboPeriodo1.SelectedValue), (chbInicioMeta.Checked) ? new DateTime(Convert.ToInt32(cPeriodo.Substring(2, 4)), Convert.ToInt32(cPeriodo.Substring(0, 2)), 1).AddDays(-1) : Convert.ToDateTime(dtpFecha.Value), chbInicioMeta.Checked, Convert.ToInt32(cboListaPerfil1.SelectedValue));
            if (dtTramosRecuperaciones.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cTitulo", cTitulo, false));
                dtslist.Add(new ReportDataSource("dsCreditos", dtTramosRecuperaciones));

                string reportpath = "rptCredTramosGestoresRecuperaciones.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos a mostrar en el reporte.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void inicializar()
        {
            cboPeriodo1.cargarPeriodoSinTodos();
            cboPeriodo1.SelectedValue = clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year.ToString("0000");
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            cboListaPerfil1.cargarPerfilRecuperadores();
        }
        #endregion
    }
}
