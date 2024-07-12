using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using GRH.CapaNegocio;
namespace CLI.Presentacion
{
    public partial class frmRptClientesFallecidos : frmBase
    {
        public frmRptClientesFallecidos()
        {
            InitializeComponent();
        }

        private void frmClientesFallecidos_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            dtpFechaDesde.Value = clsVarGlobal.dFecSystem;
            dtpFechaHasta.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechaDesde = this.dtpFechaDesde.Value;
            DateTime dFechaHasta = this.dtpFechaHasta.Value;

            if (dFechaDesde > dFechaHasta)
            {
                MessageBox.Show("La Fecha Desde es más reciente que la Fecha Hasta", "Error Selección de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            clsRPTCNClientes rptClientesFallecidos = new clsRPTCNClientes();
            DataTable dtClientesFallecidos = rptClientesFallecidos.CNRetornoClientesFallecidos(dFechaDesde, dFechaHasta);
            if (dtClientesFallecidos.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNombreAge", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("listClientesFallecidos", dtClientesFallecidos));

                string reportpath = "rptClientesFall.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Personas Clientes Fallecidos", "No se Encontraron Clientes Fallecidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

    }
}
