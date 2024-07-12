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
using GEN.CapaNegocio;
using ADM.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoOperaciones : frmBase
    {
        DataTable tbOperaciones;
        String TipOpe = "N";
        int idOperac;

        public frmMantenimientoOperaciones()
        {
            InitializeComponent();
        }

        private void MantenimientoOperaciones_Load(object sender, EventArgs e)
        {
            CargarOperaciones(0);
            cboModulo1.SelectedIndex = -1;
            Limpiar();
            HabilitarControles(false);
            btnCancelar1.Enabled = false;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            TipOpe = "EA";//Editar una Operacion Antigua
            HabilitarControles(true);
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (TipOpe == "N")
            {//ESTADO NORMAL
                Limpiar();
                tbOperaciones.Rows.Clear();
                HabilitarControles(false);
                btnNuevo1.Enabled = false;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                cboModulo1.SelectedIndex = -1;
            }

            if (TipOpe == "EA" || TipOpe == "EN")//EDITANDO(MODIFICANDO O CREANDO NUEVO)
            {
                Limpiar();
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnGrabar1.Enabled = false;
                if (dtgOperaciones.SelectedRows.Count > 0)
                    btnEditar1.Enabled = true;
                else
                    btnEditar1.Enabled = false;
            }
            TipOpe = "N";

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validaciones() == "ERROR")
            {
                return;
            }
            int idTipoAsiento = 0;
            if (cboTipoAsiento1.Text != "")
                idTipoAsiento = Convert.ToInt32(cboTipoAsiento1.SelectedValue);

            clsCNMantOperaciones Operaciones = new clsCNMantOperaciones();
            if (TipOpe == "EA")//MODIFICAR Operaciones
            {
                Int32 nFila = Convert.ToInt32(dtgOperaciones.SelectedCells[0].RowIndex);

                idOperac = Operaciones.ActualizarOperaciones(Convert.ToInt32(dtgOperaciones.Rows[nFila].Cells["idTipoOperacion"].Value), "E", Convert.ToInt32(cboModulo1.SelectedValue), Convert.ToString(txtNombOper.Text.Trim()),
                                               Convert.ToInt32(CBModalidad.Checked), Convert.ToInt32(CBMoneda.Checked), Convert.ToInt32(CBProducto.Checked),
                                               Convert.ToInt32(CBExtractocta.Checked), Convert.ToString(txtCodigoSBS.Text), idTipoAsiento, Convert.ToInt32(CBVigente.Checked), Convert.ToInt32(txtImpres.Text.Trim()),
                                               Convert.ToBoolean(chcSplaft.Checked),chcImpVoucher.Checked,Convert.ToInt32(txtNumDiasVcto.Text));
                MessageBox.Show("Los datos se Actualizaron Correctamente", "Mantenimiento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            if (TipOpe == "EN")//REG. Operaciones NUEVO
            {
                idOperac = Operaciones.ActualizarOperaciones(0, "N", Convert.ToInt32(cboModulo1.SelectedValue), Convert.ToString(txtNombOper.Text.Trim()),
                                               Convert.ToInt32(CBModalidad.Checked), Convert.ToInt32(CBMoneda.Checked), Convert.ToInt32(CBProducto.Checked),
                                               Convert.ToInt32(CBExtractocta.Checked), Convert.ToString(txtCodigoSBS.Text), idTipoAsiento, Convert.ToInt32(CBVigente.Checked), Convert.ToInt32(txtImpres.Text.Trim()),
                                               Convert.ToBoolean(chcSplaft.Checked),chcImpVoucher.Checked,Convert.ToInt32(txtNumDiasVcto.Text));
                MessageBox.Show("Los datos se Guardaron Correctamente", "Mantenimiento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            CargarOperaciones(Convert.ToInt32(cboModulo1.SelectedValue));
            int n = 0;
            foreach (DataGridViewRow fila in dtgOperaciones.Rows)
            {
                n += 1;
                if (Convert.ToInt32(fila.Cells["idTipoOperacion"].Value) == idOperac)
                {
                    dtgOperaciones.CurrentCell = dtgOperaciones.Rows[n - 1].Cells["cTipoOperacion"];
                    MostrarDatos();
                }
            }


            TipOpe = "N";
            HabilitarControles(false);
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = false;

        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            TipOpe = "EN";//Edicion de una Nueva Operacion
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            Limpiar();
            HabilitarControles(true);
            CBVigente.Checked = true;
            CBVigente.Enabled = false;

        }
        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModulo1.SelectedIndex) >= 0)
            {
                cboTipoAsiento1.CargarTipoAsientos(Convert.ToInt32(cboModulo1.SelectedValue));
                CargarOperaciones(Convert.ToInt32(cboModulo1.SelectedValue));
                btnNuevo1.Enabled = true;
            }
            else
            {
                cboTipoAsiento1.CargarTipoAsientos(0);
                tbOperaciones.Rows.Clear();
                Limpiar();
                btnNuevo1.Enabled = false;
            }
        }
        private void dtgOperaciones_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            if (dtgOperaciones.SelectedRows.Count > 0)
            {
                int FilaSeleccionada = Convert.ToInt32(dtgOperaciones.SelectedCells[2].RowIndex);
                txtNombOper.Text = Convert.ToString(dtgOperaciones.Rows[FilaSeleccionada].Cells["cTipoOperacion"].Value).Trim();
                CBModalidad.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lIndClaModalidad"].Value);
                CBMoneda.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lIndClaMoneda"].Value);
                CBProducto.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lIndClaProducto"].Value);
                CBExtractocta.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lIndExtractoCta"].Value);
                txtCodigoSBS.Text = Convert.ToString(dtgOperaciones.Rows[FilaSeleccionada].Cells["cCodSBS"].Value).Trim();
                cboTipoAsiento1.SelectedValue = Convert.ToInt32(dtgOperaciones.Rows[FilaSeleccionada].Cells["idTipoAsiento"].Value);
                txtImpres.Text = Convert.ToString(dtgOperaciones.Rows[FilaSeleccionada].Cells["nNumIPresionVou"].Value).Trim();
                chcSplaft.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lRegOpeSplaft"].Value);
                CBVigente.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lVigente"].Value);
                chcImpVoucher.Checked = Convert.ToBoolean(dtgOperaciones.Rows[FilaSeleccionada].Cells["lImprimir"].Value);
                txtNumDiasVcto.Text = Convert.ToString(dtgOperaciones.Rows[FilaSeleccionada].Cells["nNumDiasVcto"].Value);

                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnGrabar1.Enabled = false;
            }
        }

        private void CargarOperaciones(int idModulo)
        {

            clsCNMantOperaciones Operaciones = new clsCNMantOperaciones();
            tbOperaciones = Operaciones.Listaroperaciones(idModulo);

            dtgOperaciones.DataSource = tbOperaciones.DefaultView;
            FormatoDtgOperciones();


        }
        private void FormatoDtgOperciones()
        {
            foreach (DataGridViewColumn column in dtgOperaciones.Columns)
            {
                column.Visible = false;
            }

            dtgOperaciones.Columns["cTipoOperacion"].Visible = true;
            dtgOperaciones.Columns["cAsiento"].Visible = true;
            dtgOperaciones.Columns["cVigente"].Visible = true;

            dtgOperaciones.Columns["cTipoOperacion"].FillWeight = 50;
            dtgOperaciones.Columns["cAsiento"].FillWeight = 30;
            dtgOperaciones.Columns["cVigente"].FillWeight = 20;

            dtgOperaciones.Columns["cTipoOperacion"].HeaderText = "Nombre de la Operación";
            dtgOperaciones.Columns["cAsiento"].HeaderText = "Tipo de Asiento";
            dtgOperaciones.Columns["cVigente"].HeaderText = "Vigencia";

            dtgOperaciones.Columns["cTipoOperacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgOperaciones.Columns["cAsiento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOperaciones.Columns["cVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (tbOperaciones.Rows.Count == 0)
            {
                tbOperaciones.Rows.Clear();
                Limpiar();
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = true;
            }

        }
        private string Validaciones()
        {

            if (string.IsNullOrEmpty(txtNombOper.Text.Trim()))
            {
                MessageBox.Show("Ingrese el Nombre de la Operación", "Mantenimiento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombOper.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(txtImpres.Text.Trim()))
            {
                MessageBox.Show("Ingrese la Cantidad de Vouchers a Imprimir", "Mantenimiento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtImpres.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(txtNumDiasVcto.Text.Trim()))
            {
                MessageBox.Show("Ingrese el número de dias de vencimiento de las solicitudes de aprobación.", "Mantenimiento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumDiasVcto.Focus();
                return "ERROR";
            }


            if (TipOpe == "EA")
            {
                int filaSeleccionada = Convert.ToInt32(dtgOperaciones.SelectedCells[2].RowIndex);

                for (int i = 0; i <= (dtgOperaciones.Rows.Count - 1); i++)
                {
                    if (i != filaSeleccionada)
                        if (Convert.ToString(dtgOperaciones.Rows[i].Cells["cTipoOperacion"].Value).Trim() == txtNombOper.Text.Trim())
                        {
                            MessageBox.Show("Ya existe una operación con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombOper.Focus();
                            return "ERROR";
                        }
                }

            }
            if (TipOpe == "EN")
            {
                for (int i = 0; i <= (dtgOperaciones.Rows.Count - 1); i++)
                {
                    if (Convert.ToString(dtgOperaciones.Rows[i].Cells["cTipoOperacion"].Value).Trim() == txtNombOper.Text.Trim())
                    {
                        MessageBox.Show("Ya existe una operación con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombOper.Focus();
                        return "ERROR";
                    }
                }
            }

            return "OK";

        }
        private void Limpiar()
        {
            txtNombOper.Text = "";
            txtNombOper.Text = "";
            CBModalidad.Checked = false;
            CBProducto.Checked = false;
            CBMoneda.Checked = false;
            CBExtractocta.Checked = false;
            chcSplaft.Checked = false;
            txtImpres.Text = "";
            txtCodigoSBS.Text = "";
            cboTipoAsiento1.SelectedIndex = -1;
            chcImpVoucher.Checked = false;
            txtNumDiasVcto.Text = string.Empty;
        }
        private void HabilitarControles(Boolean var)
        {
            txtNombOper.Enabled = var;
            txtNombOper.Enabled = var;
            CBModalidad.Enabled = var;
            CBMoneda.Enabled = var;
            CBProducto.Enabled = var;
            CBExtractocta.Enabled = var;
            chcSplaft.Enabled = var;
            txtCodigoSBS.Enabled = var;
            txtImpres.Enabled = var;
            cboTipoAsiento1.Enabled = var;
            CBVigente.Enabled = var;
            chcImpVoucher.Enabled = var;
            txtNumDiasVcto.Enabled = var;
        }

    }
}
