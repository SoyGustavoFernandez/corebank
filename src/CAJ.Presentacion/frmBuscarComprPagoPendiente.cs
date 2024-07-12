using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmBuscarComprPagoPendiente : frmBase
    {
        int idTipoComprobante = 0;
        string  cSerie = "%", cNumero = "%";
        public int pidComprobantePago;
        public string pidCliente;
        public string pcDocumentoID, pcNombre, pcDireccion, pcDescripcion, pcGlosa;
        public int idMonedaCtaBcos;
        public decimal pnTotal;

        public frmBuscarComprPagoPendiente()
        {
            InitializeComponent();
        } 

        private void frmBuscarComprPagoPendiente_Load(object sender, EventArgs e)
        {
            InsertarItemCboTipoComprobante();
            this.cboTipoComprobantePago.SelectedIndex = 0;
        }       

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgComprobantes_KeyDown(object sender, KeyEventArgs e)
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
            dtgComprobantes.Columns["idComprobantePago"].Visible = true;
            dtgComprobantes.Columns["idCliente"].Visible = false;
            dtgComprobantes.Columns["cDocumentoID"].Visible = false;
            dtgComprobantes.Columns["cNombre"].Visible = true;
            dtgComprobantes.Columns["cDireccion"].Visible = false;
            dtgComprobantes.Columns["idTipComPag"].Visible = false;
            dtgComprobantes.Columns["cDescripcion"].Visible = true;
            dtgComprobantes.Columns["idMoneda"].Visible = false;
            dtgComprobantes.Columns["cMoneda"].Visible = true;
            dtgComprobantes.Columns["idDestino"].Visible = false;
            dtgComprobantes.Columns["dFechaEmision"].Visible = false;
            dtgComprobantes.Columns["dFechaPago"].Visible = false;
            dtgComprobantes.Columns["cSerie"].Visible = true;
            dtgComprobantes.Columns["cNumero"].Visible = true;
            dtgComprobantes.Columns["nSubTotal"].Visible = false;
            dtgComprobantes.Columns["nTotalIGV"].Visible = false;
            dtgComprobantes.Columns["nIgvCalculo"].Visible = false;
            dtgComprobantes.Columns["nTotal"].Visible = true;
            dtgComprobantes.Columns["nTotalDetraccion"].Visible = false;
            dtgComprobantes.Columns["dFechaProvision"].Visible = false;
            dtgComprobantes.Columns["lEstadoProvision"].Visible = false;
            dtgComprobantes.Columns["lCpgCajChica"].Visible = false;
            dtgComprobantes.Columns["idEstadoComprobante"].Visible = false;
            dtgComprobantes.Columns["cDescripEstado"].Visible = true;
            dtgComprobantes.Columns["cGlosa"].Visible = false;
            dtgComprobantes.Columns["cCodCliente"].Visible = false;

            dtgComprobantes.Columns["idComprobantePago"].HeaderText = "Codigo";
            dtgComprobantes.Columns["cNombre"].HeaderText = "Cliente";
            dtgComprobantes.Columns["cDescripcion"].HeaderText = "Tipo Comprobante";
            dtgComprobantes.Columns["cMoneda"].HeaderText = "Moneda";
            dtgComprobantes.Columns["cSerie"].HeaderText = "Serie";
            dtgComprobantes.Columns["cNumero"].HeaderText = "Numero";
            dtgComprobantes.Columns["nTotal"].HeaderText = "Monto";
            dtgComprobantes.Columns["cDescripEstado"].HeaderText = "Estado";

            dtgComprobantes.Columns["idComprobantePago"].Width = 40;
            dtgComprobantes.Columns["cNombre"].Width = 140;
            dtgComprobantes.Columns["cDescripcion"].Width = 100;
            dtgComprobantes.Columns["cMoneda"].Width = 80;
            dtgComprobantes.Columns["cSerie"].Width = 30;
            dtgComprobantes.Columns["cNumero"].Width = 70;
            dtgComprobantes.Columns["nTotal"].Width = 50;
        }

        private void Aceptar()
        {
            if (dtgComprobantes.RowCount > 0)
            {
                pidComprobantePago  = Convert.ToInt32(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["idComprobantePago"].Value);
                pidCliente          = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value);
                pcDocumentoID       = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value);
                pcNombre            = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cNombre"].Value);
                pcDireccion         = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cDireccion"].Value);
                pcDescripcion       = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cDescripcion"].Value); 
                pcGlosa             = Convert.ToString(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["cGlosa"].Value);
                pnTotal             = Convert.ToDecimal(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["nTotal"].Value); 
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
            DataTable dtResult = objCajChica.CNListarComprPendiente(chcTieneComprobante.Checked, chcCajChic.Checked, idTipoComprobante, cSerie, cNumero, idMonedaCtaBcos);
            dtgComprobantes.DataSource = dtResult;
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
