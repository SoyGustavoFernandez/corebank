using EntityLayer;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class FrmConfigEscalaMontosEvalScoring : frmBase
    {

        #region Variables

        private clsCNScoring _objCnScoring;
        private const string cTituloMsjes = "Validación de datos";
        private int idRegistro = 0;

        #endregion

        #region Constructores

        public FrmConfigEscalaMontosEvalScoring()
        {
            InitializeComponent();

            _objCnScoring = new clsCNScoring();

            Load += FrmConfigEscalaMontosEvalScoring_Load;
        }

        #endregion

        #region Eventos

        private void FrmConfigEscalaMontosEvalScoring_Load(object sender, EventArgs e)
        {
            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnGrabar.Click += btnGrabar_Click;
            btnActualizar.Click += btnActualizar_Click;

            GetData();

            HabilitarControles(false);

            btnNuevo.Enabled = true;
            btnEditar.Enabled = dtgConfig.RowCount > 0;
            btnCancelar.Enabled = false;
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

            DataTable dtData = _objCnScoring.GetEscalaMontosEvalScoring(0);
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

            dtgConfig.Columns["cDescripcion"].Visible = true;
            dtgConfig.Columns["nPonderado"].Visible = true;
            dtgConfig.Columns["lVigente"].Visible = true;

            dtgConfig.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgConfig.Columns["nPonderado"].HeaderText = "Ponderado";
            dtgConfig.Columns["lVigente"].HeaderText = "Vigente";

            dtgConfig.Columns["cDescripcion"].FillWeight = 70;
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
                idRegistro = (int)row["idEscalaMontos"];
                nudValMin.Value = (decimal)row["nRangoMin"];
                nudValMax.Value = (decimal)row["nRangoMax"];
                nudPonderado.Value = (decimal)row["nPonderado"];
                chcVigente.Checked = (bool)row["lVigente"];
            }
        }

        private void GrabarRegistro()
        {
            if (!Validar())
                return;

            decimal nValMin = nudValMin.Value;
            decimal nValMax = nudValMax.Value;
            decimal nPonderado = nudPonderado.Value;
            bool lVigente = chcVigente.Checked;

            clsDBResp objDbResp = _objCnScoring.SaveEscalaMontosEvalScoring(idRegistro, nValMin, nValMax, nPonderado, lVigente);
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
            if (nudValMax.Value <= nudValMin.Value)
            {
                MessageBox.Show("El valor máximo del rango no puede ser menor o igual al valor mínimo.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            nudValMin.Value = 0;
            nudValMax.Value = 0;
            nudPonderado.Value = 0;
            chcVigente.Checked = true;
        }

        private void HabilitarControles(bool lHabil)
        {
            nudValMin.Enabled = lHabil;
            nudValMax.Enabled = lHabil;
            nudPonderado.Enabled = lHabil;
            chcVigente.Enabled = lHabil;
            dtgConfig.Enabled = !lHabil;
        }

        private void CancelarRegistro()
        {
            idRegistro = 0;
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
            {
                idRegistro = 0;
                LimpiarCampos();
            }

            HabilitarControles(true);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        #endregion
    }
}
