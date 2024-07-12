using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBuscaProyecto : frmBase
    {
        private DataTable dtSubConceptos;
        public int pidSubConcepto;
        public string pcSubConcpeto;

        public frmBuscaProyecto()
        {
            InitializeComponent();
        }

        private void frmBuscarProyecto_Load(object sender, EventArgs e)
        {
            CargarConceptos();            
        }

        private void CargarConceptos()
        {
            clsCNControlOpe objConceptos = new clsCNControlOpe();
            DataTable dtConceptos = objConceptos.ListaProyectos(txtBusCom.Text);

            dtgSubConceptos.DataSource = dtConceptos;
            FormatoDataGrid();
        }
        private void FormatoDataGrid()
        {
            dtgSubConceptos.Columns["cProyecto"].MinimumWidth = 359;
            dtgSubConceptos.Columns["idProyecto"].Visible = true;
            dtgSubConceptos.Columns["cProyecto"].Visible = true;
            dtgSubConceptos.Columns["idProyecto"].HeaderText = "Codigo";
            dtgSubConceptos.Columns["cProyecto"].HeaderText = "Descripción del Proyecto";
            
        }

        private void Aceptar()
        {
            if (dtgSubConceptos.Rows.Count > 0)
            {
                pidSubConcepto = Convert.ToInt32(dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["idProyecto"].Value.ToString());
                pcSubConcpeto = dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["cProyecto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Proyecto", "Busqueda Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Dispose();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            CargarConceptos();            

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            pidSubConcepto = 0;
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            pidSubConcepto = 0;
            pcSubConcpeto = "";
            this.Close();

        }
        
    }
}
