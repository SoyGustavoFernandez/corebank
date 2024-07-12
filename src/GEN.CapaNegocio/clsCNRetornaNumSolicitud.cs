using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNRetornaNumSolicitud
    {
        clsRetornaNumSolicitud objRetNumSolicitud = new clsRetornaNumSolicitud();
        public DataTable CNRetornaNumSolicitud(int nValBusqueda, string cTipoBusqueda, string cEstado)
        {
            return objRetNumSolicitud.ADRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
        }
        public DataTable CNRetornaNumSolicitudApr(int nValBusqueda, string cTipoBusqueda, string cEstado)
        {
            return objRetNumSolicitud.ADRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
        }
    }
}
