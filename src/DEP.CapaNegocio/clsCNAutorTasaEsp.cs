using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEP.AccesoDatos;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data;


namespace DEP.CapaNegocio
{
    public class clsCNAutorTasaEsp
    {
        clsADAutorTasaEsp objADApeCta = new clsADAutorTasaEsp();

        public DataTable DatosCuenta(int NroCuenta)
        {
            return objADApeCta.DatosCuenta(NroCuenta);
        }
        public DataTable DatosSolicitud(int NroCuenta)
        {
            return objADApeCta.DatosSolicitud(NroCuenta);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                        int idUsuario,bool lExcepcion = false)
        {
            return objADApeCta.EnviarSolicitud(idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, lExcepcion);
        }
        public DataTable AplicarTasaEsp(decimal nTasaNueva, int NroCuenta, int idSolicitud)
        {
            return objADApeCta.AplicarTasaEsp(nTasaNueva, NroCuenta, idSolicitud);
        }
        public DataTable ListTasaSoliciAprob()
        {
            return objADApeCta.ListTasaSoliciAprob();
        }
        public DataTable AnularSol(int idsol)
        {
            return objADApeCta.AnularSol(idsol);
        }

        public DataTable SolicitudTasaEspecial(int idCuenta)
        {
            return objADApeCta.SolicitudTasaEspecial(idCuenta);
        }

        public DataTable RegistraSolCambioInterv(int idCuenta, int idMotivo, string cMotCambio, int nNroFirmas, string cDocRef, DateTime dFechaDoc,
                                                string cCorreo, string cNroTelf, int idSolicitud, int idUsuario, int idAgencia, string xmlRetirados, string xmlNuevos)
        {
            return objADApeCta.RegistraSolCambioInterv(idCuenta, idMotivo, cMotCambio, nNroFirmas, cDocRef, dFechaDoc,
                                                                cCorreo, cNroTelf, idSolicitud, idUsuario, idAgencia, xmlRetirados, xmlNuevos);
        }

        public DataTable ListarSolicitudesCambioAprobadas()
        {
            return objADApeCta.ListarSolicitudesCambioAprobadas();
        }

        public DataTable ListarDatosSolCta(int idCuenta,int idSolicitud)
        {
            return objADApeCta.ListarDatosSolCta(idCuenta, idSolicitud);
        }

        public DataTable ListarCambioIntervinientes(int idCuenta, int idSolicitud)
        {
            return objADApeCta.ListarCambioIntervinientes(idCuenta, idSolicitud);
        }

        public DataTable ConfirmarCambioTitulares(int idCuenta, int idSolicitud, int idSolCambio, int idUsuario, int idAgencia, DateTime dFecha)
        {
            return objADApeCta.ConfirmarCambioTitulares(idCuenta, idSolicitud, idSolCambio, idUsuario, idAgencia, dFecha);
        }

        public DataTable ValidaSolCambioTitxCta(int idCuenta)
        {
            return objADApeCta.ValidaSolCambioTitxCta(idCuenta);
        }
    }
}
