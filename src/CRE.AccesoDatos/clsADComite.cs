using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADComite
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarIntegComiteCredito(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarIntegComiteCredito_SP", idAgencia);
        }

        public DataTable InsertarActaComiteCredito(int idSolicitud,  string cNumActa, DateTime dFechaReg, 
                                                   int idAgencia, string cAcuerdo, string cObservaciones, string cComentario, 
                                                    int idUsuReg, string xmlDetComite)
        {
            return objEjeSp.EjecSP("CRE_InsertarActaComiteCredito_SP", idSolicitud,  cNumActa, dFechaReg, idAgencia, 
                                                    cAcuerdo, cObservaciones, cComentario, idUsuReg, xmlDetComite);
        }

        public DataTable RetornaDatosActaComite(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetornaDatosActaComite_SP", idSolicitud);
        }

        public DataTable RetornaDetalleComite(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetornaDetalleComite_SP", idSolicitud);
        }

        public DataTable RptActaComiteCredito(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RptActaComiteCredito_SP", idSolicitud);
        }

        public DataTable ActualizarComiteCredito(int idSolicitud, string cNumActa, DateTime dFechaReg,
                                                 int idAgencia, string cAcuerdo, string cObservaciones, string cComentario,
                                                 int idUsuReg, string xmlDetComite)
        {
            return objEjeSp.EjecSP("CRE_ActualizarComiteCredito_SP", idSolicitud, cNumActa, dFechaReg, idAgencia,
                                                    cAcuerdo, cObservaciones, cComentario, idUsuReg, xmlDetComite);
        }

        public DataTable ListarCargoComiteid(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarCargoComiteidAgencia_SP", idAgencia);
        }

        public DataTable InsertarCargoComite(int idAgencia, int idCargo, bool lVigente, int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_InsertarCargoComite_SP", idAgencia, idCargo, lVigente, idUsuReg);
        }

        public DataTable EliminarCargoComite(int idAgencia, int idCargo)
        {
            return objEjeSp.EjecSP("CRE_EliminarCargoComite_SP", idAgencia, idCargo);
        }
    }
}
