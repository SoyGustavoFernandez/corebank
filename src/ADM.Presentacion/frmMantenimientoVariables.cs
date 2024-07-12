using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using ADM.CapaNegocio;
namespace ADM.Presentacion
{
    public partial class frmMantenimientoVariables : frmBase
    {
        clsCNMantenimiento AdministraVariable = new clsCNMantenimiento();
        private int pidVariable=-1;
        private bool plVigente;
        public frmMantenimientoVariables()
        {
            InitializeComponent();
            habilitarBotones(false);
        }

        private void frmMantenimientoVariables_Load(object sender, EventArgs e)
        {
            cargarTipoDatos();
            cboAgencia.SelectedIndexChanged -= new EventHandler(cboAgencia_SelectedIndexChanged);
            ListaVariables(Convert.ToInt32(cboAgencia.SelectedValue));
            cboAgencia.SelectedIndexChanged += new EventHandler(cboAgencia_SelectedIndexChanged);
            habilitarObjetos(0);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            habilitarObjetos(1);
            limpiarDatos();
            pidVariable = -1;
            plVigente = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            habilitarObjetos(2);
            plVigente = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            habilitarObjetos(0);
            EstablecerDatosVariable();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro())
            {
                string cVariable = txtNomVariable.Text;
                string cDescripcion = txtDescripcion.Text;
                string cTipoVariable = cboTipoDato.SelectedValue.ToString();
                string cValVar = txtValorVariable.Text;
                int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
                bool lCargaVarApl = chcCargaInicio.Checked;

                AdministraVariable.GrabarVariables(pidVariable, cVariable, cDescripcion,
                   cTipoVariable, cValVar, plVigente, idAgencia, lCargaVarApl);
                MessageBox.Show("Se Registro Correctamente la Variable", "Registro de Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaVariables(Convert.ToInt32(cboAgencia.SelectedValue));
                btnCancelar_Click(sender, e);
            }
        }
        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaVariables(Convert.ToInt32(cboAgencia.SelectedValue));
        }
        private void dtgVariables_SelectionChanged(object sender, EventArgs e)
        {
            EstablecerDatosVariable();
        }
        private void dtgVariables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgVariables_SelectionChanged(sender, e);
        }

        void habilitarObjetos(int idOpcion)
        {
            switch (idOpcion)
	            {
                case 1://nuevo
                    cboAgencia.Enabled = true;                    
                    cboAgencia1.Enabled = true;
                    txtNomVariable.ReadOnly = false;
                    txtDescripcion.ReadOnly = false;
                    cboTipoDato.Enabled = true;
                    txtValorVariable.ReadOnly = false;
                    cboAgencia.Enabled = false;
                    chcCargaInicio.Checked = false;
                    chcCargaInicio.Enabled =true;
                    break;
                case 2://editar
                    cboAgencia.Enabled = true;                    
                    cboAgencia1.Enabled = true;                    
                    txtDescripcion.ReadOnly = false;
                    cboTipoDato.Enabled = true;
                    txtValorVariable.ReadOnly = false;
                    cboAgencia.Enabled = false;
                    chcCargaInicio.Enabled = true;
                    break;
                case 0://x defecto
                    cboAgencia.Enabled = true;
                    cboAgencia1.Enabled = false;
                    txtNomVariable.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cboTipoDato.Enabled = false;
                    txtValorVariable.ReadOnly = true;
                    chcCargaInicio.Enabled = false;
                    break;
	            }  
        }

        void habilitarBotones(bool lactivo)
        {
            btnEditar.Enabled = !lactivo;
            btnNuevo.Enabled  = !lactivo;
            btnGrabar.Enabled = lactivo;
            btnCancelar.Enabled = lactivo;
            btnEliminar.Enabled = !lactivo; 
        }
        void cargarTipoDatos()
        {
           cboTipoDato.DataSource = AdministraVariable.ListarTipodeDatos();
           cboTipoDato.ValueMember = "cNombre";
           cboTipoDato.DisplayMember = "cNombre";
        }
        void EstablecerDatosVariable()
        {
            if (dtgVariables.RowCount > 0)
            {
                cboAgencia1.SelectedValue = Convert.ToInt32(dtgVariables.CurrentRow.Cells["idAgencia"].Value);
                txtNomVariable.Text = dtgVariables.CurrentRow.Cells["cVariable"].Value.ToString();
                txtDescripcion.Text = dtgVariables.CurrentRow.Cells["cDescripcion"].Value.ToString();
                txtValorVariable.Text = dtgVariables.CurrentRow.Cells["cValVar"].Value.ToString();
                cboTipoDato.SelectedValue = dtgVariables.CurrentRow.Cells["cTipoVariable"].Value.ToString();
                chcCargaInicio.Checked = Convert.ToBoolean(dtgVariables.CurrentRow.Cells["lCargaVarApl"].Value);
                pidVariable = Convert.ToInt32(dtgVariables.CurrentRow.Cells["idVariable"].Value.ToString());
               // plVigente = Convert.ToBoolean(dtgVariables.CurrentRow.Cells["lVigente"].Value.ToString());
            }   

        }
        void ListaVariables(int idAgencia)
        {
            dtgVariables.DataSource = AdministraVariable.ListarVariables(idAgencia);
            EstablecerDatosVariable();
        }
        void limpiarDatos()
        {

            txtNomVariable.Clear();
            txtDescripcion.Clear();
            txtValorVariable.Clear();
            
        }
        private bool ValidarRegistro()
        {
            if(txtNomVariable.Text.Trim().Length<3)
            {
                MessageBox.Show("Debe Ingresar Nombre de la Variable", "Registro de Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDescripcion.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Descripción de la Variable", "Registro de Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtValorVariable.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe Ingresar Valor de la Variable", "Registro de Variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            return true;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("¿Esta Seguro de Eliminar la Variable?", "Eliminación de Variable", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes){
            string cVariable = txtNomVariable.Text;
            string cDescripcion = txtDescripcion.Text;
            string cTipoVariable = cboTipoDato.SelectedValue.ToString();
            string cValVar = txtValorVariable.Text;
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            bool lCargaVarApl = chcCargaInicio.Checked;
            plVigente = false;
            AdministraVariable.GrabarVariables(pidVariable, cVariable, cDescripcion,
               cTipoVariable, cValVar, plVigente, idAgencia, lCargaVarApl);
            MessageBox.Show("Se Eliminó Correctamente la Variable", "Eliminación de Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListaVariables(Convert.ToInt32(cboAgencia.SelectedValue));

            }
        }

          
    }
}
