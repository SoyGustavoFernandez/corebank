using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
namespace CRE.AccesoDatos
{
    public class clsADScoring
    {
        IntConexion objEjeSp;
       
        public clsADScoring(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADScoring()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ObtenerDatosClienteScoring(string cNroDocumento, bool lServicioWeb)
        {
                return objEjeSp.EjecSP("RCP_ObtenerDatosClienteScoring_SP", cNroDocumento);
        }

        public DataTable ObtenerVariables(bool lServicioWeb)
        {
               return objEjeSp.EjecSP("RCP_ObtenerVariablesScoring_SP");
        }

        public DataTable VerificarUbigeoAgencia(int idUsuario, string cUbigeo, bool lServicioWeb)
        {
               return objEjeSp.EjecSP("CRE_VerificarUbigeoAgencia_SP", idUsuario, cUbigeo);
        }

        public DataTable ObtenerMaximoMontos(bool lBancarizado, int idDestino, decimal nMontoMaximoRCC, bool lServicioWeb)
        {
                return objEjeSp.EjecSP("CRE_ObtenerMaximoMontos_SP", lBancarizado, idDestino, nMontoMaximoRCC);
        }

        public DataTable ObtenerMaximoMontos(decimal nMonto, bool lServicioWeb)
        {
                return objEjeSp.EjecSP("CRE_ObtenerTasaScoring_SP", nMonto);
        }

        public DataTable RegistroLogScoring(string cNroDocumento, decimal nCalificacion, int idUsuario, int idEstado, bool lServicioWeb)
        {
                return objEjeSp.EjecSP("CRE_RegistraScoring_SP", cNroDocumento, nCalificacion, idUsuario, idEstado, lServicioWeb);
        }

        public DataTable ActualizarLogScoring(string cNroDocumento, decimal nCalificacion, int idUsuario, int idEstadoCivil, int nEdad, string cCodigoUbigeo, int nExperienciaNegocio, bool lFormalizado, int idDestino, decimal nMontoSolicitado, int nPlazo, decimal nExcedente, decimal nObligaciones, bool lServicioWeb)
        {
                return objEjeSp.EjecSP("CRE_ActualizaScoring_SP", cNroDocumento, nCalificacion, idUsuario, idEstadoCivil, nEdad, cCodigoUbigeo, nExperienciaNegocio, lFormalizado, idDestino, nMontoSolicitado, nPlazo, nExcedente, nObligaciones, lServicioWeb);
        }

        public DataTable VerificarAccesoMovil(int idusuario)
        {
                return objEjeSp.EjecSP("GEN_ValidarPermisoMovil_SP", idusuario);
        }

        public DataTable ADObtieneMensaje(int idGrupoCamp)
        {
            return objEjeSp.EjecSP("CRE_RecuperaMensajeCampania_Sp", idGrupoCamp);
        }


    }
}
