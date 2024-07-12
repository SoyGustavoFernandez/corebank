using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADRetiroChequeGer
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaChequesByCli(string idCli, int idMotOpeBco, int idMoneda, int idTipofondo,string cNroDNI)
        {
            return objEjeSp.EjecSP("GEN_ListarCheqEmiByCliente_sp", idCli, idMotOpeBco, idMoneda, idTipofondo, cNroDNI);
        }
    }
}
