using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNCarteraRecupera
    {
        clsADCarteraRecupera carterarecupera = new clsADCarteraRecupera();

        public DataTable ListarCarteraRecupera()
        {
            return carterarecupera.ListarCarteraRecupera();
        }
        public DataTable ListarCarteraRecuperaid(int idSolicitudRecuperacion)
        {
            return carterarecupera.ListarCarteraRecuperaid(idSolicitudRecuperacion);
        }

        public DataTable InsertarCarteraRecupera(int idSolicitudRecuperacion, int idCuenta, int idUsuario, int idEstadoRecupera, bool lUbicable)
        {
            return carterarecupera.InsertarCarteraRecupera(idSolicitudRecuperacion, idCuenta, idUsuario, idEstadoRecupera, lUbicable);
        }

        public DataTable ActualizarCarteraRecupera(int idSolicitudRecuperacion, int idCuenta, int idUsuario, int idEstadoRecupera, bool lUbicable)
        {
            return carterarecupera.ActualizarCarteraRecupera(idSolicitudRecuperacion, idCuenta, idUsuario, idEstadoRecupera, lUbicable);
        }
        public DataTable ListarCarteraRecuperacionByUsu(int idUsuario, int idUbigeo, int idAgencia)
        {
            return carterarecupera.ListarCarteraRecuperacionByUsu(idUsuario, idUbigeo, idAgencia);
        }
        public DataTable ListarCarteraCastigada(int idUbigeo, int idAgencia)
        {
            return carterarecupera.ListarCarteraCastigada(idUbigeo, idAgencia);
        }

        public DataTable reasignarCartera(string xml, int idUsuarioOrigen, int idUsuarioDestino, int idUsuarioReasigna, string motivo)
        {
            return carterarecupera.reasignarCartera(xml, idUsuarioOrigen, idUsuarioDestino, idUsuarioReasigna, motivo);
        }

        public DataTable asignarCarteraCastigada(string xml, int idUsuarioDestino, int idUsuarioReasigna, string motivo)
        {
            return carterarecupera.asignarCarteraCastigada(xml, idUsuarioDestino, idUsuarioReasigna, motivo);
        }        

        public DataTable obtenerCreditosSinGlosa(string cPeriodo)
        {
            return carterarecupera.obtenerCreditosSinGlosa(cPeriodo);
        }

        public DataTable DevolverCreditosSinGloza(int idUsuario, string xmlCreditos, DateTime dFechaSistema)
        {
            return carterarecupera.DevolverCreditosSinGloza(idUsuario, xmlCreditos, dFechaSistema);            
        }

        public DataTable DevolverCreditoRecuperadorAsesor(int idSolAproba, int idCuenta, DateTime dFechaSis)
        {
            return carterarecupera.DevolverCreditoRecuperadorAsesor(idSolAproba, idCuenta, dFechaSis);            
        }

        public DataTable obtenerCreditosParaAsignar(string xmlCodigos)
        {
            return carterarecupera.obtenerCreditosParaAsignar(xmlCodigos);            
        }

        public DataTable obtenerUsuario(int idCliente)
        {
            return carterarecupera.obtenerUsuario(idCliente);            
        }

        public DataTable obtenerCreditosAsignados(int idCliente)
        {
            return carterarecupera.obtenerCreditosAsignados(idCliente);            
        }

        public DataTable AsignarCarteraAGestor(string xmlCodigos, int idUsuario, int idUsuCliente, string cPeriodo, int idUsuReg, DateTime dFechaSistema)
        {
            return carterarecupera.AsignarCarteraAGestor(xmlCodigos, idUsuario, idUsuCliente, cPeriodo, idUsuReg, dFechaSistema);            
            
        }

        public DataTable resumenAsigSinGestor()
        {
            return carterarecupera.resumenAsigSinGestor();            
        }

        public DataTable AsignarCarteraSinGestor(string xmlCodigos, string cPeriodo, int idUsuario, DateTime dFecha)
        {
            return carterarecupera.AsignarCarteraSinGestor(xmlCodigos, cPeriodo, idUsuario, dFecha);            
        }
    }
}
