using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADCarteraRecupera
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarCarteraRecupera()
        {            
            return objEjeSp.EjecSP("RCP_ListarCarteraRecupera_SP");
        }
        public DataTable ListarCarteraRecuperaid(int idSolicitudRecuperacion)
        {
            return objEjeSp.EjecSP("RCP_ListarCarteraRecuperaidSolicitudRecuperacion_SP", idSolicitudRecuperacion);
        }

        public DataTable InsertarCarteraRecupera(int idSolicitudRecuperacion, int idCuenta, int idUsuario, int idEstadoRecupera, bool lUbicable)
        {
            return objEjeSp.EjecSP("RCP_InsertarCarteraRecupera_SP", idSolicitudRecuperacion, idCuenta, idUsuario, idEstadoRecupera, lUbicable);
        }

        public DataTable ActualizarCarteraRecupera(int idSolicitudRecuperacion, int idCuenta, int idUsuario, int idEstadoRecupera, bool lUbicable)
        {
            return objEjeSp.EjecSP("RCP_ActualizarCarteraRecupera_SP", idSolicitudRecuperacion, idCuenta, idUsuario, idEstadoRecupera, lUbicable);
        }
        
        public DataTable ListarCarteraRecuperacionByUsu(int idUsuario, int idUbigeo, int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListarCartera_SP", idUsuario, idUbigeo, idAgencia);
        }

        public DataTable ListarCarteraCastigada(int idUbigeo, int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListarCarteraCastigada_SP", idUbigeo, idAgencia);
        }

        public DataTable reasignarCartera(string xml, int idUsuarioOrigen, int idUsuarioDestino, int idUsuarioReasigna, string cMotivo)
        {
            return objEjeSp.EjecSP("RCP_ReasignarCartera_SP", xml, idUsuarioOrigen, idUsuarioDestino, idUsuarioReasigna, cMotivo);
        }

        public DataTable asignarCarteraCastigada(string xml, int idUsuarioDestino, int idUsuarioReasigna, string cMotivo)
        {
            return objEjeSp.EjecSP("RCP_AsignarCarteraCastigada_SP", xml, idUsuarioDestino, idUsuarioReasigna, cMotivo);
        }
        
        public DataTable obtenerCreditosSinGlosa(string cPeriodo)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosTransSinGlosa_SP", cPeriodo);
        }

        public DataTable DevolverCreditosSinGloza(int idUsuario, string xmlCreditos, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("RCP_DevolverCreditosSinGLosa_SP", idUsuario, xmlCreditos, dFechaSistema);
        }

        public DataTable DevolverCreditoRecuperadorAsesor(int idSolAproba, int idCuenta, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("RPC_DevolverCreditoRecuperadorAsesor_SP", idSolAproba, idCuenta, dFechaSis);
        }

        public DataTable obtenerCreditosParaAsignar(string xmlCodigos)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosAAsignar_SP", xmlCodigos);
        }

        public DataTable obtenerUsuario(int idCliente)
        {
            return objEjeSp.EjecSP("RCP_ObtenerCaracteristicasUsuario_SP", idCliente);
        }

        public DataTable obtenerCreditosAsignados(int idCliente)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosAsignado_SP", idCliente);
        }

        public DataTable AsignarCarteraAGestor(string xmlCodigos, int idUsuario, int idUsuCliente, string cPeriodo, int idUsuReg, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("RCP_AsignarCreditosAGestor_SP", xmlCodigos, idUsuario, idUsuCliente, cPeriodo, idUsuReg, dFechaSistema);
        }

        public DataTable resumenAsigSinGestor()
        {
            return objEjeSp.EjecSP("RCP_ResumenCarteraAsigNoGestor_SP");
        }

        public DataTable AsignarCarteraSinGestor(string xmlCodigos, string cPeriodo, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_AsignarCreditosSinGestor_SP", xmlCodigos, cPeriodo, idUsuario, dFecha);
        }
    }
}
