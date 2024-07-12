using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public class clsCNConsejo
    {
        clsADConsejo adconsejo = new clsADConsejo();

        public DataTable ListarConsejo()
        {
            return adconsejo.ListarConsejo();
        }

        public DataTable ListarConsejoidConsejo(int idConsejo)
        {
            return adconsejo.ListarConsejoidConsejo(idConsejo);
        }

        public DataTable InsertarConsejo(string cConsejo, int idTipoConsejo, bool lVigente, string xmlIntegrante)
        {
            return adconsejo.InsertarConsejo(cConsejo, idTipoConsejo, lVigente, xmlIntegrante);
        }

        public DataTable ActualizarConsejo(string cConsejo, int idTipoConsejo, bool lVigente, int idConsejo, string xmlIntegrante)
        {
            return adconsejo.ActualizarConsejo(cConsejo, idTipoConsejo, lVigente, idConsejo, xmlIntegrante);
        }
    }
}
