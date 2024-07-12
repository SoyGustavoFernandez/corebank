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
    public partial class frmMantenimientoConceptoPersona : frmBase
    {
        clsCNConceptoRemunerativo objConceptoRemunerativo = new clsCNConceptoRemunerativo();
        DataTable dtConceptoPersona;

        public frmMantenimientoConceptoPersona()
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

        private void CargarConceptoRemunerativo()
        {
            if (conBusPerson.txtCod.Text == "")
            {
                conBusPerson.txtCod.Text = "0";
            }
            dtConceptoPersona = objConceptoRemunerativo.CNListarConceptoPersona(Convert.ToInt32(conBusPerson.txtCod.Text));
            dtgConceptoPersona.DataSource = dtConceptoPersona;

            if (dtConceptoPersona.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
            }
        }

        private void frmMantenimientoConceptoPersona_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void conBusPerson_BuscarUsuario(object sender, EventArgs e)
        {
            CargarConceptoRemunerativo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conBusPerson.HabilitarControles(false);
            dtConceptoPersona.Columns["nMonto"].ReadOnly = false;
            dtgConceptoPersona.ReadOnly = false;
            dtgConceptoPersona.Columns["dtgtxtTipoConcepto"].ReadOnly = true;
            dtgConceptoPersona.Columns["dtgtxtConcepto"].ReadOnly = true;
            dtgConceptoPersona.Columns["dtgtxtMonto"].ReadOnly = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            conBusPerson.HabilitarControles(true);
            dtgConceptoPersona.ReadOnly = true;
            dtgtxtMonto.ReadOnly = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            DataSet ds = new DataSet("dsConceptoPersona");
            ds.Tables.Add(dtConceptoPersona);
            String xmlConceptoPersona = ds.GetXml();
            xmlConceptoPersona = clsCNFormatoXML.EncodingXML(xmlConceptoPersona);

            DataTable dtRegistraConceptoPersona = objConceptoRemunerativo.CNRegistrarConceptoPersona(Convert.ToInt32(conBusPerson.txtCod.Text), xmlConceptoPersona);
            MessageBox.Show(dtRegistraConceptoPersona.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Conceptos por Persona", MessageBoxButtons.OK, ((int)dtRegistraConceptoPersona.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtRegistraConceptoPersona.Rows[0]["idError"] != 0) return;
            CargarConceptoRemunerativo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusPerson.HabilitarControles(true);
            dtgConceptoPersona.ReadOnly = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            CargarConceptoRemunerativo();
        }

        private void dtgConceptoPersona_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgConceptoPersona_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 nfila = e.RowIndex;

            if (nfila == -1)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.dtgConceptoPersona.Rows[nfila].Cells["dtgtxtMonto"].Value.ToString()))
            {
                this.dtgConceptoPersona.Rows[nfila].Cells["dtgtxtMonto"].Value = 0.00;
            }
        }
    }
}
