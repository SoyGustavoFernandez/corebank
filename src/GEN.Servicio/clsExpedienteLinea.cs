using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using GEN.ControlesBase;
using EntityLayer;

namespace GEN.Servicio
{
    public class clsExpedienteLinea
    {
        #region Variables
        private clsCNExpedienteLinea clsExpediente = new clsCNExpedienteLinea();
        #endregion

        #region Métodos
        
        public bool guardarCopiaExpediente(string cGrupo, int idSolicitud, Form frmActual, string cTipoSolicitud = "individual", bool lMensaje = true)
        {
            string cMsgError = "Ha ocurrido un error al Guardar los Expedientes \n\n";
            if (cGrupo == "Solicitud de Credito")
                cMsgError = "Ha ocurrido un error al Guardar los Expedientes, por lo tanto se cancelará el envío a evaluación de créditos.  \n\n";
            else if (cGrupo == "Evaluacion de Credito")
                cMsgError = "Ha ocurrido un error al Guardar los Expedientes, por lo tanto se cancelará el envío a comité/aprobación de créditos.  \n\n";

            try
            {
                frmActual.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                if(lMensaje)
                    MessageBox.Show("Se procederá a guardar los Expedientes necesarios para este proceso.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet dExpedientes = clsExpediente.getGrupoExpedienteLinea(cGrupo, idSolicitud, cTipoSolicitud);
                DataSet dDatosExpedientes = clsExpediente.getEjecutarSpExpediente(cGrupo, idSolicitud, cTipoSolicitud, clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dDatosExpedientes.Tables[dDatosExpedientes.Tables.Count - 1].Rows[0]["nRespuesta"]) == 0)
                {
                    MessageBox.Show(cMsgError, "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmActual.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    return false;
                }
                DataTable dtProcParamDat = clsExpediente.getParametroAndDatosXml(dExpedientes, dDatosExpedientes, idSolicitud);
                DataTable res = clsExpediente.guardarGrupoExpediente(dtProcParamDat, idSolicitud, clsVarGlobal.User.idUsuario, cTipoSolicitud, cGrupo);
                if (lMensaje)
                {
                    if (Convert.ToInt32(res.Rows[0]["nRespuesta"]) == 1)
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frmActual.Enabled = true;
                        Cursor.Current = Cursors.Default;
                        return false;
                    }
                }
                if (dExpedientes != null)
                    dExpedientes.Clear();

                if (dDatosExpedientes != null)
                    dDatosExpedientes.Clear();

                if (dtProcParamDat != null)
                    dtProcParamDat.Clear();

                frmActual.Enabled = true;
                Cursor.Current = Cursors.Default;
                return true;
            }catch(Exception exp){
                clsExpediente.guardarLogError(idSolicitud, cGrupo, cTipoSolicitud, exp.Message, frmActual.Name, clsVarGlobal.User.idUsuario);
                if (lMensaje)
                    MessageBox.Show(cMsgError + exp.Message, "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActual.Enabled = true;
                Cursor.Current = Cursors.Default;
                return false;
            }
        }
        public bool guardarCopiaExpedientePosicionConsolidada(int idDescTipoDoc, string cTipoSolicitud, int idSecundario, string cGrupo, int idSolicitud, Form frmActual, DataSet dsContenedorDatoSentinel = null, DataSet dExpedientes=null)
        {
            bool lMensaje = false;
            string cMsgError = "Ha ocurrido un error al Guardar los Expedientes \n\n";
           

            try
            {
                frmActual.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                if (lMensaje)
                    MessageBox.Show("Se procederá a guardar Expediente Posicion Consolidada.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataTable dtProcParamDat = clsExpediente.getParametroAndDatosXmlJC(idDescTipoDoc, cTipoSolicitud, idSecundario, dExpedientes, idSolicitud, dsContenedorDatoSentinel);
                DataTable res = clsExpediente.guardarGrupoExpediente(dtProcParamDat, idSolicitud, clsVarGlobal.User.idUsuario, "individual", cGrupo);
                if (lMensaje)
                {
                    if (Convert.ToInt32(res.Rows[0]["nRespuesta"]) == 1)
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes Posición Consolidada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes Posición Consolidada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frmActual.Enabled = true;
                        Cursor.Current = Cursors.Default;
                        return false;
                    }
                }
                if (dtProcParamDat != null)
                    dtProcParamDat.Clear();

                frmActual.Enabled = true;
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception exp)
            {
                clsExpediente.guardarLogError(idSolicitud, cGrupo, "individual", exp.Message, frmActual.Name, clsVarGlobal.User.idUsuario);
                if (lMensaje)
                    MessageBox.Show(cMsgError + exp.Message, "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActual.Enabled = true;
                Cursor.Current = Cursors.Default;
                return false;
            }
        }

        public DataSet obtenerExpediente(int idArchivo, int idSolicitud, int idCategoriaArchivo, string cTipoSolicitud, string cExtension, int idSecundario)
        {
            return clsExpediente.obtenerExpediente(idArchivo, idSolicitud, idCategoriaArchivo, cTipoSolicitud, cExtension, idSecundario);
        }

        public frmReporteLocal getReportLocal(DataTable dsDatoExpediente, DataTable dsDataSets, DataTable dsParameters, DataTable dsClaves)
        {
            frmReporteLocal frmReporteProp;

            string reportpath = "";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            
                reportpath = dsDatoExpediente.Rows[0]["cReporte"].ToString();

                paramlist = clsExpediente.getParameters(dsParameters, dsClaves);

                dtslist = clsExpediente.getDataSource(dsDataSets, dsDatoExpediente.Rows[0]["cArchivoXml"].ToString());

            
            frmReporteProp = new frmReporteLocal(dtslist, reportpath, paramlist);

            Cursor.Current = Cursors.Default;
            frmReporteProp.TopLevel = false;
            frmReporteProp.Dock = DockStyle.Fill;
            frmReporteProp.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            frmReporteProp.ControlBox = false;
            frmReporteProp.ShowIcon = false;
            frmReporteProp.WindowState = FormWindowState.Maximized;
            frmReporteProp.BringToFront();
            return frmReporteProp;
        }

        public DataSet getMenuExpediente(int idSolicitud, string cTipoSolicitud)
        {
            DataSet dtMenu = clsExpediente.getMenuExpediente(idSolicitud, cTipoSolicitud);
            return dtMenu;
        }

        public frmReporteLocal getReportLocalExpedienteNormal(int idDescTipoDoc, int idSolicitud, string cTipoSolicitud, int idSecundario)
        {
            frmReporteLocal frmReporteProp;

            string reportpath = "";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            DataSet dsDatosExpediente = clsExpediente.getDatosExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud);

            DataTable dtDatosRpt = dsDatosExpediente.Tables[0];
            DataTable dtDataSets = dsDatosExpediente.Tables[1];
            DataTable dtParameters = dsDatosExpediente.Tables[2];
            DataTable dtClaves = dsDatosExpediente.Tables[3];
            
            reportpath = dtDatosRpt.Rows[0]["cReporte"].ToString();

            paramlist = clsExpediente.getParameters(dtParameters, dtClaves);

            dtslist = clsExpediente.getDataSourceExpedienteNormal(idDescTipoDoc, idSolicitud, dtDataSets, cTipoSolicitud, idSecundario);

            frmReporteProp = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporteProp.lEsExpedienteVirtual2 = true;
            Cursor.Current = Cursors.Default;
            frmReporteProp.TopLevel = false;
            frmReporteProp.Dock = DockStyle.Fill;
            frmReporteProp.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            frmReporteProp.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmReporteProp.ControlBox = false;
            frmReporteProp.ShowIcon = false;
            frmReporteProp.AutoSize = true;
            frmReporteProp.BringToFront();
            return frmReporteProp;
        }
        public frmReporteLocal getReportLocalExpedienteNormalJC(int idDescTipoDoc, int idSolicitud, string cTipoSolicitud, int idSecundario, DataTable dtCondiciones = null, DataSet dsContenedorDatoSentinel = null)
        {
            frmReporteLocal frmReporteProp;

            string reportpath = "";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            DataSet dsDatosExpediente = clsExpediente.getDatosExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud);

            DataTable dtDatosRpt = dsDatosExpediente.Tables[0];
            DataTable dtDataSets = dsDatosExpediente.Tables[1];
            DataTable dtParameters = dsDatosExpediente.Tables[2];
            DataTable dtClaves = dsDatosExpediente.Tables[3];

            reportpath = dtDatosRpt.Rows[0]["cReporte"].ToString();

            paramlist = clsExpediente.getParameters(dtParameters, dtClaves);

            dtslist = clsExpediente.getDataSourceExpedienteNormalJC(idDescTipoDoc, idSolicitud, dtDataSets, cTipoSolicitud, idSecundario, dtCondiciones, dsContenedorDatoSentinel);

            frmReporteProp = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporteProp.lEsExpedienteVirtual2 = true;
            Cursor.Current = Cursors.Default;
            frmReporteProp.TopLevel = false;
            frmReporteProp.Dock = DockStyle.Fill;
            frmReporteProp.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            frmReporteProp.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmReporteProp.ControlBox = false;
            frmReporteProp.ShowIcon = false;
            frmReporteProp.AutoSize = true;
            frmReporteProp.BringToFront();
            return frmReporteProp;
        }
        public DataTable getDatosSolicitud(int idSolicitud, string cTipoSolicitud)
        {
            return clsExpediente.getDatosSolicitud(idSolicitud, cTipoSolicitud);
        }
        #endregion
    }
}
