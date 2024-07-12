using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmMonitorSobreDeudaSolicitud : frmBase
    {
        #region Varibles globales
        String cTitulo = "Reporte de solicitudes de crédito con riesgo de sobreendeudamiento";
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();
        DataTable dtCuentas;

        #endregion
        public frmMonitorSobreDeudaSolicitud()
        {
            InitializeComponent();
        }
        
        #region Eventos
        private void frmMonitorSobreendeuda_Load(object sender, EventArgs e)
        {                        
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            cargarCliSobreDeuda();
        }
        #endregion

        #region Metodos
        private void cargarCliSobreDeuda()
        {
            if (this.dtpFecIni.Value > this.dtpFecFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idAgencia = Convert.ToInt32(this.cboAgencia1.SelectedValue);
            DataTable dtListaSobreDeuda = sobreendeuda.listaSoliciCreSobredeuda(0, idAgencia , this.dtpFecIni.Value.Date, this.dtpFecFin.Value.Date);
            if (dtListaSobreDeuda.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //this.dtgListaSobreDeuda.DataSource = dtListaSobreDeuda;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idCli", "0", false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("cAgenciaSoli", Convert.ToString(((DataRowView)this.cboAgencia1.SelectedItem)[this.cboAgencia1.DisplayMember]), false));
            paramlist.Add(new ReportParameter("dFechaIni", this.dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", this.dtpFecFin.Value.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DSsolicitudesSobre", dtListaSobreDeuda));
            String reportpath = "rptSoliCreSobredeuda.rdlc";            

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        #endregion

        
        
    }
}
