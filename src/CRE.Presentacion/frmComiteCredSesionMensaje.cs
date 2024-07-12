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
    public partial class frmComiteCredSesionMensaje : Form
    {
        private string cMensaje;
        private string cTitulo;
        private MessageBoxButtons idBoton;
        private MessageBoxIcon idIcono;
        public DialogResult idResultado;

        private System.Timers.Timer objTimer;
        private int nTiempoRestante;
        public frmComiteCredSesionMensaje()
        {
            InitializeComponent();
        }

        public frmComiteCredSesionMensaje(string cMensaje, string cTitulo, int nTiempoApertura, MessageBoxButtons idBoton, MessageBoxIcon idIcono )
        {
            InitializeComponent();
            this.cMensaje = cMensaje;
            this.cTitulo = cTitulo;
            this.idBoton = idBoton;
            this.idIcono = idIcono;
            this.nTiempoRestante = nTiempoApertura;

            this.inicializarDatos();
        }
        private void inicializarDatos()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.idResultado = DialogResult.OK;

            this.visualizarMensaje();
            this.visualizarBotones();

            this.iniciarTemporizador();
        }

        private void visualizarMensaje()
        {
            this.txtMensaje.Text = this.cMensaje;
            this.Text = this.cTitulo;
        }

        private void mostrarMultimedia()
        {
            switch (this.idIcono)
            {
                case MessageBoxIcon.Information:
                    this.txtMensaje.ForeColor = System.Drawing.Color.DarkGreen;
                    break;
                case MessageBoxIcon.Warning:
                    this.txtMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                    System.Media.SystemSounds.Exclamation.Play();
                    break;
                case MessageBoxIcon.Question:
                    this.txtMensaje.ForeColor = System.Drawing.Color.DarkBlue;
                    System.Media.SystemSounds.Question.Play();
                    //this.pctIcono.Image = SystemIcons.Question;
                    break;
                case MessageBoxIcon.Error:
                    this.txtMensaje.ForeColor = System.Drawing.Color.DarkRed;
                    System.Media.SystemSounds.Exclamation.Play();
                    break;
            }
        }
        private void visualizarBotones()
        {
            switch(this.idBoton)
            {
                case MessageBoxButtons.OK:
                    this.btnAceptar.Visible = true;
                    this.btnSi.Visible = false;
                    this.btnNo.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    this.btnAceptar.Visible = false;
                    this.btnSi.Visible = true;
                    this.btnNo.Visible = true;
                    break;
                default:
                    this.btnAceptar.Visible = true;
                    this.btnSi.Visible = false;
                    this.btnNo.Visible = false;
                    break;
            }
        }

        private void iniciarTemporizador()
        {
            this.objTimer = new System.Timers.Timer();
            this.objTimer.Interval = 1000;
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
                this.nTiempoRestante = this.nTiempoRestante - 1;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.idResultado = DialogResult.OK;
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            this.idResultado = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.idResultado = DialogResult.No;
            this.Close();
        }

        private void frmComiteCredSesionMensaje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.finalizarTemporizador();
        }

        private void frmComiteCredSesionMensaje_Paint(object sender, PaintEventArgs e)
        {
            this.mostrarMultimedia();
        }
    }
}
