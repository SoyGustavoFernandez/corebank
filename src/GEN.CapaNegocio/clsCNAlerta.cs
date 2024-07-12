using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNAlerta
    {
        clsADAlerta adAlerta = new clsADAlerta();

        public DataTable ListarAlertas(int idUsuario, DateTime dFechaSistema)
        {
            return adAlerta.ListarAlertas(idUsuario, dFechaSistema);
        }
    }
}
