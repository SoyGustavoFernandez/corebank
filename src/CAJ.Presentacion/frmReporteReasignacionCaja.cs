using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using RPT.CapaNegocio;
namespace CAJ.Presentacion
{
    public partial class frmReporteReasignacionCaja : frmBase
    {
        public frmReporteReasignacionCaja()
        {
            InitializeComponent();
            cboAgencias1.AgenciasYTodos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpFechIni.Value;
            DateTime dFecFin = dtpFechFin.Value;

            if (dFecIni > dFecFin)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha final","Valida reasignación de caja",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtReasignaCaja = new clsRPTCNCaja().CNRptListaReasignacionCaja(dFecIni, dFecFin, idAgencia);

            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            
            paramlist.Add(new ReportParameter("dFecProc", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsReasignacionCaja", dtReasignaCaja));
            string reportpath = "rptReasignacionCaja.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
