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

namespace CNT.Presentacion
{
    public partial class frmOperacionesRemotas : frmBase
    {
        public frmOperacionesRemotas()
        {
            InitializeComponent();
        }

        private void frmOperacionesRemotas_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        Boolean Valida()
        {
            Boolean lEstado = true;
            if (dtpFecFin.Value < dtpFecIni.Value)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la fecha inicial");
                lEstado = false;
                return lEstado;
            }
            return lEstado;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string reportpath;
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsOperacionesRemotas", new clsRPTCNCredito().CNRptOperaRemotas(dtpFecIni.Value, dtpFecFin.Value)));

            reportpath = "RptOperacionesRemotas.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();           
        }

    }
}
