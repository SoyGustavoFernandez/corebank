using CRE.CapaNegocio;
using GEN.CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using WCF.Authorization.Negocio;
using WCF.KasNet.Helper;
using WCF.KasNet.Interfaces;
using WCF.KasNet.Modelo;
using GEN.Funciones;
using System.Reflection;

namespace WCF.KasNet
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KasNet" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KasNet.svc or KasNet.svc.cs at the Solution Explorer and start debugging.
    public class KasNet : IKasNet
    {
        public ResAuth auth(ReqAuth objReqAuth)
        {
            ResAuth objResAuth = new ResAuth();
            int idAPITransacLogKasNet = 0;

            try
            {
                if (objReqAuth.usuario == null ||
                    objReqAuth.clave == null)
                {
                    objResAuth.codigo = "98";
                    objResAuth.mensaje = "Error 98. Parametros incorrectos.";
                    return objResAuth;
                }

                clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
                DataTable dtRegReqTransLogKasNet = new DataTable();
                DataTable dtValCredenciales = new DataTable();

                //------------------------
                //Registra Log Request
                //------------------------
                XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqAuth));
                var xml = string.Empty;

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, objReqAuth);
                        xml = sww.ToString();
                    }
                }

                string cTipo = "Auth";
                string xINxml = xml;
                DateTime dFechaIni = DateTime.Now;

                dtRegReqTransLogKasNet = objCNCredencialTokenValidador.CNRegRequestAPITransacLogKasNet(cTipo, xINxml, dFechaIni, 0);
                //------------------------

                //------------------------
                //Ejecuta Evento
                //------------------------
                int idAPIUsuarioAuth;
                string cToken;
                int idApiEmpresa = 3; //Por Empresa KasNet

                dtValCredenciales = objCNCredencialTokenValidador.CNValidarCredenciales(objReqAuth.usuario, clsHash.ComputeSha256Hash(objReqAuth.clave), idApiEmpresa);
                
                if (dtValCredenciales.Rows.Count > 0)
                {
                    idAPIUsuarioAuth = Convert.ToInt32(dtValCredenciales.Rows[0]["idAPIUsuarioAuth"]);
                    cToken = clsJwt.GetJwt(objReqAuth.usuario, objReqAuth.clave, idAPIUsuarioAuth);

                    dtValCredenciales = objCNCredencialTokenValidador.CNGuardarToken(idAPIUsuarioAuth, cToken);

                    objResAuth.codigo = "00";
                    objResAuth.mensaje = "success";
                    objResAuth.expires_in = WCF.Authorization.Negocio.clsTokenValidador.DefaultMinutesUntilTokenExpires;
                    objResAuth.token = cToken;
                    objResAuth.refresh_token = string.Empty;
                }
                else
                {
                    objResAuth.codigo = "01";
                    objResAuth.mensaje = "Error 01. Validacion incorrecta.";
                }
                //------------------------

                //------------------------
                //Registra Log Response
                //------------------------
                xsSubmit = new XmlSerializer(typeof(ResAuth));
                xml = string.Empty;

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, objResAuth);
                        xml = sww.ToString();
                    }
                }

                idAPITransacLogKasNet = (dtRegReqTransLogKasNet.Rows.Count > 0) ? Convert.ToInt32(dtRegReqTransLogKasNet.Rows[0]["idAPITransacLogKasNet"]) : 0;
                string xOUTxml = xml;
                DateTime dFechaFin = DateTime.Now;

                objCNCredencialTokenValidador.CNRegResponseAPITransacLogKasNet(idAPITransacLogKasNet, xOUTxml, dFechaFin, 0);
                //------------------------                
            }
            catch (Exception e)
            {                
                objResAuth.codigo = "99";
                objResAuth.mensaje = "Error 99. Error general interno.";
                FinalizarLogResponse<ResAuth>(objResAuth, idAPITransacLogKasNet, 0);
            }

            return objResAuth;
        }

        public ResDebtConsult debtconsult(string nroSumin, string traceConsulta, string fechaConsulta, string horaConsulta, string codEmpresa, string codServicio, string codAgencia, string codCanal, string terminal)
        {
            ResDebtConsult objResDebtConsult = new ResDebtConsult();
            ReqDebtConsult jsonReqDebtConsult = new ReqDebtConsult();
            DataTable dtConsulta = new DataTable();

            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            
            int idAPITransacLogKasNet = 0;
            int idAPIUsuarioAuth = 0;
            XmlSerializer xsSubmit;
            var xml = string.Empty;

            string cCodErrorInterno = string.Empty;

            while (true)
            {
                //------------------------
                //Revisa y Valida Request
                //------------------------
                try
                {
                    if (nroSumin == null ||
                    traceConsulta == null ||
                    fechaConsulta == null ||
                    horaConsulta == null ||
                    codEmpresa == null ||
                    codServicio == null ||
                    codAgencia == null ||
                    codCanal == null ||
                    terminal == null
                    )
                    {
                        objResDebtConsult = new ResDebtConsult();
                        objResDebtConsult.codigo = "98";
                        objResDebtConsult.mensaje = "Error 98. Parametros incorrectos.";                        
                        break;                        
                    }


                    var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                    if (string.IsNullOrWhiteSpace(cAuthorization))
                    {
                        throw new WebFaultException(HttpStatusCode.Forbidden);
                    }

                    var cToken = cAuthorization.Substring(7);
                    var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

                    idAPIUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                }
                catch (Exception e)
                {
                    objResDebtConsult = new ResDebtConsult();
                    objResDebtConsult.codigo = "99";
                    objResDebtConsult.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0101";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("DebtConsult", nroSumin, traceConsulta, "", DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------

                //------------------------
                //Registra Log Request
                //------------------------
                try
                {
                    jsonReqDebtConsult = new ReqDebtConsult();
                    jsonReqDebtConsult.nroSumin = nroSumin;
                    jsonReqDebtConsult.traceConsulta = traceConsulta;
                    jsonReqDebtConsult.fechaConsulta = fechaConsulta;
                    jsonReqDebtConsult.horaConsulta = horaConsulta;
                    jsonReqDebtConsult.codEmpresa = codEmpresa;
                    jsonReqDebtConsult.codServicio = codServicio;
                    jsonReqDebtConsult.codAgencia = codAgencia;
                    jsonReqDebtConsult.codCanal = codCanal;
                    jsonReqDebtConsult.terminal = terminal;

                    DataTable dtRegReqTransLogKasNet = new DataTable();
                    
                    xsSubmit = new XmlSerializer(typeof(ReqDebtConsult));
                    xml = string.Empty;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, jsonReqDebtConsult);
                            xml = sww.ToString();
                        }
                    }

                    string cTipo = "DebtConsult";
                    string xINxml = xml;
                    DateTime dFechaIni = DateTime.Now;

                    dtRegReqTransLogKasNet = objCNCredencialTokenValidador.CNRegRequestAPITransacLogKasNet(cTipo, xINxml, dFechaIni, idAPIUsuarioAuth);
                    idAPITransacLogKasNet = (dtRegReqTransLogKasNet.Rows.Count > 0) ? Convert.ToInt32(dtRegReqTransLogKasNet.Rows[0]["idAPITransacLogKasNet"]) : 0;                    
                }
                catch (Exception e)
                {
                    objResDebtConsult = new ResDebtConsult();
                    objResDebtConsult.codigo = "99";
                    objResDebtConsult.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0102";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("DebtConsult", nroSumin, traceConsulta, "", DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------

                //------------------------
                //Ejecuta Evento
                //------------------------
                try
                {                    
                    clsCNAPIKasNet objCNAPIKasNet = new clsCNAPIKasNet(true);                    

                    dtConsulta = objCNAPIKasNet.CNConsulta(Convert.ToInt32(jsonReqDebtConsult.nroSumin),
                            Convert.ToString(jsonReqDebtConsult.traceConsulta),
                            Convert.ToString(jsonReqDebtConsult.fechaConsulta),
                            Convert.ToString(jsonReqDebtConsult.horaConsulta),
                            Convert.ToString(jsonReqDebtConsult.codEmpresa),
                            Convert.ToString(jsonReqDebtConsult.codServicio),
                            Convert.ToString(jsonReqDebtConsult.codAgencia),
                            Convert.ToString(jsonReqDebtConsult.codCanal),
                            Convert.ToString(jsonReqDebtConsult.terminal)
                        );

                    if (dtConsulta.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dtConsulta.Rows[0]["lResultado"]))
                        {
                            WCF.KasNet.Modelo.ResDebtConsult.clsLstdebt objLstdebt = new WCF.KasNet.Modelo.ResDebtConsult.clsLstdebt();
                            WCF.KasNet.Modelo.ResDebtConsult.clsConceptosAdicionales objConceptosAdicionales = new WCF.KasNet.Modelo.ResDebtConsult.clsConceptosAdicionales();

                            objResDebtConsult.codigo = Convert.ToString(dtConsulta.Rows[0]["cEstCode"]);
                            objResDebtConsult.mensaje = Convert.ToString(dtConsulta.Rows[0]["cMensaje"]);
                            objResDebtConsult.nombreCliente = Convert.ToString(dtConsulta.Rows[0]["cNombreCliente"]);
                            objResDebtConsult.nroSumin = Convert.ToString(dtConsulta.Rows[0]["cNroSumin"]);
                            objResDebtConsult.ordenPrelacion = Convert.ToString(dtConsulta.Rows[0]["cOrdenPrelacion"]);

                            objResDebtConsult.lstdebt = new List<WCF.KasNet.Modelo.ResDebtConsult.clsLstdebt>();

                            for (int i = 0; i < dtConsulta.Rows.Count; i++)
                            {
                                objLstdebt = new WCF.KasNet.Modelo.ResDebtConsult.clsLstdebt();

                                objLstdebt.numFactura = Convert.ToString(dtConsulta.Rows[i]["cNumFactura"]);
                                objLstdebt.tipoMoneda = Convert.ToInt32(dtConsulta.Rows[i]["nTipoMoneda"]); //Valor Constante Soles
                                objLstdebt.montoTipoCambio = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]);
                                objLstdebt.montoDeuda = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoDeuda"]);
                                objLstdebt.montoDeudaConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoDeudaConvertido"]);
                                objLstdebt.comision = Convert.ToDecimal(dtConsulta.Rows[i]["nComision"]);
                                objLstdebt.comisionConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nComisionConvertido"]);

                                objLstdebt.conceptosAdicionales = new List<ResDebtConsult.clsConceptosAdicionales>();

                                objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Mora";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal(Convert.ToDecimal(dtConsulta.Rows[i]["nMora"]) / Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]));
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nMora"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);

                                objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Interes";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal((Convert.ToDecimal(dtConsulta.Rows[i]["nInteres"]) + Convert.ToDecimal(dtConsulta.Rows[i]["nInteresComp"])) / Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]));
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nInteres"]) + Convert.ToDecimal(dtConsulta.Rows[i]["nInteresComp"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);

                                /*objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Interes Compensatorio";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal(dtConsulta.Rows[i]["nInteresComp"]);
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nInteresComp"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);*/

                                objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Otros";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal(Convert.ToDecimal(dtConsulta.Rows[i]["nOtros"]) / Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]));
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nOtros"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);

                                objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Itf";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal(Convert.ToDecimal(dtConsulta.Rows[i]["nITF"]) / Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]));
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nITF"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);

                                objConceptosAdicionales = new ResDebtConsult.clsConceptosAdicionales();
                                objConceptosAdicionales.nombreConcepto = "Redondeo";
                                objConceptosAdicionales.montoConcepto = Convert.ToDecimal(Convert.ToDecimal(dtConsulta.Rows[i]["nRedondeo"]) / Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTipoCambio"]));
                                objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nRedondeo"]);
                                objLstdebt.conceptosAdicionales.Add(objConceptosAdicionales);

                                objLstdebt.montoTotalConcepto = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTotalConcepto"]);
                                objLstdebt.montoTotalConceptoConv = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTotalConceptoConv"]);
                                objLstdebt.montoTotal = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTotal"]);
                                objLstdebt.montoTotalConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoTotalConvertido"]);
                                objLstdebt.formaPago = Convert.ToString(dtConsulta.Rows[i]["nFormaPago"]);
                                objLstdebt.montoMinimo = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoMinimo"]);
                                objLstdebt.montoMinimoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoMinimoConvertido"]);
                                objLstdebt.montoMaximo = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoMaximo"]);
                                objLstdebt.montoMaximoConvertido = Convert.ToDecimal(dtConsulta.Rows[i]["nMontoMaximoConvertido"]);
                                objLstdebt.fechaEmision = Convert.ToString(dtConsulta.Rows[i]["cFechaEmision"]);
                                objLstdebt.fechaVencimiento = Convert.ToString(dtConsulta.Rows[i]["cFechaVencimiento"]);
                                objLstdebt.tipoIntegracion = Convert.ToString(dtConsulta.Rows[i]["cTipoIntegracion"]);
                                objLstdebt.glosa = Convert.ToString(dtConsulta.Rows[i]["cGlosa"]);
                                objLstdebt.orden = Convert.ToString(dtConsulta.Rows[i]["cOrden"]);

                                objResDebtConsult.lstdebt.Add(objLstdebt);
                            }
                        }
                        else
                        {
                            objResDebtConsult = new ResDebtConsult();
                            objResDebtConsult.codigo = Convert.ToString(dtConsulta.Rows[0]["cEstCode"]);
                            objResDebtConsult.mensaje = Convert.ToString(dtConsulta.Rows[0]["cMensaje"]);
                        }
                    }
                    else
                    {
                        objResDebtConsult = new ResDebtConsult();
                        objResDebtConsult.codigo = "19";
                        objResDebtConsult.mensaje = "Error 19. Error interno.";
                    }                    
                }
                catch (Exception e)
                {
                    objResDebtConsult = new ResDebtConsult();
                    objResDebtConsult.codigo = "99";
                    objResDebtConsult.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0103";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("DebtConsult", nroSumin, traceConsulta, "", DateTime.Now, cCodErrorInterno, e.Message);                    
                }
                //------------------------

                //------------------------
                //Registra Log Response
                //------------------------
                try
                {                    
                    xsSubmit = new XmlSerializer(typeof(ResDebtConsult));
                    xml = string.Empty;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, objResDebtConsult);
                            xml = sww.ToString();
                        }
                    }


                    int idAPIHisTransKasNet = (dtConsulta.Rows.Count > 0) ? Convert.ToInt32(dtConsulta.Rows[0]["idAPIHisTransKasNet"]) : 0;
                    string xOUTxml = xml;
                    DateTime dFechaFin = DateTime.Now;

                    objCNCredencialTokenValidador.CNRegResponseAPITransacLogKasNet(idAPITransacLogKasNet, xOUTxml, dFechaFin, idAPIHisTransKasNet);
                    break;                    
                }
                catch (Exception e)
                {
                    objResDebtConsult = new ResDebtConsult();
                    objResDebtConsult.codigo = "99";
                    objResDebtConsult.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0104";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("DebtConsult", nroSumin, traceConsulta, "", DateTime.Now, cCodErrorInterno, e.Message);
                    FinalizarLogResponse<ResDebtConsult>(objResDebtConsult, idAPITransacLogKasNet, 0);
                    break;
                }
                //------------------------
            }

            return objResDebtConsult;            
        }

        public ResCreate create(ReqCreate jsonReqCreate)
        {
            ResCreate objResCreate = new ResCreate();
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);            

            int idAPITransacLogKasNet = 0;
            int idAPIUsuarioAuth = 0;            
            string cCodErrorInterno = string.Empty;

            while (true)
            {
                //------------------------
                //Revisa y Valida Request
                //------------------------
                try
                {
                    if (
                        jsonReqCreate.nroSumin == null ||
                        jsonReqCreate.numFactura == null ||
                        jsonReqCreate.tracePago == null ||
                        jsonReqCreate.traceConsulta == null ||
                        jsonReqCreate.fechaPago == null ||
                        jsonReqCreate.horaPago == null ||
                        jsonReqCreate.montoDeudaConvertido == null ||
                        jsonReqCreate.comisionConvertido == null ||
                        jsonReqCreate.conceptosAdicionales == null ||
                        jsonReqCreate.conceptosAdicionales.Count != 5 ||
                        jsonReqCreate.montoTotalConceptoConv == null ||
                        jsonReqCreate.montoTotalConvertido == null ||
                        jsonReqCreate.codEmpresa == null ||
                        jsonReqCreate.codServicio == null ||
                        jsonReqCreate.codAgencia == null ||
                        jsonReqCreate.codCanal == null ||
                        jsonReqCreate.terminal == null
                    )
                    {
                        objResCreate = new ResCreate();
                        objResCreate.codigo = "98";
                        objResCreate.mensaje = "Error 98. Parametros incorrectos.";
                        break;                        
                    }

                    //Delay 30 seg
                    //Thread.Sleep(30000);

                    var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                    if (string.IsNullOrWhiteSpace(cAuthorization))
                    {
                        throw new WebFaultException(HttpStatusCode.Forbidden);
                    }

                    var cToken = cAuthorization.Substring(7);
                    var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

                    idAPIUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                }
                catch (Exception e)
                {
                    objResCreate = new ResCreate();
                    objResCreate.codigo = "99";
                    objResCreate.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0201";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Create", jsonReqCreate.nroSumin, jsonReqCreate.traceConsulta, jsonReqCreate.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------

                //------------------------
                //Registra Log Request
                //------------------------
                try
                {
                    DataTable dtRegReqTransLogKasNet = new DataTable();
                    
                    XmlSerializer xsSubmit = new XmlSerializer(typeof(ReqCreate));
                    var xml = string.Empty;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, jsonReqCreate);
                            xml = sww.ToString();
                        }
                    }

                    string cTipo = "Create";
                    string xINxml = xml;
                    DateTime dFechaIni = DateTime.Now;

                    dtRegReqTransLogKasNet = objCNCredencialTokenValidador.CNRegRequestAPITransacLogKasNet(cTipo, xINxml, dFechaIni, idAPIUsuarioAuth);
                    idAPITransacLogKasNet = (dtRegReqTransLogKasNet.Rows.Count > 0) ? Convert.ToInt32(dtRegReqTransLogKasNet.Rows[0]["idAPITransacLogKasNet"]) : 0;                    
                }
                catch (Exception e)
                {
                    objResCreate = new ResCreate();
                    objResCreate.codigo = "99";
                    objResCreate.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0202";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Create", jsonReqCreate.nroSumin, jsonReqCreate.traceConsulta, jsonReqCreate.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------
                
                //------------------------
                //Ejecuta Evento
                //------------------------
                clsCNAPIKasNet objCNAPIKasNet = new clsCNAPIKasNet(true);
                DataTable dtCreate = new DataTable();

                try
                {
                    dtCreate = objCNAPIKasNet.CNPago(
                            Convert.ToInt32(jsonReqCreate.nroSumin),
                            (jsonReqCreate.montoTotalConvertido - jsonReqCreate.comisionConvertido),
                            jsonReqCreate.comisionConvertido,
                            jsonReqCreate.tracePago,
                            jsonReqCreate.traceConsulta,
                            jsonReqCreate.fechaPago,
                            jsonReqCreate.horaPago,
                            jsonReqCreate.codEmpresa,
                            jsonReqCreate.codServicio,
                            jsonReqCreate.codAgencia,
                            jsonReqCreate.codCanal,
                            jsonReqCreate.numFactura,
                            jsonReqCreate.terminal
                        );

                    if (dtCreate.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dtCreate.Rows[0]["lResultado"]))
                        {
                            objResCreate.codigo = Convert.ToString(dtCreate.Rows[0]["cEstCode"]);
                            objResCreate.mensaje = Convert.ToString(dtCreate.Rows[0]["cMensaje"]);
                            objResCreate.nombreCliente = Convert.ToString(dtCreate.Rows[0]["cNombreCliente"]);
                            objResCreate.nroSumin = Convert.ToString(dtCreate.Rows[0]["cNroSumin"]);
                            //objResCreate.montoDeudaConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoDeudaConvertido"]);
                            objResCreate.montoDeudaConvertido = Convert.ToDecimal(jsonReqCreate.montoDeudaConvertido);
                            objResCreate.comisionConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nComisionConvertido"]);

                            objResCreate.conceptosAdicionales = new List<ResCreate.clsConceptosAdicionales>();
                            ResCreate.clsConceptosAdicionales objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();

                            objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Mora";
                            //objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoMora"]);
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(jsonReqCreate.conceptosAdicionales[0].montoConceptoConvertido);
                            objResCreate.conceptosAdicionales.Add(objConceptosAdicionales);

                            objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Interes";
                            //objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoInteres"]) + Convert.ToDecimal(dtCreate.Rows[0]["nMontoIntComp"]);
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(jsonReqCreate.conceptosAdicionales[1].montoConceptoConvertido);
                            objResCreate.conceptosAdicionales.Add(objConceptosAdicionales);

                            /*objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Interes Compensatorio";
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoIntComp"]);*/

                            objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Otros";
                            //objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoOtros"]);
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(jsonReqCreate.conceptosAdicionales[2].montoConceptoConvertido);
                            objResCreate.conceptosAdicionales.Add(objConceptosAdicionales);

                            objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Itf";
                            //objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nITF"]);
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(jsonReqCreate.conceptosAdicionales[3].montoConceptoConvertido);
                            objResCreate.conceptosAdicionales.Add(objConceptosAdicionales);

                            objConceptosAdicionales = new ResCreate.clsConceptosAdicionales();
                            objConceptosAdicionales.nombreConcepto = "Redondeo";
                            //**objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nRedondeo"]);
                            objConceptosAdicionales.montoConceptoConvertido = Convert.ToDecimal(jsonReqCreate.conceptosAdicionales[4].montoConceptoConvertido);
                            objResCreate.conceptosAdicionales.Add(objConceptosAdicionales);

                            //objResCreate.montoTotalConceptoConv = Convert.ToDecimal(dtCreate.Rows[0]["nMontoTotalConceptoConv"]);
                            objResCreate.montoTotalConceptoConv = Convert.ToDecimal(jsonReqCreate.montoTotalConceptoConv);
                            objResCreate.montoTotalConvertido = Convert.ToDecimal(dtCreate.Rows[0]["nMontoTotalConvertido"]);
                            objResCreate.numOperacionEmpresa = Convert.ToString(dtCreate.Rows[0]["cNumOperacionEmpresa"]);
                            objResCreate.glosa = Convert.ToString(dtCreate.Rows[0]["cGlosa"]);
                        }
                        else
                        {
                            objResCreate = new ResCreate();
                            objResCreate.codigo = Convert.ToString(dtCreate.Rows[0]["cEstCode"]);
                            objResCreate.mensaje = Convert.ToString(dtCreate.Rows[0]["cMensaje"]);
                        }
                    }
                    else
                    {
                        objResCreate = new ResCreate();
                        objResCreate.codigo = "29";
                        objResCreate.mensaje = "Error 29. Error Interno.";
                    }                    
                }
                catch (Exception e)
                {
                    objResCreate = new ResCreate();
                    objResCreate.codigo = "99";
                    objResCreate.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0203";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Create", jsonReqCreate.nroSumin, jsonReqCreate.traceConsulta, jsonReqCreate.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                }
                //------------------------

                //------------------------
                //Registra Log Response
                //------------------------
                try
                {
                    int idAPIHisTransKasNet = (dtCreate.Rows.Count > 0) ? Convert.ToInt32(dtCreate.Rows[0]["idAPIHisTransKasNet"]) : 0;
                    FinalizarLogResponse<ResCreate>(objResCreate, idAPITransacLogKasNet, idAPIHisTransKasNet);
                    break;
                }
                catch (Exception e)
                {
                    cCodErrorInterno = "0204";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Create", jsonReqCreate.nroSumin, jsonReqCreate.traceConsulta, jsonReqCreate.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------
            }

            return objResCreate;           
        }

        public ResCancel cancel(ReqCancel jsonReqCancel)
        {
            ResCancel objResCancel = new ResCancel();
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);            

            int idAPITransacLogKasNet = 0;
            int idAPIUsuarioAuth = 0;
            XmlSerializer xsSubmit;
            var xml = string.Empty;
            string cCodErrorInterno = string.Empty;

            while (true)
            {
                //------------------------
                //Revisa y Valida Request
                //------------------------
                try
                {
                    if (
                        jsonReqCancel.nroSumin == null ||
                        jsonReqCancel.numFactura == null ||
                        jsonReqCancel.tracePago == null ||
                        jsonReqCancel.traceConsulta == null ||
                        jsonReqCancel.fechaPago == null ||
                        jsonReqCancel.horaPago == null ||
                        jsonReqCancel.montoDeudaConvertido == null ||
                        jsonReqCancel.comisionConvertido == null ||
                        jsonReqCancel.conceptosAdicionales == null ||
                        jsonReqCancel.montoTotalConceptoConv == null ||
                        jsonReqCancel.montoTotalConvertido == null ||
                        jsonReqCancel.codEmpresa == null ||
                        jsonReqCancel.codServicio == null ||
                        jsonReqCancel.codAgencia == null ||
                        jsonReqCancel.codCanal == null ||
                        jsonReqCancel.terminal == null
                    )
                    {
                        objResCancel = new ResCancel();
                        objResCancel.codigo = "98";
                        objResCancel.mensaje = "Error 98. Parametros incorrectos.";
                        break;                        
                    }

                    var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                    if (string.IsNullOrWhiteSpace(cAuthorization))
                    {
                        throw new WebFaultException(HttpStatusCode.Forbidden);
                    }

                    var cToken = cAuthorization.Substring(7);
                    var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

                    idAPIUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                }
                catch (Exception e)
                {
                    objResCancel = new ResCancel();
                    objResCancel.codigo = "99";
                    objResCancel.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0301";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Cancel", jsonReqCancel.nroSumin, jsonReqCancel.traceConsulta, jsonReqCancel.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------

                //------------------------
                //Registra Log Request
                //------------------------
                try
                {                    
                    DataTable dtRegReqTransLogKasNet = new DataTable();
                    
                    xsSubmit = new XmlSerializer(typeof(ReqCancel));
                    xml = string.Empty;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, jsonReqCancel);
                            xml = sww.ToString();
                        }
                    }

                    string cTipo = "Cancel";
                    string xINxml = xml;
                    DateTime dFechaIni = DateTime.Now;

                    dtRegReqTransLogKasNet = objCNCredencialTokenValidador.CNRegRequestAPITransacLogKasNet(cTipo, xINxml, dFechaIni, idAPIUsuarioAuth);
                    idAPITransacLogKasNet = (dtRegReqTransLogKasNet.Rows.Count > 0) ? Convert.ToInt32(dtRegReqTransLogKasNet.Rows[0]["idAPITransacLogKasNet"]) : 0;                    
                }
                catch (Exception e)
                {
                    objResCancel = new ResCancel();
                    objResCancel.codigo = "99";
                    objResCancel.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0302";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Cancel", jsonReqCancel.nroSumin, jsonReqCancel.traceConsulta, jsonReqCancel.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------

                //------------------------
                //Ejecuta Evento
                //------------------------
                clsCNAPIKasNet objCNAPIKasNet = new clsCNAPIKasNet(true);
                DataTable dtCancel = new DataTable();

                try
                {
                    int idUsuarioExtorno = 1;

                    dtCancel = objCNAPIKasNet.CNExtorno(
                        Convert.ToInt32(jsonReqCancel.nroSumin),
                        jsonReqCancel.montoTotalConvertido,
                        idUsuarioExtorno,
                        jsonReqCancel.tracePago,
                        jsonReqCancel.traceConsulta,
                        jsonReqCancel.fechaPago,
                        jsonReqCancel.horaPago,
                        jsonReqCancel.codEmpresa,
                        jsonReqCancel.codServicio,
                        jsonReqCancel.codAgencia,
                        jsonReqCancel.codCanal,
                        jsonReqCancel.numFactura,
                        jsonReqCancel.terminal
                    );

                    if (dtCancel.Rows.Count > 0)
                    {
                        objResCancel = new ResCancel();
                        objResCancel.codigo = Convert.ToString(dtCancel.Rows[0]["cEstCode"]);
                        objResCancel.mensaje = Convert.ToString(dtCancel.Rows[0]["cMensaje"]);
                    }
                    else
                    {
                        objResCancel = new ResCancel();
                        objResCancel.codigo = "39";
                        objResCancel.mensaje = "Error 39. Error interno.";
                    }                    
                }
                catch (Exception e)
                {
                    objResCancel = new ResCancel();
                    objResCancel.codigo = "99";
                    objResCancel.mensaje = "Error 99. Error general interno.";

                    cCodErrorInterno = "0303";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Cancel", jsonReqCancel.nroSumin, jsonReqCancel.traceConsulta, jsonReqCancel.tracePago, DateTime.Now, cCodErrorInterno, e.Message);                    
                }
                //------------------------

                //------------------------
                //Registra Log Response
                //------------------------
                try
                {                    
                    xsSubmit = new XmlSerializer(typeof(ResCancel));
                    xml = string.Empty;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, objResCancel);
                            xml = sww.ToString();
                        }
                    }

                    int idAPIHisTransKasNet = (dtCancel.Rows.Count > 0) ? Convert.ToInt32(dtCancel.Rows[0]["idAPIHisTransKasNet"]) : 0;
                    string xOUTxml = xml;
                    DateTime dFechaFin = DateTime.Now;

                    objCNCredencialTokenValidador.CNRegResponseAPITransacLogKasNet(idAPITransacLogKasNet, xOUTxml, dFechaFin, idAPIHisTransKasNet);
                    break;
                }
                catch (Exception e)
                {
                    cCodErrorInterno = "0304";
                    objCNCredencialTokenValidador.CNRegLogExceptionErrorKasNet("Cancel", jsonReqCancel.nroSumin, jsonReqCancel.traceConsulta, jsonReqCancel.tracePago, DateTime.Now, cCodErrorInterno, e.Message);
                    break;
                }
                //------------------------            
            }

            return objResCancel;       
        }

        private void FinalizarLogResponse<T>(T objResponse, int idAPITransacLogKasNet, int idAPIHisTransKasNet)
        {
            //------------------------
            //Registra Log Response
            //------------------------
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            string cXML = clsUtils.ConvertirObjetoXml<T>(objResponse);

            
            DateTime dFechaFin = DateTime.Now;

            objCNCredencialTokenValidador.CNRegResponseAPITransacLogKasNet(idAPITransacLogKasNet, cXML, dFechaFin, idAPIHisTransKasNet);
        }
    }
}
