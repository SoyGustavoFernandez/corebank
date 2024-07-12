using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    
    public class clsCNRetiroChequeGer
    {
        clsADRetiroChequeGer clsRetiro = new clsADRetiroChequeGer();
        public DataTable CNListaChequesByCli(string idCli, int idMotOpeBco, int idMoneda, int idTipofondo, string cNroDNI)
        {
            return clsRetiro.ADListaChequesByCli(idCli, idMotOpeBco, idMoneda, idTipofondo, cNroDNI);
        }
    }
}
