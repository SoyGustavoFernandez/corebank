using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
namespace CRE.Presentacion
{
    public partial class frmCarteraVigente : frmBase
    {

        public int idPerfilUsu = clsVarGlobal.User.idCargo;
        public frmCarteraVigente()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechBus = this.dtpCorto1.Value;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            if (idPerfilUsu == 6 & dFechBus < clsVarGlobal.dFecSystem)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                String CodAna = "";

                foreach (DataRowView item in chklAsesores1.CheckedItems)
                {
                    CodAna += (item.Row["idUsuario"] + ",");
                }
                if (string.IsNullOrEmpty(CodAna))
                {
                    MessageBox.Show("Debe seleccionar por lo menos un asesor");
                    return;
                }
                dtslist.Add(new ReportDataSource("dtsCarAnalista", new clsRPTCNCredito().CNCarteraVigente(CodAna, dFechBus)));
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                String CodAna = "";

                foreach (DataRowView item in chklAsesores1.CheckedItems)
                {
                    CodAna += (item.Row["idUsuario"] + ",");
                }

                if (string.IsNullOrEmpty(CodAna))
                {
                    MessageBox.Show("Debe seleccionar por lo menos un asesor");
                    return;
                }
                dtslist.Add(new ReportDataSource("dtsCarAnalista", new clsRPTCNCredito().CNCarteraVigente(CodAna)));
            }

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptLisCreCliVig.rdlc";
            new frmReporteLocal(dtslist, reportpath).ShowDialog();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            Boolean chSelec = true;
            chSelec = chcTodos.Checked;
            for (int i = 0; i < chklAsesores1.Items.Count; ++i)
                chklAsesores1.SetItemChecked(i, chSelec);
        }

        private void frmCarteraVigente_Load(object sender, EventArgs e)
        {
            if (idPerfilUsu == 6)
            {
                this.cboAgencia1.Enabled = true;
                this.dtpCorto1.Enabled = true;
            }
            else 
            {
                this.cboAgencia1.Enabled = false;
                this.cboAgencia1.SelectedValue = clsVarGlobal.nIdAgencia;
                this.dtpCorto1.Enabled = false;
            }
            this.dtpCorto1.Value = clsVarGlobal.dFecSystem;
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chklAsesores1.CargarDatos((int)this.cboAgencia1.SelectedValue);
        }
    }
}
