using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{   
    public class clsADAccionCuota
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarTipoAccionCuota()
        {
            return objEjeSp.EjecSP("GEN_lisTipoAccionCuota_sp");
        }
    }
}
