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
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmValidarClienteOfaq : frmBase
    {
        #region Variables Globales

        clsCNListaOfaq cnlistaofaq = new clsCNListaOfaq();

        #endregion

        public frmValidarClienteOfaq()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgClientesOfaq.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgClientesOfaq.Columns["idCli"].HeaderText = "Cod.Cli";
            dtgClientesOfaq.Columns["cNombre"].HeaderText = "Nombres";
            dtgClientesOfaq.Columns["idIdentificador"].HeaderText = "Id. Ofaq";
            dtgClientesOfaq.Columns["cDocumentoID"].HeaderText = "Doc.Identidad";
            dtgClientesOfaq.Columns["cTipo"].HeaderText = "Tipo Ofaq";
            dtgClientesOfaq.Columns["cCargo"].HeaderText = "Cargo Ofaq";
            dtgClientesOfaq.Columns["cPrograma"].HeaderText = "Programa Ofaq";
            dtgClientesOfaq.Columns["cDireccion"].HeaderText = "Direccion Ofaq";
            dtgClientesOfaq.Columns["cCiudad"].HeaderText = "Ciudad Ofaq";
            dtgClientesOfaq.Columns["cPais"].HeaderText = "Pais Ofaq";

            dtgClientesOfaq.Columns["cNombre"].Width=160;
            dtgClientesOfaq.Columns["idCli"].Width = 47;
            dtgClientesOfaq.Columns["idIdentificador"].Width = 53;
        }

        private void btnValidar1_Click(object sender, EventArgs e)
        {
            var dtClientes=cnlistaofaq.ValidarListaOfaqClientes();

            if (dtClientes.Rows.Count > 0)
            {
                dtgClientesOfaq.DataSource = dtClientes;
                formatoGrid();
                MessageBox.Show("Se encontraron " + dtClientes.Rows.Count .ToString()+ " coincidencia(s) en la búsqueda de clientes", "Validación de clientes Ofaq", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
            else
            {
                MessageBox.Show("No se encontraron coincidencias en la búsqueda de clientes", "Validación de clientes Ofaq", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}
