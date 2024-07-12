using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class frmListaActivEcoInterna : frmBase
    {
        int nFila;
        DataTable dtListaActivInternas = new DataTable();
        clsCNListaActivEco ObjActividadEco = new clsCNListaActivEco();
        public int idActivEcoInt = 0;
        public Boolean aceptado = false;
        public frmListaActivEcoInterna()
        {
            InitializeComponent();
        }

        private void frmListaActivEcoInterna_Load(object sender, EventArgs e)
        {
            txtBusActivEco.Focus();
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusActivEco.Text))
            {
                BuscarActivEco(txtBusActivEco.Text);
                dtgActivEcoInt.Focus();
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para la búsqueda", "Registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void BuscarActivEco(string cActividad)
        {
            dtListaActivInternas = ObjActividadEco.CNListaActivEcoByNombre(cActividad);
            if (dtListaActivInternas.Rows.Count > 0)
            {
                dtgActivEcoInt.DataSource = dtListaActivInternas;
                FormatoGrid();
            }
            else
            {
                dtgActivEcoInt.DataSource = "";
                txtBusActivEco.Focus();
            }
        }
        private void FormatoGrid()
        {
            foreach (DataGridViewColumn item in dtgActivEcoInt.Columns)
	        {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
	        }
            
            dtgActivEcoInt.Columns["idActividadInterna"].Visible =false;
            dtgActivEcoInt.Columns["idActividad"].Visible =false;
            dtgActivEcoInt.Columns["lVigente"].Visible =false;
            dtgActivEcoInt.Columns["idCategoria"].Visible = false;
            dtgActivEcoInt.Columns["nRow"].Width =30;
            dtgActivEcoInt.Columns["cActividadInterna"].Width =200;

            dtgActivEcoInt.Columns["nRow"].HeaderText = "Nro.";
            dtgActivEcoInt.Columns["cActividadInterna"].HeaderText = "Actividad";
        }
        private void txtBusActivEco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtBusActivEco.Text))
                {
                    string cActividad = txtBusActivEco.Text.Trim();
                     BuscarActivEco(cActividad);
                     dtgActivEcoInt.Focus();
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para la búsqueda", "Registro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBusActivEco.Focus();
                    return;
                }

            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgActivEcoInt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActivEcoInt.Rows.Count>0)
            {
                nFila = e.RowIndex;
                idActivEcoInt = Convert.ToInt32(dtListaActivInternas.Rows[nFila]["idActividadInterna"].ToString()); 
            }
            
        }
        private void Aceptar()
        {
            if (dtgActivEcoInt.Rows.Count > 0)
            {
                this.aceptado = true;
                idActivEcoInt = Convert.ToInt32(dtListaActivInternas.Rows[nFila]["idActividadInterna"].ToString());
            }
            else
            {
                idActivEcoInt = 0;
            }
            this.Dispose();
                
        }
        private void dtgActivEcoInt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }

        }

        private void dtgActivEcoInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                Aceptar();
            }
        }

        private void dtgActivEcoInt_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }
    }
}
