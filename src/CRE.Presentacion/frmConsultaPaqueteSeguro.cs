using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
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
    public partial class frmConsultaPaqueteSeguro : frmBase
    {
        private DateTime dFechaSistema;
        private readonly string TituloForm = "Consulta Planes de Seguro";
        private clsCNCreditoCargaSeguro _cnCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        public frmConsultaPaqueteSeguro()
        {
            InitializeComponent();
        }

        private void frmConsultaPaqueteSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            dFechaSistema = clsVarGlobal.dFecSystem;
            LimpiarTodo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void btnImprimirAlta_Click(object sender, EventArgs e)
        {
            ImprimirAlta();
        }

        private void btnImprimirBaja_Click(object sender, EventArgs e)
        {
            ImprimirBaja();
        }

        private void btnImprimirCobro_Click(object sender, EventArgs e)
        {
            ImprimirCobro();
        }

        private void LimpiarTodo()
        {
            dtpFechaDesde.Value = dFechaSistema.Date;
            dtpFechaHasta.Value = dFechaSistema.Date;
        }

        
        private void ImprimirAlta()
        {
            if (!ValidarParaImprimir())
                return;

            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;

            DataTable dtInformacion = _cnCreditoCargaSeguro.CNConsultaPaqueteSeguroAlta(dFechaDesde, dFechaHasta);

            if (dtInformacion.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para la búsqueda.", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>
            {
                new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false),
                new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false),
                new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false),
                new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false)
            };

            dtslist.Add(new ReportDataSource("dtsInformacion", dtInformacion));

            string reportpath = "rptAltasPlanPaquetesAsistencia.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.ShowDialog();
        }

        private void ImprimirBaja()
        {
            if (!ValidarParaImprimir())
                return;

            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;

            DataTable dtInformacion = _cnCreditoCargaSeguro.CNConsultaPaqueteSeguroBaja(dFechaDesde, dFechaHasta);

            if (dtInformacion.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para la búsqueda.", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>
            {
                new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false),
                new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false),
                new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false),
                new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false)
            };

            dtslist.Add(new ReportDataSource("dtsInformacion", dtInformacion));

            string reportpath = "rptBajasPlanPaquetesAsistencia.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.ShowDialog();
        }

        private void ImprimirCobro()
        {
            if (!ValidarParaImprimir())
                return;

            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;

            DataTable dtInformacion = _cnCreditoCargaSeguro.CNConsultaPaqueteSeguroCobro(dFechaDesde, dFechaHasta);

            if (dtInformacion.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para la búsqueda.", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>
            {
                new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false),
                new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false),
                new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false),
                new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false),
                new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false)
            };

            dtslist.Add(new ReportDataSource("dtsInformacion", dtInformacion));

            string reportpath = "rptCobrosPlanPaquetesAsistencia.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.ShowDialog();
        }

        private bool ValidarParaImprimir()
        {
            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;

            if (dFechaDesde > dFechaHasta)
            {
                MessageBox.Show("Ingrese un rango de fechas correcto", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
