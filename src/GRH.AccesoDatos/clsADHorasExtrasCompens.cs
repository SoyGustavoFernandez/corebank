using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADHorasExtrasCompens
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable SolicitudesPendientes(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarSolicHorasExtras_SP", idUsuario);
        }
        public DataTable DatosCompensaciones(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarCompenHorasExtras_SP", idUsuario);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                       decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                       int idUsuario, int IExcepcion, int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSp.EjecSP("GEN_InsSoliciAproba_SP",idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, IExcepcion, idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }

        public DataTable GuardarCompensacion(int idUsuario,DateTime FecInicio,DateTime FecFin,int lTurno,int idTurno,DateTime HoraInicio,DateTime HoraFin,int MinutosXCompensar,
                                             int idUsuarioRegistro,DateTime dFechaRegistro)
        {
           return objEjeSp.EjecSP("GRH_GuardarCompensHorasExtras_SP", idUsuario,FecInicio, FecFin, lTurno, idTurno, HoraInicio, HoraFin,MinutosXCompensar, 
                                                            idUsuarioRegistro, dFechaRegistro);
        }
        public DataTable ConsultarCantMinutos(int idTurno)
        {
            return objEjeSp.EjecSP("GRH_ConsultarCantMin_SP", idTurno);
        }

        public DataTable CADHoraextra(int idClienteUsuario)
        {
            return objEjeSp.EjecSP("RPT_HorasExtras_sp", idClienteUsuario);
        }
    }
}
