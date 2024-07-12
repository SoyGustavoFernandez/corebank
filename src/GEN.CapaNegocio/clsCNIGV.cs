using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{

    public class clsCNIGV
    {
        #region atributos
        clsADIGV oIGV = new clsADIGV();

        #endregion


        #region métodos
        public DataTable obtenerListaIGV()
        {
            return oIGV.listarIGV();
        }
        #endregion
    }
}
