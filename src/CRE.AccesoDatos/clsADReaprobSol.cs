using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Xml.Linq;

namespace CRE.AccesoDatos
{
    public class clsADReaprobSol
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable obtenerSolReaprob(int idEstado, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_LisSolReaprob_SP", idEstado, idUsuario);
        }

        public DataTable validarSolReaprobUsu(int idSolicitud, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ValSolicitudUsu_SP", idSolicitud, idUsuario);
        }

        public DataTable validarSolReaprobRefi(int idSolicitud, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ValSolicitudRef_SP", idSolicitud, idUsuario);
        }

        public DataTable actualizarCondCredRef(int idSolicitud, int idSolReAprob, string cComentReaprob, decimal nCapitalPropuesto, int nCuotas, 
                                                    int idTipoPeriodo, int nPlazoCuota, DateTime dFechaDesembolso, int nDiasGracia, int idTasa, decimal nTEA, decimal nTEM, 
                                                    int nCuotasGracia, int nPlazo, int idUsuario, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_ActualizarSolReaprobRef_SP", idSolicitud, idSolReAprob, cComentReaprob, nCapitalPropuesto, nCuotas, 
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM, 
                                                    nCuotasGracia, nPlazo, idUsuario, dFechaSis);
        }

        public DataTable actualizarCondCredOtor(int idSolicitud, string cComentReaprob, decimal nCapitalPropuesto, int nCuotas,
                                                    int idTipoPeriodo, int nPlazoCuota, DateTime dFechaDesembolso, int nDiasGracia, int idTasa, decimal nTEA, decimal nTEM,
                                                    int nCuotasGracia, int nPlazo, int idUsuario, DateTime dFechaSis, object nCapacidadPago)
        {
            return objEjeSp.EjecSP("CRE_ActualizarSolReaprobOtor_SP", idSolicitud, cComentReaprob, nCapitalPropuesto, nCuotas,
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM,
                                                    nCuotasGracia, nPlazo, idUsuario, dFechaSis, nCapacidadPago ?? DBNull.Value);
        }

        public DataTable validarGarantias(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidarGarantia_SP", idSolicitud);
        }

        public DataTable obtenerMontoTotalRefi(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDeudaTotalRefi_SP", idSolicitud);
        }
        public  DataTable obtenerDatosSolEval(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosSolEval", idSolicitud);
        }

        public clsCreditoProp ObtenerCondicionesSolicitud(int idSolicitud)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_ObtenerCondicionesSolicitud_SP", idSolicitud);

            if (dtRes.Rows.Count <= 0)
                return new clsCreditoProp();

            return (new clsCreditoProp()
            {
                idEvalCred = Convert.ToInt32(dtRes.Rows[0]["idEvalCred"]),
                idSolicitud = Convert.ToInt32(dtRes.Rows[0]["idSolicitud"]),
                nMonto = Convert.ToDecimal(dtRes.Rows[0]["nCapitalAprobado"]),
                nCuotas = Convert.ToInt32(dtRes.Rows[0]["nCuotas"]),
                idTipoPeriodo = Convert.ToInt32(dtRes.Rows[0]["idTipoPeriodo"]),
                nPlazoCuota = Convert.ToInt32(dtRes.Rows[0]["nPlazoCuota"]),
                nPlazo = Convert.ToInt32(dtRes.Rows[0]["nPlazo"]),
                nCuotasGracia = Convert.ToInt32(dtRes.Rows[0]["nCuotasGracia"]),
                nDiasGracia = Convert.ToInt32(dtRes.Rows[0]["ndiasgracia"]),
                dFechaDesembolso = Convert.ToDateTime(dtRes.Rows[0]["dFechaDesembolso"]),
                idProducto = Convert.ToInt32(dtRes.Rows[0]["idProducto"]),
                idTasa = Convert.ToInt32(dtRes.Rows[0]["idTasa"]),
                nTasaCompensatoria = Convert.ToDecimal(dtRes.Rows[0]["nTEA"]),
                idSubProducto = Convert.ToInt32(dtRes.Rows[0]["idSubProducto"]),
                idOperacion = Convert.ToInt32(dtRes.Rows[0]["idOperacion"]),
                idAgencia = Convert.ToInt32(dtRes.Rows[0]["idAgencia"]),
                nMontoSolicitado = Convert.ToDecimal(dtRes.Rows[0]["nCapitalSolicitado"]),
                idClasificacionInterna = Convert.ToInt32(dtRes.Rows[0]["idClasificacionInterna"]),
            });
        }

        public DataTable obtenerDatosModGPP(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosModGPP_SP", idSolicitud);
        }

        public DataTable registrarReaprobacion(int idSolicitud, int idUsuario, DateTime dFechaSis, DateTime dFechaAprueba) 
        {
            return objEjeSp.EjecSP("CRE_RegistrarReaprobacion_SP", idSolicitud, idUsuario, dFechaSis, dFechaAprueba);
        }

        public DataTable terminarReaprobacion(int idSolicitud) 
        {
            return objEjeSp.EjecSP("CRE_TerminarReaprobacion_SP", idSolicitud);
        }

        public DataTable obtenerReaprobacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerReaprobacion_SP", idSolicitud);
        }

        public DataTable obtenerResumenReaprobacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerResumenPlanPago_SP", idSolicitud);
        }
        public DataTable obtenerPlanPagosSol(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerPlanPagosSolicitud_SP", idSolicitud);
        }

        public DataTable obtenerCapacidadPago(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCapacidadPagoReaprobacion_SP", parametros);
        }
    }
}
