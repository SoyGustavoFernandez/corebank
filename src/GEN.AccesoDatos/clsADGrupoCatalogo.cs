using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADGrupoCatalogo
    {
        clsGENEjeSP obj = new clsGENEjeSP();
        public DataTable ADListaGrupoCatalogo(int idPadreGrupo, int idTipoBien, bool lTodos)
        {
            return obj.EjecSP("LOG_ListaGruposCatalogo_sp", idPadreGrupo, idTipoBien, lTodos);
        }
    }
}
