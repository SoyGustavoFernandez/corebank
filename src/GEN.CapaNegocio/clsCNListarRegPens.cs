using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListarRegPens
    {
        clsADListarRegPens objListaProv = new clsADListarRegPens();
        public DataTable ListarRegimenPen(int idTipReg)
        {
            return objListaProv.ListarRegimenPen(idTipReg);
        }
    }
}
