using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace DEP.AccesoDatos
{
    public class clsADAutorTasaEsp
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();

        //============================================================================
        //---Listado Campos Deposito
        //============================================================================
        public DataTable DatosCuenta(int NroCuenta)
        {
            return objEjeSP.EjecSP("DEP_DatosCtaExonerITF_Sp", NroCuenta);
        }
        public DataTable DatosSolicitud(int NroCuenta)
        {
            return objEjeSP.EjecSP("DEP_DatosSolTasaEsp_Sp", NroCuenta);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                        int idUsuario,bool lExcepcion = false, int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSP.EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, lExcepcion, idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }
        public DataTable AplicarTasaEsp(decimal nTasaNueva,int NroCuenta, int idSolicitud)
        {
            return objEjeSP.EjecSP("DEP_AplicarTasaEsp_Sp", nTasaNueva, NroCuenta, idSolicitud);
        }
        public DataTable ListTasaSoliciAprob()
        {
            return objEjeSP.EjecSP("DEP_ListaSolTasaEspAprob_Sp");
        }
        public DataTable AnularSol(int idsol)
        {
            return objEjeSP.EjecSP("DEP_AnularSolExonerITF_Sp", idsol);
        }

        public DataTable SolicitudTasaEspecial(int idCuenta)
        {
            return objEjeSP.EjecSP("DEP_SolicitudesTasaEspecial_SP", idCuenta);
        }

        public DataTable RegistraSolCambioInterv(int idCuenta,int idMotivo, string cMotCambio,int nNroFirmas,string cDocRef,DateTime dFechaDoc,
                                                string cCorreo,string cNroTelf,int idSolicitud,int idUsuario,int idAgencia,string xmlRetirados,string xmlNuevos)
        {
            return objEjeSP.EjecSP("DEP_RegSolCambioTitulares_SP", idCuenta,idMotivo, cMotCambio,nNroFirmas,cDocRef, dFechaDoc,
                                                                cCorreo, cNroTelf, idSolicitud, idUsuario, idAgencia, xmlRetirados, xmlNuevos);
        }

        public DataTable ListarSolicitudesCambioAprobadas()
        {
            return objEjeSP.EjecSP("DEP_SolAprobadasCambioTitular_sp");
        }

        public DataTable ListarDatosSolCta(int idCuenta, int idSolicitud)
        {
            return objEjeSP.EjecSP("DEP_DatosCtaCambioTitular_sp", idCuenta, idSolicitud);
        }

        public DataTable ListarCambioIntervinientes(int idCuenta, int idSolicitud)
        {
            return objEjeSP.EjecSP("DEP_ListaIntervCambioTitular_sp", idCuenta, idSolicitud);
        }

        public DataTable ConfirmarCambioTitulares(int idCuenta, int idSolicitud,int idSolCambio,int idUsuario,int idAgencia,DateTime dFecha)
        {
            return objEjeSP.EjecSP("DEP_ConfirmaCambioTitular_Sp", idCuenta, idSolicitud, idSolCambio, idUsuario, idAgencia, dFecha);
        }

        public DataTable ValidaSolCambioTitxCta(int idCuenta)
        {
            return objEjeSP.EjecSP("DEP_ValidaCambioTitularCta_sp", idCuenta);
        }

    }
}
