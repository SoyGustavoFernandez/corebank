using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNNivelAprobacion
    {
        clsADNivelAprobacion adnivelAprobacion = new clsADNivelAprobacion();
        public List<clsNivelAprobacion> listarNivelAprobacion(int idCanalAproCred = 0)
        {
            return adnivelAprobacion.listarNivelAprobacion(idCanalAproCred);
        }
        public DataTable ListaTodoNivelAprobacion()
        {
            return adnivelAprobacion.ListaTodoNivelAprobacion();
        }
        public DataTable InsertarNivelAprobacion(String cNivelAprobacion, String cDescripcion, int nOrden, String cIdsPerfiles, bool lRevision, bool lVigente)
        {
            return adnivelAprobacion.InsertarNivelAprobacion(cNivelAprobacion, cDescripcion, nOrden, cIdsPerfiles, lRevision, lVigente);
        }
        public DataTable ActualizarNivelAprobacion(int idNivelAprobacion, String cNivelAprobacion, String cDescripcion, int nOrden, String cIdsPerfiles, bool lRevision, bool lVigente)
        {
            return adnivelAprobacion.ActualizarNivelAprobacion(idNivelAprobacion, cNivelAprobacion, cDescripcion, nOrden, cIdsPerfiles, lRevision, lVigente);
        }
        public DataTable ListarPerfilAsignado(int nOpcion, string cCargos)
        {
            return adnivelAprobacion.ListarPerfilAsignado(nOpcion, cCargos);
        }
    }
}
