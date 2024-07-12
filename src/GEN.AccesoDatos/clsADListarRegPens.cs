using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper; 
namespace GEN.AccesoDatos
{
    public class clsADListarRegPens
    {
        public DataTable ListarRegimenPen(int idTipoReg)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarRegimenPension_SP", idTipoReg);
        }
    }
}
