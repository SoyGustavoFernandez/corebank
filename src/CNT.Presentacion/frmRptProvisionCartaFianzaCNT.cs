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
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmRptProvisionCartaFianzaCNT : frmBase
    {
        String reportpath = "rptSaldosProvisionesCartaFianza.rdlc";
        public frmRptProvisionCartaFianzaCNT()
        {
            InitializeComponent();
        }

        private void frmRptProvisionCartaFianzaCNT_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void lblBase1_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            //int idA = 0;
            DataTable dtProvisionFianza = new clsRPTCNProvisionCartaFianza().CNProvisionCartaFianza(fecha, 0 ); //idAgencia el cero es el id de la agencia  

            if (dtProvisionFianza.Rows.Count != 0)
            {

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", fecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsProvisiones", dtProvisionFianza));

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
            else
            {
                MessageBox.Show("No existen datos para el reporte", "Provision Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
