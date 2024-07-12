using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNTipoFamiliar
    {
        public DataTable ListarTipoFamiliar()
        {
            clsADTipoFamiliar objTiCa = new clsADTipoFamiliar();
            return objTiCa.listarTipoFamiliar();
        }

        public DataTable ListarTipoVinculo()
        {
            clsADTipoFamiliar objTiCa = new clsADTipoFamiliar();
            return objTiCa.ListarTipoVinculo();
        }
    }
}
