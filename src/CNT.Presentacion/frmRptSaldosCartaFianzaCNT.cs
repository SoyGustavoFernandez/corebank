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
    public partial class frmRptSaldosCartaFianzaCNT : frmBase
    {
        String reportpath = "rptSaldosCartaFianza.rdlc";
        public frmRptSaldosCartaFianzaCNT()
        {
            InitializeComponent();
        }

        private void frmSaldosCartaFianza_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            
            DataTable dtSaldoFianza = new clsRPTCNCartaFianza().CNCartaFianza(fecha, idAgencia); 

            if(dtSaldoFianza.Rows.Count != 0)
            {

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", fecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsSaldoCreditoCartaFianza", dtSaldoFianza));
                
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }else
            {
                MessageBox.Show("No existen datos para el reporte", "Saldos Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

        private void lblBase1_Click(object sender, EventArgs e)
        {

        }

        private void lblBase2_Click(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
