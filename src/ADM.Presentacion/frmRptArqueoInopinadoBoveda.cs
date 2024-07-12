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
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmRptArqueoInopinadoBoveda : frmBase
    {
        #region variables
        clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        private string cTipoSupervision = "ArqueoBoveda";
        #endregion

        #region Metodos
        public frmRptArqueoInopinadoBoveda()
        {
            InitializeComponent();
        }

        #endregion

        /**********************************************************************************************/
        #region Eventos

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtRptResultado = clsVisita.rptArqueoInopinado(
               this.conFiltroSupervision1.getZonaSelect(),
               this.conFiltroSupervision1.getAgenciaSelect(),
               this.conFiltroSupervision1.getEstablecimientoSelect(),
                this.conFiltroSupervision1.getSupervisorSelect(),
                this.conFiltroSupervision1.getEstadoSelect(),
                cTipoSupervision,
                this.conFiltroSupervision1.getFechaIni(),
                this.conFiltroSupervision1.getFechaFin()
                );

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cTipoArqueo", "BÓVEDA", false));

            if (dtRptResultado.Rows.Count > 0)
            {
                dtslist.Add(new ReportDataSource("dtDatosResultado", dtRptResultado));
                string reportpath = "rptArqueoInopinado.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontró ningún resultado.", "Reporte de Resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmRptArqueoInopinadoBoveda_Load(object sender, EventArgs e)
        {
            conFiltroSupervision1.setearDatos(clsVarApl.dicVarGen["cPerfilSupervisionOficina"], clsVarGlobal.PerfilUsu.idPerfil, true, cTipoSupervision);
        }
        #endregion
    }
}
