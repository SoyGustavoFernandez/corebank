using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
namespace GEN.AccesoDatos
{
    public class clsADGrupoCargaArchivo
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarGrupoArchivo()
        {
            return objEjeSp.EjecSP("CRE_ObtenerGrupoCargaArchivo_SP");
        }
    }
}
