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

namespace DEP.Presentacion
{
    public partial class frmRptCtasRenovadas : frmBase
    {
        public frmRptCtasRenovadas()
        {
            InitializeComponent();
        }

        private void RptCtasRenovadas_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencias.AgenciasYTodos();
            cboMoneda.MonedasYTodos();
            cboAgencias.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no Puede Ser Mayor que la Fecha Final", "Reporte de Renovaciones de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMoneda.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Estado del Traslado de CTS", "Reporte de Renovaciones de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAgencias.SelectedIndex == -1 || cboAgencias.Text == "")
            {
                MessageBox.Show("Seleccione la Agencia", "Reporte de Renovaciones de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string idAgencia = "";
            string idMoneda = "";
            DateTime dFecInicio = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;

            //Obtener idAgencia//
            if (Convert.ToString(cboAgencias.SelectedValue) == "0")
            {
                int i = 1;
                foreach (DataRowView item in cboAgencias.Items)
                {
                    if (i < cboAgencias.Items.Count && i > 0)
                        idAgencia += item[0] + ",";
                    i++;
                }
                idAgencia = idAgencia.Remove((idAgencia.Length - 1), 1);
            }

            else if (Convert.ToString(cboAgencias.SelectedValue) != "0")
                idAgencia = Convert.ToString(cboAgencias.SelectedValue);




            //Obtener idMoneda//
            if (Convert.ToString(cboMoneda.SelectedValue) == "0")
            {
                idMoneda = "[";
                int i = 1;
                foreach (DataRowView item in cboMoneda.Items)
                {
                    if (i < cboMoneda.Items.Count)
                        idMoneda += item[0] + ",";
                    i++;
                }
                idMoneda = idMoneda.Remove((idMoneda.Length - 1), 1) + "]";
            }

            else if (Convert.ToString(cboMoneda.SelectedValue) != "0")
                idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            
            DataTable dtRpt = new clsRPTCNDeposito().CNDatosCtasRenovadas(idAgencia, idMoneda, dFecInicio, dFecFin);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cAgencia", cboAgencias.Text.ToString(), false));
                paramlist.Add(new ReportParameter("x_cMoneda", cboMoneda.Text.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFecIni", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsCtaRenov", dtRpt));

                string reportpath = "RptCtasRenovadas.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte para este intervalo de Fechas", "Reporte de Renovaciones de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
