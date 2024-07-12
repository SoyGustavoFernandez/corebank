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
    public partial class frmLibroTributoPagar : frmBase
    {
        public frmLibroTributoPagar()
        {
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;

            dtslist.Add(new ReportDataSource("dtsTributoXPagar", new clsRPTCNContabilidad().CNLibroTributosPagar(dFecIni, dFecFin)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFechaFin", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            string reportpath = "RptLibroTributoPagar.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
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

      
    }
}
