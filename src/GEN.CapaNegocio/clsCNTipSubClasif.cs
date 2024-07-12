using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipSubClasif
    {
        clsADTipSubClasif objTipSubClasif = new clsADTipSubClasif();

        public DataTable ListaTipSubClasificacion(int idTipClasificacion)
        {
            return objTipSubClasif.ListaTipSubClasificacion(idTipClasificacion);
        }
    }
}
