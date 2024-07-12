using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoVivienda
    {
        clsADTipoVivienda objlistaVivienda = new clsADTipoVivienda();
        public DataTable ListaViviendas()
        {
            return objlistaVivienda.ListaViviendas();
        }
    }
}
