using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    
    public class clsADTipoBien
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoBien(int idTipoPedido)
        {
            return objEjeSp.EjecSP("LOG_ListarTipoBien_sp", idTipoPedido);
        }
    }
}
