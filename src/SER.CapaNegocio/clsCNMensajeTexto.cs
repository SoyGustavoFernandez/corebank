using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SER.AccesoDatos;
using System.Data;

namespace SER.CapaNegocio
{
    public class clsCNMensajeTexto
    {
        clsADMensajeTexto obj;

        public clsCNMensajeTexto()
        {
            this.obj = new clsADMensajeTexto();
        }

        public DataTable CNListarTipoMensaje()
        {
            return this.obj.ADListarTipoMensaje();
        }

        public DataTable CNGuardarEnvioMensajeTexto(string xmlMensaje)
        {
            return this.obj.ADGuardarEnvioMensajeTexto(xmlMensaje);
        }
    }
}
