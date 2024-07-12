using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoCliente
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListaTipoCliente()
        {
            return objEjeSp.EjecSP("GEN_ListaTipoCliente_sp");
        }


        public DataTable ListaPorModulo(int idModulo)
        {
            return objEjeSp.EjecSP("GEN_ListarTipoClientexModulo_sp", idModulo);
        }
    }
}
