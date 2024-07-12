using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipClasif
    {
        clsADTipClasif objTipClasif = new clsADTipClasif();

        public DataTable ListaTipClasificacion(int cTipoFiltro)
        {
            return objTipClasif.ListaTipClasificacion(cTipoFiltro);
        }
    }

}
