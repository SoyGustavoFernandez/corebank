using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNEstadoCli
    {
        clsADEstadoCli ObjEstado = new clsADEstadoCli();
        public DataTable CNListaEstadoCli(int idTipoPersona)
        {
            return ObjEstado.ADListaEstadoCli(idTipoPersona);
        }
    }
}
