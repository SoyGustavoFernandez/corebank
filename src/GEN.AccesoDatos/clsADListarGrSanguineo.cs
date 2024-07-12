using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper; 

namespace GEN.AccesoDatos
{
    public class clsADListarGrSanguineo
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public DataTable ListarGrupoSanguineo()
        {
            return new clsGENEjeSP().EjecSP("ADM_LisGrupoSanguineo_SP");
        }
        public DataTable ListarGrupoSanguineoXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinGrupoSanguineo");
        }

    }
}
