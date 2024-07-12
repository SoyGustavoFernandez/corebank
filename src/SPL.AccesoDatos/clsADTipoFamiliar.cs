using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADTipoFamiliar
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable dt = new DataTable();

        public DataTable listarTipoFamiliar()
        {
            dt = objEjeSp.EjecSP("GEN_ListarTipoFamiliar");
            return dt;
        }

        public DataTable ListarTipoVinculo()
        {
            dt = objEjeSp.EjecSP("CLI_ListarTipoVinculo_SP");
            return dt;
        }
    }
}
