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
using GEN.CapaNegocio;
using System.Xml.Linq;
using System.ComponentModel;
using System.Globalization;

namespace GEN.ControlesBase
{
    public class clsRptEvalPyme : clsRptEvalInterface
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



        public clsRptEvalPyme(int idEval, int idSol)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "PYME";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
        }

        public clsRptEvalPyme(int idEval, int idSol, Form frm)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "PYME";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
            this.oParent = frm;

            this.frmReporteCualit = null;
            this.frmReporteProp = null;
            this.frmReporteEEFF = null;
            this.frmReporteHTrab = null;
            this.frmReporteFCaja = null;
                    /** Docu Online **/
            this.frmReporteSolicitud = null;
            this.frmReporteActaAprob = null;
            this.frmReporteOpRiesgos = null;
            this.frmReporteOpRecup = null;
            this.frmReporteAproRapida = null;

            this.dsCualit = null;
            this.dsProp = null;
            this.dsEEFF = null;
            this.dsHTrab = null;
            this.dsFCaja = null;
                    /** Docu Online **/
            this.dsSolicitud = null;
            this.dsActaAprob = null;
            this.dsOpRiesgos = null;
            this.dsOpRecupe = null;
            this.dsAproRapida = null;
        }

        public void ImpPropuestaEval()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.frmReporteProp == null)
                dsProp = cnEval.CNPropuestaImpEval(this.idSolicitud, this.idEvalCre);
            if (dsProp.Tables.Count > 0)
            {
                if (this.frmReporteProp == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsGeneral", this.dsProp.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsAvales", this.dsProp.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsSolicitud", this.dsProp.Tables[2]));
                    dtsList.Add(new ReportDataSource("dsEvaluacion", this.dsProp.Tables[3]));
                    dtsList.Add(new ReportDataSource("dsExcepciones", this.dsProp.Tables[4]));

                    paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("cTipoEval", cNombreEval));

                    string reportPath = "rptEvalPropPyme.rdlc";

                    this.frmReporteProp = new frmReporteLocal(dtsList, reportPath, paramList);
                    Cursor.Current = Cursors.Default;

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
            }
            else
            {
                MessageBox.Show("No hay datos para esta propuesta", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor.Current = Cursors.Default;
        }

        public void ImpEvalCualitativa()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteCualit == null)
                this.dsCualit = cnEval.CNEvalCualitativa(idEvalCre);

            if (this.dsCualit.Tables.Count > 0)
            {
                if (this.frmReporteCualit == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsEvalCualita", this.dsCualit.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsReferencias", this.dsCualit.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsSolicitud", this.dsCualit.Tables[2]));

                    paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("cTipoEval", cNombreEval));

                    string reportPath = "rptEvalCualitativa.rdlc";

                    this.frmReporteCualit = new frmReporteLocal(dtsList, reportPath, paramList);
                    Cursor.Current = Cursors.Default;

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
                    this.frmReporteCualit.WindowState = FormWindowState.Maximized;
                    this.frmReporteCualit.BringToFront();
                    this.frmReporteCualit.Activate();
                }
            }
            else
            {
                MessageBox.Show("No hay datos a imprimir", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor.Current = Cursors.Default;
        }

        public void ImpEEFF()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteEEFF == null)
                this.dsEEFF = cnEval.CNEstadosFinanEval(this.idSolicitud, this.idEvalCre);

            if (this.dsEEFF.Tables.Count > 0)
            {
                if (this.frmReporteEEFF == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsEERR", this.dsEEFF.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsDestino", this.dsEEFF.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsSolicitud", this.dsEEFF.Tables[2]));
                    dtsList.Add(new ReportDataSource("dsEvaluacion", this.dsEEFF.Tables[3]));
                    dtsList.Add(new ReportDataSource("dsRcc", this.dsEEFF.Tables[4]));
                    dtsList.Add(new ReportDataSource("dsIndicadores", this.dsEEFF.Tables[5]));
                    dtsList.Add(new ReportDataSource("dsBBGG", this.dsEEFF.Tables[6]));
                    dtsList.Add(new ReportDataSource("dsGastosPersonal", filtrarDataValorColumna(this.dsEEFF.Tables[7], "idEEFF", EEFF.GastosPersonales)));
                    dtsList.Add(new ReportDataSource("dsGastosOperativos", filtrarDataValorColumna(this.dsEEFF.Tables[7], "idEEFF", EEFF.GastosOperativos)));
                    dtsList.Add(new ReportDataSource("dsGastosFamiliare", filtrarDataValorColumna(this.dsEEFF.Tables[7], "idEEFF", EEFF.GastosFamiliares)));
                    dtsList.Add(new ReportDataSource("dsOtrosIngresos", filtrarDataValorColumna(this.dsEEFF.Tables[7], "idEEFF", EEFF.OtrosIngresos)));
                    dtsList.Add(new ReportDataSource("dsOtrosEgresos", filtrarDataValorColumna(this.dsEEFF.Tables[7], "idEEFF", EEFF.OtrosEgresos)));
                    dtsList.Add(new ReportDataSource("dsDeudaDirecta", filtrarDataValorColumna(this.dsEEFF.Tables[8], "idTipoDeuda", 1)));
                    dtsList.Add(new ReportDataSource("dsDeudaIndirecta", filtrarDataValorColumna(this.dsEEFF.Tables[8], "idTipoDeuda", 2)));

                    paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("cTipoEval", cNombreEval));

                    string reportPath = "rptEvalPropEEFF.rdlc";

                    this.frmReporteEEFF = new frmReporteLocal(dtsList, reportPath, paramList);
                    Cursor.Current = Cursors.Default;

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
                    this.frmReporteEEFF.WindowState = FormWindowState.Maximized;
                    this.frmReporteEEFF.BringToFront();
                    this.frmReporteEEFF.Activate();
                }
            }
            else
            {
                MessageBox.Show("No hay datos para esta propuesta", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor.Current = Cursors.Default;
        }

        public void ImpHojaTrabajo()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteHTrab == null)
                this.dsHTrab = cnEval.CNHojaTrabajoEval(this.idEvalCre);

            if (this.dsHTrab.Tables.Count > 0)
            {
                if (this.frmReporteHTrab == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsEvaluacion", this.dsHTrab.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsSolicitud", this.dsHTrab.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsVentasCostos", this.dsHTrab.Tables[2]));
                    dtsList.Add(new ReportDataSource("dsCosteo", this.dsHTrab.Tables[3]));
                    dtsList.Add(new ReportDataSource("dsInventario", filtrarDataValorColumna(this.dsHTrab.Tables[4], "idEEFF", EEFF.Inventario)));
                    dtsList.Add(new ReportDataSource("dsMaqEqHerramientas", filtrarDataValorColumna(this.dsHTrab.Tables[4], "idEEFF", EEFF.MaqEquipos)));
                    dtsList.Add(new ReportDataSource("dsInmuebles", filtrarDataValorColumna(this.dsHTrab.Tables[4], "idEEFF", EEFF.Inmuebles)));
                    //dtsList.Add(new ReportDataSource("dsInventarioCodigo", filtrarDataValorColumna(dsPropuesta.Tables[4], "idEEFF", EEFF.Inventario)));

                    paramList.Add(new ReportParameter("idEvalCre", this.idEvalCre.ToString()));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cTipoEval", cNombreEval));

                    string reportPath = "RptHojaTrabPyme.rdlc";

                    this.frmReporteHTrab = new frmReporteLocal(dtsList, reportPath, paramList);
                    Cursor.Current = Cursors.Default;

                    this.frmReporteHTrab.MdiParent = this.oParent;
                    this.frmReporteHTrab.Dock = DockStyle.Fill;
                    this.frmReporteHTrab.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                    this.frmReporteHTrab.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                    this.frmReporteHTrab.ControlBox = false;
                    this.frmReporteHTrab.ShowIcon = false;
                    this.frmReporteHTrab.Show();
                    this.frmReporteHTrab.WindowState = FormWindowState.Maximized;
                    this.frmReporteHTrab.BringToFront();
                }
                else
                {
                    this.frmReporteHTrab.WindowState = FormWindowState.Maximized;
                    this.frmReporteHTrab.BringToFront();
                    this.frmReporteHTrab.Activate();
                }
            }
            else
            {
                MessageBox.Show("No hay datos para la hoja de trabajo", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor.Current = Cursors.Default;
        }

        public void ImpFlujoCaja()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteFCaja == null)
                this.dsFCaja = cnEval.FlujoCajaEvalPyme(this.idEvalCre);

            if (this.dsFCaja.Tables.Count > 0)
            {
                if (this.frmReporteFCaja == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsSolicitud", this.dsFCaja.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsIngresos", this.dsFCaja.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsEgresos", this.dsFCaja.Tables[2]));
                    dtsList.Add(new ReportDataSource("dsSaldos", this.dsFCaja.Tables[3]));

                    paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("idEvalCre", this.idEvalCre.ToString()));
                    paramList.Add(new ReportParameter("cTipoEval", cNombreEval));

                    string reportPath = "RptFlujoCaja.rdlc";

                    if (this.oParent != null)
                    {
                        this.frmReporteFCaja = new frmReporteLocal(dtsList, reportPath, paramList);
                        Cursor.Current = Cursors.Default;

                        this.frmReporteFCaja.MdiParent = this.oParent;
                        this.frmReporteFCaja.Dock = DockStyle.Fill;
                        this.frmReporteFCaja.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                        this.frmReporteFCaja.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                        this.frmReporteFCaja.ControlBox = false;
                        this.frmReporteFCaja.ShowIcon = false;
                        this.frmReporteFCaja.Show();
                        this.frmReporteFCaja.WindowState = FormWindowState.Maximized;
                        this.frmReporteFCaja.BringToFront();
                    }
                    else
                    {
                        this.frmReporteFCaja = new frmReporteLocal(dtsList, reportPath, paramList);
                        this.frmReporteFCaja.ShowDialog();
                    }
                }
                else
                {
                    this.frmReporteFCaja.WindowState = FormWindowState.Maximized;
                    this.frmReporteFCaja.BringToFront();
                    this.frmReporteFCaja.Activate();
                }
            }
            else
            {
                MessageBox.Show("No hay datos el Flujo de Caja", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Cursor.Current = Cursors.Default;
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


                string reportpath = "rptDatoSolicitud.rdlc";
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


                string reportpath = "rptDatoSolicitudJudi.rdlc";
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
             Cursor.Current = Cursors.WaitCursor;
            
           if (this.frmReporteActaAprob  == null)
            {

            int idSolicitud = Convert.ToInt32(this.idSolicitud);
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cTituloMsjes = "Impresión de actas de aprobación";
            DataSet dsData = new clsRPTCNCredito().CNGenActaAprobDenegCred(idSolicitud);

            if (dsData.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDatosGenerales", dsData.Tables["dtDatosGenerales"]));
            dtslist.Add(new ReportDataSource("dsDestCredSol", dsData.Tables["dtDestCredSol"]));
            dtslist.Add(new ReportDataSource("dsComite", dsData.Tables["dtComite"]));
            dtslist.Add(new ReportDataSource("dsNivAproba", dsData.Tables["dtNivAproba"]));
            dtslist.Add(new ReportDataSource("dsIntervSolCre", dsData.Tables["dtIntervSolCre"]));
            dtslist.Add(new ReportDataSource("dsExcepciones", dsData.Tables["dtExcepciones"]));
            dtslist.Add(new ReportDataSource("dsParticipantes", dsData.Tables["dtParticipantes"]));
            dtslist.Add(new ReportDataSource("dsHistObs", dsData.Tables["dtHistObs"]));
            
            string reportpath = "rptActaAprobacionCredito.rdlc";

            //  new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.frmReporteActaAprob = new frmReporteLocal(dtslist, reportpath, paramlist);
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
               this.frmReporteActaAprob.WindowState = FormWindowState.Maximized;
               this.frmReporteActaAprob.BringToFront();
               this.frmReporteActaAprob.Activate();
           }

        }
        public void ImpOpRiesgos()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteOpRiesgos == null)
            {

            DataTable dtInfRiesgos = new clsCNInformeRiesgos().ObtenerInformeRiesgo(this.idSolicitud);
            string cTitulo = "Informe de Riesgos";
            if (dtInfRiesgos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el informe de riesgos.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idInfRiesgos = Convert.ToInt32(dtInfRiesgos.Rows[0]["idInfRiesgos"]);

            clsCNInformeRiesgos obInformeRiesgos = new clsCNInformeRiesgos();
           
            int idSolInfRiesgo = obInformeRiesgos.RetornarSolInforme(idInfRiesgos);

            int idMolidad = obInformeRiesgos.modalidadOpinionRiesgo(idSolInfRiesgo);
            if (idMolidad == 2)
            {
               imprimir(idSolInfRiesgo);

            }
            else
            {
                dtInfRiesgos = obInformeRiesgos.BuscarInformeRiesgo(idInfRiesgos, null, null, null, string.Empty, 2);

               //frmRegistroInformeRiesgosGEN frmInformeRiesgos = new frmRegistroInformeRiesgos(idInfRiesgos);
               //frmInformeRiesgos.ShowDialog();
                
                if (dtInfRiesgos.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el Informe de Riesgos N°" + idInfRiesgos + ", pero si existe la solicitud de Informe de Riesgos con el N°:" + idSolInfRiesgo, "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Dispose();
                    return;
                }
                else
                {
                    frmBuscarDocsRiesgos frmBuscar = new frmBuscarDocsRiesgos(idInfRiesgos);
                    frmBuscar.ShowDialog();
                    
                }


            }

           }
           else
           {
               this.frmReporteOpRiesgos.WindowState = FormWindowState.Maximized;
               this.frmReporteOpRiesgos.BringToFront();
               this.frmReporteOpRiesgos.Activate();
           }
        }
        public void ImpOpRecu()
        {
             Cursor.Current = Cursors.WaitCursor;

            if (this.frmReporteOpRecup == null)
            {
               
                clsCNSolicitudAmortiza cnsolicitudamortiza = new clsCNSolicitudAmortiza();
                DataTable dtData = cnsolicitudamortiza.CNrptOpinionRefinanciacion(this.idSolicitud);
                if (dtData.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte.", "Opinion de Recuperaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

           // clsCNSolicitudAmortiza cnsolicitudamortiza = new clsCNSolicitudAmortiza();
            string reportpath = "rptOpinionRefinanciacion.rdlc";

            List<ReportDataSource> lisData = new List<ReportDataSource>();
            List<ReportParameter> lisParametros = new List<ReportParameter>();

            lisParametros.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            lisParametros.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            lisParametros.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            lisData.Add(new ReportDataSource("dsOpinion", cnsolicitudamortiza.CNrptOpinionRefinanciacion(this.idSolicitud)));
            //new frmReporteLocal(lisData, reportpath, lisParametros).ShowDialog();

            this.frmReporteOpRecup = new frmReporteLocal(lisData, reportpath, lisParametros);
            this.frmReporteOpRecup.MdiParent = this.oParent;
            this.frmReporteOpRecup.Dock = DockStyle.Fill;
            this.frmReporteOpRecup.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            this.frmReporteOpRecup.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.frmReporteOpRecup.ControlBox = false;
            this.frmReporteOpRecup.ShowIcon = false;
            this.frmReporteOpRecup.Show();
            this.frmReporteOpRecup.WindowState = FormWindowState.Maximized;
            this.frmReporteOpRecup.BringToFront();

            }
            else
            {
                this.frmReporteOpRecup.WindowState = FormWindowState.Maximized;
                this.frmReporteOpRecup.BringToFront();
                this.frmReporteOpRecup.Activate();
            }



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

        public void imprimir(int idSolInfRiesgo)
        {

            clsCNInformeRiesgos obInformeRiesgos = new clsCNInformeRiesgos();

            List<clsDetalleInformeRiesgo> listDetInfRsg2 = new List<clsDetalleInformeRiesgo>();
            List<clsComposicionCredito> listDestinoCreditoEval2 = new List<clsComposicionCredito>();
            List<clsNivelTipoRiesgo> listNivelTipoRiesgo2 = new List<clsNivelTipoRiesgo>();

            listDetInfRsg2 = obInformeRiesgos.listarDetalleInformeRiesgo(idSolInfRiesgo);
            listDestinoCreditoEval2 = obInformeRiesgos.destinoCreditoEvalGuardado(listDetInfRsg2[0].idDetalleInformeRsg);
            listNivelTipoRiesgo2 = obInformeRiesgos.tipoNivelRiesgoGuardado(listDetInfRsg2[0].idDetalleInformeRsg);


            DataTable dtDetInfRsg = ConvertToDataTable(listDetInfRsg2);
            DataTable dtNivelTipoRsg = ConvertToDataTable(listNivelTipoRiesgo2);
            DataTable dtDestinoCredito = ConvertToDataTable(listDestinoCreditoEval2);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idSolInfRiesgo", idSolInfRiesgo.ToString(), false));
            paramlist.Add(new ReportParameter("idUsuarioSis", clsVarGlobal.PerfilUsu.idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtsList.Add(new ReportDataSource("dtsFichaOpinionRiesgo", dtDetInfRsg));
            dtsList.Add(new ReportDataSource("dtsNivelTipoRiesgo", dtNivelTipoRsg));
            dtsList.Add(new ReportDataSource("dtsDestinoCredito", dtDestinoCredito));

            //new frmReporteLocal(dtsList, "rptFichaOpinionRiesgo.rdlc", paramlist).ShowDialog();
            string reportpath = "rptFichaOpinionRiesgo.rdlc";
            this.frmReporteOpRiesgos = new frmReporteLocal(dtsList, reportpath, paramlist);
            this.frmReporteOpRiesgos.MdiParent = this.oParent;
            this.frmReporteOpRiesgos.Dock = DockStyle.Fill;
            this.frmReporteOpRiesgos.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            this.frmReporteOpRiesgos.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.frmReporteOpRiesgos.ControlBox = false;
            this.frmReporteOpRiesgos.ShowIcon = false;
            this.frmReporteOpRiesgos.Show();
            this.frmReporteOpRiesgos.WindowState = FormWindowState.Maximized;
            this.frmReporteOpRiesgos.BringToFront();

        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
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
