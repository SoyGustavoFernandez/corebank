using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADClasifCli
    {
        public DataTable ADLstMotReclasifCli()
        {
            return new clsGENEjeSP().EjecSP("GEN_LstMotReclasifCli_Sp");
        }
    }
}
