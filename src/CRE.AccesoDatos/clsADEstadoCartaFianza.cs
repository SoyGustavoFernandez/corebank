using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADEstadoCartaFianza
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable obtenerEstadosCartaFianza(string cEstado)
        {
            return objEjeSp.EjecSP("CRE_DescripcionEstadoCartaFianza_sp", cEstado);
        }

    }
}
