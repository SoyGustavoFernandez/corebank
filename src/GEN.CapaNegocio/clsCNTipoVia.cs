using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoVia
    {
        clsADTipoVia objlistaVia = new clsADTipoVia();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListaVias()
        {
            return objlistaVia.ListaVias();
        }
    }
}
