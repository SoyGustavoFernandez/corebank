using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADTipoPersonaEjeActProc
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable listar()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoPersEjecActProc_SP");
        }
    }
}
