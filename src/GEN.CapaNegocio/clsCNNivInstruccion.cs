using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNNivInstruccion
    {
        clsADNivInstruccion objlista = new clsADNivInstruccion();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListarNivInstruccion()
        {
            return objlista.ListaNivInstruccion();
        }
    }
}
