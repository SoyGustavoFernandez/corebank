using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace RCP.AccesoDatos
{
    public class clsADTipoAfectaciones
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoAfectaciones()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoAfectaciones_SP");
        }
    }
}
