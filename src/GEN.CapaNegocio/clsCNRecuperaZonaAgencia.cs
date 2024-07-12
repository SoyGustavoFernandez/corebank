using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNRecuperaZonaAgencia
    {
        clsADRecuperaZonaAgencia objListaEstab = new clsADRecuperaZonaAgencia();

        public DataTable CNRecuperaZonaAgencia(int idAge)
        {
            return objListaEstab.ADRecuperaZonaAgencia(idAge);
        }
    }
}

