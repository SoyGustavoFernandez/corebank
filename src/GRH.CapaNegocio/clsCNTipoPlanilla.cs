using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNTipoPlanilla
    {
        clsADTipoPlanilla objTipoPlanilla = new clsADTipoPlanilla();

        public DataTable CNListarTipoPlanillaRelacionLab(int idTipoRelLab)
        {
            return objTipoPlanilla.ADListarTipoPlanillaRelacionLab(idTipoRelLab);
        }

        public DataTable CNListarTipoPlanillaProvisionRelacionLab(int idTipoRelLab)
        {
            return objTipoPlanilla.ADListarTipoPlanillaProvisionRelacionLab(idTipoRelLab);
        }

        public DataTable CNListarTipoPlanillaAdelantoRelacionLab(int idTipoRelLab)
        {
            return objTipoPlanilla.ADListarTipoPlanillaAdelantoRelacionLab(idTipoRelLab);
        }
    }
}
