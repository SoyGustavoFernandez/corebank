using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNEstadoCivil
    {
        clsADEstadoCivil objlistaEstCivil = new clsADEstadoCivil();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListaEstadoCivil( int nInd)
        {
            return objlistaEstCivil.ListaEstadoCivil(nInd);
        }
    }
}
