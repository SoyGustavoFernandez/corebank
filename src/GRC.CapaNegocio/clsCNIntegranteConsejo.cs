using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public class clsCNIntegranteConsejo
    {
        clsADIntegranteConsejo integranteconsejo = new clsADIntegranteConsejo();

        public DataTable ListarIntegranteConsejo()
        {
            return integranteconsejo.ListarIntegranteConsejo();
        }

        public DataTable ListarIntegranteIdConsejo(int idConsejo)
        {
            return integranteconsejo.ListarIntegranteIdConsejo(idConsejo);
        }

        public DataTable ListarIntegranteConsejoidCli(int idCli)
        {
            return integranteconsejo.ListarIntegranteConsejoidCli( idCli);
        }

        public DataTable InsertarIntegranteConsejo(int idConsejo, int idCli, DateTime dFecIni, DateTime dFecfin, int idTipoIntegranteConsejo, bool lVigente)
        {
            return integranteconsejo.InsertarIntegranteConsejo( idConsejo, idCli, dFecIni, dFecfin, idTipoIntegranteConsejo, lVigente);
        }

        public DataTable ActualizarIntegranteConsejo(int idConsejo, int idCli, DateTime dFecIni, DateTime dFecfin, int idTipoIntegranteConsejo, bool lVigente)
        {
            return integranteconsejo.ActualizarIntegranteConsejo(idConsejo, idCli, dFecIni, dFecfin, idTipoIntegranteConsejo, lVigente);
        }
    }
}
