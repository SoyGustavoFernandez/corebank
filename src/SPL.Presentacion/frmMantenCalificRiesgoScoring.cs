using EntityLayer;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMantenCalificRiesgoScoring : frmBase
    {

        #region Variables globales

        private string cTituloMensaje = "Mantenimiento de calificativos";
        private string cTipoOperacion = "N";
        private clsCNScoring _cnScoring ;
        private DataTable dtCalificativos;
        private int idCalificativo = 0;

        #endregion

        public frmMantenCalificRiesgoScoring()
        {
            InitializeComponent();
            _cnScoring = new clsCNScoring();
        }

        #region Eventos

        private void frmMantenCalificRiesgoScoring_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            CargarCalificativos();
            CargarCboColor();
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboColor.SelectedValue != null)
                txtColorMuestra.BackColor = Color.FromName(cboColor.SelectedValue.ToString());
            else
                txtColorMuestra.BackColor = Color.FromName("Window");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cTipoOperacion = "N";
            LimpiarControles();
            HabilitarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgCalificativos.Rows.Count <= 0)
            {
                MessageBox.Show("No existen calificativos para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cTipoOperacion = "A";
            HabilitarControles(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                return;
            }

            if (cTipoOperacion == "N")
            {
                DataTable dtInsercion = _cnScoring.GuardaDesCalificacion(0, txtNombreR.Text, nudRangoMin.Value, nudRangoMax.Value, chcAprobacion.Checked, chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cboColor.SelectedValue.ToString());
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(),
                                cTituloMensaje,
                                MessageBoxButtons.OK,
                                ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
            }
            else if (cTipoOperacion == "A")
            {
                DataTable dtInsercion = _cnScoring.GuardaDesCalificacion(idCalificativo, txtNombreR.Text, nudRangoMin.Value, nudRangoMax.Value, chcAprobacion.Checked, chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cboColor.SelectedValue.ToString());
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(),
                                cTituloMensaje,
                                MessageBoxButtons.OK,
                                ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
            }
            cTipoOperacion = "";
            LimpiarControles();
            CargarCalificativos();
            HabilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cTipoOperacion = "N";
            LimpiarControles();
            VerDetalle();
            HabilitarControles(false);
        }

        private void dtgCalificativos_SelectionChanged(object sender, EventArgs e)
        {
            VerDetalle();
        }

        #endregion

        #region Metodos

        private void CargarCalificativos()
        {
            dtCalificativos = _cnScoring.ListaDesCalificacion(0);
            dtgCalificativos.DataSource = dtCalificativos;
            FormatoCalificativos();
        }

        private void FormatoCalificativos()
        {
            foreach (DataGridViewColumn item in dtgCalificativos.Columns)
            {
                item.Visible = false;
            }

            dtgCalificativos.Columns["idCalificativo"].Visible = true;
            dtgCalificativos.Columns["cCalificativo"].Visible = true;
            dtgCalificativos.Columns["nMinCalific"].Visible = true;
            dtgCalificativos.Columns["nMaxCalific"].Visible = true;
            //dtgCalificativos.Columns["lRequiereAprob"].Visible = true;
            dtgCalificativos.Columns["lVigente"].Visible = true;

            dtgCalificativos.Columns["idCalificativo"].FillWeight = 20;
            //dtgCalificativos.Columns["cCalificativo"].FillWeight = 40;
            dtgCalificativos.Columns["nMinCalific"].FillWeight = 40;
            dtgCalificativos.Columns["nMaxCalific"].FillWeight = 40;
            //dtgCalificativos.Columns["lRequiereAprob"].FillWeight = 40;
            dtgCalificativos.Columns["lVigente"].FillWeight = 40;

            dtgCalificativos.Columns["idCalificativo"].HeaderText = "Id";
            dtgCalificativos.Columns["cCalificativo"].HeaderText = "Calificativo";
            dtgCalificativos.Columns["nMinCalific"].HeaderText = "Calific.Min";
            dtgCalificativos.Columns["nMaxCalific"].HeaderText = "Calific.Max";
            //dtgCalificativos.Columns["lRequiereAprob"].HeaderText = "Requiere Aprob.";
            dtgCalificativos.Columns["lVigente"].HeaderText = "Vigencia";
        }

        private void HabilitarControles(bool Val)
        {
            dtgCalificativos.Enabled = !Val;

            txtNombreR.Enabled = Val;
            nudRangoMin.Enabled = Val;
            nudRangoMax.Enabled = Val;
            chcVigencia.Enabled = Val;
            chcAprobacion.Enabled = Val;
            cboColor.Enabled = Val;

            btnNuevo.Enabled = !Val;
            btnEditar.Enabled = !Val;
            btnCancelar.Enabled = Val;
            btnGrabar.Enabled = Val;
        }

        private void LimpiarControles()
        {
            txtNombreR.Clear();
            nudRangoMin.Value = 0.00m;
            nudRangoMax.Value = 0.00m;
            chcVigencia.Checked = true;
            chcVigencia.Checked = false;
            cboColor.SelectedIndex = 0;
        }

        private bool ValidarDatos()
        {
            if (nudRangoMin.Value > nudRangoMax.Value)
            {
                MessageBox.Show("Rango mínimo no puede ser mayor que el rango máximo",
                                    cTituloMensaje,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                nudRangoMax.Focus();
                return true;
            }

            foreach (DataGridViewRow item in dtgCalificativos.Rows)
            {
                if (Convert.ToInt32(item.Cells["idCalificativo"].Value) != idCalificativo
                        && Convert.ToBoolean (item.Cells["lVigente"].Value))
                {
                    if ((Convert.ToDecimal(item.Cells["nMinCalific"].Value) <= nudRangoMin.Value && nudRangoMin.Value <= Convert.ToDecimal(item.Cells["nMaxCalific"].Value))
                    || (Convert.ToDecimal(item.Cells["nMinCalific"].Value) <= nudRangoMax.Value && nudRangoMax.Value <= Convert.ToDecimal(item.Cells["nMaxCalific"].Value)))
                    {
                        MessageBox.Show("Rangos se superponen a rangos existentes",
                                cTituloMensaje,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        nudRangoMin.Focus();
                        return true;
                    }
                }
            }
            return false;
        }

        private void VerDetalle()
        {
            if (dtgCalificativos.SelectedRows.Count > 0)
            {
                idCalificativo = Convert.ToInt32(dtgCalificativos.SelectedRows[0].Cells["idCalificativo"].Value);
                txtNombreR.Text = Convert.ToString(dtgCalificativos.SelectedRows[0].Cells["cCalificativo"].Value);
                nudRangoMin.Value = Convert.ToDecimal(dtgCalificativos.SelectedRows[0].Cells["nMinCalific"].Value);
                nudRangoMax.Value = Convert.ToDecimal(dtgCalificativos.SelectedRows[0].Cells["nMaxCalific"].Value);
                chcVigencia.Checked = Convert.ToBoolean(dtgCalificativos.SelectedRows[0].Cells["lVigente"].Value);
                chcAprobacion.Checked = Convert.ToBoolean(dtgCalificativos.SelectedRows[0].Cells["lRequiereAprob"].Value);
                cboColor.SelectedValue = Convert.ToString(dtgCalificativos.SelectedRows[0].Cells["cColorRiesgo"].Value);
            }
        }

        private void CargarCboColor()
        {
            DataTable dtColor = new DataTable();
            dtColor.Columns.Add("idColor", typeof(string));
            dtColor.Columns.Add("cColor", typeof(string));

            DataRow drTipo = dtColor.NewRow();
            drTipo["idColor"] = "Window";
            drTipo["cColor"] = "";
            dtColor.Rows.Add(drTipo);
            DataRow drTipo1 = dtColor.NewRow();
            drTipo1["idColor"] = "DeepSkyBlue";
            drTipo1["cColor"] = "DeepSkyBlue";
            dtColor.Rows.Add(drTipo1);
            DataRow drTipo11 = dtColor.NewRow();
            drTipo11["idColor"] = "LimeGreen";
            drTipo11["cColor"] = "LimeGreen";
            dtColor.Rows.Add(drTipo11);
            DataRow drTipo2 = dtColor.NewRow();
            drTipo2["idColor"] = "Gold";
            drTipo2["cColor"] = "Gold";
            dtColor.Rows.Add(drTipo2);
            DataRow drTipo3 = dtColor.NewRow();
            drTipo3["idColor"] = "Orange";
            drTipo3["cColor"] = "Orange";
            dtColor.Rows.Add(drTipo3);
            DataRow drTipo4 = dtColor.NewRow();
            drTipo4["idColor"] = "Red";
            drTipo4["cColor"] = "Red";
            dtColor.Rows.Add(drTipo4);

            cboColor.SelectedIndexChanged -= new EventHandler(cboColor_SelectedIndexChanged);

            cboColor.DataSource = dtColor;
            cboColor.DisplayMember = "cColor";
            cboColor.ValueMember = "idColor";

            cboColor.SelectedIndexChanged += new EventHandler(cboColor_SelectedIndexChanged);
        }

        #endregion

    }
}
