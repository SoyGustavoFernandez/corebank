using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNEstadosPeriodoPres
    {
        public DataTable CNListarTodosEstados()
        {
            return new clsADEstadoPeriodoPres().ADListarTodosEstados();
        }

        public DataTable CNListarUnEstado(int idEstado)
        {
            return new clsADEstadoPeriodoPres().ADListarUnEstado(idEstado);
        }
    }
}
