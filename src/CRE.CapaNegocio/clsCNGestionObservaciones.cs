using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNGestionObservaciones
    {
        private clsADGestionObservaciones objGestionObservaciones = new clsADGestionObservaciones();

        public DataTable ObtenerObservacionCredito(bool lVigente, int idSolicitud, int idUsuario, int idTipif, int idEtapaEval, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objGestionObservaciones.ObtenerObservacionCredito(lVigente, idSolicitud, idUsuario, idTipif, idEtapaEval, dFechaInicial, dFechaFinal);
        }

        public DataTable ObtenerEstObs(int idEstado)
        {
            return objGestionObservaciones.ObtenerEstObs(idEstado);
        }

        public void RegistrarObservCredito(string cXmlObservaciones)
        {
            objGestionObservaciones.RegistrarObservCredito(cXmlObservaciones);
        }

        public DataTable EmitirObservCredito(bool lValida, int idUsuario, DateTime dFecha)
        {
            return objGestionObservaciones.EmitirObservCredito(lValida, idUsuario, dFecha);
        }

        public DataTable DetalleObservCredito(int idRegistroObs)
        {
            return objGestionObservaciones.DetalleObservCredito(idRegistroObs);
        }

        public DataTable ObtenerIndicadoresObs(int idSolicitud, int idEtapaEvalCred)
        {
            return objGestionObservaciones.ObtenerIndicadoresObs(idSolicitud, idEtapaEvalCred);
        }
    }
}
