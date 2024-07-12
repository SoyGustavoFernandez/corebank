using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNActividadLog
    {
        public DataTable CNListaActividadLog(int idAgencia,int idPerfil)
        {
            return new clsADActividadLog().ADListaActividadLog(idAgencia,idPerfil);
        }
    }
}
