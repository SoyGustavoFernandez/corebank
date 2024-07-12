using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADConSol
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ExtraeDatosSolicitud(Int32 idsolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatoSolicitudxIDSolicitud_sp", idsolicitud);
        }

    }
}
