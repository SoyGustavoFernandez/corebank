using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsRetornaNumSolicitud
    {
        public clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADRetornaNumSolicitud(int nValBusqueda, string cTipoBusqueda, string cEstado)
        {
            return ObjEjeSp.EjecSP("Cre_RetornaNumSolicitud_sp",nValBusqueda, cTipoBusqueda, cEstado);
        }
    }
}
