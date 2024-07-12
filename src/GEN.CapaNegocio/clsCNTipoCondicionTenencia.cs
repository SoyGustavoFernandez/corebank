using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoCondicionTenencia
    {
        clsADTipoCondicionTenencia objlistaCondicionTenencia = new clsADTipoCondicionTenencia(); 

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListaCondicionTenencia()
        {
            return objlistaCondicionTenencia.ADListaTipoCondicionTenencia();
        }
    }
}
