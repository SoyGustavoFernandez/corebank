using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoTasaCredito
    {
        public clsADTipoTasaCredito adTipoTasaCredito = new clsADTipoTasaCredito();

        /// <summary>
        /// Lista de tipos de tasas de creditos
        /// </summary>
        /// <returns>Datos Tipos de tasas de creditos</returns>
        public DataTable listarTipoTasaCredito(int idModulo)
        {
            return adTipoTasaCredito.ADListarTipoTasaCredito(idModulo);
        }
    }
}
