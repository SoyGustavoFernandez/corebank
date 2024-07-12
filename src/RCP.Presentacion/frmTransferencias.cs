using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmTransferencias : frmBase
    {
        clsCNTranferencias cnTranferencias = new clsCNTranferencias();
        int idDtgSeleccionado = -1;
        public frmTransferencias()
        {
            InitializeComponent();
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            dtgResumenTransferencia.DataSource = cnTranferencias.ListarResumenTransferencia();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (idDtgSeleccionado > -1)
            {
                int idResumenTransferencia = Convert.ToInt32(dtgResumenTransferencia.Rows[idDtgSeleccionado].Cells["idResumenAsigCartRecuperaciones"].Value);
                DataTable dtCredTransferencia = cnTranferencias.ListaCreditosTransferencia(idResumenTransferencia);
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();
                
                paramlist.Add(new ReportParameter("FechaTransferencia", dtgResumenTransferencia.Rows[idDtgSeleccionado].Cells["dFecha"].Value.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            
                dtslist.Add(new ReportDataSource("dsCreditosTransferidosRecu", dtCredTransferencia));

                string reportpath = "rptTransferenciaCarteraRecuperaciones.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una tranferencia", "Reporte Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
        }

        private void dtgResumenTransferencia_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idDtgSeleccionado = e.RowIndex;
        }
    }
}
