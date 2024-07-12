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

namespace SPL.Presentacion
{
    public partial class frmRptFaltanteRegOpe : frmBase
    {
        clsRPTCNSplaft clsrptcnsplaft = new clsRPTCNSplaft();
        String cTitulo = "Reporte de faltantes";

        public frmRptFaltanteRegOpe()
        {
            InitializeComponent();
        }
        private void frmRptFaltanteRegOpe_Load(object sender, EventArgs e)
        {
            this.cboAgencias1.AgenciasYTodos();
            this.cboModulo1.ListarSoloModulos();
            this.cboMoneda1.MonedasYTodos();
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            DateTime dFechaDesde = Convert.ToDateTime("01/" + this.conFechaAñoMesDesde.cPeriodo);
            DateTime dFechaHasta = Convert.ToDateTime(DateTime.DaysInMonth(this.conFechaAñoMesHasta.anio, this.conFechaAñoMesHasta.idMes) + "/" + this.conFechaAñoMesHasta.cPeriodo);
            int idAgencia = Convert.ToInt32(this.cboAgencias1.SelectedValue);
            int idModulo = Convert.ToInt32(this.cboModulo1.SelectedValue);
            int idMoneda = Convert.ToInt32(this.cboMoneda1.SelectedValue);            
            DataTable dtResultado = clsrptcnsplaft.CNListaFaltantesRegOpe(dFechaDesde, dFechaHasta, idAgencia, idModulo, idMoneda);
            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No hay resultados para esos filtros", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("cNombreAgenciaRpt", Convert.ToString(((DataRowView)this.cboAgencias1.SelectedItem)[this.cboAgencias1.DisplayMember]).ToString(), false));
            
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idModulo", idModulo.ToString(), false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));            

            string reportpath = "rptClientesFaltantesRegOpe.rdlc";
            dtslist.Add(new ReportDataSource("FaltantesRegOpe", dtResultado));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private Boolean validar()
        {
            if ((Convert.ToDateTime(this.conFechaAñoMesDesde.cPeriodo) > Convert.ToDateTime(this.conFechaAñoMesHasta.cPeriodo)))
            {
                MessageBox.Show("La fecha fin no puede ser menor que la fecha inicio", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }     

       

        
    }
}
