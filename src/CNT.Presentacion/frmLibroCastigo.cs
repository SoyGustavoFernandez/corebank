using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CNT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;

namespace CNT.Presentacion
{
    public partial class frmLibroCastigo : frmBase
    {
        public frmLibroCastigo()
        {
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
        }
        Boolean Validar()
        {
            if (this.dtpFecIni.Value.Date>this.dtpFecFin.Value.Date)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial");
                return false;
            }
            else
	        {
            return true;
	        }
        }
        private void frmLibroDia_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnLibCaja_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

                paramlist.Add(new ReportParameter("x_dFechaFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsCastigo", new clsRPTCNContabilidad().CNLibroCastigo(dFecIni, dFecFin)));

                string reportpath = "RptLibroCastigos.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
