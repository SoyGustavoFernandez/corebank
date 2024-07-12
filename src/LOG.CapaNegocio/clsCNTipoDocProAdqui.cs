using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;

namespace LOG.CapaNegocio
{
    public class clsCNTipoDocProAdqui
    {
        clsADTipoDocProAdqui objTipoDocProAdqui = new clsADTipoDocProAdqui();

        public DataTable CNListarTipoDocProAdqui()
        {
            return objTipoDocProAdqui.ADListarTipoDocProAdqui();
        }

        public DataTable CNInsertarTipoDocProAdqui(string cTipoDocProAdqui)
        {
            return objTipoDocProAdqui.ADInsertarTipoDocProAdqui(cTipoDocProAdqui);
        }

        public DataTable CNActualizarTipoDocProAdqui(int idTipoDocProAdqui, string cTipoDocProAdqui, bool lVigente)
        {
            return objTipoDocProAdqui.ADActualizarTipoDocProAdqui(idTipoDocProAdqui, cTipoDocProAdqui, lVigente);
        }
    }
}
