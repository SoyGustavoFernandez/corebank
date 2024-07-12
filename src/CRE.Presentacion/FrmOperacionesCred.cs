using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class FrmOperacionesCred : frmBase
    {
        public int idPerfilUsu = clsVarGlobal.User.idCargo;
        public FrmOperacionesCred()
        {
            InitializeComponent();         
        }

        private void FrmOperacionesCred_Load(object sender, EventArgs e)
        {
            if (idPerfilUsu == 6)
            {
                this.cboAgencia1.Enabled = true;
            }
            else
            {
                this.cboAgencia1.Enabled = false;
                this.cboAgencia1.SelectedValue = clsVarGlobal.nIdAgencia;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime pdFecBus = clsVarGlobal.dFecSystem;
            Int32 idAgencia = (int)cboAgencia1.SelectedValue;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dFecBus", pdFecBus.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsOpeCred", new clsRPTCNCredito().CNRptListaOperac(idAgencia, pdFecBus)));

            string reportpath = "RptLisOpeCred.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
