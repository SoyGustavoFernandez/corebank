using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmReporteMovDinElec : frmBase
    {
        clsCNControlOpe cnControlOpe = new clsCNControlOpe();
        DataTable dtMovimientos = new DataTable();

        public frmReporteMovDinElec()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpInicio.Value) > Convert.ToDateTime(dtpFin.Value))
            {
                MessageBox.Show("La fecha inicio no puede ser mayor a la fecha final", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtMovimientos = cnControlOpe.reporteDineroElect(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value));
                
            if (dtMovimientos.Rows.Count > 0)
            {
                String cTitulo = "Reporte de movimientos de dinero electronico del " + dtpInicio.Value.ToShortDateString() + " al " + dtpFin.Value.ToShortDateString();
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsMovimientos", dtMovimientos));

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramList.Add(new ReportParameter("cTitulo", cTitulo, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptPonerSacarDineroElectronico.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("El reporte no tiene datos que mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void frmReporteMovDinElec_Load(object sender, EventArgs e)
        {
            dtpFin.Value = dtpInicio.Value = clsVarGlobal.dFecSystem;
        }
    }
}
