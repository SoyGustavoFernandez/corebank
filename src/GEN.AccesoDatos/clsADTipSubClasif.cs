using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipSubClasif
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipSubClasificacion(int cTipoFiltro)
        {
            return objEjeSp.EjecSP("Gen_ListaSubClasificacionTipoPer_sp", cTipoFiltro);
        }
    }
}
