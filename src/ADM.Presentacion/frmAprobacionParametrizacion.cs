using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmAprobacionParametrizacion : frmBase
    {
        private clsCNAprobacionParametrizacion objCNAproAutoUsuario;
        private List<clsAprobacionAutonomiaUsuario> lstAproAutonomiaUsuario;
        private clsAprobacionAutonomiaUsuario objAproAutonomiaUsuario;
        private bool lEdicion;

        public frmAprobacionParametrizacion()
        {
            InitializeComponent();
            this.inicializarDatos();            
        }

        public void inicializarDatos()
        {
            this.objCNAproAutoUsuario = new clsCNAprobacionParametrizacion();
            this.lstAproAutonomiaUsuario = new List<clsAprobacionAutonomiaUsuario>();
            this.objAproAutonomiaUsuario = new clsAprobacionAutonomiaUsuario();
            this.lEdicion = false;
            this.bsAproAutonomiaUsuario.DataSource = this.lstAproAutonomiaUsuario;

            this.habilitarControles(clsAcciones.DEFECTO);
        }
        public void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.NUEVO:
                    this.pnlAproAutoUsuarioCtrl.Enabled = true;
                    this.cboCanalAproCred.Enabled = true;
                    this.cboNivelAprobacion.Enabled = true;
                    this.cboPerfil.Enabled = true;
                    this.btnMiniBusqueda.Enabled = true;
                    this.dtgAproAutonomiaUsuario.Enabled = false;
                    break;
                case clsAcciones.GRABAR:
                    this.pnlAproAutoUsuarioCtrl.Enabled = false;
                    this.dtgAproAutonomiaUsuario.Enabled = true;
                    break;
                case clsAcciones.EDITAR:
                    this.pnlAproAutoUsuarioCtrl.Enabled = true;
                    this.cboCanalAproCred.Enabled = false;
                    this.cboNivelAprobacion.Enabled = false;
                    this.cboPerfil.Enabled = true;
                    this.btnMiniBusqueda.Enabled = false;
                    this.dtgAproAutonomiaUsuario.Enabled = false;
                    break;
                default:
                    this.txtUsuario.Enabled = false;
                    this.txtIdUsuario.Enabled = false;
                    this.btnMiniBusqueda.Enabled = false;
                    this.pnlAproAutoUsuarioCtrl.Enabled = false;
                    this.dtgAproAutonomiaUsuario.Enabled = true;
                    break;
            }
        }
        public void limpiarAproAutonomiaUsuario()
        {
            this.cboCanalAproCred.SelectedIndex = -1;
            this.cboNivelAprobacion.SelectedIndex = -1;
            this.cboPerfil.SelectedIndex = -1;
            this.txtUsuario.Text = string.Empty;
            this.txtIdUsuario.Text = "0";
            this.txtMontoAutonomia.Text = "0.00";
        }
        public void listarAproAutonomiaUsuario()
        {
            this.lstAproAutonomiaUsuario.Clear();
            this.lstAproAutonomiaUsuario.AddRange(this.objCNAproAutoUsuario.listarAproAutonomiaUsuario());

            this.bsAproAutonomiaUsuario.ResetBindings(false);
            this.dtgAproAutonomiaUsuario.Refresh();
        }
        public void grabarAproAutonomiaUsuario()
        {
            clsRespuestaServidor objRespuesta = this.objCNAproAutoUsuario.grabarAproAutonomiaUsuario(this.extraerAproAutoUsuCtrl());
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                this.limpiarAproAutonomiaUsuario();
                this.habilitarControles(clsAcciones.GRABAR);
                MessageBox.Show(objRespuesta.cMensaje, "REGISTRO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarAproAutonomiaUsuario();
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void gestionarAproAutonomiaUsuario(int idEstado)
        {
            clsRespuestaServidor objRespuesta = this.objCNAproAutoUsuario.gestionarAproAutonomiaUsuario(
                this.objAproAutonomiaUsuario.idAprobacionAutonomiaUsuario, idEstado);
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {               
                MessageBox.Show(objRespuesta.cMensaje, "REGISTRO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarAproAutonomiaUsuario();
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public clsAprobacionAutonomiaUsuario extraerAproAutoUsuCtrl()
        {
            clsAprobacionAutonomiaUsuario objNuevoAproAutoUsu;
            if (this.lEdicion)
            {
                objNuevoAproAutoUsu = (clsAprobacionAutonomiaUsuario)this.objAproAutonomiaUsuario.Clone();
                objNuevoAproAutoUsu.idPerfil = Convert.ToInt32(this.cboPerfil.SelectedValue);
                objNuevoAproAutoUsu.nMonto = this.txtMontoAutonomia.nDecValor;
            }
            else
            {
                objNuevoAproAutoUsu = new clsAprobacionAutonomiaUsuario();
                objNuevoAproAutoUsu.idCanalAproCred = Convert.ToInt32(this.cboCanalAproCred.SelectedValue);
                objNuevoAproAutoUsu.idNivelAprobacion = Convert.ToInt32(this.cboNivelAprobacion.SelectedValue);
                objNuevoAproAutoUsu.idPerfil = Convert.ToInt32(this.cboPerfil.SelectedValue);
                objNuevoAproAutoUsu.idUsuario = Convert.ToInt32(this.txtIdUsuario.Text);
                objNuevoAproAutoUsu.nMonto = this.txtMontoAutonomia.nDecValor;
            }

            return objNuevoAproAutoUsu;
        }
        private void distribuirAproAutoUsuCtrl()
        {
            this.cboCanalAproCred.SelectedValue = this.objAproAutonomiaUsuario.idCanalAproCred;

            this.cboNivelAprobacion.SelectedIndexChanged -= cboNivelAprobacion_SelectedIndexChanged;            

            this.cboNivelAprobacion.CargarNivelesCanal(this.objAproAutonomiaUsuario.idCanalAproCred);
            this.cboNivelAprobacion.SelectedValue = this.objAproAutonomiaUsuario.idNivelAprobacion;
            clsNivelAprobacion objNivel = (clsNivelAprobacion)this.cboNivelAprobacion.SelectedItem;
            this.cboPerfil.cargarPerfilIds(objNivel.cIdsPerfiles);
            this.cboPerfil.SelectedValue = this.objAproAutonomiaUsuario.idPerfil;

            this.cboNivelAprobacion.SelectedIndexChanged += cboNivelAprobacion_SelectedIndexChanged;

            this.txtUsuario.Text = this.objAproAutonomiaUsuario.cUsuario;
            this.txtIdUsuario.Text = this.objAproAutonomiaUsuario.idUsuario.ToString();
            this.txtMontoAutonomia.Text = this.objAproAutonomiaUsuario.nMonto.ToString("0.00");
        }
        private bool validarAproAutoUsuCtrl()
        {
            if (this.cboCanalAproCred.SelectedIndex == -1)
            {
                MessageBox.Show("¡Debe seleccionar el canal de aprobación!", "DATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.cboNivelAprobacion.SelectedIndex == -1)
            {
                MessageBox.Show("¡Debe seleccionar el nivel de aprobación!", "DATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.cboPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("¡Debe seleccionar el perfil del aprobador!", "DATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtIdUsuario.Text.Trim().Equals("0"))
            {
                MessageBox.Show("¡Debe asignar el usuario para configurar su autonomía!", "DATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtMontoAutonomia.nDecValor < Decimal.Zero)
            {
                MessageBox.Show("¡El monto de autonomía debe ser un valor positivo!", "DATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void generarReporteHistAproAutoUsu()
        {
            DataTable dtData = this.objCNAproAutoUsuario.generarReporteHistAproAutoUsu();
            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", "RESULTADO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dsHistoricoAproAutoUsu", dtData));

            string reportpath = "rptHistoricoAproAutoUsuario.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        #region Eventos
        private void frmAprobacionParametrizacion_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            this.cboNivelAprobacion.SelectedIndexChanged -= cboNivelAprobacion_SelectedIndexChanged;
            this.cboNivelAprobacion.CargarNivelesCanal(Convert.ToInt32(this.cboCanalAproCred.SelectedValue));            
            this.cboNivelAprobacion.SelectedIndex = -1;
            this.cboNivelAprobacion.SelectedIndexChanged += cboNivelAprobacion_SelectedIndexChanged;
            this.listarAproAutonomiaUsuario();
        }

        private void dtgAproAutonomiaUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgAproAutonomiaUsuario.SelectedRows.Count == 0) return;

            int nIndice = this.dtgAproAutonomiaUsuario.SelectedRows[0].Index;
            this.objAproAutonomiaUsuario = this.lstAproAutonomiaUsuario[nIndice];
            if (this.objAproAutonomiaUsuario.idEstado == (int)Estado.ACTIVO)
            {
                this.tsbActivarAutoUsu.Visible = false;
                this.tsbDeshabilitarAutoUsu.Visible = true;
            }
            else if (this.objAproAutonomiaUsuario.idEstado == (int)Estado.DESHABILITADO)
            {
                this.tsbActivarAutoUsu.Visible = true;
                this.tsbDeshabilitarAutoUsu.Visible = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.validarAproAutoUsuCtrl())
            {
                this.grabarAproAutonomiaUsuario();
            }
        }

        private void tsbAgregarAutoUsu_Click(object sender, EventArgs e)
        {
            this.lEdicion = false;
            this.habilitarControles(clsAcciones.NUEVO);
        }

        private void tsbEditarAutoUsu_Click(object sender, EventArgs e)
        {
            if (this.objAproAutonomiaUsuario.idUsuario == 0) return;
            this.lEdicion = true;
            this.habilitarControles(clsAcciones.EDITAR);
            this.distribuirAproAutoUsuCtrl();
        }

        private void tsbActivarAutoUsu_Click(object sender, EventArgs e)
        {
            if (this.objAproAutonomiaUsuario.idAprobacionAutonomiaUsuario == 0) return;
            this.gestionarAproAutonomiaUsuario((int)Estado.ACTIVO);
        }

        private void tsbDeshabilitarAutoUsu_Click(object sender, EventArgs e)
        {
            if (this.objAproAutonomiaUsuario.idAprobacionAutonomiaUsuario == 0) return;
            this.gestionarAproAutonomiaUsuario((int)Estado.DESHABILITADO);
        }

        private void cboCanalAproCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCanalAproCred.SelectedIndex == -1) return;
            this.cboNivelAprobacion.CargarNivelesCanal(Convert.ToInt32(this.cboCanalAproCred.SelectedValue));
        }

        private void cboNivelAprobacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboNivelAprobacion.SelectedIndex == -1) return;
            clsNivelAprobacion objNivelAprobacion = (clsNivelAprobacion)this.cboNivelAprobacion.SelectedItem;
            this.cboPerfil.cargarPerfilIds(objNivelAprobacion.cIdsPerfiles);
        }

        private void btnMiniBusqueda_Click(object sender, EventArgs e)
        {
            FrmBusCol objFrmBusCol = new FrmBusCol();
            objFrmBusCol.ShowDialog();
            this.txtIdUsuario.Text = objFrmBusCol.idUsu;
            this.txtUsuario.Text = objFrmBusCol.cNom;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarAproAutonomiaUsuario();
            this.habilitarControles(clsAcciones.CANCELAR);
        }

        private void btnImpHistorico_Click(object sender, EventArgs e)
        {
            this.generarReporteHistAproAutoUsu();
        }
        #endregion
    }
}
