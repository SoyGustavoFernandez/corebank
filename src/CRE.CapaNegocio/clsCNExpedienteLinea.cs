using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using GEN.CapaNegocio;
using System.IO;
using System.Xml.Linq;

namespace CRE.CapaNegocio
{
    public class clsCNExpedienteLinea
    {
        #region Variables
        private clsADExpedienteLinea clsExpedientes = new clsADExpedienteLinea();
        private clsCovertRptXml clsRptXml = new clsCovertRptXml();
        #endregion

        #region Metodos
        public DataSet getGrupoExpedienteLinea(string cGrupo, int idSolicitud, string cTipoSolicitud)
        {
            return clsExpedientes.getGrupoExpedienteLinea(cGrupo, idSolicitud, cTipoSolicitud);
        }

        public DataSet getEjecutarSpExpediente(string cGrupo, int idSolicitud, string cTipoSolicitud, int idUsuario)
        {
            return clsExpedientes.getEjecutarSpExpediente(cGrupo, idSolicitud, cTipoSolicitud, idUsuario);
        }

        public DataTable getParametroAndDatosXml(DataSet dtExpedientes, DataSet dDatosExpedientes, int idSolicitud)
        {
            DataTable dtExpediente = dtExpedientes.Tables[0];
            DataTable dtDataSet = dtExpedientes.Tables[1];

            DataTable dtExpParamDat = new DataTable("dtExpediente");
            dtExpParamDat.Columns.Add("idExpediente", typeof(Int32));
            dtExpParamDat.Columns.Add("idDetGrupo", typeof(Int32));
            dtExpParamDat.Columns.Add("idSecundario", typeof(Int32));
            dtExpParamDat.Columns.Add("cXmlExpediente", typeof(string));


            List<ReportDataSource> dtslist;

            int nPosicion = 0;
            foreach (DataRow row in dtExpediente.Rows)
            {
                dtslist = new List<ReportDataSource>();
                int j = 0;
                for (int i = nPosicion; j < Convert.ToInt32(row["nDataSets"]); i++)
                {
                    dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dDatosExpedientes.Tables[i]));
                    j++;
                }

                DataRow rowExpediente = dtExpParamDat.NewRow();
                rowExpediente["idExpediente"] = row["idExpediente"];
                rowExpediente["idDetGrupo"] = row["idDetGrupo"];
                rowExpediente["idSecundario"] = row["idSecundario"];
                string cXmlExpediente = clsRptXml.convertirReportAXml(dtslist, row["cExpediente"].ToString()).ToString();
                rowExpediente["cXmlExpediente"] = cXmlExpediente;
                dtExpParamDat.Rows.Add(rowExpediente);

                nPosicion = nPosicion + Convert.ToInt32(row["nDataSets"]);
            }

            return dtExpParamDat;
        }

        public DataTable getParametroAndDatosXmlJC(int idDescTipoDoc, string cTipoSolicitud, int idSecundario, DataSet dtExpedientes, int idSolicitud, DataSet dsContenedorDatoSentinel = null)
        {
            DataTable dtExpediente = dtExpedientes.Tables[0];
            DataTable dtDataSet = dtExpedientes.Tables[1];

            DataTable dtExpParamDat = new DataTable("dtExpediente");
            dtExpParamDat.Columns.Add("idExpediente", typeof(Int32));
            dtExpParamDat.Columns.Add("idDetGrupo", typeof(Int32));
            dtExpParamDat.Columns.Add("idSecundario", typeof(Int32));
            dtExpParamDat.Columns.Add("cXmlExpediente", typeof(string));

      
            DataSet dsDataSource = clsExpedientes.getDataSourceExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud, idSecundario);


            List<ReportDataSource> dtslist;

            foreach (DataRow row in dtExpediente.Rows)
            {
                dtslist = new List<ReportDataSource>();
                int j = 0;
                for (int i = 0; j < dtDataSet.Rows.Count; i++)
                {
                    switch (dtDataSet.Rows[i]["cDataSet"].ToString())
                    {
                        case "DtValidacionCondiciones":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["DtValidacionCondiciones"]));
                            break;
                        case "dtsbSunatTitular":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBasicoSunatTitular"]));
                            break;
                        case "dtsBSunatDireccionT":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBSunatDireccionTitular"]));
                            break;
                        case "dtsRLegalTitular":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRlegalConyuge"]));
                            break;
                        case "dtsbSunatConyuge":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBasicoSunatConyuge"]));
                            break;
                        case "dtsBSunatDireccionC":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBSunatDireccionConyuge"]));
                            break;
                        case "dtsRLegalConyuge":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRlegalConyuge"]));
                            break;
                        case "dtsDeudaSentinelDirecta":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtDeudaSentinelDirectaTitular"]));
                            break;
                        case "dtsLCreditoNoUtil":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtlCredNoUtilizadaT"]));
                            break;
                        case "dtsVencidoSentinel":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtDeudaTitular"]));
                            break;
                        case "dtsListAvalista":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtAvalistaTitular"]));
                            break;
                        case "dtsListAvalado":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtAvalado"]));
                            break;
                        case "dtsHistoricoSentinel":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtHistorialSentinelTitular"]));
                            break;
                        case "dtsHistoricoSentinelC":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtHistorialSentinelConyuge"]));
                            break;
                        case "dtsCalificacionTConyuge":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtClasTitularConyuge"]));
                            break;
                        case "dtsEndeudamientoTitular":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtMicrTitular"]));
                            break;
                        case "dtsEndeudamientoConyuge":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtMicrConyuge"]));
                            break;
                        case "dtsRastreo":
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRastreo"]));

                            break;

                        default:
                            dtslist.Add(new ReportDataSource(dtDataSet.Rows[i]["cDataSet"].ToString(), dsDataSource.Tables[i]));
                            break;
                    } 

                    j++;
                }

                DataRow rowExpediente = dtExpParamDat.NewRow();
                rowExpediente["idExpediente"] = row["idExpediente"];
                rowExpediente["idDetGrupo"] = row["idDetGrupo"];
                rowExpediente["idSecundario"] = row["idSecundario"];
                string cXmlExpediente = clsRptXml.convertirReportAXml(dtslist, dtExpediente.Rows[0]["cExpediente"].ToString()).ToString();
                rowExpediente["cXmlExpediente"] = cXmlExpediente;
                dtExpParamDat.Rows.Add(rowExpediente);

            }


            return dtExpParamDat;
        }

        public DataTable guardarGrupoExpediente(DataTable dtExpParamDat, int idSolicitud, int idUsuario, string cTipoSolicitud, string cGrupo)
        {
            DataSet dtsExpedienteDato = new DataSet("dsExpedienteDatos");
            dtsExpedienteDato.Tables.Add(dtExpParamDat);
            return clsExpedientes.guardarExpediente(dtsExpedienteDato.GetXml(), idSolicitud, idUsuario, cTipoSolicitud, cGrupo);
        }
        public DataTable CNGuardarGrupoExpedienteTN(DataTable dtExpParamDat, int idSolicitud, int idUsuario, string cTipoSolicitud, string cGrupo)
        {
            DataSet dtsExpedienteDato = new DataSet("dsExpedienteDatos");
            dtsExpedienteDato.Tables.Add(dtExpParamDat);
            return clsExpedientes.ADGuardarExpedienteTN(dtsExpedienteDato.GetXml(), idSolicitud, idUsuario, cTipoSolicitud, cGrupo);
        }
        public DataTable obtenerIdentificaridDescTipoDoc()
        {
            return clsExpedientes.obtenerIdentificaridDescTipoDoc();
        }
        
        public DataSet obtenerExpediente(int idArchivo, int idSolicitud, int idCategoriaArchivo, string cTipoSolicitud, string cExtension, int idSecundario)
        {
            return clsExpedientes.obtenerExpediente(idArchivo, idSolicitud, idCategoriaArchivo, cTipoSolicitud, cExtension, idSecundario);
        }

        public List<ReportDataSource> getDataSource(DataTable dtDataSet, string cArchivoXml)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            try
            {
                XElement xReporte = XElement.Parse(cArchivoXml);
                XElement xListReportDataSource = xReporte.Element("ListReportDataSource");

                DataTable DataSet1;
                foreach (DataRow row in dtDataSet.Rows)
                {
                    DataSet1 = new DataTable();

                    XElement xElementoTabla = xListReportDataSource.Element(row["cDataSet"].ToString());
                    if (xElementoTabla != null && xElementoTabla.Element("NewDataSet").Value != "")
                    {
                        DataSet1.Merge(clsRptXml.xmlADatatable(xListReportDataSource.Element(row["cDataSet"].ToString()).Element("NewDataSet")));
                    }
                    /*Agregar dFechaVencimiento para extracto de cuenta*/
                    if (dtDataSet.Rows.Count > 0)
                    {
                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dsDatosGenCta" && !DataSet1.Columns.Contains("dfecVencimiento"))
                            DataSet1.Columns.Add("dfecVencimiento", typeof(String));

                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dsDatosGenerales" && !DataSet1.Columns.Contains("nCapacidadPago"))
                            DataSet1.Columns.Add("nCapacidadPago", typeof(Decimal), "-9999999.99");

                        if (dtDataSet.Rows[1]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nSMultiriesgo"))
                            DataSet1.Columns.Add("nSMultiriesgo", typeof(Decimal), "0");

                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nSMultiriesgo"))
                            DataSet1.Columns.Add("nSMultiriesgo", typeof(Decimal), "0");

                        if (dtDataSet.Rows[1]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nidPaqueteSeguro"))
                            DataSet1.Columns.Add("nidPaqueteSeguro", typeof(Decimal), "0");

                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nidPaqueteSeguro"))
                            DataSet1.Columns.Add("nidPaqueteSeguro", typeof(Decimal), "0");

                        if (dtDataSet.Rows[1]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nPaqueteSeguro"))
                            DataSet1.Columns.Add("nPaqueteSeguro", typeof(Decimal), "0");

                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nPaqueteSeguro"))
                            DataSet1.Columns.Add("nPaqueteSeguro", typeof(Decimal), "0");
                        
                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nMontoSeguroMultiriesgo"))
                            DataSet1.Columns.Add("nMontoSeguroMultiriesgo", typeof(Decimal), "0");

                        if (dtDataSet.Rows[1]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nMontoSeguroMultiriesgo"))
                            DataSet1.Columns.Add("nMontoSeguroMultiriesgo", typeof(Decimal), "0");

                        if (dtDataSet.Rows[1]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nITF"))
                            DataSet1.Columns.Add("nITF", typeof(Decimal), "0");

                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dtsPPG" && !DataSet1.Columns.Contains("nITF"))
                            DataSet1.Columns.Add("nITF", typeof(Decimal), "0");
                        
                        if (dtDataSet.Rows[0]["cDataSet"].ToString() == "dsHojaResumen" && !DataSet1.Columns.Contains("cPolizaPaquete"))
                            DataSet1.Columns.Add("cPolizaPaquete", typeof(string), "");                        
                    }


                    dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), DataSet1));
                }

                return dtslist;
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message, "Expedientes en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return dtslist;
            }
            
        }

        public List<ReportParameter> getParameters(DataTable dtParameters, DataTable dsClaves)
        {
            string cValor = "";
            List<ReportParameter> paramlist = new List<ReportParameter>();

            foreach (DataRow row in dtParameters.Rows)
            {
                if (dsClaves.Columns.Contains(row["cClave"].ToString()))
                {
                    cValor = dsClaves.Rows[0][row["cClave"].ToString()].ToString();
                }
                else
                {
                    cValor = getValueParameter(row["cClave"].ToString());
                }
                paramlist.Add(new ReportParameter(row["cParametro"].ToString(), cValor, false));
                
            }
            return paramlist;
        }

        public DataSet getMenuExpediente(int idSolicitud, string cTipoSolicitud)
        {
            return clsExpedientes.getMenuExpediente(idSolicitud, cTipoSolicitud);
        }

        public string getValueParameter(string cClave)
        {
            switch (cClave)
            {
                case "cRutaLogo": 
                    return clsVarApl.dicVarGen["CRUTALOGO"];
                case "dFechaSis":
                    return clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy").ToString();
                case "cNomAgen":
                    return clsVarGlobal.cNomAge.ToString();
                case "cNomUser":
                    return clsVarGlobal.User.cNomUsu;
                case "idUsuarioSis":
                    return clsVarGlobal.User.idUsuario.ToString();
                default:
                    return "";
            }
        }
        public List<ReportDataSource> getDataSourceExpedienteNormalJC(int idDescTipoDoc, int idSolicitud, DataTable dtDataSets, string cTipoSolicitud, int idSecundario, DataTable DTCondiciones, DataSet dsContenedorDatoSentinel)
        {
            DataSet dsDataSource = clsExpedientes.getDataSourceExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud, idSecundario);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            if (dsDataSource.Tables.Count == dtDataSets.Rows.Count)
            {
                int i = 0;
                foreach (DataRow row in dtDataSets.Rows)
                {
                    switch (row["cDataSet"].ToString())
                    {
                        case "DtValidacionCondiciones":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), DTCondiciones));
                            break;
                        case "dtsbSunatTitular":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBasicoSunatTitular"]));
                            break;
                        case "dtsBSunatDireccionT":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBSunatDireccionTitular"]));
                            break;
                        case "dtsRLegalTitular":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRlegalConyuge"]));
                            break;
                        case "dtsbSunatConyuge":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBasicoSunatConyuge"]));
                            break;
                        case "dtsBSunatDireccionC":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtBSunatDireccionConyuge"]));
                            break;
                        case "dtsRLegalConyuge":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRlegalConyuge"]));
                            break;
                        case "dtsDeudaSentinelDirecta":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtDeudaSentinelDirectaTitular"]));
                            break;
                        case "dtsLCreditoNoUtil":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtlCredNoUtilizadaT"]));
                            break;
                        case "dtsVencidoSentinel":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtDeudaTitular"]));
                            break;
                        case "dtsListAvalista":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtAvalistaTitular"]));
                            break;
                        case "dtsListAvalado":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtAvalado"]));
                            break;
                        case "dtsHistoricoSentinel":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtHistorialSentinelTitular"]));
                            break;
                        case "dtsHistoricoSentinelC":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtHistorialSentinelConyuge"]));
                            break;
                        case "dtsCalificacionTConyuge":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtClasTitularConyuge"]));
                            break;
                        case "dtsEndeudamientoTitular":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtMicrTitular"]));
                            break;
                        case "dtsEndeudamientoConyuge":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtMicrConyuge"]));
                            break;
                        case "dtsRastreo":
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsContenedorDatoSentinel.Tables["dtRastreo"]));
                            break;
                        default:
                            dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsDataSource.Tables[i]));
                            break;
                    }

                    i++;
                }

            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los datos, Número de Datos devueltos no coinciden", "Expedientes en Linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtslist;
        }
        public List<ReportDataSource> getDataSourceExpedienteNormal(int idDescTipoDoc, int idSolicitud, DataTable dtDataSets, string cTipoSolicitud, int idSecundario)
        {
            DataSet dsDataSource = clsExpedientes.getDataSourceExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud, idSecundario);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            if (dsDataSource.Tables.Count == dtDataSets.Rows.Count)
            {
                int i = 0;
                foreach (DataRow row in dtDataSets.Rows)
                {
                    dtslist.Add(new ReportDataSource(row["cDataSet"].ToString(), dsDataSource.Tables[i]));
                    i++;
                }
                
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los datos, Número de Datos devueltos no coinciden", "Expedientes en Linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dtslist;
        }

        public DataSet getDatosExpedienteNormal(int idDescTipoDoc, int idSolicitud, string cTipoSolicitud)
        {
            return clsExpedientes.getDatosExpedienteNormal(idDescTipoDoc, idSolicitud, cTipoSolicitud);
        }

        public DataTable getDatosSolicitud(int idSolicitud, string cTipoSolicitud)
        {
            if (cTipoSolicitud == "individual")
            {
                return clsExpedientes.getDatosSolicitudIndividual(idSolicitud);
            }
            else
            {
                return clsExpedientes.getDatosSolicitudGrupal(idSolicitud);
            }
            
        }

        public DataTable guardarLogError(int idSolicitud, string cGrupo, string cTipoSolicitud, string cMsgError, string cForm, int idUsuario)
        {
            return clsExpedientes.guardarLogError(idSolicitud, cGrupo, cTipoSolicitud, cMsgError, cForm, idUsuario);
        }
        #endregion
    }
}
