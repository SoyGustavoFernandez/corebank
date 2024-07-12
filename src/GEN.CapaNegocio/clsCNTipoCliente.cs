using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoCliente
    {
        public clsADTipoCliente TipCli = new clsADTipoCliente();

        public DataTable Lista()
        {
            return TipCli.ListaTipoCliente();
        }

        public DataTable ListaPorModulo(int idModulo)
        {
            return TipCli.ListaPorModulo(idModulo);
        }
    }
}
