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
using LOG.CapaNegocio;
using EntityLayer;
namespace LOG.Presentacion
{
    public partial class frmManTipoFactorTecnico : frmBase
    {
        #region Variables

        clsCNNotaPedido cnTipoFacTec = new clsCNNotaPedido();
        string pidNueEdtTipFac, pidNueEdtCriEva;

        #endregion

        #region Constructor

        public frmManTipoFactorTecnico()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmManTipoFactorTecnico_Load(object sender, EventArgs e)
        {
            int idTipoPed = Convert.ToInt32(cboTipoPedido.SelectedValue);
            cargarTipoFacTecnico(idTipoPed, 0);
            habilitarBotones(true);
            habilitarBotones_CriEva(true);

            HabilitarControlFacTec(false);
            HabilitarControlCriEva(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTipoFacTecnico.Text.Trim()))
            {
                MessageBox.Show("Ingrese Tipo de Factor Técnico", "Validar Tipo Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtPuntajeFacTec.Text.Trim()))
            {
                MessageBox.Show("Ingrese Puntaje Correcto", "Validar Tipo Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToDecimal((txtPuntajeFacTec.Text)) <= 0)
            {
                MessageBox.Show("Ingrese Puntaje Mayor que Cero", "Validar Tipo Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsTipoFactoresTecnicos TipFacTec = new clsTipoFactoresTecnicos();
            TipFacTec.idFacTecnicos = 0;
            if (pidNueEdtTipFac == "E")
            {
                var itemSelc = (clsTipoFactoresTecnicos)dtgFacTec.CurrentRow.DataBoundItem;
                TipFacTec.idFacTecnicos = itemSelc.idFacTecnicos;
            }

            TipFacTec.cFacTecnicos = txtTipoFacTecnico.Text.Trim();
            TipFacTec.nPuntaje = Convert.ToDecimal(txtPuntajeFacTec.Text);
            TipFacTec.idTipoPedido = Convert.ToInt32(cboTipoPedido.SelectedValue);
            TipFacTec.idPadre = 0;
            TipFacTec.lVigente = chcVigente.Checked;
            string resp = new clsCNProcesoAdjudicacion().GrabarTipFacTecnico(TipFacTec);
            if (resp == "-1")
            {
                string msg = (pidNueEdtTipFac == "E") ? "Error al Actualizar el Registro" : "Error al Grabar el Registro";
                MessageBox.Show(msg, "Validar Registro de Tipo de Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string msg = (pidNueEdtTipFac == "E") ? "Edición Correcta de Registro" : "Se Grabó Correctamente el Registro";
                MessageBox.Show(msg, "Validar Registro de Tipo de Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarBotones(true);
                int idTipoPed = Convert.ToInt32(cboTipoPedido.SelectedValue);
                cargarTipoFacTecnico(idTipoPed, 0);
                HabilitarControlFacTec(false);
                btnContinuarTipoCanal.Enabled = true;
                dtgFacTec.Enabled = true;
            }

        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            HabilitarControlFacTec(true);
            btnContinuarTipoCanal.Enabled = false;
            pidNueEdtTipFac = "N";
            txtTipoFacTecnico.Text = string.Empty;
            txtPuntajeFacTec.Text = "0.00";
            chcVigente.Checked = true;
            dtgFacTec.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            HabilitarControlFacTec(false);
            btnContinuarTipoCanal.Enabled = true;

            dtgFacTec_SelectionChanged(sender, e);
            dtgFacTec.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgFacTec.RowCount <= 0)
            {
                MessageBox.Show("No Existe Registro para Editar", "Validar Tipo de Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var itemSelc = (clsTipoFactoresTecnicos)dtgFacTec.CurrentRow.DataBoundItem;
            habilitarBotones(false);
            HabilitarControlFacTec(true);
            btnContinuarTipoCanal.Enabled = false;
            pidNueEdtTipFac = "E";
            dtgFacTec.Enabled = false;
        }

        private void btnRegresar1_Click(object sender, EventArgs e)
        {
            tbcFacTecnicos.SelectedIndex = 0;
            lblTitulo.Text = "FACTORES TÉCNICOS";
        }

        private void btnContinuarTipoCanal_Click(object sender, EventArgs e)
        {
            if (dtgFacTec.RowCount <= 0)
            {
                MessageBox.Show("Debe Seleccionar Tipo de Factor Técnico", "Validar Tipo de Factor Técnico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tbcFacTecnicos.SelectedIndex = 1;
            lblTitulo.Text = "CRITERIOS DE EVALUACIÓN";
            int idTipoPed;
            idTipoPed = Convert.ToInt32(cboTipoPedido.SelectedValue);
            var itemSelec = (clsTipoFactoresTecnicos)dtgFacTec.CurrentRow.DataBoundItem;
            dtgCriEva.DataSource = null;
            dtgCriEva.DataSource = new clsCNProcesoAdjudicacion().buscaTipoFacTecnico(idTipoPed, itemSelec.idFacTecnicos);
            txtDesFacTec.Text = itemSelec.cFacTecnicos;
            if (dtgCriEva.RowCount <= 0)
            {
                txtDesCriEva.Clear();
                txtPuntCreEva.Text = "0.00";
            }

        }

        private void btnNuevoCriEva_Click(object sender, EventArgs e)
        {
            habilitarBotones_CriEva(false);
            HabilitarControlCriEva(true);
            btnRegresar1.Enabled = false;
            txtDesCriEva.Text = string.Empty;
            txtPuntCreEva.Text = "0.00";
            chcCritVigente.Checked = true;
            pidNueEdtCriEva = "N";
            dtgCriEva.Enabled = false;
        }

        private void btnEditarCriEva_Click(object sender, EventArgs e)
        {
            if (dtgCriEva.RowCount <= 0)
            {
                MessageBox.Show("No Existe Registro para Editar", "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            habilitarBotones_CriEva(false);
            HabilitarControlCriEva(true);
            btnRegresar1.Enabled = false;
            pidNueEdtCriEva = "E";
            dtgCriEva.Enabled = false;
        }

        private void btnGrabarCritEva_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDesCriEva.Text.Trim()))
            {
                MessageBox.Show("Ingrese la Descripción del Criterio de Evaluación", "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtPuntCreEva.Text.Trim()))
            {
                MessageBox.Show("Ingrese Puntaje Correcto", "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToDecimal((txtPuntCreEva.Text)) <= 0)
            {
                MessageBox.Show("Ingrese Puntaje Mayor que Cero", "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var itemSelc = (clsTipoFactoresTecnicos)dtgFacTec.CurrentRow.DataBoundItem;
            clsTipoFactoresTecnicos TipFacTec = new clsTipoFactoresTecnicos();
            TipFacTec.idFacTecnicos = 0;
            if (pidNueEdtCriEva == "E")
            {
                var itemSelcCri = (clsTipoFactoresTecnicos)dtgCriEva.CurrentRow.DataBoundItem;
                TipFacTec.idFacTecnicos = itemSelcCri.idFacTecnicos;
            }

            TipFacTec.cFacTecnicos = txtDesCriEva.Text.Trim();
            TipFacTec.nPuntaje = Convert.ToDecimal(txtPuntCreEva.Text);
            TipFacTec.idTipoPedido = Convert.ToInt32(cboTipoPedido.SelectedValue);
            TipFacTec.idPadre = itemSelc.idFacTecnicos;
            TipFacTec.lVigente = chcCritVigente.Checked;
            string resp = new clsCNProcesoAdjudicacion().GrabarTipFacTecnico(TipFacTec);
            if (resp == "-1")
            {
                string msg = (pidNueEdtCriEva == "E") ? "Error al Actualizar el Registro" : "Error al Grabar el Registro";
                MessageBox.Show(msg, "Validar Registro de Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string msg = (pidNueEdtCriEva == "E") ? "Edición Correcta de Registro" : "Se Grabó Correctamente el Registro";
                MessageBox.Show(msg, "Validar Registro de Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarBotones_CriEva(true);
                HabilitarControlCriEva(false);
                btnRegresar1.Enabled = true;
                int idTipoPed;
                idTipoPed = Convert.ToInt32(cboTipoPedido.SelectedValue);
                dtgCriEva.DataSource = null;
                dtgCriEva.DataSource = new clsCNProcesoAdjudicacion().buscaTipoFacTecnico(idTipoPed, itemSelc.idFacTecnicos);
                dtgCriEva.Enabled = true;
            }


        }

        private void cboTipoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPedido.Items.Count <= 0)
            {
                return;
            }
            int idTipoPed = Convert.ToInt32(cboTipoPedido.SelectedValue);
            cargarTipoFacTecnico(idTipoPed, 0);
        }

        private void dtgFacTec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgFacTec_SelectionChanged(sender, e);
        }

        private void dtgFacTec_SelectionChanged(object sender, EventArgs e)
        {
            var itemSel = (clsTipoFactoresTecnicos)dtgFacTec.CurrentRow.DataBoundItem;
            txtPuntajeFacTec.Text = itemSel.nPuntaje.ToString();
            txtTipoFacTecnico.Text = itemSel.cFacTecnicos;
            chcVigente.Checked = itemSel.lVigente;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarBotones_CriEva(true);
            HabilitarControlCriEva(false);
            btnRegresar1.Enabled = true;
            dtgCriEva_SelectionChanged(sender, e);
            dtgCriEva.Enabled = true;
        }

        private void dtgCriEva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgCriEva_SelectionChanged(sender, e);
        }

        private void dtgCriEva_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgCriEva.RowCount <= 0)
            {
                return;
            }
            var itemSel = (clsTipoFactoresTecnicos)dtgCriEva.CurrentRow.DataBoundItem;
            txtDesCriEva.Text = itemSel.cFacTecnicos;
            txtPuntCreEva.Text = itemSel.nPuntaje.ToString();
            chcCritVigente.Checked = itemSel.lVigente;
        }

        #endregion

        #region Metodos

        private void cargarTipoFacTecnico(int idTipoPed, int idPadre)
        {
            dtgFacTec.DataSource = null;
            dtgFacTec.DataSource = new clsCNProcesoAdjudicacion().buscaTipoFacTecnico(idTipoPed, idPadre);
            if (dtgFacTec.RowCount <= 0)
            {
                txtTipoFacTecnico.Clear();
                txtPuntajeFacTec.Text = "0.00";
            }
        }

        private void HabilitarControlFacTec(bool lactiva)
        {
            txtTipoFacTecnico.Enabled = lactiva;
            txtPuntajeFacTec.Enabled = lactiva;
            cboTipoPedido.Enabled = !lactiva;
            chcVigente.Enabled = lactiva;
        }

        private void HabilitarControlCriEva(bool lactiva)
        {
            txtDesCriEva.Enabled = lactiva;
            txtPuntCreEva.Enabled = lactiva;
            chcCritVigente.Enabled = lactiva;
        }

        private void habilitarBotones(bool lActivo)
        {
            btnNuevoTipProc.Enabled = lActivo;
            btnEditarTipProc.Enabled = lActivo;
            btnGrabarTipPro.Enabled = !lActivo;
            btnCancelar.Enabled = !lActivo;
        }

        private void habilitarBotones_CriEva(bool lActivo)
        {
            btnNuevoCriEva.Enabled = lActivo;
            btnEditarCriEva.Enabled = lActivo;
            btnGrabarCritEva.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;
        }

        #endregion

    }
}
