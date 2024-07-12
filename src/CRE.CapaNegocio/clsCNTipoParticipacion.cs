using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNTipoParticipacion
    {
        public clsADTipoParticipacion objCNTipParticip = new clsADTipoParticipacion();
        public DataTable CNLstTipoParticip()
        {
            return objCNTipParticip.ADLstTipoParticip();
        }
    }
}
