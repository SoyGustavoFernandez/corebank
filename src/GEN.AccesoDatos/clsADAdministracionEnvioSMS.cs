using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADAdministracionEnvioSMS
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADObtenerTelefonoCliente(int idCliente)
        {
            return objEjeSp.EjecSP("GEN_ObtenerTelefonoCliente_SP", idCliente);
        }

        public DataTable ADRegistrarNotificacionIndividualSMS(string xmlNotificacionSMS, int idUsuario, DateTime dFechaSistema, bool lEnviado)
        {
            return objEjeSp.EjecSP("GEN_GuardarNotificacionIndividualSMS_SP", xmlNotificacionSMS, idUsuario, dFechaSistema, lEnviado);
        }
        public DataTable ADActualizarDetallesNotificacionSMS(int idNotificacionSMS, string cIDCodigoMensaje, string cMensajeTexto)
        {
            return objEjeSp.EjecSP("GEN_ActualizarDetalleNotificacionSMS_SP", idNotificacionSMS, cIDCodigoMensaje, cMensajeTexto);
        }
        public DataTable ADActualizacionNotificacionSMS(int idCliente, string cCodigoConfirmacion, string cNumero, int idNotificacionSMS, bool lActualizarPrincipal, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("GEN_ActualizarNotificacionSMS_SP", idCliente, cCodigoConfirmacion, cNumero, idNotificacionSMS, lActualizarPrincipal, idUsuario, dFechaSistema);
        }
        public DataTable ADActualizacionNotificacionKardexSMS(int idRegistro, int idModulo , int idTipoPlantillaSMS, int idKardex, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("GEN_ActualizarNotificacionKardexSMS_SP", idRegistro, idModulo, idTipoPlantillaSMS, idKardex, idUsuario, dFechaSistema);
        }

        public DataTable ADObtenerNotificacionActivas(int idCliente, int idRegistro, int idModulo, int idTipoPlantillaSMS)
        {
            return objEjeSp.EjecSP("GEN_ObtenerNotificacionActiva_SP", idCliente, idRegistro, idModulo, idTipoPlantillaSMS);
        }

        public DataSet ADObtenerDatosPlantillaSMS(int idAgencia, int idEstablecimiento, int idTipoPlantillaSMS, int  idCliente, int idRegistroTelefono)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerDatosPlantillaSMS_SP", idAgencia, idEstablecimiento, idTipoPlantillaSMS, idCliente, idRegistroTelefono);
        }
        public DataSet ADObtenerDatosNotificacionPlantillaSMS(int idPlantillaSMS, int idTipoPlantillaSMS, int idNotificacionSMS, int idCliente, int idRegistroTelefono, int idRegistro)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerDatosNotificacionPlantillaSMS_SP", idPlantillaSMS, idTipoPlantillaSMS, idNotificacionSMS, idCliente, idRegistroTelefono, idRegistro);
        }

        public DataTable ADObtenerTipoPlantillaSMS(int idTipoPlantillaSMS)
        {
            return objEjeSp.EjecSP("GEN_ObtenerDatosTipoPlantillaSMS_SP", idTipoPlantillaSMS);
        }
        public DataTable ADRegistrarEjecucionNotificacionSMS(int idNotificacionSMS, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("GEN_RegistrarEjecucionNotificacionSMS_SP", idNotificacionSMS, idUsuario, dFechaSistema);
        }

        public DataTable ADObtenerMotivoExcepcionSMS()
        {
            return objEjeSp.EjecSP("GEN_ObtenerMotivoExcepcionSMS_SP");
        }

        public DataSet ADObtenerIntervinientesNotificacionSMS(int idRegistro, int idModulo)
        {
            return objEjeSp.DSEjecSP("GEN_ObtenerIntevinientesNotificacionSMS_SP", idRegistro, idModulo);
        }

        public DataTable ADObtenerTipoOperador()
        {
            return objEjeSp.EjecSP("GEN_ObtenerTipoOperador_SP");
        }

        public DataTable ADObtenerRPTDatosNotificacionSMS(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("GEN_ObtenerRPTDatosNotificacionSMS_SP", idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        }
        public DataTable ADObtenerRPTSMSPaqueteSeguro(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("GEN_ObtenerRPTSMSPaqueteSeguro_SP", idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        }
    }
}
