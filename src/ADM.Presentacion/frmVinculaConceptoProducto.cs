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
    public partial class frmVinculaConceptoProducto : frmBase
    {
        clsCNMantenimiento objMantenimiento = new clsCNMantenimiento();
        clsCNGenAdmOpe objTipoOperacion = new clsCNGenAdmOpe();
        clsCNCanal objTipoCanal = new clsCNCanal();
        clsCNTipoPago objTipoPago = new clsCNTipoPago();
        clsCNConcepto objConcepto = new clsCNConcepto();

        DataTable dtTipoOperacion = new DataTable();
        DataTable dtTipoCanal = new DataTable();
        DataTable dtTipoPago = new DataTable();
        DataTable dtConcepto = new DataTable();

        string cTipTrxTipoOperacion = "";
        string cTipTrxTipoCanal = "";
        string cTipTrxTipoPago = "";
        string cTipTrxConcepto = "";

        public frmVinculaConceptoProducto()
        {
            InitializeComponent();
        }

        private void frmVinculaConceptoProducto_Load(object sender, EventArgs e)
        {
            if (cboModulo.Items.Count > 0)
            {
                cboModulo.SelectedIndex = 0;
                cboModulo_SelectedIndexChanged(sender, e);
            }

            cboConcepto.ListarConcepto(0);
            HabilitarControlesPrincipal(true);
            HabilitarControlesTipoOperacion(false);
            clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idModulo = (int)cboModulo.SelectedValue;
            cboTipoProducto.SelectedIndexChanged -= new EventHandler(cboTipoProducto_SelectedIndexChanged);
            cboTipoProducto.CargarProductoModNivel(idModulo, 1);
            cboTipoProducto.SelectedIndexChanged += new EventHandler(cboTipoProducto_SelectedIndexChanged);

            cboTipoOperacion.LisTipoOperacModulo(idModulo);

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
                btnNuevoTipoOperacion.Enabled = false;
                btnEditarTipoOperacion.Enabled = false;
                dtTipoOperacion.Clear();
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
                btnNuevoTipoOperacion.Enabled = false;
                btnEditarTipoOperacion.Enabled = false;
                dtTipoOperacion.Clear();
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
                btnNuevoTipoOperacion.Enabled = false;
                btnEditarTipoOperacion.Enabled = false;
                dtTipoOperacion.Clear();
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
                btnNuevoTipoOperacion.Enabled = true;
            }
            else
            {
                btnNuevoTipoOperacion.Enabled = false;
                btnEditarTipoOperacion.Enabled = false;
                dtTipoOperacion.Clear();
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
            CargarLisTipoOperacProduc(idSubProducto);
            HabilitarControlesTipoOperacion(false);
        }

        private void HabilitarControlesPrincipal(bool lHabilitar)
        {
            cboModulo.Enabled = lHabilitar;
            cboTipoProducto.Enabled = lHabilitar;
            cboSubTipoProducto.Enabled = lHabilitar;
            cboProducto.Enabled = lHabilitar;
            cboSubProducto.Enabled = lHabilitar;
        }

        #region Panel_TipoOperacion
        private void dtgTipoOperacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipoOperac = e.RowIndex;

            cboTipoOperacion.SelectedValue = (int)dtTipoOperacion.Rows[iFilaTipoOperac]["idTipoOperacion"];
            chcTipoOperacion.Checked = (bool)dtTipoOperacion.Rows[iFilaTipoOperac]["lVigente"];
        }

        private void btnNuevoTipoOperacion_Click(object sender, EventArgs e)
        {
            cTipTrxTipoOperacion = "N";
            chcTipoOperacion.Checked = true;
            HabilitarControlesPrincipal(false);
            HabilitarControlesTipoOperacion(true);
        }

        private void btnEditarTipoOperacion_Click(object sender, EventArgs e)
        {
            if (dtgTipoOperacion.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxTipoOperacion = "A";
            HabilitarControlesPrincipal(false);
            HabilitarControlesTipoOperacion(true);
        }

        private bool validar()
        {
            if (Convert.ToInt32(cboModulo.SelectedValue) == 3)
            {
                if (cboSubTipoProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe elegir el sub tipo", "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true ;
                }
            }
            else
            {
                if (cboSubProducto.SelectedValue == null)
                {
                    MessageBox.Show("Debe elegir el sub producto", "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true ;
                }
            }
            if (cboTipoOperacion.SelectedValue==null )
            {
                MessageBox.Show("Debe elegir el tipo de operación", "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void btnGrabarTipoOperacion_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            
            int idProducto = (int)(Convert.ToInt32(cboModulo.SelectedValue) == 3 ? cboSubTipoProducto.SelectedValue : cboSubProducto.SelectedValue);
            int idTipoOperacion = (int)cboTipoOperacion.SelectedValue;
            bool lVigente = chcTipoOperacion.Checked;

            if (cTipTrxTipoOperacion == "N")
            {
                DataTable dtInsertarTipOpeProduc = objMantenimiento.CNInsertarTipOpeProduc(idProducto, idTipoOperacion, lVigente);
                MessageBox.Show(dtInsertarTipOpeProduc.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cTipTrxTipoOperacion == "A")
            {
                int iFilaTipoOperac = dtgTipoOperacion.SelectedCells[0].RowIndex;
                int idTipOpeProduc = (int)dtTipoOperacion.Rows[iFilaTipoOperac]["idTipOpeProduc"];

                DataTable dtActualizarTipOpeProduc = objMantenimiento.CNActualizarTipOpeProduc(idTipOpeProduc, lVigente);
                MessageBox.Show(dtActualizarTipOpeProduc.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cTipTrxTipoOperacion = "";
            CargarLisTipoOperacProduc(idProducto);
            HabilitarControlesPrincipal(true);
            HabilitarControlesTipoOperacion(false);
        }

        private void btnCancelarTipoOperacion_Click(object sender, EventArgs e)
        {
            cTipTrxTipoOperacion = "";
            HabilitarControlesPrincipal(true);
            HabilitarControlesTipoOperacion(false);
            dtgTipoOperacion.Focus();
        }

        private void btnContinuarTipoOperacion_Click(object sender, EventArgs e)
        {
            if (dtTipoOperacion.Rows.Count <= 0)
            {
                return;
            }
            int iFilaTipoOperac = dtgTipoOperacion.SelectedCells[0].RowIndex;
            int idTipOpeProduc = (int)dtTipoOperacion.Rows[iFilaTipoOperac]["idTipOpeProduc"];

            tbcMantenimiento.SelectedIndex = 1;
            lblPathTipoCanal.Text = dtTipoOperacion.Rows[iFilaTipoOperac]["cTipoOperacion"].ToString();
            CargarLisCanalTipOpe(idTipOpeProduc);
            HabilitarControlesPrincipal(false);
            HabilitarControlesTipoCanal(false);

            if ((int)cboModulo.SelectedValue == 3)
            {

                DataTable dtValidaProduc = objMantenimiento.CNValidaProduto((int)cboTipoProducto.SelectedValue);

                if (dtValidaProduc.Rows[0]["nResp"].ToString() == "1")
                {
                    cboConceptoRec.Visible = false;
                    cboConcepto.Visible = true;
                }
                else
                {
                    clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();

                    //========================== Cargar sólo los conceptos con estado vigente ==============>
                    //cboConceptoRec.DataSource = Conceptos.ListarConcep(idTipOpeProduc);
                    DataTable dtAuxConcepto = Conceptos.ListarConcep(idTipOpeProduc);//Todos loc conceptos
                    DataTable dtConcepto = dtAuxConcepto.Clone();//sólo conceptos vigentes

                    for (int f = 0; f < dtAuxConcepto.Rows.Count; f++)
                    {
                        if (Convert.ToInt32(dtAuxConcepto.Rows[f]["cEstado"]) == 1)
                        {
                            DataRow dr = dtConcepto.NewRow();
                            for (int c = 0; c < dtAuxConcepto.Columns.Count; c++)
                            {
                                dr[c] = dtAuxConcepto.Rows[f][c];
                            }
                            dtConcepto.Rows.Add(dr);
                        }

                    }
                    cboConceptoRec.DataSource = dtConcepto;
                    //======================================================================================>

                    cboConceptoRec.ValueMember = "idConcepto";
                    cboConceptoRec.DisplayMember = "cConcepto";

                    cboConceptoRec.Visible = true;
                    cboConcepto.Visible = false;
                }
            }
            else
            {
                cboConceptoRec.Visible = false;
                cboConcepto.Visible = true;
            }
        }

        private void HabilitarControlesTipoOperacion(bool lHabilitar)
        {
            dtgTipoOperacion.Enabled = !lHabilitar;

            cboTipoOperacion.Enabled = lHabilitar;
            chcTipoOperacion.Enabled = lHabilitar;

            btnNuevoTipoOperacion.Enabled = !lHabilitar;
            if (dtTipoOperacion.Rows.Count > 0)
            {
                btnEditarTipoOperacion.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarTipoOperacion.Enabled = false;
            }
            btnGrabarTipoOperacion.Enabled = lHabilitar;
            btnCancelarTipoOperacion.Enabled = lHabilitar;
            btnContinuarTipoOperacion.Enabled = !lHabilitar;
        }

        private void CargarLisTipoOperacProduc(int idProducto)
        {
            dtTipoOperacion = objTipoOperacion.CNLisTipoOperacProduc(idProducto);
            dtgTipoOperacion.DataSource = dtTipoOperacion;
        }
        #endregion

        #region Panel_TipoCanal
        private void dtgTipoCanal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipoCanal = e.RowIndex;

            cboTipoCanal.SelectedValue = (int)dtTipoCanal.Rows[iFilaTipoCanal]["idCanal"];
            chcTipoCanal.Checked = (bool)dtTipoCanal.Rows[iFilaTipoCanal]["lVigente"];
        }

        private void btnRegresarTipoCanal_Click(object sender, EventArgs e)
        {
            HabilitarControlesPrincipal(true);
            tbcMantenimiento.SelectedIndex = 0;
        }

        private void btnNuevoTipoCanal_Click(object sender, EventArgs e)
        {
            cTipTrxTipoCanal = "N";
            chcTipoCanal.Checked = true;
            HabilitarControlesTipoCanal(true);
        }

        private void btnEditarTipoCanal_Click(object sender, EventArgs e)
        {
            if (dtgTipoCanal.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxTipoCanal = "A";
            HabilitarControlesTipoCanal(true);
        }

        private void btnGrabarTipoCanal_Click(object sender, EventArgs e)
        {
            int iFilaTipoOperac = dtgTipoOperacion.SelectedCells[0].RowIndex;
            int idTipOpeProduc = (int)dtTipoOperacion.Rows[iFilaTipoOperac]["idTipOpeProduc"];
            int idCanal = (int)cboTipoCanal.SelectedValue;
            bool lVigente = chcTipoCanal.Checked;

            if (cTipTrxTipoCanal == "N")
            {
                DataTable dtInsertarCanalTipOpe = objMantenimiento.CNInsertarCanalTipOpe(idTipOpeProduc, idCanal, lVigente);
                MessageBox.Show(dtInsertarCanalTipOpe.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cTipTrxTipoCanal == "A")
            {
                int iFilaTipoCanal = dtgTipoCanal.SelectedCells[0].RowIndex;
                int idCanalTipOpe = (int)dtTipoCanal.Rows[iFilaTipoCanal]["idCanalTipOpe"];

                DataTable dtActualizarCanalTipOpec = objMantenimiento.CNActualizarCanalTipOpec(idCanalTipOpe, lVigente);
                MessageBox.Show(dtActualizarCanalTipOpec.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cTipTrxTipoCanal = "";
            CargarLisCanalTipOpe(idTipOpeProduc);
            HabilitarControlesTipoCanal(false);
        }

        private void btnCancelarTipoCanal_Click(object sender, EventArgs e)
        {
            cTipTrxTipoCanal = "";
            HabilitarControlesTipoCanal(false);
            dtgTipoCanal.Focus();
        }

        private void btnContinuarTipoCanal_Click(object sender, EventArgs e)
        {
            if (dtTipoCanal.Rows.Count <= 0)
            {
                return;
            }
            int iFilaTipoCanal = dtgTipoCanal.SelectedCells[0].RowIndex;
            int idCanalTipOpe = (int)dtTipoCanal.Rows[iFilaTipoCanal]["idCanalTipOpe"];

            tbcMantenimiento.SelectedIndex = 2;
            lblPathTipoPago.Text = lblPathTipoCanal.Text + " | " + dtTipoCanal.Rows[iFilaTipoCanal]["cCanal"].ToString();
            cargarLisTipoPagoCanal(idCanalTipOpe);
            HabilitarControlesTipoPago(false);
        }

        private void HabilitarControlesTipoCanal(bool lHabilitar)
        {
            dtgTipoCanal.Enabled = !lHabilitar;

            cboTipoCanal.Enabled = lHabilitar;
            chcTipoCanal.Enabled = lHabilitar;

            btnRegresarTipoCanal.Enabled = !lHabilitar;
            btnNuevoTipoCanal.Enabled = !lHabilitar;
            if (dtTipoCanal.Rows.Count > 0)
            {
                btnEditarTipoCanal.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarTipoCanal.Enabled = false;
            }
            btnGrabarTipoCanal.Enabled = lHabilitar;
            btnCancelarTipoCanal.Enabled = lHabilitar;
            btnContinuarTipoCanal.Enabled = !lHabilitar;
        }

        private void CargarLisCanalTipOpe(int idTipOpeProduc)
        {
            dtTipoCanal = objTipoCanal.CNListarCanalTipOpe(idTipOpeProduc);
            dtgTipoCanal.DataSource = dtTipoCanal;
        }
        #endregion

        #region Panel_TipoPago
        private void dtgTipoPago_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaTipoPago = e.RowIndex;

            cboTipoPago.SelectedValue = (int)dtTipoPago.Rows[iFilaTipoPago]["idTipoPago"];
            chcTipoPago.Checked = (bool)dtTipoPago.Rows[iFilaTipoPago]["lVigente"];
        }

        private void btnRegresarTipoPago_Click(object sender, EventArgs e)
        {
            tbcMantenimiento.SelectedIndex = 1;
        }

        private void btnNuevoTipoPago_Click(object sender, EventArgs e)
        {
            cTipTrxTipoPago = "N";
            chcTipoPago.Checked = true;
            HabilitarControlesTipoPago(true);
        }

        private void btnEditarTipoPago_Click(object sender, EventArgs e)
        {
            if (dtgTipoPago.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxTipoPago = "A";
            HabilitarControlesTipoPago(true);
        }

        private void btnGrabarTipoPago_Click(object sender, EventArgs e)
        {
            int iFilaTipoCanal = dtgTipoCanal.SelectedCells[0].RowIndex;
            int idCanalTipOpe = (int)dtTipoCanal.Rows[iFilaTipoCanal]["idCanalTipOpe"];
            int idTipoPago = (int)cboTipoPago.SelectedValue;
            bool lVigente = chcTipoPago.Checked;

            if (cTipTrxTipoPago == "N")
            {
                DataTable dtInsertarTipPagCanal = objMantenimiento.CNInsertarTipPagCanal(idCanalTipOpe, idTipoPago, lVigente);
                MessageBox.Show(dtInsertarTipPagCanal.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cTipTrxTipoPago == "A")
            {
                int iFilaTipoPago = dtgTipoPago.SelectedCells[0].RowIndex;
                int idTipPagCanal = (int)dtTipoPago.Rows[iFilaTipoPago]["idTipPagCanal"];
                DataTable dtActualizarTipPagCanal = objMantenimiento.CNActualizarTipPagCanal(idTipPagCanal, lVigente);
                MessageBox.Show(dtActualizarTipPagCanal.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cTipTrxTipoPago = "";
            cargarLisTipoPagoCanal(idCanalTipOpe);
            HabilitarControlesTipoPago(false);
        }

        private void btnCancelarTipoPago_Click(object sender, EventArgs e)
        {
            cTipTrxTipoPago = "";
            HabilitarControlesTipoPago(false);
            dtgTipoPago.Focus();
        }

        private void btnContinuarTipoPago_Click(object sender, EventArgs e)
        {
            if (dtTipoPago.Rows.Count <= 0)
            {
                return;
            }
            int iFilaTipoPago = dtgTipoPago.SelectedCells[0].RowIndex;
            int idTipPagCanal = (int)dtTipoPago.Rows[iFilaTipoPago]["idTipPagCanal"];

            tbcMantenimiento.SelectedIndex = 3;
            lblPathConcepto.Text = lblPathTipoPago.Text + " | " + dtTipoPago.Rows[iFilaTipoPago]["cDesTipoPago"].ToString();
            cargarLisConceptoTipPag(idTipPagCanal);
            HabilitarControlesConcepto(false);
        }

        private void HabilitarControlesTipoPago(bool lHabilitar)
        {
            dtgTipoPago.Enabled = !lHabilitar;

            cboTipoPago.Enabled = lHabilitar;
            chcTipoPago.Enabled = lHabilitar;

            btnRegresarTipoPago.Enabled = !lHabilitar;
            btnNuevoTipoPago.Enabled = !lHabilitar;
            if (dtTipoPago.Rows.Count > 0)
            {
                btnEditarTipoPago.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarTipoPago.Enabled = false;
            }
            btnGrabarTipoPago.Enabled = lHabilitar;
            btnCancelarTipoPago.Enabled = lHabilitar;
            btnContinuarTipoPago.Enabled = !lHabilitar;
        }

        private void cargarLisTipoPagoCanal(int idCanalTipOpe)
        {
            dtTipoPago = objTipoPago.CNListarTipPagCanal(idCanalTipOpe);
            dtgTipoPago.DataSource = dtTipoPago;
        }
        #endregion

        #region Panel_Concepto
        private void dtgConcepto_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int iFilaConcepto = e.RowIndex;

            cboConcepto.SelectedValue = (int)dtConcepto.Rows[iFilaConcepto]["idConcepto"];
            chcConcepto.Checked = (bool)dtConcepto.Rows[iFilaConcepto]["lVigente"];
        }

        private void btnRegresarConcepto_Click(object sender, EventArgs e)
        {
            tbcMantenimiento.SelectedIndex = 2;
        }

        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            cTipTrxConcepto = "N";
            chcConcepto.Checked = true;
            HabilitarControlesConcepto(true);
        }

        private void btnEditarConcepto_Click(object sender, EventArgs e)
        {
            if (dtgConcepto.Rows.Count <= 0)
            {
                return;
            }
            cTipTrxConcepto = "A";
            HabilitarControlesConcepto(true);
        }

        private void btnGrabarConcepto_Click(object sender, EventArgs e)
        {
            int idConcepto;
            if ((int)cboModulo.SelectedValue == 3)
            {
                DataTable dtValidaProduc = objMantenimiento.CNValidaProduto((int)cboTipoProducto.SelectedValue);

                if (dtValidaProduc.Rows[0]["nResp"].ToString() == "1")
                {
                    idConcepto = (int)cboConcepto.SelectedValue;
                }
                else
                {
                    idConcepto = (int)cboConceptoRec.SelectedValue;
                }
            }
            else
            {
                idConcepto = (int)cboConcepto.SelectedValue;
            }

            int iFilaTipoPago = dtgTipoPago.SelectedCells[0].RowIndex;
            int idTipPagCanal = (int)dtTipoPago.Rows[iFilaTipoPago]["idTipPagCanal"];
            bool lVigente = chcConcepto.Checked;

            if (cTipTrxConcepto == "N")
            {
                DataTable dtInsertarConcepTipPag = objMantenimiento.CNInsertarConcepTipPag(idTipPagCanal, idConcepto, lVigente);
                MessageBox.Show(dtInsertarConcepTipPag.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cTipTrxConcepto == "A")
            {
                int iFilaConcepto = dtgConcepto.SelectedCells[0].RowIndex;
                int idConcepTipPag = (int)dtConcepto.Rows[iFilaConcepto]["idConcepTipPag"];

                DataTable dtActualizarConcepTipPag = objMantenimiento.CNActualizarConcepTipPag(idConcepTipPag, lVigente);
                MessageBox.Show(dtActualizarConcepTipPag.Rows[0]["cMensaje"].ToString(), "Vinculación de Conceptos a Tipo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cTipTrxConcepto = "";
            cargarLisConceptoTipPag(idTipPagCanal);
            HabilitarControlesConcepto(false);
        }

        private void btnCancelarConcepto_Click(object sender, EventArgs e)
        {
            cTipTrxConcepto = "";
            HabilitarControlesConcepto(false);
            dtgConcepto.Focus();
        }

        private void HabilitarControlesConcepto(bool lHabilitar)
        {
            dtgConcepto.Enabled = !lHabilitar;

            cboConcepto.Enabled = lHabilitar;
            chcConcepto.Enabled = lHabilitar;

            btnRegresarConcepto.Enabled = !lHabilitar;
            btnNuevoConcepto.Enabled = !lHabilitar;
            if (dtConcepto.Rows.Count > 0)
            {
                btnEditarConcepto.Enabled = !lHabilitar;
            }
            else
            {
                btnEditarConcepto.Enabled = false;
            }
            btnGrabarConcepto.Enabled = lHabilitar;
            btnCancelarConcepto.Enabled = lHabilitar;
        }

        private void cargarLisConceptoTipPag(int idTipPagCanal)
        {
            if ((int)cboModulo.SelectedValue == 3)
            {
                DataTable dtValidaProduc = objMantenimiento.CNValidaProduto((int)cboTipoProducto.SelectedValue);

                if (dtValidaProduc.Rows[0]["nResp"].ToString() == "1")
                {
                    dtConcepto = objConcepto.CNListarConcepTipPag(idTipPagCanal);
                    dtgConcepto.DataSource = dtConcepto;
                }
                else
                {
                    dtConcepto = objConcepto.CNListarConcepRecTipPag(idTipPagCanal);
                    dtgConcepto.DataSource = dtConcepto;
                }
            }
            else
            {
                dtConcepto = objConcepto.CNListarConcepTipPag(idTipPagCanal);
                dtgConcepto.DataSource = dtConcepto;
            }
        }
        #endregion
    }
}
