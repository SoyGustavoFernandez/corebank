using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmRptExcepcionLimites : frmBase
    {
        #region Variables

        private clsCNConfiguracionLimite objCNConfiguracionLimite { get; set; }

        #endregion

        #region Metodos Publicos

        public frmRptExcepcionLimites()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos Privados

        private void CargarComponentes()
        {
            objCNConfiguracionLimite = new clsCNConfiguracionLimite();

            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;

            cboLimitesExcep.LimitesExcepYTodos();
            cboLimitesExcep.SelectedIndex = 0;


            string cProductosEstamosContigo = clsVarApl.dicVarGen["cPerfilesGeneralesEOB"];
            String[] cPerfilesGenerales = cProductosEstamosContigo.Split(',');
            int[] nPerfilesGenerales = Array.ConvertAll<string, int>(cPerfilesGenerales, int.Parse);

            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;

            if (nPerfilesGenerales.Contains(idPerfil))
            {
                cboAgencias1.AgenciasYTodos();
            }
            else
            {
                List<clsAgencia> lstAgencias = new List<clsAgencia>();
                lstAgencias = new clsCNAgenciaUsu().CNListarAgenciasUsuario(clsVarGlobal.User.idUsuario);
                cboAgencias1.DataSource = lstAgencias;
            }

        }

        private bool validarFechas()
        {
            bool lValor = true;

            if (dtpDesde.Value > dtpHasta.Value)
            {
                lValor = false;
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return lValor;
        }

        #endregion

        #region Eventos

        private void lblBase1_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validarFechas())
                return;


            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            List<ReportParameter> paramList = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            int idTipoLimite = Convert.ToInt32(cboLimitesExcep.SelectedValue);
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            int idEstablecimiento = Convert.ToInt32(cboEstablecimiento1.SelectedValue);


            DataTable dtDatosEOBLimitesReporte = objCNConfiguracionLimite.CNObtenerDatosRPTLimitesEOB(dFechaDesde, dFechaHasta, idTipoLimite, idAgencia, idEstablecimiento);

            if (dtDatosEOBLimitesReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para el reporte.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            paramList.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramList.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));

            paramList.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));


            dtsList.Add(new ReportDataSource("DSRPTLimitesEOB", dtDatosEOBLimitesReporte));

            string reportpath = "rptExcepcionLimites.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtsList, reportpath, paramList);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.Normal);
            frmReporte.ShowDialog();

        }

        private void frmRptExcepcionLimites_Load(object sender, EventArgs e)
        {
            CargarComponentes();
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            cboEstablecimiento1.CargarEstablecimientos(idAgencia);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}