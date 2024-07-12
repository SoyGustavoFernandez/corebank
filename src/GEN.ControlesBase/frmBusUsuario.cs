using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmBusUsuario : frmBase
    {
        clsCNConfiguracionLimiteAprobacionExcepcion clsCNConfigLimiteAprobacionExcepcion = new clsCNConfiguracionLimiteAprobacionExcepcion();
        public int idUsuario=0;
        public clsUsuComite objUsu = null;
        private bool lBloqueaConsultaNombre = false;
        public frmBusUsuario()
        {
            InitializeComponent();
            this.cboCriBusCli.Focus();
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            lBloqueaConsultaNombre = false;
            BuscarUsuario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void BuscarUsuario()
        {
            int idCriteriobusqueda;
            string cValorIngresado;
            idCriteriobusqueda = Convert.ToInt32(cboCriBusCli.SelectedValue);
            cValorIngresado = txtDniNom.Text.Trim();

            if (cboCriBusCli.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el criterio de búsqueda", "Busqueda de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCli.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(cValorIngresado))
            {
                MessageBox.Show("Debe ingresar los datos a buscar", "Busqueda de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            DataTable dtUsuarioConsulta = clsCNConfigLimiteAprobacionExcepcion.CNObtenerUsuario(idCriteriobusqueda, cValorIngresado);

            dtgUsuario.Columns.Clear();

            dtgUsuario.DataSource = dtUsuarioConsulta;
            formatoGridUsuario();

            if (dtUsuarioConsulta.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos con el criterio de busqueda", "Busqueda de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
        }

        

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BuscarUsuario();            
        }

        private void dtgUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Aceptar();
                
        }
        private void Aceptar() {

            if (dtgUsuario.SelectedRows.Count > 0)
            {
                idUsuario = Convert.ToInt32(dtgUsuario.CurrentRow.Cells["idUsuario"].Value.ToString());
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Debe seleccionar a un colaborador.", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
        }

        private void frmBusUsuario_Load(object sender, EventArgs e)
        {
            lblCriterioBusqueda.Text = "Ape. y Nombres:";
            this.cboCriBusCli.cargaDatos(lBloqueaConsultaNombre);
            this.cboCriBusCli.SelectedValue = 1;
            txtDniNom.Focus();
            txtDniNom.Select();
        }

        private void cboCriBusCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCriterioBusqueda;
            idCriterioBusqueda = Convert.ToInt32(cboCriBusCli.SelectedValue);
            if (idCriterioBusqueda == 1)
            {
                lblCriterioBusqueda.Text = "DNI:";
            }
            else if (idCriterioBusqueda == 2)
            {
                lblCriterioBusqueda.Text = "Ape. y Nombres:";
            }
            txtDniNom.Text = String.Empty;
            txtDniNom.Focus();
        }
        private void formatoGridUsuario()
        {
            foreach (DataGridViewColumn column in dtgUsuario.Columns)
            {
                column.Visible = false;
            }

            dtgUsuario.Columns["idUsuario"].Visible = true;               
            dtgUsuario.Columns["cWinUser"].Visible = true;
            dtgUsuario.Columns["cNombre"].Visible = true;

            dtgUsuario.Columns["idUsuario"].HeaderText = "Cod. Usuario";            
            dtgUsuario.Columns["cWinUser"].HeaderText = "Usuario";
            dtgUsuario.Columns["cNombre"].HeaderText = "Apellidos y Nombres";

            dtgUsuario.Columns["idUsuario"].DisplayIndex = 0;
            dtgUsuario.Columns["cWinUser"].DisplayIndex = 1;
            dtgUsuario.Columns["cNombre"].DisplayIndex = 2;

            dtgUsuario.Columns["idUsuario"].Width= 50;
            dtgUsuario.Columns["cWinUser"].Width = 100;
            dtgUsuario.Columns["cNombre"].Width = 300;
            dtgUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgUsuario.MultiSelect = false;

            lblCriterioBusqueda.Text = "Ape. y Nombres:";
            dtgUsuario.ClearSelection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
