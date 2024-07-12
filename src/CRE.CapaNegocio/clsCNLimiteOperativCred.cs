using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNLimiteOperativCred
    {
        public DataTable GetLimitesAsesor(int idUsuario, int idAgencia)
        {
            return new clsADLimiteOperativCred().GetLimitesAsesor(idUsuario, idAgencia);
        }
    }
}
