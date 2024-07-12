using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using GEN.AccesoDatos;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsCNAdministracionEnvioSMS
    {
        private clsADAdministracionEnvioSMS objAdministracionEnvioSMS = new clsADAdministracionEnvioSMS();

        public List<clsRegistroTelefono> CNObtenerTelefonoCliente(int idCliente)
        {
            DataTable dtRegistroTelefonos = objAdministracionEnvioSMS.ADObtenerTelefonoCliente(idCliente);
            return (dtRegistroTelefonos.Rows.Count > 0) ? dtRegistroTelefonos.ToList<clsRegistroTelefono>() as List<clsRegistroTelefono> : new List<clsRegistroTelefono>() ; 
        }

        public List<clsNotificacionSMS> CNObtenerNotificacionActivas(int idCliente, int idRegistro, int idModulo, int idTipoPlantillaSMS)
        {
            DataTable dtNotificacionSMS = objAdministracionEnvioSMS.ADObtenerNotificacionActivas(idCliente, idRegistro, idModulo, idTipoPlantillaSMS);
            return (dtNotificacionSMS.Rows.Count > 0) ? dtNotificacionSMS.ToList<clsNotificacionSMS>() as List<clsNotificacionSMS> : new List<clsNotificacionSMS>(); ;
        }

        public DataTable CNRegistrarNotificacionIndividualSMS(string xmlNotificacionSMS, int idUsuario, DateTime dFechaSistema, bool lEnviado)
        {
            return objAdministracionEnvioSMS.ADRegistrarNotificacionIndividualSMS(xmlNotificacionSMS, idUsuario, dFechaSistema, lEnviado);
        }

        public DataTable CNActualizarDetallesNotificacionSMS(int idNotificacionSMS, string cIDCodigoMensaje, string cMensajeTexto)
        {
            return objAdministracionEnvioSMS.ADActualizarDetallesNotificacionSMS(idNotificacionSMS, cIDCodigoMensaje, cMensajeTexto);
        }

        public DataTable CNActualizarNotificacionSMS (int idCliente, string cCodigoConfirmacion, string cNumero, int idNotificacionSMS, bool lActualizarPrincipal, int idUsuario, DateTime dFechaSistema)
        {
            return objAdministracionEnvioSMS.ADActualizacionNotificacionSMS(idCliente, cCodigoConfirmacion, cNumero, idNotificacionSMS, lActualizarPrincipal, idUsuario, dFechaSistema);
        }

        public DataTable CNActualizacionNotificacionKardexSMS(int idRegistro, int idModulo, int idTipoPlantillaSMS, int idKardex, int idUsuario, DateTime dFechaSistema)
        {
            return objAdministracionEnvioSMS.ADActualizacionNotificacionKardexSMS(idRegistro, idModulo, idTipoPlantillaSMS, idKardex, idUsuario, dFechaSistema);
        }

        public clsPlantillaSMS CNObtenerDatosPlantillaSMS(int idAgencia, int idEstablecimiento, int idTipoPlantillaSMS, int idCliente, int idRegistroTelefono)
        {
            clsPlantillaSMS objPlantillaSMS = new clsPlantillaSMS();

            DataSet dsResultado = objAdministracionEnvioSMS.ADObtenerDatosPlantillaSMS(idAgencia, idEstablecimiento, idTipoPlantillaSMS, idCliente, idRegistroTelefono);

            if (dsResultado.Tables.Count < 2)
            {
                return objPlantillaSMS;
            }
            else
            {
                DataTable dtPlantillaSMS = dsResultado.Tables[0];
                DataTable dtDatosPlantillaSMS = dsResultado.Tables[1];

                if (dtDatosPlantillaSMS.Rows.Count == 0 || dtPlantillaSMS.Rows.Count == 0)
                {
                    return objPlantillaSMS;
                }
                else
                {
                    // validacion si recibio respuesta
                    objPlantillaSMS.cCodigoValidacion = Convert.ToString(dtDatosPlantillaSMS.Rows[0]["cCodigoValidacion"]);
                    objPlantillaSMS.idPlantillaSMS = Convert.ToInt32(dtPlantillaSMS.Rows[0]["idPlanillaSMS"]);
                    objPlantillaSMS.idTipoMensaje = Convert.ToInt32(dtDatosPlantillaSMS.Rows[0]["idTipoMensaje"]);
                    objPlantillaSMS.nExpiracion = Convert.ToInt32(dtDatosPlantillaSMS.Rows[0]["nExpiracionContenido"]);
                }
            }
            return objPlantillaSMS;
        }

        public clsPlantillaSMS CNObtenerDatosNotificacionPlantillaSMS(int idPlanillaSMS, int idTipoPlanillaSMS, int idNotificacionSMS, int idCliente, int idRegistroTelefono, int idRegistro)
        {
            clsPlantillaSMS objPlantillaSMS = new clsPlantillaSMS();

            DataSet dsResultado = objAdministracionEnvioSMS.ADObtenerDatosNotificacionPlantillaSMS(idPlanillaSMS, idTipoPlanillaSMS, idNotificacionSMS, idCliente, idRegistroTelefono, idRegistro);

            if (dsResultado.Tables.Count == 0)
            {
                return objPlantillaSMS;
            }


            DataTable dtPlantillaSMS = dsResultado.Tables[0];
            DataTable dtDatosPlantillaSMS = dsResultado.Tables[1];
            DataTable dtDatosMensaje = dsResultado.Tables[2];

            if (dtPlantillaSMS.Rows.Count == 0)
            {
                return objPlantillaSMS;
            }

            if(dtDatosPlantillaSMS.Rows.Count == 0)
            {
                DataRow drow = dtDatosPlantillaSMS.NewRow();
                dtDatosPlantillaSMS.Rows.Add(drow);
            }

            if (dtDatosMensaje.Rows.Count == 0)
            {
                DataRow drow = dtDatosMensaje.NewRow();
                dtDatosMensaje.Rows.Add(drow);
            }

            // validacion si recibio respuesta
            string cContenidoMensaje = Convert.ToString(dtPlantillaSMS.Rows[0]["cPlantillaSMS"]);

            foreach (DataColumn dcColumna in dtDatosMensaje.Columns)
            {
                cContenidoMensaje = cContenidoMensaje.Replace("[" + dcColumna.ColumnName + "]", Convert.ToString(dtDatosMensaje.Rows[0][dcColumna.ColumnName]));
            }

            foreach (DataColumn dcColumna in dtDatosPlantillaSMS.Columns)
            {
                cContenidoMensaje = cContenidoMensaje.Replace("[" + dcColumna.ColumnName + "]", Convert.ToString(dtDatosPlantillaSMS.Rows[0][dcColumna.ColumnName]));
            }

            objPlantillaSMS.cMensajeTexto = cContenidoMensaje;
            objPlantillaSMS.cCodigoValidacion = Convert.ToString(dtDatosPlantillaSMS.Rows[0]["cCodigoValidacion"]);

            return objPlantillaSMS;
        }

        public DataTable CNObtenerTipoPlantillaSMS(int idTipoPlantillaSMS)
        {
            return objAdministracionEnvioSMS.ADObtenerTipoPlantillaSMS(idTipoPlantillaSMS);
        }

        public DataTable CNRegistrarEjecucionNotificacionSMS(int idNotificacionSMS, int idUsuario, DateTime dFechaSistema)
        {
            return objAdministracionEnvioSMS.ADRegistrarEjecucionNotificacionSMS(idNotificacionSMS, idUsuario, dFechaSistema);
        }

        public DataTable CNObtenerMotivoExcepcionSMS()
        {
            return objAdministracionEnvioSMS.ADObtenerMotivoExcepcionSMS();
        }

        public List<clsClienteNotificacionSMS> CNObtenerIntervinientesNotificacionSMS(int idRegistro, int idModulo)
        {
            List<clsClienteNotificacionSMS> lstIntervinienteNotificacionSMS = new List<clsClienteNotificacionSMS>();
            List<clsRegistroTelefono> lstRegistroTelefonicoCompleto = new List<clsRegistroTelefono>();
            DataSet dsResultado = objAdministracionEnvioSMS.ADObtenerIntervinientesNotificacionSMS(idRegistro, idModulo);

            if(dsResultado.Tables.Count > 1)
            {
                lstRegistroTelefonicoCompleto = (dsResultado.Tables[1].Rows.Count > 0) ? dsResultado.Tables[1].ToList<clsRegistroTelefono>() as List<clsRegistroTelefono> : new List<clsRegistroTelefono>() ;
                lstIntervinienteNotificacionSMS = (dsResultado.Tables[0].Rows.Count > 0) ? dsResultado.Tables[0].AsEnumerable().Select(
                    item => new clsClienteNotificacionSMS()
                    {
                        idCliente = Convert.ToInt32(item["idCli"]),
                        cDocumentoID = Convert.ToString(item["cDocumentoID"]),
                        cNombreCompleto = Convert.ToString(item["cNombre"]),
                        idRegistro = idRegistro,
                        idModulo = idModulo,
                        lstRegistroTelefono = (lstRegistroTelefonicoCompleto.Any(iteml => iteml.idCli == Convert.ToInt32(item["idCli"]))) ? lstRegistroTelefonicoCompleto.Where(iteml => iteml.idCli == Convert.ToInt32(item["idCli"])).ToList<clsRegistroTelefono>() : new List<clsRegistroTelefono>()
                    }
                ).ToList<clsClienteNotificacionSMS>() : new List<clsClienteNotificacionSMS>() ;
            }
            return lstIntervinienteNotificacionSMS;
        }

        public DataTable CNObtenerTipoOperador()
        {
            return objAdministracionEnvioSMS.ADObtenerTipoOperador();
        }

        public DataTable CNObtenerRPTDatosNotificacionSMS(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objAdministracionEnvioSMS.ADObtenerRPTDatosNotificacionSMS(idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        } 
        public DataTable CNObtenerRPTSMSPaqueteSeguro(int idZona, int idAgencia, int idEstablecimiento, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objAdministracionEnvioSMS.ADObtenerRPTSMSPaqueteSeguro(idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta);
        }
    }
}