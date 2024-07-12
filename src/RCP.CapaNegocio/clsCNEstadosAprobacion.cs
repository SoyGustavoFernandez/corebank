using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNEstadosAprobacion
    {
        clsADEstados adEstados = new clsADEstados();

        public DataTable getEstadosAprobacion(int tipoOperacion)
        {
             return adEstados.getEstadosAprobacion(tipoOperacion);
        }
    }
}
