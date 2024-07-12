using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteDocumentosCTS : frmBase
    {
        public frmReporteDocumentosCTS()
        {
            InitializeComponent();
        }

        private void frmReporteDocumentosCTS_Load(object sender, EventArgs e)
        {
            this.inicializaComboBoxEstadoRegDocCTS();
        }

        private void inicializaComboBoxEstadoRegDocCTS()
        {
            DataTable dtEstRegDocCTS = new DataTable();
            dtEstRegDocCTS.Columns.Add("Value");
            dtEstRegDocCTS.Columns.Add("Descripcion");

            dtEstRegDocCTS.Rows.Add("1", "Pendientes de Envio y Firma");
            dtEstRegDocCTS.Rows.Add("2", "Pendientes de Envio");
            dtEstRegDocCTS.Rows.Add("3", "Pendientes de Firma");

            cboEstadoRegDocCTS.DataSource = dtEstRegDocCTS;
            cboEstadoRegDocCTS.ValueMember = dtEstRegDocCTS.Columns["Value"].ToString();
            cboEstadoRegDocCTS.DisplayMember = dtEstRegDocCTS.Columns["Descripcion"].ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.cboEstadoRegDocCTS.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado antes de continuar", "Reporte de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            DataRow drTemp = ((DataRowView)cboEstadoRegDocCTS.SelectedItem).Row;            
            int nEstado = Convert.ToInt32(drTemp["Value"]);
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaIni = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            int idAgencia = (int)cboAgencia1.SelectedValue;
           

            DataTable dtRegDocCTS = new clsCNRegDocumentoCTS().CNReporteRegDocumentosCTS(nEstado, dFechaIni, dFechaFin, idAgencia);

            if (dtRegDocCTS.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Registro de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsListaRegDocumentosCTS", dtRegDocCTS));

                string reportpath = "rptRegDocumentosCTS.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
