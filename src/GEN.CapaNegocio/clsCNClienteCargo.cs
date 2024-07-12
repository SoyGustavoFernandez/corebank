using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNClienteCargo
    {
        clsADClienteCargo objClientePago = new clsADClienteCargo();
        public DataTable CNListaClienteCargos()
        {
            return objClientePago.ADListaClienteCargoXML();
        }
        public DataTable CNListaClienteCargosBus(string cCargo)
        {
            return objClientePago.ADListaClienteCargoBus(cCargo);
        }
    }
}
