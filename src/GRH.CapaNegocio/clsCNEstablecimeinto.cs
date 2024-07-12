using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNEstablecimeinto
    {
        clsADEstablecimeinto ListaAreas = new clsADEstablecimeinto();

        public DataTable ListadoEstablec(int idAgencia)
        {
            return ListaAreas.ListadoEstablec(idAgencia);
        }

        public DataTable ListadoEstablecimientos(int idPadre, int idZona, int idAgencia)
        {
            return ListaAreas.ListarEstablecimientos(idPadre, idZona, idAgencia);
        }
    }
}
