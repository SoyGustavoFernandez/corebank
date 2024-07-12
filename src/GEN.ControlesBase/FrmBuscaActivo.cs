using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class FrmBuscaActivo : frmBase
    {
        clsCNActivos Activos = new clsCNActivos();
        public int pidActivo;
        public int pidCatalogo;
        

        public FrmBuscaActivo()
        {
            InitializeComponent();
        }

        private void Buscar(string cBuscActivo, int nTipoDato)
        {
            DataTable dt = Activos.CNListaTodosActivos(cBuscActivo, nTipoDato);
            dtgListaActivos.DataSource = dt;

            if (dt.Rows.Count == 0)
            {              
                MessageBox.Show("Seleccione Activo Válido", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FormatoDataGrid();
        }

        private void Aceptar()
        {
            if (dtgListaActivos.RowCount > 0)
            {
                pidActivo = Convert.ToInt32(dtgListaActivos.Rows[dtgListaActivos.SelectedCells[0].RowIndex].Cells["idActivo"].Value);
                pidCatalogo = Convert.ToInt32(dtgListaActivos.Rows[dtgListaActivos.SelectedCells[0].RowIndex].Cells["idCatalogo"].Value);
            }
            else
            {
                MessageBox.Show("Ingrese Codigo de Activo Válido", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Dispose();
        }

        private void FrmBuscaActivo_Load(object sender, EventArgs e)
        {
            Buscar('0'.ToString(), 1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodActivo.Text) && string.IsNullOrEmpty(txtNomActivo.Text))
            {
                MessageBox.Show("Ingrese Codigo o Nombre de Activo Válido", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtCodActivo.Text != "")
            {
                if (string.IsNullOrEmpty(txtCodActivo.Text))
                {
                    MessageBox.Show("Ingrese Codigo de Activo Válido", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCodActivo.Focus();
                    return;
                }
                else
                {
                    Buscar(Convert.ToInt32(txtCodActivo.Text).ToString(), 1);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtNomActivo.Text))
                {
                    MessageBox.Show("Ingrese Nombre de Activo Válido", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNomActivo.Focus();
                    return;
                }
                else
                {
                    Buscar(txtNomActivo.Text, 2);
                }
            }
            
        }
        private void FormatoDataGrid()
        {
            dtgListaActivos.Columns["idActivo"].Visible = true;
            dtgListaActivos.Columns["idCatalogo"].Visible = true;
            dtgListaActivos.Columns["cProducto"].Visible = true;
            dtgListaActivos.Columns["idGrupoActivo"].Visible = false;
            dtgListaActivos.Columns["cNombreGrupo"].Visible = true;

            dtgListaActivos.Columns["idActivo"].HeaderText = "Cod Activo";
            dtgListaActivos.Columns["idCatalogo"].HeaderText = "Cod Catálogo";
            dtgListaActivos.Columns["cProducto"].HeaderText = "Producto";
            dtgListaActivos.Columns["cNombreGrupo"].HeaderText = "Sub Grupo";

            dtgListaActivos.Columns["idActivo"].FillWeight = 5;
            dtgListaActivos.Columns["idCatalogo"].FillWeight = 5;
            dtgListaActivos.Columns["cProducto"].FillWeight = 70;
            dtgListaActivos.Columns["cNombreGrupo"].FillWeight = 20;
        }

        private void txtCodActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCodActivo.Text))
                {
                    MessageBox.Show("No se encuentra datos del código de Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Buscar(Convert.ToInt32(txtCodActivo.Text).ToString(), 1);
            }
        }

        private void txtNomActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtNomActivo.Text))
                {
                    MessageBox.Show("No se encuentra datos del nombre de Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Buscar(txtNomActivo.Text, 2);
            }
        }

        private void txtNomActivo_Click(object sender, EventArgs e)
        {
            txtCodActivo.Text = "";
        }

        private void txtCodActivo_Click(object sender, EventArgs e)
        {
            txtNomActivo.Text = "";
        }
    }
}
