using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using DEP.CapaNegocio;
using RPT.CapaNegocio;
namespace DEP.Presentacion
{
    public partial class frmRptValoradosGenerados : frmBase
    {
        #region Variables Globales
        private DataTable dtValorados;
        clsCNValorados objValorados = new clsCNValorados(); 
        #endregion
        #region Constructor
        public frmRptValoradosGenerados()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {            
            if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha Final", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date; 
                return;
            }
            if (this.dtpFechaInicio.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha del Sistema", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idtipoValorado = (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            
            string reportpath = "";

            if (idtipoValorado == 1)
            {
                dtValorados = objValorados.CNListaValoradosGeneradosOP(idTipoMoneda, idAgencia, dFechaInicio, dFechaFin);
                reportpath = "rptValoradosGeneradosOP.rdlc";
            }
            else if (idtipoValorado == 2)
            {
                dtValorados = objValorados.CNListaValoradosGeneradoCertificadoPF(idTipoMoneda, idAgencia, dFechaInicio, dFechaFin);
                reportpath = "rptValoradosGeneradosCertificadosPF.rdlc";
            }
            else
            {
                MessageBox.Show("Tipo de valorado no valido", "Reporte de Valorados Generados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            

            if (dtValorados.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Valorados Generados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {                
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaFinal", dFechaFin.ToString(), false));
                paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("idTipoMoneda", idTipoMoneda.ToString(), false));                
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsListaValoradosGenerados", dtValorados));

             
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                this.dtValorados.Dispose(); 
            }     
        }

        #endregion

        private void RptValoradosGenerados_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencia.AgenciasYTodos();
            cboMoneda1.MonedasYTodos(); 
        }
    }
}
