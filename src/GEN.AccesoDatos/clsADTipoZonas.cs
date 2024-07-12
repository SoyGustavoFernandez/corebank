using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoZonas
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaZonas()
        {
            return objEjeSp.EjecSP("gen_ListaTipoZona_sp");
        }

        public DataTable ListaZonasSector(int idSector)
        {
            return objEjeSp.EjecSP("GEN_ListaTipoZonaSector_SP", idSector);
        }
    }
}
