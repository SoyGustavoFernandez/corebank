using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptExtractoBcos : frmBase
    {
        int nIdCuentaInst;
        public frmRptExtractoBcos()
        {
            InitializeComponent();
        }

        private void frmRptExtractoBcos_Load(object sender, EventArgs e)
        {
            this.cboEntidad.Enabled = false;
            this.txtNroCuenta.Enabled = false;
            this.cboMoneda.Enabled = false;
            this.btnBuscarCuenta.Enabled = true;
            this.dtpFecIni.Text = clsVarApl.dicVarGen["dFechaAct"].ToString();
            this.dtpFecFin.Text = clsVarApl.dicVarGen["dFechaAct"].ToString();
        }

        private string ValidarDatos()
        {
            string Msje = "";
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(this.txtNroCuenta.Text.Trim()))
            {
                Msje += "Debe Seleccionar una Cuenta.\n";
                this.btnBuscarCuenta.Focus();
                this.btnBuscarCuenta.Select();
            }
            if (this.dtpFecIni.Value > this.dtpFecFin.Value)
            {
                Msje += "La fecha final no puede ser menor a la fecha inicial.";
                this.dtpFecIni.Focus();
                this.dtpFecIni.Select();
            }
            return Msje;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string Msje = ValidarDatos().Trim();
            if (!string.IsNullOrEmpty(Msje))
            {
                MessageBox.Show(Msje, "Reporte Extracto Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idCtaBco = nIdCuentaInst;
            DateTime dFechaIni = this.dtpFecIni.Value.Date;
            DateTime dFechaFin = this.dtpFecFin.Value.Date;

            paramlist.Add(new ReportParameter("idCtaBco", idCtaBco.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString(), false));


            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsMovBco", new clsRPTCNCaja().CNExtractoBcos(idCtaBco, dFechaIni, dFechaFin)));
            dtslist.Add(new ReportDataSource("dsDatosBco", new clsRPTCNCaja().CNDatosBco(idCtaBco)));

            string reportpath = "RptExtractoBcos.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();

        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst frmBuscar = new frmBusquedaCuentaInst();
            frmBuscar.ShowDialog();
            if (frmBuscar.pcNumeroCuenta == null) return;
            nIdCuentaInst = frmBuscar.pidCuentaInstitucion;
            this.cboEntidad.CargarEntidades(frmBuscar.pidTipoEntidad);
            this.cboEntidad.SelectedValue = frmBuscar.pidEntidad;
            this.txtNroCuenta.Text = frmBuscar.pcNumeroCuenta;
            this.cboMoneda.SelectedValue = frmBuscar.pidMoneda;
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            string Msje = ValidarDatos().Trim();
            if (!string.IsNullOrEmpty(Msje))
            {
                MessageBox.Show(Msje, "Reporte Extracto Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idCtaBco = nIdCuentaInst;
            DateTime dFechaIni = this.dtpFecIni.Value.Date;
            DateTime dFechaFin = this.dtpFecFin.Value.Date;

            paramlist.Add(new ReportParameter("idCtaBco", idCtaBco.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsMovBco", new clsRPTCNCaja().CNExtractoBcosResumen(idCtaBco, dFechaIni, dFechaFin)));
            dtslist.Add(new ReportDataSource("dsDatosBco", new clsRPTCNCaja().CNDatosBco(idCtaBco)));

            string reportpath = "RptExtractoBcosRes.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
