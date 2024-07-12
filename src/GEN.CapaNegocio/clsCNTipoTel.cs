using EntityLayer;
using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoTel
    {
        clsADTipoTel adTipotel = new clsADTipoTel();        

        public DataTable ListarTipos()
        {
            return adTipotel.ListarTipoTel();
        }

       
    }
}
