using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADM.CapaNegocio;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace ADM.Presentacion
{
    public partial class frmVinculaConCtbProducto : frmBase
    {
        clsCNMantenimiento objMantenimiento = new clsCNMantenimiento();
        clsCNCondicionContable objCondicionContable = new clsCNCondicionContable();

        DataTable dtCondicionCtb = new DataTable();

        string cTipoTrx = "";

        public frmVinculaConCtbProducto()
        {
            InitializeComponent();
        }

        private void frmVinculaConCtbProducto_Load(object sender, EventArgs e)
        {
            if (cboModulo.Items.Count > 0)
            {
                cboModulo.SelectedIndex = 0;
                cboModulo_SelectedIndexChanged(sender, e);
            }

            HabilitarControles(false);
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idModulo = (int)cboModulo.SelectedValue;
            cboTipoProducto.SelectedIndexChanged -= new EventHandler(cboTipoProducto_SelectedIndexChanged);
            cboTipoProducto.CargarProductoModNivel(idModulo, 1);
            cboTipoProducto.SelectedIndexChanged += new EventHandler(cboTipoProducto_SelectedIndexChanged);
            if (cboTipoProducto.Items.Count > 0)
            {
                cboTipoProducto.SelectedIndex = -1;
                cboTipoProducto.SelectedIndex = 0;
            }
            else
            {
                cboSubTipoProducto.DataSource = null;
                cboProducto.DataSource = null;
                cboSubProducto.DataSource = null;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                dtCondicionCtb.Clear();
            }
        }

        private void cboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProducto.SelectedIndex == -1)
            {
                return;
            }

            if (cboTipoProducto.Items.Count > 1 && string.IsNullOrEmpty(cboTipoProducto.Text.Trim())) cboTipoProducto.SelectedIndex = cboTipoProducto.SelectedIndex + 1;
            int idTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);
            cboSubTipoProducto.SelectedIndexChanged -= new EventHandler(cboSubTipoProducto_SelectedIndexChanged);
            cboSubTipoProducto.CargarProducto(idTipoProducto);
            cboSubTipoProducto.SelectedIndexChanged += new EventHandler(cboSubTipoProducto_SelectedIndexChanged);
            if (cboSubTipoProducto.Items.Count > 0)
            {
                cboSubTipoProducto.SelectedIndex = -1;
                cboSubTipoProducto.SelectedIndex = 0;
            }
            else
            {
                cboProducto.DataSource = null;
                cboSubProducto.DataSource = null;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                dtCondicionCtb.Clear();
            }
        }

        private void cboSubTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoProducto.SelectedIndex == -1)
            {
                return;
            }

            if (cboSubTipoProducto.Items.Count > 1 && string.IsNullOrEmpty(cboSubTipoProducto.Text.Trim())) cboSubTipoProducto.SelectedIndex = cboSubTipoProducto.SelectedIndex + 1;
            int idSubTipoProducto = (int)cboSubTipoProducto.SelectedValue;
            cboProducto.SelectedIndexChanged -= new EventHandler(cboProducto_SelectedIndexChanged);
            cboProducto.CargarProducto(idSubTipoProducto);
            cboProducto.SelectedIndexChanged += new EventHandler(cboProducto_SelectedIndexChanged);
            if (cboProducto.Items.Count > 0)
            {
                cboProducto.SelectedIndex = -1;
                cboProducto.SelectedIndex = 0;
            }
            else
            {
                cboSubProducto.DataSource = null;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                dtCondicionCtb.Clear();
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
            {
                return;
            }

            if (cboProducto.Items.Count > 1 && string.IsNullOrEmpty(cboProducto.Text.Trim())) cboProducto.SelectedIndex = cboProducto.SelectedIndex + 1;
            int idProducto = (int)cboProducto.SelectedValue;
            cboSubProducto.SelectedIndexChanged -= new EventHandler(cboSubProducto_SelectedIndexChanged);
            cboSubProducto.CargarProducto((idProducto == 0 ? 999 : idProducto));
            cboSubProducto.SelectedIndexChanged += new EventHandler(cboSubProducto_SelectedIndexChanged);
            if (cboSubProducto.Items.Count > 0)
            {
                cboSubProducto.SelectedIndex = -1;
                cboSubProducto.SelectedIndex = 0;
                btnNuevo.Enabled = true;
            }
            else
            {
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                dtCondicionCtb.Clear();
            }
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubProducto.SelectedIndex == -1)
            {
                return;
            }

            int idSubProducto;
            if ((int)cboModulo.SelectedValue == 3)
            {
                if (cboSubTipoProducto.SelectedValue.ToString().Equals("System.Data.DataRowView"))
                {
                    idSubProducto = 0;
                }
                else
                {
                    idSubProducto = (int)cboSubTipoProducto.SelectedValue;
                }
            }
            else
            {
                if (cboSubProducto.Items.Count > 1 && string.IsNullOrEmpty(cboSubProducto.Text.Trim())) cboSubProducto.SelectedIndex = cboSubProducto.SelectedIndex + 1;
                idSubProducto = (int)cboSubProducto.SelectedValue;
            }

            CargarLisConCtbProduc(idSubProducto);
            HabilitarControles(false);
        }

        private void dtgCondicionCtb_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaCondicionCtb = e.RowIndex;

            cboCondicionContable.SelectedValue = (int)dtCondicionCtb.Rows[iFilaCondicionCtb]["idCondicionContable"];
            chcVigente.Checked = (bool)dtCondicionCtb.Rows[iFilaCondicionCtb]["lVigente"];
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cTipoTrx = "N";
            chcVigente.Checked = true;
            HabilitarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgCondicionCtb.Rows.Count <= 0)
            {
                return;
            }
            cTipoTrx = "A";
            HabilitarControles(true);
        }
        private bool validar()
        {
            if (Convert.ToInt32(cboModulo.SelectedValue) == 3)
            {
                if (cboSubTipoProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe elegir el sub tipo", "Vinculación de Condición Contable a Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            else
            {
                if (cboSubProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe elegir el sub producto", "Vinculación de Condición Contable a Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            if (cboCondicionContable.SelectedValue == null)
            {
                MessageBox.Show("Debe elegir condición contable", "Vinculación de Condición Contable a Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }

            int idProducto = (int)(Convert.ToInt32(cboModulo.SelectedValue) == 3 ? cboSubTipoProducto.SelectedValue : cboSubProducto.SelectedValue);
            int idCondicionCtb = (int)cboCondicionContable.SelectedValue;
            bool lVigente = chcVigente.Checked;

            if (cTipoTrx == "N")
            {
                DataTable dtInsertarConCtbProduc = objMantenimiento.CNInsertarConCtbProduc(idProducto, idCondicionCtb, lVigente);
                MessageBox.Show(dtInsertarConCtbProduc.Rows[0]["cMensaje"].ToString(), "Vinculación de Condición Contable a Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cTipoTrx == "A")
            {
                int iFilaCondicionCtb = dtgCondicionCtb.SelectedCells[0].RowIndex;
                int idConCtbProduc = (int)dtCondicionCtb.Rows[iFilaCondicionCtb]["idConCtbProduc"];

                DataTable dtActualizarConCtbProduc = objMantenimiento.CNActualizarConCtbProduc(idConCtbProduc, lVigente);
                MessageBox.Show(dtActualizarConCtbProduc.Rows[0]["cMensaje"].ToString(), "Vinculación de Condición Contable a Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cTipoTrx = "";
            CargarLisConCtbProduc(idProducto);
            HabilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cTipoTrx = "";
            HabilitarControles(false);
            dtgCondicionCtb.Focus();
        }

        private void HabilitarControles(bool lHabilitar)
        {
            cboModulo.Enabled = !lHabilitar;
            cboTipoProducto.Enabled = !lHabilitar;
            cboSubTipoProducto.Enabled = !lHabilitar;
            cboProducto.Enabled = !lHabilitar;
            cboSubProducto.Enabled = !lHabilitar;
            
            dtgCondicionCtb.Enabled = !lHabilitar;
            cboCondicionContable.Enabled = lHabilitar;
            chcVigente.Enabled = lHabilitar;

            btnNuevo.Enabled = !lHabilitar;
            if (dtCondicionCtb.Rows.Count > 0)
            {
                btnEditar.Enabled = !lHabilitar;
            }
            else
            {
                btnEditar.Enabled = false;
            }
            btnGrabar.Enabled = lHabilitar;
            btnCancelar.Enabled = lHabilitar;
        }

        private void CargarLisConCtbProduc(int idProducto)
        {
            dtCondicionCtb = objCondicionContable.CNListarConCtbProduc(idProducto);
            dtgCondicionCtb.DataSource = dtCondicionCtb;
        }
    }
}
