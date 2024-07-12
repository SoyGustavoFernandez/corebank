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
    public class clsADModalidadPlanilla
    {

        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarModalidadPlanilla()
        {
            return objEjeSp.EjecSP("GRH_ListarModalidadPlanilla_SP");
        }
        public DataTable ADListarModalidadPlanillaXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinModalidadPlanilla");
        }

        public DataTable ADListarModalidadTipoPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarModalidadTipoPlanilla_SP", idTipoPlanilla);
        }

        public DataTable ADListarModalidadDctoAdelantoTipoPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarModalidadDctoAdelantoTipoPlanilla_SP", idTipoPlanilla);
        }

    }
}
