using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantGenProducto : frmBase
    {
        #region Variables
        clsCNProducto Producto = new clsCNProducto();
        DataTable dtListaProducto = new DataTable();
        string cTipTrxProducto = "";
        DateTime dFechaInicio;
        DateTime dFechaFin;
        #endregion

        #region Eventos

        private void frmMantGenProducto_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            cboNivelProducto.SelectedIndex = 0;
            mostrarFechas(false);
            mostrarFuenteCalcMora(false);
            dtpVigenciaInicio.Value = clsVarGlobal.dFecSystem;
            dtpVigenciaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idModulo = (int)cboModulo.SelectedValue;
            int idNivelProd = (int)cboNivelProducto.SelectedValue;
            cboProductoPadre.CargarProductoModNivel(idModulo, idNivelProd - 1);

            CargarListaProductos(idModulo, idNivelProd);
            cboNivelProducto_SelectedIndexChanged(sender, e);

            if (idModulo != 1)
            {
                mostrarFuenteCalcMora(false);
            }
        }

        private void cboNivelProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNivelProducto.SelectedIndex >= 0)
            {
                int idModulo = (int)cboModulo.SelectedValue;
                int idNivelProd = (int)cboNivelProducto.SelectedValue;
                cboProductoPadre.CargarProductoModNivel(idModulo, idNivelProd - 1);

                CargarListaProductos(idModulo, idNivelProd);
                if (cboNivelProducto.SelectedIndex == 3)
                {
                    dtgProducto.Columns["dVigenciaInicio"].Visible = true;
                    dtgProducto.Columns["dVigenciaFin"].Visible = true;
                    dtgProducto.Columns["lConfigurable"].Visible = true;
                }
                else
                {
                    dtgProducto.Columns["dVigenciaInicio"].Visible = false;
                    dtgProducto.Columns["dVigenciaFin"].Visible = false;
                    dtgProducto.Columns["lConfigurable"].Visible = false;
                }
            }
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgProducto_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipOpe = e.RowIndex;

            cboProductoPadre.SelectedValue = (int)dtListaProducto.Rows[iFilaTipOpe]["IdProductoPadre"];
            txtProducto.Text = dtListaProducto.Rows[iFilaTipOpe]["cNomProducto"].ToString();
            txtCodProducto.Text = dtListaProducto.Rows[iFilaTipOpe]["idProducto"].ToString();
            chcVigente.Checked = (bool)dtListaProducto.Rows[iFilaTipOpe]["lVigente"];
            chcConfigurable.Checked = (bool)dtListaProducto.Rows[iFilaTipOpe]["lConfigurable"];
            if (dtListaProducto.Rows[iFilaTipOpe]["dVigenciaInicio"] != DBNull.Value ||
                dtListaProducto.Rows[iFilaTipOpe]["dVigenciaFin"] != DBNull.Value)
            {
                mostrarFechas(true);
                dtpVigenciaInicio.Value = Convert.ToDateTime(dtListaProducto.Rows[iFilaTipOpe]["dVigenciaInicio"]);
                if (dtListaProducto.Rows[iFilaTipOpe]["dVigenciaFin"] == DBNull.Value)
                {
                    dtpVigenciaFin.Visible = false;
                    chcIndeterminado.Checked = true;
                }
                else
                {
                    chcIndeterminado.CheckedChanged -= chcIndeterminado_CheckedChanged;
                    chcIndeterminado.Checked = false;
                    dtpVigenciaFin.Value = Convert.ToDateTime(dtListaProducto.Rows[iFilaTipOpe]["dVigenciaFin"]);
                    chcIndeterminado.CheckedChanged += chcIndeterminado_CheckedChanged;
                }

            }
            else
            {
                mostrarFechas(false);
            }

            cboFuenteCalcMora.SelectedValue = dtListaProducto.Rows[iFilaTipOpe]["idFuenteCalcMora"] == DBNull.Value ?
                                                            0 : Convert.ToInt16(dtListaProducto.Rows[iFilaTipOpe]["idFuenteCalcMora"]);
            mostrarFuenteCalcMora(Convert.ToInt16(cboNivelProducto.SelectedValue) == 4 && (int)cboModulo.SelectedValue == 1);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cTipTrxProducto = "N";

            txtProducto.Text = "";
            chcVigente.Checked = true;
            dtpVigenciaInicio.Value = DateTime.Now;
            dtpVigenciaFin.Value = DateTime.Now;
            cboFuenteCalcMora.SelectedIndex = -1;


            HabilitarControles(true);

            chcIndeterminado.Checked = false;

            chcConfigurable.Checked = true;

            chcVigente.Enabled = ((int)cboNivelProducto.SelectedValue != 4);

            int idNivelProd = (int)cboNivelProducto.SelectedValue;
            mostrarFechas(idNivelProd == 4);
            mostrarFuenteCalcMora(idNivelProd == 4 && (int)cboModulo.SelectedValue == 1);

            dtpVigenciaInicio.Value = clsVarGlobal.dFecSystem;
            dtpVigenciaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cTipTrxProducto = "A";
            HabilitarControles(true);
            chcVigente.Enabled = ((int)cboNivelProducto.SelectedValue != 4);
            cboProductoPadre.Enabled = false;
            dFechaInicio = (DateTime)dtpVigenciaInicio.Value;
            dFechaFin = (DateTime)dtpVigenciaFin.Value;
            int idNivelProd = (int)cboNivelProducto.SelectedValue;
            mostrarFechas(idNivelProd == 4);
            mostrarFuenteCalcMora(idNivelProd == 4 && (int)cboModulo.SelectedValue == 1);
            if (chcIndeterminado.Checked)
            {
                dtpVigenciaFin.Visible = false;
            }
        }

        /// <summary>
        /// Se agrego los campos dVigenciaInicio y dVigenciaFin, para el registro y actualizacion de la tabla de SI_FINProducto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                HabilitarControles(false);

                string cProducto = txtProducto.Text;
                int IdProductoPadre = (int)cboProductoPadre.SelectedValue;
                bool lVigente = chcVigente.Checked;
                int idModulo = (int)cboModulo.SelectedValue;
                int idNivelProd = (int)cboNivelProducto.SelectedValue;
                string dVigenciaInicio = dtpVigenciaInicio.Value.ToString();
                string dVigenciaFin = dtpVigenciaFin.Value.ToString();
                int idFuenteCalcMora = cboFuenteCalcMora.SelectedValue == null ? 0 : Convert.ToInt16(cboFuenteCalcMora.SelectedValue);
                bool lConfigurable = chcConfigurable.Checked;

                if ((int)cboNivelProducto.SelectedValue != 4)
                {
                    dVigenciaFin = null;
                    dVigenciaInicio = null;
                }
                if (chcIndeterminado.Checked)
                {
                    dVigenciaFin = null;
                }
                if (idModulo != 1 || (idModulo == 1 && (int)cboNivelProducto.SelectedValue != 4))
                {
                    idFuenteCalcMora = -1;
                }
                if (cTipTrxProducto == "N") //Nuevo
                {
                    DataTable dtInsProducto = Producto.CNInsertarProducto(cProducto, IdProductoPadre, lVigente, idModulo, dVigenciaInicio, dVigenciaFin,
                                                                        lConfigurable, idFuenteCalcMora);
                    MessageBox.Show(dtInsProducto.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cTipTrxProducto == "A")  //Actualizar
                {
                    int iFilaTipOpe = dtgProducto.SelectedCells[0].RowIndex;
                    int idProducto = (int)dtListaProducto.Rows[iFilaTipOpe]["idProducto"];

                    DataTable dtActProducto = Producto.CNActualizarproducto(idProducto, cProducto, lVigente, dVigenciaInicio, dVigenciaFin,
                                                                            lConfigurable, idFuenteCalcMora);
                    MessageBox.Show(dtActProducto.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cTipTrxProducto = "";
                CargarListaProductos(idModulo, idNivelProd);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cTipTrxProducto = "";
            HabilitarControles(false);
            dtgProducto.Focus();
        }

        private void dtpVigenciaInicio_ValueChanged(object sender, EventArgs e)
        {
            checkearVigencia();
        }

        private void dtpVigenciaFin_ValueChanged(object sender, EventArgs e)
        {
            checkearVigencia();
        }

        private void chcIndeterminado_CheckedChanged(object sender, EventArgs e)
        {
            if (chcIndeterminado.Checked)
            {
                dtpVigenciaFin.Visible = false;
                dtpVigenciaFin.Value = dtpVigenciaFin.MaxDate;
            }
            else
            {
                dtpVigenciaFin.Visible = true;
                dtpVigenciaFin.Value = clsVarGlobal.dFecSystem;
            }
        }

        #endregion

        #region Métodos

        public frmMantGenProducto()
        {
            InitializeComponent();
        }

        public void mostrarFechas(bool mostrar)
        {
            dtpVigenciaInicio.Visible = mostrar;
            dtpVigenciaFin.Visible = mostrar;
            lblFechaInicio.Visible = mostrar;
            lblFechaFin.Visible = mostrar;
            chcIndeterminado.Visible = mostrar;
            chcConfigurable.Visible = mostrar;
        }

        private void mostrarFuenteCalcMora(bool lMostrar)
        {
            lblFuenteCalcMora.Visible = lMostrar;
            cboFuenteCalcMora.Visible = lMostrar;
        }

        private void HabilitarControles(bool lHabilitar)
        {
            cboModulo.Enabled = !lHabilitar;
            cboNivelProducto.Enabled = !lHabilitar;
            cboProductoPadre.Enabled = lHabilitar;
            txtProducto.Enabled = lHabilitar;
            chcVigente.Enabled = lHabilitar;
            dtpVigenciaInicio.Enabled = lHabilitar;
            dtpVigenciaFin.Enabled = lHabilitar;
            cboFuenteCalcMora.Enabled = lHabilitar;
            dtgProducto.Enabled = !lHabilitar;
            btnNuevo.Enabled = !lHabilitar;
            btnEditar.Enabled = !lHabilitar;
            btnGrabar.Enabled = lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            chcIndeterminado.Enabled = lHabilitar;
            chcConfigurable.Enabled = lHabilitar;
        }

        private void CargarListaProductos(int idModulo, int idNivelProd)
        {
            dtListaProducto = Producto.ListarProductoModNivel(idModulo, idNivelProd);
            dtgProducto.DataSource = dtListaProducto;

            if (dtListaProducto.Rows.Count <= 0)
            {
                txtProducto.Text = "";
                this.chcVigente.Checked = false;
            }
        }

        public bool validar()
        {
            if ((int)cboNivelProducto.SelectedValue == 4)
            {
                DateTime dInicio = (DateTime)dtpVigenciaInicio.Value;
                DateTime dFin = (DateTime)dtpVigenciaFin.Value;
                if (dInicio < clsVarGlobal.dFecSystem && dFechaInicio != dInicio)
                {
                    MessageBox.Show("La fecha de inicio no puede ser menor a la actual", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpVigenciaInicio.Focus();
                    return false;
                }
                if (dFin < clsVarGlobal.dFecSystem && dFechaFin != dFin)
                {
                    MessageBox.Show("La fecha de fin no puede ser menor a la actual", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpVigenciaInicio.Focus();
                    return false;
                }
                TimeSpan diferencia = dFin - dInicio;
                if (diferencia.Days < 0)
                {
                    MessageBox.Show("Rango de fechas no valida", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpVigenciaInicio.Focus();
                    return false;
                }
            }
            if (Convert.ToInt16(cboModulo.SelectedValue) == 1 &&  (int)cboNivelProducto.SelectedValue == 4
                    && cboFuenteCalcMora.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la fuente para el cálculo de la mora para el producto", "Mantenimiento de productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFuenteCalcMora.Focus();
                return false;
            }

            if (txtProducto.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe Ingresar el nombre del producto", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProducto.Focus();
                return false;
            }
            if (cboProductoPadre.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un producto padre", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProducto.Focus();
                return false;
            }
            return true;
        }

        public void checkearVigencia()
        {
            if (dtpVigenciaInicio.Enabled)
            {
                DateTime dHoy = clsVarGlobal.dFecSystem;
                DateTime dInicio = (DateTime)dtpVigenciaInicio.Value;
                DateTime dFin = (DateTime)dtpVigenciaFin.Value;
                chcVigente.Checked = ((dHoy - dInicio).Days >= 0 && (dFin - dHoy).Days >= 0);
            }
        }

        #endregion

    }
}
