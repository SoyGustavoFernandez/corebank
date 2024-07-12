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
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmBuscarComprPago : frmBase
    {
        int idTipoComprobante = 0;
        string  cSerie = "%", cNumero = "%";
        public int pidComprobantePago;

        public frmBuscarComprPago()
        {
            InitializeComponent();
        }

        private void frmBuscarComprPago_Load(object sender, EventArgs e)
        {
            InsertarItemCboTipoComprobante();
            this.cboTipoComprobantePago.SelectedIndex = 0;
            dtpFecFinal.MaxDate = clsVarGlobal.dFecSystem;
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

        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {

        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {

        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormatoDataGridView()
        {
            foreach (DataGridViewColumn column in dtgComprobantes.Columns)
            {
                column.Visible = false;
            }
            dtgComprobantes.Columns["idComprobantePago"].Visible = true;
            //dtgComprobantes.Columns["idCliente"].Visible = false;
            //dtgComprobantes.Columns["cDocumentoID"].Visible = false;
            dtgComprobantes.Columns["cNombre"].Visible = true;
            //dtgComprobantes.Columns["cDireccion"].Visible = false;
            //dtgComprobantes.Columns["idTipComPag"].Visible = false;
            dtgComprobantes.Columns["cDescripcion"].Visible = true;
            //dtgComprobantes.Columns["idMoneda"].Visible = false;
            dtgComprobantes.Columns["cMoneda"].Visible = true;
            //dtgComprobantes.Columns["idDestino"].Visible = false;
            //dtgComprobantes.Columns["dFechaEmision"].Visible = false;
            //dtgComprobantes.Columns["dFechaPago"].Visible = false;
            dtgComprobantes.Columns["cSerie"].Visible = true;
            dtgComprobantes.Columns["cNumero"].Visible = true;
            //dtgComprobantes.Columns["nSubTotal"].Visible = false;
            //dtgComprobantes.Columns["nTotalIGV"].Visible = false;
            //dtgComprobantes.Columns["nIgvCalculo"].Visible = false;
            dtgComprobantes.Columns["nTotal"].Visible = true;
            //dtgComprobantes.Columns["nTotalDetraccion"].Visible = false;
            //dtgComprobantes.Columns["dFechaProvision"].Visible = false;
            //dtgComprobantes.Columns["lEstadoProvision"].Visible = false;
            //dtgComprobantes.Columns["lCpgCajChica"].Visible = false;
            //dtgComprobantes.Columns["idEstadoComprobante"].Visible = false;
            //dtgComprobantes.Columns["nPAgoCheque"].Visible = false;

            dtgComprobantes.Columns["idComprobantePago"].HeaderText = "Codigo";
            dtgComprobantes.Columns["cNombre"].HeaderText = "Cliente";
            dtgComprobantes.Columns["cDescripcion"].HeaderText = "Tipo Comprobante";
            dtgComprobantes.Columns["cMoneda"].HeaderText = "Moneda";
            dtgComprobantes.Columns["cSerie"].HeaderText = "Serie";
            dtgComprobantes.Columns["cNumero"].HeaderText = "Numero";
            dtgComprobantes.Columns["nTotal"].HeaderText = "Monto";

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
                pidComprobantePago = Convert.ToInt32(dtgComprobantes.Rows[dtgComprobantes.SelectedCells[0].RowIndex].Cells["idComprobantePago"].Value);            
            }
            else
            {
                MessageBox.Show("Seleccione un comprobante de pago", "Busqueda de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Dispose();
        }

        private void Buscar()
        {
            clsCNCajaChica objCajChica = new clsCNCajaChica();
            if (cboEstadoComprobante.SelectedIndex==-1)
	        {
		        MessageBox.Show("Debe Seleccionar el Estado del Comprobante", "Busqueda de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
	        }

            if (rbtBusqEspecifica.Checked && txtCodigoComprobante.Text == "")
            {
                MessageBox.Show("Debe ingresar un Código de Comprobante para la búsqueda", "Busqueda de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            int idEstCpg = Convert.ToInt32(cboEstadoComprobante.SelectedValue);
            DataTable dtResult;

            if (rbtBusqEspecifica.Checked)
            {
                dtResult = objCajChica.ListarComprPago(chcTieneComprobante.Checked, chcCajChic.Checked, 0, "", "", 0, Convert.ToInt32(txtCodigoComprobante.Text), DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                dtResult = objCajChica.ListarComprPago(chcTieneComprobante.Checked, chcCajChic.Checked, Convert.ToInt32(cboTipoComprobantePago.SelectedValue), 
                                                        txtSerie.Text.Trim(), txtNumero.Text.Trim(), Convert.ToInt32(cboEstadoComprobante.SelectedValue), 0, dtpFecInicial.Value, dtpFecFinal.Value);
            }
            
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

        private void cboEstadoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void rbtBusqEspecifica_CheckedChanged(object sender, EventArgs e)
        {
            grbBusqEspecifica.Enabled = true;
            grbBusqGeneral.Enabled = false;
        }

        private void rbtBusqGeneral_CheckedChanged(object sender, EventArgs e)
        {
            grbBusqEspecifica.Enabled = false;
            grbBusqGeneral.Enabled = true;
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dtpFecFinal_ValueChanged(object sender, EventArgs e)
        {
            dtpFecInicial.MaxDate = dtpFecFinal.Value;
        }

        private void txtCodigoComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(e.KeyChar) == 13)
            {
                Buscar();
            }
        }
      
    }
}
