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
using GEN.ControlesBase;
using EntityLayer;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmComiteCreditoTiempoAdicional : frmBase
    {
        #region Variables Globales
        private int idComiteCred;
        private clsComiteCred objComiteCred;
        private clsCNComiteCreditos objCNComiteCreditos;
        private clsCNAprobacion objCNAprobacion;
        private List<clsEvalCredComite> lstEvalCredComite;

        private clsAprobacionSolicitud objAprobacionSolicitud;
        private bool lRevision;


        private System.Timers.Timer objTimer;
        private int nTiempoRestante;
        #endregion
        public frmComiteCreditoTiempoAdicional()
        {
            InitializeComponent();
        }

        public frmComiteCreditoTiempoAdicional(int idComiteCred, bool lRevision, int nTiempoApertura = 60)
        {
            InitializeComponent();
            this.idComiteCred = idComiteCred;
            this.lRevision = lRevision;
            this.nTiempoRestante = nTiempoApertura;
            this.inicializarDatos();
        }

        #region Metodos
        private void inicializarDatos()
        {
            this.objCNComiteCreditos = new clsCNComiteCreditos();
            this.objCNAprobacion = new clsCNAprobacion();
            this.lstEvalCredComite = new List<clsEvalCredComite>();

            this.objAprobacionSolicitud = new clsAprobacionSolicitud();

            this.bsEvalCred.DataSource = this.lstEvalCredComite;
            this.bsEvalCred.ResetBindings(false);
            this.habilitarControles(clsAcciones.DEFECTO);

        }
        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.nudTiempoAdicional.Enabled = false;
                    this.txtJustificacion.Enabled = false;
                    this.txtEstadoSolicitud.Enabled = false;
                    this.txtFechaSolicitud.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    this.btnGrabar.Visible = false;
                    break;
                case clsAcciones.NUEVO:
                    this.nudTiempoAdicional.Enabled = true;
                    this.txtJustificacion.Enabled = true;
                    this.txtEstadoSolicitud.Enabled = false;
                    this.txtFechaSolicitud.Enabled = false;
                    this.btnSolicitar.Visible = true;
                    break;
                case clsAcciones.GRABAR:
                    this.nudTiempoAdicional.Enabled = false;
                    this.txtJustificacion.Enabled = false;
                    this.txtEstadoSolicitud.Enabled = false;
                    this.txtFechaSolicitud.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    break;
                case clsAcciones.REVISAR:
                    this.nudTiempoAdicional.Enabled = true;
                    this.txtJustificacion.Enabled = false;
                    this.txtEstadoSolicitud.Enabled = false;
                    this.txtFechaSolicitud.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    this.btnGrabar.Visible = true;
                    break;
                case clsAcciones.FINALIZAR:
                    this.nudTiempoAdicional.Enabled = false;
                    this.txtJustificacion.Enabled = false;
                    this.txtEstadoSolicitud.Enabled = false;
                    this.txtFechaSolicitud.Enabled = false;
                    this.btnSolicitar.Visible = false;
                    this.btnGrabar.Visible = false;
                    break;
            }
        }
        private void obtenerComiteCred()
        {
            this.objComiteCred = this.objCNComiteCreditos.obtenerComiteCred(this.idComiteCred);
            if (this.objComiteCred.idComiteCred == 0)
            {
                MessageBox.Show("¡No se han podido recuperar los datos del comité de créditos!", "DATOS DE COMITE VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.visualizarComiteCred();
                this.obtenerAprobacionSolicitud();
            }
        }
        private void visualizarComiteCred()
        {
            this.lblAgencia.Text = this.objComiteCred.cNombreAge;
            this.lblComite.Text = this.objComiteCred.cNomComite;
            this.lblPresidente.Text = this.objComiteCred.cWinUserPreside;
            this.lblEstado.Text = this.objComiteCred.cEstComiteCred;
            this.lblNumCreditos.Text = this.objComiteCred.nNumEval.ToString();
            this.lblMontoTotal.Text = this.objComiteCred.nMontoCreditosTotal.ToString("###,###,###.00");

            this.lstEvalCredComite.Clear();
            this.lstEvalCredComite.AddRange(this.objComiteCred.lstEvalCred);
            this.bsEvalCred.ResetBindings(false);
            this.dtgEvalCred.Refresh();
        }
        private void grabarAprobacionSolicitud()
        {
            clsRespuestaServidor objRespuestaServidor = this.objCNAprobacion.grabarAprobacionSolicitud(
                (int)AprobacionSolicitudTipo.TiempoComiteCredito,
                this.idComiteCred,
                2,//Canal de aprobación de Ampliacion de Tiempo de Comite de Credito
                (int)this.objComiteCred.idUsuPreside,
                this.nudTiempoAdicional.Value.ToString("0"),
                this.objComiteCred.nMontoCreditosTotal,
                this.txtJustificacion.Text
                );

            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "RESULTADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFechaSolicitud.Text = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                this.txtEstadoSolicitud.Text = "REGISTRADO";
                this.habilitarControles(clsAcciones.GRABAR);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void obtenerAprobacionSolicitud()
        {
            this.objAprobacionSolicitud = this.objCNAprobacion.obtenerAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.idComiteCred);
            if (this.objAprobacionSolicitud.idAprobacionSolicitud > 0)
            {
                this.txtJustificacion.Text = this.objAprobacionSolicitud.cSustento;
                this.txtFechaSolicitud.Text = this.objAprobacionSolicitud.dFecha.ToString("dd/MM/yyyy");
                this.txtEstadoSolicitud.Text = this.objAprobacionSolicitud.cEstado;
                this.nudTiempoAdicional.Value = Convert.ToDecimal(this.objAprobacionSolicitud.cValor);

                if (this.lRevision && this.objAprobacionSolicitud.idEstado == (int)Estado.REGISTRADO)
                {
                    this.habilitarControles(clsAcciones.REVISAR);
                }
                else
                {
                    this.habilitarControles(clsAcciones.GRABAR);
                }
            }
            else
            {
                this.txtEstadoSolicitud.Text = "SIN SOLICITUD";
                this.habilitarControles(clsAcciones.NUEVO);
            }

            this.iniciarAperturaFormulario();
        }

        private void actualizarAprobacionSolicitud()
        {
            if (this.nudTiempoAdicional.Value < 5M)
            {
                frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("¡El valor solicitado debe ser mayor o igual a 5 min.!", "VALOR INCORRECTO", 5,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objFrmMensaje.ShowDialog();
                this.nudTiempoAdicional.Value = 5M;
                return;
            }
            string cValor = this.nudTiempoAdicional.Value.ToString("0");
            clsRespuestaServidor objRespuestaServidor = this.objCNAprobacion.actualizarAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.objComiteCred.idComiteCred, cValor);

            if(objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, 3,
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                objFrmMensaje.ShowDialog();

                this.habilitarControles(clsAcciones.FINALIZAR);
            }
            else
            {
                frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, 3,
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                objFrmMensaje.ShowDialog();
            }
        }

        private void iniciarTemporizador()
        {
            this.objTimer = new System.Timers.Timer();
            this.objTimer.Interval = 5000;
            this.objTimer.Elapsed += Timer_Elapsed;
            this.objTimer.Start();
        }
        private void finalizarTemporizador()
        {
            if (this.objTimer != null)
            {
                this.objTimer.Close();
            }
        }

        private void iniciarAperturaFormulario()
        {
            this.actualizarTiempoApertura();
            this.iniciarTemporizador();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!IsHandleCreated) return;
            Invoke(new MethodInvoker(delegate()
            {
                this.nTiempoRestante = this.nTiempoRestante - 5;
                if (this.nTiempoRestante <= 0)
                {
                    this.finalizarTemporizador();
                    this.Close();
                }
                this.actualizarTiempoApertura();
            }));
        }
        private void actualizarTiempoApertura()
        {
            this.lblTiempoRestante.Text = (new TimeSpan(0, 0, this.nTiempoRestante)).ToString(@"mm\:ss");
        }
        private bool datosValidos()
        {
            if (this.nudTiempoAdicional.Value < 5M)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Eventos
        private void frmComiteCreditoTiempoAdicional_Shown(object sender, EventArgs e)
        {
            this.obtenerComiteCred();
        }
        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if(this.datosValidos())
                this.grabarAprobacionSolicitud();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.actualizarAprobacionSolicitud();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmComiteCreditoTiempoAdicional_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.finalizarTemporizador();
        }
        #endregion
    }
}
