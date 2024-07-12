using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADNivelAprobacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Niveles de Aprobacion
        public List<clsNivelAprobacion> listarNivelAprobacion(int idCanalAproCred)
        {
            return this.objEjeSp.LOEjecutar<clsNivelAprobacion>("CRE_ListarNivelAprobacion_SP", 0, idCanalAproCred);
        }
        public DataTable ListaTodoNivelAprobacion()
        {
            return objEjeSp.EjecSP("CRE_ListarNivelAprobacion_SP",0, 0);
        }

        public DataTable InsertarNivelAprobacion(String cNivelAprobacion, String cDescripcion, int nOrden, String cIdsPerfiles, bool lRevision, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_InsertarNivelAprobacion_SP", cNivelAprobacion, cDescripcion, nOrden, cIdsPerfiles, lRevision, lVigente);
        }
        public DataTable ActualizarNivelAprobacion(int idNivelAprobacion, String cNivelAprobacion, String cDescripcion, int nOrden, String cIdsPerfiles, bool lRevision, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_ActualizarNivelAprobacion_SP", idNivelAprobacion, cNivelAprobacion, cDescripcion, nOrden, cIdsPerfiles, lRevision, lVigente);
        }
        public DataTable ListarPerfilAsignado(int nOpcion, string cCargos)
        {
            return objEjeSp.EjecSP("CRE_ListarPerfilAsig_SP", nOpcion, cCargos);
        }
    }
}
