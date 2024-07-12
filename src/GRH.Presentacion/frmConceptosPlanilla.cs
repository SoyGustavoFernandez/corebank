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
    public partial class frmConceptosPlanilla : frmBase
    {
        clsCNConceptoRemunerativo objConceptoRemunerativo = new clsCNConceptoRemunerativo();

        DataTable dtConceptoPlanilla;

        public frmConceptosPlanilla()
        {
            InitializeComponent();
        }

        public void CargarConceptoPlanilla()
        {
            dtConceptoPlanilla = objConceptoRemunerativo.CNListarConceptoTipoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
            dtgConceptoPlanilla.DataSource = dtConceptoPlanilla;

            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void frmConceptosPlanilla_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
        }

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.ValueMember == "" || cboRelacionLabInst.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
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
                CargarConceptoPlanilla();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dtConceptoPlanilla.Columns["lAfectoSNP"].ReadOnly = false;
            dtConceptoPlanilla.Columns["lAfectoSPP"].ReadOnly = false;
            dtConceptoPlanilla.Columns["lAfectoQuinta"].ReadOnly = false;
            dtConceptoPlanilla.Columns["lAfectoEssalud"].ReadOnly = false;
            dtConceptoPlanilla.Columns["lAfectoIES"].ReadOnly = false;
            dtConceptoPlanilla.Columns["cCodSunat"].ReadOnly = false;
            dtConceptoPlanilla.Columns["lVigente"].ReadOnly = false;
            
            dtgConceptoPlanilla.ReadOnly = false;

            dtgConceptoPlanilla.Columns["dtgtxtConcepto"].ReadOnly = true;
            dtgConceptoPlanilla.Columns["dtgtxtTipoConcepto"].ReadOnly = true;

            foreach (DataGridViewRow row in dtgConceptoPlanilla.Rows)
            {
                int idTipoConcepto = Convert.ToInt32(row.Cells["dtgtxtIdTipoConcepto"].Value);

                if (idTipoConcepto != 1)
                {
                    row.Cells["dtgchcAfectoSNP"].ReadOnly = true;
                    row.Cells["dtgchcAfectoSPP"].ReadOnly = true;
                    row.Cells["dtgchcAfectoQuinta"].ReadOnly = true;
                    row.Cells["dtgchcAfectoEssalud"].ReadOnly = true;
                    row.Cells["dtgchcAfectoIES"].ReadOnly = true;
                }
            }

            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            dtgConceptoPlanilla.ReadOnly = true;

            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            DataSet dsConceptoPlanilla = new DataSet("dsConceptoPlanilla");
            dsConceptoPlanilla.Tables.Add(dtConceptoPlanilla);
            String xmlConceptoPlanilla = dsConceptoPlanilla.GetXml();
            xmlConceptoPlanilla = clsCNFormatoXML.EncodingXML(xmlConceptoPlanilla);

            DataTable dtRegistrarConceptoPlanilla = objConceptoRemunerativo.CNRegistrarConceptoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue), xmlConceptoPlanilla);
            MessageBox.Show(dtRegistrarConceptoPlanilla.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Conceptos por Tipo de Planilla", MessageBoxButtons.OK, ((int)dtRegistrarConceptoPlanilla.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            
            CargarConceptoPlanilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtgConceptoPlanilla.ReadOnly = true;

            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }
    }
}
