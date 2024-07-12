using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmReporteEntregaProducto : frmBase
    {
        int idCargo = clsVarGlobal.User.idCargo;
        int idAgencia = clsVarGlobal.nIdAgencia;
        public frmReporteEntregaProducto()
        {
            InitializeComponent();
        }

        private void frmReporteEntregaProducto_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;

            //if (idCargo == 1 || idCargo == 2 || idCargo == 3)
            //{
            //    cboAgencia.SelectedValue = idAgencia;
            //    cboAgencia.Enabled = false;
            //}
            //else
            //{
            //    cboAgencia.Enabled = true;
            //    cboAgencia.SelectedValue = 0;
            //}

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsListadoCanasta", new clsRPTCNDeposito().CNEntregaProducto(this.dtpFecIni.Value,this.dtpFecFin.Value,(int)this.cboAgencia.SelectedValue)));

            string reportpath = "RptEntregaProducto.rdlc";
            new frmReporteLocal(dtslist, reportpath).ShowDialog();
        }
    }
}
