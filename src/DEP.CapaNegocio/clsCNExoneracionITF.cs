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
    public class clsCNExoneracionITF
    {
        clsADExoneracionITF objADApeCta = new clsADExoneracionITF();

        public DataTable DatosCuenta(int NroCuenta)
        {
            return objADApeCta.DatosCuenta(NroCuenta);
        }
        public DataTable DatosSolicitud(int NroCuenta)
        {
            return objADApeCta.DatosSolicitud(NroCuenta);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento,int EstSolic, DateTime FechaAprob,
                                        int idUsuario,bool lExcepcion)
        {
            return objADApeCta.EnviarSolicitud( idAgencia,  idCliente,  idTipoOper,  EstadoOpe,  idMoneda,  idProducto,
                                         Valor, NroCuenta,  FechaSolic,  idMotivo,  sustento, EstSolic, FechaAprob,
                                         idUsuario,lExcepcion);
        }
        public DataTable ExonerarAfectarITF(int AfectoITF,int NroCuenta, int idSolicitud, DateTime dFechaOper, int idAgencia, int idUsuario)
        {
            return objADApeCta.ExonerarAfectarITF(AfectoITF, NroCuenta, idSolicitud, dFechaOper, idAgencia, idUsuario);
        }
        public DataTable ListSoliciAprob()
        {
            return objADApeCta.ListSoliciAprob();
        }
        public DataTable AnularSol(int idsol)
        {
            return objADApeCta.AnularSol(idsol);
        }

        public DataTable SolicitudesExoneracionITF(int idCuenta)
        {
            return objADApeCta.SolicitudesExoneracion(idCuenta);
        }
        public DataTable MotivosExoITF()
        {
            return objADApeCta.CNMotivoExoneracionITF();
        }
        public DataTable CNEnviaCorreoSolExoITF(int idCli, int idCuenta, int idTipoOpe, int idUsuario, int idAgencia, int idSolicitud)
        {
            return objADApeCta.ADEnviaCorreoSolExoITF(idCli, idCuenta, idTipoOpe, idUsuario, idAgencia, idSolicitud);
        }

    }
}
