using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public  class clsCNTipoIntegranteConsejo
    {
        clsADTipoIntegranteConsejo tipointegrante = new clsADTipoIntegranteConsejo();

        public DataTable ListarTipoIntegranteConsejo()
        {
            return tipointegrante.ListarTipoIntegranteConsejo();
        }

        public DataTable InsertarTipoIntegranteConsejo(int idTipoConsejo, string cTipoIntegranteConsejo, bool lDerechoVoto, bool lVigente)
        {
            return tipointegrante.InsertarTipoIntegranteConsejo(idTipoConsejo, cTipoIntegranteConsejo, lDerechoVoto, lVigente);
        }

        public DataTable ActualizarTipoIntegranteConsejo(int idTipoConsejo, string cTipoIntegranteConsejo, bool lDerechoVoto, bool lVigente, int idTipoIntegranteConsejo)
        {
            return tipointegrante.ActualizarTipoIntegranteConsejo(idTipoConsejo, cTipoIntegranteConsejo, lDerechoVoto, lVigente, idTipoIntegranteConsejo);
        }
    }
}
