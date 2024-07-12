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
using GEN.CapaNegocio;
using EntityLayer;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using GEN.Servicio;
using System.Diagnostics;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmOpinionRiesgo : frmBase
    {
        #region Variables
        string cNombreFormulario = "Opiníon de Riesgo";
        int idSolInfRiesgo = 0;
        int idInformeRiesgo = 0;
        clsCNInformeRiesgos obInformeRiesgos = new clsCNInformeRiesgos();
        List<clsDetalleInformeRiesgo> listDetInfRsg = new List<clsDetalleInformeRiesgo>();
		List<clsComposicionCredito> listDestinoCreditoEval = new List<clsComposicionCredito>();
		List<clsIndicadoresFinancieros> listIndicadoresFinancieros = new List<clsIndicadoresFinancieros>();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        List<clsNivelTipoRiesgo> listNivelTipoRiesgo = new List<clsNivelTipoRiesgo>();
        frmListSolInformeRiesgos frmListSolInfRiesgos;
        List<clsUlrWeb> listUrlWeb = new List<clsUlrWeb>();
        string cModo = "Inicio";
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        string cUrlWebs = clsVarApl.dicVarGen["cUrlWeb"];
        int idPerfilAnalista;
        int? idPerfilRecon;
        #endregion
        #region Constructor
        public frmOpinionRiesgo()
        {
            InitializeComponent();

            this.btnSalir.lEventoDesactivado = true;
            idPerfilAnalista = clsVarGlobal.PerfilUsu.idPerfil;
            idPerfilRecon = clsVarGlobal.PerfilUsu.idPerfil;
            obtenerUrlWeb();
        }
        #endregion
        #region Métodos
        private void cargarDatos()
        {
            
            listDetInfRsg = obInformeRiesgos.CNListarDetalleInformeRiesgoEdit(idSolInfRiesgo);
            if (listDetInfRsg.Count == 0)
            {
                listDetInfRsg = obInformeRiesgos.listarDetalleInformeRiesgo(idSolInfRiesgo);
            }
            listDetInfRsg[0].idAnalistaAtiende = (listDetInfRsg[0].idAnalistaAtiende == null) ? 0 : listDetInfRsg[0].idAnalistaAtiende; 

            if (listDetInfRsg[0].idAnalistaAtiende != clsVarGlobal.PerfilUsu.idUsuario && listDetInfRsg[0].idAnalistaAtiende != 0 && listDetInfRsg[0].lAtendido == false)
            {
                MessageBox.Show("La solicitud de Opinión Riesgos está siendo atendido por otro Analista.", "Solicitud de Opinión Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            bool lReconcidera1 = (listDetInfRsg[0].lAtendido) ? listDetInfRsg[0].lReconsidera : false;
            idPerfilAnalista = (listDetInfRsg[0].idPerfilAnalista == null || listDetInfRsg[0].idPerfilAnalista == 0) ? idPerfilAnalista : listDetInfRsg[0].idPerfilAnalista;
            DateTime dFechaAct = (DateTime.Parse(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + (DateTime.Now.ToString(@" HH\:mm\:ss"))));
            obInformeRiesgos.CNRegistroFechaInicioReingreso(idSolInfRiesgo, dFechaAct, (listDetInfRsg[0].lAtendido && listDetInfRsg[0].lReconsidera));
            
            this.txtSolInfRiesgo.Text = idSolInfRiesgo.ToString();
            this.btnAdministradorFiles1.idSolicitud = listDetInfRsg[0].idSolicitud;
            this.txtNombreCliente.Text = listDetInfRsg[0].cNombreCliente;
            this.txtDocumento.Text = listDetInfRsg[0].cDocumento;
            this.txtidCli.Text = listDetInfRsg[0].idCli.ToString();
            this.txtOperacion.Text = listDetInfRsg[0].cOperacion;
            this.txtTipoCliente.Text = listDetInfRsg[0].cTipoCliente;
            this.txtMonto.Text = listDetInfRsg[0].nMonto.ToString();
            this.txtMoneda.Text = listDetInfRsg[0].cMoneda;
            this.txtActEconomica.Text = listDetInfRsg[0].cActEconomica;
            this.txtModalidad.Text = listDetInfRsg[0].cModalidad;
            this.txtSubProducto.Text = listDetInfRsg[0].cSubProducto;
            this.txtOficina.Text = listDetInfRsg[0].cOficina;
            this.txtNombreAsesor.Text = listDetInfRsg[0].cNombreAsesor;
            this.txtMoraOrigen.Text = listDetInfRsg[0].nMoraOrigen.ToString();
            this.txtMoraRsgPotencial.Text = listDetInfRsg[0].nMoraRsgPotencial.ToString();
            this.txtDestinoCredito.Text = String.IsNullOrEmpty(listDetInfRsg[0].cDestinoCredito) ? "" : listDetInfRsg[0].cDestinoCredito;
            this.txtPromDiasAtraso.Text = listDetInfRsg[0].nPromDiasAtraso.ToString();
            this.txtSaldoVigCraclasa.Text = listDetInfRsg[0].nSaldoVigCraclasa.ToString();
            this.txtFinanCraclasaImporte.Text = listDetInfRsg[0].nFinanCraclasaImporte.ToString();
            this.txtAportePropImporte.Text = listDetInfRsg[0].nAportePropImporte.ToString();
            this.txtComentario1.Text = listDetInfRsg[0].cComentario1.ToString();
            this.txtDeudaActualSF.Text = listDetInfRsg[0].nDeudaActualSF.ToString();
            this.txtTechoMaxEndeud.Text = listDetInfRsg[0].nTechoMaxEndeud.ToString();
            this.txtEntidadesAFecha.Text = listDetInfRsg[0].nEntidadesAFecha.ToString();
            this.txtEscalonamientoDeuda.Text = listDetInfRsg[0].nEscalonamientoDeuda.ToString();
            this.txtDeudaActualYPropuesto.Text = listDetInfRsg[0].nDeudaActualYPropuesto.ToString();
            this.txtTiempoActividad.Text = listDetInfRsg[0].nTiempoActividad.ToString();
            this.txtTiempoResidencia.Text = listDetInfRsg[0].nTiempoResidencia.ToString();
            this.txtTipoVivienda.Text = listDetInfRsg[0].cTipoVivienda;
            this.txtComentario2.Text = listDetInfRsg[0].cComentario2;
            if (listDetInfRsg[0].idOperacion != 3)
            {
                this.txtRatioLiquidez.Text = listDetInfRsg[0].nRatioLiquidez.ToString();
                this.txtComentario3.Text = listDetInfRsg[0].cComentario3;
                this.txtComentario4.Text = listDetInfRsg[0].cComentario4;
                this.txtGarantia.Text = String.IsNullOrEmpty(listDetInfRsg[0].cGarantia) ? "" : listDetInfRsg[0].cGarantia;
            }
            this.txtAnalistaRsg.Text = listDetInfRsg[0].cAnalistaRsg;
            this.txtFechaSolicitud.Text = listDetInfRsg[0].dFechaSolicitud.ToString("dd-MM-yyyy");
			this.txtFechaIngresoGerRisg.Text = listDetInfRsg[0].dFechaIngresoGerRisg.ToString();
			this.dtpFechaRecepcionSustento.Text = listDetInfRsg[0].dFechaRecepcionSustento.ToString("dd-MM-yyyy hh:mm:ss tt");
			this.dtpEnvioOBs.Text = listDetInfRsg[0].dEnvioObs.ToString("dd-MM-yyyy hh:mm:ss tt");
			this.dtpLevantamientoOBs.Text = listDetInfRsg[0].dLevantamientoObs.ToString("dd-MM-yyyy hh:mm:ss tt");
            this.txtSustento1.Text = listDetInfRsg[0].cSustento1;
            this.txtSustento2.Text = listDetInfRsg[0].cSustento2;
			this.txtUsuarioReconsidera.Text = listDetInfRsg[0].cUsuarioReconsidera;
			this.txtFechaSalida2.Text = listDetInfRsg[0].dFechaSalida2.ToString();
            this.textMotivoOpinion.Text = (listDetInfRsg[0].cMotivoRiesgoResu == null) ? ((listDetInfRsg[0].cMotivoRiesgo == null) ? "" : listDetInfRsg[0].cMotivoRiesgo.ToString()) : listDetInfRsg[0].cMotivoRiesgoResu.ToString();
            cargarCombos();
            
            if (listDetInfRsg[0].idOperacion == 3)
            {
                this.tbcAnalisisCliente.Controls.Add(this.tabPage1);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage2);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage5);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage6);
                }
            else {
                this.tbcAnalisisCliente.Controls.Add(this.tabPage1);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage2);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage3);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage4);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage5);
                this.tbcAnalisisCliente.Controls.Add(this.tabPage6);
            }
                if (listDetInfRsg[0].lAtendido)
                {
                    this.tbcAnalisisCliente.Controls.Add(this.tabPage7);
                }
            else {
                idPerfilRecon = 0;
            }
            if (listDetInfRsg[0].lNuevo)//Si es nuevo
            {
				this.txtFechaSalida.Text = clsVarGlobal.dFecSystem.ToString("dd-MM-yyyy");

				if (!listDetInfRsg[0].lReconsidera)
				{
						listDetInfRsg[0].dFechaSalida = clsVarGlobal.dFecSystem;
				}

                cModo = "Nuevo";
                this.Text = cNombreFormulario + " - "+ cModo ;
                habilitarSoloLectura(false);
                habilitarBotones();
                listDestinoCreditoEval = obInformeRiesgos.listarComposicionCredito(listDetInfRsg[0].idEvalCred);
                dtgComposicionCredito.DataSource = null;
                dtgComposicionCredito.DataSource = listDestinoCreditoEval;
				formatearGridDestino();

                dtgTipoNivelRiesgo.DataSource = null;
                pintarCamposEditables();
            }
            else
            {
				this.txtFechaSalida.Text = listDetInfRsg[0].dFechaSalida.ToString();
                cModo = "Lectura";
                this.Text = cNombreFormulario + " - " + cModo;
                habilitarSoloLectura(true);
                habilitarBotones();
                this.cboVisitaNegocio.SelectedIndex = listDetInfRsg[0].lVisitaNegocio ? 0 : 1;
                this.cboOpinion1.SelectedIndex = listDetInfRsg[0].lOpinion1 ? 0 : 1;

                if (listDetInfRsg[0].lOpinion2 == null)
                {
                    this.cboOpinion2.SelectedIndex = -1;
                }
                else if (listDetInfRsg[0].lOpinion2 == true)
                {
                    this.cboOpinion2.SelectedIndex = 0;
                }
                else
                {
                    this.cboOpinion2.SelectedIndex = 1;
                }
                listDestinoCreditoEval = obInformeRiesgos.destinoCreditoEvalGuardado(listDetInfRsg[0].idDetalleInformeRsg);
                dtgComposicionCredito.DataSource = null;
                dtgComposicionCredito.DataSource = listDestinoCreditoEval;
				formatearGridDestino();

                listNivelTipoRiesgo = obInformeRiesgos.tipoNivelRiesgoGuardado(listDetInfRsg[0].idDetalleInformeRsg);
                dtgTipoNivelRiesgo.DataSource = null;
                if (listNivelTipoRiesgo.Count > 0)
                {
                    dtgTipoNivelRiesgo.DataSource = listNivelTipoRiesgo;
                    formatearGridTipoNivel();
                }
                if (cboOpinion1.SelectedItem == "Favorable" && !ValidarIndicadorObser("lAbsolCom"))
                {
                    MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                pintarCamposEditables();
            }
			if (listDetInfRsg[0].lReconsidera)
			{
				if (listDetInfRsg[0].idUsuarioReconsidera == null)
				{
					listDetInfRsg[0].idUsuarioReconsidera = clsVarGlobal.User.idUsuario;
					listDetInfRsg[0].dFechaSalida2 = clsVarGlobal.dFecSystem;
					this.txtUsuarioReconsidera.Text = clsVarGlobal.User.cNomUsu;
					this.txtFechaSalida2.Text = clsVarGlobal.dFecSystem.ToString("dd-MM-yyyy");
				}
				else
				{
					this.txtUsuarioReconsidera.Text = listDetInfRsg[0].cUsuarioReconsidera;
					this.txtFechaSalida2.Text = listDetInfRsg[0].dFechaSalida2.ToString();
				}
                this.pnlReconsideracion.Enabled = true;
				
			}
			listIndicadoresFinancieros = obInformeRiesgos.listarIndicadoresFinancieros(listDetInfRsg[0].idEvalCred);
            if (listDetInfRsg[0].idOperacion != 3)
            {
                dtgIndicadoresFinancieros.DataSource = null;
                dtgIndicadoresFinancieros.DataSource = listIndicadoresFinancieros;
                formatearGridIndicadoresFinancieros();
            }

            this.btnPosicionCliente.Enabled = true;
            this.btnHistorialCredito.Enabled = true;
            this.button1.Enabled = true;
            this.btnEvaluacion.Enabled = true;
            this.btnCentralRiesgo.Enabled = true;
        }

        private void calcComposicionFinanciamiento()
        {
            if (txtFinanCraclasaImporte.Text.Length > 0 && txtAportePropImporte.Text.Length > 0)
            {
                decimal nFinanCraclasaImporte = Convert.ToDecimal(txtFinanCraclasaImporte.Text);
                decimal nAportePropImporte = Convert.ToDecimal(txtAportePropImporte.Text);
                decimal nTotalImporte = nFinanCraclasaImporte + nAportePropImporte;
                decimal nTotalImporteDivisor = nTotalImporte == 0 ? 1 : nTotalImporte;
                decimal nFinanCraclasaParticip = nFinanCraclasaImporte * 100 / nTotalImporteDivisor;
                decimal nAportePropParticip = nAportePropImporte * 100 / nTotalImporteDivisor;
                decimal nTotalParticip = nFinanCraclasaParticip + nAportePropParticip;

                txtFinanCraclasaParticip.Text = (nFinanCraclasaParticip).ToString("#.##");
                txtAportePropParticip.Text = (nAportePropParticip).ToString("#.##");
                txtTotalImporte.Text = Convert.ToString(nTotalImporte);
                txtTotalParticip.Text = (nTotalParticip).ToString("#.##");

                listDetInfRsg[0].nFinanCraclasaImporte = nFinanCraclasaImporte;
                listDetInfRsg[0].nAportePropImporte = nAportePropImporte;
            }

        }

		private void calcularEscalonamientoDeuda()
		{
			if (listDetInfRsg[0].idOperacion == 4)
			{
				if (txtTechoMaxEndeud.Text.Length > 0 && Convert.ToDecimal(txtTechoMaxEndeud.Text) != 0)
				{
					decimal nEscalonamientoDeuda = Math.Round(((Convert.ToDecimal(this.txtDeudaActualSF.Text) - Convert.ToDecimal(txtDeudaActualYPropuesto.Text)) * 100.0m) / Convert.ToDecimal(txtTechoMaxEndeud.Text),2)-100;
					listDetInfRsg[0].nEscalonamientoDeuda = nEscalonamientoDeuda;
					this.txtEscalonamientoDeuda.Text = Convert.ToString(listDetInfRsg[0].nEscalonamientoDeuda);
				}
			}
			else if (listDetInfRsg[0].idModalidad==2)
			{
				if (txtTechoMaxEndeud.Text.Length > 0 && Convert.ToDecimal(txtTechoMaxEndeud.Text) != 0)
				{
					decimal nEscalonamientoDeuda = Math.Round(((Convert.ToDecimal(this.txtDeudaActualSF.Text) + Convert.ToDecimal(txtDeudaActualYPropuesto.Text)) * 100.0m) / Convert.ToDecimal(txtTechoMaxEndeud.Text), 2)-100;
					listDetInfRsg[0].nEscalonamientoDeuda = nEscalonamientoDeuda;
					this.txtEscalonamientoDeuda.Text = Convert.ToString(listDetInfRsg[0].nEscalonamientoDeuda);
				}

			}
			else
			{
				listDetInfRsg[0].nEscalonamientoDeuda = 0;
				this.txtEscalonamientoDeuda.Text = Convert.ToString(listDetInfRsg[0].nEscalonamientoDeuda);
			}
		}

        private void cargarCombos()
        {
            List<clsTipoRiesgo> listTipoRiesgo = obInformeRiesgos.listarTipoRiesgo();
            List<clsNivelRiesgo> listNivelRiesgo = obInformeRiesgos.listarNivelRiesgo();

            this.cboTipoRiesgo.DataSource = listTipoRiesgo;
            this.cboTipoRiesgo.DisplayMember = "cTipoRiesgo";
            this.cboTipoRiesgo.ValueMember = "idTipoRiesgo";

            this.cboNivelRiesgo.DataSource = listNivelRiesgo;
            this.cboNivelRiesgo.DisplayMember = "cNivelRiesgo";
            this.cboNivelRiesgo.ValueMember = "idNivelRiesgo";

        }

        private void agregarTipoNivelRiesgo()
        {
            int idNivelRiesgo = Convert.ToInt32(this.cboNivelRiesgo.SelectedValue.ToString());
            string cNivelRiesgo = this.cboNivelRiesgo.Text.ToString();
            int idTipoRiesgo = Convert.ToInt32(this.cboTipoRiesgo.SelectedValue.ToString());
            string cTipoRiesgo = this.cboTipoRiesgo.Text.ToString();
            string cComentario5 = this.txtComentario5.Text;

            int index = listNivelTipoRiesgo.FindIndex(f=>f.idTipoRiesgo == idTipoRiesgo);
            if (index >= 0)
            {
                MessageBox.Show("Ya existe un registro", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
            }
            else
            {
                listNivelTipoRiesgo.Add(new clsNivelTipoRiesgo
                {
                    idNivelRiesgo = idNivelRiesgo,
                    cNivelRiesgo = cNivelRiesgo,
                    idTipoRiesgo = idTipoRiesgo,
                    cTipoRiesgo = cTipoRiesgo,
                    cComentario5 = cComentario5
                });

                dtgTipoNivelRiesgo.DataSource = null;
                this.dtgTipoNivelRiesgo.DataSource = listNivelTipoRiesgo;
				formatearGridTipoNivel();
				this.txtComentario5.Clear();
            }

        }

        private void quitarTipoNivelRiesgo()
        {
            if (listNivelTipoRiesgo.Count <= 0)
            {
                MessageBox.Show("Ya no existe registros que eliminar", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
			if (this.dtgTipoNivelRiesgo.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Seleccione un registro", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
            int nfilaseleccionada = Convert.ToInt32(this.dtgTipoNivelRiesgo.CurrentRow.Index);

            int idTipoRiesgo = Convert.ToInt32(dtgTipoNivelRiesgo.Rows[nfilaseleccionada].Cells["idTipoRiesgo"].Value.ToString());

            var itemAEliminar = listNivelTipoRiesgo.Single(r=>r.idTipoRiesgo == idTipoRiesgo);
            listNivelTipoRiesgo.Remove(itemAEliminar);

            dtgTipoNivelRiesgo.DataSource = null;
			if (listNivelTipoRiesgo.Count > 0)
			{
				this.dtgTipoNivelRiesgo.DataSource = listNivelTipoRiesgo;
				formatearGridTipoNivel();
			}

        }

        private void editarTipoNivelRiesgo()
        {
            if (listNivelTipoRiesgo.Count <= 0)
            {
                MessageBox.Show("No existe registro que editar", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
			if (this.dtgTipoNivelRiesgo.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Seleccione un registro", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
            int nfilaseleccionada = Convert.ToInt32(this.dtgTipoNivelRiesgo.CurrentRow.Index);

            int idNivelRiesgo = Convert.ToInt32(dtgTipoNivelRiesgo.Rows[nfilaseleccionada].Cells["idNivelRiesgo"].Value.ToString());
            int idTipoRiesgo = Convert.ToInt32(dtgTipoNivelRiesgo.Rows[nfilaseleccionada].Cells["idTipoRiesgo"].Value.ToString());

            this.cboTipoRiesgo.SelectedValue = idTipoRiesgo;
            this.cboNivelRiesgo.SelectedValue = idNivelRiesgo;
            string cComentario5 = dtgTipoNivelRiesgo.Rows[nfilaseleccionada].Cells["cComentario5"].Value.ToString();

            this.cboNivelRiesgo.SelectedValue = idNivelRiesgo;
            this.cboTipoRiesgo.SelectedValue = idTipoRiesgo;
            this.txtComentario5.Text = cComentario5;
            this.btnEditarAdministracion.Enabled = false;
            this.btnEditarAdministracion.Visible = false;
            this.btnActualizar.Enabled = true;
            this.btnActualizar.Visible = true;
            this.cboTipoRiesgo.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Visible = false;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Visible = false;
            this.btnCancelarAdministracion.Enabled = true;
            this.btnCancelarAdministracion.Visible = true;
        }

        private void registrarEdicionTipoNivelRiesgo()
        {
            int idTipoRiesgo = Convert.ToInt32(this.cboTipoRiesgo.SelectedValue.ToString());
            int idNivelRiesgo = Convert.ToInt32(this.cboNivelRiesgo.SelectedValue.ToString());
            string cNivelRiesgo = this.cboNivelRiesgo.Text.ToString();
            string cComentario5 = this.txtComentario5.Text;

            var itemAEditar = listNivelTipoRiesgo.Single(r => r.idTipoRiesgo == idTipoRiesgo);
            itemAEditar.cComentario5 = this.txtComentario5.Text;
            itemAEditar.idNivelRiesgo = idNivelRiesgo;
            itemAEditar.cNivelRiesgo = cNivelRiesgo;

            dtgTipoNivelRiesgo.DataSource = null;
            this.dtgTipoNivelRiesgo.DataSource = listNivelTipoRiesgo;
			formatearGridTipoNivel();

            this.btnEditarAdministracion.Enabled = true;
            this.btnEditarAdministracion.Visible = true;
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Visible = false;
            this.cboTipoRiesgo.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnAgregar.Visible = true;
            this.btnQuitar.Enabled = true;
            this.btnQuitar.Visible = true;
            this.btnCancelarAdministracion.Enabled = false;
            this.btnCancelarAdministracion.Visible = false;

        }

        private bool validarCampos()
        {
            string cPrefijoMensaje = "Debe ingresar un valor en el campo: ";
            string cPrefijoMensaje2 = "Falta seleccionar una opción en el campo: ";
            if (string.IsNullOrEmpty(txtMoraOrigen.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Mora Origen", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMoraOrigen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMoraRsgPotencial.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Mora Riesgo potencial", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMoraRsgPotencial.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFinanCraclasaImporte.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Importe - Financiamiento CRACLASA", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage1;
                this.txtFinanCraclasaImporte.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAportePropImporte.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Importe - Aporte Propio", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage1;
                this.txtAportePropImporte.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtComentario1.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Comentario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage1;
                this.txtComentario1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTechoMaxEndeud.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Techo máximo de endeudamiento", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage2;
                this.txtTechoMaxEndeud.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEscalonamientoDeuda.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Escalonamiento Deuda (%)", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage2;
                this.txtEscalonamientoDeuda.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtComentario2.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Comentario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage2;
                this.txtComentario2.Focus();
                return false;
            }
            if (listDetInfRsg[0].idOperacion != 3)
            {
                if (string.IsNullOrEmpty(txtComentario3.Text))
                {
                    MessageBox.Show(cPrefijoMensaje + "Comentario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbcAnalisisCliente.SelectedTab = tabPage3;
                    this.txtComentario3.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtComentario4.Text))
                {
                    MessageBox.Show(cPrefijoMensaje + "Comentario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbcAnalisisCliente.SelectedTab = tabPage4;
                    this.txtComentario4.Focus();
                    return false;
                }
            }
            
            if (listNivelTipoRiesgo.Count == 0)
            {
                MessageBox.Show("Falta información en la pestaña Administración de riesgo", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage5;
                this.txtComentario4.Focus();
                return false;
            }
            if (cboVisitaNegocio.SelectedIndex == -1)
            {
                MessageBox.Show(cPrefijoMensaje2 + "Visita de Negocio", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage6;
                this.cboVisitaNegocio.Focus();
                return false;
            }
            if (cboOpinion1.SelectedIndex == -1)
            {
                MessageBox.Show(cPrefijoMensaje2 + "Opinión", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage6;
                this.cboOpinion1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSustento1.Text))
            {
                MessageBox.Show(cPrefijoMensaje + "Sustento", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbcAnalisisCliente.SelectedTab = tabPage6;
                this.txtSustento1.Focus();
                return false;
            }

            return true;
        }

        private void grabarDatos()
        {
            if (!ValidarIndicadorObser("lAbsolCom"))
            {
                MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Preparando data
            listDetInfRsg[0].nMoraOrigen = Convert.ToDecimal(this.txtMoraOrigen.Text);
            listDetInfRsg[0].nMoraRsgPotencial = Convert.ToDecimal(this.txtMoraRsgPotencial.Text);

            listDetInfRsg[0].nFinanCraclasaImporte = Convert.ToDecimal(this.txtFinanCraclasaImporte.Text);

            listDetInfRsg[0].nAportePropImporte = Convert.ToDecimal(this.txtAportePropImporte.Text);

            listDetInfRsg[0].nDeudaActualSF = Convert.ToDecimal(this.txtDeudaActualSF.Text);
            listDetInfRsg[0].nTechoMaxEndeud = Convert.ToDecimal(this.txtTechoMaxEndeud.Text);
            listDetInfRsg[0].nEntidadesAFecha = Convert.ToInt32(this.txtEntidadesAFecha.Text);
            listDetInfRsg[0].nEscalonamientoDeuda = Convert.ToDecimal(this.txtEscalonamientoDeuda.Text);

            listDetInfRsg[0].cComentario1 = this.txtComentario1.Text;
            listDetInfRsg[0].cComentario2 = this.txtComentario2.Text;
            listDetInfRsg[0].cComentario3 = (listDetInfRsg[0].idOperacion != 3) ? this.txtComentario3.Text : "";
            listDetInfRsg[0].cComentario4 = (listDetInfRsg[0].idOperacion != 3) ? this.txtComentario4.Text : "";
            listDetInfRsg[0].cComentario5 = this.txtComentario5.Text;

			listDetInfRsg[0].dFechaRecepcionSustento = this.dtpFechaRecepcionSustento.Value;
			listDetInfRsg[0].dEnvioObs = this.dtpEnvioOBs.Value;
			listDetInfRsg[0].dLevantamientoObs = this.dtpLevantamientoOBs.Value;
            listDetInfRsg[0].cSustento1 = this.txtSustento1.Text;
            listDetInfRsg[0].cSustento2 = this.txtSustento2.Text;

            listDetInfRsg[0].lVisitaNegocio = this.cboVisitaNegocio.Text == "Si" ? true : false;
            listDetInfRsg[0].lOpinion1 = this.cboOpinion1.Text == "Favorable" ? true : false;
			listDetInfRsg[0].lOpinion2 = this.cboOpinion2.Text == "" ? (bool?)null : this.cboOpinion2.Text == "Favorable" ? true : false;         

            
            int idSolInfRiesgo = this.idSolInfRiesgo;
            int idCli = listDetInfRsg[0].idCli;
            int idOperacion = listDetInfRsg[0].idOperacion;//
            int idTipoCliente = listDetInfRsg[0].idTipoCliente;
            decimal nMonto = listDetInfRsg[0].nMonto;
            int idMoneda = listDetInfRsg[0].idMoneda;
			int idActEconomica = listDetInfRsg[0].idActEconomica;
			int idModalidad = listDetInfRsg[0].idModalidad;//
            int idSubProducto = listDetInfRsg[0].idSubProducto;
            int idOficina = listDetInfRsg[0].idOficina;
            int idUsuarioAsesor = listDetInfRsg[0].idUsuarioAsesor;
            decimal nMoraOrigen = listDetInfRsg[0].nMoraOrigen;
            decimal nMoraRsgPotencial = listDetInfRsg[0].nMoraRsgPotencial;
            string cDestinoCredito = String.IsNullOrEmpty(listDetInfRsg[0].cDestinoCredito) ? "" : listDetInfRsg[0].cDestinoCredito;
            decimal nPromDiasAtraso = listDetInfRsg[0].nPromDiasAtraso;
            decimal nSaldoVigCraclasa = listDetInfRsg[0].nSaldoVigCraclasa;
            decimal nFinanCraclasaImporte = listDetInfRsg[0].nFinanCraclasaImporte;
            decimal nAportePropImporte = listDetInfRsg[0].nAportePropImporte;
            string cComentario1 = listDetInfRsg[0].cComentario1;
            decimal nDeudaActualSF = listDetInfRsg[0].nDeudaActualSF;
            decimal nTechoMaxEndeud = listDetInfRsg[0].nTechoMaxEndeud;
            int nEntidadesAFecha = listDetInfRsg[0].nEntidadesAFecha;
            decimal nEscalonamientoDeuda = listDetInfRsg[0].nEscalonamientoDeuda;
            decimal nDeudaActualYPropuesto = listDetInfRsg[0].nDeudaActualYPropuesto;
            int nTiempoActividad = listDetInfRsg[0].nTiempoActividad;
            int nTiempoResidencia = listDetInfRsg[0].nTiempoResidencia;
            int idTipoVivienda = listDetInfRsg[0].idTipoVivienda;
            string cComentario2 = listDetInfRsg[0].cComentario2;
            decimal nRatioLiquidez = listDetInfRsg[0].nRatioLiquidez;
            string cComentario3 = listDetInfRsg[0].cComentario3;
            string cGarantia = String.IsNullOrEmpty(listDetInfRsg[0].cGarantia) ? "" : listDetInfRsg[0].cGarantia;
            string cComentario4 = listDetInfRsg[0].cComentario4;
            int idUsuarioAnalistaRsg = (listDetInfRsg[0].lAtendido == false) ? clsVarGlobal.PerfilUsu.idUsuario : listDetInfRsg[0].idUsuarioAnalistaRsg;
            bool lVisitaNegocio = listDetInfRsg[0].lVisitaNegocio;
            bool lOpinion1 = listDetInfRsg[0].lOpinion1;
            DateTime dFechaSolicitud = listDetInfRsg[0].dFechaSolicitud;
			DateTime? dFechaIngresoGerRisg = listDetInfRsg[0].dFechaIngresoGerRisg;
			DateTime dFechaRecepcionSustento = listDetInfRsg[0].dFechaRecepcionSustento;
			DateTime dEnvioObs = listDetInfRsg[0].dEnvioObs;
			DateTime dLevantamientoObs = listDetInfRsg[0].dLevantamientoObs;
            DateTime? dFechaSalida = listDetInfRsg[0].dFechaSalida;
            string cSustento1 = listDetInfRsg[0].cSustento1;
            bool? lOpinion2 = listDetInfRsg[0].lOpinion2;
            string cSustento2 = listDetInfRsg[0].cSustento2;
			DateTime? dFechaSalida2 = listDetInfRsg[0].dFechaSalida2;
			int? idUsuarioReconsidera = listDetInfRsg[0].idUsuarioReconsidera;
            int idSolicitud = listDetInfRsg[0].idSolicitud;//************************************************//
            int idUsuarioSis = clsVarGlobal.PerfilUsu.idUsuario;
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            bool lVigente = true;
            int nEstado = (listDetInfRsg[0].lReconsidera == true) ? ((listDetInfRsg[0].lAtendido == true) ? 3 : 2) : 2;
            bool lAutorizadoReconcidera = listDetInfRsg[0].lReconsidera;
            //Preparar XML Administracion Riesgo
            var xml = new XElement("TipoNivelInformeRsg", listNivelTipoRiesgo.Select(x => new XElement("fila",
                                                new XAttribute("idTipoRiesgo", x.idTipoRiesgo),
                                                new XAttribute("idNivelRiesgo", x.idNivelRiesgo),
                                                new XAttribute("cComentario", x.cComentario5))));

            string cXml = Convert.ToString(xml);

            var xmlCompFinan = new XElement("CompoFinanRsg", listDestinoCreditoEval.Select(x => new XElement("fila",
                                                new XAttribute("cDestino", x.cDestino),
                                                new XAttribute("nMonto", x.nMonto),
                                                new XAttribute("nPorcentaje", x.nPorcentaje))));

            string cXmlCompFinan = Convert.ToString(xmlCompFinan);

			DialogResult dialrConfirmar = MessageBox.Show("¿Está seguro de guardar?", cNombreFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialrConfirmar == DialogResult.Yes)
            {

				DataTable   dt = new clsCNInformeRiesgos().regDetalleInformeRsg
				(idSolInfRiesgo                ,     idCli                    ,     idOperacion,
				idTipoCliente                  ,     nMonto                   ,     idMoneda                  ,     idActEconomica,
				idModalidad					   ,
				idSubProducto                  ,     idOficina                ,     idUsuarioAsesor           ,     nMoraOrigen,
				nMoraRsgPotencial              ,     cDestinoCredito          ,     nPromDiasAtraso           ,     nSaldoVigCraclasa,
				nFinanCraclasaImporte          ,     nAportePropImporte       ,     cComentario1              ,     nDeudaActualSF,
				nTechoMaxEndeud                ,     nEntidadesAFecha         ,     nEscalonamientoDeuda      ,
				nDeudaActualYPropuesto         ,     nTiempoActividad         ,     nTiempoResidencia         ,     idTipoVivienda,
				cComentario2                   ,     nRatioLiquidez            ,  	cComentario3                   ,     cGarantia                ,     cComentario4              ,     idUsuarioAnalistaRsg,
				lVisitaNegocio, lOpinion1, dFechaSolicitud, dFechaIngresoGerRisg, dFechaRecepcionSustento,
				dEnvioObs						,	dLevantamientoObs         ,     dFechaSalida			  ,     cSustento1                ,     lOpinion2,
				cSustento2                     ,    dFechaSalida2, idUsuarioReconsidera, cXml                     ,     cXmlCompFinan             ,     idSolicitud,
                idUsuarioSis, lVigente, nEstado, lAutorizadoReconcidera, idPerfilRecon, idPerfilAnalista);

					if (dt.Rows[0]["idMsje"].ToString() == "0")
					{
						MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarDatos();
                        cModo = "Lectura";
						habilitarSoloLectura(false);
						cargarDatos();
                        this.btnGestObs.Enabled = true;
					}
					else
					{
						MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnGestObs.Enabled = false;
						return;
					}
			}
        }
        private void enviarOpinion()
        {
            if (!validarCampos())
            {
                return;
            }
            clsCNSolicitud SolCre = new clsCNSolicitud();
            DataTable dtSolOpiRecu = SolCre.verificarSolOpiRecu(listDetInfRsg[0].idSolicitud);
            if (dtSolOpiRecu.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud tiene pendiente la opinión de recuperaciones.", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!listDetInfRsg[0].lAtendido) //OPINION
            {
                if (cboOpinion1.SelectedItem == "Favorable" && !ValidarIndicadorObser("lAbsolCom"))
            {
                    MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else  //RECONSIDERACION
            {
                if (cboOpinion2.SelectedItem == "Favorable" && !ValidarIndicadorObser("lAbsolCom"))
            {
                    MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            DataTable dtVerComiteAmpliado = obInformeRiesgos.CNVerificarRegistroComiteAmpl(listDetInfRsg[0].idSolicitud, this.idSolInfRiesgo) ;
            int idComiteAmp = Convert.ToInt32(dtVerComiteAmpliado.Rows[0]["idComiteAmpRiesgo"]);
            bool lObligatorio = Convert.ToBoolean(dtVerComiteAmpliado.Rows[0]["lComiteObligatorio"]);
            listDetInfRsg[0].lReconsidera = (listDetInfRsg[0].lAtendido) ? listDetInfRsg[0].lReconsidera : false;
            if ((idComiteAmp == 0 && listDetInfRsg[0].lReconsidera) || (idComiteAmp == 0 && lObligatorio))
            {
                MessageBox.Show("Debe registrar un comite Ampliado de Riesgos para emitir la Opinion", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Preparando data
            listDetInfRsg[0].nMoraOrigen = Convert.ToDecimal(this.txtMoraOrigen.Text);
            listDetInfRsg[0].nMoraRsgPotencial = Convert.ToDecimal(this.txtMoraRsgPotencial.Text);

            listDetInfRsg[0].nFinanCraclasaImporte = Convert.ToDecimal(this.txtFinanCraclasaImporte.Text);

            listDetInfRsg[0].nAportePropImporte = Convert.ToDecimal(this.txtAportePropImporte.Text);

            listDetInfRsg[0].nDeudaActualSF = Convert.ToDecimal(this.txtDeudaActualSF.Text);
            listDetInfRsg[0].nTechoMaxEndeud = Convert.ToDecimal(this.txtTechoMaxEndeud.Text);
            listDetInfRsg[0].nEntidadesAFecha = Convert.ToInt32(this.txtEntidadesAFecha.Text);
            listDetInfRsg[0].nEscalonamientoDeuda = Convert.ToDecimal(this.txtEscalonamientoDeuda.Text);

            listDetInfRsg[0].cComentario1 = this.txtComentario1.Text;
            listDetInfRsg[0].cComentario2 = this.txtComentario2.Text;
            listDetInfRsg[0].cComentario3 =  (listDetInfRsg[0].idOperacion != 3) ? this.txtComentario3.Text : "";
            listDetInfRsg[0].cComentario4 =  (listDetInfRsg[0].idOperacion != 3) ? this.txtComentario4.Text : "";
            listDetInfRsg[0].cComentario5 = this.txtComentario5.Text;

            listDetInfRsg[0].dFechaRecepcionSustento = this.dtpFechaRecepcionSustento.Value;
            listDetInfRsg[0].dEnvioObs = this.dtpEnvioOBs.Value;
            listDetInfRsg[0].dLevantamientoObs = this.dtpLevantamientoOBs.Value;
            listDetInfRsg[0].cSustento1 = this.txtSustento1.Text;
            listDetInfRsg[0].cSustento2 = this.txtSustento2.Text;

            listDetInfRsg[0].lVisitaNegocio = this.cboVisitaNegocio.Text == "Si" ? true : false;
            listDetInfRsg[0].lOpinion1 = this.cboOpinion1.Text == "Favorable" ? true : false;
            listDetInfRsg[0].lOpinion2 = this.cboOpinion2.Text == "" ? (bool?)null : this.cboOpinion2.Text == "Favorable" ? true : false;



            int idSolInfRiesgo = this.idSolInfRiesgo;
            int idCli = listDetInfRsg[0].idCli;
            int idOperacion = listDetInfRsg[0].idOperacion;//
            int idTipoCliente = listDetInfRsg[0].idTipoCliente;
            decimal nMonto = listDetInfRsg[0].nMonto;
            int idMoneda = listDetInfRsg[0].idMoneda;
            int idActEconomica = listDetInfRsg[0].idActEconomica;
            int idModalidad = listDetInfRsg[0].idModalidad;//
            int idSubProducto = listDetInfRsg[0].idSubProducto;
            int idOficina = listDetInfRsg[0].idOficina;
            int idUsuarioAsesor = listDetInfRsg[0].idUsuarioAsesor;
            decimal nMoraOrigen = listDetInfRsg[0].nMoraOrigen;
            decimal nMoraRsgPotencial = listDetInfRsg[0].nMoraRsgPotencial;
            string cDestinoCredito = String.IsNullOrEmpty(listDetInfRsg[0].cDestinoCredito) ? "" : listDetInfRsg[0].cDestinoCredito;
            decimal nPromDiasAtraso = listDetInfRsg[0].nPromDiasAtraso;
            decimal nSaldoVigCraclasa = listDetInfRsg[0].nSaldoVigCraclasa;
            decimal nFinanCraclasaImporte = listDetInfRsg[0].nFinanCraclasaImporte;
            decimal nAportePropImporte = listDetInfRsg[0].nAportePropImporte;
            string cComentario1 = listDetInfRsg[0].cComentario1;
            decimal nDeudaActualSF = listDetInfRsg[0].nDeudaActualSF;
            decimal nTechoMaxEndeud = listDetInfRsg[0].nTechoMaxEndeud;
            int nEntidadesAFecha = listDetInfRsg[0].nEntidadesAFecha;
            decimal nEscalonamientoDeuda = listDetInfRsg[0].nEscalonamientoDeuda;
            decimal nDeudaActualYPropuesto = listDetInfRsg[0].nDeudaActualYPropuesto;
            int nTiempoActividad = listDetInfRsg[0].nTiempoActividad;
            int nTiempoResidencia = listDetInfRsg[0].nTiempoResidencia;
            int idTipoVivienda = listDetInfRsg[0].idTipoVivienda;
            string cComentario2 = listDetInfRsg[0].cComentario2;
            decimal nRatioLiquidez = listDetInfRsg[0].nRatioLiquidez;
            string cComentario3 = listDetInfRsg[0].cComentario3;
            string cGarantia = String.IsNullOrEmpty(listDetInfRsg[0].cGarantia) ? "" : listDetInfRsg[0].cGarantia;
            string cComentario4 = listDetInfRsg[0].cComentario4;
            int idUsuarioAnalistaRsg = (listDetInfRsg[0].lAtendido == false) ? clsVarGlobal.PerfilUsu.idUsuario : listDetInfRsg[0].idUsuarioAnalistaRsg;
            bool lVisitaNegocio = listDetInfRsg[0].lVisitaNegocio;
            bool lOpinion1 = listDetInfRsg[0].lOpinion1;
            DateTime dFechaSolicitud = listDetInfRsg[0].dFechaSolicitud;
            DateTime? dFechaIngresoGerRisg = listDetInfRsg[0].dFechaIngresoGerRisg;
            DateTime dFechaRecepcionSustento = listDetInfRsg[0].dFechaRecepcionSustento;
            DateTime dEnvioObs = listDetInfRsg[0].dEnvioObs;
            DateTime dLevantamientoObs = listDetInfRsg[0].dLevantamientoObs;
            DateTime? dFechaSalida = listDetInfRsg[0].dFechaSalida;
            string cSustento1 = listDetInfRsg[0].cSustento1;
            bool? lOpinion2 = listDetInfRsg[0].lOpinion2;
            string cSustento2 = listDetInfRsg[0].cSustento2;
            DateTime? dFechaSalida2 = listDetInfRsg[0].dFechaSalida2;
            int? idUsuarioReconsidera = listDetInfRsg[0].idUsuarioReconsidera;
            int idSolicitud = listDetInfRsg[0].idSolicitud;//************************************************//
            int idUsuarioSis = clsVarGlobal.PerfilUsu.idUsuario;
            bool lVigente = true;
            int nEstado = 1;
            bool lAutorizadoReconcidera = listDetInfRsg[0].lReconsidera;
            //Preparar XML Administracion Riesgo
            var xml = new XElement("TipoNivelInformeRsg", listNivelTipoRiesgo.Select(x => new XElement("fila",
                                                new XAttribute("idTipoRiesgo", x.idTipoRiesgo),
                                                new XAttribute("idNivelRiesgo", x.idNivelRiesgo),
                                                new XAttribute("cComentario", x.cComentario5))));

            string cXml = Convert.ToString(xml);

            var xmlCompFinan = new XElement("CompoFinanRsg", listDestinoCreditoEval.Select(x => new XElement("fila",
                                                new XAttribute("cDestino", x.cDestino),
                                                new XAttribute("nMonto", x.nMonto),
                                                new XAttribute("nPorcentaje", x.nPorcentaje))));

            string cXmlCompFinan = Convert.ToString(xmlCompFinan);

            DialogResult dialrConfirmar = MessageBox.Show("¿Está seguro de Emitir Opinión?", cNombreFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialrConfirmar == DialogResult.Yes)
            {

                DataTable dt = new clsCNInformeRiesgos().regDetalleInformeRsg
                (idSolInfRiesgo, idCli, idOperacion,
                idTipoCliente, nMonto, idMoneda, idActEconomica,
                idModalidad,
                idSubProducto, idOficina, idUsuarioAsesor, nMoraOrigen,
                nMoraRsgPotencial, cDestinoCredito, nPromDiasAtraso, nSaldoVigCraclasa,
                nFinanCraclasaImporte, nAportePropImporte, cComentario1, nDeudaActualSF,
                nTechoMaxEndeud, nEntidadesAFecha, nEscalonamientoDeuda,
                nDeudaActualYPropuesto, nTiempoActividad, nTiempoResidencia, idTipoVivienda,
                cComentario2, nRatioLiquidez, cComentario3, cGarantia, cComentario4, idUsuarioAnalistaRsg,
                lVisitaNegocio, lOpinion1, dFechaSolicitud, dFechaIngresoGerRisg, dFechaRecepcionSustento,
                dEnvioObs, dLevantamientoObs, dFechaSalida, cSustento1, lOpinion2,
                cSustento2, dFechaSalida2, idUsuarioReconsidera, cXml, cXmlCompFinan, idSolicitud,
                idUsuarioSis, lVigente, nEstado, lAutorizadoReconcidera, idPerfilRecon, idPerfilAnalista);

                if (dt.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatos();
                    cModo = "Lectura";
                    habilitarSoloLectura(false);
                    cargarDatos();
                    clsProcesoExp.guardarCopiaExpediente("Opinion de Riesgos", idSolicitud, this);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
		private void imprimir()
        {

            DataTable dtDetInfRsg = ConvertToDataTable(listDetInfRsg);
			DataTable dtNivelTipoRsg = ConvertToDataTable(listNivelTipoRiesgo);
			DataTable dtDestinoCredito = ConvertToDataTable(listDestinoCreditoEval);
            DataTable dtComiteAmpliado = obInformeRiesgos.CNObtenerDatosComiteAmplRiesgo(listDetInfRsg[0].idSolicitud, idSolInfRiesgo);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
			paramlist.Add(new ReportParameter("idSolInfRiesgo", idSolInfRiesgo.ToString(), false));
            paramlist.Add(new ReportParameter("idUsuarioSis", clsVarGlobal.PerfilUsu.idUsuario.ToString(), false));
			paramlist.Add(new ReportParameter("cNomAgen",clsVarGlobal.cNomAge,false));

            dtsList.Add(new ReportDataSource("dtsFichaOpinionRiesgo", dtDetInfRsg));
			dtsList.Add(new ReportDataSource("dtsNivelTipoRiesgo", dtNivelTipoRsg));
			dtsList.Add(new ReportDataSource("dtsDestinoCredito", dtDestinoCredito));
            dtsList.Add(new ReportDataSource("dtsComiteAmpliado", dtComiteAmpliado));

            new frmReporteLocal(dtsList, "rptFichaOpinionRiesgo.rdlc", paramlist).ShowDialog();
        }

		public void imprimir(int idSolInfRiesgo)
		{
			List<clsDetalleInformeRiesgo> listDetInfRsg2 = new List<clsDetalleInformeRiesgo>();
			List<clsComposicionCredito> listDestinoCreditoEval2 = new List<clsComposicionCredito>();
			List<clsNivelTipoRiesgo> listNivelTipoRiesgo2 = new List<clsNivelTipoRiesgo>();

			listDetInfRsg2 = obInformeRiesgos.listarDetalleInformeRiesgo(idSolInfRiesgo);
			listDestinoCreditoEval2 = obInformeRiesgos.destinoCreditoEvalGuardado(listDetInfRsg2[0].idDetalleInformeRsg);
			listNivelTipoRiesgo2 = obInformeRiesgos.tipoNivelRiesgoGuardado(listDetInfRsg2[0].idDetalleInformeRsg);


			DataTable dtDetInfRsg = ConvertToDataTable(listDetInfRsg2);
			DataTable dtNivelTipoRsg = ConvertToDataTable(listNivelTipoRiesgo2);
			DataTable dtDestinoCredito = ConvertToDataTable(listDestinoCreditoEval2);
			List<ReportParameter> paramlist = new List<ReportParameter>();
			List<ReportDataSource> dtsList = new List<ReportDataSource>();

			paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
			paramlist.Add(new ReportParameter("idSolInfRiesgo", idSolInfRiesgo.ToString(), false));
			paramlist.Add(new ReportParameter("idUsuarioSis", clsVarGlobal.PerfilUsu.idUsuario.ToString(), false));
			paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

			dtsList.Add(new ReportDataSource("dtsFichaOpinionRiesgo", dtDetInfRsg));
			dtsList.Add(new ReportDataSource("dtsNivelTipoRiesgo", dtNivelTipoRsg));
			dtsList.Add(new ReportDataSource("dtsDestinoCredito", dtDestinoCredito));

			new frmReporteLocal(dtsList, "rptFichaOpinionRiesgo.rdlc", paramlist).ShowDialog();

		}

        private void busarPorSolicitudInforme()
        {
            frmListSolInfRiesgos = new frmListSolInformeRiesgos();
            frmListSolInfRiesgos.ShowDialog();

            if (frmListSolInfRiesgos.nidSolInfRiesgo != 0)
            {
                idSolInfRiesgo = frmListSolInfRiesgos.nidSolInfRiesgo;
                int idMolidad = obInformeRiesgos.modalidadOpinionRiesgo(idSolInfRiesgo);
                if (idMolidad == 2)
                {
                    this.btnGestObs.Enabled = true;
                    limpiarDatos();
                    cargarDatos();
                }
                else
                {
                    this.btnGestObs.Enabled = false;
                    MessageBox.Show("El informe seleccionado fue realizado desde el anterior formulario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
            }

        }

        private void buscarPorInforme()
        {
            frmBuscarInfRiegos frmBuscaInf = new frmBuscarInfRiegos();
            frmBuscaInf.ShowDialog();
            if (frmBuscaInf.nidSolInfRiesgo != 0)
            {
                idInformeRiesgo = frmBuscaInf.nidSolInfRiesgo;//nidSolInfRiesgo es el número de informe en el formulario referenciado más no la solicitud.
                idSolInfRiesgo = obInformeRiesgos.RetornarSolInforme(idInformeRiesgo);

                int idMolidad = obInformeRiesgos.modalidadOpinionRiesgo(idSolInfRiesgo);
                if (idMolidad == 2)
                {
                    limpiarDatos();
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("El informe seleccionado fue realizado desde el anterior formulario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
        }

		private void busquedaRapida()
		{
			if (txtCodigoInformeRiesgo.Text.Trim().Equals(""))
			{
				MessageBox.Show("Debe ingresar un Número de Informe de Riesgo", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtCodigoInformeRiesgo.Focus();
				return;
			}

			idInformeRiesgo = Convert.ToInt32(txtCodigoInformeRiesgo.Text);

			idSolInfRiesgo = obInformeRiesgos.RetornarSolInforme(idInformeRiesgo);
			if (idSolInfRiesgo != 0)
			{
				int idMolidad = obInformeRiesgos.modalidadOpinionRiesgo(idSolInfRiesgo);
				if (idMolidad == 2)
				{
					limpiarDatos();
					cargarDatos();
				}
				else
				{
					MessageBox.Show("El informe seleccionado fue realizado desde el anterior formulario", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			else
			{
				MessageBox.Show("El informe buscado no existe", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void limpiarDatos()
        {
            listDetInfRsg.Clear();
            listDestinoCreditoEval.Clear();
            listNivelTipoRiesgo.Clear();
            this.txtComentario5.Clear();
            if (this.dtgTipoNivelRiesgo.Rows.Count > 0)
            {
                this.dtgTipoNivelRiesgo.DataSource = null;
        }
            if (this.tbcAnalisisCliente.TabCount > 0)
            {
                this.tbcAnalisisCliente.TabPages.Clear();
            }
        }

        private void habilitarBotones()
        {
            switch (cModo)
            {
                case "Nuevo":
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnImprimir.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnGrabar.Visible = true;
                    this.btnAgregar.Enabled = true;
                    this.btnQuitar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEnviarOpinion.Enabled = true;
                    break;
                case "Lectura":
                    this.btnEditar.Enabled = true;
                    this.btnEditar.Visible = true;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCancelar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEditarAdministracion.Enabled = false;
                    this.btnAgregar.Enabled = false;
                    this.btnQuitar.Enabled = false;
                    this.btnCancelarAdministracion.Enabled = false;
                    this.btnEnviarOpinion.Enabled = false;
                    btnActualizar.Enabled = false;
                    break;
                case "Edición":
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = true;
                    this.btnGrabar.Visible = true;
                    this.btnImprimir.Enabled = false;
                    this.btnAgregar.Enabled = true;
                    this.btnQuitar.Enabled = true;
                    this.btnEditarAdministracion.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEnviarOpinion.Enabled = true;
                    this.btnGestObs.Enabled = true;
                    break;
                default:
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCancelar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEnviarOpinion.Enabled = false;
                    this.btnGestObs.Enabled = false;
                    break;
            }
        }

        private void habilitarSoloLectura(bool lEditar)
        {
            txtSustento2.ReadOnly = lEditar;
            cboOpinion2.Enabled = !lEditar;
            cboOpinion2.Enabled = !lEditar;
            if (listDetInfRsg.Count > 0)
            {
                if (listDetInfRsg[0].lReconsidera == true && listDetInfRsg[0].lAtendido == true)
                {
                    this.tbcAnalisisCliente.SelectedTab = tabPage7;
                    lEditar = true;
                }
            }
            txtMoraOrigen.ReadOnly = lEditar;
            txtMoraRsgPotencial.ReadOnly = lEditar;
            txtFinanCraclasaImporte.ReadOnly = lEditar;
            txtAportePropImporte.ReadOnly = lEditar;
            txtDeudaActualSF.ReadOnly = lEditar;
            txtTechoMaxEndeud.ReadOnly = lEditar;
            txtEntidadesAFecha.ReadOnly = lEditar;
            txtEscalonamientoDeuda.ReadOnly = lEditar;
            txtComentario1.ReadOnly = lEditar;
            txtComentario2.ReadOnly = lEditar;
            if (listDetInfRsg.Count > 0)
            {
                if (listDetInfRsg[0].idOperacion != 3)
                {
                txtComentario3.ReadOnly = lEditar;
                txtComentario4.ReadOnly = lEditar;
            }
            }
            txtComentario5.ReadOnly = lEditar;
			dtpFechaRecepcionSustento.Enabled = !lEditar;
			dtpEnvioOBs.Enabled = !lEditar;
			dtpLevantamientoOBs.Enabled = !lEditar;
            txtSustento1.ReadOnly = lEditar;
            cboVisitaNegocio.Enabled = !lEditar;
            cboOpinion1.Enabled = !lEditar;
            cboTipoRiesgo.Enabled = !lEditar;
            cboNivelRiesgo.Enabled = !lEditar;
            btnAdministradorFiles1.idSolicitud = 0;
            btnAdministradorFiles1.Enabled = !lEditar;
        }

		private void formatearGridTipoNivel()
		{
			foreach (DataGridViewColumn item in this.dtgTipoNivelRiesgo.Columns)
			{
				item.Visible = false;
				item.SortMode = DataGridViewColumnSortMode.Automatic;
			}
			this.dtgTipoNivelRiesgo.Columns["cTipoRiesgo"].Visible = true;
			this.dtgTipoNivelRiesgo.Columns["cNivelRiesgo"].Visible = true;
			this.dtgTipoNivelRiesgo.Columns["cComentario5"].Visible = true;

			this.dtgTipoNivelRiesgo.Columns["cTipoRiesgo"].HeaderText = "Tipo de riesgo";
			this.dtgTipoNivelRiesgo.Columns["cNivelRiesgo"].HeaderText = "Nivel de riesgo";
			this.dtgTipoNivelRiesgo.Columns["cComentario5"].HeaderText = "Comentario";
		}

		private void formatearGridDestino()
		{
			foreach (DataGridViewColumn item in this.dtgComposicionCredito.Columns)
			{
				item.Visible = false;
				item.SortMode = DataGridViewColumnSortMode.Automatic;
			}
			this.dtgComposicionCredito.Columns["cDestino"].Visible = true;
			this.dtgComposicionCredito.Columns["nMonto"].Visible = true;
			this.dtgComposicionCredito.Columns["nPorcentaje"].Visible = true;

			this.dtgComposicionCredito.Columns["cDestino"].HeaderText = "Destino";
			this.dtgComposicionCredito.Columns["nMonto"].HeaderText = "Monto";
			this.dtgComposicionCredito.Columns["nPorcentaje"].HeaderText = "%";
		}

		private void formatearGridIndicadoresFinancieros()
		{
			foreach (DataGridViewColumn item in this.dtgIndicadoresFinancieros.Columns)
			{
				item.Visible = false;
				item.SortMode = DataGridViewColumnSortMode.Automatic;
			}
			this.dtgIndicadoresFinancieros.Columns["cDescripcion"].Visible = true;
			this.dtgIndicadoresFinancieros.Columns["cDescFormula"].Visible = true;
			this.dtgIndicadoresFinancieros.Columns["nRatio"].Visible = true;
			this.dtgIndicadoresFinancieros.Columns["cDescRegla"].Visible = true;

			this.dtgIndicadoresFinancieros.Columns["cDescripcion"].HeaderText = "Descripción";
			this.dtgIndicadoresFinancieros.Columns["cDescFormula"].HeaderText = "Fórmula";
			this.dtgIndicadoresFinancieros.Columns["nRatio"].HeaderText = "Ratio(%)";
			this.dtgIndicadoresFinancieros.Columns["cDescRegla"].HeaderText = "Regla";

			this.dtgIndicadoresFinancieros.Columns["nRatio"].DefaultCellStyle.Format = "n2";
		}

		private void formatearHoras()
		{
			dtpFechaRecepcionSustento.Format = DateTimePickerFormat.Custom;
			dtpFechaRecepcionSustento.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

			dtpEnvioOBs.Format = DateTimePickerFormat.Custom;
			dtpEnvioOBs.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";

			dtpLevantamientoOBs.Format = DateTimePickerFormat.Custom;
			dtpLevantamientoOBs.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"; 
		}
        #endregion
        #region Eventos
        private void frmDetalleInformeRiesgo_Load(object sender, EventArgs e)
        {
			this.activarControlObjetos(this, EventoFormulario.INICIO);
            button1.Enabled = false;
			formatearHoras(); 
        }

        private void txtFinanCraclasaImporte_TextChanged(object sender, EventArgs e)
        {
            calcComposicionFinanciamiento();
        }

        private void txtAportePropImporte_TextChanged(object sender, EventArgs e)
        {
            calcComposicionFinanciamiento();
        }

		private void txtTechoMaxEndeud_TextChanged(object sender, EventArgs e)
		{
            if (cModo == "Nuevo")
            {
                calcularEscalonamientoDeuda();
            }
			
		}

        private void pintarCamposEditables()
        {
            Color amarillo = Color.LightGoldenrodYellow;
            Color verde = Color.LightGreen;
            Color celeste = Color.PaleTurquoise;
            if (cModo == "Nuevo")
            {
                txtFinanCraclasaImporte.BackColor = verde;
                txtAportePropImporte.BackColor = verde;
                txtMoraOrigen.BackColor = verde;
                txtMoraRsgPotencial.BackColor = verde;
                txtTechoMaxEndeud.BackColor = verde;
                txtEscalonamientoDeuda.BackColor = verde;

                txtComentario1.BackColor = verde;
                txtComentario2.BackColor = verde;
                if (listDetInfRsg.Count > 0)
                {
                if (listDetInfRsg[0].idOperacion != 3)
                {
                    txtComentario3.BackColor = verde;
                    txtComentario4.BackColor = verde;
                }
                }
                
                txtComentario5.BackColor = verde;
                txtSustento1.BackColor = verde;
				txtSustento2.BackColor = verde;
				dtpFechaRecepcionSustento.BackColor = verde;
				dtpEnvioOBs.BackColor = verde;
				dtpLevantamientoOBs.BackColor = verde;
                txtFechaSalida.BackColor = verde;
            }
            else if(cModo == "Lectura")
            {
                txtFinanCraclasaImporte.BackColor = amarillo;
                txtAportePropImporte.BackColor = amarillo;
                txtMoraOrigen.BackColor = amarillo;
                txtMoraRsgPotencial.BackColor = amarillo;
                txtTechoMaxEndeud.BackColor = amarillo;
                txtEscalonamientoDeuda.BackColor = amarillo;

                txtComentario1.BackColor = amarillo;
                txtComentario2.BackColor = amarillo;
                if (listDetInfRsg.Count > 0)
                {
                if (listDetInfRsg[0].idOperacion != 3)
                {
                    txtComentario3.BackColor = amarillo;
                    txtComentario4.BackColor = amarillo;
                }
                }
                
                txtComentario5.BackColor = amarillo;
                txtSustento1.BackColor = amarillo;
                txtSustento2.BackColor = amarillo;
				dtpFechaRecepcionSustento.BackColor = amarillo;
				dtpEnvioOBs.BackColor = amarillo;
                dtpLevantamientoOBs.BackColor = amarillo;
                txtFechaSalida.BackColor = amarillo;
            }
            else if (cModo == "Edición")
            {
                if (listDetInfRsg.Count > 0)
                {
                    if (listDetInfRsg[0].lReconsidera == true && listDetInfRsg[0].lAtendido == true)
                    {
                        txtSustento2.BackColor = celeste;
                    }
                    else {
                        txtFinanCraclasaImporte.BackColor = celeste;
                        txtAportePropImporte.BackColor = celeste;
                        txtMoraOrigen.BackColor = celeste;
                        txtMoraRsgPotencial.BackColor = celeste;
                        txtTechoMaxEndeud.BackColor = celeste;
                        txtEscalonamientoDeuda.BackColor = celeste;

                        txtComentario1.BackColor = celeste;
                        txtComentario2.BackColor = celeste;
                        if (listDetInfRsg.Count > 0)
                        {
                            if (listDetInfRsg[0].idOperacion != 3)
                            {
                                txtComentario3.BackColor = celeste;
                                txtComentario4.BackColor = celeste;
                            }
                        }
                        txtComentario5.BackColor = celeste;
                        txtSustento1.BackColor = celeste;
                        txtSustento2.BackColor = celeste;
                        dtpFechaRecepcionSustento.BackColor = celeste;
                        dtpEnvioOBs.BackColor = celeste;
                        dtpLevantamientoOBs.BackColor = celeste;
                        txtFechaSalida.BackColor = celeste;
                    }
                }
               
            }
        }
        private void obtenerUrlWeb()
        {
            this.Text = cNombreFormulario;
            string cInicio = "(";
            string cFin = ")";
            int nIndiceInicio = 0;
            int nIndiceFin = 0;
            int nIndice = 0;
            List<string> listValores = new List<string>();
            listValores.Clear();
            listUrlWeb.Add(
                    new clsUlrWeb
                    {
                        idRutaWeb = 0,
                        cNombreWeb = "",
                        cRutaWeb = ""
                    }
                );
            while ((nIndiceInicio = cUrlWebs.IndexOf(cInicio, nIndiceInicio)) != -1 &&
               (nIndiceFin = cUrlWebs.IndexOf(cFin, nIndiceInicio + cInicio.Length)) != -1)
            {
                string cValor = cUrlWebs.Substring(nIndiceInicio + cInicio.Length, nIndiceFin - nIndiceInicio - cInicio.Length);
                listValores.Add(cValor);
                nIndiceInicio = nIndiceFin + cFin.Length;
            }
            foreach (string valor in listValores)
            {
                string[] partes = valor.Split('|');
                nIndice++;
                listUrlWeb.Add(
                    new clsUlrWeb 
                    { 
                        idRutaWeb = nIndice, 
                        cNombreWeb = partes[0], 
                        cRutaWeb = partes[1] 
                    }
                );
            }
            this.cboUrlWeb.DataSource = listUrlWeb;
            this.cboUrlWeb.DisplayMember = "cNombreWeb";
            this.cboUrlWeb.ValueMember = "idRutaWeb";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarTipoNivelRiesgo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarTipoNivelRiesgo();
        }
        
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            quitarTipoNivelRiesgo();
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            registrarEdicionTipoNivelRiesgo();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.btnEditarAdministracion.Enabled = true;
            this.btnEditarAdministracion.Visible = true;
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Visible = false;
            this.cboTipoRiesgo.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnAgregar.Visible = true;
            this.btnQuitar.Enabled = true;
            this.btnQuitar.Visible = true;
            this.btnCancelarAdministracion.Enabled = false;
            this.btnCancelarAdministracion.Visible = false;
            this.txtComentario5.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabarDatos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           imprimir();
        }

        private void btnEditarGeneral_Click(object sender, EventArgs e)
        {
            if (listDetInfRsg[0].lEditable == false)
            {
                MessageBox.Show("El registro ya no se puede editar, porque el estado del crédito cambió.", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (listDetInfRsg[0].lReconsidera == false && listDetInfRsg[0].lAtendido == true)
            {
                MessageBox.Show("El registro ya no se puede editar, La Opinión fue emitida.", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (listDetInfRsg[0].lReconsidera == true && listDetInfRsg[0].lAtendido == true && listDetInfRsg[0].lFavorable == true)
            {
                MessageBox.Show("El registro ya no se puede editar, La Opinión fue emitida.", cNombreFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            habilitarSoloLectura(false);
            cModo = "Edición";
            this.Text = cNombreFormulario + " - " + cModo;
            habilitarBotones();
            pintarCamposEditables();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(idSolInfRiesgo > 0 && listDetInfRsg.Count > 0)
            {
                if (!ValidarIndicadorObser("lEmision"))
                {
                    MessageBox.Show("La solicitud debe estar en 'Emisión Completa' para pasar a la siguiente etapa, no puede cerrar el formulario.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    this.btnSalir.lEventoDesactivado = false;
                }
            }
            this.Dispose();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            buscarPorInforme();
        }

        private void btnListaSolPendientes_Click(object sender, EventArgs e)
        {
            busarPorSolicitudInforme();
        }

        private void btnAgrDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            this.tbcAnalisisCliente.Controls.Add(this.tabPage1);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage2);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage3);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage4);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage5);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage6);
            this.tbcAnalisisCliente.Controls.Add(this.tabPage7);

            listDetInfRsg.Clear();
            this.txtSolInfRiesgo.Clear();
            this.txtNombreCliente.Clear();
            this.txtDocumento.Clear();
            this.txtidCli.Clear();
            this.txtOperacion.Clear();
            this.txtTipoCliente.Clear();
            this.txtMonto.Clear();
            this.txtMoneda.Clear();
            this.txtActEconomica.Clear();
            this.txtModalidad.Clear();
            this.txtSubProducto.Clear();
            this.txtOficina.Clear();
            this.txtNombreAsesor.Clear();
            this.txtMoraOrigen.Clear();
            this.txtMoraRsgPotencial.Clear();
            this.txtDestinoCredito.Clear();
            this.txtPromDiasAtraso.Clear();
            this.txtSaldoVigCraclasa.Clear();
            this.txtFinanCraclasaImporte.Clear();
            this.txtAportePropImporte.Clear();
            this.txtComentario1.Clear();
            this.txtDeudaActualSF.Clear();
            //this.txtTechoMaxEndeud.Clear();
            this.txtEntidadesAFecha.Clear();
            this.txtEscalonamientoDeuda.Clear();
            this.txtDeudaActualYPropuesto.Clear();
            this.txtTiempoActividad.Clear();
            this.txtTiempoResidencia.Clear();
            this.txtTipoVivienda.Clear();
            this.txtComentario2.Clear();
            this.txtRatioLiquidez.Clear();
            this.txtComentario3.Clear();
            this.txtComentario4.Clear();
            this.txtGarantia.Clear();
            this.txtAnalistaRsg.Clear();
            this.txtFechaSolicitud.Clear();
            this.txtFechaIngresoGerRisg.Clear();
            this.dtpFechaRecepcionSustento.Text = "";
            this.dtpEnvioOBs.Text = "";
            this.dtpLevantamientoOBs.Text = "";
            this.txtSustento1.Clear();
            this.txtSustento2.Clear();
            this.txtUsuarioReconsidera.Clear();
            this.txtFechaSalida2.Clear();
            this.textMotivoOpinion.Text = "Motivo...";

            this.cboTipoRiesgo.DataSource = null;

            this.cboNivelRiesgo.DataSource = null;
            this.txtFechaSalida.Clear();
            this.Text = cNombreFormulario;

            bool lEnabled = true;
            txtSustento2.Enabled = lEnabled;
            //cboOpinion2.Enabled = lEnabled;
            txtMoraOrigen.Enabled = lEnabled;
            txtMoraRsgPotencial.Enabled = lEnabled;
            txtFinanCraclasaImporte.Enabled = lEnabled;
            txtAportePropImporte.Enabled = lEnabled;
            txtDeudaActualSF.Enabled = lEnabled;
            txtTechoMaxEndeud.Enabled = lEnabled;
            txtEntidadesAFecha.Enabled = lEnabled;
            txtEscalonamientoDeuda.Enabled = lEnabled;
            txtComentario1.Enabled = lEnabled;
            txtComentario2.Enabled = lEnabled;
            txtComentario3.Enabled = lEnabled;
            txtComentario4.Enabled = lEnabled;
            txtComentario5.Enabled = lEnabled;
            dtpFechaRecepcionSustento.Enabled = lEnabled;
            dtpEnvioOBs.Enabled = lEnabled;
            dtpLevantamientoOBs.Enabled = lEnabled;
            txtSustento1.Enabled = lEnabled;
            cboOpinion1.Enabled = lEnabled;
            cboTipoRiesgo.Enabled = lEnabled;
            cboNivelRiesgo.Enabled = lEnabled;
            btnAdministradorFiles1.idSolicitud = 0;
            btnAdministradorFiles1.Enabled = lEnabled;


            listDestinoCreditoEval.Clear();
            dtgComposicionCredito.DataSource = null;


            listNivelTipoRiesgo.Clear();
            dtgTipoNivelRiesgo.DataSource = null;
            this.txtUsuarioReconsidera.Clear();
            this.txtFechaSalida2.Clear();

            Color cancelar = Color.Gainsboro;
            txtFinanCraclasaImporte.BackColor = cancelar;
            txtAportePropImporte.BackColor = cancelar;
            txtMoraOrigen.BackColor = cancelar;
            txtMoraRsgPotencial.BackColor = cancelar;
            txtTechoMaxEndeud.BackColor = cancelar;
            txtEscalonamientoDeuda.BackColor = cancelar;
            txtComentario1.BackColor = cancelar;
            txtComentario2.BackColor = cancelar;
            txtComentario3.BackColor = cancelar;
            txtComentario4.BackColor = cancelar;
            txtComentario5.BackColor = cancelar;
            txtSustento1.BackColor = cancelar;
            txtSustento2.BackColor = cancelar;
            dtpFechaRecepcionSustento.BackColor = cancelar;
            dtpEnvioOBs.BackColor = cancelar;
            dtpLevantamientoOBs.BackColor = cancelar;
            txtFechaSalida.BackColor = cancelar;
            listIndicadoresFinancieros.Clear();
            dtgIndicadoresFinancieros.DataSource = null;


            this.btnComiteRiesgo.Enabled = false;
            this.btnGestObs.Enabled = false;
            this.btnEnviarOpinion.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnCancelar.Enabled = false;

            listDetInfRsg.Clear();
            listDestinoCreditoEval.Clear();
            listNivelTipoRiesgo.Clear();
            this.txtComentario5.Clear();
            this.dtgTipoNivelRiesgo.DataSource = null;


        }

        private void btnPosicionCliente_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.UseWaitCursor = true;
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                new frmPosicionInterv().MostrarReporte(listDetInfRsg[0].cDocumento, listDetInfRsg[0].cNombreCliente, listDetInfRsg[0].idCli);
            }
            finally
            {
                this.Enabled = true;
                this.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnEvaluacion_Click(object sender, EventArgs e)
        {
            frmExpEval frmExpEval = new frmExpEval(listDetInfRsg[0].idEvalCred, listDetInfRsg[0].idSolicitud, listDetInfRsg[0].idTipEvalCred);
            frmExpEval.ShowDialog();
        }

        private void btnHistorialCredito_Click(object sender, EventArgs e)
        {
            FrmPosicionCli frmposicioncli = new FrmPosicionCli(listDetInfRsg[0].idCli);
            frmposicioncli.ShowDialog();
        }

        private void txtCodigoInformeRiesgo_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void btnMiniBusqueda1_Click(object sender, EventArgs e)
		{
			busquedaRapida();
		}

		private void txtCodigoInformeRiesgo_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				busquedaRapida();
			}
		}

		private void dtgTipoNivelRiesgo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			this.dtgTipoNivelRiesgo.Rows[0].Selected = false;
		}
        #endregion

        private void btnCentralRiesgo_Click(object sender, EventArgs e)
        {
            btnAdministradorFiles1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.listDetInfRsg == null)
            {
                MessageBox.Show("No se ha seleccionado la evaluación", "Expediente Virtual", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.listDetInfRsg[0].idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Expediente Virtual", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (listDetInfRsg[0].idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", "Expediente Virtual", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(listDetInfRsg[0].idSolicitud, listDetInfRsg[0].idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void btnEnviar1_Click_1(object sender, EventArgs e)
        {
            enviarOpinion();
        }

        private void cboBase1_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            //displaymenber y value member
            string cValorSelect = this.cboUrlWeb.SelectedValue.ToString();
            int nValor = 0;
            bool esEntero = int.TryParse(cValorSelect, out nValor);

            if (esEntero)
            {
                int nValorSelect = Convert.ToInt32(this.cboUrlWeb.SelectedValue);
                var cRutaWebs = (from num in listUrlWeb
                                   where num.idRutaWeb == nValorSelect
                                   select num).Take(1);

                foreach (var objRuta in cRutaWebs)
                {
                    if (!objRuta.cRutaWeb.Equals(""))
                    {
                        try
                        {
                            string cNavegadorPath = obtenerNavegadorDefault();
                            if (!string.IsNullOrEmpty(cNavegadorPath))
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = cNavegadorPath,
                                    Arguments = objRuta.cRutaWeb
                                };
                                Process.Start(startInfo);
                            }
                            else
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
                                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                startInfo.Arguments = objRuta.cRutaWeb;
                                Process.Start(startInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al abrir el enlace.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                
            }    
        }
        static string obtenerNavegadorDefault()
        {
            string cNavegadorPath = string.Empty;
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\https\UserChoice");
            if (key != null)
            {
                string cProgId = key.GetValue("ProgId") as string;
                if (!string.IsNullOrEmpty(cProgId))
                {
                    if (cProgId.Equals("ChromeHTML", StringComparison.OrdinalIgnoreCase))
                    {
                        Microsoft.Win32.RegistryKey chromeKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe");
                        if (chromeKey != null)
                        {
                            cNavegadorPath = chromeKey.GetValue(null) as string;
                        }
                    }
                }
            }

            return cNavegadorPath;
        }
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            enviarOpinion();
        }

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            if(idSolInfRiesgo > 0 && listDetInfRsg.Count > 0)
            {
                frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
                frmGestObs.idEtapaEvalCred = 9;
                frmGestObs.nModoFunc = (listDetInfRsg[0].lAtendido == true ? 2 : 1);
                frmGestObs.idSolicitud = listDetInfRsg[0].idSolicitud;
                frmGestObs.ConfigSelecFiltros(true, false, true, true);
                frmGestObs.ConfigHabilitarFiltros(false, true, true, true);
                frmGestObs.ShowDialog();
            }
        }

        private bool ValidarIndicadorObser(string cFiltro)
        {
            if (idSolInfRiesgo > 0 && listDetInfRsg.Count > 0)
            {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(listDetInfRsg[0].idSolicitud, 9);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>(cFiltro));
        }
            return true;
        }

        private void cboOpinion1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboOpinion1.SelectedItem == "Favorable" && !ValidarIndicadorObser("lAbsolCom")) 
            {
                MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnComiteRiesgo_Click(object sender, EventArgs e)
        {
            if(idSolInfRiesgo > 0 && listDetInfRsg.Count > 0)
            {
                int idSolicitudSel = listDetInfRsg[0].idSolicitud;
                frmComiteAmpliadoRiesgo frmComite = new frmComiteAmpliadoRiesgo();
                frmComite.idSolicitud = idSolicitudSel;
                frmComite.idSolInformeRiesgo = idSolInfRiesgo;
                frmComite.lReferencia = true;
                frmComite.ShowDialog();
            }
        }

        private void frmOpinionRiesgo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(idSolInfRiesgo > 0 && listDetInfRsg.Count > 0)
            {
                if (!ValidarIndicadorObser("lEmision"))
                {
                    MessageBox.Show("La solicitud debe estar en 'Emisión Completa' para pasar a la siguiente etapa, no puede cerrar el formulario.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cboOpinion2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboOpinion2.SelectedItem == "Favorable" && !ValidarIndicadorObser("lAbsolCom"))
            {
                MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    
}
