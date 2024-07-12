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

namespace CNT.Presentacion
{
    public partial class frmMovCtaCtb : frmBase
    {
        public frmMovCtaCtb()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmLibroMayor_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboMoneda.CargaDatosContaTodos();
            //cboMoneda.SelectedValue = 1;
        }

        #endregion

        #region Metodos

        private Boolean validar()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la Incial", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCtaCtb.Text))
            {
                MessageBox.Show("Debe ingresar una cuenta contable valida", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private void btnBusCta_Click(object sender, EventArgs e)
        {
            txtCtaCtb.Text = "";
            frmBuscaCtaCtb frmBscCtaCtbDeb = new frmBuscaCtaCtb();
            frmBscCtaCtbDeb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtbDeb.pcCtaCtb)) return;
            txtCtaCtb.Text = frmBscCtaCtbDeb.pcCtaCtb;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string pcCuenta = txtCtaCtb.Text;
                int idMoneda =Convert.ToInt32(cboMoneda.SelectedValue);
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cCtaCtb", pcCuenta, false));
                paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("x_cMoneda", cboMoneda.Text, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsMovCta", new clsRPTCNContabilidad().CNMovCtaCtb(dFecIni, dFecFin, pcCuenta, idMoneda)));
                string reportpath = "RptMovimientoCuentaCnt.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string pcCuenta = txtCtaCtb.Text;
                int idMoneda =Convert.ToInt32(cboMoneda.SelectedValue);
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cCtaCtb", pcCuenta, false));
                paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("x_cMoneda", cboMoneda.Text, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsResMovCta", new clsRPTCNContabilidad().CNResMovCtaCtb(dFecIni, dFecFin, pcCuenta, idMoneda)));
                string reportpath = "RptResMovCuentaCnt.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
