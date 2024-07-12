using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNJustificaciones
    {
        clsADJustificaciones ListaJustificaciones = new clsADJustificaciones();
        
        public DataTable Inasistencias(int idUsuario,int idPeriodo)
        {
            return ListaJustificaciones.Inasistencias(idUsuario, idPeriodo);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                       decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                       int idUsuario, bool x_lExcepcion)
        {
            return ListaJustificaciones.EnviarSolicitud(idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, x_lExcepcion);
        }
        public int GuardarSolicitud(int idUsuario, string cSustento,string XMLInasistencias)
        {
            DataTable tbJustificacion = ListaJustificaciones.GuardarSolicitud(idUsuario, cSustento, XMLInasistencias);
            int idJustificacion = Convert.ToInt32(tbJustificacion.Rows[0][0]);
            return idJustificacion;
        }
        public DataTable DatosSolicitud(int idUsuario, int idPeriodo)
        {
            return ListaJustificaciones.DatosSolicitud(idUsuario, idPeriodo);
        }
        public void AnularSolicRechazada(int idSolicitud)
        {
            ListaJustificaciones.AnularSolicRechazada(idSolicitud);
        }
    }
}
