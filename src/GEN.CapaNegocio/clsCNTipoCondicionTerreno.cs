using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoCondicionTerreno
    {
        clsADTipoCondicionTerreno objlistaCondicionTerreno = new clsADTipoCondicionTerreno(); 

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListaCondicionTerreno()
        {
            return objlistaCondicionTerreno.ADListaTipoCondicionTerreno();
        }
    }
}
