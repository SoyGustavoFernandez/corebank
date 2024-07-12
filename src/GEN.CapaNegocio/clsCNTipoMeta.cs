using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoMeta
    {
        public clsADTipoMeta TipoMeta = new clsADTipoMeta();
        public DataTable CNListaTipoMeta(int idTipoIncentivo)
        {
            return TipoMeta.ADListaTipoMeta(idTipoIncentivo);
        }
    }
}
