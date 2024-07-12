using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptDetOpeTrasferencia : frmBase
    {
        public frmRptDetOpeTrasferencia()
        {
            InitializeComponent();
        }

        private void frmRptDetalleOpe_Load(object sender, EventArgs e)
        {
            this.dtpFecProc.Value = clsVarGlobal.dFecSystem;
            ListarColAgencia(clsVarGlobal.nIdAgencia);
        }

    
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFecha = this.dtpFecProc.Value;
            int idUsu = Convert.ToInt32(cboColaborador.SelectedValue) ;
            int idAge = clsVarGlobal.nIdAgencia;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsKardex", new clsRPTCNCaja().CNDetallOpeTrasferencias(dFecha, idUsu, idAge)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("cNombre",cboColaborador.Text , false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            
            string reportpath = "rptDetalleOpeTrasferencia.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }
        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);
            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            if (tbColAge.Rows.Count > 0)
            {
                this.cboColaborador.Enabled = true;
            }
            else
            {
                this.cboColaborador.Enabled = false;
            }
        }
    }
}
