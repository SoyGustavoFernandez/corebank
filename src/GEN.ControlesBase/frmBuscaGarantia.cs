using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class frmBuscaGarantia : frmBase
    {
        public clsDetGarantia objGarantiaCli=new clsDetGarantia();

        public frmBuscaGarantia()
        {
            InitializeComponent();
            dtgGarantias.AutoGenerateColumns = false;
            dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtValBusqueda.Focus();
            
        }

        private void cboCriBusGar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusGar.SelectedValue.ToString();
            this.cboCriBusGar.SelectedText.Trim();
            txtValBusqueda.Focus();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            clsCNGarantia objgarantia = new clsCNGarantia();
            int nCriterio = Convert.ToInt32(cboCriBusGar.SelectedValue);
            string cValBusqueda = txtValBusqueda.Text.Trim();

            dtgGarantias.DataSource = objgarantia.buscarGarantiaCli(nCriterio, cValBusqueda);
        }

        private void txtValBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                buscar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
        private void aceptar()
        {
            
            if (this.dtgGarantias.RowCount > 0)
            {
                objGarantiaCli.idCliGarantia = Convert.ToInt32(dtgGarantias.CurrentRow.Cells["idCliGarantia"].Value);
                objGarantiaCli.idGarantia = Convert.ToInt32(dtgGarantias.CurrentRow.Cells["idGarantia"].Value);
                objGarantiaCli.idCli = Convert.ToInt32(dtgGarantias.CurrentRow.Cells["idCli"].Value);
                objGarantiaCli.nMonGravado = Convert.ToDecimal(dtgGarantias.CurrentRow.Cells["nMonGravado"].Value);
                objGarantiaCli.nPorcentaje = Convert.ToDecimal(dtgGarantias.CurrentRow.Cells["nPorcentaje"].Value);
                objGarantiaCli.nMonGarantia = Convert.ToDecimal(dtgGarantias.CurrentRow.Cells["nMonGarantia"].Value);
                objGarantiaCli.nMonSaldoGrav = Convert.ToDecimal(dtgGarantias.CurrentRow.Cells["nMonSaldoGrav"].Value);
                
            }
            else
            {
                objGarantiaCli = null;                
            }

            this.Close();
        }

        private void txtValBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
