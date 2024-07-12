using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEP.AccesoDatos;
using System.Data;

namespace DEP.CapaNegocio
{
    public class clsCNRechazoSolApe
    {
        clsADRechazoSolApe objDeposito = new clsADRechazoSolApe();
        //Lista las solicitudes de apertura pendientes de aproación
        public DataTable CNListSolApe(int nIdAgencia)
        {
            return objDeposito.ADListSolApe(nIdAgencia);
        }
        //Graba el rechazo de las solicitudes de apertura
        public DataTable CNGrabaRechazoSolApe(string xmlCuentaDen, int idUsuario, DateTime dFechaAtencion)
        {
            return objDeposito.ADGrabaRechazoSolApe(xmlCuentaDen, idUsuario, dFechaAtencion);
        }
    }
}
