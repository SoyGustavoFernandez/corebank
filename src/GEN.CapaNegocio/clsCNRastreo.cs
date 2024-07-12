using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNRastreo
    {
        clsADRastreo adrastreo = new clsADRastreo();

        public void insertarRastreo(clsRastreo objrastreo)
        {
            adrastreo.insertarRastreo(objrastreo);
        }
        public void insertarRastreoPosicionConsolidada(clsRastreo objrastreo)
        {
            adrastreo.insertarRastreoPosicionConsolidada(objrastreo);
        }
    }
}
