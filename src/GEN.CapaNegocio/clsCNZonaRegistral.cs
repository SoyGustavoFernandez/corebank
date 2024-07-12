using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNZonaRegistral
    {

        public clsADZonaRegistral objdocide = new clsADZonaRegistral();
        public DataTable CNListarZonaRegistral(Int32 nidZonaRegistral)
        {
            return objdocide.ADListarZonaRegistral(nidZonaRegistral);
        }
    }
}
