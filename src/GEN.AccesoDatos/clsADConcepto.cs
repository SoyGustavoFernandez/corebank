using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADConcepto
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarConcepto(int idGrupoCon)
        {
            return objEjeSp.EjecSP("GEN_ListarConcepto_sp", idGrupoCon);
        }

        public DataTable ADListarConcepTipPag(int idTipPagCanal)
        {
            return objEjeSp.EjecSP("GEN_ListarConcepTipPag_SP", idTipPagCanal);
        }
        public DataTable ADListarConcepRecTipPag(int idTipPagCanal)
        {
            return objEjeSp.EjecSP("GEN_ListarConcepRecTipPag_SP", idTipPagCanal);
        }
    }
}
