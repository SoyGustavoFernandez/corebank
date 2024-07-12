using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GEN.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmMantAccion : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Mantenimiento de tipos de accion.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboAccion.cargarTodos();
            LimpiarControles();
            cboAccion.SelectedIndexChanged -= cboAccion_SelectedIndexChanged;
            cboAccion.SelectedIndex = -1;
            cboAccion.SelectedIndexChanged += cboAccion_SelectedIndexChanged;
            cboAccion.SelectedIndex = cboAccion.Items.Count > 0 ? 0 : -1;
            
            HabilitarControles(false);
            btnEditar.Enabled = cboAccion.Items.Count > 0;
        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAccion.SelectedIndex >= 0 && cboAccion.SelectedValue != null)
            {
                DataRowView dr = (DataRowView)cboAccion.SelectedItem;
                AsignarValoresControles(dr);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            int idTipoAccion = 0;
            string cTipoAccion = String.Empty;
            bool lNotificacion = false;
            bool lVigente = true;
            idTipoAccion = cboAccion.SelectedIndex == -1 ? 0 : Convert.ToInt32(cboAccion.SelectedValue);
            cTipoAccion = txtNomAccion.Text.Trim();
            lNotificacion = chcNotificacion.Checked;
            lVigente = chcVigente.Checked;

            clsDBResp objDbResp = new clsCNAccion().GuardarTipoAccion(idTipoAccion, cTipoAccion, lNotificacion, lVigente);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarControles(false);
                btnEditar.Enabled = cboAccion.Items.Count > 0;
                cboAccion.cargarTodos();
                cboAccion.SelectedIndex = 0;
                AsignarValoresControles((DataRowView)cboAccion.SelectedItem);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboAccion.SelectedIndex = -1;
            LimpiarControles();
            HabilitarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboAccion.SelectedIndex = cboAccion.Items.Count > 0 ? 0 : -1;
            HabilitarControles(false);
            btnEditar.Enabled = cboAccion.Items.Count > 0;
            btnCancelar.Enabled = false;
        }

        #endregion

        #region Metodos

        public frmMantAccion()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtNomAccion.Text))
            {
                MessageBox.Show("Ingrese la descripción del tipo de acción.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txtNomAccion.Text = String.Empty;
            chcVigente.Checked = false;
            chcNotificacion.Checked = false;
        }

        private void HabilitarControles(bool lHabil)
        {
            txtNomAccion.Enabled = lHabil;
            chcNotificacion.Enabled = lHabil;
            chcVigente.Enabled = lHabil;

            btnNuevo.Enabled = !lHabil;
            btnEditar.Enabled = !lHabil;
            btnGrabar.Enabled = lHabil;
            btnCancelar.Enabled = lHabil;
        }

        private void AsignarValoresControles(DataRowView dr)
        {
            txtNomAccion.Text = dr["cTipoAccion"].ToString();
            chcNotificacion.Checked = (bool)dr["lNotificacion"];
            chcVigente.Checked = Convert.ToBoolean(dr["idEstado"]);
        }

        #endregion

    }
}
