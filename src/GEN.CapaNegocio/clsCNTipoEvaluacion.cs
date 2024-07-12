using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoEvaluacion
    {
        clsADTipoEvaluacion objTipoEval = new clsADTipoEvaluacion();

        public DataTable CNListarTipoEvaluacion()
        {
            return objTipoEval.ADListarTipoEvaluacion();
        }
    }
}
