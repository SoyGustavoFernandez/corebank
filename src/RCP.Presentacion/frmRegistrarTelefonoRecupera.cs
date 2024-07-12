using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmRegistrarTelefonoRecupera : frmBase
    {
        public int idCli;

        clsCNTelefonoRecupera CNTelefonoRecupera = new clsCNTelefonoRecupera();

        public frmRegistrarTelefonoRecupera()
        {
            InitializeComponent();
        }
        
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = CNTelefonoRecupera.InsertarTelefonoRecupera(idCli, txtTelefCel1.Text);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Telefono registrado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefCel1.Text = "";
                    cargar();
                }
                else
                {
                    MessageBox.Show("Error al registrar: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private bool validar()
        {
            if (txtTelefCel1.Text.Trim().Length <= 5)
            {
                MessageBox.Show("El numero de telefono o celular debe tener 6 digitos como mínimo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTelefCel1.Focus();
                return false;
            }
            return true;
        }

        private void frmRegistrarTelefonoRecupera_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            DataTable dtTelefonos = CNTelefonoRecupera.ListarTelefonoRecupera(idCli);
            dtgTelefonos.DataSource = dtTelefonos;
        }

    }
}
