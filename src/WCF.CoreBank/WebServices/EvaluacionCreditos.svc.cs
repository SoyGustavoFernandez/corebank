using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using EntityLayer;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using GEN.Funciones;
using WCF.CoreBank.Interface;
using RCP.CapaNegocio;
using GEN.ControlesBase;
using System.Globalization;

namespace WCF.CoreBank.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EvaluacionCreditos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EvaluacionCreditos.svc or EvaluacionCreditos.svc.cs at the Solution Explorer and start debugging.
    public class EvaluacionCreditos : AbstractConexion, IEvaluacionCreditos
    {
        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        clsCNEvaluacion cnEvaluacion = new clsCNEvaluacion(true);
        private clsCNSolicitud cnSolicitud = new clsCNSolicitud(true);

        #region Enviar a Aprobacion la evaluacion
        //private clsEvalCred objEvalCred;
        //private GEN.ControlesBase.ConCreditoTasa conCreditoTasa;
        //private clsCNEvaluacion objCapaNegocio;
        //private clsCreditoProp objSolicitud;
        //private int idTipEvalCred = 16;     
        //private int idCanal;
        #endregion

        public EvaluacionCreditos()
        {
            this.setConectionString();
        }

        public IList<clsSolicitudEvaluacion> ListarSolicitudPendienteEvaluacion(string cToken)
        {
            IList<clsSolicitudEvaluacion> lstSolicitudEvaluacion = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtSolicitudEvaluacion = cnEvaluacion.WCFCNListarSolicitudPendienteEvaluacion(datosToken.idUsuario);
                lstSolicitudEvaluacion = dtSolicitudEvaluacion.ToList<clsSolicitudEvaluacion>();
            }

            return lstSolicitudEvaluacion;
        }

        public double GetCapacidadPago(string cToken, int idSolicitud)
        {
            double nCapacidadPago = 88.33;
            return nCapacidadPago;
        }

        public IList<clsBalanceGeneral> GetBalanceGeneral(string cToken, int idTipEvalCred, int idEvalcred)
        {
            IList<clsBalanceGeneral> lstBalanceGeneral= null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtBalanceGeneral = cnEvaluacion.WCFCNGetBalanceGeneral(idTipEvalCred, idEvalcred);
                lstBalanceGeneral = dtBalanceGeneral.ToList<clsBalanceGeneral>();
            }
            return lstBalanceGeneral;
        }

        public IList<clsEstadoResultados> GetEstadoResultados(string cToken, int idTipEvalCred, int idEvalcred)
        {

            IList<clsEstadoResultados> lstEstadoresultados = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
            DataTable dtEstadoresultados = cnEvaluacion.WCFCNGetEstadoResultados(idTipEvalCred, idEvalcred);
                lstEstadoresultados = dtEstadoresultados.ToList<clsEstadoResultados>();
            }

            return lstEstadoresultados;
        }

        public clsWCFRespuesta GuardarEvaluacionCredito(string cToken, int idSolicitud ,int idEvalCred, List<clsEstResEval> listEstadoResultado, List<clsBalGenEval> listBalance, Decimal nCapacidadPago, Decimal nEndeudamientoTotal)
        { 
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFRespuesta objRes = new clsWCFRespuesta();
            
            if (!usuario.validaToken(cToken))
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "Acceso denegado";
                return objRes;
            }

            DataTable dtRes = cnEvaluacion.WCFCNGuardarEvaluacionCred(idSolicitud, idEvalCred, clsUtils.ListToXml<clsEstResEval>((List<clsEstResEval>)listEstadoResultado), clsUtils.ListToXml<clsBalGenEval>((List<clsBalGenEval>)listBalance), nCapacidadPago, nEndeudamientoTotal, datosToken.idUsuario);
            if (dtRes.Rows.Count == 0)
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "Error al registrar la evaluación";
                return objRes;
            }

            objRes.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["nResultado"]);
            objRes.cMensaje = dtRes.Rows[0]["cMensaje"].ToString();

            return objRes;
        }

        public clsWCFRespuesta EnviarAAprobacion(string cToken, int idEvalCred, int idSolicitud, int idCli, int idMoneda, decimal nMonto, int idProducto)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFRespuesta objRes = new clsWCFRespuesta();

            if (!usuario.validaToken(cToken))
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "Acceso denegado";
                return objRes;
            }



            DataTable dtEstadoresultados = cnEvaluacion.WCFCNGetCondicionesCredito(idEvalCred);
            if (dtEstadoresultados.Rows.Count == 0)
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "No se encontró la solicitud número: "+idSolicitud.ToString();
                return objRes;
            }

            clsCreditoProp oEvalCredTemp = FormatearSolicitud(dtEstadoresultados, datosToken.idAgencia); //= this.conCreditoTasa.ObtenerCreditoPropuesto();

            //********************************************
            // Reglas Dinamicas
            //********************************************
            #region Reglas Dinamicas Eval Andy
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros(oEvalCredTemp);
            //////////////////**//////////////
            clsCNValidaReglasDinamicas oReglas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = oReglas.ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: "frmEvaluacionAppMovil",
                                                                            idAgencia: datosToken.idAgencia,
                                                                            idCliente: oEvalCredTemp.idCli,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: oEvalCredTemp.idMoneda,
                                                                            idProducto: oEvalCredTemp.idProducto,
                                                                            nValAproba: oEvalCredTemp.nMonto,
                                                                            idDocument: oEvalCredTemp.idSolicitud,
                                                                            dFecSolici: datosToken.dFechaSistema,
                                                                            idMotivo: 2,
                                                                            idEstadoSol: 13,
                                                                            idUsuRegist: datosToken.idUsuario,
                                                                            idSolApr: ref nNivAuto, lMostrarAlerta: false
                                                                            );

            if (!cCumpleReglas.Equals("Cumple"))
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = oReglas.cMensajeErrores;
                return objRes;
            }

            #endregion

            // ------------------------------------------------------------------------
            int idCanal = 0;
            int idCanalAproCredTemp = 0;
            int lCanalAproCredEditable = 0;
            int nCantidadCanales = 0;

            DataSet dsCanales = this.cnEvaluacion.DeterminarCanalesAprobacion(datosToken.idEstablecimiento,
                    datosToken.idTipoEstablecimiento,
                    idSolicitud,
                    idCli,
                    nMonto,
                    idProducto,
                    Convert.ToInt32(dtEstadoresultados.Rows[0]["idOperacion"].ToString())
                    );

            if (dsCanales.Tables.Count > 0)
            {
                nCantidadCanales = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["nCantidadCanales"]);

                if (nCantidadCanales == -1)
                {
                    objRes.idRespuesta = 0;
                    objRes.cMensaje = dsCanales.Tables[0].Rows[0]["cMensaje"].ToString();
                    return objRes;
                }
                else if (nCantidadCanales == 0)
                {
                    objRes.idRespuesta = 0;
                    objRes.cMensaje = dsCanales.Tables[0].Rows[0]["cMensaje"].ToString();
                    return objRes;
                }
            }
            else {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "No se encontraron canales de aprobación configurados";
                return objRes;  
            }

            if (nCantidadCanales == 1)
            {
                idCanal = Convert.ToInt32(dsCanales.Tables[1].Rows[0]["idCanalAproCred"]);
            }
            else
            {
                if (datosToken.idTipoEstablecimiento == 8)
                {
                    idCanal = 1; // se asigna el canal A
                }//EOB
            }

            string xmlDestCredProp = oEvalCredTemp.GetXml();

            DataTable dtEnvCom = cnEvaluacion.EnviarAComiteCreditosRapid(idEvalCred,
                datosToken.idUsuario,
                datosToken.dFechaSistema,
                xmlDestCredProp,
                idCanal,
                lCanalAproCredEditable,
                true,
                datosToken.idPerfil
            );

            objRes.idRespuesta = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);
            objRes.cMensaje = dtEnvCom.Rows[0]["cMensaje"].ToString();
            return objRes;

        }

        #region Metodos
        public clsCreditoProp FormatearSolicitud(DataTable dt, int idAgencia)
        {
            new clsCNVarGen().LisVar(idAgencia);
            new clsCNVarApl().LisVar(idAgencia); 

            clsCreditoProp oProp = new clsCreditoProp()
            {
                idOrigenCredProp = 2,
                idSolicitud = Convert.ToInt32(dt.Rows[0]["idSolicitud"]),
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = Convert.ToDecimal(dt.Rows[0]["nCapitalPropuesto"]),
                nCuotas = Convert.ToInt32(dt.Rows[0]["nCuotas"]),
                idTipoPeriodo = Convert.ToInt32(dt.Rows[0]["idTipoPeriodo"]),
                nPlazoCuota = Convert.ToInt32(dt.Rows[0]["nPlazoCuotaPropuesto"]),
                nDiasGracia = Convert.ToInt32(dt.Rows[0]["nDiasGracia"]),
                idTasa = Convert.ToInt32(dt.Rows[0]["idTasa"]),
                dFechaDesembolso = DateTime.ParseExact(dt.Rows[0]["cFechaDesembolso"].ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture),
                dFechaPrimeraCuota = DateTime.ParseExact(dt.Rows[0]["cFechaPrimeraCuota"].ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture),
                nTasaCompensatoria = Convert.ToDecimal(dt.Rows[0]["nTEA"]),
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = Convert.ToString(dt.Rows[0]["tObservacion"]),
                nCuotasGracia = Convert.ToInt32(dt.Rows[0]["nCuotasGracia"]),
                idCli = Convert.ToInt32(dt.Rows[0]["idCli"]),
                idEvalCred = Convert.ToInt32(dt.Rows[0]["idEvalCred"]),
                idModalidadCredito = Convert.ToInt32(dt.Rows[0]["idModalidadCredito"]),
                idOperacion = Convert.ToInt32(dt.Rows[0]["idOperacion"]),
                idSubProducto = Convert.ToInt32(dt.Rows[0]["idProducto"]),
            };

            ConCreditoTasa con = new ConCreditoTasa();

            con.AsignarDatosObj(oProp);
            con.GeneraPlanPagos();
            oProp.nCuotaAprox = con.CuotaAprox();
            oProp.nCuotaGraciaAprox = con.CuotaGraciaAprox();

            return oProp;
        }

        public clsCreditoProp FormatearSolicitud(int idEvalCred, int idPeriodoCred, int nCuotas, int nDiasGracia, string cFechaDesembolso, string cFechaPrimeraCuota, decimal nCapitalPropuesto, int idTasa, decimal nTEA, decimal nTIM, int idProducto, int idTipoPeriodo, int nPlazoCuotaPropuesto, int idSolicitud, int idAgencia)
        {
            new clsCNVarGen().LisVar(idAgencia);
            new clsCNVarApl().LisVar(idAgencia); 

            clsCreditoProp oProp = new clsCreditoProp()
            {
                idOrigenCredProp = 2,
                idSolicitud = idSolicitud,
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = nCapitalPropuesto,
                nCuotas = nCuotas,
                idTipoPeriodo = idTipoPeriodo,
                nPlazoCuota = nPlazoCuotaPropuesto,
                nDiasGracia = nDiasGracia,
                idTasa = idTasa,
                dFechaDesembolso = DateTime.ParseExact(cFechaDesembolso, "dd/MM/yyyy", CultureInfo.CurrentCulture),
                dFechaPrimeraCuota = DateTime.ParseExact(cFechaPrimeraCuota, "dd/MM/yyyy", CultureInfo.CurrentCulture),
                nTasaCompensatoria = nTEA,
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = "",
                nCuotasGracia = 0
            };

            ConCreditoTasa con = new ConCreditoTasa();

            con.AsignarDatosObj(oProp);
            con.GeneraPlanPagos();
            oProp.nCuotaAprox = con.CuotaAprox();
            oProp.nCuotaGraciaAprox = con.CuotaGraciaAprox();

            return oProp;
        }

        public clsCreditoProp GeneraCreditoProPorSolicitudCred(clsSolicitudCreditos obj)
        {
            clsCreditoProp objRes = new clsCreditoProp();
            objRes.idTipoPeriodo = obj.idTipoPeriodo;
            objRes.idMoneda = obj.IdMoneda;
            objRes.nMonto = obj.nCapitalSolicitado;
            objRes.nCuotas = obj.nCuotas;
            objRes.nPlazoCuota = obj.nPlazoCuota;
            objRes.nCuotasGracia = obj.nCuotasGracia;
            objRes.nDiasGracia = obj.ndiasgracia;
            objRes.dFechaDesembolso = obj.dFechaDesembolsoSugerido;
            objRes.idProducto = obj.idProducto;
            objRes.idTasa = obj.idTasa;
            objRes.nTasaCompensatoria = obj.nTasaCompensatoria;

            return objRes;
        }

        public clsCondicionesCredito GetCondicionesCredito(string cToken, int idEvalCred)
        {
            try
            {
            IList<clsCondicionesCredito> lstCondicionesCred = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtEstadoresultados = cnEvaluacion.WCFCNGetCondicionesCredito(idEvalCred);
            lstCondicionesCred = dtEstadoresultados.ToList<clsCondicionesCredito>();
            }

                return lstCondicionesCred[0];
            }
            catch (Exception e)
            {
                clsCondicionesCredito obj = new clsCondicionesCredito();
                obj.oRes = new clsWCFRespuesta();
                obj.oRes.cMensaje = e.Message+"    ---    "+  e.StackTrace;
                return obj;
            }
        }

        public clsWCFRespuesta GuardarPropuestaEval(string cToken, int idEvalCred, int idPeriodoCred, int nCuotas, int nDiasGracia, string cFechaDesembolso, string cFechaPrimeraCuota, decimal nCapitalPropuesto, int idTasa, decimal nTEA, decimal nTIM, int idProducto, int idTipoPeriodo, int nPlazoCuotaPropuesto, int idSolicitud)
        {
            try
            {
                IList<clsWCFRespuesta> lstCondicionesCred = null;
                clsDatosToken datosToken = new clsDatosToken();
                datosToken = usuario.obtenerDatosToken(cToken);

                if (usuario.validaToken(cToken))
                {
                    clsCreditoProp oProp = FormatearSolicitud(idEvalCred, idPeriodoCred, nCuotas, nDiasGracia, cFechaDesembolso, cFechaPrimeraCuota, nCapitalPropuesto, idTasa, nTEA, nTIM, idProducto, idTipoPeriodo, nPlazoCuotaPropuesto, idSolicitud, datosToken.idAgencia);

                    DataTable dtEstadoresultados = cnEvaluacion.WCFCNActualizarPropuesta(idEvalCred, idPeriodoCred, nCuotas, nDiasGracia, cFechaDesembolso, cFechaPrimeraCuota, nCapitalPropuesto, idTasa, nTEA, nTIM, idProducto, idTipoPeriodo, nPlazoCuotaPropuesto, idSolicitud, oProp.nCuotaAprox, oProp.nCuotaGraciaAprox);
                    lstCondicionesCred = dtEstadoresultados.ToList<clsWCFRespuesta>();
                    return lstCondicionesCred[0];
                }
                else
                {
                    clsWCFRespuesta obj = new clsWCFRespuesta();
                    obj.cMensaje = "Sesión terminada, vuelva a iniciar sesión";
                    return obj;
                }
            }
            catch (Exception e)
            {
                clsWCFRespuesta obj = new clsWCFRespuesta();
                obj.cMensaje = e.Message + "    ---    " + e.StackTrace;
                return obj;
            }
        }



        public clsWCFRespuesta GuardarReferencias(string cToken, int idEvalCred, List<clsReferenciaEval> list)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFRespuesta objRes = new clsWCFRespuesta();

            if (!usuario.validaToken(cToken))
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "Acceso denegado";
                return objRes;
            }

            DataTable dtRes = cnEvaluacion.WCFCNGuardarReferenciaEvalCred(idEvalCred, clsUtils.ListToXml<clsReferenciaEval>((List<clsReferenciaEval>)list));
            if (dtRes.Rows.Count == 0)
            {
                objRes.idRespuesta = 0;
                objRes.cMensaje = "Error al registrar la evaluación";
                return objRes;
            }

            objRes.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["nResultado"]);
            objRes.cMensaje = dtRes.Rows[0]["cMensaje"].ToString();

            return objRes;
        }

        public IList<clsReferenciaEval> ObtenerReferencias(string cToken, int idEvalcred)
        {

            IList<clsReferenciaEval> lstEstadoresultados = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
            DataTable dtEstadoresultados = cnEvaluacion.WCFCNGetObtenerReferencias(idEvalcred);
            lstEstadoresultados = dtEstadoresultados.ToList<clsReferenciaEval>();
            }

            return lstEstadoresultados;
        }

        public clsWCFSolicitudTipoDocumento SolicitudTipoDocumentoExpediente(string cToken, int idCliente)
        {
            clsWCFSolicitudTipoDocumento objResultado = new clsWCFSolicitudTipoDocumento();
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtSolicitud = cnEvaluacion.WCFSolicitudIdCli(idCliente);
                if (dtSolicitud.Rows.Count > 0)
                {
                    objResultado.idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"].ToString());
                    objResultado.idProducto = Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"].ToString());
                    objResultado.cProducto = dtSolicitud.Rows[0]["cProducto"].ToString();
                    DataTable dtTiposDocumento = cnEvaluacion.WCFTiposDocumento(objResultado.idSolicitud, datosToken.idUsuario);
                    objResultado.lTipoDocumento = dtTiposDocumento.ToList<clsWCFTipoDocumentoArchivo>();
                }
            }

            return objResultado;
        }

        public clsWCFRespuesta RegistroArchivoEscaneado(string cToken, int idSolicitud, int idDescTipoDoc, int idTipoArchivo, string cArchivoContent)
        {
            clsWCFRespuesta objResultado = new clsWCFRespuesta();
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                try
                {
                    clsCNAdministracionFiles clsFiles = new clsCNAdministracionFiles(true);
                    if (clsFiles.enPreAprobacion(idSolicitud))
                    {
                        byte[] archivoContentDecoded = Compresion.CompressedByte(
                            Convert.FromBase64CharArray(cArchivoContent.ToCharArray(), 0, cArchivoContent.Length)
                        );
                        String fileName = "AppScan-" + DateTime.Now.ToString("yyyyMMddhhmmss") + "-" + Guid.NewGuid().ToString();
                        DataTable dtResult = clsFiles.cargarArchivo(idSolicitud, idDescTipoDoc, idTipoArchivo, fileName, archivoContentDecoded, ".pdf", datosToken.idUsuario);
                        if (dtResult.Rows.Count > 0)
                        {
                            if (dtResult.Rows[0]["idEstado"].ToString() == "1")
                            {
                                objResultado.idRespuesta = 0;
                                objResultado.cMensaje = "Archivo guardado exitosamente";
                            }
                            else
                            {
                                objResultado.idRespuesta = 1;
                                objResultado.cMensaje = "Error al guardar el archivo";
                            }
                        }
                        else
                        {
                            objResultado.idRespuesta = 1;
                            objResultado.cMensaje = "Error al guardar el archivo";
                        }
                    }
                    else
                    {
                        objResultado.idRespuesta = 1;
                        objResultado.cMensaje = "Error no se puede guardar el archivo";
                    }
                }
                catch (Exception e)
                {
                    objResultado.idRespuesta = 1;
                    objResultado.cMensaje = e.Message;
                }
            }
            else
            {
                objResultado.idRespuesta = 1;
                objResultado.cMensaje = "Error no hay sesión activa";
            }
            return objResultado;
        }

        #endregion

        #region Metodos Privados

        private clsWCFRespuesta GuardarDesicion(int idSolicitud, int idAprobacion, int idEvalCred, decimal nMonto, string cComentario, int idMotRechazo, int idUsuario, int idPerfil, DateTime dFechaSistema, int idAgencia, int idCanal)
        {
            clsWCFRespuesta res = new clsWCFRespuesta();
            IList<clsWCFGestionAprobacion> lstGestion = null;
            
            int idCanalReg = 2;
            
            DataSet dsInicializacion = new clsCNHojaRuta(true).WCFInicializarCreditoAprobacion(idEvalCred, idUsuario, idPerfil, dFechaSistema);
            if (Convert.ToInt32(dsInicializacion.Tables[0].Rows[0]["idError"]) == 1)
            {
                res.cMensaje = Convert.ToString(dsInicializacion.Tables[0].Rows[0]["cMensaje"]);
                res.idRespuesta = 1;
                return res;
            }

            DataTable dtGestion = new clsCNHojaRuta(true).WCFCreditosAprobacionGestion(idSolicitud, idEvalCred, idAgencia, nMonto);
            lstGestion = dtGestion.ToList<clsWCFGestionAprobacion>();

            if (idAprobacion == 5)
            {

                if (lstGestion[0].idError == 0)
                {
                    DataTable guardar = new clsCNHojaRuta(true).WCFCreditosAprobacionGuardar(idSolicitud, idEvalCred, idUsuario, lstGestion[0].idEstadoEvalCred, 4, lstGestion[0].idNivelAprobacion, lstGestion[0].lEnviaSolInfRiesgos, lstGestion[0].lRevision, cComentario, false, 0, dFechaSistema, idCanalReg);
                    if (Convert.ToInt32(guardar.Rows[0]["idError"]) == 0)
                    {
                        res.idRespuesta = 1;
                        res.cMensaje = lstGestion[0].cMensaje;
                        res.oAprobacion = lstGestion[0];
                        return res;
                    }
                    else
                    {
                        res.cMensaje = "" + guardar.Rows[0]["cMensaje"];
                        res.idRespuesta = 1;
                        res.oAprobacion = lstGestion[0];
                        return res;
                    }
                }
                else
                {
                    res.cMensaje = lstGestion[0].cMensaje;
                    res.idRespuesta = 1;
                    res.oAprobacion = lstGestion[0];
                    return res;
                }
            }
            else
            {
                DataTable guardar = new clsCNHojaRuta(true).WCFCreditosAprobacionGuardar(idSolicitud, idEvalCred, idUsuario, idAprobacion, 5, lstGestion[0].idNivelAprobacion, false, false, cComentario, false, idMotRechazo, dFechaSistema, idCanalReg);
                if (Convert.ToInt32(guardar.Rows[0]["idError"]) == 0)
                {
                    res.cMensaje = "Credito rechazado";
                    return res;
                }
                else
                {
                    res.cMensaje = "" + guardar.Rows[0]["cMensaje"];
                    res.idRespuesta = 1;
                    return res;
                }
            }
        }

        private DataTable ArmarTablaParametros(clsCreditoProp oEvalCredTemp)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = oEvalCredTemp.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = oEvalCredTemp.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEvalCred";
            drfila[1] = oEvalCredTemp.idEvalCred;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacion";
            drfila[1] = oEvalCredTemp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = oEvalCredTemp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = oEvalCredTemp.idSubProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = oEvalCredTemp.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = (oEvalCredTemp.idTipoPeriodo == 1) ? oEvalCredTemp.nCuotas : (int)Math.Round(((oEvalCredTemp.nCuotas * oEvalCredTemp.nPlazoCuota) / 30.000), 0);//oEvalCredTemp.nPlazo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = oEvalCredTemp.nMonto;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool ValidarReglas(bool lMostrarAlerta, clsCreditoProp oEvalCredTemp)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros(oEvalCredTemp);
            //////////////////**//////////////
            clsCNValidaReglasDinamicas oReglas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = oReglas.ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: "frmEvaluacionAppMovil",
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: oEvalCredTemp.idCli,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: oEvalCredTemp.idMoneda,
                                                                            idProducto: oEvalCredTemp.idProducto,
                                                                            nValAproba: oEvalCredTemp.nMonto,
                                                                            idDocument: oEvalCredTemp.idSolicitud,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 2,
                                                                            idEstadoSol: 13,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto, lMostrarAlerta: lMostrarAlerta);

            if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
