using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADTipoPeriodo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListaTipoPeriodo()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoPeriodo_sp");
        }
        public List<clsPeriodoCredito> listarPeriodoCredito()
        {
            return objEjeSp.LOEjecutar<clsPeriodoCredito>("CRE_ListarPeriodoCredito_SP");
        }
    }
}
