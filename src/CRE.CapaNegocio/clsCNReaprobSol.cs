using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNReaprobSol
    {
        clsADReaprobSol caReaprobSol = new clsADReaprobSol();

        public DataTable obtenerSolReaprob(int idEstado, int idUsuario)
        {
            return caReaprobSol.obtenerSolReaprob(idEstado, idUsuario);
        }

        public DataTable validarSolReaprobUsu(int idSolicitud, int idUsuario)
        {
            return caReaprobSol.validarSolReaprobUsu(idSolicitud, idUsuario);
        }

        public DataTable validarSolReaprobRefi(int idSolicitud, int idUsuario)
        {
            return caReaprobSol.validarSolReaprobRefi(idSolicitud, idUsuario);
        }

        public DataTable actualizarCondCredRef(int idSolicitud, int idSolReAprob, string cComentReaprob, decimal nCapitalPropuesto, int nCuotas,
                                                    int idTipoPeriodo, int nPlazoCuota, DateTime dFechaDesembolso, int nDiasGracia, int idTasa, decimal nTEA, decimal nTEM,
                                                    int nCuotasGracia, int nPlazo, int idUsuario, DateTime dFechaSis)
        {
            return caReaprobSol.actualizarCondCredRef(idSolicitud, idSolReAprob, cComentReaprob, nCapitalPropuesto, nCuotas,
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM,
                                                    nCuotasGracia, nPlazo, idUsuario, dFechaSis );
        }

        public DataTable actualizarCondCredOtor(int idSolicitud, string cComentReaprob, decimal nCapitalPropuesto, int nCuotas,
                                                    int idTipoPeriodo, int nPlazoCuota, DateTime dFechaDesembolso, int nDiasGracia, int idTasa, decimal nTEA, decimal nTEM,
                                                    int nCuotasGracia, int nPlazo, int idUsuario, DateTime dFechaSis, decimal? nCapacidadPago)
        {
            return caReaprobSol.actualizarCondCredOtor(idSolicitud, cComentReaprob, nCapitalPropuesto, nCuotas,
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM,
                                                    nCuotasGracia, nPlazo, idUsuario, dFechaSis, nCapacidadPago);
        }

        public DataTable validarGarantias(int idSolicitud)
        {
            return caReaprobSol.validarGarantias(idSolicitud);
        }

        public DataTable obtenerMontoTotalRefi(int idSolicitud)
        {
            return caReaprobSol.obtenerMontoTotalRefi(idSolicitud); ;
        }

        public DataTable obtenerDatosSolEval(int idSolicitud)
        {
            return caReaprobSol.obtenerDatosSolEval(idSolicitud);
        }

        public clsCreditoProp ObtenerCondicionesSolicitud(int idSolicitud)
        {
            return caReaprobSol.ObtenerCondicionesSolicitud(idSolicitud);
        }

        public DataTable obtenerDatosModGPP(int idSolicitud)
        {
            return caReaprobSol.obtenerDatosModGPP(idSolicitud);
        }

        public DataTable registrarReaprobacion(int idSolicitud, int idUsuario, DateTime dFechaSis, DateTime dFechaAprueba) 
        {
            return caReaprobSol.registrarReaprobacion(idSolicitud, idUsuario, dFechaSis, dFechaAprueba);
        }

        public DataTable terminarReaprobacion(int idSolicitud) //
        {
            return caReaprobSol.terminarReaprobacion(idSolicitud);
        }

        public DataTable obtenerReaprobacion(int idSolicitud) //
        {
            return caReaprobSol.obtenerReaprobacion(idSolicitud);
        }

        public DataTable obtenerResumenReaprobacion(int idSolicitud) //
        {
            return caReaprobSol.obtenerResumenReaprobacion(idSolicitud);
        }
        public DataTable obtenerPlanPagosSol(int idSolicitud)
        {
            return caReaprobSol.obtenerPlanPagosSol(idSolicitud);
        }

        public DataTable obtenerCapacidadPago(int idSolicitud, decimal nCuotaAprox)
        {
            return caReaprobSol.obtenerCapacidadPago(idSolicitud, nCuotaAprox);
        }
    }
}
