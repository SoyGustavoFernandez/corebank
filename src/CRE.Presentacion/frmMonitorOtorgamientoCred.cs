using CRE.CapaNegocio;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace CRE.Presentacion
{
    public partial class frmMonitorOtorgamientoCred : frmBase
    {
        private int nTipoConsulta = 0;
        private clsCNMonitorOtorgamientoCred objCNMonitorOtorgCred = new clsCNMonitorOtorgamientoCred();
        private List<clsResumOtorgamientosEtapa> lstResumOtorgEtapa = new List<clsResumOtorgamientosEtapa>();
        private List<clsResumOtorgamientosNivel> lstResumOtorgNivel = new List<clsResumOtorgamientosNivel>();

        public frmMonitorOtorgamientoCred()
        {
            InitializeComponent();

            //this.cboAgencias.FiltrarPorZona(5);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ObtSegmtoFlujoOtorgCred();
            this.GraficarTuberia();
        }

        private void tbcPrincipal_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.tbcPrincipal.SelectedIndex == 0)
            {
                this.nTipoConsulta = 0;
            }
            else if (this.tbcPrincipal.SelectedIndex == 1)
            {
                this.nTipoConsulta = 1;
            }
        }

        private void ObtSegmtoFlujoOtorgCred()
        {
            /*int idUsuario = Convert.ToInt32(this.cboAsesor.SelectedValue);
            int idAgencia = Convert.ToInt32(this.cboOficina.SelectedValue);
            int idZona = Convert.ToInt32(this.cboRegion.SelectedValue);*/

            int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idZona = Convert.ToInt32(cboZona.SelectedValue);


            if(this.nTipoConsulta == 0)
            {
                lstResumOtorgEtapa = objCNMonitorOtorgCred.ObtSegmtoFlujoOtorgCredEtapa(idUsuario, idAgencia,idZona,nTipoConsulta);
                this.bindingResumOtorgamientosEtapa.DataSource = lstResumOtorgEtapa;
                this.dtgEtapas.Refresh();
            }
            else if (this.nTipoConsulta == 1)
            {
                lstResumOtorgNivel = objCNMonitorOtorgCred.ObtSegmtoFlujoOtorgCredNivel(idUsuario, idAgencia,idZona,nTipoConsulta);
                this.bindingResumOtorgamientosNivel.DataSource = lstResumOtorgNivel;
                this.dtgEtapas.Refresh();
            }
        }

        private void GraficarTuberia()
        {
            if (this.nTipoConsulta == 0)
            {
                this.chtMtorOtorgCredEtapas.DataSource = this.lstResumOtorgEtapa;

                this.chtMtorOtorgCredEtapas.Series["sreSolicitud"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreSolicitud"].YValueMembers = "nSolicitud";
                //this.chtMtorOtorgCredEtapas.Series["sreSolicitud"].ChartType = SeriesChartType.StackedArea100;

                this.chtMtorOtorgCredEtapas.Series["sreEvaluacion"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreEvaluacion"].YValueMembers = "nEvaluacion";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;

                this.chtMtorOtorgCredEtapas.Series["sreXComite"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreXComite"].YValueMembers = "nParaComite";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;

                this.chtMtorOtorgCredEtapas.Series["sreComite"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreComite"].YValueMembers = "nEnComite";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Series["sreAprobacion"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreAprobacion"].YValueMembers = "nAprobacion";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Series["sreRevision"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreRevision"].YValueMembers = "nRevision";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Series["sreAprobado"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreAprobado"].YValueMembers = "nAprobados";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Series["sreDenegado"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreDenegado"].YValueMembers = "nDenegados";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Series["sreDesembolsado"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredEtapas.Series["sreDesembolsado"].YValueMembers = "nDesemboldados";
                //this.chtMtorOtorgCredEtapas.Series["Series1"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredEtapas.Titles.Clear();
                this.chtMtorOtorgCredEtapas.Titles.Add("Total de Acumulados en Tuberia por Etapa");
                this.chtMtorOtorgCredEtapas.DataBind();
            }
            else if (this.nTipoConsulta == 1)
            {
                this.chtMtorOtorgCredNiveles.DataSource = this.lstResumOtorgNivel;

                this.chtMtorOtorgCredNiveles.Series["sreAsesor"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreAsesor"].YValueMembers = "nAsesorNeg";
                //this.chtMtorOtorgCredNiveles.Series["sreAsesor"].ChartType = SeriesChartType.StackedArea100;

                this.chtMtorOtorgCredNiveles.Series["sreCoordCred"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreCoordCred"].YValueMembers = "nCoordCred";
                //this.chtMtorOtorgCredNiveles.Series["sreCoordCred"].ChartType = SeriesChartType.Bar;

                this.chtMtorOtorgCredNiveles.Series["sreJefeOfi"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreJefeOfi"].YValueMembers = "idJefeOficina";
                //this.chtMtorOtorgCredNiveles.Series["sreJefeOfi"].ChartType = SeriesChartType.Bar;

                this.chtMtorOtorgCredNiveles.Series["sreGrteReg"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreGrteReg"].YValueMembers = "nGrteRegional";
                //this.chtMtorOtorgCredNiveles.Series["sreGrteReg"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredNiveles.Series["sreEvaluador"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreEvaluador"].YValueMembers = "nEvaluador";
                //this.chtMtorOtorgCredNiveles.Series["sreEvaluador"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredNiveles.Series["sreJefeCred"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreJefeCred"].YValueMembers = "nJefeCreditos";
                //this.chtMtorOtorgCredNiveles.Series["sreJefeCred"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredNiveles.Series["sreGrteNeg"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreGrteNeg"].YValueMembers = "nGrteNegocios";
                //this.chtMtorOtorgCredNiveles.Series["sreGrteNeg"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredNiveles.Series["sreGrteGral"].XValueMember = "cGrupo";
                this.chtMtorOtorgCredNiveles.Series["sreGrteGral"].YValueMembers = "nGrteGeneral";
                //this.chtMtorOtorgCredNiveles.Series["sreGrteGral"].ChartType = SeriesChartType.Bar;*/

                this.chtMtorOtorgCredNiveles.Titles.Clear();
                this.chtMtorOtorgCredNiveles.Titles.Add("Total de Acumulados en Tuberia por Nivel");
                this.chtMtorOtorgCredNiveles.DataBind();
            }
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZona = Convert.ToInt32(this.cboZona.SelectedValue);
            if (idZona < 0)
            {
                this.btnBuscar.Enabled = false;
                this.btnImprimir.Enabled = false;
                return;
            }
            else
            {
                this.btnBuscar.Enabled = true;
                this.btnImprimir.Enabled = true;
                this.cboAgencias.FiltrarPorZona(idZona, true);
            }
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue);
            this.cboPersonalCreditos.ListarPersonal(idAgencia, true);
        }

        private void dtgEtapas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 1) return;

            //MessageBox.Show("Index =  "+e.ColumnIndex);

            int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int nTipoConsulta = 0;
            int nIndiceTabla = e.ColumnIndex;


            DataTable dtRes = objCNMonitorOtorgCred.SeguimientoSolicitudCred(idUsuario, idAgencia,idZona,nTipoConsulta, nIndiceTabla);

            if (dtRes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(),false ));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            paramlist.Add(new ReportParameter("nTipoConsulta", nTipoConsulta.ToString(), false));
            paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtRes));

            string reportpath = "rptSeguimientoSolicitudCred.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void dtgNiveles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 0) return;

            //MessageBox.Show("Index =  "+e.ColumnIndex);

            int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int nTipoConsulta = 1;
            int nIndiceTabla = e.ColumnIndex;


            DataTable dtRes = objCNMonitorOtorgCred.SeguimientoSolicitudCred(idUsuario, idAgencia, idZona, nTipoConsulta, nIndiceTabla);

            if (dtRes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            paramlist.Add(new ReportParameter("nTipoConsulta", nTipoConsulta.ToString(), false));
            paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtRes));

            string reportpath = "rptSeguimientoSolicitudCred.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int nTipoConsulta = 0;
            //int nIndiceTabla = e.ColumnIndex;


            DataTable dtRes = objCNMonitorOtorgCred.RptMonitorOtorgamientoCred(idUsuario, idAgencia, idZona, nTipoConsulta);

            if (dtRes.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString(), false));
            paramlist.Add(new ReportParameter("nTipoConsulta", nTipoConsulta.ToString(), false));
            //paramlist.Add(new ReportParameter("nIndiceTabla", nIndiceTabla.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtRes));

            string reportpath = "rptMonitorOtorgamientoCred.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmMonitorOtorgamientoCred_Load(object sender, EventArgs e)
        {
            this.cboAgencias.DataSource = null;
            this.cboPersonalCreditos.DataSource = null;
            this.cboZona.AgregarNingunoTodos();
        }
    }
}
