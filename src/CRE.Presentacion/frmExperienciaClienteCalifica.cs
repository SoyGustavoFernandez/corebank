using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmExperienciaClienteCalifica : frmBase
    {
        public int idTipoOperacion;
        public string cDocumentocliente;
        public int idExHorario;
        DataTable dtParametrosEncuesta;
        int idRespuesta = 0;

        public frmExperienciaClienteCalifica()
        {
            InitializeComponent();
        }

        private void frmExperienciaClienteCalifica_Load(object sender, EventArgs e)
        {
            clsCNExperienciaCliente objCNParametrosEncuesta = new clsCNExperienciaCliente();
            DataSet dsRespuesta = objCNParametrosEncuesta.ListaParametrosEncuesta();

            DataTable dtPregunta = dsRespuesta.Tables[0];
            dtParametrosEncuesta = dsRespuesta.Tables[1];

            lblPregunta.Text = Convert.ToString(dtPregunta.Rows[0]["cExPregunta"]);
            lblRespuestas.Text = Convert.ToString(dtParametrosEncuesta.Rows[0]["cValVar"]);

            tbCalificacion.SelectedTab = tbCalificacion.TabPages[0];
            txtCalificacion.Text = string.Empty;
            this.txtCalificacion.Select();
            txtCalificacion.Focus();
        }
        
        private void btnRegistrar1_Click(object sender, EventArgs e)
        {
            guardarRespuestaEncuesta();
            txtCalificacion.Focus();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            guardarRespuestaEncuesta();
        }

        private void guardarRespuestaEncuesta()
        {
            if (txtCalificacion.Text == string.Empty)
            {
                MessageBox.Show("No ingresó Calificación", "Calificación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt32(txtCalificacion.Text) > 5)
            {
                MessageBox.Show("Número incorrecto, favor volver a ingresar la calificación.", "Calificación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalificacion.Text = String.Empty;
                txtCalificacion.Focus();
                return;
            }
            if (Convert.ToInt32(txtCalificacion.Text) == 0)
            {
                MessageBox.Show("Número incorrecto, favor volver a ingresar la calificación.", "Calificación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalificacion.Text = String.Empty;
                txtCalificacion.Focus();
                return;
            }
            else
            {
                clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
                DataTable dtRegCalificacion = cnExpCliente.RegistraCalificacionExpCliente(Convert.ToInt32(txtCalificacion.Text), clsVarGlobal.dFecSystem, idTipoOperacion, clsVarGlobal.nIdAgencia, txExcepcion.Text, cDocumentocliente, clsVarGlobal.User.idUsuario, idExHorario);
                if (Convert.ToInt32(dtRegCalificacion.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtRegCalificacion.Rows[0]["cMensage"].ToString(), "Registro Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idRespuesta = Convert.ToInt32(dtRegCalificacion.Rows[0]["idRpta"]);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(dtRegCalificacion.Rows[0]["cMensage"].ToString(), "Registro Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCalificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCalificacion_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5))
            {
                guardarRespuestaEncuesta();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbCalificacion.SelectedTab = tbCalificacion.TabPages[1];
            txExcepcion.Text = string.Empty;
        }

        private void btnRegresar1_Click(object sender, EventArgs e)
        {
            txExcepcion.Text = string.Empty;
            tbCalificacion.SelectedTab = tbCalificacion.TabPages[0];
            txtCalificacion.Focus();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            if (String.IsNullOrWhiteSpace(txExcepcion.Text))
            {
                MessageBox.Show("No ingresó el detalle de la Excepción", "Calificación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtRegCalificacion = cnExpCliente.RegistraCalificacionExpCliente(0, clsVarGlobal.dFecSystem, idTipoOperacion, clsVarGlobal.nIdAgencia, txExcepcion.Text, cDocumentocliente, clsVarGlobal.User.idUsuario, idExHorario);
            if (Convert.ToInt32(dtRegCalificacion.Rows[0]["idRpta"]) == 1)
            {
                MessageBox.Show(dtRegCalificacion.Rows[0]["cMensage"].ToString(), "Registro Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idRespuesta = Convert.ToInt32(dtRegCalificacion.Rows[0]["idRpta"]);
                this.Close();
            }
            else
            {
                MessageBox.Show(dtRegCalificacion.Rows[0]["cMensage"].ToString(), "Registro Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmExperienciaClienteCalifica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (idRespuesta == 0)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                focusedControl = Control.FromHandle(focusedHandle);
            return focusedControl;
        }

        private void txtCalificacion_Leave(object sender, EventArgs e)
        {
            Control[] aControlPermitido = { 
                 txtCalificacion, linkLabel1
            };

            Control oControlSelectionado = GetFocusedControl();

            if (!aControlPermitido.Contains(oControlSelectionado))
            {
                txtCalificacion.Focus();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            txtCalificacion.Focus();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            txtCalificacion.Focus();
        }

        private void lblRespuestas_Click(object sender, EventArgs e)
        {
            txtCalificacion.Focus();
        }

        private void lblPregunta_Click(object sender, EventArgs e)
        {
            txtCalificacion.Focus();
        }

    }
}
