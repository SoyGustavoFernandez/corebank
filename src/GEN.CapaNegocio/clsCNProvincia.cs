using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNProvincia
    {
        clsADProvincia objListaProv = new clsADProvincia();

        // Crear metodo para recibir datos en un datatable
        public DataTable ListarProv(string cCodDpto)
        {
            return objListaProv.ListaProvincia(cCodDpto);
        }
    }
}
