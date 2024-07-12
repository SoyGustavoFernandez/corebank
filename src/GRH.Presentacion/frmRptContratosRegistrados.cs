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
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmRptContratosRegistrados : frmBase
    {
        public frmRptContratosRegistrados()
        {
            InitializeComponent();
        }

      
        private void btnImprFondo_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value ;            
         
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            int idEstContrato = Convert.ToInt32(cboEstado.SelectedValue);

            clsCNBuscaPersonal BuscaPer = new clsCNBuscaPersonal();
            DataTable dtListContratos = new DataTable();

            dtListContratos= BuscaPer.ListarContratosRegistrados(dFechaIni, dFechaFin, idEstContrato);

            if (dtListContratos.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Reporte de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
                paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("idEstadoContrato", idEstContrato.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dtsContratosRegistrados", dtListContratos));

                string reportpath = "rptContratosPerRegistrados.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }          
        }

        private void frmRptContratosRegistrados_Load(object sender, EventArgs e)
        {
            DataTable dtEstContrato = new clsCNBuscaPersonal().ListarEstadoContrato();

            DataRow row = dtEstContrato.NewRow();
            row["idEstadoCon"] = 0;
            row["cEstado"] = "** TODOS **";
            dtEstContrato.Rows.Add(row);
           
            cboEstado.DataSource = dtEstContrato;
            cboEstado.ValueMember = dtEstContrato.Columns[0].ToString();
            cboEstado.DisplayMember = dtEstContrato.Columns[1].ToString();

            cboEstado.SelectedValue = 0;

        }
    }
}
