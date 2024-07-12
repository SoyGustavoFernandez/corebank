using EntityLayer;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class FrmConfigProdEvalScoring : frmBase
    {

        #region Variables

        private clsCNScoring _objCnScoring;
        private const string cTituloMsjes = "Validación de datos";

        #endregion

        #region Constructores

        public FrmConfigProdEvalScoring()
        {
            InitializeComponent();
            cboModulo.CargarProducto(0);
            _objCnScoring = new clsCNScoring();

            Load += FrmConfigProdEvalScoring_Load;
        }

        #endregion

        #region Eventos

        private void FrmConfigProdEvalScoring_Load(object sender, EventArgs e)
        {
            cboModulo.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboSubTipo.SelectedIndex = -1;
            cboTipProd.SelectedIndex = -1;

            cboModulo.SelectedIndexChanged += CboModulo_SelectedIndexChanged;
            cboTipo.SelectedIndexChanged += CboTipo_SelectedIndexChanged;
            cboSubTipo.SelectedIndexChanged += CboSubTipo_SelectedIndexChanged;

            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnGrabar.Click += btnGrabar_Click;
            btnActualizar.Click += btnActualizar_Click;

            cboModulo.SelectedValue = 1;

            GetData();

            HabilitarControles(false);

            btnNuevo.Enabled = true;
            btnEditar.Enabled = dtgConfig.RowCount > 0;
            btnCancelar.Enabled = false;
        }

        private void CboSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipo.SelectedIndex >= 0)
            {
                int idSubTipo = (int)cboSubTipo.SelectedValue;
                cboTipProd.CargarProducto(idSubTipo, false, false);
            }
        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex >= 0)
            {
                int idTipo = (int)cboTipo.SelectedValue;
                cboSubTipo.CargarProducto(idTipo, false, false);
            }
        }

        private void CboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex >= 0)
            {
                int idModulo = (int)cboModulo.SelectedValue;
                cboTipo.CargarProducto(idModulo, false, false);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IniciarRegistro(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            IniciarRegistro(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarRegistro();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GrabarRegistro();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetData();
        }

        #endregion

        #region Métodos privados

        private void GetData()
        {
            dtgConfig.SelectionChanged -= DtgConfig_SelectionChanged;

            DataTable dtData = _objCnScoring.GetConfigProductoEvalScoring(0);
            dtgConfig.DataSource = dtData;
            FormatGridViewData();
            MapDataToControls();

            dtgConfig.SelectionChanged += DtgConfig_SelectionChanged;
        }

        private void DtgConfig_SelectionChanged(object sender, EventArgs e)
        {
            MapDataToControls();
        }

        private void FormatGridViewData()
        {
            foreach (DataGridViewColumn column in dtgConfig.Columns)
            {
                column.Visible = false;
            }

            dtgConfig.Columns["cProducto"] .Visible = true;
            dtgConfig.Columns["nPonderado"].Visible = true;
            dtgConfig.Columns["lVigente"].Visible = true;

            dtgConfig.Columns["cProducto"].HeaderText = "Producto";
            dtgConfig.Columns["nPonderado"].HeaderText = "Ponderado";
            dtgConfig.Columns["lVigente"].HeaderText = "Vigente";

            dtgConfig.Columns["cProducto"].FillWeight = 70;
            dtgConfig.Columns["nPonderado"].FillWeight = 15;
            dtgConfig.Columns["lVigente"].FillWeight = 15;

            dtgConfig.Columns["nPonderado"].DefaultCellStyle.Format = "#,0.00";
        }

        private void MapDataToControls()
        {
            LimpiarCampos();
            if (dtgConfig.SelectedRows.Count > 0)
            {
                DataRowView row = dtgConfig.SelectedRows[0].DataBoundItem as DataRowView;
                cboModulo.SelectedValue = (int)row["idModulo"];
                cboTipo.SelectedValue = (int)row["idTipo"];
                cboSubTipo.SelectedValue = (int)row["idSubTipo"];
                cboTipProd.SelectedValue = (int)row["idProducto"];
                nudPonderado.Value = (decimal)row["nPonderado"];
                chcVigente.Checked = (bool)row["lVigente"];
            }
        }

        private void GrabarRegistro()
        {
            if (!Validar())
                return;

            int idProducto = (int)cboTipProd.SelectedValue;
            decimal nPonderado = nudPonderado.Value;
            bool lVigente = chcVigente.Checked;

            clsDBResp objDbResp = _objCnScoring.SaveConfigProductoEvalScoring(idProducto, nPonderado, lVigente);
            MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK,
                            objDbResp.nMsje == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (objDbResp.nMsje == 0)
            {
                CancelarRegistro();
                GetData();
            }
        }

        private bool Validar()
        {
            if(cboTipProd.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el sub tipo de producto.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            cboModulo.SelectedIndexChanged -= CboModulo_SelectedIndexChanged;
            cboTipo.SelectedIndexChanged -= CboTipo_SelectedIndexChanged;
            cboSubTipo.SelectedIndexChanged -= CboSubTipo_SelectedIndexChanged;

            cboModulo.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboSubTipo.SelectedIndex = -1;
            cboTipProd.SelectedIndex = -1;

            nudPonderado.Value = 0;
            chcVigente.Checked = true;

            cboModulo.SelectedIndexChanged += CboModulo_SelectedIndexChanged;
            cboTipo.SelectedIndexChanged += CboTipo_SelectedIndexChanged;
            cboSubTipo.SelectedIndexChanged += CboSubTipo_SelectedIndexChanged;
        }

        private void HabilitarControles(bool lHabil)
        {
            cboModulo.Enabled = lHabil;
            cboTipo.Enabled = lHabil;
            cboSubTipo.Enabled = lHabil;
            cboTipProd.Enabled = lHabil;
            nudPonderado.Enabled = lHabil;
            chcVigente.Enabled = lHabil;
            dtgConfig.Enabled = !lHabil;
        }

        private void CancelarRegistro()
        {
            MapDataToControls();
            HabilitarControles(false);

            btnNuevo.Enabled = true;
            btnEditar.Enabled = dtgConfig.RowCount > 0;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            dtgConfig.Focus();
        }

        private void IniciarRegistro(bool lNuevo)
        {
            if (lNuevo)
                LimpiarCampos();

            HabilitarControles(true);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        #endregion

    }
}
