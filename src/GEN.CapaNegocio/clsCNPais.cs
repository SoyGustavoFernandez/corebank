using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNPais
    {
        clsADPais objListaPais = new clsADPais();

        // Crear metodo para recibid datos en un datatable
        public DataTable ListarPaises()
        {
            return objListaPais.ListaPais();
        }
    }
}
