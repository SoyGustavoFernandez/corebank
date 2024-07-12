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
    public partial class frmReporteCreditoColaborador : frmBase
    {
        clsCNControlExp cnControlExp = new clsCNControlExp();
        public frmReporteCreditoColaborador()
        {
            InitializeComponent();

            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;

            DataTable dtFiltro = new DataTable();
            dtFiltro.Columns.Add("idFiltro", typeof(int));
            dtFiltro.Columns.Add("cFiltro", typeof(string));

            DataRow dr = dtFiltro.NewRow();
            dr["idFiltro"] = 0;
            dr["cFiltro"] = "** TODOS **";
            dtFiltro.Rows.Add(dr);
            DataRow dr2 = dtFiltro.NewRow();
            dr2["idFiltro"] = 5;
            dr2["cFiltro"] = "ACTIVOS";
            dtFiltro.Rows.Add(dr2);
            DataRow dr3 = dtFiltro.NewRow();
            dr3["idFiltro"] = 6;
            dr3["cFiltro"] = "CANCELADOS";
            dtFiltro.Rows.Add(dr3);

            cboFiltro.ValueMember = dtFiltro.Columns[0].ToString();
            cboFiltro.DisplayMember = dtFiltro.Columns[1].ToString();
            cboFiltro.DataSource = dtFiltro;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "Reporte Crédito Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una Oficina", "Reporte Crédito Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string reportpath = "rptCreditoColaborador.rdlc";

            DateTime dFechaInicio = dtpFechaInicio.Value;
            DateTime dFechafin = dtpFechaFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstado = Convert.ToInt32(cboFiltro.SelectedValue);


            DataTable dtRpt = cnControlExp.CNRptReporteCreditoColaborador(idEstado,dFechaInicio, dFechafin, idAgencia);
            if (dtRpt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró resultados para el reporte", "Reporte Crédito Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));

            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsReporteCreditoColaborador", dtRpt));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
