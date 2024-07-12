using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNSegmentoSocio
    {
        clsADSegmentoSocio ObjSegmento = new clsADSegmentoSocio();
        public DataTable CNListaSegmentoSocio(int idTipoPersona)
        {
            return ObjSegmento.ADListaSegmentoSocio(idTipoPersona);
        }
    }
}
