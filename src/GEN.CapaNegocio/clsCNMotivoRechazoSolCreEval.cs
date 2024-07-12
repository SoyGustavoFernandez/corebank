using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNMotivoRechazoSolCreEval
    {
        clsADMotivoRechazoSolCreEval cnMotivo;

        public clsCNMotivoRechazoSolCreEval()
        {
            cnMotivo = new clsADMotivoRechazoSolCreEval();
        }

        public DataTable CNlistaMotivos(int nCondicion)
        {
            return cnMotivo.ADListarMotivo(nCondicion);

        }
    }
}
