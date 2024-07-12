using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteGerencial : frmBase
    {
        public frmReporteGerencial()
        {
            InitializeComponent();
            cboProducto1.ProductosYTodos(46);
            cboMoneda1.MonedasYTodos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idAgencia=Convert.ToInt32(cboAgencia1.SelectedValue);
            int idMoneda=Convert.ToInt32(cboMoneda1.SelectedValue);
            DateTime dFecProc=dtFecProceso.Value;
            int idProducto=Convert.ToInt32(cboProducto1.SelectedValue);
            string cNombreAge = clsVarGlobal.cNomAge;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            List<ReportParameter> lstParamentros= new List<ReportParameter>();
            lstParamentros.Clear();
            lstParamentros.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            lstParamentros.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            lstParamentros.Add(new ReportParameter("dFecProc", dFecProc.ToShortDateString(), false));
            lstParamentros.Add(new ReportParameter("idProducto", idProducto.ToString(), false));
            lstParamentros.Add(new ReportParameter("cNombreAge", cNombreAge, false));
            lstParamentros.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            string cRptPath = "rptConcentracionAhoOfiMonPro.rdlc";

            DataTable dtRptGerencial = new clsRPTCNDeposito().CNRptGerencialXOfi(idAgencia, idMoneda, dFecProc, idProducto);
            if (dtRptGerencial.Rows.Count<=0)
            {
                MessageBox.Show("No existen datos para el reporte","Reporte gerencial por oficina",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
            lstDataSource.Clear();
            lstDataSource.Add(new ReportDataSource("dsConcentracionAho", dtRptGerencial));
            new frmReporteLocal(lstDataSource, cRptPath, lstParamentros).ShowDialog();

        }

        private void grbBase2_Enter(object sender, EventArgs e)
        {
           
        }

        private void frmReporteGerencial_Load(object sender, EventArgs e)
        {  
            //cboProducto1.SelectedIndex = 5;
            //cboMoneda1.SelectedIndex = 2;
            dtFecProceso.Value = clsVarGlobal.dFecSystem;
        }
    }
}
