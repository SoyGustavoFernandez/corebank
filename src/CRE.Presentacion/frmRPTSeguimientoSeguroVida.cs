#region Referencias
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
using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
#endregion


namespace CRE.Presentacion
{
    public partial class frmRPTSeguimientoSeguroVida : frmBase
    {
        #region Variables Globales
        public int idPerfilUsuario { get; set; }
        public List<clsConfiguracionReporteSeguro> lstConfiguracionSeguro { get; set; }
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro { get; set; }
        private DataTable dtUsuarioZona { get; set; }
        private RolFormulario eRolFormulario { get; set; }
        #endregion
        public frmRPTSeguimientoSeguroVida()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmRPTSeguimientoSeguroVida_Load(object sender, EventArgs e)
        {
            cargarComponentes();
            cargarDatos();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado      = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaDefecto        = Convert.ToInt32(dtUsuarioZona.Rows[0]["idAgencia"]);
            cboAgencia.FiltrarPorZonaTodos(idZonaSeleccionado);
            cboAgencia.SelectedValue    = idAgenciaDefecto;
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado      = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado   = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, idTipoSeguro: 2);

            cboPersonal.DataSource      = dtUsuarioSeleccionado;
            cboPersonal.ValueMember     = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember   = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;

            btnImprimir.Enabled = (!dtUsuarioSeleccionado.AsEnumerable().Any(item => Convert.ToInt32(item["idUsuario"]) == clsVarGlobal.User.idUsuario) && eRolFormulario == RolFormulario.Colaborador) ? false : true;
            cboPersonal.SelectedValue = idUsuarioDefecto;
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, idTipoSeguro: 1);

            cboPersonal.DataSource = dtUsuarioSeleccionado;
            cboPersonal.ValueMember = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;

            btnImprimir.Enabled = (!dtUsuarioSeleccionado.AsEnumerable().Any(item => Convert.ToInt32(item["idUsuario"]) == clsVarGlobal.User.idUsuario) && eRolFormulario == RolFormulario.Colaborador) ? false : true;
            cboPersonal.SelectedValue = idUsuarioDefecto;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuarioDefecto = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtUsuarioSeleccionado = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZonaSeleccionado, idAgenciaSeleccionado, dFechaDesde, dFechaHasta, idTipoSeguro: 1);

            cboPersonal.DataSource = dtUsuarioSeleccionado;
            cboPersonal.ValueMember = dtUsuarioSeleccionado.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtUsuarioSeleccionado.Columns["cNombre"].ColumnName;

            btnImprimir.Enabled = (!dtUsuarioSeleccionado.AsEnumerable().Any(item => Convert.ToInt32(item["idUsuario"]) == clsVarGlobal.User.idUsuario) && eRolFormulario == RolFormulario.Colaborador) ? false : true;
            cboPersonal.SelectedValue = idUsuarioDefecto;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idZona      = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia   = Convert.ToInt32(cboAgencia.SelectedValue);
            int idUsuario   = Convert.ToInt32(cboPersonal.SelectedValue);


            DataTable dtDatosReporte = objCNCreditoCargaSeguro.CNObtenerDatosRPTSeguimientoSeguroVida(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
            DataTable dtResumenReporte = objCNCreditoCargaSeguro.CNObtenerDatosRPTResumenSeguroVida(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idZona",Convert.ToString(idZona)));
            paramlist.Add(new ReportParameter("idUsuario", Convert.ToString(idUsuario)));
            paramlist.Add(new ReportParameter("idAgencia",Convert.ToString(idAgencia)));

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsRPTDatosSeguroVida", dtDatosReporte));
            dtslist.Add(new ReportDataSource("dsRPTResumenSeguroVida", dtResumenReporte));

            string reportpath = "rptReporteSeguimientoSeguroVida.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }
        #endregion

        #region Metodos
        private void cargarComponentes()
        {
            idPerfilUsuario = clsVarGlobal.PerfilUsu.idPerfil;

            objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            lstConfiguracionSeguro = new List<clsConfiguracionReporteSeguro>();

            cargarListaConfiguracion();
            obtenerRolUsuario();
            dtUsuarioZona = objCNCreditoCargaSeguro.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);
            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;

            cboZona.SelectedValue = Convert.ToInt32(dtUsuarioZona.Rows[0]["idZona"]);
            cboAgencia.SelectedValue = Convert.ToInt32(dtUsuarioZona.Rows[0]["idAgencia"]);
            cboPersonal.SelectedValue = Convert.ToInt32(dtUsuarioZona.Rows[0]["idUsuario"]);

            eRolFormulario = obtenerRolUsuario();
            if(eRolFormulario == RolFormulario.Administrador)
            {
                activarControles(AccionFormulario.NIVEL_ADMINISTRADOR);
            }
            else if (eRolFormulario == RolFormulario.Zona)
            {
                activarControles(AccionFormulario.NIVEL_ZONA);
            }
            else if (eRolFormulario == RolFormulario.Oficina)
            {
                activarControles(AccionFormulario.NIVEL_OFICINA);
            }
            else if (eRolFormulario == RolFormulario.Colaborador)
            {
                activarControles(AccionFormulario.NIVEL_COLABORADOR);
            }
            else
            {
                activarControles(AccionFormulario.NIVEL_DEFECTO);
            }
        }
        private void cargarDatos()
        {
            int idZona = Convert.ToInt32(dtUsuarioZona.Rows[0]["idZona"]);
            int idAgencia = Convert.ToInt32(dtUsuarioZona.Rows[0]["idAgencia"]);
            cboZona.cargarZona(true, false);
            cboAgencia.FiltrarPorZonaTodos(idZona);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtPersonal = objCNCreditoCargaSeguro.CNObtenerListaUsuarioSeguro(idZona, idAgencia, dFechaDesde, dFechaHasta, idTipoSeguro: 2);
            cboZona.SelectedValue = idZona;
            cboAgencia.SelectedValue = idAgencia;
            cboPersonal.DataSource = dtPersonal;
            cboPersonal.ValueMember = dtPersonal.Columns["idUsuario"].ColumnName;
            cboPersonal.DisplayMember = dtPersonal.Columns["cNombre"].ColumnName;

            btnImprimir.Enabled = (!dtPersonal.AsEnumerable().Any(item => Convert.ToInt32(item["idUsuario"]) == clsVarGlobal.User.idUsuario) && eRolFormulario == RolFormulario.Colaborador) ? false : true;
            cboPersonal.SelectedValue = clsVarGlobal.User.idUsuario;
        }

        private void cargarListaConfiguracion()
        {
            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cReporteSeguroConfiguracionPerfil"));
            List<string> lstRolFormulario = objVarGen.cValVar.Split(';').ToList();
            foreach (string cRol in lstRolFormulario)
            {
                clsConfiguracionReporteSeguro objConfiguracionReporte = new clsConfiguracionReporteSeguro();
                objConfiguracionReporte.cConfiguracion = cRol.Split(':')[0];
                objConfiguracionReporte.lstPerfil = cRol.Split(':')[1].Split(',').Select(Int32.Parse).ToList();
                lstConfiguracionSeguro.Add(objConfiguracionReporte);
            }
        }

        private RolFormulario obtenerRolUsuario()
        {
            List<clsConfiguracionReporteSeguro> lstConfiguracionSeguroFiltrado = new List<clsConfiguracionReporteSeguro>();
            lstConfiguracionSeguroFiltrado = lstConfiguracionSeguro.Where(item => item.lstPerfil.Contains(idPerfilUsuario)).ToList();
            if (lstConfiguracionSeguroFiltrado.Count > 0)
            {
                if (lstConfiguracionSeguroFiltrado.Any(item => item.cConfiguracion == "Administrador"))
                {
                    return RolFormulario.Administrador;
                }
                else if (lstConfiguracionSeguroFiltrado.Any(item => item.cConfiguracion == "Zona"))
                {
                    return RolFormulario.Zona;
                }
                else if (lstConfiguracionSeguroFiltrado.Any(item => item.cConfiguracion == "Oficina"))
                {
                    return RolFormulario.Oficina;
                }
                else if (lstConfiguracionSeguroFiltrado.Any(item => item.cConfiguracion == "Colaborador"))
                {
                    return RolFormulario.Colaborador;
                }
                else
                {
                    return RolFormulario.Ninguno;
                }
            }
            else
            {
                return RolFormulario.Ninguno;
            }
        }

        private void activarControles(AccionFormulario evento)
        {
            switch (evento)
            {
                case AccionFormulario.NIVEL_DEFECTO:
                    cboZona.Enabled     = false;
                    cboAgencia.Enabled  = false;
                    cboPersonal.Enabled = false;
                    dtpDesde.Enabled    = false;
                    dtpHasta.Enabled    = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled    = true;
                    break;
                case AccionFormulario.NIVEL_ADMINISTRADOR:
                    cboZona.Enabled     = true;
                    cboAgencia.Enabled  = true;
                    cboPersonal.Enabled = true;
                    dtpDesde.Enabled    = true;
                    dtpHasta.Enabled    = true;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled    = true;
                    break;
                case AccionFormulario.NIVEL_ZONA:
                    cboZona.Enabled     = false;
                    cboAgencia.Enabled  = true;
                    cboPersonal.Enabled = true;
                    dtpDesde.Enabled    = true;
                    dtpHasta.Enabled    = true;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled    = true;
                    break;
                case AccionFormulario.NIVEL_OFICINA:
                    cboZona.Enabled     = false;
                    cboAgencia.Enabled  = false;
                    cboPersonal.Enabled = true;
                    dtpDesde.Enabled    = true;
                    dtpHasta.Enabled    = true;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled    = true;
                    break;
                case AccionFormulario.NIVEL_COLABORADOR:
                    cboZona.Enabled     = false;
                    cboAgencia.Enabled  = false;
                    cboPersonal.Enabled = false;
                    dtpDesde.Enabled    = true;
                    dtpHasta.Enabled    = true;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled    = true;
                    break;
                default: break;
            }
        }

        private void habilitarEventHandler(bool lValor)
        {
            if(!lValor)
            {
                cboZona.SelectedIndexChanged        -= new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencia.SelectedIndexChanged     -= new EventHandler(cboAgencia_SelectedIndexChanged);
            }
            else
            {
                cboZona.SelectedIndexChanged        += new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencia.SelectedIndexChanged     += new EventHandler(cboAgencia_SelectedIndexChanged);
            }
        }
        private bool validar()
        {
            bool lValor = true;
            if (dtpDesde.Value > dtpHasta.Value)
            {
                lValor = false;
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;

            }
            return lValor;
        }
        #endregion

        #region Enumeradores
        private enum AccionFormulario
        {
            NIVEL_DEFECTO           = 0,
            NIVEL_ADMINISTRADOR     = 2,
            NIVEL_ZONA              = 3,
            NIVEL_OFICINA           = 4,
            NIVEL_COLABORADOR       = 5
        }

        private enum RolFormulario
        {
            Ninguno         = 0,
            Administrador   = 1,
            Zona            = 2,
            Oficina         = 3,
            Colaborador     = 4,
        }

        #endregion
    }
}
