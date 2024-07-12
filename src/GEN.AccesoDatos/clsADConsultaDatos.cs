using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using EntityLayer;
using System.Threading.Tasks;




namespace GEN.AccesoDatos
{
    public class clsADConsultaDatos
    {
        IntConexion objEjeSp;

        public clsADConsultaDatos(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADConsultaDatos()
        {
            objEjeSp = new clsGENEjeSP();
        }



        public DataTable ADVerDatos(string cDatos, int idUsuario, string cDniAutorizado)
        {
            return objEjeSp.EjecSP("GEN_InsertarDatosConsulta_SP", cDatos, idUsuario, cDniAutorizado);
        }
        public DataTable ADValidaInsDatos(string cDni)
        {
            return objEjeSp.EjecSP("GEN_ValidaInsertarDatos_SP", cDni);
        }
        public DataTable ADConsultaDatos(string cDni)
        {
            return objEjeSp.EjecSP("GEN_ConsultaDatosRen_SP", cDni);
        }
        public DataTable ADConsultaDatosReporte(string cDni)
        {
            return objEjeSp.EjecSP("CLI_RecuperaDatosDNI_SP", cDni);
        }
        public DataTable CNConsultaDatosDniAut(int nMod)
        {
            return objEjeSp.EjecSP("CLI_RecuperaDatosDocAutorizado_SP", nMod);
        }
        public DataTable ADRegistraLog(string cDni, string cError, string cMensajeCola, int idUsuario, string cDocAutorizado)
        {
            return objEjeSp.EjecSP("CLI_InsertarLogReniec_SP", cDni, cError, cMensajeCola, idUsuario, cDocAutorizado);
        }
        public DataTable ADBuscaLog(string cDni)
        {
            return objEjeSp.EjecSP("CLI_BuscarLogReniec_SP", cDni);
        }
        public DataTable ADRetornaRestri(string cRes)
        {
            return objEjeSp.EjecSP("CRE_RetornaDetalleRestriccion_SP", cRes);
        }
        public DataTable ADRegistraTrama(string cDni, string cDniTrama, string cTrama, string cFotoTrama, string cFirmaTrama, int idEstado)
        {
            return objEjeSp.EjecSP("CLI_ReniecGuardarTrama_SP", cDni, cDniTrama, cTrama, cFotoTrama, cFirmaTrama, idEstado);
        }
        public DataTable ADBuscarDniError(string cDni)
        {
            return objEjeSp.EjecSP("CLI_ReniecBuscarDniError_SP", cDni);
        }
        public DataTable ADBuscarDniTrama(string cDni)
        {
            return objEjeSp.EjecSP("CLI_ReniecBuscarDniTrama_SP", cDni);
        }
        public DataTable ADBuscarDniEnvioCola(string cDni)
        {
            return objEjeSp.EjecSP("CLI_ReniecBuscarDniEnvioCola_SP", cDni);
        }
        public DataTable ADBuscarDniListaNegra(string cDni)
        {
            return objEjeSp.EjecSP("CLI_ReniecBuscarDniListaNegra_SP", cDni);
        }
        /**MASIVO**/
        public DataTable ADRegistrarLote(string cRutaArchivo)
        {
            return objEjeSp.EjecSP("CLI_RegistraLoteConsultaRen_SP", cRutaArchivo);
        }
        public DataTable ADRegistrarLogMasivo(string cDni, int idUsuConsul, int idLote, string cErrof)
        {
            return objEjeSp.EjecSP("CLI_RegistraRenLogConsultaMasiva_SP", cDni, idUsuConsul, idLote, cErrof);
        }
        public DataTable ADReporteLogMasivo(int idTipoConsulta, int idLote, DateTime dFechaConsulta)
        {
            return objEjeSp.EjecSP("CLI_ReporteConsultaMasiva_SP", idTipoConsulta, idLote, dFechaConsulta);
        }
        /** Consulta Directa **/
        public DataTable ADValidaInsDatosDirecta(string cDni)
        {
            return objEjeSp.EjecSP("GEN_ValidaInsertarDatosConsulDirect_SP", cDni);
        }
        public DataTable ADBuscarDniEnvioColaDirect(string cDni)
        {
            return objEjeSp.EjecSP("CLI_ReniecBuscarDniEnvioColaDirect_SP", cDni);
        }
    }
}
