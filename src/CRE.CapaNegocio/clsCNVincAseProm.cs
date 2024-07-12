using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNVincAseProm
    {
        clsADVincAseProm advinasepro = new clsADVincAseProm();

        public DataTable CNLstPromotorByAsesorAgencia(int idAsesor,int idAgencia)
        {
            return new clsADVincAseProm().ADLstPromotorByAsesorAgencia(idAsesor,idAgencia);
        }

        public DataTable CNVincAsesorPromotor(int idAsesor, string xmlPromotores, DateTime dFecSis, int idUsuReg)
        {
            return new clsADVincAseProm().AdVincAsesorPromotor(idAsesor, xmlPromotores, dFecSis, idUsuReg);
        }
        

        public DataTable CNDesvincAsesorPromotor(int idAsesor, string xmlPromotores, DateTime dFecSis, int idUsuReg)
        {
            return new clsADVincAseProm().AdDesvincAsesorPromotor(idAsesor, xmlPromotores, dFecSis, idUsuReg);
        }

        public DataTable CNlistarVinculoAsesorPromotor(int idUsuario, int nTipoVinculo)
        {
            return advinasepro.ADlistarVinculoAsesorPromotor(idUsuario, nTipoVinculo);
        }

        public DataTable CNbuscarPromotor(bool bAsignados, int idAgencia, string txtBusPromotor)
        {
            return new clsADVincAseProm().ADbuscarPromotor(bAsignados, idAgencia, txtBusPromotor);
        }
    }
}
