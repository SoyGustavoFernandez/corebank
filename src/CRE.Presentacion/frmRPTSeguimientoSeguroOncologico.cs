using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Data;
using CRE.CapaNegocio;
using System.Linq;

namespace CRE.Presentacion
{
    public partial class frmRPTSeguimientoSeguroOncologico : frmBase
    {
        #region Variables
        private clsCNSeguros objSeguros = new clsCNSeguros();
        private DataTable dtUsuarioZona = new DataTable();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        int nCodigoOncologico;
        #endregion

        public frmRPTSeguimientoSeguroOncologico()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
            if (!validar())
                return;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuario = Convert.ToInt32(cboPersonal.SelectedValue);

            DataTable dtDatosReporte = objSeguros.CNObtenerDatosRPTSeguimientoSeguroOncologico(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("idZona", Convert.ToString(idZona), false));
            paramlist.Add(new ReportParameter("idAgencia", Convert.ToString(idAgencia), false));
            paramlist.Add(new ReportParameter("idUsuario", Convert.ToString(idUsuario), false));

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsRPTDatosSeguroOncologico", dtDatosReporte));

            string reportpath = "rptReporteSeguimientoSeguroOncologico.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        #region Eventos
        private void frmRPTSeguimientoSeguroOncologico_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarDatos();
        }

        private void cboZona_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idAgencia"]);
            cboAgencia.FiltrarPorZonaTodos(idZonaSeleccionado);
            cboAgencia.SelectedValue = 0;
        }

        private void cboAgencia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, nCodigoOncologico);

            cboPersonal.DataSource = dtUsuarioSeleccionado;
            cboPersonal.ValueMember = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;
            cboPersonal.SelectedValue = 0;
        }
        #endregion

        #region Métodos
        private bool validar()
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void cargarDatos()
        {
            nCodigoOncologico = Convert.ToInt16(clsVarApl.dicVarGen["nIdSeguroOncologico"]);

            cboZona.SelectedIndexChanged -= new EventHandler(cboZona_SelectedIndexChanged_1);
            cboAgencia.SelectedIndexChanged -= new EventHandler(cboAgencia_SelectedIndexChanged_1);
        
            dtUsuarioZona = objCNCreditoCargaSeguro.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);

            int idZona = Convert.ToInt32(dtUsuarioZona.Rows[0]["idZona"]);
            int idAgencia = Convert.ToInt32(dtUsuarioZona.Rows[0]["idAgencia"]);
            cboZona.cargarZona(true, false);
            cboAgencia.FiltrarPorZonaTodos(idZona);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtPersonal = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZona, idAgencia, dFechaDesde, dFechaHasta, nCodigoOncologico);
            cboZona.SelectedValue = idZona;
            cboAgencia.SelectedValue = idAgencia;
            cboPersonal.DataSource = dtPersonal;
            cboPersonal.ValueMember = dtPersonal.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtPersonal.Columns["cNombre"].ColumnName;

            cboPersonal.SelectedValue = clsVarGlobal.User.idUsuario;

            validarPermisos();

            cboZona.SelectedIndexChanged += new EventHandler(cboZona_SelectedIndexChanged_1);
            cboAgencia.SelectedIndexChanged += new EventHandler(cboAgencia_SelectedIndexChanged_1);
        }

        private void validarPermisos()
        {
            DataTable dtPermisos = objSeguros.CNValidarPermisosRPTOncologico(clsVarGlobal.PerfilUsu.idPerfil);
            cboPersonal.Enabled = false;
            cboAgencia.Enabled = false;
            cboZona.Enabled = false;

            if (dtPermisos.Rows.Count > 0)
            {
                bool lPermisoOficina = Convert.ToBoolean(dtPermisos.Rows[0]["lPermisoOficina"]);
                bool lPermisoRegion = Convert.ToBoolean(dtPermisos.Rows[0]["lPermisoRegion"]);
                bool lPermisoNacional = Convert.ToBoolean(dtPermisos.Rows[0]["lPermisoNacional"]);

                if (lPermisoOficina)
                    cboPersonal.Enabled = true;

                if (lPermisoRegion)
                {
                    cboAgencia.Enabled = true;
                    cboPersonal.Enabled = true;
                }

                if (lPermisoNacional)
                {
                    cboZona.Enabled = true;
                    cboAgencia.Enabled = true;
                    cboPersonal.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para acceder al formulario actual", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
        }
        #endregion

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, nCodigoOncologico);

            cboPersonal.DataSource = dtUsuarioSeleccionado;
            cboPersonal.ValueMember = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;

            cboPersonal.SelectedValue = idUsuarioDefecto;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, nCodigoOncologico);

            cboPersonal.DataSource = dtUsuarioSeleccionado;
            cboPersonal.ValueMember = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;

            cboPersonal.SelectedValue = idUsuarioDefecto;
        }
    }
}