using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTramo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable listar(int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ListarTramo_SP", idPerfil);            
        }

        public DataTable ListarTipoTramos()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoTramo_SP");            
        }

        public DataTable listarTodo()
        {
            return objEjeSp.EjecSP("RCP_ListarTramoTodos_SP");    
        }

        public DataTable registrarTramo(string cNombre, string cDescripcion, int nAtrasoMinimo, int nAtrasoMaximo, string cUsuarioReg, bool lVigente, int idTipoTramo)
        {
            return objEjeSp.EjecSP("RCP_InsertarTramo_SP", cNombre, cDescripcion, nAtrasoMinimo, nAtrasoMaximo, cUsuarioReg, lVigente, idTipoTramo);    
        }

        public DataTable actualizarTramo(int idTramo, string cNombre, string cDescripcion, int nAtrasoMinimo, int nAtrasoMaximo, string cUsuarioReg, bool lVigente, int idTipoTramo)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTramo_SP", idTramo, cNombre, cDescripcion, nAtrasoMinimo, nAtrasoMaximo, cUsuarioReg, lVigente, idTipoTramo);    
        }
    }
}
