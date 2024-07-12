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
    public partial class frmClientesCancelados : frmBase
    {
        Boolean lEstado = true;

        public frmClientesCancelados()
        {
            InitializeComponent();
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            Validar();
            if (!lEstado)
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
           
            int idAgencia = clsVarGlobal.nIdAgencia;

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCreCancelados", new clsRPTCNCredito().CNCancelados(idAgencia, dFecIni, dFecFin)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));


            string reportpath = "RptCreditosCancelados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
           
        }
        void Validar()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial","Créditos Cancelados",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                lEstado = false;
            }
            else
            {
                lEstado = true;
            }

        } 

    }
}
