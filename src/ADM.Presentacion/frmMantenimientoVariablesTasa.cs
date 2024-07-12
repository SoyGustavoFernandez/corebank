using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.ControlesBase;
using ADM.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoVariablesTasa : frmBase
    {
        clsCNMantenimiento AdministraVariable = new clsCNMantenimiento();
        private int pidVariable=-1;
        private bool plVigente, lEdicion = false;
        private string cNomVariable, cTipoDato;

        public frmMantenimientoVariablesTasa()
        {
            InitializeComponent();
            listarAgenciasActivasVariable(0);
            habilitarBotones(false);
        }

        private void frmMantenimientoVariables_Load(object sender, EventArgs e)
        {
            cboAgenciav.SelectedIndexChanged -= new EventHandler(cboAgenciav_SelectedIndexChanged);
            listaVariables(0);
            cboAgenciav.SelectedIndexChanged += new EventHandler(cboAgenciav_SelectedIndexChanged); 
            habilitarObjetos(0);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            habilitarObjetos(2);
            plVigente = true;
            lEdicion = true;
            aplicaCellFormatting();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            habilitarObjetos(0);
            establecerDatosVariable();
            lEdicion = false;
            aplicaCellFormatting();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {
                string cVariable = cNomVariable;
                string cDescripcion = txtDescripcion.Text;
                string cTipoVariable = cTipoDato;
                string cValVar = txtValorVariable.Text;
                int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
                bool lCargaVarApl = false;

                AdministraVariable.CNGrabarVariablesCredito(pidVariable, cVariable, cDescripcion,
                   cTipoVariable, cValVar, plVigente, idAgencia, lCargaVarApl, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);
                MessageBox.Show("Se registró correctamente la variable.", "Registro de Variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarAgenciasActivasVariable(0);
                listaVariables(Convert.ToInt32(cboAgenciav.SelectedValue));
                btnCancelar_Click(sender, e);
                lEdicion = false;
                aplicaCellFormatting();
            }
        }
        private void dtgVariables_SelectionChanged(object sender, EventArgs e)
        {
            establecerDatosVariable();
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
                    cboAgenciav.Enabled = true;                    
                    cboAgencia1.Enabled = true;
                    txtDescripcion.ReadOnly = false;
                    txtValorVariable.ReadOnly = false;
                    cboAgenciav.Enabled = false;
                    break;
                case 2://editar
                    cboAgenciav.Enabled = true;                    
                    cboAgencia1.Enabled = true;                    
                    txtDescripcion.ReadOnly = false;
                    txtValorVariable.ReadOnly = false;
                    cboAgenciav.Enabled = false;
                    cboAgencia1.Enabled = false;
                    dtgVariables.Enabled = false;
                    break;
                case 0://x defecto
                    cboAgenciav.Enabled = true;
                    cboAgencia1.Enabled = false;
                    txtDescripcion.ReadOnly = true;
                    txtValorVariable.ReadOnly = true;
                    dtgVariables.Enabled = true;
                    break;
	            }  
        }

        void habilitarBotones(bool lactivo)
        {
            btnEditar.Enabled = !lactivo;
            btnGrabar.Enabled = lactivo;
            btnCancelar.Enabled = lactivo;
        }

        void establecerDatosVariable()
        {
            if (dtgVariables.RowCount > 0)
            {
                cboAgencia1.SelectedValue = Convert.ToInt32(dtgVariables.CurrentRow.Cells["idAgencia"].Value);
                cNomVariable = dtgVariables.CurrentRow.Cells["cVariable"].Value.ToString();
                txtDescripcion.Text = dtgVariables.CurrentRow.Cells["cDescripcion"].Value.ToString();
                txtValorVariable.Text = dtgVariables.CurrentRow.Cells["cValVar"].Value.ToString();
                cTipoDato = dtgVariables.CurrentRow.Cells["cTipoVariable"].Value.ToString();
                pidVariable = Convert.ToInt32(dtgVariables.CurrentRow.Cells["idVariable"].Value.ToString());
                txtItem.Text = dtgVariables.CurrentRow.Cells["Item"].Value.ToString();
            }   

        }
        void formatoDatosVariables() 
        {
            dtgVariables.Columns["Item"].HeaderText = "ítem";
            dtgVariables.Columns["cDescripcion"].HeaderText = "Descripción";
        }
        void listaVariables(int idAgencia)
        {
            dtgVariables.DataSource = AdministraVariable.CNListarVariablesTasa(idAgencia);
            establecerDatosVariable();
            formatoDatosVariables();
        }

        private void listarAgenciasActivasVariable(int nItemvalue)
        {
            DataTable dtResultado = AdministraVariable.CNListarAgenciaVariablesCredito();
            cboAgenciav.DataSource = dtResultado;
            cboAgenciav.ValueMember = dtResultado.Columns[0].ToString();
            cboAgenciav.DisplayMember = dtResultado.Columns[1].ToString();
            cboAgenciav.SelectedValue = nItemvalue;
        }

        private void cboAgenciav_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nidAge;
            bool isNumeric = int.TryParse(cboAgenciav.SelectedValue.ToString(), out nidAge);
            if (isNumeric == true) 
            { 
                listaVariables(nidAge);
            }            
        }

        private bool validarRegistro()
        {
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

        private void aplicaCellFormatting()
        {
            if (lEdicion == true)
            {
                foreach (DataGridViewRow row in dtgVariables.Rows)
                {
                    int valorColumnaA = Convert.ToInt32(row.Cells[0].Value);

                    if (valorColumnaA == Convert.ToInt32(txtItem.Text))
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Silver;
                    }
                }
            }
            else 
            {
                foreach (DataGridViewRow row in dtgVariables.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
