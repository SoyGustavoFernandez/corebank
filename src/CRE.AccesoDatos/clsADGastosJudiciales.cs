using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADGastosJudiciales
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable RegistrarSolicitud(int idCuenta, int idConcepto, int idMoneda, decimal nMonto, string cObservacion, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_RegSolGastoJudicial_SP", idCuenta, idConcepto, idMoneda, nMonto, cObservacion, idUsuario, dFecha);
        }

        public DataTable ListarPendientes(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_LstSolGastoJudicialPendientes_SP", idCuenta);
        }

        public DataTable EliminarSolGastoJud(int idSolCargaGastosJudiciales, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_EliSolGastoJudicial_SP", idSolCargaGastosJudiciales, idUsuario, dFecha);
        }

        public DataTable Listar(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_LstSolGastoJudicial_SP", idCuenta);
        }

        public DataTable CargarGastosJudiciales(int idCuenta, int idPlanPagos, int idProducto, string cMotivoCarga, int idMoneda, string XMLGastosJudiciales, int idUsuario, int idAgencia, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_CargaSolGastoJudicial_SP", idCuenta, idPlanPagos, idProducto, cMotivoCarga, idMoneda, XMLGastosJudiciales, idUsuario, idAgencia, dFecha);
        }

        public DataTable ObtenerDatosCredito(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosCreditoCargarJud_SP", idCuenta);
        }

        public DataTable ContarGastosPendientes(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ContarNumCobrosJudPend_SP", idCuenta);
        }
    }
}
