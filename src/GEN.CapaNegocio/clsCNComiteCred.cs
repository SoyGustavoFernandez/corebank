using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNComiteCred
    {

        public DataTable CNLstResultComiteCred()
        {
            return new clsADComiteCred().ADLstResultComiteCred();
        }

        public DataTable CNLstEstadoEvalCredNivelSuperior()
        {
            return new clsADComiteCred().ADLstEstadoEvalCredNivelSuperior();
        }

        public DataTable CNLstEstComiteCred()
        {
            return new clsADComiteCred().ADLstEstComiteCred();
        }

    }
}
