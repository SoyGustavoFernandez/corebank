using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPlantillaCuentaAsientoPlanilla
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPlantillaCuentaAsientoPlanilla(int idTipoPlanilla, int idConcepto)
        {
            return objEjeSp.EjecSP("GRH_ListarPlantillaCuentaAsientoPlanilla_SP", idTipoPlanilla, idConcepto);
        }

        public DataTable ADActualizarPlantillaCuentaAsientoPlanilla(int idTipoPlanilla, int idConcepto, string xmlPlantillaCtaCtb)
        {
            return objEjeSp.EjecSP("GRH_ActualizarPlantillaCuentaAsientoPlanilla_SP", idTipoPlanilla, idConcepto, xmlPlantillaCtaCtb);
        }
    }
}
