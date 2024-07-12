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
    public partial class frmSaldoAnalistas : frmBase
    {
        int idCargo = clsVarGlobal.User.idCargo;
        Boolean lNivelReporte = false;

        public frmSaldoAnalistas()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> listPar = new List<ReportParameter>();

            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Clear();
            DateTime dFecha = dtpFechaProceso.Value;
            Int32 idAgePar = Convert.ToInt32(cboAgencia1.SelectedValue);
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));

            string reportpath = "";
            if (idAgePar > 0)
            {
                dtslist.Add(new ReportDataSource("dtsSaldo", new clsRPTCNCredito().CNSaldoCartera(dFecha, idAgePar)));
                reportpath = "RptSaldoCarteraAnalista.rdlc";
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtsSaldoDesembolso", new clsRPTCNCredito().CNSaldoCartera(dFecha)));
                reportpath = "RptSaldoCarteraOficina.rdlc";
            }
            new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            dtslist.Clear();

            int idAgencia = (int)cboAgencia1.SelectedValue;
            if (idAgencia == 0)
            {
                MessageBox.Show("Seleccione una Agencia");
                return;
            }

            DateTime dFecha = dtpFechaProceso.Value;
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsDetCreAna", new clsRPTCNCredito().CNCarteraAnalistas(dFecha, idAgencia)));

            string reportpath = "RptDetalleCarteraAnalista.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
        }

        private void frmSaldoAnalistas_Load(object sender, EventArgs e)
        {
            //if (idCargo == 1 || idCargo == 2 || idCargo == 3)
            //{
            //    cboAgencia1.SelectedValue = clsVarGlobal.nIdAgencia;
            //    cboAgencia1.Enabled = false;
            //}
            //else
            //{
            //    cboAgencia1.Enabled = true;
            //    cboAgencia1.SelectedValue = 0;
            //}
        }
    }
}
