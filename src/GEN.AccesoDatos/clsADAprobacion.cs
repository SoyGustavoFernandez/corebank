using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADAprobacion
    {
        public DataTable LisTipoOpeAproba(int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisTipoOpeAproba_SP", idTipoOperacion);
        }

        public DataTable ADExtractTipoVariable(string cVariable)
        {
            return new clsGENEjeSP().EjecSP("CRE_ExtractValorVariable_SP", cVariable);
        }

        public DataTable InsTipoOpeAproba(int idTipoOperacion, int idEstadoOperac, int idMoneda, bool lporAgencia, bool lporProducto, int idNivelProd, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_InsTipoOpeAproba_SP", idTipoOperacion, idEstadoOperac, idMoneda, lporAgencia, lporProducto, idNivelProd, lVigente);
        }

        public DataTable ActTipoOpeAproba(int idTipOpeAproba, bool lporAgencia, bool lporProducto, int idNivelProd, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActTipoOpeAproba_SP", idTipOpeAproba, lporAgencia, lporProducto, idNivelProd, lVigente);
        }

        public DataTable LisRangoAprobaOpe(int idTipOpeAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisRangoAprobaOpe_SP", idTipOpeAproba);
        }

        public DataTable InsRangoAprobaOpe(int idTipOpeAproba, int idAgencia, int idProducto, decimal nRangoMinimo, decimal nRangoMaximo, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_InsRangoAprobaOpe_SP", idTipOpeAproba, idAgencia, idProducto, nRangoMinimo, nRangoMaximo, lVigente);
        }

        public DataTable ActRangoAprobaOpe(int idRangoOperacion, decimal nRangoMinimo, decimal nRangoMaximo, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActRangoAprobaOpe_SP", idRangoOperacion, nRangoMinimo, nRangoMaximo, lVigente);
        }

        public DataTable LisNivelAprRangoOpe(int idRangoOperacion)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisNivelAprRangoOpe_SP", idRangoOperacion);
        }

        public DataTable InsNivelAprRangoOpe(int idRangoOperacion, string cNivelAproba, int nNumAprobadores, int nOrdenAprobacion, bool lVigente, bool lSoloComent)
        {
            return new clsGENEjeSP().EjecSP("ADM_InsNivelAprRangoOpe_SP", idRangoOperacion, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
        }

        public DataTable ActNivelAprRangoOpe(int idNivelAprRanOpe, string cNivelAproba, int nNumAprobadores, int nOrdenAprobacion, bool lVigente, bool lSoloComent)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActNivelAprRangoOpe_SP", idNivelAprRanOpe, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
        }

        public DataTable LisPerfilNivelAproba(int idNivelAprRanOpe)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisPerfilNivelAproba_SP", idNivelAprRanOpe);
        }

        public DataTable InsPerfilNivelAproba(int idNivelAprRanOpe, int idPerfil, int idAmbito, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_InsPerfilNivelAproba_SP", idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
        }

        public DataTable ActPerfilNivelAproba(int idNivelAprRanOpe, int idPerfil, int idAmbito, bool lVigente)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActPerfilNivelAproba_SP", idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
        }

        //--================================================================================
        //--Guardar Solicitudes de Aprobacion
        //--================================================================================
        public DataTable GuardarSolicitudAprobac(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, int IExcepcion, int idEstablecimiento, int idPerfilUser,
                                            int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return new clsGENEjeSP().EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValAproba, idDocument, dFecSolici, 
                                            idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion, idEstablecimiento, idPerfilUser, idTipoOpeExp, cLimiteExcep);
        }

        public DataTable ActualizaPerfilEstablecimientoSolicitudAprobac(int idsolAprobacion, int idEstablecimiento, int idPerfilUser)
        {
            return new clsGENEjeSP().EjecSP("GEN_UpdPerfilSoliciAproba_SP", idsolAprobacion, idEstablecimiento, idPerfilUser);
        }   

        //--================================================================================
        //--Guardar Solicitudes Recibo Utilizado
        //--================================================================================
        public DataTable GuardarSolicitudReciboUtilizado(int idRecibo, int idKardex, int idUsuRegist, int idAgencia, int idSolAproba, int idCliente, DateTime dFecAprSol)
        {
            return new clsGENEjeSP().EjecSP("ADM_RegistrarReciboSolicitud", idRecibo, idKardex, idUsuRegist, idAgencia, idSolAproba, idCliente, dFecAprSol);
        }
        //--================================================================================
        //--Guardar Solicitudes de Aprobacion Automatica
        //--================================================================================
        public DataTable GuardarSolicitudAprobacAutomatica(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, int IExcepcion,int idEstablecimiento, int idPerfilUser)
        {
            return new clsGENEjeSP().EjecSP("GEN_InsSoliciAprobaAutomatica_SP", idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion, idEstablecimiento, idPerfilUser);
        }

        //--================================================================================
        //--RECUPERA CONCEPTO DE PAGO
        //--================================================================================
        public DataTable RecuperaConceptoPago()
        {
            return new clsGENEjeSP().EjecSP("ADM_RecuperaConceptoPago");
        }

        //--================================================================================
        //--Listar Operaciones Aprobadas por Usuario
        //--================================================================================
        public DataTable ListarSolAprobadasExt(DateTime dFecOpe, int idAge, int idusu, int idModulo, string idTpOpe)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListaExtornoAprobados_Sp", dFecOpe, idAge, idusu, idModulo, idTpOpe);
        }

        //--================================================================================
        //--Listar Operaciones Aprobadas por kardex 
        //--================================================================================
        public DataTable ListarSolAprobadasExtPorKardex(DateTime dFecOpe, int idAge, int idUsu, int idModulo, string idTpOpe,int idKardex)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListaExtornoAprobados_Kardex_Sp", dFecOpe, idAge, idUsu, idModulo, idTpOpe, idKardex);
        }

        //--================================================================================
        //--Retorna Datos de la Operación para el Extorno
        //--================================================================================
        public DataTable RetDatosOpeExt(int idKardex, DateTime dFecOpe, int idAge, int idusu, int idModulo, string idTpOpe)
        {
            return new clsGENEjeSP().EjecSP("GEN_RetornaDatosExtorno_Sp", idKardex, dFecOpe, idAge, idusu, idModulo, idTpOpe);
        }

        //--================================================================================
        //--Listado de Solicitudes Pendientes de Aprobación
        //--================================================================================
        public DataTable ADLisSoliciAprobaPendiente(int idUsuario, int idPerfil, DateTime dFecSis, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisSoliciAprobaPendiente_SP", idUsuario, idPerfil, dFecSis, idAgencia);
        }
        //--================================================================================
        //--Listado de Solicitudes Aprobadas
        //--================================================================================
        public DataTable ADLisSoliciAproba(int idUsuario, int idPerfil, DateTime dFecSis)
        {
            return new clsGENEjeSP().EjecSP("ADM_ListarSoliciAproba_sp", idUsuario, idPerfil, dFecSis);
        }
        //--================================================================================
        //--Registrar Aprobación/Rechazo Solicitudes
        //--================================================================================
        public DataTable ADObtenerNivelAprobaTasa(int idSolicitud)
        {
            return new clsGENEjeSP().EjecSP("ADM_RetornaNivelAprobaTasa_SP", idSolicitud);
        }
        public DataTable ADObtenerRangoAprobaSolicitud(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_RetornaIdRangoAprobacion_SP", idSolAproba);
        }
        public DataTable ADRegAprobaSolicitud(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado, string cOpinion, DateTime dFecSis, int idPerfil, string xmlPropSolCred)
        {
            return new clsGENEjeSP().EjecSP("ADM_RegAprobaSolicitud_SP", idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dFecSis, idPerfil, xmlPropSolCred);
        }
        public DataTable ADActualizaTasaNegociada(int idTasaNegociada, decimal nTasaNegociada)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActualizaTasaNegociable_SP", idTasaNegociada, nTasaNegociada);
        }
        //--================================================================================
        //--Registrar Aprobación/Rechazo Solicitudes WebServices
        //--================================================================================
        public DataTable ADRegAprobaSolicitudWcf(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado, string cOpinion, DateTime dFecSis, int idPerfil, string xmlPropSolCred)
        {
            return new clsWCFEjeSP().EjecSP("ADM_RegAprobaSolicitud_SP", idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dFecSis, idPerfil, xmlPropSolCred);
        }
        //--================================================================================
        //--Validar Permisos para Aprobación
        //--================================================================================
        public DataTable ADValidarPermisosAprobacion(int idAgencia, int idTipoOperacion, int idEstadoOperac, int idMoneda, int idProducto, Decimal nValor, int idUsuarioAproba, int idPerfilAproba)
        {
            return new clsGENEjeSP().EjecSP("GEN_ValidarPermisosAprobacion_SP", idAgencia, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValor, idUsuarioAproba, idPerfilAproba);
        }

        //--================================================================================
        //--Cambia de estado a las solicitudes de extorno de pre sol a otro estado
        //--================================================================================
        public DataTable ADUpdEstadoSolicitud(int idEstadoSol, int idDocument, int idTipOpe, int idMoneda, int idAgencia, int idCli, int idProducto, int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("GEN_CambiaEstadoSolicitud_SP", idEstadoSol, idDocument, idTipOpe, idMoneda, idAgencia, idCli, idProducto, idSolAproba);
        }

        //--================================================================================
        //--Listar Operaciones Aprobadas por Usuario
        //--================================================================================
        public DataTable ListarSolicitudesAprobadas(int idTipOpe, int idUsario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListaSolicAprobados_Sp", idTipOpe, idUsario, idAgencia);
        }

        //--================================================================================
        //--Listar las observaciones por nivel de aprobacion
        //--================================================================================
        public DataTable ListarObsSoliciAproba(int idSolAproba, int idNivelAprRanOpe)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarObsSoliciAproba_Sp", idSolAproba, idNivelAprRanOpe);
        }

        //--================================================================================
        //--Registrar observaciones de solicitud de aprobación
        //--================================================================================
        public clsDBResp RegObsSoliciAproba(string xmlObservaciones, DateTime dFecha)
        {
            return new clsDBResp(new clsGENEjeSP().EjecSP("GEN_RegObsSoliciAproba_Sp", xmlObservaciones, dFecha));
        }

        public DataTable ListarSolicitudesExtorno(string idUsuario,string idKardex)
        {
            return new clsGENEjeSP().EjecSP("CRE_ObtenerSolicitudExtornoSolicitadoAprobado_SP", idUsuario, idKardex);
        }

        public DataTable ListarSolicitudesObservadas(int idUsuario, int idRegistro = 0)
        {
            return new clsGENEjeSP().EjecSP("CRE_ListarSolicitudesConObservaciones_SP", idUsuario, idRegistro);
        }

        public DataTable ListarObservacionesPorSolicitud(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("CRE_ListarObservacionesPorSolicitud_SP", idSolAproba);
        }

        public DataTable ActualizarMontoSolicitud(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActualizaMontoSolAprobaCartaFianza_SP", idSolAproba);
        }

        public clsDBResp GenerarNivelesAprobCreditos(int idAgencia, int idCli, int idTipOpe, int idProducto, decimal nValAproba,
                                                    int idDocument, int nOrdenAproba, string cSustento, DateTime dFecha, int idUsuario)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("CRE_GeneraNivAprobCreditos_Sp", idAgencia, idCli, idTipOpe, idProducto, nValAproba,
                                                                    idDocument, nOrdenAproba, cSustento, dFecha, idUsuario);
            return new clsDBResp(dtResult);
        }

        public DataTable ObtenerSoliciAprobaPendiente(int idTipoOperacion, int idDocument)
        {
            return new clsGENEjeSP().EjecSP("GEN_ObtenerSoliciAprobaPendiente_SP", idTipoOperacion, idDocument);
        }

        public DataTable ListarSolicitudesAprobacion(int idTipoOperacion, int idEstadoOperac, int idCliente, int idMoneda, int idProducto, int idDocument, int idUsuRegist)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListaSolicitudesAprobacion_Sp", idTipoOperacion, idEstadoOperac, idCliente, idMoneda,
                                            idProducto, idDocument, idUsuRegist);
        }
        public DataTable ConsultaAccesoTipoDestinoCmp(int idDestino)
        {
            return new clsGENEjeSP().EjecSP("ADM_ConsultaAccesoTipoDestinoCmp_SP", idDestino);
        }
        public DataTable ActualizaAccesoDestinoCmp(string Xml, int idDestino)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActualizaAccesoDestinoCmp_sp", Xml, idDestino);
        }

        public DataTable RegistrarSolicitudExcepBiometria(int idBiometriaExcep, string cBiometriaExcep, string cDocumentoID, int idEstadoSolicitud
                , int idMotivoBiometriaExcep
                , string cNombreArchivo
                , string cExtencion
                , byte[] bArchivo
                , int idTipoArchivo
                , string xmlUsuarioVerificador
                , bool lDerivacionDirecta
                , int idUsuReg
                , DateTime dFechaReg, bool lVigente, int idAgencia, int idCli, int idTipoOperacion, int idMoneda, decimal nMontoOperacion, int idProducto)
        {
            return new clsGENEjeSP().EjecSP("GEN_RegistrarSolicitudExcepBiometria_SP", idBiometriaExcep, cBiometriaExcep, cDocumentoID, idEstadoSolicitud
                , idMotivoBiometriaExcep
                , cNombreArchivo
                , cExtencion
                , bArchivo
                , idTipoArchivo
                , xmlUsuarioVerificador
                , lDerivacionDirecta
                , idUsuReg
                , dFechaReg, lVigente, idAgencia, idCli, idTipoOperacion, idMoneda, nMontoOperacion, idProducto);
        }

        public DataTable ConsultarSolicitudExcepBiometria(string cDocumentoID, int idUsuReg, DateTime dFechaReg, int idAgencia, int idCli, DateTime dFechaSis, int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("GEN_ConsultarSolicitudExcepBiometria_SP", cDocumentoID, idUsuReg, dFechaReg, idAgencia, idCli, dFechaSis, idTipoOperacion);
        }

        public DataTable EjecutarSolicitudExcepBiometria(int idSolAproba, int idBiometriaExcep, int idUsuario, DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("GEN_EjecutarSolicitudExcepBiometria_SP", idSolAproba, idBiometriaExcep, idUsuario, dFecha);
        }

        public DataTable ADListarMotivoExcepBiometrica()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarMotivosExcepcionBiometrica_SP");
        }

        public DataTable ADObtenerExcepcionBiometrica(int idBiometriaExcep)
        {
            return new clsGENEjeSP().EjecSP("GEN_ObtenerExcepcionBiometrica_SP", idBiometriaExcep);
        }


        public DataTable ADRegistrarExcepcionNotificacionSMS(   string cExcepcionNotificacionSMS    , int idCliente         , int idNotificacionSMS                 , int idRegistroTelefonico  ,
                                                                string cNumeroTelefonico            , int idEstadoSolicitud , int idMotivoExcepcionNotifiacionSMS   , int idUsuario             ,
                                                                DateTime dFechaSistema              , int idAgencia         , int idTipoOperacion                   , int idMoneda              ,
                                                                decimal nMontoOperacion             , int idProducto)
        {
            return new clsGENEjeSP().EjecSP("GEN_RegistrarExcepNotificacionSMS_SP",     cExcepcionNotificacionSMS   , idCliente         , idNotificacionSMS                 , idRegistroTelefonico  ,
                                                                                        cNumeroTelefonico           , idEstadoSolicitud , idMotivoExcepcionNotifiacionSMS   , idUsuario             ,
                                                                                        dFechaSistema               , idAgencia         , idTipoOperacion                   , idMoneda              ,
                                                                                        nMontoOperacion             , idProducto);
        }

        public DataTable ADConsultarSolicitudExcepNotificacionSMS(int idCliente, int idNotificacionSMS, int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("GEN_ConsultarSolicitudExcepNotificacionSMS_SP", idCliente, idNotificacionSMS, idTipoOperacion);
        }

        public DataTable ADEjecutarSolicitudExcepNotificacionSMS(int idSolAproba, int idExcepcionNotificacionSMS, int idNotificacionSMS, int idEstadoSolExcepcion, int idUsuario, DateTime dFechaSistema)
        {
            return new clsGENEjeSP().EjecSP("GEN_EjecutarSolicitudExcepNotificacionSMS_SP", idSolAproba, idExcepcionNotificacionSMS, idNotificacionSMS, idEstadoSolExcepcion, idUsuario, dFechaSistema);
        }

        public DataTable ADObtenerUsuarioBiometrico(int idCriterio, string cValorBusqueda, int idAgencia, int idEstablecimiento, int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("GEN_ConsultarUsuarioAprobBiometrico_SP", idCriterio, cValorBusqueda, idAgencia, idEstablecimiento, idTipoOperacion);
        }

        public DataTable ADObtenerUsuarioAutBiometrico(int idCliente)
        {
            return new clsGENEjeSP().EjecSP("GEN_ConsultarUsuarioAutBiometrico_SP", idCliente);
        }

        public DataTable ADObtenerConfigBioAutorizacion(int idAgencia, int idEstablecimiento, int idTipoOperacion, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("GEN_ConsultarConfigBioAutorizacion_SP", idAgencia, idEstablecimiento, idTipoOperacion, idMoneda);
        }

        public DataTable ADRegistrarOperacionKardexBioExcepcion(string xmlBiometriaExcepcionOperacion, int idUsuario, DateTime dFechaSistema)
        {
            return new clsGENEjeSP().EjecSP("GEN_RegistrarOperacionKardexBioExcepcion_SP", xmlBiometriaExcepcionOperacion, idUsuario, dFechaSistema);
        }

        public DataTable ADAnularSolicitudAprobacion(int idSolAproba, int idUsuario, int idPerfil, DateTime dFechaSistema, int idAgencia, string cOpinionAprobador)
        {
            return new clsGENEjeSP().EjecSP("GEN_AnulacionSolicitudAprobacion_SP", idSolAproba, idUsuario, idPerfil, dFechaSistema, idAgencia, cOpinionAprobador);
        }

        public DataTable ADConfigurarAprobSoli(int idUsuario, int idSolicitud, int idPerfil)
        {
            return new clsGENEjeSP().EjecSP("ADM_ConfigAprobSolicitud_SP", idUsuario, idSolicitud, idPerfil);
        }

        public DataTable ADListarSolAprobaPendiente(int idUsuario, int idPerfil, DateTime dFecSis, int idOperacion, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("ADM_LisSolAprobaPen_SP", idUsuario, idPerfil, dFecSis, idOperacion, idAgencia);
        }

        public DataTable ADListarSolAproba(int idUsuario, int idPerfil, DateTime dFecSis, int idTipoOperacion)
        {
            return new clsGENEjeSP().EjecSP("ADM_ListarSolAproba_sp", idUsuario, idPerfil, dFecSis, idTipoOperacion);
        }
        //--================================================================================
        //--Obtener correos de aprobadores de extorno
        //--================================================================================
        public DataTable ADListarCorreoAprobaSol(int idSolAproba, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCorreoAproSol_SP", idSolAproba, idAgencia);
        }
        //--================================================================================
        //--Obtener celulares de aprobadores de extorno
        //--================================================================================
        public DataTable ADListarCelularAprobaSol(int idSolAproba, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCelularAproSol_SP", idSolAproba, idAgencia);
        }
        //--================================================================================
        //--Envío de correos a los aprobadores de extorno
        //--================================================================================
        public DataTable ADEnviarCorreoAprobador(string cPerfil,string cDestinatario,string cCuerpo,string cAsunto)
        {
            return new clsGENEjeSP().EjecSP("GEN_EnvioCorreoExtorno_SP", cPerfil,cDestinatario,cCuerpo,cAsunto);
        }
        //--================================================================================
        //--Switch de envio EMAIL
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioMail()
        {
            return new clsGENEjeSP().EjecSP("GEN_ParametrosenvioEMAIL_SP");
        }
        //--================================================================================
        //--Switch de envio SMS
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioSMS()
        {
            return new clsGENEjeSP().EjecSP("GEN_ParametrosenvioSMS_SP");
        }

        public DataTable ADObtenerGiroSolDesblContra(int idServicioGiro, int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("SER_ObtenerGiroSolDesbContra_SP", idServicioGiro, idSolAproba);
        }
    }
}
