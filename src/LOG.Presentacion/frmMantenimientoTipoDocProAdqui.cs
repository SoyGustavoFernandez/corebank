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
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmMantenimientoTipoDocProAdqui : frmBase
    {
        string cTipOpera = "";

        clsCNTipoDocProAdqui objTipoDocProAdqui = new clsCNTipoDocProAdqui();

        public frmMantenimientoTipoDocProAdqui()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtTipoDocumento.Clear();
            chcVigente.Checked = true;
        }

        private void HabilitarControles(Boolean lHabilitar)
        {
            dtgTipoDocProAdqui.Enabled = !lHabilitar;
            txtTipoDocumento.Enabled = lHabilitar;
            chcVigente.Enabled = lHabilitar;

            btnNuevo.Enabled = !lHabilitar;
            btnEditar.Enabled = !lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;
        }

        private void ListarTipoDocProAdqui()
        {
            DataTable dtTipoDocProAdqui = objTipoDocProAdqui.CNListarTipoDocProAdqui();

            dtgTipoDocProAdqui.DataSource = dtTipoDocProAdqui;
        }

        private void MostrarDatosTipoDocProAdqui()
        {
            if (dtgTipoDocProAdqui.SelectedRows.Count > 0)
            {
                txtTipoDocumento.Text = Convert.ToString(dtgTipoDocProAdqui.CurrentRow.Cells["dtgtxtTipoDocProAdqui"].Value);
                chcVigente.Checked = Convert.ToBoolean(dtgTipoDocProAdqui.CurrentRow.Cells["dtgchcVigente"].Value);

                HabilitarControles(false);
                cTipOpera = "";
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(txtTipoDocumento.Text))
            {
                MessageBox.Show("Ingresar Tipo de Documento", "Mantenimiento de Tipo de Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTipoDocumento.Focus();
                return false;
            }

            return true;
        }

        private void InsertarTipoDocProAdqui(string cTipoDocProAdqui)
        {
            DataTable dtResultado = objTipoDocProAdqui.CNInsertarTipoDocProAdqui(cTipoDocProAdqui);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Tipo de Documento", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void ActualizarTipoDocProAdqui(int idTipoDocProAdqui, string cTipoDocProAdqui, bool lVigente)
        {
            DataTable dtResultado = objTipoDocProAdqui.CNActualizarTipoDocProAdqui(idTipoDocProAdqui, cTipoDocProAdqui, lVigente);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Tipo de Documento", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void frmMantenimientoTipoDocProAdqui_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            ListarTipoDocProAdqui();
        }

        private void dtgTipoDocProAdqui_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosTipoDocProAdqui();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            LimpiarControles();
            cTipOpera = "N";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            cTipOpera = "A";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatosTipoDocProAdqui();
            cTipOpera = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            HabilitarControles(false);
            if (cTipOpera == "N")
            {
                InsertarTipoDocProAdqui(txtTipoDocumento.Text);
            }
            if (cTipOpera == "A")
            {
                int idTipoDocProAdqui = (int)dtgTipoDocProAdqui.CurrentRow.Cells["dtgtxtIdTipoDocProAdqui"].Value;
                ActualizarTipoDocProAdqui(idTipoDocProAdqui, txtTipoDocumento.Text, chcVigente.Checked);
            }
            ListarTipoDocProAdqui();
            cTipOpera = "";
        }
    }
}
