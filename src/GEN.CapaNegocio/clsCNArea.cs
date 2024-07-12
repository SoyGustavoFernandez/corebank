using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;


namespace GEN.CapaNegocio
{
    public class clsCNArea
    {
        public DataTable CNListadoArea(int idAgencia)
        {
            return new clsADArea().CNListadoArea(idAgencia);
        }
        public DataTable CNListarTodasAreas()
        {
            return new clsADArea().CNListarTodasAreas();
        }
        public DataTable CNListadoTodosPorArea(int idAgencia)
        {
            return new clsADArea().CNListadoTodosPorArea(idAgencia);
        }

    }
}
