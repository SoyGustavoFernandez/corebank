using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADVincCredAdeudado
    {
        private clsGENEjeSP objAD = new clsGENEjeSP();

        public DataTable ADGetCtasPosiblesAdeudos(int idProducto, int idMoneda, int nAtrasoMin, int nAtrasoMax)
        {
            return objAD.EjecSP("CRE_GetCtasPosiblesAdeudos_Sp", idProducto, idMoneda, nAtrasoMin, nAtrasoMax);
        }

        public DataTable ADGetCtasAdeudado(int idAdeudado)
        {
            return objAD.EjecSP("CRE_GetCtasAdeudado_Sp", idAdeudado);
        }

        public clsDBResp ADVincularCredAdeudado(string xmlAdeudado, int idAdeudado, int lHistorico, DateTime dFechaHistorico)
        {
            return new clsDBResp(objAD.EjecSP("CRE_VincularCredAdeudado_Sp", xmlAdeudado, idAdeudado, lHistorico, dFechaHistorico));
        }
    }
}
