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
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CLI.Presentacion
{
    public partial class frmRptCliCodSBSDif : frmBase
    {
        clsRPTCNClientes Cliente = new clsRPTCNClientes();
        public frmRptCliCodSBSDif()
        {
            InitializeComponent();
        }

        private void frmRptCliCodSBSDif_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //Validar
            if (dtpFecIni.Value>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que el sistema","Reporte de clientes",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpFecIni.Value>dtpFecFin.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final","Reporte de clientes",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            DateTime dFechaIni = dtpFecIni.Value;
            DateTime dFechaFin = dtpFecFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            string cNombreAge = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            //Procesar
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("x_dFechaIni",dFechaIni.ToString("dd-MM-yyyy"),false));
            paramlist.Add(new ReportParameter("x_dFechaFin",dFechaFin.ToString("dd-MM-yyyy"),false));
            paramlist.Add(new ReportParameter("x_idAgencia",idAgencia.ToString(),false));
            paramlist.Add(new ReportParameter("x_cNomAgen",cNombreAge,false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd-MM-yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsCliCodSBSDif", Cliente.CNReporteCliCodSBSDif(dFechaIni, dFechaFin, idAgencia)));
           
            string reportpath = "rptCliCodSBSDif.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir1.Enabled = true;

        }

    }
}
