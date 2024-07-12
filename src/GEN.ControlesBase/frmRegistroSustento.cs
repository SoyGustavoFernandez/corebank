using EntityLayer;
using System;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmRegistroSustento : frmBase
    {
        //Declaro mi variable global para registrar el sustento
        public string _sustento;

        public frmRegistroSustento()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validarDatos())
                return;

            _sustento = txtSustento.Text.Trim();

            //Cerrar formulario
            this.Close();
        }

        private bool validarDatos()
        {
            if (string.IsNullOrEmpty(txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el sustento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSustento.Focus();
                return false;
            }
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _sustento = string.Empty;
            this.Close();
        }

        private void frmRegistroSustento_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }
    }
}