using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoCartaFianza
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        /// <summary>
        /// Lista tipos de cartas fianza
        /// </summary>
        /// <returns>Datos tipo carta fianza</returns>
        public DataTable listarTipoCartaFianza()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoCartasFianza_SP");
        }
    }
}
