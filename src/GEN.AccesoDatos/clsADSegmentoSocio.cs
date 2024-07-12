using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADSegmentoSocio
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADListaSegmentoSocio(int idTipoPersona)
        {
            return ObjEjeSp.EjecSP("GEN_ListaSegmentoSocio_sp", idTipoPersona);
        }
    }
}
