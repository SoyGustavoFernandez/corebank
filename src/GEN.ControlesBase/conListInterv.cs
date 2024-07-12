using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conListInterv : UserControl
    {
        
        
        clsCNDeposito clsDeposito = new clsCNDeposito();

        public conListInterv()
        {
            InitializeComponent();
        }

        public void cargarIntervDep(int idCuenta)
        {
            DataTable dtIntervDep = clsDeposito.CNRetornaIntervDep(idCuenta);
            if (dtIntervDep.Rows.Count > 0)
            {
                dtgIntervinientes.DataSource = dtIntervDep;
                //Formtado DataGridView
                this.dtgIntervinientes.Columns["cDireccion"].Visible = false;
                this.dtgIntervinientes.Columns["cDocumentoID"].Visible = false;
                this.dtgIntervinientes.Columns["cTipoIntervencion"].Visible = false;

                this.dtgIntervinientes.Columns["idCli"].HeaderText = "Cod.Cli";
                this.dtgIntervinientes.Columns["cNombre"].HeaderText = "Cliente";

                this.txtNumDoc.Text = dtgIntervinientes.Rows[0].Cells["cDocumentoID"].Value.ToString();
                this.txtTipInterv.Text = dtgIntervinientes.Rows[0].Cells["cTipoIntervencion"].Value.ToString();
                this.txtDireccion.Text = dtgIntervinientes.Rows[0].Cells["cDireccion"].Value.ToString();
            }
            else
            {
                MessageBox.Show("No se Encontro Clientes Vinculados a la Cuenta", "Abono a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }

        private void dtgIntervinientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtNumDoc.Text = dtgIntervinientes.CurrentRow.Cells["cDocumentoID"].Value.ToString();
            this.txtTipInterv.Text = dtgIntervinientes.CurrentRow.Cells["cTipoIntervencion"].Value.ToString();
            this.txtDireccion.Text = dtgIntervinientes.CurrentRow.Cells["cDireccion"].Value.ToString();
            
        }
    }
}
