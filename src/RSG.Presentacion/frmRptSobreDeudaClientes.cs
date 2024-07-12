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
    public partial class frmRptSobreDeudaClientes : frmBase
    {
        #region Varibles globales
        String cTitulo = "Reporte de clientes expuestos a sobreendeudamiento";        
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();        

        #endregion

        public frmRptSobreDeudaClientes()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmRptSobreDeudaClientes_Load(object sender, EventArgs e)
        {
            cboAgencia1.cargarSoloAgencias();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            cargarCliSobreDeuda();
        }

        #endregion

        #region Metodos
        private void cargarCliSobreDeuda()
        {
            Cursor.Current = Cursors.WaitCursor;
            int idAgencia = Convert.ToInt32(this.cboAgencia1.SelectedValue);
            int idTipoPer = Convert.ToInt32(this.cboTipoPersona1.SelectedValue);
            DateTime dFechaCorte = Convert.ToDateTime(DateTime.DaysInMonth(this.conFechaAñoMesCorte.anio, this.conFechaAñoMesCorte.idMes) + "/" + this.conFechaAñoMesCorte.cPeriodo);
            DataTable dtCLiSobreDeuda = sobreendeuda.listaCliSobredeuda(idAgencia, idTipoPer, dFechaCorte.ToString("yyyy-MM-dd"), clsVarGlobal.dFecSystem);
            if (dtCLiSobreDeuda.Rows.Count == 0)
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
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoPer", idTipoPer.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaCorte", dFechaCorte.ToShortDateString().ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DSCliExpSobredeuda", dtCLiSobreDeuda));
            String reportpath = "rptCliExpuestosSobredeuda.rdlc";
            
            Cursor.Current = Cursors.Default;

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion        

    }
}
