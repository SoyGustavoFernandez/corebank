using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADEnvioBoletas
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADInsertarDatos(string cDni, string cNombres, string cApellidos, string cPeriodo, string cAgencia, string cCorreoColabString, string cSexo, string cNomArchivo, string cEstado, string cError)
        {
            return objEjeSp.EjecSP("GRH_InsertarEnvioBoletas_SP", cDni, cNombres, cApellidos, cPeriodo, cAgencia, cCorreoColabString, cSexo, cNomArchivo, cEstado, cError);
        }

        public DataTable ADVerDatos(int nDato)
        {
            return objEjeSp.EjecSP("GRH_VerEnvioBoletas_SP",nDato);
        }

       


    }
}
