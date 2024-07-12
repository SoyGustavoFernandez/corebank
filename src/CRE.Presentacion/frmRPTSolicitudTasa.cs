using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using ADM.CapaNegocio;
using GEN.CapaNegocio;
using clsUsuario = GEN.CapaNegocio.clsCNUsuario;
namespace CRE.Presentacion
{
    public partial class frmRPTSolicitudTasa : frmBase
    {
        #region Variables Globales
        string nPerfilReporte = "";
        int nPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        public string cEstSolicitud = "cEstadosSolicitud";
        #endregion

        public frmRPTSolicitudTasa()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmRPTSolicitudTasa_Load(object sender, EventArgs e)
        {
            if ("75,93,172,158".Contains(Convert.ToString(clsVarGlobal.PerfilUsu.idPerfil)))
            {
                obtenerZonaByAgencia();
            }
            else
            {
                obtenerZonaByEstab();
            }
            poblarEstadosCredito();
            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;
            dtpDesde.MaxDate = clsVarGlobal.dFecSystem;
        }
        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
                clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
                DataTable dtAgencia = ListadoAgencia.CNObtenerAgenciaZona(idZonaSeleccionado);
                cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ColumnName;
                cboAgencia.DisplayMember = dtAgencia.Columns["cNombreAge"].ColumnName;
                if (clsVarGlobal.PerfilUsu.idPerfil == 93 || clsVarGlobal.PerfilUsu.idPerfil == 75 || clsVarGlobal.PerfilUsu.idPerfil == 172)//SUPERVISOR DE OPERACIONES
                {
                    DataRow row = dtAgencia.NewRow();
                    row["idAgencia"] = 0;
                    row["cNombreAge"] = "**TODOS**";
                    dtAgencia.Rows.InsertAt(row, 0);
                    cboAgencia.DataSource = dtAgencia;
                    return;
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 158)//EJECUTIVO CORPORATIVO
                {
                    DataRow row = dtAgencia.NewRow();
                    row["idAgencia"] = 0;
                    row["cNombreAge"] = "**TODOS**";
                    dtAgencia.Rows.InsertAt(row, 0);
                    cboAgencia.DataSource = dtAgencia;
                    return;
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 58)//COORDINADOR DE OPERACIONES
                {
                    DataTable dtAgencia_COP = ListadoAgencia.CNObtenerAgenciaZona(0);
                    DataTable dtFiltrado = dtAgencia_COP.AsEnumerable().Where(r => r.Field<int>("idAgencia") == clsVarGlobal.nIdAgencia).CopyToDataTable();
                    cboAgencia.DataSource = dtFiltrado;
                    return;
                }

                DataTable dtFiltradoGEN = dtAgencia.AsEnumerable().Where(r => r.Field<int>("idAgencia") == clsVarGlobal.nIdAgencia).CopyToDataTable();
                cboAgencia.DataSource = dtFiltradoGEN;
            }
            catch { }
        }
        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
                bool lPerfilAceptado = false;
                clsCNMantenimiento ListadEstablecimiento = new clsCNMantenimiento();
                DataTable dtEstablecimiento = ListadEstablecimiento.CNObtenerEstabAgencia(idAgenciaSeleccionado);
                cboEstablecimiento.ValueMember = dtEstablecimiento.Columns["idEstablecimiento"].ColumnName;
                cboEstablecimiento.DisplayMember = dtEstablecimiento.Columns["cNombreEstab"].ColumnName;
                if (clsVarGlobal.PerfilUsu.idPerfil == 93 || clsVarGlobal.PerfilUsu.idPerfil == 75 || clsVarGlobal.PerfilUsu.idPerfil == 172)//SUPERVISOR DE OPERACIONES
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                    lPerfilAceptado = true;
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 58)//COORDINADOR DE OPERACIONES
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                    lPerfilAceptado = true;
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 158)//EJECUTIVO CORPORATIVO
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                    lPerfilAceptado = true;
                }
                if (lPerfilAceptado == false)
                {
                    DataTable dtFiltrado = dtEstablecimiento.AsEnumerable().Where(r => r.Field<int>("idEstablecimiento") == clsVarGlobal.User.idEstablecimiento).CopyToDataTable();
                    cboEstablecimiento.DataSource = dtFiltrado;
                }

                DataTable dtUsuario = ListadEstablecimiento.CNObtenerUsuarioAgencia(idAgenciaSeleccionado);
                cboUsuario.ValueMember = dtUsuario.Columns["idUsuario"].ColumnName;
                cboUsuario.DisplayMember = dtUsuario.Columns["cWinUser"].ColumnName;

                DataRow urow = dtUsuario.NewRow();
                urow["idUsuario"] = 0;
                urow["cWinUser"] = "**TODOS**";
                dtUsuario.Rows.InsertAt(urow, 0);
                cboUsuario.DataSource = dtUsuario;
            }
            catch
            {

            }
        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idZona = cboZona.SelectedValue == null ? -1 : Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = cboAgencia.SelectedValue == null ? -1 : Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = cboEstablecimiento.SelectedValue == null ? -1 : Convert.ToInt32(cboEstablecimiento.SelectedValue);
            clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            DataTable dtDatosReporte = objCNCreditoCargaSeguro.CNObtenerDatosRPTSolicitudesTasa(dFechaDesde, dFechaHasta, idZona, idAgencia, idEstablecimiento, cboEstadoSolicitud.SelectedValue.ToString(), Convert.ToInt32(cboUsuario.SelectedValue.ToString()));

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cTituloRepo", "PRE DESEMBOLSO", false));

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsSolicitudes", dtDatosReporte));

            string reportpath = "rptReporteSolicitudesTasa.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.Normal);
            frmReporte.ShowDialog();
        }

        #endregion

        #region Metodos
        private bool validar()
        {
            bool lValor = true;
            if (dtpDesde.Value > dtpHasta.Value)
            {
                lValor = false;
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;

            }

            DateTime dFechaini = dtpDesde.Value;
            DateTime dFechafin = dtpHasta.Value;
            TimeSpan diferencia = dFechafin - dFechaini;
            if (diferencia.TotalDays > 30) 
            {
                lValor = false;
                MessageBox.Show("El rango de fecha no puede ser mayor a 30 días.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;
            }
            return lValor;
        }

        private void obtenerEstabById()
        {
            clsCNMantenimiento Listadoestablecimiento = new clsCNMantenimiento();
            DataTable dtEstablecimiento = Listadoestablecimiento.CNObtenerEstablecimiento(clsVarGlobal.User.idEstablecimiento);
            DataRow row = dtEstablecimiento.NewRow();
            row["idEstablecimiento"] = 0;
            row["cNombreEstab"] = "**TODOS**";
            dtEstablecimiento.Rows.InsertAt(row, 0);
            cboEstablecimiento.ValueMember = dtEstablecimiento.Columns["idEstablecimiento"].ColumnName;
            cboEstablecimiento.DisplayMember = dtEstablecimiento.Columns["cNombreEstab"].ColumnName;

            cboEstablecimiento.DataSource = dtEstablecimiento;
            cboEstablecimiento.SelectedValue = clsVarGlobal.User.idEstablecimiento;
        }

        private void obtenerZonaByAgencia()
        {
            clsCNMantenimiento ListadoZona = new clsCNMantenimiento();
            DataTable dtZona = ListadoZona.CNObtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            DataRow row = dtZona.NewRow();
            row["idZona"] = 0;
            row["cDesZona"] = "**TODOS**";
            dtZona.Rows.InsertAt(row, 0);
            cboZona.ValueMember = dtZona.Columns["idZona"].ColumnName;
            cboZona.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
            cboZona.DataSource = dtZona;
        }

        private void obtenerZonaByEstab()
        {
            clsCNMantenimiento ListadoZona = new clsCNMantenimiento();
            DataTable dtZona = ListadoZona.CNObtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            cboZona.ValueMember = dtZona.Columns["idZona"].ColumnName;
            cboZona.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
            cboZona.DataSource = dtZona;
        }

        private void poblarEstadosCredito()
        {
            string estadosSolicitud = "99";

            clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            DataTable dtEstados = new DataTable();
            dtEstados = objCNCreditoCargaSeguro.CNListarEstadosSolicitudTasa();
            DataRow row = dtEstados.NewRow();
            row["idEstadoSol"] = estadosSolicitud;
            row["cEstadoSol"] = "**TODOS**";
            dtEstados.Rows.InsertAt(row, 0);
            cboEstadoSolicitud.ValueMember = dtEstados.Columns["idEstadoSol"].ColumnName;
            cboEstadoSolicitud.DisplayMember = dtEstados.Columns["cEstadoSol"].ColumnName;
            cboEstadoSolicitud.DataSource = dtEstados;

        }

        private void actualizarFechasEvento()
        {
            DateTime max = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            if (max < dtpHasta.MaxDate)
            {
                dtpHasta.MinDate = Convert.ToDateTime(dtpDesde.Value);
                dtpHasta.MaxDate = Convert.ToDateTime(max);
            }
            else
            {
                dtpHasta.MaxDate = Convert.ToDateTime(max);
                dtpHasta.MinDate = Convert.ToDateTime(dtpDesde.Value);
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            actualizarFechasEvento();
        }

        #endregion

    }
}
