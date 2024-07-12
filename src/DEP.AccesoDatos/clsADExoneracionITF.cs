using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace DEP.AccesoDatos
{
    public class clsADExoneracionITF
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
            return objEjeSP.EjecSP("DEP_DatosSolExonerITF_Sp", NroCuenta);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor,int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento,int EstSolic, DateTime FechaAprob,
                                        int idUsuario,bool lExcepcion, int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSP.EjecSP("GEN_InsSoliciAproba_SP",  idAgencia,  idCliente,  idTipoOper,  EstadoOpe,  idMoneda,  idProducto,
                                         Valor, NroCuenta,  FechaSolic,  idMotivo,  sustento,EstSolic,  FechaAprob,
                                         idUsuario, lExcepcion, idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }
        public DataTable ExonerarAfectarITF(int AfectoITF, int NroCuenta, int idSolicitud, DateTime dFechaOper, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("DEP_ExonerarITF_Sp",AfectoITF, NroCuenta, idSolicitud, dFechaOper,  idAgencia, idUsuario);
        }
        public DataTable ListSoliciAprob()
        {
            return objEjeSP.EjecSP("DEP_ListaSolExonerAprob_Sp");
        }
        public DataTable AnularSol(int idsol)
        {
            return objEjeSP.EjecSP("DEP_AnularSolExonerITF_Sp", idsol);
        }

        public DataTable SolicitudesExoneracion(int idCuenta)
        {
            return objEjeSP.EjecSP("DEP_SolicitudesExoITF_SP", idCuenta);
        }
        public DataTable CNMotivoExoneracionITF()
        {
            return objEjeSP.EjecSP("DEP_MotivosExoneracionITF_SP");
        }
        public DataTable ADEnviaCorreoSolExoITF(int idCli, int idCuenta, int idTipoOpe, int idUsuario, int idAgencia, int idSolicitud)
        {
            return objEjeSP.EjecSP("DEP_EnviarEmailSolExoneraITF_Sp", idCli, idCuenta, idTipoOpe, idUsuario, idAgencia, idSolicitud);
        }
    }
}
