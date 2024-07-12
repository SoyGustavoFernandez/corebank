using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNComite
    {
        clsADComite adcomite = new clsADComite();
        public DataTable ListarIntegComiteCredito(int idAgencia)
        {
            return adcomite.ListarIntegComiteCredito(idAgencia);
        }

        public DataTable InsertarActaComiteCredito(int idSolicitud, string cNumActa, DateTime dFechaReg,
                                                  int idAgencia, string cAcuerdo, string cObservaciones, string cComentario,
                                                   int idUsuReg, string xmlDetComite)
        {
            return adcomite.InsertarActaComiteCredito(idSolicitud,  cNumActa, dFechaReg, idAgencia,
                                                    cAcuerdo, cObservaciones, cComentario, idUsuReg, xmlDetComite);
        }

        public DataTable RetornaDatosActaComite(int idSolicitud)
        {
            return adcomite.RetornaDatosActaComite(idSolicitud);
        }

        public DataTable RetornaDetalleComite(int idSolicitud)
        {
            return adcomite.RetornaDetalleComite(idSolicitud);
        }

        public DataTable RptActaComiteCredito(int idSolicitud)
        {
            return adcomite.RptActaComiteCredito(idSolicitud);
        }

        public DataTable ActualizarComiteCredito(int idSolicitud, string cNumActa, DateTime dFechaReg,
                                                 int idAgencia, string cAcuerdo, string cObservaciones, string cComentario,
                                                 int idUsuReg, string xmlDetComite)
        {
            return adcomite.ActualizarComiteCredito(idSolicitud, cNumActa, dFechaReg, idAgencia,
                                                    cAcuerdo, cObservaciones, cComentario, idUsuReg, xmlDetComite);
        }

        public DataTable ListarCargoComiteid(int idAgencia)
        {
            return adcomite.ListarCargoComiteid(idAgencia);
        }

        public DataTable InsertarCargoComite(int idAgencia, int idCargo, bool lVigente, int idUsuReg)
        {
            return adcomite.InsertarCargoComite(idAgencia, idCargo, lVigente, idUsuReg);
        }

        public DataTable EliminarCargoComite(int idAgencia, int idCargo)
        {
            return adcomite.EliminarCargoComite(idAgencia, idCargo);
        }
    }
}
