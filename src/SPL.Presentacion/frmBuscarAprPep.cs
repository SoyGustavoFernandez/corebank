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
using GEN.CapaNegocio;
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmBuscarAprPep : frmBase
    {
        public int pidPep=0;
        public string pcNroDocumento="";
        public int idTipoDocumento = 0;
        public frmBuscarAprPep()
        {
            InitializeComponent();
        }

        private void frmBuscarAprPep_Load(object sender, EventArgs e)
        {
            ListadoPendientesPep();
        }

        private void ListadoPendientesPep()
        {
            //clsCNPep clPep = new clsCNPep();
            //DataTable dtPendPep = clPep.CNListarPepPorAprobar();
            //dtgListaPep.DataSource = dtPendPep;
            //FormatoGrid();
            btnAceptar.Enabled = false;
            txtCBDNI1.lSoloNumeros = true;
            txtCBDNI1.MaxLength = 15;
        }

        private void buscarPep()
        { 
            if(!Validar())
            {
                return;
            }

            string cDocumento = txtCBDNI1.Text;

            clsCNPep cnPep = new clsCNPep();
            DataTable dt = cnPep.CNObtenerPepNroDocumento(cDocumento);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontrado en la lista de Personas Expuestas Políticamente con Nro de Documento: "+ cDocumento, "Cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtgListaPep.DataSource = dt;
            FormatoGrid();
            seleccionaFila();
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtCBDNI1.Text))
            {
                MessageBox.Show("Ingrese el Nro de Documento del cliente pep a buscar", "Cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCBDNI1.Focus();
                return false;
            }

            if (txtCBDNI1.Text.Length < 8)
            {
                MessageBox.Show("El nro de documento debe tener al menos 8 digitos", "Cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCBDNI1.Focus();
                return false;
            }

            return true;
        }

        private void FormatoGrid()
        {
            this.dtgListaPep.Columns["idPep"].Visible = false;
            this.dtgListaPep.Columns["idTipoDocumento"].Visible = false;
            this.dtgListaPep.Columns["bEstadoAprobacion"].Visible = false;
            
            this.dtgListaPep.Columns["cNombres"].HeaderText = "Nombres";
            this.dtgListaPep.Columns["cNombres"].Width = 80;
            this.dtgListaPep.Columns["cPaterno"].HeaderText = "Ape.Paterno";
            this.dtgListaPep.Columns["cPaterno"].Width = 80;
            this.dtgListaPep.Columns["cMaterno"].HeaderText = "Ape. Materno";
            this.dtgListaPep.Columns["cMaterno"].Width = 80;
            this.dtgListaPep.Columns["cTipoDocumento"].HeaderText = "Tipo Documento";
            this.dtgListaPep.Columns["nDocumento"].HeaderText = "Documento";
            this.dtgListaPep.Columns["nDocumento"].Width = 60;
            this.dtgListaPep.Columns["cCargo"].HeaderText = "Cargo";
            this.dtgListaPep.Columns["cCargo"].Width = 100;
            this.dtgListaPep.Columns["cInstitucion"].HeaderText = "Institución";
            this.dtgListaPep.Columns["cInstitucion"].Width = 140;
        }

        private void pintarGrid()
        {

            foreach (DataGridViewRow item in this.dtgListaPep.Rows)
            {
                Color coAprobado = Color.Azure;
                if (Convert.ToInt32(item.Cells["bEstadoAprobacion"].Value) == 2)
                { //Cliente ya esta aprobado como PEP
                    item.DefaultCellStyle.BackColor = coAprobado;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgListaPep.RowCount > 0)
            {
                pidPep = Convert.ToInt32(dtgListaPep.Rows[dtgListaPep.SelectedCells[0].RowIndex].Cells["idPep"].Value.ToString());
                pcNroDocumento = dtgListaPep.Rows[dtgListaPep.SelectedCells[0].RowIndex].Cells["nDocumento"].Value.ToString();
                idTipoDocumento = Convert.ToInt32(dtgListaPep.Rows[dtgListaPep.SelectedCells[0].RowIndex].Cells["idTipoDocumento"].Value);
            }
            else
            {
                pidPep = 0;
                pcNroDocumento = "";
                idTipoDocumento = 0;
            }

            this.Dispose();
        }

        private void dtgListaPep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgListaPep_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pidPep = 0;
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            buscarPep();
        }

        private void txtCBDNI1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                buscarPep();
            }
            
        }

        private void dtgListaPep_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            seleccionaFila();
        }

        private void seleccionaFila()
        {
            if (dtgListaPep.DataSource == null)
            {
                return;
            }

            if (((DataTable)dtgListaPep.DataSource).Rows.Count == 0)
            {
                return;
            }

            if (dtgListaPep.SelectedRows.Count == 0)
            {
                return;
            }

            if (Convert.ToInt32(dtgListaPep.SelectedRows[0].Cells["bEstadoAprobacion"].Value) == 2)
            {
                MessageBox.Show("El cliente ya fue aprobado como PEP, ", "Cliente Pep", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAceptar.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = true;
            }
        }

        private void dtgListaPep_SelectionChanged(object sender, EventArgs e)
        {
            //seleccionaFila();
        }

        private void txtCBDNI1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
