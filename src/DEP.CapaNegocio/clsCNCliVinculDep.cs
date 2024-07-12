using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEP.AccesoDatos;
using System.Data;

namespace DEP.CapaNegocio
{
    public class clsCNCliVinculDep
    {
        public clsADCliVinculDep objTipDireccion = new clsADCliVinculDep();
        public DataTable ListaTipVincDep()
        {
            return objTipDireccion.ListaTipVincDep();
        }

        public DataTable ValidaIntervinienteJur(int idCliJuridica, int idCliRepres)
        {
            return objTipDireccion.ValidaIntervinienteJur(idCliJuridica, idCliRepres);
        }
    }
}
