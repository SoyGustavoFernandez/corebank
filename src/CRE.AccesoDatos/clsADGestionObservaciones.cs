using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADGestionObservaciones
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ObtenerObservacionCredito(bool lVigente, int idSolicitud, int idUsuario, int idTipif, int idEtapaEval, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CRE_ObtenerObservaciones_SP", lVigente, idSolicitud, idUsuario, idTipif, idEtapaEval, dFechaInicial, dFechaFinal);
        }

        public DataTable ObtenerEstObs(int idEstado)
        {
            return objEjeSp.EjecSP("CRE_LstEstadoObs_SP", idEstado);
        }

        public void RegistrarObservCredito(string cXmlObservaciones)
        {
            objEjeSp.EjecSP("CRE_RegObservacion_SP", cXmlObservaciones);
        }

        public DataTable EmitirObservCredito(bool lValida, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_EmitirObservacion_SP", lValida, idUsuario, dFecha);
        }

        public DataTable DetalleObservCredito(int idRegistroObs)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDetalleObserv_SP", idRegistroObs);
        }

        public DataTable ObtenerIndicadoresObs(int idSolicitud, int idEtapaEvalCred)
        {
            return objEjeSp.EjecSP("CRE_IndicadorObserv_SP", idSolicitud, idEtapaEvalCred);
        }
    }
}
