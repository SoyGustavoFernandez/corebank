using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPT.CapaNegocio;
namespace GEN.ControlesBase
{
    public class clsRptGrupoSolidario : clsRptEvalInterface
    {
        private int idGrupoSol;
        private int idSolicitud;
        private string cNombreEval;
        private clsCNEvaluacion cnEval;
        private string cNomAgen;
        private Form oParent;
        private int idEvalCredGS;

        private frmReporteLocal frmReporteCualit;
        private frmReporteLocal frmReporteProp;
        private frmReporteLocal frmReporteEEFF;
        private frmReporteLocal frmReporteHTrab;
        private frmReporteLocal frmReporteFCaja;
        /** Docu Online **/
        private frmReporteLocal frmReporteSolicitud;
        private frmReporteLocal frmReporteActaAprob;
        private frmReporteLocal frmReporteOpRiesgos;
        private frmReporteLocal frmReporteOpRecup;
        private frmReporteLocal frmReporteAproRapida;

        private DataSet dsCualit;
        private DataSet dsProp;
        private DataSet dsEEFF;
        private DataSet dsHTrab;
        private DataSet dsFCaja;

        /** Docu Online **/
        private DataSet dsSolicitud;
        private DataSet dsActaAprob;
        private DataSet dsOpRiesgos;
        private DataSet dsOpRecupe;
        private DataSet dsAproRapida;

        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsCNGrupoSolidario objCNGrupoSolidario;

        public clsRptGrupoSolidario(int idEval, int idSol, int idEvalCredGS)
        {
            this.idGrupoSol = idEval;
            this.idSolicitud = idSol;
            this.idEvalCredGS = idEvalCredGS;
            this.cNombreEval = "GRUPO SOLIDARIO";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
        }

        public clsRptGrupoSolidario(int idEval, int idSol, int idEvalCredGS,Form frm)
        {
            this.idGrupoSol = idEval;
            this.idSolicitud = idSol;
            this.idEvalCredGS=idEvalCredGS;
            this.cNombreEval = "GRUPO SOLIDARIO";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
            this.oParent = frm;

            this.frmReporteCualit = null;
            this.frmReporteProp = null;
            this.frmReporteEEFF = null;
            this.frmReporteHTrab = null;
            this.frmReporteFCaja = null;

            this.dsCualit = null;
            this.dsProp = null;
            this.dsEEFF = null;
            this.dsHTrab = null;
            this.dsFCaja = null;
        }

        public void ImpPropuestaEval()
        {
             Cursor.Current = Cursors.WaitCursor;

             if (this.frmReporteProp == null)
            {
            DataSet dsProp = objCNGrupoSolidario.ReporteGrupoSolidario(this.idGrupoSol);//IDGRUPOSOLIDARIO
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cNomUsuario = clsVarGlobal.User.cWinUser;

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("dataGrupoSolidario", dsProp.Tables[0]));
            dtsList.Add(new ReportDataSource("dataIntegrantes", dsProp.Tables[1]));

            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramList.Add(new ReportParameter("idGrupoSolidario", this.idGrupoSol.ToString(), false));
            paramList.Add(new ReportParameter("cNomUsuario", cNomUsuario, false));

            string reportpath = "rptGrupoSolidario.rdlc";
           // new frmReporteLocal(dtsList, reportpath, paramList).ShowDialog();
            this.frmReporteProp = new frmReporteLocal(dtsList, reportpath, paramList);
            this.frmReporteProp.MdiParent = this.oParent;
            this.frmReporteProp.Dock = DockStyle.Fill;
            this.frmReporteProp.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            this.frmReporteProp.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.frmReporteProp.ControlBox = false;
            this.frmReporteProp.ShowIcon = false;
            this.frmReporteProp.Show();
            this.frmReporteProp.WindowState = FormWindowState.Maximized;
            this.frmReporteProp.BringToFront();
            }
            else
            {
                this.frmReporteProp.WindowState = FormWindowState.Maximized;
                this.frmReporteProp.BringToFront();
                this.frmReporteProp.Activate();
            }
            
            Cursor.Current = Cursors.Default;
        }

        public void ImpEvalCualitativa()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteCualit == null)
            {

            DataSet ds = (new clsCNGrupoSolidario()).ObtenerFichaEvalCualitativa(this.idEvalCredGS);

            if (ds.Tables.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", ds.Tables[0]));
                dtsList.Add(new ReportDataSource("dsEvalCualita", ds.Tables[1]));
                dtsList.Add(new ReportDataSource("dsDescripcion", ds.Tables[2]));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", this.idEvalCredGS.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
                //paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptEvalCualitativaGrupoSol.rdlc";
                //new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                this.frmReporteCualit = new frmReporteLocal(dtsList, reportPath, paramlist);
                this.frmReporteCualit.MdiParent = this.oParent;
                this.frmReporteCualit.Dock = DockStyle.Fill;
                this.frmReporteCualit.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                this.frmReporteCualit.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.frmReporteCualit.ControlBox = false;
                this.frmReporteCualit.ShowIcon = false;
                this.frmReporteCualit.Show();
                this.frmReporteCualit.WindowState = FormWindowState.Maximized;
                this.frmReporteCualit.BringToFront();
            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", "Documentacion en línea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            }
            else
            {
                this.frmReporteCualit.WindowState = FormWindowState.Maximized;
                this.frmReporteCualit.BringToFront();
                this.frmReporteCualit.Activate();
            }


            Cursor.Current = Cursors.Default;

        }

        public void ImpEEFF()
        { 
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteEEFF == null)
            {
            clsCNGrupoSolidario cnRep = new clsCNGrupoSolidario();
            string idEval = Convert.ToString(this.idEvalCredGS);
            int nIdEval = Convert.ToInt32(idEval);
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;

            DataTable dtData2 = cnRep.ReporteEvaluacion(nIdEval);
            DataTable dtData3 = cnRep.ReporteEvaluacion3(nIdEval);
            DataTable dtData4 = cnRep.ReporteEvaluacion4(nIdEval);
            DataTable dtData5 = cnRep.ReporteEvaluacion5(nIdEval);
            DataTable dtData6 = cnRep.ReporteEvaluacion6(nIdEval);
            DataTable dtData7 = cnRep.ReporteEvaluacion7(nIdEval);
            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsResEvalGrupal2", dtData2));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal3", dtData3));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal4", dtData4));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData5));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData6));
                dtsList.Add(new ReportDataSource("dsExcepcionesIndividuales", dtData7));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", idEval.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptResuEvalGrupal.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                //new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                this.frmReporteEEFF = new frmReporteLocal(dtsList, reportPath, paramlist);
                this.frmReporteEEFF.MdiParent = this.oParent;
                this.frmReporteEEFF.Dock = DockStyle.Fill;
                this.frmReporteEEFF.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                this.frmReporteEEFF.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.frmReporteEEFF.ControlBox = false;
                this.frmReporteEEFF.ShowIcon = false;
                this.frmReporteEEFF.Show();
                this.frmReporteEEFF.WindowState = FormWindowState.Maximized;
                this.frmReporteEEFF.BringToFront();

            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", "Docuemntos en Línea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
            else
            {
                this.frmReporteEEFF.WindowState = FormWindowState.Maximized;
                this.frmReporteEEFF.BringToFront();
                this.frmReporteEEFF.Activate();
            }


            Cursor.Current = Cursors.Default;
        }

        public void ImpHojaTrabajo()
        {



          }

        public void ImpFlujoCaja()
        {
         }
        public void ImpSolicitud()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteSolicitud == null)
            {
                clsCNGrupoSolidario cnRep = new clsCNGrupoSolidario();
                //int idGrupoSol = this.idEvalCre;//idEvalCre=idGrupoSolidario
                int idSolicitudGrupoSol = Convert.ToInt32(this.idSolicitud);


                DataTable dtData1 = cnRep.ReporteSolicitud1DocuEnLinea(idGrupoSol, idSolicitudGrupoSol);
                DataTable dtData2 = cnRep.ReporteSolicitud2DocuEnLinea(idGrupoSol, idSolicitudGrupoSol);
                DataTable dtData3 = cnRep.ReporteSolicitud3DocuEnLinea(idGrupoSol, idSolicitudGrupoSol);

                if (dtData1.Rows.Count > 0 || dtData2.Rows.Count > 0 || dtData3.Rows.Count > 0)
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
                    paramlist.Add(new ReportParameter("dFecOpe", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("idGrupo", idGrupoSol.ToString(), false));

                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsSoli1", dtData1));
                    dtsList.Add(new ReportDataSource("dsSoli2", dtData2));
                    dtsList.Add(new ReportDataSource("dsSoli3", dtData3));


                    string reportPath = "rptSolCrediSolidario.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                   // new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    this.frmReporteSolicitud = new frmReporteLocal(dtsList, reportPath, paramlist);
                    this.frmReporteSolicitud.MdiParent = this.oParent;
                    this.frmReporteSolicitud.Dock = DockStyle.Fill;
                    this.frmReporteSolicitud.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                    this.frmReporteSolicitud.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                    this.frmReporteSolicitud.ControlBox = false;
                    this.frmReporteSolicitud.ShowIcon = false;
                    this.frmReporteSolicitud.Show();
                    this.frmReporteSolicitud.WindowState = FormWindowState.Maximized;
                    this.frmReporteSolicitud.BringToFront();
                }
                else
                {
                    MessageBox.Show("No existen datos para esta solicitud ", "Documentación en Línea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                   


            }
            else
            {
                this.frmReporteSolicitud.WindowState = FormWindowState.Maximized;
                this.frmReporteSolicitud.BringToFront();
                this.frmReporteSolicitud.Activate();
            }


            Cursor.Current = Cursors.Default;
        }
        public void ImpActaAprob()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteActaAprob == null)
            {
            
            
            string idGrupo = Convert.ToString(idGrupoSol);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();

            DataTable dtData = objCNAprobacionCredito.ActaCreditoGrupoSol(idGrupoSol, idSolicitud);
            DataTable dtData2 = objCNAprobacionCredito.ActaCreditoGrupoSol2(idGrupoSol, idSolicitud);
            DataTable dtData3 = objCNAprobacionCredito.ActaCreditoGrupoSol3(idGrupoSol, idSolicitud);
            DataTable dtData4 = objCNAprobacionCredito.ActaCreditoGrupoSol4(idGrupoSol, idSolicitud);
            DataTable dtNivelesAprob = objCNAprobacionCredito.LisNivelAprobaSolCredGrupoSol(idSolicitud);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsSoli1", dtData));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData2));
                dtsList.Add(new ReportDataSource("dsSoli3", dtData3));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData4));
                dtsList.Add(new ReportDataSource("dsNivelAproGrupoSol", dtNivelesAprob));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idGrupo", idGrupo.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

                string reportPath = "rptActaCrediSolidario.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
               // new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                this.frmReporteActaAprob = new frmReporteLocal(dtsList, reportPath, paramlist);
                this.frmReporteActaAprob.MdiParent = this.oParent;
                this.frmReporteActaAprob.Dock = DockStyle.Fill;
                this.frmReporteActaAprob.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                this.frmReporteActaAprob.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.frmReporteActaAprob.ControlBox = false;
                this.frmReporteActaAprob.ShowIcon = false;
                this.frmReporteActaAprob.Show();
                this.frmReporteActaAprob.WindowState = FormWindowState.Maximized;
                this.frmReporteActaAprob.BringToFront();

            }
            else
            {
                MessageBox.Show("No existen datos para esta Evaluación. ", "Documentos en Linea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
            else
            {
                this.frmReporteActaAprob.WindowState = FormWindowState.Maximized;
                this.frmReporteActaAprob.BringToFront();
                this.frmReporteActaAprob.Activate();
            }


            Cursor.Current = Cursors.Default;
        
        
        }
        public void ImpOpRiesgos()
        {

        }
        public void ImpOpRecu()
        {

        }
        public void ImpAproRapida()
        {

        }
        
        public void VerVisita()
        {
            //frmVisita frm = new frmVisita(0, this.idSolicitud);
            //frm.ShowDialog();

            frmVisitaRealizadaSinVinculacion frm = new frmVisitaRealizadaSinVinculacion(0, this.idSolicitud, false, true);
            frm.ShowDialog();
        }

        /*  Funcion para Imprimir el Reporte de Score Crédito  */
        public void impScore()
        {

        }
        /// <summary>
        /// Filtra datos de un datatable por columna
        /// </summary>
        /// <param name="dt">Datatable original de donde se aplicará el filtro</param>
        /// <param name="cColumnaNombre">Nombre de la columna del datatable a filtrar</param>
        /// <param name="nValor">valor por el cual filtrar</param>
        /// <returns>Retorna un datatable con los valores filtrados</returns>
        private DataTable filtrarDataValorColumna(DataTable dt, string cColumnaNombre, int nValor)
        {
            DataTable dtResultado = dt.Clone();

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item[cColumnaNombre]) == nValor)
                {
                    dtResultado.ImportRow(item);
                }
            }

            return dtResultado;
        }
    }
}
