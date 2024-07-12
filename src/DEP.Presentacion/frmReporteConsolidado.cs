using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmReporteConsolidado : frmBase
    {
        int idCargo = clsVarGlobal.User.idCargo;
        int idAgencia = clsVarGlobal.nIdAgencia;

        public frmReporteConsolidado()
        {
            InitializeComponent();
            this.cboProducto1.CargarProducto(16);
        }

        private void frmReporteConsolidado_Load(object sender, EventArgs e)
        {
            this.cboProducto1.SelectedIndex = 1;

            //if (idCargo == 1 || idCargo == 2 || idCargo == 3)
            //{
            //    cboAgencia1.SelectedValue = idAgencia;
            //    cboAgencia1.Enabled = false;
            //}
            //else
            //{
            //    cboAgencia1.Enabled = true;
            //    cboAgencia1.SelectedValue = 0;
            //}

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idAgencia", cboAgencia1.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", this.cboProducto1.SelectedValue.ToString(), false));
            string reportpath;
            if ((int)cboAgencia1.SelectedValue == 0)
            {
                reportpath = "/RPT/RptGerenciaDepositos";
            }
            else
            {
                reportpath = "/RPT/RptGerenciaDepositosAse";
            }
            new frmReporte(paramlist, reportpath).ShowDialog();

        }
    }
}
