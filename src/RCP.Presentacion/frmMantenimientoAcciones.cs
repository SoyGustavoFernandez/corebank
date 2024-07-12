using GEN.CapaNegocio;
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

namespace RCP.Presentacion
{
    public partial class frmMantenimientoAcciones : frmBase
    {
        clsCNAccion cnAccion = new clsCNAccion();
        DataTable dtAcciones = new DataTable();
        int idSeleccionado = -1;
        public frmMantenimientoAcciones()
        {
            InitializeComponent();
        }

        private void cboListaPerfil1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboListaPerfil1.SelectedIndex >= 0)
            {
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                dtAcciones = cnAccion.ListarAccionesPorPerfil(Convert.ToInt32(cboListaPerfil1.SelectedValue));
                btnEditar1.Enabled = (dtAcciones.Rows.Count > 0);
                if (dtAcciones.Rows.Count <= 0)
                {
                    limpiar();
                }
                dtgAcciones.DataSource = dtAcciones;
                formatearGrillAcciones();
            }
            

        }

        private void activarControles(int idEstado)
        {
            switch (idEstado)
            {
                case 1://lectura
                    cboListaPerfil1.Enabled = true;
                    dtgAcciones.Enabled = true;
                    cboAccion1.Enabled = false;
                    chbVigente.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    break;
                case 2://Nuevo
                    cboListaPerfil1.Enabled = false;
                    dtgAcciones.Enabled = false;
                    cboAccion1.Enabled = true;
                    chbVigente.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
                case 3://Editar
                    cboListaPerfil1.Enabled = false;
                    dtgAcciones.Enabled = false;
                    cboAccion1.Enabled = false;
                    chbVigente.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
            }
        }

        private void formatearGrillAcciones()
        {
            foreach (DataGridViewColumn columna in dtgAcciones.Columns)
            {
                columna.Visible = false;
            }

            dtgAcciones.Columns["cTipoAccion"].Visible = true;
            dtgAcciones.Columns["lVigente"].Visible = true;

            dtgAcciones.Columns["cTipoAccion"].HeaderText = "Tipo Acción";
            dtgAcciones.Columns["lVigente"].HeaderText = "Vigente";

            dtgAcciones.Columns["cTipoAccion"].Width = 150;
            dtgAcciones.Columns["lVigente"].Width = 50;
        }

        private void frmMantenimientoAcciones_Load(object sender, EventArgs e)
        {
            limpiar();
            activarControles(1);
        }

        private void dtgAcciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = e.RowIndex;
                cboAccion1.SelectedValue = dtgAcciones.Rows[e.RowIndex].Cells["idTipoAccion"].Value;
                chbVigente.Checked = Convert.ToBoolean(dtgAcciones.Rows[e.RowIndex].Cells["lVigente"].Value);
                btnEditar1.Enabled = true;
            }
            else
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            cboAccion1.SelectedIndex = -1;
            chbVigente.Checked = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtAcciones = cnAccion.ListarAccionesPorPerfil(Convert.ToInt32(cboListaPerfil1.SelectedValue));
            dtgAcciones.DataSource = dtAcciones;
            formatearGrillAcciones();
            activarControles(1);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            activarControles(2);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            activarControles(3);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = cnAccion.InsUpdTipoAccionPerfil(Convert.ToInt32(cboListaPerfil1.SelectedValue), Convert.ToInt32(cboAccion1.SelectedValue), chbVigente.Checked);
            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("Sus cambios fueron guardados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtAcciones = cnAccion.ListarAccionesPorPerfil(Convert.ToInt32(cboListaPerfil1.SelectedValue));
                dtgAcciones.DataSource = dtAcciones;
                formatearGrillAcciones();
                activarControles(1);
            }
            else
            {
                MessageBox.Show("Error al procesar la solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
            
        }
    }
}
