using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoConstruccion
    {
        clsADTipoConstruccion ObjContruccion = new clsADTipoConstruccion();
        public DataTable CNListaTipoContruccion()
        {
            return ObjContruccion.ADListaTipoConstruccion();
        }

    }
}
