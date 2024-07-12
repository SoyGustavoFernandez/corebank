using CRE.CapaNegocio;
using DEP.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmMantMotExoITF : frmBase
    {
        clsCNMotivoExtorno con = new clsCNMotivoExtorno();
        int idMotExoITF = 0;
        string cMotExoneracionITF = "";
        string cDetMotExoneraITF = "";
        public frmMantMotExoITF()
        {
            InitializeComponent();
        }

        private void frmMantMotExoITF_Load(object sender, EventArgs e)
        {
            DataTable dtMotExoITF = con.ListaMotivioExtrono(3);
            dtgMotExo.DataSource = dtMotExoITF;
            dtgMotExo.Columns["IdMotivoExt"].Visible = false;
            dtgMotExo.Columns["cMotivoExt"].HeaderText = "Motivo";
            dtgMotExo.Columns["cDetalleMotivo"].Visible = false;
            
            txtMotExoneracion.ReadOnly = true;
            txtDetalleMotivo.ReadOnly = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar1.Enabled = false;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idMotExoITF = 0;
            txtMotExoneracion.ReadOnly = false;
            txtDetalleMotivo.ReadOnly = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar1.Enabled = true;
            txtMotExoneracion.Clear();
            txtDetalleMotivo.Clear();
            txtMotExoneracion.Focus();
            dtgMotExo.Enabled = false;
            btnEliminar1.Enabled=false;
        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgMotExo.Rows.Count <= 0)
            {
                return;
            }
            habilitarBotones(false);
            txtMotExoneracion.Focus();
            dtgMotExo.Enabled = false;
            btnEliminar1.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtgMotExo.Enabled = true;
            habilitarBotones(true);
            txtMotExoneracion.Clear();
            txtDetalleMotivo.Clear();          
            int index = dtgMotExo.SelectedCells[0].RowIndex;
            cargarDatos(index);
            btnEliminar1.Enabled = true;
            
            //dtgMotExo.Rows[dtgMotExo.CurrentRow.Index].Selected = true;
            
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (txtMotExoneracion.Text.Trim().Equals(""))
            {
                return;
            }
            cMotExoneracionITF = txtMotExoneracion.Text;
            cDetMotExoneraITF = txtDetalleMotivo.Text;
            DataTable dtMotExoItf = con.GrabarMotivoExoITF(idMotExoITF, cMotExoneracionITF, cDetMotExoneraITF, true);
            if (dtMotExoItf.Rows[0]["nResp"].ToString().Equals("0"))
            {
                MessageBox.Show("Error al registrar el motivo de exoneración de ITF", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Se registro correctamente el motivo", "Grabar Motivo de exoneración ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dtMotExoITF = con.ListaMotivioExtrono(3);
                dtgMotExo.DataSource = dtMotExoITF;
                dtgMotExo.Columns["IdMotivoExt"].Visible = false;
                dtgMotExo.Columns["cMotivoExt"].HeaderText = "Motivo";

                habilitarBotones(true);
                dtgMotExo.Enabled = true;
                btnEliminar1.Enabled = true;
            }
        }
        private void habilitarBotones(bool lactiva)
        {
            txtMotExoneracion.ReadOnly = lactiva;
            txtDetalleMotivo.ReadOnly = lactiva;
            btnNuevo.Enabled = lactiva;
            btnEditar.Enabled = lactiva;
            btnCancelar.Enabled = !lactiva;
            btnGrabar1.Enabled = !lactiva;
        }
        private void dtgMotExo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            cargarDatos(row);
        }
        public void cargarDatos(int row)
        {
            if (dtgMotExo.Rows.Count > 0)
            {
                idMotExoITF = Convert.ToInt32(dtgMotExo.Rows[row].Cells["IdMotivoExt"].Value);
                cMotExoneracionITF = dtgMotExo.Rows[row].Cells["cMotivoExt"].Value.ToString();
                cDetMotExoneraITF = dtgMotExo.Rows[row].Cells["cDetalleMotivo"].Value.ToString();
                txtDetalleMotivo.Text = cDetMotExoneraITF;
                txtMotExoneracion.Text = cMotExoneracionITF;
            }

        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el motivo de exoneración de ITF", "Eliminar motivo de exoneración ITF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dtMotExoItf = con.GrabarMotivoExoITF(idMotExoITF, "", "", false);
                if (dtMotExoItf.Rows[0]["nResp"].ToString().Equals("0"))
                {
                    MessageBox.Show("Error al eliminar el motivo de exoneración de ITF", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Se eliminó correctamente el motivo de exoneración de ITF", "Eliminar motivo de exoneración ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dtMotExoITF = con.ListaMotivioExtrono(3);

                    dtgMotExo.DataSource = dtMotExoITF;
                    dtgMotExo.Columns["IdMotivoExt"].Visible = false;
                    dtgMotExo.Columns["cMotivoExt"].HeaderText = "Motivo";

                    habilitarBotones(true);

                }
            }

        }
   }
}
