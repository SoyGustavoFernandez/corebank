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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmArqueoPagares : frmBase
    {
        clsCNControlExp cnControlExp = new clsCNControlExp();
        public frmArqueoPagares()
        {
            InitializeComponent();
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;

            //
            DataTable dtFiltro = new DataTable();
            dtFiltro.Columns.Add("idFiltro", typeof(int));
            dtFiltro.Columns.Add("cFiltro", typeof(string));

            DataRow dr = dtFiltro.NewRow();
            dr["idFiltro"] = 0;
            dr["cFiltro"] = "** TODOS **";
            dtFiltro.Rows.Add(dr);
            DataRow dr2 = dtFiltro.NewRow();
            dr2["idFiltro"] = 1;
            dr2["cFiltro"] = "CANCELADOS";
            dtFiltro.Rows.Add(dr2);
            DataRow dr3 = dtFiltro.NewRow();
            dr3["idFiltro"] = 2;
            dr3["cFiltro"] = "VIGENTES";
            dtFiltro.Rows.Add(dr3);

            cboFiltro.ValueMember = dtFiltro.Columns[0].ToString();
            cboFiltro.DisplayMember = dtFiltro.Columns[1].ToString();
            cboFiltro.DataSource = dtFiltro;

            DataTable dtPagares = new DataTable();
            dtPagares.Columns.Add("idPagare", typeof(int));
            dtPagares.Columns.Add("cPagare", typeof(string));

            DataRow dp = dtPagares.NewRow();
            dp["idPagare"] = 0;
            dp["cPagare"] = "** TODOS **";
            dtPagares.Rows.Add(dp);
            DataRow dp2 = dtPagares.NewRow();
            dp2["idPagare"] = 1;
            dp2["cPagare"] = "CON PAGARE";
            dtPagares.Rows.Add(dp2);
            DataRow dp3 = dtPagares.NewRow();
            dp3["idPagare"] = 2;
            dp3["cPagare"] = "SIN PAGARE";
            dtPagares.Rows.Add(dp3);

            cboPagares.ValueMember = dtPagares.Columns[0].ToString();
            cboPagares.DisplayMember = dtPagares.Columns[1].ToString();
            cboPagares.DataSource = dtPagares;
            cboMoneda.MonedasYTodos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin" , "Reporte de Pagares Para Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una oficina", "Reporte de Pagares Para Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una moneda", "Reporte de Pagares Para Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string reportpath = "rptPagaresParaArqueo.rdlc";
            
            DateTime dFechaInicio = dtpFechaInicio.Value;
            DateTime dFechafin = dtpFechaFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            int idFiltro = Convert.ToInt32(cboFiltro.SelectedValue);
            int nPagare = Convert.ToInt32(cboPagares.SelectedValue);

            DataTable dtRpt = cnControlExp.CNRptPagaresParaArqueo(dFechaInicio, dFechafin, idAgencia, idMoneda, idFiltro, nPagare);
            if (dtRpt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró resultados para el reporte", "Reporte de Pagares Para Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                
            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsReportePagaresArqueo", dtRpt));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
