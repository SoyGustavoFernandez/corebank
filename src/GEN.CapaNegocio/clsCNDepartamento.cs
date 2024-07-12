using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNDepartamento
    {
        clsADDepartamento objListaDpto = new clsADDepartamento();

        // Crear metodo para recibid datos en un datatable
        public DataTable ListarDpto(string cCodPais)
        {
            return objListaDpto.ListaDepartamento(cCodPais);
        }
    }
}
