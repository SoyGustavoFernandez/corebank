using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBusquedaProveedor : frmBase
    {
        public clsProveedores objProveedor;

        public frmBusquedaProveedor()
        {
            InitializeComponent();
            DataTable dtResult = (DataTable)cboCriBusCli.DataSource;
            dtResult.Rows[0][1] = "NOMBRES";
            cboCriBusCli.DataSource = dtResult;
            this.cboCriBusCli.Focus();  
        }

        private void frmSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            //dtgProveedores.ColumnCount = 2;
            //dtgProveedores.ColumnHeadersVisible = true;
            //dtgProveedores.Columns[0].Width = 130;
            //dtgProveedores.Columns[1].Width = 372;
            //dtgProveedores.Columns[0].HeaderText = "Cod. Cliente";
            //dtgProveedores.Columns[1].HeaderText = "Apellidos y Nombres";
            lblCriterio.Text = "Nombre:";
        }

        private void cboCriBusCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            if (cCriBus == "1")
            {
                lblCriterio.Text = "DNI:";
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Nombre:";
            }
            else if (cCriBus == "3")
            {
                lblCriterio.Text = "RUC:";
            }
            else
            {
                lblCriterio.Text = "Otros:";
            }
            txtDniNom.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void aceptar()
        {
            if (dtgProveedores.SelectedRows.Count > 0)
            {
                objProveedor = (clsProveedores)dtgProveedores.SelectedRows[0].DataBoundItem;
                //pcCodCli = dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                //pcNroDoc = dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                //pcNomCli = dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                //pcDireccion = dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                //pnTipoPersona = (int)dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[4].Value;
                //pcCodCliLargo = dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                //pnTipoDocumento = (int)dtgProveedores.Rows[dtgProveedores.SelectedCells[0].RowIndex].Cells[6].Value;
            }
            else
            {
                objProveedor = null;
            }
            this.Dispose();
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            string cCriBus, cDatoIngr;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            cDatoIngr = txtDniNom.Text.Trim();

            if (cCriBus == "")
            {
                MessageBox.Show("Debe Seleccionar El Criterio de Busqueda", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCli.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe Ingresar los Datos a Buscar", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            List<clsProveedores> LstProveedores = new clsCNProveedor().CNBusProveedor(cCriBus, cDatoIngr);

            if (LstProveedores.Count == 0)
            {
                MessageBox.Show("No existen datos con el criterio de busqueda", "Busqueda de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtgProveedores.DataSource = LstProveedores;
            //dtgProveedores.Columns[0].Width = 130;
            //dtgProveedores.Columns[1].Width = 372;
            //dtgProveedores.Columns[0].HeaderText = "Cod. Cliente";
            //dtgProveedores.Columns[1].HeaderText = "Apellidos y Nombres";
            //dtgProveedores.Columns[2].Visible = false;
            //dtgProveedores.Columns[3].Visible = false;
            //dtgProveedores.Columns[4].Visible = false;
            //dtgProveedores.Columns[5].Visible = false;
            //dtgProveedores.Columns[6].Visible = false;

            dtgProveedores.Focus();           
        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusProveedor.PerformClick();
            }
        }

        private void dtgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
        }


    }
}
