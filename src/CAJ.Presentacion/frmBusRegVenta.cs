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

namespace CAJ.Presentacion
{
    public partial class frmBusRegVenta : frmBase
    {
        int idTipoComprobante = 0;
        string cSerie = "%", cNumero = "%";
        public int pidRegVenta;

        public frmBusRegVenta()
        {
            InitializeComponent();
        }

        private void frmBusRegVenta_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgRegVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }
        }

        private void cboTipoComprobantePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoComprobante = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
            Buscar();
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSerie.Text.Trim()))
            {
                cSerie = "%";
            }
            else
            {
                cSerie = txtSerie.Text.Trim();
            }
            Buscar();
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {
                cNumero = "%";
            }
            else
            {
                cNumero = txtNumero.Text.Trim();
            }
            Buscar();
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Buscar();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Buscar();
            }
        }

        private void FormatoDataGridView()
        {
            dtgRegVentas.Columns["idComprobante"].Visible = true;
            dtgRegVentas.Columns["cDocumentoID"].Visible = false;
            dtgRegVentas.Columns["cNombre"].Visible = true;
            dtgRegVentas.Columns["idTipComPag"].Visible = true;
            dtgRegVentas.Columns["idMoneda"].Visible = false;
            dtgRegVentas.Columns["cMoneda"].Visible = true;
            dtgRegVentas.Columns["dFechaEmision"].Visible = false;
            dtgRegVentas.Columns["cSerie"].Visible = true;
            dtgRegVentas.Columns["cNumero"].Visible = true;

            dtgRegVentas.Columns["idComprobante"].HeaderText = "Codigo";
            dtgRegVentas.Columns["cNombre"].HeaderText = "Cliente";
            dtgRegVentas.Columns["idTipComPag"].HeaderText = "Tipo Comprobante";
            dtgRegVentas.Columns["cMoneda"].HeaderText = "Moneda";
            dtgRegVentas.Columns["cSerie"].HeaderText = "Serie";
            dtgRegVentas.Columns["cNumero"].HeaderText = "Numero";

            dtgRegVentas.Columns["idComprobante"].Width = 40;
            dtgRegVentas.Columns["cNombre"].Width = 140;
            dtgRegVentas.Columns["idTipComPag"].Width = 100;
            dtgRegVentas.Columns["cMoneda"].Width = 80;
            dtgRegVentas.Columns["cSerie"].Width = 30;
            dtgRegVentas.Columns["cNumero"].Width = 70;
        }

        private void Aceptar()
        {
            if (dtgRegVentas.RowCount > 0)
            {
                pidRegVenta = Convert.ToInt32(dtgRegVentas.Rows[dtgRegVentas.SelectedCells[0].RowIndex].Cells["idComprobante"].Value);
            }
            else
            {
                MessageBox.Show("Seleccione un comprobante de pago", "Busqueda Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Dispose();
        }

        private void Buscar()
        {
            clsCNCajaChica objCajChica = new clsCNCajaChica();
            DataTable dtResult = objCajChica.ListarRegVentas(idTipoComprobante, cSerie, cNumero);
            dtgRegVentas.DataSource = dtResult;
            FormatoDataGridView();
        }

        private void InsertarItemCboTipoComprobante()
        {
            DataTable dtCboTipoComprobante = (DataTable)cboTipoComprobantePago.DataSource;
            DataRow row = dtCboTipoComprobante.NewRow();
            row[0] = 0;
            row[1] = "TODOS";
            dtCboTipoComprobante.Rows.InsertAt(row, 0);
        }

    }
}
