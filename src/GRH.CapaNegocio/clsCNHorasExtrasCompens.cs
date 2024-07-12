using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNHorasExtrasCompens
    {
        clsADHorasExtrasCompens ListaJustificaciones = new clsADHorasExtrasCompens();
        public DataTable SolicitudesPendientes(int idUsuario)
        {
            return ListaJustificaciones.SolicitudesPendientes(idUsuario);
        }
        public DataTable DatosCompensaciones(int idUsuario)
        {
            return ListaJustificaciones.DatosCompensaciones(idUsuario);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                       decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                       int idUsuario, int IExcepcion)
        {
            return ListaJustificaciones.EnviarSolicitud(idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, IExcepcion);
        }

        public DataTable GuardarCompensacion(int idUsuario,DateTime FecInicio,DateTime FecFin,int lTurno,int idTurno,DateTime HoraInicio,DateTime HoraFin,int MinutosXCompensar,
                                             int idUsuarioRegistro,DateTime dFechaRegistro)
        {
            return ListaJustificaciones.GuardarCompensacion(idUsuario, FecInicio, FecFin, lTurno, idTurno, HoraInicio, HoraFin,MinutosXCompensar,
                                                            idUsuarioRegistro, dFechaRegistro);
        }

        public DataTable ConsultarCantMinutos(int idTurno)
        {
            return ListaJustificaciones.ConsultarCantMinutos(idTurno);
        }
        public DataTable CNHoraextra(int idClienteUsuario)
        {
            return ListaJustificaciones.CADHoraextra(idClienteUsuario);
        }
    }
}
