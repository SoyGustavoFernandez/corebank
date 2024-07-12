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

namespace CRE.Presentacion
{
    public partial class frmReporteColocaciones : frmBase
    {
        string cTituloMsg = "Control de colocaciones";
        public frmReporteColocaciones()
        {
            InitializeComponent();
            dtpFechaSeleccionada.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }

        private void frmReporteColocaciones_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechaSeleccionada = this.dtpFechaSeleccionada.Value;

            if (dFechaSeleccionada >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Seleccione una fecha anterior a: " + dFechaSeleccionada.ToString("dd/MM/yyyy"), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaSeleccionada.Focus();
                return;
            }
            

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            clsRPTCNCredito rptCredito = new clsRPTCNCredito();
            DataTable dtReporteColocaciones = rptCredito.CNRptColocaciones(dFechaSeleccionada);
            if (dtReporteColocaciones.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                paramlist.Add(new ReportParameter("dFecha", dFechaSeleccionada.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dsControlColocaciones", dtReporteColocaciones));

                string reportpath = "rptControlColocacion.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay colocaciones de créditos para la Fecha " + dFechaSeleccionada.ToString("dd/MM/yyyy"), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaSeleccionada.Focus();
                return;
            }
        }
    }
}
