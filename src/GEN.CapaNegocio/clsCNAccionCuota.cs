using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNAccionCuota
    {
        clsADAccionCuota adAccionCuota = new clsADAccionCuota();

        public DataTable listarTipoAccionCuota()
        {
            return adAccionCuota.listarTipoAccionCuota();
        }
    }
}
