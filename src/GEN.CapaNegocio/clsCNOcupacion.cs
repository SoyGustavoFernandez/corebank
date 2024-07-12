using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNOcupacion
    {
        clsADOcupacion objlistaOcupacion = new clsADOcupacion();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListarOcupacion()
        {
            return objlistaOcupacion.ListaOcupacion();
        }

        public DataTable ListaOcupacionPorIdDeclaracion(int idDeclaracion)
        {
            return objlistaOcupacion.ListaOcupacionPorIdDeclaracion(idDeclaracion);
        }
    }
}
