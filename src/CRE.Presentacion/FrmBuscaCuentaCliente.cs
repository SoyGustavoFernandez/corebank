using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;


namespace CRE.Presentacion
{
    public partial class FrmBuscaCuentaCliente : frmBase
    {
        public Int32 pnIdCreSol;
        public string pcIdMoneda;
        public string pcIdProducto;
        public string pcMonto;
        public string pcCuotas;
        public FrmBuscaCuentaCliente()
        {
            InitializeComponent();

        }

        private void FrmBuscaCuentaCliente_Load(object sender, EventArgs e)
        {
           
        }
        public void CargarDatos(Int32 nIdCliente, string cTipoBusqueda, string cEstadoCredito)
        {
            clsCNRetornsCuentaSolCliente objNumCreSol = new clsCNRetornsCuentaSolCliente();
            DataTable dtbNumCreSol = objNumCreSol.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstadoCredito);
            dtgDatosCreSol.DataSource = dtbNumCreSol;
           // dtgDatosCreSol.Columns.RemoveAt(2);
            dtgDatosCreSol.Columns.RemoveAt(3);
            dtgDatosCreSol.Columns.RemoveAt(4);
            dtgDatosCreSol.Columns.RemoveAt(5);
            dtgDatosCreSol.Columns.RemoveAt(7);
            dtgDatosCreSol.Columns["cNombre"].Visible = false;
            dtgDatosCreSol.Columns["idCli"].Visible = false;
            dtgDatosCreSol.Columns["IdMoneda"].Visible = false;
            dtgDatosCreSol.Columns["idProducto"].Visible = false;
            this.formatoGrid();
            conBusCli.txtCodCli.Text = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();
            conBusCli.txtNombre.Text = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
        }
        public void formatoGrid()
        {
            dtgDatosCreSol.ColumnCount = 4;
            dtgDatosCreSol.ColumnHeadersVisible = true;
            dtgDatosCreSol.Columns["idNum"].Width = 100;
            dtgDatosCreSol.Columns["nMonto"].Width = 70;
            dtgDatosCreSol.Columns["nCuotas"].Width = 70;
            dtgDatosCreSol.Columns["cEstado"].Width = 100;
            dtgDatosCreSol.Columns["idNum"].HeaderText = "Cod. Cuenta";
            dtgDatosCreSol.Columns["nMonto"].HeaderText = "Monto";
            dtgDatosCreSol.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgDatosCreSol.Columns["cEstado"].HeaderText = "Estado";
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            pnIdCreSol = Convert.ToInt32(dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idNum"].Value.ToString());
            pcIdMoneda = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["IdMoneda"].Value.ToString();
            pcIdProducto = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idProducto"].Value.ToString();
            pcMonto = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["nMonto"].Value.ToString();
            pcCuotas = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["nCuotas"].Value.ToString();
            this.Dispose();
        }

    }
}
