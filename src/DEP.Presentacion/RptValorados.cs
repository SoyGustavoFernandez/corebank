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
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class RptValorados : frmBase
    {

        #region Variables Globales
        private DataTable dtEstsValorados;
        clsCNValorados objValorados = new clsCNValorados();
        //string idEstadoVal = "1";
        #endregion
        
        public RptValorados()
        {
            InitializeComponent();
        }

        private void grbBase2_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha final", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem.Date;
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }
            if (this.dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final de búsqueda no puede ser mayor a la fecha del sistema", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                return;
            }


            int idEstadoVal = (int)this.cboEstValorado1.SelectedValue;
            DateTime dFecIni = this.dtpFechaInicio.Value;
            DateTime dFecFin = this.dtpFechaFin.Value;
            dtEstsValorados = objValorados.CNEstValorados(idEstadoVal, dFecIni, dFecFin, clsVarGlobal.dFecSystem);
            if (dtEstsValorados.Rows.Count<=0)
            {
                MessageBox.Show("No existe datos a mostrar", "Reporte de Valorados Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string cNomAge = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idEstadoVal", idEstadoVal.ToString(), false));
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToString(), false));            
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtEstValorado", dtEstsValorados));

            string reportpath = "rptValorados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            this.dtEstsValorados.Dispose();

        }

        private void RptValorados_Load(object sender, EventArgs e)
        {
            dtpFechaFin.Value=clsVarGlobal.dFecSystem;
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
        }

        
    }
}
