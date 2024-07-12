using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoTasa
    {
        clsADTipoTasa objTipoTasa = new clsADTipoTasa();
        public DataTable LisTipTasa()
        {
            return objTipoTasa.LisTipoTasa();
        }
    }
}
