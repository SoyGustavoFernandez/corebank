using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNControlAsistencia
    {
        clsADControlAsistencia objControlAsistencia = new clsADControlAsistencia();

        public DataTable CNMarcarAsistenciaPC(int idUsuario)
        {
            return objControlAsistencia.ADMarcarAsistenciaPC(idUsuario);
        }
    }
}
