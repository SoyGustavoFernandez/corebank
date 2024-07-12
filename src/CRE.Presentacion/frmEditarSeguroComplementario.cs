using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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
    public partial class frmEditarSeguroComplementario : frmBase
    {
        clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        clsSeguroComplementario clsSeguroComplementario = new clsSeguroComplementario();
        public int idSeguro, idUsuario = clsVarGlobal.User.idUsuario;
        public string cNombreSeguro, cNombreCortoSeguro;
        public  bool lSeguroComplementario, lEstado;
        public decimal nPrecio;
        public frmEditarSeguroComplementario()
        {
            InitializeComponent();
        }
        public frmEditarSeguroComplementario(clsSeguroComplementario _clsSeguroComplementario)
        {
            InitializeComponent();
            clsSeguroComplementario = _clsSeguroComplementario;
        }

        private void frmEditarSeguroComplementario_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            CargarDatos();
            chcSegComplementario.Enabled = false;
            chcSegComplementario.Checked = true;
            //chcVigente.Checked = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBase1.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre para el seguro complementario", "Seguros complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBase1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBase2.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre corto para el seguro complementario", "Seguros complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBase2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text) || Convert.ToDecimal(txtPrecio.Text)<= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0", "Seguros complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return;
            }
            cNombreSeguro = txtBase1.Text;
            cNombreCortoSeguro = txtBase2.Text;
            nPrecio = Convert.ToDecimal(txtPrecio.Text);
            lSeguroComplementario = chcSegComplementario.Checked;
            lEstado = chcVigente.Checked ;
            DataTable dtMatenimientPaqSeguro= PaqueteSeguro.CNMantenimientoSegurosComplementarios(idUsuario, idSeguro, cNombreSeguro, cNombreCortoSeguro, lSeguroComplementario, lEstado, nPrecio);
            MessageBox.Show(dtMatenimientPaqSeguro.Rows[0]["cMensaje"].ToString(), "Mantenimiento de seguros", MessageBoxButtons.OK, ((int)dtMatenimientPaqSeguro.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            this.Close();
        }

        void CargarDatos()
        {
            if (clsSeguroComplementario.idSeguro == 0)
            {
                return;
            }
            else
            {
                CargarDatosEditar();
            }
        }
        void CargarDatosEditar()
        {
            idSeguro= clsSeguroComplementario.idSeguro;
            txtBase1.Text = clsSeguroComplementario.cSeguro;
            txtBase2.Text = clsSeguroComplementario.cSeguroCorto;
            chcVigente.Checked = clsSeguroComplementario.lVigente;
            txtPrecio.Text = clsSeguroComplementario.nPrecio.ToString();
        }
    }
}
