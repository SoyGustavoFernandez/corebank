using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTramo
    {
        clsADTramo adTramo = new clsADTramo();
        public DataTable listar(int idPerfil)
        {
            return adTramo.listar(idPerfil);
        }

        public DataTable ListarTipoTramos()
        {
            return adTramo.ListarTipoTramos();
        }

        public DataTable listarTodo()
        {
            return adTramo.listarTodo();
        }

        public DataTable registrarTramo(string cNombre, string cDescripcion, int nAtrasoMinimo, int nAtrasoMaximo, string cUsuarioReg, bool lVigente, int idTipoTramo)
        {
            return adTramo.registrarTramo(cNombre, cDescripcion, nAtrasoMinimo, nAtrasoMaximo, cUsuarioReg, lVigente, idTipoTramo);
        }

        public DataTable actualizarTramo(int idTramo, string cNombre, string cDescripcion, int nAtrasoMinimo, int nAtrasoMaximo, string cUsuarioReg, bool lVigente, int idTipoTramo)
        {
            return adTramo.actualizarTramo(idTramo, cNombre, cDescripcion, nAtrasoMinimo, nAtrasoMaximo, cUsuarioReg, lVigente, idTipoTramo);
        }
    }
}
