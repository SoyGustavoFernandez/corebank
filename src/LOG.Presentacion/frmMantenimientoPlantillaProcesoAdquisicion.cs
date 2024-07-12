using System;
using System.Data;
using System.Windows.Forms;
using GEN.ControlesBase;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmMantenimientoPlantillaProcesoAdquisicion : frmBase
    {

        #region Variables

        private clsCNPlantillaProcesoAdquisicion objPlaTipAdq;
        private const string cTituloDialog = "Mantenimiento Plantilla Proceso Adquisicion";
        private int idPlantilla = 0;

        #endregion

        #region Constructor

        public frmMantenimientoPlantillaProcesoAdquisicion()
        {
            InitializeComponent();
            objPlaTipAdq = new clsCNPlantillaProcesoAdquisicion();
        }

        #endregion

        #region Eventos

        private void frmMantenimientoPlantillaProcesoAdquisicion_Load(object sender, EventArgs e)
        {
            CargarCombos();
            if (cboFiltroTipoProceso.Items.Count > 0)
                cboFiltroTipoProceso.SelectedIndex = 0;
            if (cboFiltroEtapas.Items.Count > 0)
                cboFiltroEtapas.SelectedIndex = 0;
            HabilitarControlesForm(false);
            btnEditar.Enabled = dtgPlantillaProceso.RowCount > 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControlesDetalle();
            HabilitarControlesForm(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControlesForm(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idPlantilla = 0;
            HabilitarControlesForm(false);
            cargarDTG();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            int idtipPro = Convert.ToInt32(cboTipoProceso.SelectedValue);
            int idEtap = Convert.ToInt32(cboEtapas.SelectedValue);
            int idDoc = Convert.ToInt32(cboDocumentos.SelectedValue);
            int nNumDias = Convert.ToInt32(nudNumDias.Value);
            bool chcDocObl = chcDocObligatorio.Checked;
            bool lVigente = chcVigente.Checked;
            DataTable objResult;
            if (idPlantilla > 0)
            {
                objResult = objPlaTipAdq.CNActualizarPlantillaProcAdq(idPlantilla, idtipPro, idEtap, idDoc, nNumDias, chcDocObl, lVigente);
            }
            else
            {
                objResult = objPlaTipAdq.CNRegistrarPlantillaProcAdq(idtipPro, idEtap, idDoc, nNumDias, chcDocObl, lVigente);
            }
            if ((int)objResult.Rows[0]["nResultado"] > 0)
            {
                MessageBox.Show(objResult.Rows[0]["cMensaje"].ToString(), cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                idPlantilla = 0;
                HabilitarControlesForm(false);
                cargarDTG();
            }
            else
            {
                MessageBox.Show(objResult.Rows[0]["cMensaje"].ToString(), cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dtgPlantillaProceso_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgPlantillaProceso.SelectedRows.Count == 0)
                return;

            LimpiarControlesDetalle();
            MapeaRegistro((dtgPlantillaProceso.SelectedRows[0].DataBoundItem as DataRowView).Row);
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDTG();
        }        

        #endregion

        #region Métodos

        private void MapeaRegistro(DataRow dr)
        {
            idPlantilla = (int)dr["idRelProcesoCalendario"];

            cboTipoProceso.SelectedValue = (int)dr["idTipoProceso"];
            cboEtapas.SelectedValue = (int)dr["idEtapaCalendario"];
            cboDocumentos.SelectedValue = (int)dr["idTipoDocProAdqui"];
            nudNumDias.Value = Convert.ToInt32(dr["nDiasEtapa"]);
            chcDocObligatorio.Checked = (bool)dr["lDocObligatorio"];
            chcVigente.Checked = (bool)dr["lVigente"];
        }

        private void LimpiarControlesDetalle()
        {
            cboTipoProceso.SelectedIndex = -1;
            cboEtapas.SelectedIndex = -1;
            cboDocumentos.SelectedIndex = -1;
            nudNumDias.Value = 0;
            chcDocObligatorio.Checked = false;
            chcVigente.Checked = false;
        }

        private void HabilitarControlesForm(bool val)
        {
            cboFiltroTipoProceso.Enabled = !val;
            cboFiltroEtapas.Enabled = !val;

            cboTipoProceso.Enabled = val;
            cboEtapas.Enabled = val;
            cboDocumentos.Enabled = val;
            nudNumDias.Enabled = val;
            chcDocObligatorio.Enabled = val;
            chcVigente.Enabled = val;
            dtgPlantillaProceso.Enabled = !val;

            btnNuevo.Enabled = !val;
            btnEditar.Enabled = !val;
            btnGrabar.Enabled = val;
            btnCancelar.Enabled = val;
        }

        public bool Validar()
        {
            if (cboTipoProceso.SelectedIndex < 0)
            {
                MessageBox.Show("Error Selecione un Tipo de Proceso", cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoProceso.Focus();
                return false;
            }
            if (cboEtapas.SelectedIndex < 0)
            {
                MessageBox.Show("Error Seleccione una Etapa", cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEtapas.Focus();
                return false;
            }
            if (cboDocumentos.SelectedIndex < 0)
            {
                MessageBox.Show("Error Selecione un Documento", cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDocumentos.Focus();
                return false;
            }

            if (nudNumDias.Value <= 0)
            {
                MessageBox.Show("Inserte un número de días mayor a 0", cTituloDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudNumDias.Value = 0;
                nudNumDias.Focus();
                return false;
            }


            return true;
        }

        private void cargarDTG()
        {
            if (cboFiltroTipoProceso.SelectedIndex > -1 && cboFiltroEtapas.SelectedIndex > -1)
            {
                int idTipPro = (int)cboFiltroTipoProceso.SelectedValue;
                int idEtapa = (int)cboFiltroEtapas.SelectedValue;
                DataTable dtPlantilla = objPlaTipAdq.CNCargarPlantilla(idTipPro, idEtapa);

                dtgPlantillaProceso.SelectionChanged -= dtgPlantillaProceso_SelectionChanged;

                dtgPlantillaProceso.DataSource = dtPlantilla;
                dtgPlantillaProceso.ClearSelection();

                dtgPlantillaProceso.SelectionChanged += dtgPlantillaProceso_SelectionChanged;

                if (dtgPlantillaProceso.RowCount > 0)
                    dtgPlantillaProceso.Rows[0].Selected = true;

                btnEditar.Enabled = dtgPlantillaProceso.RowCount > 0;
            }
        }

        public void CargarCombos()
        {
            cargarTipoFiltroProceso();
            cargarFiltroEtapas();
            cargarTipoProceso();
            cargarEtapas();
            cargarDocumentos();
        }

        public void cargarTipoFiltroProceso()
        {
            DataTable dtFiltroTipoProceso = objPlaTipAdq.CNCargarTipoProceso();
            cboFiltroTipoProceso.ValueMember = "idTipoProceso";
            cboFiltroTipoProceso.DisplayMember = "cTipoProceso";
            cboFiltroTipoProceso.DataSource = dtFiltroTipoProceso;
        }

        public void cargarFiltroEtapas()
        {
            DataTable dtFiltroEtapa = objPlaTipAdq.CNCargarEtapas();
            cboFiltroEtapas.ValueMember = "idEtapaCalendario";
            cboFiltroEtapas.DisplayMember = "cEtapaCalendario";
            cboFiltroEtapas.DataSource = dtFiltroEtapa;
        }

        public void cargarTipoProceso()
        {
            DataTable dtTipoProceso = objPlaTipAdq.CNCargarTipoProceso();
            cboTipoProceso.DataSource = dtTipoProceso;
            cboTipoProceso.ValueMember = dtTipoProceso.Columns["idTipoProceso"].ToString();
            cboTipoProceso.DisplayMember = dtTipoProceso.Columns["cTipoProceso"].ToString();
        }

        public void cargarEtapas()
        {
            DataTable dtEtapas = objPlaTipAdq.CNCargarEtapas();
            cboEtapas.DataSource = dtEtapas;
            cboEtapas.ValueMember = dtEtapas.Columns["idEtapaCalendario"].ToString();
            cboEtapas.DisplayMember = dtEtapas.Columns["cEtapaCalendario"].ToString();
        }

        public void cargarDocumentos()
        {
            DataTable dtDocumentos = objPlaTipAdq.CNCargarDocumentos();
            cboDocumentos.DataSource = dtDocumentos;
            cboDocumentos.ValueMember = dtDocumentos.Columns["idTipoDocProAdqui"].ToString();
            cboDocumentos.DisplayMember = dtDocumentos.Columns["cTipoDocProAdqui"].ToString();
        }

        #endregion

    }
}
