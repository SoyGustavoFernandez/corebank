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
    public partial class frmVinculaCtasContablesPlanillas : frmBase
    {
        clsCNPlantillaCuentaAsientoPlanilla objPlantillaCuentaAsiento = new clsCNPlantillaCuentaAsientoPlanilla();
        
        DataTable dtPlantillaCtaCtb;

        public frmVinculaCtasContablesPlanillas()
        {
            InitializeComponent();
        }

        private void CargarPlantillaCtaCtb()
        {
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
            int idConcepto = Convert.ToInt32(cboConceptoRemunerativo.SelectedValue);
            dtPlantillaCtaCtb = objPlantillaCuentaAsiento.CNListarPlantillaCuentaAsientoPlanilla(idTipoPlanilla, idConcepto);
            dtgPlantillaCtaCtb.DataSource = dtPlantillaCtaCtb;
        }
        private void ActualizarPlantillaCtaCtb()
        {
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
            int idConcepto = Convert.ToInt32(cboConceptoRemunerativo.SelectedValue);
            DataSet dsPlantillaCtaCtb = new DataSet("dsPlantillaCtaCtb");
            dsPlantillaCtaCtb.Tables.Add(dtPlantillaCtaCtb);
            string xmlPlantillaCtaCtb = dsPlantillaCtaCtb.GetXml();
            xmlPlantillaCtaCtb = clsCNFormatoXML.EncodingXML(xmlPlantillaCtaCtb);
            dsPlantillaCtaCtb.Tables.Clear();

            DataTable dtActPlantilla = objPlantillaCuentaAsiento.CNActualizarPlantillaCuentaAsientoPlanilla(idTipoPlanilla, idConcepto, xmlPlantillaCtaCtb);

            MessageBox.Show(dtActPlantilla.Rows[0]["cMensaje"].ToString(), "Asignación de Cuentas Contables de Planillas", MessageBoxButtons.OK, ((int)dtActPlantilla.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void HabilitarControles(bool lHabilitar)
        {
            if (cboConceptoRemunerativo.Items.Count > 0)
            {
                btnEditar.Enabled = !lHabilitar;
                btnGrabar.Enabled = lHabilitar;
                btnCancelar.Enabled = lHabilitar;

                btnAgregar.Enabled = lHabilitar;
                btnQuitar.Enabled = lHabilitar;

                cboRelacionLabInst.Enabled = !lHabilitar;
                cboTipoPlanilla.Enabled = !lHabilitar;
                cboConceptoRemunerativo.Enabled = !lHabilitar;

                dtgPlantillaCtaCtb.ReadOnly = !lHabilitar;

                if (dtPlantillaCtaCtb.Rows.Count > 0)
                {
                    dtPlantillaCtaCtb.Columns["cCtaDebe"].ReadOnly = !lHabilitar;
                    dtPlantillaCtaCtb.Columns["cTipSegDebe"].ReadOnly = !lHabilitar;
                    dtPlantillaCtaCtb.Columns["cCtaHaber"].ReadOnly = !lHabilitar;
                    dtPlantillaCtaCtb.Columns["cTipSegHaber"].ReadOnly = !lHabilitar;
                } 
            }
        }

        private void frmVinculaCtasContablesPlanillas_Load(object sender, EventArgs e)
        {
            clsCNTipoAfectacionCuentaCtb TipoAfectacionCuentaCtb = new clsCNTipoAfectacionCuentaCtb();

            DataTable dtTipoAfectacionDebe = TipoAfectacionCuentaCtb.CNListarTipoAfectacionCuentaCtb();
            dtgcboTipSegDebe.DataSource = dtTipoAfectacionDebe;
            dtgcboTipSegDebe.ValueMember = dtTipoAfectacionDebe.Columns["idTipoAfectacion"].ToString();
            dtgcboTipSegDebe.DisplayMember = dtTipoAfectacionDebe.Columns["cDesTipoAfectacion"].ToString();

            DataTable dtTipoAfectacionHaber = TipoAfectacionCuentaCtb.CNListarTipoAfectacionCuentaCtb();
            dtgcboTipSegHaber.DataSource = dtTipoAfectacionHaber;
            dtgcboTipSegHaber.ValueMember = dtTipoAfectacionHaber.Columns["idTipoAfectacion"].ToString();
            dtgcboTipSegHaber.DisplayMember = dtTipoAfectacionHaber.Columns["cDesTipoAfectacion"].ToString();

            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();

            this.ControlBox = false;
            
            HabilitarControles(false);
        }

        private void cboRelacionLabInst1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.ValueMember == "" || cboRelacionLabInst.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));

                if (cboTipoPlanilla.Items.Count == 0)
                {
                    cboConceptoRemunerativo.DataSource = null;
                    btnEditar.Enabled = false;
                }
            }
        }

        private void cboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPlanilla.ValueMember == "" || cboTipoPlanilla.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboConceptoRemunerativo.ListarConceptoTipoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
                if (cboConceptoRemunerativo.Items.Count == 0)
                {
                    dtgPlantillaCtaCtb.DataSource = null;
                    btnEditar.Enabled = false;
                }
                else
                {
                    btnEditar.Enabled = true;
                }
            }
        }

        private void cboConceptoRemunerativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConceptoRemunerativo.ValueMember == "" || cboConceptoRemunerativo.DisplayMember == "")
            {
                return;
            }
            else
            {
                CargarPlantillaCtaCtb();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow dr = dtPlantillaCtaCtb.NewRow();
            dr["cCtaDebe"] = "";
            dr["cTipSegDebe"] = "";
            dr["cCtaHaber"] = "";
            dr["cTipSegHaber"] = "";

            dtPlantillaCtaCtb.Rows.Add(dr);

            if (dtPlantillaCtaCtb.Rows.Count == 1)
            {
                dtPlantillaCtaCtb.Columns["cCtaDebe"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cTipSegDebe"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cCtaHaber"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cTipSegHaber"].ReadOnly = false;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgPlantillaCtaCtb.Rows.Count > 0)
            {
                this.dtgPlantillaCtaCtb.Rows.Remove(dtgPlantillaCtaCtb.CurrentRow);
                this.dtgPlantillaCtaCtb.Refresh();
            }
        }

        private void dtgPlantillaCtaCtb_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            dtgPlantillaCtaCtb.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            ActualizarPlantillaCtaCtb();
            CargarPlantillaCtaCtb();
            dtgPlantillaCtaCtb.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarPlantillaCtaCtb();
            HabilitarControles(false);
            dtgPlantillaCtaCtb.Enabled = false;
        }

        private void dtgPlantillaCtaCtb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPlantillaCtaCtb.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgPlantillaCtaCtb.Columns[e.ColumnIndex].DisplayIndex) == 0)
            {
                frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                frmBscCtaCtb.ShowDialog();
                if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                dtgPlantillaCtaCtb.CurrentRow.Cells["dtgtxtCtaDebe"].Value = frmBscCtaCtb.pcCtaCtb;
            }
            if (dtgPlantillaCtaCtb.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgPlantillaCtaCtb.Columns[e.ColumnIndex].DisplayIndex) == 3)
            {
                frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                frmBscCtaCtb.ShowDialog();
                if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                dtgPlantillaCtaCtb.CurrentRow.Cells["dtgtxtCtaHaber"].Value = frmBscCtaCtb.pcCtaCtb;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
          
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmVinculaCtasContablesPlanillas_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
