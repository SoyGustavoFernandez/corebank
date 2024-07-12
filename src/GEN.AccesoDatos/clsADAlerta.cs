using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADAlerta
    {
        public DataTable ListarAlertas(int idUsuario, DateTime dFechaSistema)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarAlertasPendientes_sp", idUsuario, dFechaSistema);
        }
    }
}
