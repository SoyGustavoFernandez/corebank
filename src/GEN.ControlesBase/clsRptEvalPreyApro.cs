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
    class clsRptEvalPreyApro : clsRptEvalInterface
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



        public clsRptEvalPreyApro(int idEval, int idSol)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "RESUMIDA";
            this.cnEval = new clsCNEvaluacion();
            this.cNomAgen = clsVarGlobal.cNomAge.ToString();
        }

        public clsRptEvalPreyApro(int idEval, int idSol, Form frm)
        {
            this.idEvalCre = idEval;
            this.idSolicitud = idSol;
            this.cNombreEval = "RESUMIDA";
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
                dsProp = cnEval.ImprimirEvalResumida(this.idSolicitud, this.idEvalCre);

            if (dsProp.Tables.Count > 0)
            {
                if (this.frmReporteProp == null)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();


                    string cProducto = Convert.ToString(dsProp.Tables[1].Rows[0]["cProducto"]);

                    paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
                    paramList.Add(new ReportParameter("cTipoEval", cProducto));

                    dtsList.Add(new ReportDataSource("dsIndicadores", dsProp.Tables[0]));
                    dtsList.Add(new ReportDataSource("dsSolicitud", dsProp.Tables[1]));
                    dtsList.Add(new ReportDataSource("dsGeneral", dsProp.Tables[2]));
                    dtsList.Add(new ReportDataSource("dsEvaluacion", dsProp.Tables[3]));
                    dtsList.Add(new ReportDataSource("dsBBGG", dsProp.Tables[4]));
                    dtsList.Add(new ReportDataSource("dsEERR", dsProp.Tables[5]));
                    dtsList.Add(new ReportDataSource("dsDeudaDirecta", filtrarDataValorColumna(dsProp.Tables[6], "idTipoDeuda", 1)));
                    dtsList.Add(new ReportDataSource("dsDeudaIndirecta", filtrarDataValorColumna(dsProp.Tables[6], "idTipoDeuda", 2)));
                    dtsList.Add(new ReportDataSource("dsRetornaDestino", dsProp.Tables[9]));
                    dtsList.Add(new ReportDataSource("dsAvales", dsProp.Tables[7]));

                    string reportPath = "rptEvalResumenPreAprob.rdlc";

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

            if (this.frmReporteActaAprob == null)
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
