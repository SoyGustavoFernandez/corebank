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
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmConceptosUsuarioPlanillaTmp : frmBase
    {
        public int x_idTipoPlanilla;
        public int x_idUsuario;

        clsCNPlanilla objPlanilla = new clsCNPlanilla();
        DataTable dtConceptosPlanilla;

        public frmConceptosUsuarioPlanillaTmp()
        {
            InitializeComponent();
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cargarConceptosPlanilla()
        {
            dtConceptosPlanilla = objPlanilla.CNListarConceptoUsuarioPlanillaTmp(x_idTipoPlanilla, x_idUsuario);
            dtgConceptosPlanilla.DataSource = dtConceptosPlanilla;

            if (dtConceptosPlanilla.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
            }
        }

        private void dtgConceptosPlanilla_CellValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frmConceptosUsuarioPlanillaTmp_Load(object sender, EventArgs e)
        {
            conBusPersonal.txtCod.Text = x_idUsuario.ToString();
            conBusPersonal.BusPerByCod();
            conBusPersonal.HabilitarControles(false);

            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cargarConceptosPlanilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dtConceptosPlanilla.Columns["nMontoConcepto"].ReadOnly = false;
            dtgConceptosPlanilla.ReadOnly = false;
            dtgConceptosPlanilla.Columns["dtgtxtIdTipoPlanilla"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtIdUsuario"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtIdTipoConcepto"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtTipoConcepto"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtIdConcepto"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtConcepto"].ReadOnly = true;
            dtgConceptosPlanilla.Columns["dtgtxtMontoConcepto"].ReadOnly = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            dtgConceptosPlanilla.ReadOnly = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            DataSet ds = new DataSet("dsConceptosPlanilla");
            ds.Tables.Add(dtConceptosPlanilla);
            String xmlConceptosPlanilla = ds.GetXml();
            xmlConceptosPlanilla = clsCNFormatoXML.EncodingXML(xmlConceptosPlanilla);

            DataTable dtActualizarConceptos = objPlanilla.CNActualizarConceptosUsuarioPlanillaTmp(x_idTipoPlanilla, x_idUsuario, xmlConceptosPlanilla);
            MessageBox.Show(dtActualizarConceptos.Rows[0]["cMensaje"].ToString(), "Detalle de Conceptos por Persona", MessageBoxButtons.OK, ((int)dtActualizarConceptos.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

            cargarConceptosPlanilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtgConceptosPlanilla.ReadOnly = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            cargarConceptosPlanilla();
        }

        private void dtgConceptosPlanilla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgConceptosPlanilla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 nfila = e.RowIndex;

            if (nfila == -1)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.dtgConceptosPlanilla.Rows[nfila].Cells["dtgtxtMontoConcepto"].Value.ToString()))
            {
                this.dtgConceptosPlanilla.Rows[nfila].Cells["dtgtxtMontoConcepto"].Value = 0.00;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
