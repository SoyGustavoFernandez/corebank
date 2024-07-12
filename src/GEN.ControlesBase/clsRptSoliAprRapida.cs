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
    public class clsRptSoliAprRapida : clsRptEvalInterface
    {
        private int idEvalCre;
        private int idSolicitud;
        private string cNombreEval;
        private clsCNEvaluacion cnEval;
        private string cNomAgen;
        private Form oParent;

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
        private frmReporteLocal frmReporteScore;

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


        public clsRptSoliAprRapida(int idEval, int idSol)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "APROBACION RAPIDA";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
        }

        public clsRptSoliAprRapida(int idEval, int idSol, Form frm)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "APROBACION RAPIDA";
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
        }

        public void ImpEvalCualitativa()
        {
        }

        public void ImpEEFF()
        {
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

                int idsolicitud = Convert.ToInt32(this.idSolicitud);

                if (idsolicitud == 0)
                {
                    MessageBox.Show("No existe numero de solicitud", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                CRE.CapaNegocio.clsCNCredito credito = new CRE.CapaNegocio.clsCNCredito();
                DataTable dtResultado = credito.CNBuscarDatosDocumentacion(idsolicitud);

                int idcli = Convert.ToInt32(dtResultado.Rows[0]["idCli"]);
                int idtipocliente = Convert.ToInt32(dtResultado.Rows[0]["idTipoPer"]);

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

                if (idtipocliente == 1)
                {
                    dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNCredito().DatosSolicitud(idsolicitud)));
                    dtslist.Add(new ReportDataSource("DataSet2", new clsRPTCNCredito().DatosFamiliar(idcli)));
                    dtslist.Add(new ReportDataSource("DataSet3", new clsRPTCNCredito().DatosAprobador(idsolicitud)));


                    string reportpath = "rptDatoSolicitud_Doclinea.rdlc";
                    this.frmReporteSolicitud = new frmReporteLocal(dtslist, reportpath, paramlist);

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
                    dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNCredito().DatosSolicitud(idsolicitud)));
                    dtslist.Add(new ReportDataSource("ClienteJur", new clsRPTCNCredito().DatosclienteJur(idcli)));
                    dtslist.Add(new ReportDataSource("ClienteVin", new clsRPTCNCredito().DatosclienteVin(idcli)));
                    dtslist.Add(new ReportDataSource("DataSet3", new clsRPTCNCredito().DatosAprobador(idsolicitud)));

                    string reportpath = "rptDatoSolicitudJudi_Doclinea.rdlc";
                    this.frmReporteSolicitud = new frmReporteLocal(dtslist, reportpath, paramlist);
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

            frmVisitaRealizadaSinVinculacion frm = new frmVisitaRealizadaSinVinculacion(0, this.idSolicitud, true);
            frm.ShowDialog();
        }

        /*  Funcion para Imprimir el Reporte de Score Crédito  */
        public void impScore()
        {
            /*  Reporte de Score Crédito  */
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteScore == null)
            {

                int idsolicitud = Convert.ToInt32(this.idSolicitud);

                if (idsolicitud == 0)
                {
                    MessageBox.Show("No existe número de solicitud", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                CRE.CapaNegocio.clsCNCredito credito = new CRE.CapaNegocio.clsCNCredito();
                DataTable dtResultado = credito.CNBuscarDatosDocumentacion(idsolicitud);

                int idcli = Convert.ToInt32(dtResultado.Rows[0]["idCli"]);
                int idtipocliente = Convert.ToInt32(dtResultado.Rows[0]["idTipoPer"]);

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));

                {
                    dtslist.Add(new ReportDataSource("dtsDatosScore", new clsRPTCNCredito().CNDatosScore(idsolicitud)));
                    dtslist.Add(new ReportDataSource("dtsDatosDetalleScore", new clsRPTCNCredito().CNDatosDetalleScore(idSolicitud)));
                    dtslist.Add(new ReportDataSource("dsSolicitud", new clsRPTCNCredito().CNDatosSolicitudScore(idSolicitud)));

                    string reportpath = "rptDatosScoreCredito.rdlc";
                    this.frmReporteScore = new frmReporteLocal(dtslist, reportpath, paramlist);
                    this.frmReporteScore.MdiParent = this.oParent;
                    this.frmReporteScore.Dock = DockStyle.Fill;
                    this.frmReporteScore.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                    this.frmReporteScore.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                    this.frmReporteScore.ControlBox = false;
                    this.frmReporteScore.ShowIcon = false;
                    this.frmReporteScore.Show();
                    this.frmReporteScore.WindowState = FormWindowState.Maximized;
                    this.frmReporteScore.BringToFront();

                }
            }
            else
            {
                this.frmReporteScore.WindowState = FormWindowState.Maximized;
                this.frmReporteScore.BringToFront();
                this.frmReporteScore.Activate();
            }


            Cursor.Current = Cursors.Default;
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
