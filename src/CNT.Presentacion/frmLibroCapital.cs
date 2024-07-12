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
    public partial class frmLibroCapital : frmBase
    {
        public frmLibroCapital()
        {
            InitializeComponent();
        }
        Boolean Validar()
        {
            if (dtpFecha.Value.Date>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha debe igual o menor a la Fecha del Sistema");
                return false;
            }
            else
	        {
            return true;
	        }
        }
        private void frmLibroDia_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnLibCaja_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecha = dtpFecha.Value.Date;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsCapital", new clsRPTCNContabilidad().CNInvBalCapital(dFecha)));

                string reportpath = "RptLibroCapital.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
