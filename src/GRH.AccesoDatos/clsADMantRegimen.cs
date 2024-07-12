using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantRegimen
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarRegimen()
        {
            return objEjeSp.EjecSP("GRH_ListarDatosRegimen_SP");
        }
        public DataTable ActualizarRegimen(int idRegimen, string cNombreReg, int idTipoRegimen, decimal cPorcSNP, decimal cPorcFlujoSPP, decimal cPorcMixtaSPP,
                                             decimal cPorcSeguroSPP, decimal cPorcAporteSPP, int lVigente)
        {
             return objEjeSp.EjecSP("GRH_ActualizarRegimen_SP", idRegimen, cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
        }
        public DataTable GuardarRegimen(string cNombreReg, int idTipoRegimen, decimal cPorcSNP, decimal cPorcFlujoSPP, decimal cPorcMixtaSPP,
                                             decimal cPorcSeguroSPP, decimal cPorcAporteSPP, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_GuardarRegimen_SP", cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
        }
    }
}
