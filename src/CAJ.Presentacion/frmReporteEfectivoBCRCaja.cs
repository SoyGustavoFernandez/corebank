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
    public partial class frmReporteEfectivoBCRCaja : frmBase
    {
        public frmReporteEfectivoBCRCaja()
        {
            InitializeComponent();
          
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if ( cboMoneda1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir la moneda","Valida efectivo BCR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            DateTime dFecha= dtpFecha.Value;
            if (dFecha > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida efectivo BCR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
        
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            
            int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string cNombreInstitucion = clsVarApl.dicVarGen["cNomEmpresa"];
            DataTable dtEfectivoBCR = new clsRPTCNCaja().CNRptReporteEfectivoBCRCaja(dFecha, idMoneda);

            paramlist.Add(new ReportParameter("dFechaOpe", dFecha.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cAgenOpe", cNomAgen, false));
            paramlist.Add(new ReportParameter("cNombreInstitucion", cNombreInstitucion, false));

            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsEfectivoBCR", dtEfectivoBCR));
            string reportpath = "rptEfectivoBCR.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmReporteEfectivoBCRCaja_Load(object sender, EventArgs e)
        {
            cboMoneda1.SelectedIndex = -1;
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            
        }
    }
}
