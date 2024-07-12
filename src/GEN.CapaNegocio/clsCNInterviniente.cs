using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNInterviniente
    {
        public clsADInterviniente CNTipoInterv = new clsADInterviniente();
        public DataTable listarTipoIntervRegCredito()
        {
            return CNTipoInterv.listarTipoIntervRegCredito();
        }

        public DataTable CNListaTipoInterv()
        {
            return CNTipoInterv.ADListaTipoInterv();
        }
        public DataTable CNListaTipoIntervDep()
        {
            return CNTipoInterv.ADListaTipoIntervDep();
        }


        public DataTable ListarIntervinientesCredito(int idCuenta)
        {
            return CNTipoInterv.ListarIntervinientesCredito(idCuenta);
        }
    }
}
