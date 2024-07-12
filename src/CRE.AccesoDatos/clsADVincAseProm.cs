using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADVincAseProm 
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADLstPromotorByAsesorAgencia(int idAsesor,int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CRE_LstPromotoresByAsesorAgencia_Sp", idAsesor,idAgencia);
        }

        public DataTable AdVincAsesorPromotor(int idAsesor, string xmlPromotores, DateTime dFecSis, int idUsuReg)
        {
            return new clsGENEjeSP().EjecSP("CRE_VincAsesorPromotor_Sp", idAsesor, xmlPromotores, dFecSis, idUsuReg);
        }

        public DataTable AdDesvincAsesorPromotor(int idAsesor, string xmlPromotores, DateTime dFecSis, int idUsuReg)
        {
            return new clsGENEjeSP().EjecSP("CRE_DesvincAsesorPromotor_Sp", idAsesor, xmlPromotores, dFecSis, idUsuReg);
        }

        public DataTable ADlistarVinculoAsesorPromotor(int idUsuario, int nTipoVinculo)
        {
            return objEjeSp.EjecSP("CRE_listarVinculoAsesorPromotor_Sp", idUsuario, nTipoVinculo);
        }

        public DataTable ADbuscarPromotor(bool bAsignados, int idAgencia, string txtBusPromotor)
        {
            return new clsGENEjeSP().EjecSP("CRE_BuscarPromotorAsesorAgencia_SP", bAsignados, idAgencia, txtBusPromotor);
        }
    }
}
