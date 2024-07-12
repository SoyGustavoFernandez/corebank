using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoZona
    {
        clsADTipoZonas objlistaZona = new clsADTipoZonas(); 

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListaZonas()
        {
            return objlistaZona.ListaZonas();
        }

        public DataTable ListaZonasSector(int idSector)
        {
            return objlistaZona.ListaZonasSector(idSector);
        }
    }
}
