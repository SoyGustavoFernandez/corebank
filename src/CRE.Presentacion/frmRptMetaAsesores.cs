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
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmRptMetaAsesores : frmBase
    {
        #region Variables
        clsCNMeta cnmeta = new clsCNMeta();
        #endregion

        public frmRptMetaAsesores()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboMes.SelectedValue = clsVarGlobal.dFecSystem.Month;
            nudAnio.Maximum = clsVarGlobal.dFecSystem.Year;
            cboAgencia.AgenciasYTodos();
        }
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = new DateTime(Convert.ToInt32(nudAnio.Value), Convert.ToInt32(cboMes.SelectedValue), 1);
            int idAgencia= Convert.ToInt32(cboAgencia.SelectedValue);

            var dtMetasAsesores=cnmeta.RptMetasAsesores(dFecha,idAgencia);           
            if (dtMetasAsesores.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Reporte de Metas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsMetasAsesores", dtMetasAsesores));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("cAgencia", cboAgencia.Text.ToString(), false));

            string reportpath = "rptMetasAsesores.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }
    }
}
