using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADConvenios
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public DataTable ADListaConveniosXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinConvenio");
        }
        public DataTable ADClientesxPagarConvenio(DateTime dFechaProc, int idConvenio)
        {
            return new clsGENEjeSP().EjecSP("CRE_ListaParaDctoPlanilla_SP", dFechaProc, idConvenio);
        }
    }
}
