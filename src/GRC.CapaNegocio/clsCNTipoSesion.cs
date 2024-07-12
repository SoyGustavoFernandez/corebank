using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public class clsCNTipoSesion
    {
        clsADTipoSesion tiposesion = new clsADTipoSesion();

        public DataTable ListarTipoSesion()
        {
            return tiposesion.ListarTipoSesion();
        }

        public DataTable InsertarTipoSesion(string cTipoSesion, bool lVigente)
        {
            return tiposesion.InsertarTipoSesion( cTipoSesion, lVigente);
        }

        public DataTable ActualizarTipoSesion(string cTipoSesion, bool lVigente, int idTipoSesion)
        {
            return tiposesion.ActualizarTipoSesion( cTipoSesion, lVigente, idTipoSesion);
        }
    }
}
