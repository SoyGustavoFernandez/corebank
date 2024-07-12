using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNConsultaDatos
    {
        clsADConsultaDatos ConexAD;
        public clsCNConsultaDatos()
        {
            ConexAD = new clsADConsultaDatos();
        }

        public clsCNConsultaDatos(bool cConex)
        {
            ConexAD = new clsADConsultaDatos(cConex);
        }


        public DataTable CNVerDatos(string cDatos, int idUsuario, string cDniAutorizado)
        {
            return ConexAD.ADVerDatos(cDatos, idUsuario, cDniAutorizado);
        }
        public DataTable CNValidaInsDatos(string cDni)
        {
            return ConexAD.ADValidaInsDatos(cDni);
        }
        public DataTable CNConsultaDatos(string cDni)
        {
            return ConexAD.ADConsultaDatos(cDni);
        }
        public DataTable CNConsultaDatosReporte(string cDni)
        {
            return ConexAD.ADConsultaDatosReporte(cDni);
        }
        public DataTable CNConsultaDatosDniAut(int nModulo)
        {
            return ConexAD.CNConsultaDatosDniAut(nModulo);
        }
        public DataTable CNRegistraLog(string cDni, string cError, string cMensajeCola, int idUsuario, string cDocAutorizado)
        {
            return ConexAD.ADRegistraLog(cDni, cError, cMensajeCola, idUsuario, cDocAutorizado);
        }
        public DataTable CNBuscaLog(string cDni)
        {
            return ConexAD.ADBuscaLog(cDni);
        }
        public DataTable CNRetornaRestri(string cRes)
        {
            return ConexAD.ADRetornaRestri(cRes);
        }
        public DataTable CNRegistraTrama(string cDni, string cDniTrama, string cTrama, string cFotoTrama, string cFirmaTrama, int idEstado)
        {
            return ConexAD.ADRegistraTrama(cDni, cDniTrama, cTrama, cFotoTrama, cFirmaTrama, idEstado);
        }
        public DataTable CNBuscarDniError(string cDni)
        {
            return ConexAD.ADBuscarDniError(cDni);
        }
        public DataTable CNBuscarDniTrama(string cDni)
        {
            return ConexAD.ADBuscarDniTrama(cDni);
        }
        public DataTable CNBuscarDniEnvioCola(string cDni)
        {
            return ConexAD.ADBuscarDniEnvioCola(cDni);
        }
        public DataTable CNBuscarDniListaNegra(string cDni)
        {
            return ConexAD.ADBuscarDniListaNegra(cDni);
        }
        /* MASIVO**/
        public DataTable CNRegistrarLote(string cRutaArchivo)
        {
            return ConexAD.ADRegistrarLote(cRutaArchivo);
        }
        public DataTable CNRegistrarLogMasivo(string cDni, int idUsuConsul, int idLote, string cErrof)
        {
            return ConexAD.ADRegistrarLogMasivo(cDni, idUsuConsul, idLote, cErrof);
        }
        public DataTable CNReporteLogMasivo(int idTipoConsulta, int idLote, DateTime dFechaConsulta)
        {
            return ConexAD.ADReporteLogMasivo(idTipoConsulta, idLote, dFechaConsulta);
        }
        /** consulta directa**/
        public DataTable CNValidaInsDatosDirecta(string cDni)
        {
            return ConexAD.ADValidaInsDatosDirecta(cDni);
        }
        public DataTable CNBuscarDniEnvioColaDirect(string cDni)
        {
            return ConexAD.ADBuscarDniEnvioColaDirect(cDni);
        }

    }
}
