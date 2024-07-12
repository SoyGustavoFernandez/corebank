using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class FrmBusGrupoSol : frmBase
    {
        public int idGrupoSolidario;
        private string cNombreGrupoSol;
        private bool lBusqueda;

        public FrmBusGrupoSol()
        {
            InitializeComponent();

            this.idGrupoSolidario = 0;
            this.cNombreGrupoSol = String.Empty;
            this.lBusqueda = false;
        }

        public FrmBusGrupoSol(string _cNombreGrupoSol)
        {
            InitializeComponent();

            this.idGrupoSolidario = 0;
            this.cNombreGrupoSol = _cNombreGrupoSol;
            this.lBusqueda = (!String.IsNullOrWhiteSpace(_cNombreGrupoSol) ? true : false);

            if (this.lBusqueda)
            {
                this.txtNombreGrupoSol.Text = _cNombreGrupoSol;
                btnMiniBusq.PerformClick();
            }
        }

        private void FormatoDataGrid()
        {
            foreach (DataGridViewColumn column in dtgGrupoSolidario.Columns)
            {
                column.Visible = false;
            }

            dtgGrupoSolidario.Columns["idGrupoSolidario"].Visible = true;
            dtgGrupoSolidario.Columns["cNombre"].Visible = true;

            dtgGrupoSolidario.Columns["idGrupoSolidario"].HeaderText = "Cod. Grupo";
            dtgGrupoSolidario.Columns["cNombre"].HeaderText = "Nombre del Grupo Solidario";

            dtgGrupoSolidario.Columns["idGrupoSolidario"].FillWeight = 20;
            dtgGrupoSolidario.Columns["cNombre"].FillWeight = 100;
        }

        private void BuscarGrupoSolidario(string cDatoCriterio)
        {
            clsCNGrupoSolidario clsCNGrupoSolidario = new clsCNGrupoSolidario();
            DataTable dt = clsCNGrupoSolidario.BuscarGrupoSolidario(cDatoCriterio);

            dtgGrupoSolidario.DataSource = dt;

            FormatoDataGrid();

            this.dtgGrupoSolidario.Focus();            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgGrupoSolidario.RowCount > 0)
            {
                if (dtgGrupoSolidario.SelectedRows.Count > 0)
                {
                    this.idGrupoSolidario = Convert.ToInt32(dtgGrupoSolidario.Rows[dtgGrupoSolidario.SelectedRows[0].Index].Cells["idGrupoSolidario"].Value);
                }
            }
            else
            {
                this.txtNombreGrupoSol.Text = "";
                this.dtgGrupoSolidario.DataSource = null;
            }

            this.Dispose();
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            string cDatoCriterio = txtNombreGrupoSol.Text;

            BuscarGrupoSolidario(cDatoCriterio);

            this.dtgGrupoSolidario.Focus();
        }

        private void txtCBNumerosEnteros_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode ==Keys.Enter)
            {
                string cDatoCriterio = txtNombreGrupoSol.Text;

                BuscarGrupoSolidario(cDatoCriterio);
            }
        }

        private void FrmBusGrupoSol_Shown(object sender, EventArgs e)
        {
            if (this.lBusqueda == true)
            {
                this.btnMiniBusq.PerformClick();
                this.dtgGrupoSolidario.Focus();
            }
            else
            {
                this.txtNombreGrupoSol.Focus();
            }
        }

        private void dtgGrupoSolidario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.btnAceptar.PerformClick();
            }
        }
    }
}
