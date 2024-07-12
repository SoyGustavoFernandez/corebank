using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNEmpresasConvenio
    {
        clsADEmpresasConvenio clsEm;
        public clsCNEmpresasConvenio()
        {
            clsEm = new clsADEmpresasConvenio();
        }

        public DataTable CNObtenerListaEmpresas()
        {
            return clsEm.ADObtenerListaEmpresas();
        }
    }
}
