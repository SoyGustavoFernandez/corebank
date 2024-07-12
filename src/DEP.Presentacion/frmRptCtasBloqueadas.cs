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
    public partial class frmRptCtasBloqueadas : frmBase
    {
        public frmRptCtasBloqueadas()
        {
            InitializeComponent();
        }

        private void frmRptCtasBloqueadas_Load(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencias1.SelectedIndex = -1;
            cboMoneda1.SelectedIndex = -1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //--Validar Datos
            if (cboAgencias1.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAgencias1.Focus();
                return;
            }
            if (cboMoneda1.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar la Moneda", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMoneda1.Focus();
                return;
            }
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no Puede Ser Mayor que la Fecha Final", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int idAgencia=Convert.ToInt16(cboAgencias1.SelectedValue),
                idMoneda=Convert.ToInt16(cboMoneda1.SelectedValue),
                idTipBloq=1;
            DateTime dFecInicio= Convert.ToDateTime(dtFecInicio.Value);
            DateTime dFecFin = Convert.ToDateTime(dtFecFin.Value);
            string cAgencia = cboAgencias1.Text;
            string cMoneda = cboMoneda1.Text;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtRtp = new clsRPTCNDeposito().CNDatosCtasBloqueadas(idAgencia, idMoneda, idTipBloq, dFecInicio, dFecFin);
            if (dtRtp.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("x_idBloqueo", idTipBloq.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_cMoneda", cMoneda, false));
                paramlist.Add(new ReportParameter("x_dFechaInicio", dFecInicio.ToString("dd/MM/yyyy"),false));
                paramlist.Add(new ReportParameter("x_dFechaFin", dFecFin.ToString("dd/MM/yyyy"),false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsCtasBloq", dtRtp));

                string reportpath = "RptBloqueoCtas.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Cuentas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtFecInicio.Value = DateTime.Now;
            dtFecFin.Value = DateTime.Now;
            cboAgencias1.SelectedIndex = -1;
            cboMoneda1.SelectedIndex = -1;
        }
    }
}
