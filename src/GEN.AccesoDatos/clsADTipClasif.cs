using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipClasif
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipClasificacion(int cTipoFiltro)
        {
            return objEjeSp.EjecSP("Gen_ListaClasificacionTipoPer_sp", cTipoFiltro);
        }
    }
}
