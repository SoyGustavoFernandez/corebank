using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmGestionReglasNegExcepcion : frmBase
    {
        #region Variables Globales
        private clsCNExcepcionesCreditos objCNExcepciones;
        private List<clsExcepReglaNegResum> lstExcepReglaResum;
        private List<clsExcepcionReglaNeg> lstExcepcionRegla;
        private List<clsExcepcionReglaNeg> lstRegularizacion;
        private clsExcepReglaNegResum objExcepReglaResum;
        private clsExcepcionReglaNeg objRegularizacion;
        private clsResolucionExcepcionReglaNeg objResolucionExcepReglaNeg;

        private int idSolicitud;
        private int idSolicitudAprobacion = 0;
        private int idUsuarioAprobador = 0;
        private int idPerfilAprobador = 0;
        private int idCli;
        private int idProducto;
        private decimal nMonto;
        private string cNombreForm;
        private bool lModoApro;
        private bool lModificado;
        public int nPendientes = 0;
        public int nPendientesR = 0;
        public int nPendientesN = 0;
        public int nDenegados = 0;
        #endregion

        #region Metodos
        public frmGestionReglasNegExcepcion()
        {
            InitializeComponent();
            this.lModoApro = true;
            this.idSolicitud = 0;
            this.idCli = 0;
            this.idProducto = 0;
            this.nMonto = 0.00M;
            this.cNombreForm = string.Empty;
            this.inicializarFormulario();
        }

        public frmGestionReglasNegExcepcion(int idSolicitudAprobacion, int idUsuarioAprobador, int idPerfilAprobador)
        {
            InitializeComponent();
            this.idSolicitudAprobacion = idSolicitudAprobacion;
            this.idUsuarioAprobador = idUsuarioAprobador;
            this.idPerfilAprobador = idPerfilAprobador;
            this.lModoApro = true;
            this.idSolicitud = 0;
            this.idCli = 0;
            this.idProducto = 0;
            this.nMonto = 0.00M;
            this.cNombreForm = string.Empty;
            this.inicializarFormulario();
        }

        public frmGestionReglasNegExcepcion(bool lModoApro, int idSolicitud, int idCli, int idProducto, decimal nMonto, string cNombreForm, bool lSilencioso)
        {
            InitializeComponent();
            this.lModoApro = lModoApro;
            this.idSolicitud = idSolicitud;
            this.idCli = idCli;
            this.idProducto = idProducto;
            this.nMonto = nMonto;
            this.cNombreForm = cNombreForm;
            this.lModificado = false;
            this.inicializarFormulario();
            if (!lSilencioso)
            {
                this.ShowDialog();
            }
        }

        private void inicializarFormulario()
        {
            this.objCNExcepciones = new clsCNExcepcionesCreditos();
            this.lstExcepReglaResum = new List<clsExcepReglaNegResum>();
            this.lstExcepcionRegla = new List<clsExcepcionReglaNeg>();
            this.lstRegularizacion = new List<clsExcepcionReglaNeg>();
            this.objExcepReglaResum = new clsExcepReglaNegResum();
            this.objRegularizacion = new clsExcepcionReglaNeg();
            this.objResolucionExcepReglaNeg = new clsResolucionExcepcionReglaNeg();

            this.bsExcepcionResum.DataSource = this.lstExcepReglaResum;
            this.bsRegularizacion.DataSource = this.lstRegularizacion;

            this.habilitarCtrlReg(clsAcciones.FINALIZAR, false);

            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (this.lModoApro)
            {
                this.pnlSolicitudExcepcion.Visible = true;
                this.tsbAprobarReg.Visible = true;
                this.tsbDenegarReg.Visible = true;
                this.pnlComentarioAprobador.Visible = true;

                this.tsbAgregarER.Visible = false;
                this.tsbEditarER.Visible = false;
                this.tsbQuitarER.Visible = false;
                this.tsbAnularER.Visible = false;

                this.lblBase4.Visible = true;
                this.txtSustentoReg.Visible = true;
                this.btnAcepSustReg.Visible = false;
                this.btnCanSustReg.Visible = false;
                this.btnGrabar.Visible = false;
                this.btnSolicitar.Visible = false;
                this.listSolicExcepAprobacion(this.idSolicitudAprobacion);
            }
            else
            {
                this.pnlSolicitudExcepcion.Visible = false;
                this.tsbAprobarReg.Visible = false;
                this.tsbDenegarReg.Visible = false;
                this.pnlComentarioAprobador.Visible = false;

                this.tsbAgregarER.Visible = true;
                this.tsbEditarER.Visible = true;
                this.tsbQuitarER.Visible = true;
                this.tsbAnularER.Visible = true;

                this.lblBase4.Visible = true;
                this.txtSustentoReg.Visible = true;
                this.btnAcepSustReg.Visible = true;
                this.btnCanSustReg.Visible = true;
                this.btnGrabar.Visible = true;
                this.btnSolicitar.Visible = true;
                if (this.inicializarExcepcionesNeg())
                {
                    this.listarExcepcionReglaNeg(this.idSolicitud, string.Empty);
                    this.actualizarEstadisticas();
                }
            }
        }

        private void habilitarCtrlReg(int idAccion, bool lAuto)
        {
            if (this.lModoApro)
            {
                this.btnGrabar.Enabled = false;
                this.btnSolicitar.Enabled = false;
                this.txtSustentoReg.Enabled = false;
                this.btnAcepSustReg.Enabled = false;
                this.btnCanSustReg.Enabled = false;
                this.dtgRegularizacion.Enabled = true;

                this.tsbAgregarER.Enabled = false;
                this.tsbEditarER.Enabled = false;
                this.tsbQuitarER.Enabled = false;
                this.tsbAnularER.Enabled = false;
                switch (idAccion)
                {
                    case clsAcciones.RESOLVER:
                        this.tsbAprobarReg.Enabled = lAuto;
                        this.tsbDenegarReg.Enabled = lAuto;
                        break;
                    case clsAcciones.FINALIZAR:
                        this.tsbAprobarReg.Enabled = false;
                        this.tsbDenegarReg.Enabled = false;
                        break;
                }
            }
            else
            {
                if (!this.lModificado && !this.lstExcepcionRegla.Exists(x => x.lVigente && x.cSustento == string.Empty) &&
                    this.lstExcepcionRegla.Exists(x => x.lVigente && x.idEstado.In((int)Estado.REGISTRADO)))
                {
                    this.btnSolicitar.Enabled = true;
                }
                else
                {
                    this.btnSolicitar.Enabled = false;
                }
                this.btnGrabar.Enabled = this.lModificado;

                this.txtSustentoReg.Enabled = false;
                this.btnAcepSustReg.Enabled = false;
                this.btnCanSustReg.Enabled = false;
                this.dtgRegularizacion.Enabled = true;

                switch (idAccion)
                {
                    case clsAcciones.EDITAR:
                        this.tsbAgregarER.Enabled = true;
                        this.tsbEditarER.Enabled = true;
                        this.tsbQuitarER.Enabled = !lAuto;
                        this.tsbAnularER.Enabled = false;
                        break;
                    case clsAcciones.INICIAR:
                        this.tsbAgregarER.Enabled = false;
                        this.tsbEditarER.Enabled = false;
                        this.tsbQuitarER.Enabled = false;
                        this.tsbAnularER.Enabled = false;

                        this.txtSustentoReg.Enabled = true;
                        this.btnAcepSustReg.Enabled = true;
                        this.btnCanSustReg.Enabled = true;
                        this.btnGrabar.Enabled = false;
                        this.btnSolicitar.Enabled = false;
                        this.dtgRegularizacion.Enabled = false;
                        break;
                    case clsAcciones.CANCELAR:
                        this.tsbAgregarER.Enabled = true;
                        this.tsbEditarER.Enabled = false;
                        this.tsbQuitarER.Enabled = false;
                        this.tsbAnularER.Enabled = true;
                        break;
                    case clsAcciones.FINALIZAR:
                        this.tsbAgregarER.Enabled = true;
                        this.tsbEditarER.Enabled = false;
                        this.tsbQuitarER.Enabled = false;
                        this.tsbAnularER.Enabled = false;
                        break;
                }
            }
        }

        private void listSolicExcepAprobacion(int idSolicitud = 0)
        {
            this.lstExcepReglaResum.Clear();
            if (this.idUsuarioAprobador > 0 && this.idPerfilAprobador > 0)
            {
                this.lstExcepReglaResum.AddRange(this.objCNExcepciones.listSolicExcepAprobacion(idSolicitud, this.idUsuarioAprobador, this.idPerfilAprobador));
            }
            else
            {
                this.lstExcepReglaResum.AddRange(this.objCNExcepciones.listSolicExcepAprobacion(idSolicitud));
            }
            if(this.lstExcepReglaResum.Count==0)
            {
                if (this.idSolicitudAprobacion > 0)
                {
                    MessageBox.Show("¡No se ha encontrado ninguna solicitud de excepción de regla de negocio! \n\nPara esta solicitud de crédito.",
                        "SIN SOLICITUDES DE EXCEPCIÓN DE REGLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡No se ha encontrado ninguna solicitud de excepción de regla de negocio!", "SIN SOLICITUDES DE EXCEPCIÓN DE REGLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.lstRegularizacion.Clear();
                this.bsRegularizacion.ResetBindings(false);
                this.dtgRegularizacion.Refresh();
            }
            this.bsExcepcionResum.ResetBindings(false);
            this.dtgSolicitud.Refresh();
        }

        private void obtenerResolucionExcepReglaNeg()
        {
            int idSolicitud = this.objExcepReglaResum.idSolicitud;
            if (idSolicitud == 0)
                return;
            if (this.idUsuarioAprobador > 0 && this.idPerfilAprobador > 0)
            {
                this.objResolucionExcepReglaNeg = this.objCNExcepciones.obtenerResolucionExcepReglaNeg(idSolicitud, this.idUsuarioAprobador, this.idPerfilAprobador);
            }
            else
            {
                this.objResolucionExcepReglaNeg = this.objCNExcepciones.obtenerResolucionExcepReglaNeg(idSolicitud);
            }
            this.txtComentarioAprobador.Text = this.objResolucionExcepReglaNeg.cComentarioAprobador;
        }

        private bool inicializarExcepcionesNeg()
        {
            clsRespuestaServidor objRespuesta = this.objCNExcepciones.inicializarExcepcionReglaNeg(this.idSolicitud, this.cNombreForm);
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void listarExcepcionReglaNeg(int idSolicitud, string cNombreForm)
        {
            this.lstExcepcionRegla.Clear();
            this.lstRegularizacion.Clear();
            if (this.idUsuarioAprobador > 0 && this.idPerfilAprobador > 0)
            {
                this.lstExcepcionRegla.AddRange(this.objCNExcepciones.listarExcepcionReglaNeg(idSolicitud, cNombreForm, this.idUsuarioAprobador, this.idPerfilAprobador));
            }
            else
            {
                this.lstExcepcionRegla.AddRange(this.objCNExcepciones.listarExcepcionReglaNeg(idSolicitud, cNombreForm));
            }
            if (this.lstExcepcionRegla.Count > 0)
            {
                this.lstRegularizacion.AddRange(this.lstExcepcionRegla.FindAll(x => x.lVigente == true));
            }

            this.bsRegularizacion.ResetBindings(false);
            this.dtgRegularizacion.Refresh();
        }
        private void grabarExcepcionReglaNeg(int idEstado)
        {
            clsRespuestaServidor objRespuesta = this.objCNExcepciones.grabarExcepcionReglaNeg(this.lstExcepcionRegla, this.idSolicitud, this.cNombreForm, idEstado);
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lModificado = false;
                this.listarExcepcionReglaNeg(this.idSolicitud, string.Empty); 
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR DE GRABADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool agregarRegularizacion()
        {
            frmBuscarReglaNegocio objFrmBuscarRegla = new frmBuscarReglaNegocio(
                this.idSolicitud,
                this.cNombreForm,
                4/*Reglas del formulario y Manuales*/,
                this.lstRegularizacion.FindAll(x => x.lVigente).Select(x => x.idRegla).ToList());
            objFrmBuscarRegla.ShowDialog();
            if (objFrmBuscarRegla.objReglaNegocio.nIdRegla > 0)
            {
                if(this.lstExcepcionRegla.Exists(x=>x.idRegla == objFrmBuscarRegla.objReglaNegocio.nIdRegla))
                {
                    this.lstExcepcionRegla.Find(x=>x.idRegla == objFrmBuscarRegla.objReglaNegocio.nIdRegla).lVigente = true;
                }
                else
                {
                    clsExcepcionReglaNeg objExcepcionReglaNueva = new clsExcepcionReglaNeg();
                    objExcepcionReglaNueva.idTipoExcepcion = (int)TipoExcepcion.Regularizacion;
                    objExcepcionReglaNueva.idSolicitud = this.idSolicitud;
                    objExcepcionReglaNueva.lAutomatico = false;
                    objExcepcionReglaNueva.idRegla = objFrmBuscarRegla.objReglaNegocio.nIdRegla;
                    objExcepcionReglaNueva.cRegla = objFrmBuscarRegla.objReglaNegocio.cMensajeError;
                    objExcepcionReglaNueva.idMenu = objFrmBuscarRegla.objReglaNegocio.nIdOpcion;
                    objExcepcionReglaNueva.idProducto = this.idProducto;
                    objExcepcionReglaNueva.nMonto = this.nMonto;
                    objExcepcionReglaNueva.cSustento = string.Empty;
                    objExcepcionReglaNueva.cAprobacionCanal = objFrmBuscarRegla.objReglaNegocio.cAprobacionCanal;
                    objExcepcionReglaNueva.cNombreCorto = objFrmBuscarRegla.objReglaNegocio.cNombreCorto;
                    objExcepcionReglaNueva.cAcronimo = objFrmBuscarRegla.objReglaNegocio.cAcronimo;
                    objExcepcionReglaNueva.idAprobacionCanal = objFrmBuscarRegla.objReglaNegocio.idAprobacionCanal;

                    this.lstExcepcionRegla.Add(objExcepcionReglaNueva);                    
                }

                this.lstRegularizacion.Clear();
                this.lstRegularizacion.AddRange( this.lstExcepcionRegla.FindAll(x => x.lVigente == true));
                this.bsRegularizacion.ResetBindings(false);
                this.dtgRegularizacion.Refresh();

                return true;
            }
            return false;
        }

        private void distribuirRegularizacionEdit()
        {
            this.txtSustentoReg.Text = this.objRegularizacion.cSustento;
        }

        private bool validarSolicitudExcepcion()
        {
            int nReglasExcepcionMaxNum = Convert.ToInt32(clsVarApl.dicVarGen["nReglasExcepcionMaxNum"]);
            if (this.lstExcepcionRegla.FindAll(x => x.lVigente).Count > nReglasExcepcionMaxNum)
            {
                MessageBox.Show("¡La cantidad máxima de reglas permitidas para una solicitud de excepción es " + nReglasExcepcionMaxNum.ToString() + " !\n\n" +
                "*No se le permitirá agregar mas reglas para este proceso.\n" +
                "*No se le permitirá enviar para su aprobación.\n",
                    "SUSTENTO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if(this.lstExcepcionRegla.Exists(x=>x.lVigente && x.cSustento == string.Empty))
            {
                int nSinSustento = this.lstExcepcionRegla.Count(x=>x.lVigente && x.cSustento == string.Empty);
                MessageBox.Show("¡Queda(n) "+nSinSustento.ToString()+" excepcion(es) o regularización(es) sin sustento!\n\n"+
                "*Ingrese el sustento para cada regla que desea excepcionar o regularizar.",
                    "SUSTENTO REQUERIDO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            return true;
        }

        private void registrarDecisionExcepcionRegla(clsExcepcionReglaNeg objExcepcion, Estado idEstado)
        {
            clsRespuestaServidor objRespuesta;
            if (this.idUsuarioAprobador > 0 && this.idPerfilAprobador > 0)
            {
                objRespuesta = this.objCNExcepciones.registrarDecisionExcepcionRegla(
                    objExcepcion.idSolicitud,
                    objExcepcion.idExcepcionReglaNeg,
                    (int)idEstado,
                    this.txtComentarioAprobador.Text.Trim(),
                    this.idUsuarioAprobador,
                    this.idPerfilAprobador);
            }
            else
            {
                objRespuesta = this.objCNExcepciones.registrarDecisionExcepcionRegla(
                    objExcepcion.idSolicitud,
                    objExcepcion.idExcepcionReglaNeg,
                    (int)idEstado,
                    this.txtComentarioAprobador.Text.Trim());
            }
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, "REGISTRO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listarExcepcionReglaNeg(this.objExcepReglaResum.idSolicitud, string.Empty);
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR DE REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (objRespuesta.idRegistro.In((int)Estado.DERIVADO, (int)Estado.APROBADO, (int)Estado.DENEGADO))
            {
                this.listSolicExcepAprobacion(this.idSolicitudAprobacion);
            }
        }

        private bool validarPreviaDecision()
        {
            if (this.txtComentarioAprobador.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("¡Antes de emitir una decisión debe ingresar un COMENTARIO en cuadro de texto de la parte inferior!","COMENTARIO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.txtComentarioAprobador.Text.Length > 500)
            {
                MessageBox.Show("¡El tamaño máximo de caracteres (letras y símbolos) del COMENTARIO DEL APROBADOR es de 500 caracteres!\n\n" +
                "*El tamaño actual es de " + this.txtComentarioAprobador.Text.Length.ToString() + ".", "COMENTARIO MUY EXTENSO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void actualizarEstadisticas()
        {
            this.nPendientesR = this.lstExcepcionRegla.Count(x => x.idEstado != (int)Estado.APROBADO && x.cAcronimo == "CRERN");
            this.nPendientesN = this.lstExcepcionRegla.Count(x => !x.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO, (int)Estado.APROBADO) && x.cAcronimo == "CNERN");
            this.nDenegados = this.lstExcepcionRegla.Count(x => x.idEstado == (int)Estado.DENEGADO && x.idTipoExcepcion == 2);
            this.nPendientes = this.nPendientesR + this.nPendientesN + this.nDenegados;
        }
        #endregion

        #region Eventos
        private void tsbAprobarReg_Click(object sender, EventArgs e)
        {
            if (this.objRegularizacion.idRegla == 0 || !this.validarPreviaDecision())
                return;

            if (this.objRegularizacion.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO, (int)Estado.APROBADO))
            {
                this.registrarDecisionExcepcionRegla(this.objRegularizacion, Estado.APROBADO);
            }
            else
            {
                MessageBox.Show("No se permite emitir una decisión sobre una excepción en estado " + this.objRegularizacion.cEstado,
                    "ACCION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbDenegarReg_Click(object sender, EventArgs e)
        {
            if (this.objRegularizacion.idRegla == 0 || !this.validarPreviaDecision())
                return;

            if (this.objRegularizacion.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO))
            {
                this.registrarDecisionExcepcionRegla(this.objRegularizacion, Estado.DENEGADO);
            }
            else
            {
                MessageBox.Show("No se permite emitir una decisión sobre una excepción en estado " + this.objRegularizacion.cEstado,
                    "ACCION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbAgregarER_Click(object sender, EventArgs e)
        {
            int nReglasExcepcionMaxNum = Convert.ToInt32(clsVarApl.dicVarGen["nReglasExcepcionMaxNum"]);
            if (this.lstExcepcionRegla.FindAll(x => x.lVigente).Count >= nReglasExcepcionMaxNum)
            {
                MessageBox.Show("¡La cantidad máxima de reglas permitidas para una solicitud de excepción es " + nReglasExcepcionMaxNum.ToString() + " !\n\n" +
                "*No se le permitirá agregar mas reglas para este proceso.\n",
                    "SUSTENTO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.agregarRegularizacion())
            {
                this.lModificado = true;
            }
        }

        private void tsbEditarER_Click(object sender, EventArgs e)
        {
            if (this.objRegularizacion.idRegla > 0 && this.objRegularizacion.idEstado.In(0, (int)Estado.NINGUNO, (int)Estado.REGISTRADO))
            {
                this.distribuirRegularizacionEdit();
                this.habilitarCtrlReg(clsAcciones.INICIAR, this.objRegularizacion.lAutomatico);
            }
        }

        private void tsbQuitarER_Click(object sender, EventArgs e)
        {
            if (this.objRegularizacion.idRegla > 0)
            {
                if (!this.objRegularizacion.idEstado.In(0, (int)Estado.NINGUNO, (int)Estado.REGISTRADO))
                {
                    MessageBox.Show("¡Solo se permite QUITAR excepciones agregadas NANUALMENTE y en estados (NINGUNO, REGISTRADO)!",
                        "ACCION NO PERMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.objRegularizacion.idExcepcionReglaNeg > 0)
                {
                    this.objRegularizacion.lVigente = false;
                    this.lModificado = true;
                }
                else
                {
                    this.lstExcepcionRegla.Remove(this.objRegularizacion);
                }
                this.lstRegularizacion.Clear();
                this.lstRegularizacion.AddRange(this.lstExcepcionRegla.FindAll(x => x.lVigente == true));
                this.bsRegularizacion.ResetBindings(false);
                this.dtgRegularizacion.Refresh();
            }
        }

        private void tsbAnularER_Click(object sender, EventArgs e)
        {
            if (this.objRegularizacion.idRegla == 0 || this.objRegularizacion.idExcepcionReglaNeg == 0)
                return;

            if (this.objRegularizacion.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO, (int)Estado.APROBADO, (int)Estado.DENEGADO))
            {
                clsRespuestaServidor objRespuesta = this.objCNExcepciones.anularExcepcionReglaNegocio(this.objRegularizacion.idExcepcionReglaNeg, this.cNombreForm);
                if (objRespuesta.idResultado == ResultadoServidor.Correcto)
                {
                    MessageBox.Show(objRespuesta.cMensaje, "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.listarExcepcionReglaNeg(this.idSolicitud, this.cNombreForm);
                }
                else
                {
                    MessageBox.Show(objRespuesta.cMensaje, "OPERACION ERRONEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se permite ANULAR una excepción en estado " + this.objRegularizacion.cEstado,
                    "ACCION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAcepSustReg_Click(object sender, EventArgs e)
        {
            if (this.txtSustentoReg.Text == string.Empty)
            {
                MessageBox.Show("El sustento de la otras excepciones (regularización) no puede estar vacío.", "SUSTENTO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txtSustentoReg.Text.Length > 500)
            {
                MessageBox.Show("¡El tamaño máximo de caracteres (letras y símbolos) del SUSTENTO DE OTRAS EXCEPCIONES es de 500 caracteres!\n\n" +
                "*El tamaño actual es de " + this.txtSustentoReg.Text.Length.ToString() + ".", "SUSTENTO MUY EXTENSO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.objRegularizacion.cSustento = this.txtSustentoReg.Text;
            this.lModificado = true;
            this.habilitarCtrlReg(clsAcciones.EDITAR, this.objRegularizacion.lAutomatico);
        }

        private void btnCanSustReg_Click(object sender, EventArgs e)
        {
            this.distribuirRegularizacionEdit();
            this.habilitarCtrlReg(clsAcciones.EDITAR, this.objRegularizacion.lAutomatico);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.lModificado)
            {
                if (MessageBox.Show("¿Desea salir SIN GUARDAR?", "INFORMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        
        private void dtgRegularizacion_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgRegularizacion.SelectedRows.Count > 0)
            {
                int nIndice = this.dtgRegularizacion.SelectedRows[0].Index;
                this.objRegularizacion = this.lstRegularizacion[nIndice];
                if (lModoApro && this.objRegularizacion.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO))
                {
                    this.habilitarCtrlReg(clsAcciones.RESOLVER, true);
                }
                else if(lModoApro)
                {
                    this.habilitarCtrlReg(clsAcciones.FINALIZAR, true);
                }
                else if (this.objRegularizacion.idEstado.In(0, (int)Estado.NINGUNO, (int)Estado.REGISTRADO))
                {
                    this.habilitarCtrlReg(clsAcciones.EDITAR, this.objRegularizacion.lAutomatico);
                }
                else if (this.objRegularizacion.idEstado.In((int)Estado.SOLICITADO, (int)Estado.ENVIADO, (int)Estado.APROBADO, (int)Estado.DENEGADO))
                {
                    this.habilitarCtrlReg(clsAcciones.CANCELAR, this.objRegularizacion.lAutomatico);
                }
                else
                {
                    this.habilitarCtrlReg(clsAcciones.FINALIZAR, this.objRegularizacion.lAutomatico);
                }
            }
            else
            {
                this.objRegularizacion = new clsExcepcionReglaNeg();
                this.habilitarCtrlReg(clsAcciones.FINALIZAR, false);
            }
            this.distribuirRegularizacionEdit();
        }

        private void frmGestionReglasNegExcepcion_Load(object sender, EventArgs e)
        {
        }

        private void dtgSolicitud_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgSolicitud.SelectedRows.Count > 0)
            {
                int nIndice = this.dtgSolicitud.SelectedRows[0].Index;
                this.objExcepReglaResum = this.lstExcepReglaResum[nIndice];
                this.txtComentarioAprobador.Text = string.Empty;
                this.listarExcepcionReglaNeg(this.objExcepReglaResum.idSolicitud, string.Empty);
                this.obtenerResolucionExcepReglaNeg();
            }
            else
            {
                this.objExcepReglaResum = new clsExcepReglaNegResum();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(this.validarSolicitudExcepcion())
            {
                this.grabarExcepcionReglaNeg((int)Estado.REGISTRADO);
            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (this.lstExcepcionRegla.Exists(x => x.lVigente && x.idEstado == 0))
            {
                int nSinSustento = this.lstExcepcionRegla.Count(x => x.lVigente && x.idEstado == 0);
                MessageBox.Show("¡Queda(n) " + nSinSustento.ToString() + " excepción(es) SIN REGISTRAR!\n\n" +
                "*Registre las excepciones nuevas haciendo click sobre el botón GRABAR.",
                    "GRABADO REQUERIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!this.validarSolicitudExcepcion())
                return;

            if (this.lModificado)
            {
                MessageBox.Show("¡Existen cambios sin grabar!\n\n" +
                "*Grabe los cambios realizados haciendo click en el BOTON GRABAR.",
                "CAMBIOS SIN GRABAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.grabarExcepcionReglaNeg((int)Estado.SOLICITADO);
            }
        }

        private void frmGestionReglasNegExcepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.lModoApro)
                return;
            string cMensajeR = "";
            string cMensajeN = "";
            this.actualizarEstadisticas();

            if (this.nPendientesN > 0)
            {
                cMensajeN = "¡Se han encontrado [ " + this.nPendientesN.ToString() + " ] excepción(es) de regla SIN SOLICITAR! en el canal NEGOCIOS\n\n";
            }

            if (this.nPendientesR > 0)
            {
                cMensajeR = "¡Se han encontrado [ " + this.nPendientesR.ToString() + " ] excepción(es) de regla SIN APROBAR! en el canal RIESGOS\n\n";
            }
            if (!string.IsNullOrEmpty(cMensajeR.Trim() + cMensajeN.Trim()))
            {
                MessageBox.Show(cMensajeR + cMensajeN +
                "*No se le permitirá continuar con el proceso si no se APRUEBAN y/o SOLICITAN todas las excepciones.",
                    "EXCEPCIONES PENDIENTES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (this.nDenegados > 0)
            {
                DialogResult idRespuesta = MessageBox.Show("¡Se han encontrado [ " +
                    this.nDenegados.ToString() + " ] excepción(es) de regla (Manuales) DENEGADA(S)!\n\n" +
                "*En caso de que usted haya subsanado las condiciones y esté seguro(a) de que ya no requiere estas excepciones generadas de forma MANUAL, tiene la opción de ANULARLAS.\n" +
                "**Al ANULAR las excepciones MANUALES, se eliminaran de la lista de OTRAS EXCEPCIONES y se volverá a VALIDAR la REGLA.\n\n" +
                "ADVERTENCIA: Si anula una excepción sin haber subsanado las condiciones observadas, la regla volverá a saltar y su envió será bloqueado nuevamente.\n\n" +
                "¿Desea anular alguna excepción DENEGADA bajo su responsabilidad y asumir lo descrito en la ADVERTENCIA?",
                "DENEGADOS ANULABLES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (idRespuesta == DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            if (this.lModoApro)
            {
                frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objExcepReglaResum.idSolicitud, this.objExcepReglaResum.idCli, "individual");
                frmExpLinea.ShowDialog();
            }
            else
            {
                frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.idSolicitud, this.idCli, "individual");
                frmExpLinea.ShowDialog();
            }
        }
        #endregion
    }
}
