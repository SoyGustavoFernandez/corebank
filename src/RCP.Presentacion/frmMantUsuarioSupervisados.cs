using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmMantAgenciaSupervisadas : frmBase
    {
        clsCNSupervisor cnSupervisor = new clsCNSupervisor();        

        public frmMantAgenciaSupervisadas()
        {
            InitializeComponent();
        }
        
        private void cargarSupervisados()
        {
            DataTable dtUsuarioSupervisados = cnSupervisor.ListarUsuariosSupervisados(Convert.ToInt32(cboUsuarioSupervisorRec1.SelectedValue));
            dtgAgenciasSupervisados.DataSource = dtUsuarioSupervisados;
            formatearUsuarioSupervisados();
        }

        private void formatearUsuarioSupervisados()
        {
            foreach (DataGridViewColumn columna in dtgAgenciasSupervisados.Columns)
            {
                columna.Visible = false;
            }

            dtgAgenciasSupervisados.Columns["cNombreAge"].Visible = true;
            dtgAgenciasSupervisados.Columns["dFecHorAsigna"].Visible = true;

            dtgAgenciasSupervisados.Columns["cNombreAge"].HeaderText = "Nombre usuario";
            dtgAgenciasSupervisados.Columns["dFecHorAsigna"].HeaderText = "Fecha de inicio";

            dtgAgenciasSupervisados.Columns["cNombreAge"].Width = 130;
            dtgAgenciasSupervisados.Columns["dFecHorAsigna"].Width = 70;
            
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            frmRegistraSupervisado frmRegistraSupervisado = new frmRegistraSupervisado();
            frmRegistraSupervisado.ShowDialog();
            if (frmRegistraSupervisado.lAceptar)
            {
                if (Validar(frmRegistraSupervisado.idAgencia))
                {
                    DataTable dtResultado = cnSupervisor.registrarNuevoSupervisado(Convert.ToInt32(cboUsuarioSupervisorRec1.SelectedValue), frmRegistraSupervisado.idAgencia, clsVarGlobal.PerfilUsu.idUsuario);
                    if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        cargarSupervisados();
                        MessageBox.Show("Agencia agregada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar agencia: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El agencia ya fue agregada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool Validar(int idAgencia)
        {
            if (dtgAgenciasSupervisados.Rows.Count > 0)
            {
                DataTable dtUsuario = (DataTable)dtgAgenciasSupervisados.DataSource;
                foreach (DataRow row in dtUsuario.Rows)
                {
                    if (Convert.ToInt32(row["idAgencia"]) == idAgencia)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void cboUsuarioSupervisorRec1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuarioSupervisorRec1.SelectedIndex >= 0)
            {
                cargarSupervisados();
            }
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            int idSelecionado = dtgAgenciasSupervisados.SelectedRows[0].Index;
            if (idSelecionado >= 0)
            {
                DataTable dtResultado = cnSupervisor.QuitarAgenciaSupervisada(Convert.ToInt32(dtgAgenciasSupervisados.Rows[idSelecionado].Cells["idAgenciaSupervisada"].Value), clsVarGlobal.PerfilUsu.idUsuario);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    cargarSupervisados();
                    MessageBox.Show("Agencia desvinculada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al desvincular agencia: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmMantUsuarioSupervisados_Load(object sender, EventArgs e)
        {
            cboUsuarioSupervisorRec1.SelectedIndex = -1;
        }
    }
}
