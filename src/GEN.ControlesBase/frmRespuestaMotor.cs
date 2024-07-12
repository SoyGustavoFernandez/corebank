using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    //TODO: SolTechnologies - 5.Alerta que muestra el resultado del Motor de Decisiones
    public partial class frmRespuestaMotor : frmBase
    {
        public frmRespuestaMotor()
        {
            InitializeComponent();
        }

        public frmRespuestaMotor(int idrespuesta, int idSol, string estado, string hora, string comentario, string comentarioLargo = null)
        {
            InitializeComponent();
            lblIdSolicitud.Text = idSol.ToString();
            lblEstado.Text = estado.ToString();
            lblHora.Text = hora.ToString();
            lblComentarios.Text = comentario.ToString();

            if (comentarioLargo != null && !comentarioLargo.Equals(""))
            {
                txtReglas.Text = comentarioLargo.ToString();
                txtReglas.Visible = true;
                txtReglas.Height += 40;
                this.Height += 40;
            }

            switch (idrespuesta)
            {
                case 1:
                    lblEstado.ForeColor = Color.Green;
                    lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
                    break;
                case 2:
                    lblEstado.ForeColor = Color.Orange;
                    lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
                    break;
                case 3:
                    lblEstado.ForeColor = Color.Red;
                    lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
                    break;
                default:
                    lblEstado.ForeColor = Color.Black;
                    lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
                    break;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
