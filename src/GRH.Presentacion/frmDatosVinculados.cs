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
using GRH.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

using Microsoft.Reporting.WinForms;

namespace GRH.Presentacion
{
    public partial class frmDatosVinculados : frmBase
    {
        public frmDatosVinculados()
        {
            InitializeComponent();

            cmbEstado.SelectedIndex = 0;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            
            int estado_int = cmbEstado.SelectedIndex + 1;
            
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("estado", Convert.ToString(estado_int), false));
            
            DataTable dtRptdsVinculados = new clsCNDatosVinculados().CNDatosVinculados(estado_int);
            //DataTable vinculados = new clsCNDatosVinculados().CNDatosVinculados();
        
            dtslist.Add(new ReportDataSource("dsVinculados",dtRptdsVinculados) );

            string reportpath = "rptDatosVinculados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}

