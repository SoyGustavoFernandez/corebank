using GRC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.CapaNegocio
{
    public class clsCNTipoConsejo
    {
        clsADTipoConsejo tipoconsejo = new clsADTipoConsejo();

        public DataTable ListarTipoConsejo()
        {
            return tipoconsejo.ListarTipoConsejo();
        }

        public DataTable InsertarTipoConsejo(string cTipoConsejo, bool lVigente)
        {
            return tipoconsejo.InsertarTipoConsejo( cTipoConsejo, lVigente);
        }

        public DataTable ActualizarTipoConsejo(string cTipoConsejo, bool lVigente, int idTipoConsejo)
        {
            return tipoconsejo.ActualizarTipoConsejo(cTipoConsejo, lVigente, idTipoConsejo);
        }
    }
}
