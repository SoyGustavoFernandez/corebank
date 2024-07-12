using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEstadoCartaFianza
    {
        clsADEstadoCartaFianza adEstadoCartaFianza = new clsADEstadoCartaFianza();

        public DataTable obtenerEstadosCartaFianza(string cEstado)
        {
            return adEstadoCartaFianza.obtenerEstadosCartaFianza(cEstado);
        }
    }
}
