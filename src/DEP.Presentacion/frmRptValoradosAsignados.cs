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
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
namespace DEP.Presentacion
{
    public partial class frmRptValoradosAsignados : frmBase
    {
        string cTipoBus = "N";
        clsCNValorados objValorados = new clsCNValorados();
        DataView dtValImpresion;
        DataTable dtValorados;
        public frmRptValoradosAsignados()
        {
            InitializeComponent();
        }

        private void frmRptValorados_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if ((int)this.cboAgencia.SelectedIndex ==-1 )
            {
                MessageBox.Show("Debe seleccionar una agencia", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboAgencia.Focus();
                return;
            }
            if (this.dtpFechaInicio.Value> this.dtpFechaFin.Value)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha Final", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date; 
                return;
            }
            if (this.dtpFechaInicio.Value> clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha del Sistema", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }
   
            //--Imprimir Reporte
            int idTipoValorado = (int)this.cboTipoValorado.SelectedValue;
            int idMoneda = (int)this.cboMoneda.SelectedValue;
            int idAgencia = (int)this.cboAgencia.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFinal = this.dtpFechaFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string RutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            dtValorados = objValorados.CNListaValorados(cTipoBus, idTipoValorado, idMoneda, idAgencia, dFechaInicio, dFechaFinal);
            if (dtValorados.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Datos para el criterio de búsqueda", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNomEmp.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", RutaLogo.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFinal", dFechaFinal.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoValorado", idTipoValorado.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_cTipoBus", cTipoBus.ToString(), false));
                                   
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsListValoradosAsignados", dtValorados));
            
            string reportpath = "rptValoradosAsignados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            this.dtValorados.Dispose();
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cboAgencia.SelectedValue = 1;
            this.cboMoneda.SelectedValue = 1;
            this.cboTipoValorado.SelectedValue = 1;
            dtValorados.Dispose();
            dtValImpresion.Dispose();
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.btnImprimir.Enabled = true;
        }

        private void cboTipoValorado1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMoneda.Enabled = true;
            if (cboTipoValorado.SelectedIndex > 0)
            {
                if (Convert.ToInt16(cboTipoValorado.SelectedValue) == 2)
                {
                    cboMoneda.SelectedValue = 1;
                    cboMoneda.Enabled = false;
                }
                else
                {
                    cboMoneda.Enabled = true;
                }

            }
        }
    }
}
