using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{    
    public class clsCNTipoCredito
    {
        clsADTipoCredito objTipoCredito = new clsADTipoCredito();

        public DataTable listarTipoCredito()
        {
            DataTable dtTipoCredito = objTipoCredito.listarTipoCredito();
            return dtTipoCredito;
        }
    }
}
