using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNBuscaSolicitud
    {
        public clsADConSol ObjSolicitud = new clsADConSol();
        public DataTable DatoSolicitud(Int32 CodigoSol)
        {
            return ObjSolicitud.ExtraeDatosSolicitud(CodigoSol);
        }
    }
}
