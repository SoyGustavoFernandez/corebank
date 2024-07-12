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

namespace ADM.Presentacion
{
    public partial class frmNivelAprobaOperac : frmBase
    {
        clsCNAprobacion objAprobacion = new clsCNAprobacion();
        DataTable dtTipoOpeAproba;
        DataTable dtRangoAprobaOpe;
        DataTable dtNivelAprRangoOpe;
        DataTable dtPerfilNivelAproba;

        private string cTipTrxTipOpe = "";
        private string cTipTrxRanOpe = "";
        private string cTipTrxNivApr = "";
        private string cTipTrxPerfil = "";

        public frmNivelAprobaOperac()
        {
            InitializeComponent();
            cboModulo.SelectedIndexChanged -= cboModulo_SelectedIndexChanged;
            cboModulo.ListarSoloModulos();
            cboModulo.SelectedIndex = -1;
            cboModulo.SelectedIndexChanged += cboModulo_SelectedIndexChanged;
        }

        private void frmNivelAprobaOperac_Load(object sender, EventArgs e)
        {
            if (cboModulo.Items.Count > 0)
            {
                cboModulo.SelectedIndex = 0;
            }
            ActualizarDetalleTitulo();
            HabilitarControlesTipOpe(false);
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex == -1)
            {
                return;
            }

            int idModulo = (int)cboModulo.SelectedValue;
            cboTipoOperacion.SelectedIndexChanged -= new EventHandler(cboTipoOperacion_SelectedIndexChanged);
            cboTipoOperacion.LisTipoOperacModulo(idModulo);
            cboTipoOperacion.SelectedIndexChanged += new EventHandler(cboTipoOperacion_SelectedIndexChanged);
            if (cboTipoOperacion.Items.Count > 0)
            {
                cboTipoOperacion.SelectedIndex = -1;
                cboTipoOperacion.SelectedIndex = 0;
            }
        }

        private void cboTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOperacion.SelectedIndex == -1)
            {
                return;
            }

            int idTipoOperacion = (int)cboTipoOperacion.SelectedValue;
            if ((bool)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["lIndClaMoneda"] == true)
            {
                cboMoneda.CargaDatos();
            }
            else
            {
                cboMoneda.MonedasYNinguno();
            }
            CargarLisTipoOpeAproba(idTipoOperacion);
            HabilitarControlesTipOpe(false);
        }

        #region Panel_Tipo_Operacion

        private void dtgLisTipoOpeAproba_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipOpe = e.RowIndex;

            cboModalidadOperac.SelectedValue = dtTipoOpeAproba.Rows[iFilaTipOpe]["idEstadoOperac"];
            cboMoneda.SelectedValue = dtTipoOpeAproba.Rows[iFilaTipOpe]["idMoneda"];
            chcPorAgencia.Checked = (bool)dtTipoOpeAproba.Rows[iFilaTipOpe]["lporAgencia"];
            chcPorProducto.Checked = (bool)dtTipoOpeAproba.Rows[iFilaTipOpe]["lporProducto"];
            cboNivelProducto.SelectedValue = dtTipoOpeAproba.Rows[iFilaTipOpe]["idNivelProd"];
            chcVigenteTipOpe.Checked = (bool)dtTipoOpeAproba.Rows[iFilaTipOpe]["lVigente"];
        }

        private void chcPorProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cTipTrxTipOpe == "N" || cTipTrxTipOpe == "A")
            {
                cboNivelProducto.Enabled = chcPorProducto.Checked;
                if (cboNivelProducto.Enabled == false)
                {
                    cboNivelProducto.SelectedValue = 1;
                }
            }
            else
            {
                cboNivelProducto.Enabled = false;
            }
        }

        private void btnNuevoTipOpe_Click(object sender, EventArgs e)
        {
            cTipTrxTipOpe = "N";
            HabilitarControlesTipOpe(true);
        }

        private void btnEditarTipOpe_Click(object sender, EventArgs e)
        {
            if (dtgTipoOpeAproba.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxTipOpe = "A";
            HabilitarControlesTipOpe(true);
        }

        private void btnGrabarTipOpe_Click(object sender, EventArgs e)
        {
            int idTipoOperacion = (int)cboTipoOperacion.SelectedValue;
            int idEstadoOperac = (int)cboModalidadOperac.SelectedValue;
            int idMoneda = Convert.ToInt32(Convert.ToString(cboMoneda.SelectedValue) == "" ? "0" : cboMoneda.SelectedValue);
            bool lporAgencia = chcPorAgencia.Checked;
            bool lporProducto = chcPorProducto.Checked;
            int idNivelProd = (int)cboNivelProducto.SelectedValue;
            bool lVigente = chcVigenteTipOpe.Checked;

            if (cTipTrxTipOpe == "N") //Nuevo
            {
                DataTable dtInsTipoOpeAproba = objAprobacion.InsTipoOpeAproba(idTipoOperacion, idEstadoOperac, idMoneda, lporAgencia, lporProducto, idNivelProd, lVigente);
                MessageBox.Show(dtInsTipoOpeAproba.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Tipos de Operación", MessageBoxButtons.OK, ((int)dtInsTipoOpeAproba.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            if (cTipTrxTipOpe == "A")  //Actualizar
            {
                int iFilaTipOpe = dtgTipoOpeAproba.SelectedCells[0].RowIndex;
                int idTipOpeAproba = (int)dtTipoOpeAproba.Rows[iFilaTipOpe]["idTipOpeAproba"];

                DataTable dtActTipoOpeAproba = objAprobacion.ActTipoOpeAproba(idTipOpeAproba, lporAgencia, lporProducto, idNivelProd, lVigente);
                MessageBox.Show(dtActTipoOpeAproba.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Tipos de Operación", MessageBoxButtons.OK, ((int)dtActTipoOpeAproba.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            HabilitarControlesTipOpe(false);
            btnContinuarTipOpe.Enabled = true;
            cTipTrxTipOpe = "";
            CargarLisTipoOpeAproba(idTipoOperacion);
            dtgTipoOpeAproba.Focus();
        }

        private void btnCancelarTipOpe_Click(object sender, EventArgs e)
        {
            cTipTrxTipOpe = "";
            HabilitarControlesTipOpe(false);
            dtgTipoOpeAproba.Focus();
        }

        private void btnContinuarTipOpe_Click(object sender, EventArgs e)
        {
            if (dtgTipoOpeAproba.Rows.Count <= 0)
            {
                return;
            }
            cboModulo.Enabled = false;
            cboTipoOperacion.Enabled = false;

            int iFilaTipOpe = dtgTipoOpeAproba.SelectedCells[0].RowIndex;
            int idTipOpeAproba = (int)dtTipoOpeAproba.Rows[iFilaTipOpe]["idTipOpeAproba"];
            int idModulo = (int)cboModulo.SelectedValue;
            int idNivelProd = (int)dtTipoOpeAproba.Rows[iFilaTipOpe]["idNivelProd"];

            tbcMantenimientoApr.SelectedIndex = 1;
            CargarLisRangoAprobaOpe(idTipOpeAproba);
            if (chcPorProducto.Checked == true)
            {
                cboProducto.CargarProductoModNivel(idModulo, idNivelProd);
                DataTable dtProd = (DataTable)cboProducto.DataSource;
                string cLenghtMax = String.Empty;
                int nLenghtMax = 0;
                foreach (DataRow row in dtProd.Rows)
                {
                    if (Convert.ToString(row["cProducto"]).Length > nLenghtMax)
                    {
                        nLenghtMax = Convert.ToString(row["cProducto"]).Length;
                        cLenghtMax = Convert.ToString(row["cProducto"]);
                    }
                }
                SizeF size = SizeF.Empty;
                using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
                {
                    size = graphics.MeasureString(cLenghtMax, new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point));
                }

                cboProducto.DropDownWidth = size.ToSize().Width;

            }
            else
            {
                cboProducto.CargarProductoModNivelTodos(idModulo, idNivelProd);
                cboProducto.SelectedValue = 0;
            }

            HabilitarControlesRanOpe(false);
            ActualizarDetalleTitulo();
        }

        private void HabilitarControlesTipOpe(bool lHabilitar)
        {
            cboModulo.Enabled = !lHabilitar;
            cboTipoOperacion.Enabled = !lHabilitar;
            dtgTipoOpeAproba.Enabled = !lHabilitar;

            if (cTipTrxTipOpe == "N")
            {
                if ((bool)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["lIndClaMoneda"] == true)
                {
                    cboMoneda.Enabled = lHabilitar;
                }
                else
                {
                    cboMoneda.SelectedValue = -1;
                    cboMoneda.Enabled = false;
                }

                if ((bool)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["lIndClaModalidad"] == true)
                {
                    cboModalidadOperac.Enabled = lHabilitar;
                }
                else
                {
                    cboModalidadOperac.SelectedValue = 1;
                    cboModalidadOperac.Enabled = false;
                }

                chcPorAgencia.Checked = false;
                chcPorProducto.Checked = false;
                chcVigenteTipOpe.Checked = true;
            }
            else
            {
                cboModalidadOperac.Enabled = false;
                cboMoneda.Enabled = false;
            }

            chcPorAgencia.Enabled = lHabilitar;
            if (cboTipoOperacion.dtOperacion.Rows.Count > 0)
            {
                if ((bool)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["lIndClaProducto"])
                {
                    chcPorProducto.Enabled = lHabilitar;
                    cboNivelProducto.Enabled = (chcPorProducto.Checked && cTipTrxTipOpe != "");
                }
                else
                {
                    chcPorProducto.Checked = false;
                    chcPorProducto.Enabled = false;
                    cboNivelProducto.Enabled = false;
                }
            }

            chcVigenteTipOpe.Enabled = lHabilitar;

            btnNuevoTipOpe.Enabled = !lHabilitar;
            btnGrabarTipOpe.Enabled = lHabilitar;
            btnCancelarTipOpe.Enabled = lHabilitar;

            if (dtgTipoOpeAproba.RowCount > 0)
            {
                btnEditarTipOpe.Enabled = !lHabilitar;
                btnContinuarTipOpe.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarTipOpe.Enabled = false;
                btnContinuarTipOpe.Enabled = false;
            }
        }

        private void CargarLisTipoOpeAproba(int idTipoOperacion)
        {
            dtTipoOpeAproba = objAprobacion.LisTipoOpeAproba(idTipoOperacion);
            dtgTipoOpeAproba.DataSource = dtTipoOpeAproba;
            FormatoLisTipoOpeAproba();
        }

        private void FormatoLisTipoOpeAproba()
        {
            foreach (DataGridViewColumn item in dtgTipoOpeAproba.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTipoOpeAproba.Columns["idTipOpeAproba"].Visible = false;
            dtgTipoOpeAproba.Columns["idTipoOperacion"].Visible = false;
            dtgTipoOpeAproba.Columns["idEstadoOperac"].Visible = false;
            dtgTipoOpeAproba.Columns["idMoneda"].Visible = false;
            dtgTipoOpeAproba.Columns["idNivelProd"].Visible = false;

            dtgTipoOpeAproba.Columns["cEstadoKardex"].Width = 70;
            dtgTipoOpeAproba.Columns["cMoneda"].Width = 70;
            dtgTipoOpeAproba.Columns["lporAgencia"].Width = 45;
            dtgTipoOpeAproba.Columns["lporProducto"].Width = 45;
            dtgTipoOpeAproba.Columns["cNivelProd"].Width = 70;
            dtgTipoOpeAproba.Columns["lVigente"].Width = 50;

            dtgTipoOpeAproba.Columns["cEstadoKardex"].HeaderText = "Tipo";
            dtgTipoOpeAproba.Columns["cMoneda"].HeaderText = "Moneda";
            dtgTipoOpeAproba.Columns["lporAgencia"].HeaderText = "por Agencia";
            dtgTipoOpeAproba.Columns["lporProducto"].HeaderText = "por Producto";
            dtgTipoOpeAproba.Columns["cNivelProd"].HeaderText = "Nivel";
            dtgTipoOpeAproba.Columns["lVigente"].HeaderText = "Vigente";
        }

        #endregion

        #region Panel_Rango_Operacion

        private void dtgRangoAprobaOpe_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaRanOpe = e.RowIndex;

            cboAgencias.SelectedValue = dtRangoAprobaOpe.Rows[iFilaRanOpe]["idAgencia"];
            cboProducto.SelectedValue = dtRangoAprobaOpe.Rows[iFilaRanOpe]["idProducto"];
            txtRangoMin.Text = Convert.ToString(dtRangoAprobaOpe.Rows[iFilaRanOpe]["nRangoMinimo"]);
            txtRangoMax.Text = Convert.ToString(dtRangoAprobaOpe.Rows[iFilaRanOpe]["nRangoMaximo"]);
            chcVigenteRanOpe.Checked = (bool)dtRangoAprobaOpe.Rows[iFilaRanOpe]["lVigente"];
        }

        private void btnNuevoRanOpe_Click(object sender, EventArgs e)
        {
            cTipTrxRanOpe = "N";
            txtRangoMin.Text = "0.00";
            txtRangoMax.Text = "0.00";
            chcVigenteRanOpe.Checked = true;
            HabilitarControlesRanOpe(true);
        }

        private void btnEditarRanOpe_Click(object sender, EventArgs e)
        {
            if (dtgRangoAprobaOpe.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxRanOpe = "A";
            HabilitarControlesRanOpe(true);
        }

        private void btnGrabarRanOpe_Click(object sender, EventArgs e)
        {
            int iFilaTipOpe = dtgTipoOpeAproba.SelectedCells[0].RowIndex;
            int idTipOpeAproba = (int)dtTipoOpeAproba.Rows[iFilaTipOpe]["idTipOpeAproba"];
            int idAgencia = (int)cboAgencias.SelectedValue;
            int idProducto = (int)cboProducto.SelectedValue;
            decimal nRangoMinimo = txtRangoMin.nDecValor;
            decimal nRangoMaximo = txtRangoMax.nDecValor;
            bool lVigente = chcVigenteRanOpe.Checked;
            if (nRangoMinimo > nRangoMaximo)
            {
                MessageBox.Show("El Monto MINIMO debe ser Menor que el monto MAXIMO", "Mantenimiento de Rango de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cTipTrxRanOpe == "N") //Nuevo
            {
                DataTable dtInsRangoAprobaOpe = objAprobacion.InsRangoAprobaOpe(idTipOpeAproba, idAgencia, idProducto, nRangoMinimo, nRangoMaximo, lVigente);
                MessageBox.Show(dtInsRangoAprobaOpe.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Rango de Operaciones", MessageBoxButtons.OK, ((int)dtInsRangoAprobaOpe.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            if (cTipTrxRanOpe == "A")  //Actualizar
            {
                int iFilaRanOpe = dtgRangoAprobaOpe.SelectedCells[0].RowIndex;
                int idRangoOperacion = (int)dtRangoAprobaOpe.Rows[iFilaRanOpe]["idRangoOperacion"];

                DataTable dtActRangoAprobaOpe = objAprobacion.ActRangoAprobaOpe(idRangoOperacion, nRangoMinimo, nRangoMaximo, lVigente);
                MessageBox.Show(dtActRangoAprobaOpe.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Rango de Operaciones", MessageBoxButtons.OK, ((int)dtActRangoAprobaOpe.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            cTipTrxRanOpe = "";
            CargarLisRangoAprobaOpe(idTipOpeAproba);
            HabilitarControlesRanOpe(false);
            dtgRangoAprobaOpe.Focus();
        }

        private void btnCancelarRanOpe_Click(object sender, EventArgs e)
        {
            cTipTrxRanOpe = "";
            HabilitarControlesRanOpe(false);
            dtgRangoAprobaOpe.Focus();
        }

        private void btnRegresarRanOpe_Click(object sender, EventArgs e)
        {
            cboModulo.Enabled = true;
            cboTipoOperacion.Enabled = true;
            tbcMantenimientoApr.SelectedIndex = 0;
            ActualizarDetalleTitulo();
        }

        private void btnContinuarRanOpe_Click(object sender, EventArgs e)
        {
            if (dtgRangoAprobaOpe.Rows.Count <= 0)
            {
                return;
            }
            int iFilaRanOpe = dtgRangoAprobaOpe.SelectedCells[0].RowIndex;
            int idRangoOperacion = (int)dtRangoAprobaOpe.Rows[iFilaRanOpe]["idRangoOperacion"];

            tbcMantenimientoApr.SelectedIndex = 2;
            CargarLisNivelAprRangoOpe(idRangoOperacion);
            HabilitarControlesNivApr(false);
            ActualizarDetalleTitulo();
        }

        private void HabilitarControlesRanOpe(bool lHabilitar)
        {
            if (cTipTrxRanOpe == "N")
            {
                if (chcPorAgencia.Checked == true)
                {
                    cboAgencias.Enabled = lHabilitar;
                }
                else
                {
                    cboAgencias.Enabled = false;
                    cboAgencias.SelectedText = "";
                }

                if (chcPorProducto.Checked == true)
                {
                    cboProducto.Enabled = lHabilitar;
                }
                else
                {
                    cboProducto.Enabled = false;
                    cboProducto.SelectedValue = 0;
                }
            }
            else
            {
                cboAgencias.Enabled = false;
                cboProducto.Enabled = false;
            }

            txtRangoMin.Enabled = lHabilitar;
            txtRangoMax.Enabled = lHabilitar;
            chcVigenteRanOpe.Enabled = lHabilitar;

            btnNuevoRanOpe.Enabled = !lHabilitar;
            btnGrabarRanOpe.Enabled = lHabilitar;
            btnCancelarRanOpe.Enabled = lHabilitar;
            btnRegresarRanOpe.Enabled = !lHabilitar;

            if (dtgRangoAprobaOpe.RowCount > 0)
            {
                btnEditarRanOpe.Enabled = !lHabilitar;
                btnContinuarRanOpe.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarRanOpe.Enabled = false;
                btnContinuarRanOpe.Enabled = false;
            }
        }

        private void CargarLisRangoAprobaOpe(int idTipOpeAproba)
        {
            dtRangoAprobaOpe = objAprobacion.LisRangoAprobaOpe(idTipOpeAproba);
            dtgRangoAprobaOpe.DataSource = dtRangoAprobaOpe;
            FormatoLisRangoAprobaOpe();
        }

        private void FormatoLisRangoAprobaOpe()
        {
            foreach (DataGridViewColumn item in dtgRangoAprobaOpe.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgRangoAprobaOpe.Columns["idRangoOperacion"].Visible = false;
            dtgRangoAprobaOpe.Columns["idAgencia"].Visible = false;
            dtgRangoAprobaOpe.Columns["idProducto"].Visible = false;

            dtgRangoAprobaOpe.Columns["cNombreAge"].Width = 100;
            dtgRangoAprobaOpe.Columns["cProducto"].Width = 140;
            dtgRangoAprobaOpe.Columns["nRangoMinimo"].Width = 60;
            dtgRangoAprobaOpe.Columns["nRangoMaximo"].Width = 60;
            dtgRangoAprobaOpe.Columns["lVigente"].Width = 60;

            dtgRangoAprobaOpe.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgRangoAprobaOpe.Columns["cProducto"].HeaderText = "Producto";
            dtgRangoAprobaOpe.Columns["nRangoMinimo"].HeaderText = "Rango Minimo";
            dtgRangoAprobaOpe.Columns["nRangoMaximo"].HeaderText = "Rango Máximo";
            dtgRangoAprobaOpe.Columns["lVigente"].HeaderText = "Vigente";
        }

        #endregion

        #region Panel_Niveles_Aprobacion

        private void dtgNivelAprRangoOpe_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaNivApr = e.RowIndex;

            txtNivelAprobacion.Text = dtNivelAprRangoOpe.Rows[iFilaNivApr]["cNivelAproba"].ToString();
            nudNroAprobadores.Value = Convert.ToDecimal(dtNivelAprRangoOpe.Rows[iFilaNivApr]["nNumAprobadores"]);
            nudOrdenAprobacion.Value = Convert.ToDecimal(dtNivelAprRangoOpe.Rows[iFilaNivApr]["nOrdenAprobacion"]);
            chcNivComent.Checked = Convert.ToBoolean(dtNivelAprRangoOpe.Rows[iFilaNivApr]["lSoloComent"]);
            chcVigenteNivApr.Checked = (bool)dtNivelAprRangoOpe.Rows[iFilaNivApr]["lVigente"];
        }

        private void btnNuevoNivApr_Click(object sender, EventArgs e)
        {
            cTipTrxNivApr = "N";
            txtNivelAprobacion.Text = "";
            nudNroAprobadores.Value = 1;
            nudOrdenAprobacion.Value = 1;
            chcNivComent.Checked = false;
            chcVigenteNivApr.Checked = true;
            HabilitarControlesNivApr(true);
        }

        private void btnEditarNivApr_Click(object sender, EventArgs e)
        {
            if (dtgNivelAprRangoOpe.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxNivApr = "A";
            HabilitarControlesNivApr(true);
        }

        private void btnGrabarNivApr_Click(object sender, EventArgs e)
        {
            int iFilaRanOpe = dtgRangoAprobaOpe.SelectedCells[0].RowIndex;
            int idRangoOperacion = (int)dtRangoAprobaOpe.Rows[iFilaRanOpe]["idRangoOperacion"];
            string cNivelAproba = txtNivelAprobacion.Text;
            int nNumAprobadores = (int)nudNroAprobadores.Value;
            int nOrdenAprobacion = (int)nudOrdenAprobacion.Value;
            bool lSoloComent = chcNivComent.Checked;
            bool lVigente = chcVigenteNivApr.Checked;

            if (cTipTrxNivApr == "N") //Nuevo
            {
                DataTable dtInsNivelAprRangoOpe = objAprobacion.InsNivelAprRangoOpe(idRangoOperacion, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
                MessageBox.Show(dtInsNivelAprRangoOpe.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Niveles por Rango de Operaciones", MessageBoxButtons.OK, ((int)dtInsNivelAprRangoOpe.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            if (cTipTrxNivApr == "A") //Actualizar
            {
                int iFilaNivApr = dtgNivelAprRangoOpe.SelectedCells[0].RowIndex;
                int idNivelAprRanOpe = (int)dtNivelAprRangoOpe.Rows[iFilaNivApr]["idNivelAprRanOpe"];

                DataTable dtActNivelAprRangoOpe = objAprobacion.ActNivelAprRangoOpe(idNivelAprRanOpe, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
                MessageBox.Show(dtActNivelAprRangoOpe.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Niveles por Rango de Operaciones", MessageBoxButtons.OK, ((int)dtActNivelAprRangoOpe.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            cTipTrxNivApr = "";
            CargarLisNivelAprRangoOpe(idRangoOperacion);
            HabilitarControlesNivApr(false);
            dtgNivelAprRangoOpe.Focus();
        }

        private void btnCancelarNivApr_Click(object sender, EventArgs e)
        {
            cTipTrxNivApr = "";
            HabilitarControlesNivApr(false);
            dtgNivelAprRangoOpe.Focus();
        }

        private void btnRegresarNivApr_Click(object sender, EventArgs e)
        {
            tbcMantenimientoApr.SelectedIndex = 1;
            ActualizarDetalleTitulo();
        }

        private void btnContinuarNivApr_Click(object sender, EventArgs e)
        {
            if (dtgRangoAprobaOpe.Rows.Count <= 0)
            {
                return;
            }
            int iFilaNivApr = dtgNivelAprRangoOpe.SelectedCells[0].RowIndex;
            int idNivelAprRanOpe = (int)dtNivelAprRangoOpe.Rows[iFilaNivApr]["idNivelAprRanOpe"];

            tbcMantenimientoApr.SelectedIndex = 3;
            CargarLisPerfilNivelAproba(idNivelAprRanOpe);
            HabilitarControlesAproba(false);
            ActualizarDetalleTitulo();
        }

        private void HabilitarControlesNivApr(bool lHabilitar)
        {
            txtNivelAprobacion.Enabled = lHabilitar;
            nudNroAprobadores.Enabled = lHabilitar;
            nudOrdenAprobacion.Enabled = lHabilitar;
            chcNivComent.Enabled = lHabilitar;
            chcVigenteNivApr.Enabled = lHabilitar;

            btnNuevoNivApr.Enabled = !lHabilitar;
            btnGrabarNivApr.Enabled = lHabilitar;
            btnCancelarNivApr.Enabled = lHabilitar;
            btnRegresarNivApr.Enabled = !lHabilitar;

            if (dtgNivelAprRangoOpe.RowCount > 0)
            {
                btnEditarNivApr.Enabled = !lHabilitar;
                btnContinuarNivApr.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarNivApr.Enabled = false;
                btnContinuarNivApr.Enabled = false;
            }
        }

        private void CargarLisNivelAprRangoOpe(int idRangoOperacion)
        {
            dtNivelAprRangoOpe = objAprobacion.LisNivelAprRangoOpe(idRangoOperacion);
            dtgNivelAprRangoOpe.DataSource = dtNivelAprRangoOpe;
            FormatoLisNivelAprRangoOpe();
        }

        private void FormatoLisNivelAprRangoOpe()
        {
            foreach (DataGridViewColumn item in dtgNivelAprRangoOpe.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //dtgNivelAprRangoOpe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dtgNivelAprRangoOpe.ColumnHeadersHeight = 55;

            dtgNivelAprRangoOpe.Columns["idNivelAprRanOpe"].Visible = false;

            dtgNivelAprRangoOpe.Columns["cNivelAproba"].Width = 200;
            dtgNivelAprRangoOpe.Columns["nNumAprobadores"].Width = 50;
            dtgNivelAprRangoOpe.Columns["nOrdenAprobacion"].Width = 40;
            dtgNivelAprRangoOpe.Columns["lSoloComent"].Width = 50;
            dtgNivelAprRangoOpe.Columns["lVigente"].Width = 45;

            dtgNivelAprRangoOpe.Columns["cNivelAproba"].HeaderText = "Nivel";
            dtgNivelAprRangoOpe.Columns["nNumAprobadores"].HeaderText = "N° de Aprob.";
            dtgNivelAprRangoOpe.Columns["nOrdenAprobacion"].HeaderText = "Orden";
            dtgNivelAprRangoOpe.Columns["lSoloComent"].HeaderText = "Solo Coment.";
            dtgNivelAprRangoOpe.Columns["lVigente"].HeaderText = "Vigente";
        }

        #endregion

        #region Panel_Aprobadores

        private void dtgPerfilNivelAproba_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaPerfil = e.RowIndex;

            cboListaPerfil.SelectedValue = dtPerfilNivelAproba.Rows[iFilaPerfil]["idPerfil"];
            cboTipoAmbito.SelectedValue = dtPerfilNivelAproba.Rows[iFilaPerfil]["idAmbito"];
            chcVigenteAproba.Checked = (bool)dtPerfilNivelAproba.Rows[iFilaPerfil]["lVigente"];
            ActualizarDetalleTitulo();
        }

        private void btnNuevoAproba_Click(object sender, EventArgs e)
        {
            cTipTrxPerfil = "N";
            chcVigenteAproba.Checked = true;
            HabilitarControlesAproba(true);
        }

        private void btnEditarAproba_Click(object sender, EventArgs e)
        {
            if (dtgPerfilNivelAproba.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxPerfil = "A";
            HabilitarControlesAproba(true);
        }

        private void btnGrabarAproba_Click(object sender, EventArgs e)
        {
            int iFilaNivApr = dtgNivelAprRangoOpe.SelectedCells[0].RowIndex;
            int idNivelAprRanOpe = (int)dtNivelAprRangoOpe.Rows[iFilaNivApr]["idNivelAprRanOpe"];
            int idPerfil = (int)cboListaPerfil.SelectedValue;
            int idAmbito = (int)cboTipoAmbito.SelectedValue;
            bool lVigente = chcVigenteAproba.Checked;

            if (cTipTrxPerfil == "N") //Nuevo
            {
                DataTable dtInsPerfilNivelAproba = objAprobacion.InsPerfilNivelAproba(idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
                MessageBox.Show(dtInsPerfilNivelAproba.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Aprobadores por Nivel", MessageBoxButtons.OK, ((int)dtInsPerfilNivelAproba.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            if (cTipTrxPerfil == "A") //Actualizar
            {
                DataTable dtActPerfilNivelAproba = objAprobacion.ActPerfilNivelAproba(idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
                MessageBox.Show(dtActPerfilNivelAproba.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Aprobadores por Nivel", MessageBoxButtons.OK, ((int)dtActPerfilNivelAproba.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            cTipTrxPerfil = "";
            CargarLisPerfilNivelAproba(idNivelAprRanOpe);
            HabilitarControlesAproba(false);
            dtgPerfilNivelAproba.Focus();
        }

        private void btnCancelarAproba_Click(object sender, EventArgs e)
        {
            cTipTrxPerfil = "";
            HabilitarControlesAproba(false);
            dtgPerfilNivelAproba.Focus();
        }

        private void btnRegresarAproba_Click(object sender, EventArgs e)
        {
            tbcMantenimientoApr.SelectedIndex = 2;
            ActualizarDetalleTitulo();
        }

        private void HabilitarControlesAproba(bool lHabilitar)
        {
            cboListaPerfil.Enabled = lHabilitar;
            cboTipoAmbito.Enabled = lHabilitar;
            chcVigenteAproba.Enabled = lHabilitar;

            btnNuevoAproba.Enabled = !lHabilitar;
            btnGrabarAproba.Enabled = lHabilitar;
            btnCancelarAproba.Enabled = lHabilitar;
            btnRegresarAproba.Enabled = !lHabilitar;

            if (dtgPerfilNivelAproba.RowCount > 0)
            {
                btnEditarAproba.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarAproba.Enabled = false;
            }
        }

        private void CargarLisPerfilNivelAproba(int idNivelAprRanOpe)
        {
            dtPerfilNivelAproba = objAprobacion.LisPerfilNivelAproba(idNivelAprRanOpe);
            dtgPerfilNivelAproba.DataSource = dtPerfilNivelAproba;
            FormatoLisPerfilNivelAproba();
        }

        private void FormatoLisPerfilNivelAproba()
        {
            foreach (DataGridViewColumn item in dtgPerfilNivelAproba.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPerfilNivelAproba.Columns["idPerfil"].Visible = false;
            dtgPerfilNivelAproba.Columns["idAmbito"].Visible = false;

            dtgPerfilNivelAproba.Columns["cPerfil"].Width = 160;
            dtgPerfilNivelAproba.Columns["cAmbito"].Width = 160;
            dtgPerfilNivelAproba.Columns["lVigente"].Width = 60;

            dtgPerfilNivelAproba.Columns["cPerfil"].HeaderText = "Perfil";
            dtgPerfilNivelAproba.Columns["cAmbito"].HeaderText = "Ambito";
            dtgPerfilNivelAproba.Columns["lVigente"].HeaderText = "Vigente";
        }

        #endregion

        private void ActualizarDetalleTitulo()
        {
            StringBuilder sbTitulo = new StringBuilder();
            if (tbcMantenimientoApr.SelectedIndex >= 1)
            {
                sbTitulo.AppendFormat("{0} | {1} ", cboModulo.Text.Trim(),
                                                    cboTipoOperacion.Text.Trim());
            }
            if (tbcMantenimientoApr.SelectedIndex >= 2)
            {
                sbTitulo.AppendFormat("| {0} | {1} | {2} | {3} - {4} ", cboAgencias.Text.Trim(),
                                                                        cboProducto.Text.Trim(),
                                                                        cboMoneda.Text.Trim(),
                                                                        txtRangoMin.Text.Trim(),
                                                                        txtRangoMax.Text.Trim());
            }
            if (tbcMantenimientoApr.SelectedIndex >= 3)
            {
                sbTitulo.AppendFormat("| {0} ", txtNivelAprobacion.Text.Trim());
            }

            //if (tbcMantenimientoApr.SelectedIndex >= 3 && dtgPerfilNivelAproba.Rows.Count > 0)
            //{
            //    sbTitulo.AppendFormat("| {0}", cboListaPerfil.Text);
            //}
            //else
            //{
            //    sbTitulo.AppendFormat(String.Empty);
            //}
            lblDetalleOpcion.Text = sbTitulo.ToString();
        }

    }
}
