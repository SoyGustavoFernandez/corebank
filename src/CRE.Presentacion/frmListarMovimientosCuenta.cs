using DEP.CapaNegocio;
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
    public partial class frmListarMovimientosCuenta : frmBase
    {
        clsCNDeposito cnDeposito = new clsCNDeposito();
        public bool lAceptar = false;
        public string cNroCuenta = "";
        public int idKardex = 0;
        public DateTime dFechaAfectacion;
        public double nMonto = 0.00;
        public frmListarMovimientosCuenta()
        {
            InitializeComponent();
        }
        #region eventos
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            int idSeleccionado = dtgMovimientos.SelectedRows[0].Index;
            if (idSeleccionado >= 0)
            {
                idKardex = Convert.ToInt32(dtgMovimientos.Rows[idSeleccionado].Cells["IdKardex"].Value);
                dFechaAfectacion = Convert.ToDateTime(dtgMovimientos.Rows[idSeleccionado].Cells["dFechaOpe"].Value);
                nMonto = Convert.ToDouble(dtgMovimientos.Rows[idSeleccionado].Cells["nMontoOperacion"].Value);
                lAceptar = true;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un movimiento", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmListarMovimientosCuenta_Load(object sender, EventArgs e)
        {
            txtNroCuenta.Text = cNroCuenta;
            DataTable dtMovimientos = cnDeposito.CNListaMovimientosCuenta(cNroCuenta);
            dtgMovimientos.DataSource = dtMovimientos;
            formtearDtgMovimientos();
        }
        #endregion

        #region metodos
        private void formtearDtgMovimientos()
        {
            foreach (DataGridViewColumn column in dtgMovimientos.Columns)
            {
                column.Visible = false;
            }

            dtgMovimientos.Columns["IdKardex"].Visible = true;
            dtgMovimientos.Columns["dFechaOpe"].Visible = true;
            dtgMovimientos.Columns["cTipoOperacion"].Visible = true;
            dtgMovimientos.Columns["cMotivoOperacion"].Visible = true;
            dtgMovimientos.Columns["nMontoOperacion"].Visible = true;

            dtgMovimientos.Columns["IdKardex"].HeaderText = "Kardex";
            dtgMovimientos.Columns["dFechaOpe"].HeaderText = "Fecha de Operación";
            dtgMovimientos.Columns["cTipoOperacion"].HeaderText = "Tipo de Operación";
            dtgMovimientos.Columns["cMotivoOperacion"].HeaderText = "Motivo";
            dtgMovimientos.Columns["nMontoOperacion"].HeaderText = "Monto";

            dtgMovimientos.Columns["IdKardex"].Width = 50;
            dtgMovimientos.Columns["dFechaOpe"].Width = 70;
            dtgMovimientos.Columns["cTipoOperacion"].Width = 100;
            dtgMovimientos.Columns["cMotivoOperacion"].Width = 100;
            dtgMovimientos.Columns["nMontoOperacion"].Width = 70;
        }
        #endregion
    }
}
