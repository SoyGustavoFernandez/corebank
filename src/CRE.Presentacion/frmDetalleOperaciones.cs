using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDetalleOperaciones : frmBase
    {
        List<ReportParameter> paramlist = new List<ReportParameter>();
      
        int idCargo = clsVarGlobal.User.idCargo;
        int idAgencia = clsVarGlobal.nIdAgencia;

        public frmDetalleOperaciones()
        {
            InitializeComponent();
            dFecIni.Value = clsVarGlobal.dFecSystem;
            dFecFin.Value = clsVarGlobal.dFecSystem;
        }

        Boolean Valida()
        {
            if (dFecFin.Value<dFecIni.Value)
	            {
                    MessageBox.Show("Fecha Final debe ser mayor a la Fecha Inicial");                  
                    return false;
	            }
            return true;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }
            idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            parametros();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobranza", new clsRPTCNCredito().CNRptCobranza(dFecIni.Value, dFecFin.Value,idAgencia)));
            string reportpath = "RptDetalleOperaciones.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        private void btnResumen_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }
            idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            parametros();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsOperaciones", new clsRPTCNCredito().CNRptResumenCobranza(dFecIni.Value, dFecFin.Value, idAgencia)));
            string reportpath = "RptResumenOperaciones.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        void parametros()
        {
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", cboAgencia1.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
        }

        private void frmDetalleOperaciones_Load(object sender, EventArgs e)
        {
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
    }
}
