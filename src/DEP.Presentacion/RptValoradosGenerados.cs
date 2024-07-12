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
namespace DEP.Presentacion
{
    public partial class RptValoradosGenerados : frmBase
    {
        #region Variables Globales
        private DataTable dtValorados;
        clsCNValorados objValorados = new clsCNValorados();
        string cTipoBus = "N";
        #endregion
        #region Constructor
        public RptValoradosGenerados()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if ((int)this.cboAgencia.SelectedValue == 0 && this.chcBase1.Checked == false)
            {
                MessageBox.Show("Seleccione la agencia", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboAgencia.Focus();
                return;
            }
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


            int idAgencia = clsVarGlobal.nIdAgencia;
            int idtipoValorado = (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            dtValorados = objValorados.CNListaValoradosEntregados(cTipoBus, idtipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFin);
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_cTipoBus", cTipoBus.ToString(), false));
            paramlist.Add(new ReportParameter("x_idTipoValorado", idtipoValorado.ToString(), false));
            paramlist.Add(new ReportParameter("x_idTipoMoneda", idTipoMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaInicio", dFechaInicio.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaFinal", dFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNomEmp.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("DataSet1", dtValorados));

            string reportpath = "rptValoradosGenerados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            this.dtValorados.Dispose();
        }


        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked == true)
            {
                cTipoBus = "T";
                this.cboTipoValorado1.Enabled = false;
                this.cboMoneda1.Enabled = false;
                this.cboAgencia.Enabled = false;
            }
            else
            {
                cTipoBus = "N";
                this.cboTipoValorado1.Enabled = true;
                this.cboMoneda1.Enabled = true;
                this.cboAgencia.Enabled = true;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if ((int)this.cboAgencia.SelectedValue == 0 && this.chcBase1.Checked == false)
            {
                MessageBox.Show("Seleccione la agencia", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboAgencia.Focus();
                return;
            }
            if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha Final", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
                return;
            }
            if (this.dtpFechaInicio.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha del Sistema", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                return;
            }
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idtipoValorado = (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            dtValorados = objValorados.CNListaDetalleValorados(cTipoBus, idAgencia, idtipoValorado, idTipoMoneda, dFechaInicio, dFechaFin);
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNomEmp.ToString(), false));
            paramlist.Add(new ReportParameter("x_cTipoBus", cTipoBus.ToString(), false));
            paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_idTipoValorado", idtipoValorado.ToString(), false));
            paramlist.Add(new ReportParameter("x_idMoneda", idTipoMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaIni", dFechaInicio.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaFin", dFechaFin.ToString(), false));


            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("DataSet1", dtValorados));

            string reportpath = "RptDetalleValGenerados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            this.dtValorados.Dispose();
        }
        #endregion

        private void RptValoradosGenerados_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
        }
    }
}
