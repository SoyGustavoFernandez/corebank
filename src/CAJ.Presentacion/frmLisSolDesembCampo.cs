using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmLisSolDesembCampo : frmBase
    {
        public Decimal nSumDesembCampo = 0;
        private Int32 nIdUsuAse = 0;
        DataTable dtLisSolDesemCampo = new DataTable();

        public frmLisSolDesembCampo()
        {
            InitializeComponent();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.SumaDesemb(nIdUsuAse);
            if (nSumDesembCampo == 0.00m)
            {
                MessageBox.Show("Hoy no realizará desembolsos en Campo", "Habilitación para Desembolsos en Campo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Dispose();
            
        }
        public void CargaDatos(Int32 nIdAseso)
        {
            nIdUsuAse = nIdAseso;
            clsCNCredito dtLisDescampo = new clsCNCredito();
            dtLisSolDesemCampo = dtLisDescampo.CNdtLisSolDesemCampo(nIdAseso, clsVarGlobal.nIdAgencia);
            dtgBase1.DataSource = dtLisSolDesemCampo;
            dtgBase1.Columns["lSele"].HeaderText = "Sel.";
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgBase1.Columns["nCuotas"].HeaderText = "Num cuotas";
            dtgBase1.Columns["nPlazoCuota"].HeaderText = "Frecuencia";
            dtLisSolDesemCampo.Columns["lSele"].ReadOnly = false;
            this.dtgBase1.Enabled = true;
            this.dtgBase1.ReadOnly = false;
            this.dtgBase1.Columns["lSele"].ReadOnly = false;
        }
        private void SumaDesemb(Int32 nIdAseso)
        {
            Decimal nMonHabilCampo = 0;
            for (int i = 0; i < dtLisSolDesemCampo.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtLisSolDesemCampo.Rows[i]["lSele"]))
                {
                    nMonHabilCampo = Math.Round(nMonHabilCampo + Convert.ToDecimal (dtLisSolDesemCampo.Rows[i]["nCapitalSolicitado"]), 2);
                }
            }           
            nSumDesembCampo = nMonHabilCampo;
            this.txtNumRea1.Text = nSumDesembCampo.ToString();
        }
        private void frmLisSolDesembCampo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            nSumDesembCampo = 0.00m;
            this.Dispose();
        }

        private void dtgBase1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.SumaDesemb(nIdUsuAse);
        }
    }
}
