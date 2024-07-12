using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using ADM.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantTipOperacionBancos : frmBase
    {

        clsCNMotivoOpeBanco ObjMovBancos = new clsCNMotivoOpeBanco();
        String TipOpe = "N";
        int idOpera;
        public frmMantTipOperacionBancos()
        {
            InitializeComponent();
        }

        private void frmMantTipOperacionBancos_Load(object sender, EventArgs e)
        {
            cboTipOperacion.SelectedIndex = -1;
            grbDatos.Enabled = false;
            CargarCbo();
            Limpiar();
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = false;
        }

        private void CargarMotivoBancos(int idMotOpeBanco)
        {
            DataTable dtOperaciones = ObjMovBancos.CNListarOperaciones(idMotOpeBanco);
 
            if (dtgOperaciones.ColumnCount > 0)
            {
                dtgOperaciones.Columns.Remove("cDescripcion");
                dtgOperaciones.Columns.Remove("lVigente");
                dtgOperaciones.Columns.Remove("lAfectaCaja");
            }

            dtgOperaciones.DataSource = dtOperaciones.DefaultView;
            FormatoDtgConceptosRec();
        }

        private void FormatoDtgConceptosRec()
        {
            dtgOperaciones.Columns["idMotOpeBanco"].Visible = false;
            dtgOperaciones.Columns["cDescripcion"].Width = 80;
            dtgOperaciones.Columns["cDescripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOperaciones.Columns["cDescripcion"].HeaderText = "Motivo Operacion";
            dtgOperaciones.Columns["lVigente"].Width = 30;
            dtgOperaciones.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOperaciones.Columns["lVigente"].HeaderText = "Vigencia";
            dtgOperaciones.Columns["lAfectaCaja"].Visible = false;

        }

        private void cboTipOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMotivoBancos(0);

            if (Convert.ToInt32(cboTipOperacion.SelectedIndex) >= 0)
            {
                if (Convert.ToInt32(cboTipOperacion.SelectedIndex) == 0)
                {
                    CargarMotivoBancos(1); //MOVIMIENTO BANCO
                }
                else if (Convert.ToInt32(cboTipOperacion.SelectedIndex) == 1)
                {
                    CargarMotivoBancos(7); //MOVIMIENTO CHEQUE
                }
                else if (Convert.ToInt32(cboTipOperacion.SelectedIndex) == 2)
                {
                    CargarMotivoBancos(9); //TRANSFERENCIAS
                }
            }
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
        }

        private void dtgOperaciones_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            TipOpe = "Nuevo";
            grbDatos.Enabled = true;
            txtMotivoOpe.Text = "";
            chcVigente.Checked = false;
            dtgOperaciones.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            cboTipOperacion.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validaciones() == "ERROR")
            {
                return;
            }

            if (TipOpe == "Editar")//MODIFICAR MOTIVO DE OPERACION
            {
                Int32 nFila = Convert.ToInt32(dtgOperaciones.SelectedCells[0].RowIndex);
                idOpera = ObjMovBancos.CNActualizaOpeBancos(Convert.ToInt32(dtgOperaciones.Rows[nFila].Cells["idMotOpeBanco"].Value), txtMotivoOpe.Text,
                                                            Convert.ToInt32(cboTipOperacion.SelectedValue), Convert.ToInt32(chcVigente.Checked), "E");

                MessageBox.Show("Los datos se Actualizaron Correctamente", "Mantenimiento de Tipo de Operacion Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (TipOpe == "Nuevo")//REGISTRAR NUEVO MOTIVO DE OPERACION
            {
                idOpera = ObjMovBancos.CNActualizaOpeBancos(0, txtMotivoOpe.Text, Convert.ToInt32(cboTipOperacion.SelectedValue), Convert.ToInt32(chcVigente.Checked), "N");
                MessageBox.Show("Los datos se Guardaron Correctamente", "Mantenimiento de Tipo de Operacion Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            CargarMotivoBancos(Convert.ToInt32(cboTipOperacion.SelectedValue));

            int n = 0;
            foreach (DataGridViewRow fila in dtgOperaciones.Rows)
            {
                n += 1;
                if (Convert.ToInt32(fila.Cells["idMotOpeBanco"].Value) == idOpera)
                {
                    dtgOperaciones.CurrentCell = dtgOperaciones.Rows[n - 1].Cells["cDescripcion"];
                    MostrarDatos();
                }
            }


            TipOpe = "N";
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            grbDatos.Enabled = false;
            cboTipOperacion.Enabled = true;
            dtgOperaciones.Enabled = true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            TipOpe = "Editar";
            grbDatos.Enabled = true;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            cboTipOperacion.Enabled = false;
            btnGrabar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            cboTipOperacion.Enabled = true;
            grbDatos.Enabled = false;
            txtMotivoOpe.Text = "";
            chcVigente.Checked = false;
            dtgOperaciones.Enabled = true;
        }

        private void CargarCbo()
        {
            DataTable dtTipMovBancos = ObjMovBancos.CNListarMovBancos();
            cboTipOperacion.DataSource = dtTipMovBancos;
            cboTipOperacion.ValueMember = dtTipMovBancos.Columns["idMotOpeBanco"].ToString();
            cboTipOperacion.DisplayMember = dtTipMovBancos.Columns["cDescripcion"].ToString();
        }

        private void Limpiar()
        {
            txtMotivoOpe.Text = "";
            cboTipOperacion.SelectedIndex = -1;
            chcVigente.Checked = false;
            grbDatos.Enabled = false;
        }

        private string Validaciones()
        {
            if (txtMotivoOpe.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Motivo", "Mantenimiento de Tipo de Operacion Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivoOpe.Focus();
                return "ERROR";
            }

            return "OK";
        }

        private void MostrarDatos()
        {
            if (dtgOperaciones.SelectedRows.Count > 0)
            {
                int FilaSeleccionada = Convert.ToInt32(dtgOperaciones.SelectedCells[2].RowIndex);

                txtMotivoOpe.Text = Convert.ToString(dtgOperaciones.Rows[FilaSeleccionada].Cells["cDescripcion"].Value);
                chcVigente.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lVigente"].Value);
            }
        }
    }
}
