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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRegistroCanales : frmBase
    {
        private clsCNMantenimientoCanales clsMantenimientoCanales = new clsCNMantenimientoCanales();
        private int idCanal_;
        private string cDescripcion_;
        private bool lInterno_;
        private bool lActivo_;
        private bool lLlenarFormularioMantenimiento = false;

        public frmRegistroCanales()
        {
            InitializeComponent();
        }

        public frmRegistroCanales(int idCanal, string cDescripcion, bool lInterno, bool lActivo)
        {
            idCanal_ = idCanal;
            cDescripcion_ = cDescripcion;
            lInterno_ = lInterno;
            lActivo_ = lActivo;
            lLlenarFormularioMantenimiento = true;
            InitializeComponent();
        }

        private void frmRegistroCanales_Load(object sender, EventArgs e)
        {
            chbVigente.Checked = true;
            txtCodCanal.Enabled = false;

            if (lLlenarFormularioMantenimiento)
            {
                llenarFormulario();
            }
            if (txtCodCanal.Text == "")
            {
                chbVigente.Enabled = false;
            }
        }

        private void llenarFormulario()
        {
            txtCodCanal.Text = idCanal_.ToString();
            txtDescripcion.Text = cDescripcion_.ToString();
            chbActivo.Checked = lActivo_;
            chbInterno.Checked = lInterno_;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos solicitados", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dRes = MessageBox.Show("¿Esta seguro de realizar la operación?", "Mantenimiento Canales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    if (chbVigente.Checked == true)
                    {
                        clsMantenimientoCanales.RegistrarCanal(idCanal_, txtDescripcion.Text, chbInterno.Checked, chbActivo.Checked, true);
                    }
                    else
                    {
                        clsMantenimientoCanales.RegistrarCanal(idCanal_, txtDescripcion.Text, chbInterno.Checked, chbActivo.Checked, false);
                    }
                    DialogResult dRes2 = MessageBox.Show("Operación realizada con éxito", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dRes2 == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                    return;
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.txtCodCanal.Enabled = false;
            this.txtDescripcion.Clear();
        }

        private void chbVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVigente.Checked == false)
            {
                txtCodCanal.Enabled = false;
                txtDescripcion.Enabled = false;
                chbActivo.Enabled = false;
                chbInterno.Enabled = false;
            }
            else
            {
                txtCodCanal.Enabled = true;
                txtDescripcion.Enabled = true;
                chbActivo.Enabled = true;
                chbInterno.Enabled = true;
            }
        }
    }
}
