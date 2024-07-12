using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNGastosJudiciales
    {
        clsADGastosJudiciales ADGastosJudiciales = new clsADGastosJudiciales();

        public DataTable RegistrarSolicitud(int idCuenta, int idConcepto, int idMoneda, decimal nMonto, string cObservacion, int idUsuario, DateTime dFecha)
        {
            return ADGastosJudiciales.RegistrarSolicitud(idCuenta, idConcepto, idMoneda, nMonto, cObservacion, idUsuario, dFecha);
        }

        public DataTable Listar(int idCuenta)
        {
            return ADGastosJudiciales.Listar(idCuenta);
        }


        public DataTable ListarPendientes(int idCuenta)
        {
            return ADGastosJudiciales.ListarPendientes(idCuenta);
        }

        public DataTable EliminarSolGastoJud(int idSolCargaGastosJudiciales, int idUsuario, DateTime dFecha)
        {
            return ADGastosJudiciales.EliminarSolGastoJud(idSolCargaGastosJudiciales, idUsuario, dFecha);
        }

        public DataTable CargarGastosJudiciales(int idCuenta, int idPlanPagos, int idProducto, string cMotivoCarga, int idMoneda, string XMLGastosJudiciales, int idUsuario, int idAgencia, DateTime dFecha)
        {
            return ADGastosJudiciales.CargarGastosJudiciales(idCuenta, idPlanPagos, idProducto, cMotivoCarga, idMoneda, XMLGastosJudiciales, idUsuario, idAgencia, dFecha);
        }

        public DataTable ObtenerDatosCredito(int idCuenta)
        {
            return ADGastosJudiciales.ObtenerDatosCredito(idCuenta);
        }

        public DataTable ContarGastosPendientes(int idCuenta)
        {
            return ADGastosJudiciales.ContarGastosPendientes(idCuenta);
        }
    }
}
