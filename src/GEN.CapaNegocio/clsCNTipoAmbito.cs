using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoAmbito
    {
        clsADTipoAmbito objlistaTipoAmbito = new clsADTipoAmbito();

        public DataTable CNLisTipoAmbito()
        {
            return objlistaTipoAmbito.ADLisTipoAmbito();
        }
    }
}
