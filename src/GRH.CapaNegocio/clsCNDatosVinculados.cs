using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNDatosVinculados
    {
        clsADDatosVinculados objDatosVinculados = new clsADDatosVinculados();

        public DataTable CNDatosVinculados(int estado)
        {
            return objDatosVinculados.getDatosVinculados(estado);
        }
    }
}
