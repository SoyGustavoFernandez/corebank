#region Referencias
using System;
using System.Collections.Generic;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CLI.CapaNegocio;
using System.Data;
#endregion

namespace CLI.Presentacion
{
    public partial class frmRptSolActCliente : frmBase
    {
        #region Variables Globales
        #endregion
        #region Metodos
        public frmRptSolActCliente()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFechaIni = this.dtpFecIni.Value;
            DateTime dFechaFin = this.dtpFecFin.Value;

            int idZona = Convert.ToInt32(this.cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(this.cboAgencia.SelectedValue);
            int idEstado = 0;
            if (rbtTodos.Checked)
            {
                idEstado = 0;
            }
            else
            {
                if (rbtAprobados.Checked)
                {
                    idEstado = 7;
                }
                else if (rbtRechazados.Checked)
                {
                    idEstado = 40;
                }
                else if (rbtSolicitados.Checked)
                {
                    idEstado = 12;
                }
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFecIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFechaFin.ToString(), false));
                                    
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DataTable dtReporte = new clsCNSolActCliente().CNRptSolActCliente(idZona, idAgencia, dFechaIni, dFechaFin, idEstado);

            dtslist.Add(new ReportDataSource("dsSolActCliente", dtReporte));
            string reportpath = "rptSolActCliente.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }
        private void frmRptSolActCliente_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.cboZona.cargarZona(true, false);
            this.cboAgencia.cargarAgencia(0);
        }
        #endregion
    }
}
