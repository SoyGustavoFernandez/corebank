using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace CNT.Presentacion
{
    public partial class frmRptContabilidad2 : frmBase
    {
        clsRPTCNContabilidad clsRptConta = new clsRPTCNContabilidad();
        public int idCentroCosotos = 0;
        public int idProyecto = 0;
        public frmRptContabilidad2()
        {
            InitializeComponent();
        }

        private void frmRptContabilidad2_Load(object sender, EventArgs e)
        {
            cboMonedas.CargaDatosContaTodos();
            dtpFechaIni.Value = Convert.ToDateTime(clsVarGlobal.dFecSystem.Date);
            dtpFechaFin.Value = Convert.ToDateTime(clsVarGlobal.dFecSystem.Date);
            txtProyecto.Text = "** Todos **";
            cboEstablecimiento1.Enabled = false;


            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Columns.Add(new DataColumn("centroResp", typeof(string)));

            dr = dt.NewRow();dr["centroResp"] = "** Todos **";dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["centroResp"] = "Centro de Inversión"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["centroResp"] = "Centro de Gastos"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["centroResp"] = "Centro de Ingresos"; dt.Rows.Add(dr);

            cboCentroResp.DataSource = dt;
            cboCentroResp.DisplayMember = "centroResp";
            cboCentroResp.SelectedIndex = 0;

            txtCentroCostos.Text = "** Todos **";

            DataTable dt_ = new DataTable();
            DataRow dr_ = null;
            dt_.Columns.Clear();
            dt_.Rows.Clear();
            dt_.Columns.Add(new DataColumn("anio", typeof(string)));

            for (int i = Convert.ToInt32(clsVarGlobal.dFecSystem.Year); i >= 2013; i--)
            {
                dr_ = dt_.NewRow();
                dr_["anio"] = i;
                dt_.Rows.Add(dr_);
            }

            cboAnio.DataSource = dt_;
            cboAnio.DisplayMember = "anio";
            cboAnio.SelectedIndex = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();
            string establec = "** Todos **";
            if (cboEstablecimiento1.Text != "")
                establec = cboEstablecimiento1.Text;

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            paramlist.Add(new ReportParameter("cCentroCostos", txtCentroCostos.Text, false));
            paramlist.Add(new ReportParameter("cAgencia", cboAgencia.Text, false));
            paramlist.Add(new ReportParameter("cEstablecimiento", establec, false));
            paramlist.Add(new ReportParameter("cProyecto", txtProyecto.Text, false));
            paramlist.Add(new ReportParameter("cCentroResp", cboCentroResp.Text, false));
            paramlist.Add(new ReportParameter("cMoneda", cboMonedas.Text, false));
            paramlist.Add(new ReportParameter("nCifras", NumDig.Text, false));

            string reportpath = "";
            DataTable datos;
            if (rptAcumulado.Checked)
            {
                paramlist.Add(new ReportParameter("dFechaIni", dtpFechaIni.Text, false));
                paramlist.Add(new ReportParameter("dFechaFin", dtpFechaFin.Text, false));
                datos = clsRptConta.CNRptMontosCuentasContabilidad(
                       Convert.ToDateTime(dtpFechaIni.Value),
                       Convert.ToDateTime(dtpFechaFin.Value),
                       idCentroCosotos,
                       Convert.ToInt32(cboAgencia.SelectedValue),
                       Convert.ToInt32(cboEstablecimiento1.SelectedValue),
                       idProyecto,
                       Convert.ToInt32(cboCentroResp.SelectedIndex),
                       Convert.ToInt32(cboMonedas.SelectedValue),
                       Convert.ToInt32(NumDig.Value)
                );
                dtslist.Add(new ReportDataSource("dtsDatos", datos));
                reportpath = "rptMontosCuentasContabilidad.rdlc";
            }
            else
            {
                paramlist.Add(new ReportParameter("nAnio", cboAnio.Text, false));
                datos = clsRptConta.CNRptHistoricoCuentasContabilidad(
                       Convert.ToInt32(cboAnio.Text),
                       idCentroCosotos,
                       Convert.ToInt32(cboAgencia.SelectedValue),
                       Convert.ToInt32(cboEstablecimiento1.SelectedValue),
                       idProyecto,
                       Convert.ToInt32(cboCentroResp.SelectedIndex),
                       Convert.ToInt32(cboMonedas.SelectedValue),
                       Convert.ToInt32(NumDig.Value)
                );
                dtslist.Add(new ReportDataSource("dtsDatos", datos));
                reportpath = "rptContabilidadHistorico.rdlc";
            }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = Convert.ToDateTime(dtpFechaIni.Value);
            if( dtpFechaIni.Value > dtpFechaFin.Value )
                dtpFechaFin.Value = Convert.ToDateTime(dtpFechaIni.Value);
        }

        private void btnFrmCentroCosto_Click(object sender, EventArgs e)
        {
            bool selecionarPadre = true;
            frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto(selecionarPadre);
            frmBuscaCtrCosto.ShowDialog();
            if (frmBuscaCtrCosto.pnidCentroCosto == 0) return;
            idCentroCosotos =  frmBuscaCtrCosto.pnidCentroCosto;
            txtCentroCostos.Text = frmBuscaCtrCosto.pcNombreCentroCosto;
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEstablecimiento1.Enabled = true;
            if (Convert.ToInt32(cboAgencia.SelectedValue) == 0)
            {
                cboEstablecimiento1.Enabled = false;
                cboEstablecimiento1.SelectedValue = 0;
            }

            cboEstablecimiento1.CargarEstablecimientos(Convert.ToInt32(cboAgencia.SelectedValue));
        }

        private void btnProyecto_Click(object sender, EventArgs e)
        {
            frmBuscaProyecto frmProyecto = new frmBuscaProyecto();
            frmProyecto.ShowDialog();
            idProyecto = frmProyecto.pidSubConcepto;
            txtProyecto.Text = frmProyecto.pcSubConcpeto;
            if (idProyecto == 0)
                txtProyecto.Text = "** Todos **";
        }

        private void tipoReporteClick()
        {
            bool acumulado = true;
            if (rptAcumulado.Checked)
                acumulado = true;
            else
                acumulado = false;

            rptAcumulado.Checked = acumulado;
            rptHistorico.Checked = !acumulado;

            lblFechaIni.Visible = acumulado;
            lblFechaFin.Visible = acumulado;
            dtpFechaIni.Visible = acumulado;
            dtpFechaFin.Visible = acumulado;

            lblAnio.Visible = !acumulado;
            cboAnio.Visible = !acumulado;
        }

        private void rptAcumulado_CheckedChanged(object sender, EventArgs e)
        {
            tipoReporteClick();
        }

        private void rptHistorico_CheckedChanged(object sender, EventArgs e)
        {
            tipoReporteClick();
        }

        private void btnCentroCostosCancel_Click(object sender, EventArgs e)
        {
            idCentroCosotos = 0;
            txtCentroCostos.Text = "** Todos **";
        }

        private void btnProyectoCancelar_Click(object sender, EventArgs e)
        {
            idProyecto = 0;
            txtProyecto.Text = "** Todos **";
        }

    }
}
