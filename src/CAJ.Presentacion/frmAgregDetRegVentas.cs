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
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmAgregDetRegVentas : frmBase
    {
        public int pidSubConcepto;
        public string pcSubConcpeto;
        public int pidAgencia;
        public decimal pnCantidad = 0, pnPrecUnit = 0;
        public Transaccion eoperacion = Transaccion.Nuevo;

        public frmAgregDetRegVentas()
        {
            InitializeComponent();
        }

        private void CargarConceptos(int nVal)
        {
            clsCNControlOpe objConceptos = new clsCNControlOpe();
            DataTable dtConceptos = objConceptos.ListaConceptos(nVal, txtBusCom.Text);
            dtgSubConceptos.DataSource = dtConceptos;
        }

        private void Aceptar()
        {
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la Agencia del Detalle.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese la cantidad.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal(txtCantidad.Text)<=0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtPrecUnit.Text))
            {
                MessageBox.Show("Ingrese el precio unitario.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal(txtPrecUnit.Text) <= 0)
            {
                MessageBox.Show("El precio unitario debe ser mayor a 0.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgSubConceptos.Rows.Count > 0 && dtgSubConceptos.CurrentRow != null)
            {
                pidSubConcepto = Convert.ToInt32(dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["idConcepto"].Value.ToString());
                pcSubConcpeto = dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["cConcepto"].Value.ToString();
                pnPrecUnit = Convert.ToDecimal(txtPrecUnit.Text);
                pnCantidad = Convert.ToDecimal(txtCantidad.Text);
                pidAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            }
            else
            {
                MessageBox.Show("Seleccione un concepto.", "Detalle Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Dispose();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargarConceptos(5); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void frmAgregDetRegVentas_Load(object sender, EventArgs e)
        {
            cboAgencias.SelectedValue = pidAgencia;
            txtPrecUnit.Text = pnPrecUnit.ToString("##,##0.00");
            txtCantidad.Text = pnCantidad.ToString("##,##0.00");
            CargarConceptos(5);
            if (eoperacion== Transaccion.Edita)
            {
                txtPrecUnit.Enabled = false;
                txtCantidad.Enabled = false;
            }
            else
            {
                if (eoperacion == Transaccion.Edita)
                {
                    txtPrecUnit.Enabled = true;
                    txtCantidad.Enabled = true;
                }
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text)) return;
            txtCantidad.Text = Convert.ToDecimal(txtCantidad.Text).ToString("##,##0.00");
        }

        private void txtPrecUnit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecUnit.Text)) return;
            txtPrecUnit.Text = Convert.ToDecimal(txtPrecUnit.Text).ToString("##,##0.00");
        }

        public void HabilitarEdicionConcepto()
        {
            txtCantidad.Enabled = false;
            txtPrecUnit.Enabled = false;
        }
    }
}
