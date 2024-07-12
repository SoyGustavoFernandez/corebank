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
    public partial class frmSolicitudPendientes : frmBase
    {
        int idCargo = clsVarGlobal.User.idCargo;
        int idAgencia = clsVarGlobal.nIdAgencia;

        public frmSolicitudPendientes()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {            
            Int32 idAgePar = Convert.ToInt32(cboAgencia1.SelectedValue);

            string reportpath = "";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            if (idAgePar == 0)
            {
                reportpath = "rptSolicitudPendienteAge.rdlc";
                dtslist.Add(new ReportDataSource("dtsSolPendiente", new clsRPTCNCredito().CNSolicitudesPendientes()));
            }
            else
            {
                paramlist.Add(new ReportParameter("idAgencia", idAgePar.ToString(), false));
                reportpath = "rptSolicitudPendiente.rdlc";
                dtslist.Add(new ReportDataSource("dtsSolPendiente", new clsRPTCNCredito().CNSolicitudesPendientes(idAgePar)));
            }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmSolicitudPendientes_Load(object sender, EventArgs e)
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
