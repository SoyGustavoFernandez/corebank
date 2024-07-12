using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace SER.AccesoDatos
{
    public class clsADMensajeTexto
    {
        clsGENEjeSP obj;

        public clsADMensajeTexto()
        {
            this.obj = new clsGENEjeSP();
        }

        public DataTable ADListarTipoMensaje()
        {
            return this.obj.EjecSP("SER_ListarTipoMensaje_SP");
        }

        public DataTable ADGuardarEnvioMensajeTexto(string xmlMensaje)
        {
            return this.obj.EjecSP("SER_GuardarEnvioMensajeTexto_SP", xmlMensaje);
        }
    }
}
