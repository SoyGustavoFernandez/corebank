using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace SER.Presentacion
{
    public partial class frmRptListGiros : frmBase
    {
        public frmRptListGiros()
        {
            InitializeComponent();
        }

        private void frmRptListGiros_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboEstablecimientoGiro1.CargarConTodosYPrincipal();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no Puede Ser Mayor que la Fecha Final", "Reporte de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int idAgencia = Convert.ToInt16(cboEstablecimientoGiro1.SelectedValue),
                idMoneda = Convert.ToInt16(cboMoneda.SelectedValue),
                idEstado = 0;


            DateTime dFecInicio = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtGiros = new clsRPTCNServicioGiros().CNDatosGiros(dFecInicio, dFecFin, idAgencia, idEstado,idMoneda);
            if (dtGiros.Rows.Count>0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecIni", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idAge", idAgencia.ToString(), false));                
                paramlist.Add(new ReportParameter("idEst", idEstado.ToString(), false));
                paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                //paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("DsGiros", dtGiros));

                string reportpath = "RptGiros.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
