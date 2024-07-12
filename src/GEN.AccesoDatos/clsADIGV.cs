using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADIGV
    {
        #region atributos 
        clsGENEjeSP oEjeSP = new clsGENEjeSP();

        #endregion

        #region métodos
        public DataTable listarIGV()
        {
            return oEjeSP.EjecSP("GEN_ListaIGV_SP");
        }
        #endregion
    }
}
