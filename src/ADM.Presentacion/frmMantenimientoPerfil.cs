using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using ADM.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoPerfil : frmBase
    {
        clsCNMantenimiento AdministraPerfil = new clsCNMantenimiento();
        private int pIdPerfil;
        public frmMantenimientoPerfil()
        {
            InitializeComponent();
            habilitarBotones(false);
        }

        private void frmMantenimientoPerfil_Load(object sender, EventArgs e)
        {
            ListaPerfiles();            
            habilitarBotones(false);
            txtNomPerfil.ReadOnly = true;
            txtDescriPerfil.ReadOnly = true;
            chcManejoLimiteCobert.Enabled = false;
        }
        void ListaPerfiles(){
            dtgPerfiles.DataSource = AdministraPerfil.ListarPerfiles();
            AsignarValor();
        }
        void AsignarValor()
        {
            if (dtgPerfiles.RowCount > 0)
            {
                txtNomPerfil.Text = dtgPerfiles.CurrentRow.Cells["cPerfil"].Value.ToString();
                txtDescriPerfil.Text = dtgPerfiles.CurrentRow.Cells["cDescripcion"].Value.ToString();
                chcManejoLimiteCobert.Checked = Convert.ToBoolean(dtgPerfiles.CurrentRow.Cells["lLimCobertura"].Value.ToString());
                pIdPerfil = Convert.ToInt32(dtgPerfiles.CurrentRow.Cells["idPerfil"].Value.ToString());
            }
        }
        void habilitarBotones(bool lactivo)
        {
            btnEditar.Enabled = !lactivo;
            btnNuevo.Enabled = !lactivo;
            btnGrabar.Enabled = lactivo;
            btnCancelar.Enabled = lactivo;
            btnEliminar.Enabled = !lactivo;
        }
        private bool ValidarRegistro()
        {
            if (txtNomPerfil.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Nombre del Perfil", "Registro de Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDescriPerfil.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe Ingresar Descripción del Perfil", "Registro de Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            return true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pIdPerfil = -1;
            habilitarBotones(true);
            txtNomPerfil.ReadOnly = false;
            txtDescriPerfil.ReadOnly = false;
            chcManejoLimiteCobert.Enabled = true;
            chcManejoLimiteCobert.Checked = false;
            txtNomPerfil.Clear();
            txtDescriPerfil.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);            
            txtDescriPerfil.ReadOnly = false;
            chcManejoLimiteCobert.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            txtNomPerfil.ReadOnly = true;
            txtDescriPerfil.ReadOnly = true;
            chcManejoLimiteCobert.Enabled = false;
            AsignarValor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de Eliminar el Perfil?", "Eliminación de Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string cPerfil = txtNomPerfil.Text;
                string cDescripcion = txtDescriPerfil.Text;
                bool lVigente = false;
                bool lLimCobertura = chcManejoLimiteCobert.Checked;
             
                AdministraPerfil.GrabarPerfiles(pIdPerfil, cPerfil, cDescripcion, lVigente, lLimCobertura);

                MessageBox.Show("Se Eliminó Correctamente el Perfil", "Eliminación de Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarBotones(false);
                txtNomPerfil.ReadOnly = true;
                txtDescriPerfil.ReadOnly = true;
                chcManejoLimiteCobert.Enabled = false;
                ListaPerfiles();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            

            if (ValidarRegistro())
            { 
                string cPerfil=txtNomPerfil.Text; 
                string cDescripcion=txtDescriPerfil.Text;
                bool lVigente=true; 
                bool lLimCobertura=chcManejoLimiteCobert.Checked;

                AdministraPerfil.GrabarPerfiles(pIdPerfil, cPerfil, cDescripcion, lVigente,lLimCobertura);

                MessageBox.Show("Se Registro Correctamente el Perfil", "Registro de Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarBotones(false);
                txtNomPerfil.ReadOnly = true;
                txtDescriPerfil.ReadOnly = true;
                chcManejoLimiteCobert.Enabled = false;
                ListaPerfiles();
            }
        }

        private void dtgPerfiles_SelectionChanged(object sender, EventArgs e)
        {
            AsignarValor();
        }

        private void dtgPerfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgPerfiles_SelectionChanged(sender, e);
        }

      
    }
}
