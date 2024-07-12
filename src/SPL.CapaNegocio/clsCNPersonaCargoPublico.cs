using EntityLayer;
using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNPersonaCargoPublico
    {
        public clsPersonaCargoPublico BuscarPersonaCP(int nNumDoc) 
        {
            return new clsADPersonaCargoPublico().BuscarPersonaCP(nNumDoc);
        }

    }
}
