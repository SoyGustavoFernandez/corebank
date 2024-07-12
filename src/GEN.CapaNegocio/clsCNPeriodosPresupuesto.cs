using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNPeriodosPresupuesto
    {
        public DataTable CNListarTodosPeriodos()
        {
            return new clsADPeriodosPresupuesto().ADListarTodo();
        }
       
    }
}
