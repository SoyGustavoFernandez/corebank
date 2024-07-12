using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoCriteAsigCarteraRecu
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarTipoCriteAsigCarteraRecu()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoCriteriosAsigCartRecu_SP");
        }
    }
}
