using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADEmpresasConvenio
    {
        clsGENEjeSP objEjeSp;
        public clsADEmpresasConvenio()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ADObtenerListaEmpresas()
        {
            return objEjeSp.EjecSP("CRE_RetornaListaEmpresasConvenio_SP");
        }
    }
}
