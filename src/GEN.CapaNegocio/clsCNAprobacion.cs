using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsCNAprobacion
    {
        public DataTable LisTipoOpeAproba(int idTipoOperacion)
        {
            return new clsADAprobacion().LisTipoOpeAproba(idTipoOperacion);
        }

        public DataTable CNExtractTipoVariable(string cVariable)
        {
            return new clsADAprobacion().ADExtractTipoVariable(cVariable);
        }

        public DataTable InsTipoOpeAproba(int idTipoOperacion, int idEstadoOperac, int idMoneda, bool lporAgencia, bool lporProducto, int idNivelProd, bool lVigente)
        {
            return new clsADAprobacion().InsTipoOpeAproba(idTipoOperacion, idEstadoOperac, idMoneda, lporAgencia, lporProducto, idNivelProd, lVigente);
        }

        public DataTable ActTipoOpeAproba(int idTipOpeAproba, bool lporAgencia, bool lporProducto, int idNivelProd, bool lVigente)
        {
            return new clsADAprobacion().ActTipoOpeAproba(idTipOpeAproba, lporAgencia, lporProducto, idNivelProd, lVigente);
        }

        public DataTable LisRangoAprobaOpe(int idTipOpeAproba)
        {
            return new clsADAprobacion().LisRangoAprobaOpe(idTipOpeAproba);
        }

        public DataTable InsRangoAprobaOpe(int idTipOpeAproba, int idAgencia, int idProducto, decimal nRangoMinimo, decimal nRangoMaximo, bool lVigente)
        {
            return new clsADAprobacion().InsRangoAprobaOpe(idTipOpeAproba, idAgencia, idProducto, nRangoMinimo, nRangoMaximo, lVigente);
        }

        public DataTable ActRangoAprobaOpe(int idRangoOperacion, decimal nRangoMinimo, decimal nRangoMaximo, bool lVigente)
        {
            return new clsADAprobacion().ActRangoAprobaOpe(idRangoOperacion, nRangoMinimo, nRangoMaximo, lVigente);
        }

        public DataTable LisNivelAprRangoOpe(int idRangoOperacion)
        {
            return new clsADAprobacion().LisNivelAprRangoOpe(idRangoOperacion);
        }

        public DataTable InsNivelAprRangoOpe(int idRangoOperacion, string cNivelAproba, int nNumAprobadores, int nOrdenAprobacion, bool lVigente, bool lSoloComent)
        {
            return new clsADAprobacion().InsNivelAprRangoOpe(idRangoOperacion, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
        }

        public DataTable ActNivelAprRangoOpe(int idNivelAprRanOpe, string cNivelAproba, int nNumAprobadores, int nOrdenAprobacion, bool lVigente, bool lSoloComent)
        {
            return new clsADAprobacion().ActNivelAprRangoOpe(idNivelAprRanOpe, cNivelAproba, nNumAprobadores, nOrdenAprobacion, lVigente, lSoloComent);
        }

        public DataTable LisPerfilNivelAproba(int idNivelAprRanOpe)
        {
            return new clsADAprobacion().LisPerfilNivelAproba(idNivelAprRanOpe);
        }

        public DataTable InsPerfilNivelAproba(int idNivelAprRanOpe, int idPerfil, int idAmbito, bool lVigente)
        {
            return new clsADAprobacion().InsPerfilNivelAproba(idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
        }

        public DataTable ActPerfilNivelAproba(int idNivelAprRanOpe, int idPerfil, int idAmbito, bool lVigente)
        {
            return new clsADAprobacion().ActPerfilNivelAproba(idNivelAprRanOpe, idPerfil, idAmbito, lVigente);
        }

        //--================================================================================
        //--Guardar Solicitudes de Aprobacion
        //--================================================================================
        public DataTable GuardarSolicitudAprobac(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, int IExcepcion, int idEstablecimiento, int idPerfilUser)
        {
            return new clsADAprobacion().GuardarSolicitudAprobac(idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion, idEstablecimiento, idPerfilUser);
        }

        public DataTable ActualizaPerfilEstablecimientoSolicitudAprobac(int idsolAprobacion, int idEstablecimiento, int idPerfilUser)
        {
            return new clsADAprobacion().ActualizaPerfilEstablecimientoSolicitudAprobac(idsolAprobacion, idEstablecimiento, idPerfilUser);
        }


        //--================================================================================
        //--Guardar Solicitudes Recibo Utilizado
        //--================================================================================
        public DataTable GuardarSolicitudReciboUtilizado(int idRecibo, int idKardex, int idUsuRegist, int idAgencia, int idSolAproba, int idCliente, DateTime dFecAprSol)
        {
            return new clsADAprobacion().GuardarSolicitudReciboUtilizado(idRecibo, idKardex, idUsuRegist, idAgencia, idSolAproba, idCliente, dFecAprSol);
        }

        //--================================================================================
        //--Guardar Solicitudes de Aprobacion Automatica
        //--================================================================================
        public DataTable GuardarSolicitudAprobacAutomatica(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, int IExcepcion, int idEstablecimiento, int idPerfilUser)
        {
            return new clsADAprobacion().GuardarSolicitudAprobacAutomatica(idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion, idEstablecimiento, idPerfilUser);
        }

        //--================================================================================
        //--RECUPERA CONCEPTO DE PAGO
        //--================================================================================
        public DataTable RecuperaConceptoPago()
        {
            return new clsADAprobacion().RecuperaConceptoPago();
        }

        //--================================================================================
        //--Listar Aprobaciones de Extorno por Usuario y Agencia
        //--================================================================================
        public DataTable ListarAprobacionExtorno(DateTime dFecOpe, int idAge, int idusu, int idModulo, string idTpOpe)
        {
            return new clsADAprobacion().ListarSolAprobadasExt(dFecOpe, idAge, idusu, idModulo, idTpOpe);
        }

        //--================================================================================
        //--Listar Operaciones de Extorno por kardex 
        //--================================================================================
        public DataTable ListarSolAprobadasExtPorKardex(DateTime dFecOpe, int idAge, int idUsu, int idModulo, string idTpOpe, int idKardex)
        {

            return new clsADAprobacion().ListarSolAprobadasExtPorKardex(dFecOpe, idAge, idUsu, idModulo, idTpOpe, idKardex);
        }

        //--================================================================================
        //--Retorna Datos de la Operación para el Extorno
        //--================================================================================
        public DataTable RetornaDatosOperacionExt(int idKardex, DateTime dFecOpe, int idAge, int idusu, int idModulo, string idTpOpe)
        {
            return new clsADAprobacion().RetDatosOpeExt(idKardex, dFecOpe, idAge, idusu, idModulo, idTpOpe);
        }

        //--================================================================================
        //--Listado de Solicitudes Pendientes de Aprobación
        //--================================================================================
        public DataTable CNLisSoliciAprobaPendiente(int idUsuario, int idPerfil, DateTime dFecSis, int idAgencia)
        {
            return new clsADAprobacion().ADLisSoliciAprobaPendiente(idUsuario, idPerfil, dFecSis, idAgencia);
        }
        //--================================================================================
        //--Listado de Solicitudes Aprobadas
        //--================================================================================
        public DataTable CNLisSoliciAproba(int idUsuario, int idPerfil, DateTime dFecSis)
        {
            return new clsADAprobacion().ADLisSoliciAproba(idUsuario, idPerfil, dFecSis);
        }
        //--================================================================================
        //--Registrar Aprobación/Rechazo Solicitudes
        //--================================================================================
        public DataTable CNObtenerNivelAprobaTasa(int idSolicitud)
        {
            return new clsADAprobacion().ADObtenerNivelAprobaTasa(idSolicitud);
        }
        public DataTable CNObtenerRangoAprobaSolicitud(int idSolAproba)
        {
            return new clsADAprobacion().ADObtenerRangoAprobaSolicitud(idSolAproba);
        }
        public DataTable CNRegAprobaSolicitud(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado, string cOpinion, DateTime dFecSis, int idPerfil, string xmlPropSolCred)
        {
            return new clsADAprobacion().ADRegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dFecSis, idPerfil, xmlPropSolCred);
        }
        public DataTable CNActualizaTasaNegociada(int idTasaNegociada, decimal nTasaNegociada)
        {
            return new clsADAprobacion().ADActualizaTasaNegociada(idTasaNegociada, nTasaNegociada);
        }
        //--================================================================================
        //--Validar Permisos para Aprobación
        //--================================================================================
        public DataTable CNValidarPermisosAprobacion(int idAgencia, int idTipoOperacion, int idEstadoOperac, int idMoneda, int idProducto, Decimal nValor, int idUsuarioAproba, int idPerfilAproba)
        {
            return new clsADAprobacion().ADValidarPermisosAprobacion(idAgencia, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValor, idUsuarioAproba, idPerfilAproba);
        }

        //--================================================================================
        //--Cambia de estado a las solicitudes de extorno de pre sol a otro estado
        //--================================================================================
        public DataTable CNUpdEstadoSolicitud(int idEstadoSol, int idDocument, int idTipOpe, int idMoneda, int idAgencia, int idCli, int idProducto, int idSolAproba)
        {
            return new clsADAprobacion().ADUpdEstadoSolicitud(idEstadoSol, idDocument, idTipOpe, idMoneda, idAgencia, idCli, idProducto, idSolAproba);
        }

        //--================================================================================
        //--Listar Aprobaciones de Extorno por Usuario y Agencia
        //--================================================================================
        public DataTable LListarSolicitudesAprobadas(int idTipOpe, int idUsario, int idAgencia)
        {
            return new clsADAprobacion().ListarSolicitudesAprobadas(idTipOpe, idUsario, idAgencia);
        }

        //--================================================================================
        //--Listar las observaciones por nivel de aprobacion
        //--================================================================================
        public DataTable ListarObsSoliciAproba(int idSolAproba, int idNivelAprRanOpe)
        {
            return new clsADAprobacion().ListarObsSoliciAproba(idSolAproba, idNivelAprRanOpe);
        }

        //--================================================================================
        //--Registrar observaciones de solicitud de aprobación
        //--================================================================================
        public clsDBResp RegObsSoliciAproba(string xmlObservaciones, DateTime dFecha)
        {
            return new clsADAprobacion().RegObsSoliciAproba(xmlObservaciones, dFecha);
        }

        public DataTable ListarSolicitudesExtorno(string idUsuario, string idKardex)
        {
            return new clsADAprobacion().ListarSolicitudesExtorno(idUsuario, idKardex);
        }

        public DataTable ListarSolicitudesObservadas(int idUsuario, int idRegistro = 0)
        {
            return new clsADAprobacion().ListarSolicitudesObservadas(idUsuario, idRegistro);
        }

        public DataTable ListarObservacionesPorSolicitud(int idSolAproba)
        {
            return new clsADAprobacion().ListarObservacionesPorSolicitud(idSolAproba);
        }

        public DataTable ActualizarMontoSolicitud(int idSolAproba)
        {
            return new clsADAprobacion().ActualizarMontoSolicitud(idSolAproba);
        }

        public clsDBResp GenerarNivelesAprobCreditos(int idAgencia, int idCli, int idTipOpe, int idProducto, decimal nValAproba,
                                                        int idDocument, int nOrdenAproba, string cSustento, DateTime dFecha, int idUsuario)
        {
            return new clsADAprobacion().GenerarNivelesAprobCreditos(idAgencia, idCli, idTipOpe, idProducto, nValAproba,
                                                                    idDocument, nOrdenAproba, cSustento, dFecha, idUsuario);
        }

        public DataTable ObtenerSoliciAprobaPendiente(int idTipoOperacion, int idDocument)
        {
            return new clsADAprobacion().ObtenerSoliciAprobaPendiente(idTipoOperacion, idDocument);
        }

        public DataTable ListarSolicitudesAprobacion(int idTipoOperacion, int idEstadoOperac, int idCliente, int idMoneda, int idProducto,
                                                    int idDocument, int idUsuRegist)
        {
            return new clsADAprobacion().ListarSolicitudesAprobacion(idTipoOperacion, idEstadoOperac, idCliente, idMoneda, idProducto,
                                                                    idDocument, idUsuRegist);
        }
        public DataTable ConsultaAccesoTipoDestinoCmp(int idDestino)
        {
            return new clsADAprobacion().ConsultaAccesoTipoDestinoCmp(idDestino);
        }
        public DataTable ActualizaAccesoDestinoCmp(string Xml, int idDestino)
        {
            return new clsADAprobacion().ActualizaAccesoDestinoCmp(Xml, idDestino);
        }
        public DataTable RegistrarSolicitudExcepBiometria(int idBiometriaExcep, string cBiometriaExcep, string cDocumentoID, int idEstadoSolicitud, int idMotivoBiometriaExcep
                , string cNombreArchivo
                , string cExtencion
                , byte[] bArchivo
                , int idTipoArchivo 
                , string xmlUsuarioVerificador
                , bool lDerivacionDirecta
                , int idUsuReg
                , DateTime dFechaReg, bool lVigente, int idAgencia, int idCli, int idTipoOperacion, int idMoneda, decimal nMontoOperacion, int idProducto)
        {
            return new clsADAprobacion().RegistrarSolicitudExcepBiometria( idBiometriaExcep, cBiometriaExcep, cDocumentoID, idEstadoSolicitud
                , idMotivoBiometriaExcep 
	            , cNombreArchivo 
	            , cExtencion 
	            , bArchivo 
                , idTipoArchivo
                , xmlUsuarioVerificador
                , lDerivacionDirecta
                , idUsuReg
                , dFechaReg, lVigente, idAgencia, idCli, idTipoOperacion, idMoneda,  nMontoOperacion,  idProducto);
        }

        public DataTable ConsultarSolicitudExcepBiometria(string cDocumentoID, int idUsuReg, DateTime dFechaReg, int idAgencia, int idCli, DateTime dFechaSis, int idTipoOperacion)
        {
            return new clsADAprobacion().ConsultarSolicitudExcepBiometria(cDocumentoID, idUsuReg , dFechaReg , idAgencia , idCli, dFechaSis, idTipoOperacion );
        }

        public DataTable EjecutarSolicitudExcepBiometria(int idSolAproba , int  idBiometriaExcep, int idUsuario , DateTime dFecha )
        {
            return new clsADAprobacion().EjecutarSolicitudExcepBiometria( idSolAproba ,   idBiometriaExcep,  idUsuario ,  dFecha );
        }

        public DataTable CNListarMotivoExcepBiometrica()
        {
            return new clsADAprobacion().ADListarMotivoExcepBiometrica();
        }

        public DataTable CNObtenerExcepcionBiometrica(int idBiometriaExcep)
        {
            return new clsADAprobacion().ADObtenerExcepcionBiometrica(idBiometriaExcep);
        }


        public DataTable CNRegistrarExcepcionNotificacionSMS(   string cExcepcionNotificacionSMS    , int idCliente         , int idNotificacionSMS                 , int idRegistroTelefonico  ,
                                                                string cNumeroTelefonico            , int idEstadoSolicitud , int idMotivoExcepcionNotifiacionSMS   , int idUsuario             ,
                                                                DateTime dFechaSistema              , int idAgencia         , int idTipoOperacion                   , int idMoneda              ,
                                                                decimal nMontoOperacion             , int idProducto)
        {
            return new clsADAprobacion().ADRegistrarExcepcionNotificacionSMS(   cExcepcionNotificacionSMS   , idCliente         , idNotificacionSMS                 , idRegistroTelefonico  ,
                                                                                cNumeroTelefonico           , idEstadoSolicitud , idMotivoExcepcionNotifiacionSMS   , idUsuario             ,
                                                                                dFechaSistema               , idAgencia         , idTipoOperacion                   , idMoneda              ,
                                                                                nMontoOperacion             , idProducto);
        }

        public DataTable CNConsultarSolicitudExcepNotificacionSMS(int idCliente, int idNotificacionSMS, int idTipoOperacion)
        {
            return new clsADAprobacion().ADConsultarSolicitudExcepNotificacionSMS(idCliente, idNotificacionSMS, idTipoOperacion);
        }

        public DataTable CNEjecutarSolicitudExcepNotificacionSMS(int idSolAproba, int idExcepcionNotificacionSMS, int idNotificacionSMS, int idEstadoSolExcepcion, int idUsuario, DateTime dFechaSistema)
        {
            return new clsADAprobacion().ADEjecutarSolicitudExcepNotificacionSMS(idSolAproba, idExcepcionNotificacionSMS, idNotificacionSMS, idEstadoSolExcepcion, idUsuario, dFechaSistema);
        }

        public List<clsUsuAprobBiometrico> CNObtenerUsuarioBiometrico(int idCriterio, string cValorBusqueda, int idAgencia, int idEstablecimiento, int idTipoOperacion)
        {
            DataTable dtResultado = new clsADAprobacion().ADObtenerUsuarioBiometrico(idCriterio, cValorBusqueda, idAgencia, idEstablecimiento, idTipoOperacion);
            return (dtResultado.Rows.Count > 0) ? dtResultado.ToList<clsUsuAprobBiometrico>() as List<clsUsuAprobBiometrico>  : new List<clsUsuAprobBiometrico>();
        }

        public clsUsuAprobBiometrico CNObtenerUsuarioAutBiometrico(int idCliente)
        {
            DataTable dtResultado = new clsADAprobacion().ADObtenerUsuarioAutBiometrico(idCliente);
            return (dtResultado.Rows.Count > 0) ? dtResultado.ToList<clsUsuAprobBiometrico>()[0] : new clsUsuAprobBiometrico();
        }

        public clsConfigBiometricoAutorizacion CNObtenerConfigBioAutorizacion(int idAgencia, int idEstablecimiento, int idTipoOperacion, int idMoneda)
        {
            DataTable dtResultado = new clsADAprobacion().ADObtenerConfigBioAutorizacion(idAgencia, idEstablecimiento, idTipoOperacion, idMoneda);
            return (dtResultado.Rows.Count > 0) ? dtResultado.ToList<clsConfigBiometricoAutorizacion>()[0] : new clsConfigBiometricoAutorizacion() ;

        }

        public DataTable CNRegistrarOperacionKardexBioExcepcion(string xmlBiometriaExcepcionOperacion, int idUsuario, DateTime dFechaSistema)
        {
            return new clsADAprobacion().ADRegistrarOperacionKardexBioExcepcion(xmlBiometriaExcepcionOperacion, idUsuario, dFechaSistema);
        }

        public DataTable CNAnularSolicitudAprobacion(int idSolAproba, int idUsuario, int idPerfil, DateTime dFechaSistema, int idAgencia, string cOpinionAprobador)
        {
            return new clsADAprobacion().ADAnularSolicitudAprobacion(idSolAproba, idUsuario, idPerfil, dFechaSistema, idAgencia, cOpinionAprobador);
        }

        public DataTable CNConfigurarAprobSoli(int idUsuario, int idSolicitud, int idPerfil)
        {
            return new clsADAprobacion().ADConfigurarAprobSoli(idUsuario, idSolicitud, idPerfil);
        }
        public DataTable CNListarSolAprobaPendiente(int idUsuario, int idPerfil, DateTime dFecSis, int idOperacion, int idAgencia)
        {
            return new clsADAprobacion().ADListarSolAprobaPendiente(idUsuario, idPerfil, dFecSis, idOperacion, idAgencia);
        }
        public DataTable CNListarSolAproba(int idUsuario, int idPerfil, DateTime dFecSis, int idTipoOperacion)
        {
            return new clsADAprobacion().ADListarSolAproba(idUsuario, idPerfil, dFecSis, idTipoOperacion);
        }
        //--================================================================================
        //--Obtener correos de aprobadores de extorno
        //--================================================================================
        public DataTable CNListarCorreoAprobaSol(int idSolAproba, int idAgencia)
        {
            return new clsADAprobacion().ADListarCorreoAprobaSol(idSolAproba, idAgencia);
        }
        //--================================================================================
        //--Obtener celulares de aprobadores de extorno
        //--================================================================================
        public DataTable CNListarCelularAprobaSol(int idSolAproba, int idAgencia)
        {
            return new clsADAprobacion().ADListarCelularAprobaSol(idSolAproba, idAgencia);
        }
        //--================================================================================
        //--Envío de correos a los aprobadores de extorno
        //--================================================================================
        public DataTable CNEnviarCorreoAprobador(string cPerfil, string cDestinatario, string cCuerpo, string cAsunto)
        {
            return new clsADAprobacion().ADEnviarCorreoAprobador(cPerfil, cDestinatario, cCuerpo, cAsunto);
        }
        //--================================================================================
        //--Switch de envio EMAIL
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioMail()
        {
            return new clsADAprobacion().CNVerificarParametrosEnvioMail();
        }
        //--================================================================================
        //--Switch de envio SMS
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioSMS()
        {
            return new clsADAprobacion().CNVerificarParametrosEnvioSMS();
        }
        //--================================================================================
        //--Archivos de Sustento de Debloqueo de contraseña en Giros
        //--================================================================================
        public DataTable CNObtenerGiroSolDesblContra(int idServicioGiro, int idSolAproba)
        {
            return new clsADAprobacion().ADObtenerGiroSolDesblContra(idServicioGiro, idSolAproba);
        }
    }
}