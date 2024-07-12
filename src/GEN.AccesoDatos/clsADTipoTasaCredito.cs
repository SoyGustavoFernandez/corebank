using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoTasaCredito
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        /// <summary>
        /// Metodo ejecuta para traer los datos vigentes de tipo de tasa de credito.
        /// </summary>
        /// <returns>Datos Tipo de tasas vigentes</returns>
        public DataTable ADListarTipoTasaCredito(int idModulo)
        {
            return objEjeSp.EjecSP("SP_GENListarTipoTasasCredito", idModulo);
        }
    }
}
