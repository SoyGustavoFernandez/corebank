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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptGrupoSolidarioBono : frmBase
    {
        #region Varaibles Globales
        private clsCNGrupoSolidario objCNGrupoSolidario;
        #endregion
        public frmRptGrupoSolidarioBono()
        {
            InitializeComponent();
            this.inicializarDatos();
        }        
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNGrupoSolidario = new clsCNGrupoSolidario();
            this.dtpFechaInicio.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            this.dtpFechaFin.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddMonths(1).AddDays(-1);
        }
        private void imprimir()
        {

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string cTitulo = "Bono de Grupo Solidario";


            DataTable dtRptGrupoSolidarioBono = this.objCNGrupoSolidario.rptGrupoSolidarioBono(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);

            if(dtRptGrupoSolidarioBono.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaInicio", this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cTitulo", cTitulo, false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("DSGrupoSolidarioBono", dtRptGrupoSolidarioBono));

            string reportpath = "RptGrupoSolidarioBono.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimir();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
