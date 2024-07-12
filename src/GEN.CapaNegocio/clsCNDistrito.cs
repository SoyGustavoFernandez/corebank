using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNDistrito
    {
        clsADDistrito objListaProv = new clsADDistrito();

        // Crear metodo para recibir datos en un datatable
        public DataTable ListarDist(string cCodDist)
        {
            return objListaProv.ListaDistrito(cCodDist);
        }
    }
}
