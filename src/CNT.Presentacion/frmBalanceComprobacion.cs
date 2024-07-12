using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmBalanceComprobacion : frmBase
    {
        public frmBalanceComprobacion()
        {
            InitializeComponent();
            cboMonedas.CargaDatosContaIntegrado();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida balance de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            int idMoneda = (int)cboMonedas.SelectedValue;
            int idAgencia = (int)cboAgencia.SelectedValue;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsBalanceComprobacion", new clsRPTCNContabilidad().CNBalanceComprobacion(dFecha, idMoneda, idAgencia))); 
            
            string reportpath = "RptBalanceComprobacion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void frmBalanceComprobacion_Load(object sender, EventArgs e)
        {
            this.dtpFecSistema.Value = clsVarGlobal.dFecSystem;
            cboMonedas.CargaDatosContaTodos();
        }

        private void cboMonedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboMonedas.SelectedIndex == 2)
            //{
            //    chcBMonOriginal.Visible = true;
            //}
            //else
            //{
            //    chcBMonOriginal.Visible = false;
            //    chcBMonOriginal.Checked = false;
            //}
        }
    }
}
