using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace LOG.AccesoDatos
{
    public class clsADTipoDocProAdqui
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoDocProAdqui()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoDocProAdqui_SP");
        }

        public DataTable ADInsertarTipoDocProAdqui(string cTipoDocProAdqui)
        {
            return objEjeSp.EjecSP("LOG_InsertarTipoDocProAdqui_SP", cTipoDocProAdqui);
        }

        public DataTable ADActualizarTipoDocProAdqui(int idTipoDocProAdqui, string cTipoDocProAdqui, bool lVigente)
        {
            return objEjeSp.EjecSP("LOG_ActualizarTipoDocProAdqui_SP", idTipoDocProAdqui, cTipoDocProAdqui, lVigente);
        }
    }
}
