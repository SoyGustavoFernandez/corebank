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

namespace CAJ.Presentacion
{
    public partial class frmBuscarConceptoComprPago : frmBase
    {
        private DataTable dtSubConceptos;
        public int pidSubConcepto;
        public string pcSubConcpeto;

        public frmBuscarConceptoComprPago()
        {
            InitializeComponent();
        }

        private void frmBuscarConceptoComprPago_Load(object sender, EventArgs e)
        {
            CargarConceptos(3);            
        }

        private void CargarConceptos(int nVal)
        {
            clsCNControlOpe objConceptos = new clsCNControlOpe();
            DataTable dtConceptos = objConceptos.ListaConceptos(3,txtBusCom.Text);

            dtgSubConceptos.DataSource = dtConceptos;
            FormatoDataGrid();
        }
        private void FormatoDataGrid()
        {
            dtgSubConceptos.Columns["idConcepto"].Visible = true;
            dtgSubConceptos.Columns["cConcepto"].Visible = true;
            dtgSubConceptos.Columns["cTipMonto"].Visible = false;
            dtgSubConceptos.Columns["nMontoCon"].Visible = false;
            dtgSubConceptos.Columns["nAfectoITF"].Visible = false;
            dtgSubConceptos.Columns["idConcepto"].HeaderText = "Codigo";
            dtgSubConceptos.Columns["cConcepto"].HeaderText = "Concepto";
        }

        private void Aceptar()
        {
            if (dtgSubConceptos.Rows.Count > 0)
            {
                pidSubConcepto = Convert.ToInt32(dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["idConcepto"].Value.ToString());
                pcSubConcpeto = dtgSubConceptos.Rows[dtgSubConceptos.CurrentRow.Index].Cells["cConcepto"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un concepto", "Busqueda Sub Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            CargarConceptos(3);            

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            pidSubConcepto = 0;
        }
        
    }
}
