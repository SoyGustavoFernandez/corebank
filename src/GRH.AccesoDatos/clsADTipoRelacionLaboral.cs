using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;

namespace GRH.AccesoDatos
{
    public class clsADTipoRelacionLaboral
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoRelacionLaboral()
        {
            return objEjeSp.EjecSP("GRH_ListarTipoRelacionLaboral_SP");
        }
        public DataTable ADListarTipoRelacionLaboralXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoRelacionLaboral");
        }

        public DataTable ADListarTipoRelacionLaboralPlanillas()
        {
            return objEjeSp.EjecSP("GRH_ListarTipoRelacionLaboralPlanillas_SP");
        }
    }
}
