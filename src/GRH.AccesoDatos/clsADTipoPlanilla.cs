using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADTipoPlanilla
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoPlanillaRelacionLab(int idTipoRelLab)
        {
            return objEjeSp.EjecSP("GRH_ListarTipoPlanillaRelacionLab_SP", idTipoRelLab);
        }

        public DataTable ADListarTipoPlanillaProvisionRelacionLab(int idTipoRelLab)
        {
            return objEjeSp.EjecSP("GRH_ListarTipoPlanillaProvisionRelacionLab_SP", idTipoRelLab);
        }

        public DataTable ADListarTipoPlanillaAdelantoRelacionLab(int idTipoRelLab)
        {
            return objEjeSp.EjecSP("GRH_ListarTipoPlanillaAdelantoRelacionLab_SP", idTipoRelLab);
        }
    }
}
