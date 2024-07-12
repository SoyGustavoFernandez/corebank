using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using System.Data;

namespace CNT.Presentacion
{
    public partial class frmRptCambioPatrimonio : frmBase
    {
        public frmRptCambioPatrimonio()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFecha = dtpFechaSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida cambio de patrimonio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
  
            DataSet dsCamPat = new clsRPTCNContabilidad().CNRptCambioPatrimonio(dFecha,idAgencia,"0100","05");

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsRptCambioPatrimonio", dsCamPat.Tables[0]));

            string reportpath = "rptCambiosPatrimonio.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
