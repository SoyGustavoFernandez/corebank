using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantRegimen
    {
        clsADMantRegimen objRegimen = new clsADMantRegimen();
        public DataTable ListarRegimen()
        {
            return objRegimen.ListarRegimen();
        }
        public DataTable ActualizarRegimen(int idRegimen, string cNombreReg,int idTipoRegimen,decimal cPorcSNP,decimal cPorcFlujoSPP,decimal cPorcMixtaSPP,
                                             decimal cPorcSeguroSPP,decimal cPorcAporteSPP,int lVigente)
        {
            return objRegimen.ActualizarRegimen(idRegimen, cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
        }
        public int GuardarRegimen( string cNombreReg, int idTipoRegimen, decimal cPorcSNP, decimal cPorcFlujoSPP, decimal cPorcMixtaSPP,
                                             decimal cPorcSeguroSPP, decimal cPorcAporteSPP, int lVigente)
        {
            DataTable dtResul= objRegimen.GuardarRegimen(cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
            int idNuevo=Convert.ToInt32(dtResul.Rows[0][0]);
            return idNuevo;
        }
        

    }
}
