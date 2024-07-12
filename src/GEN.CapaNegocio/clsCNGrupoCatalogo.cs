using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNGrupoCatalogo
    {
        clsADGrupoCatalogo clsGrupoCatalogo = new clsADGrupoCatalogo();
        public DataTable CNListaGrupoCatalogo(int idPadreGrupo, int idTipoBien, bool lTodos = false)
        {
            return clsGrupoCatalogo.ADListaGrupoCatalogo(idPadreGrupo, idTipoBien, lTodos);
        }
    }
}
