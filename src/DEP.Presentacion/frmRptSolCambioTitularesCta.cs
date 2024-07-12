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
    public partial class frmRptSolCambioTitularesCta : frmBase
    {
        clsCNDeposito clsCNDeposito = new clsCNDeposito();

        public frmRptSolCambioTitularesCta()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
        }        

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.cboAgencias.SelectedIndex == -1)
	        {
		        MessageBox.Show("Seleccione una Oficina antes de continuar", "Reporte de Solicitudes de Cambio de Titulares de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
	        }

            if (this.dtFechaInicial.Value > this.dtFechaFinal.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta", "Reporte de Solicitudes de Cambio de Titulares de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            
            int idAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue);
            string cAgencia = this.cboAgencias.Text;
            DateTime dFechaInicial = this.dtFechaInicial.Value;
            DateTime dFechaFinal = this.dtFechaFinal.Value;
            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;

            DataTable dtSolCambioTitularesCta = clsCNDeposito.CNRptSolCambioTitularesCta(idAgencia, dFechaInicial, dFechaFinal);
            if (dtSolCambioTitularesCta.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaInicial", dFechaInicial.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFinal", dFechaFinal.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsSolCambioTitularesCta", dtSolCambioTitularesCta));

                string reportpath = "RptSolCambioTitularesCta.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Solicitudes de Cambio de Titulares de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
