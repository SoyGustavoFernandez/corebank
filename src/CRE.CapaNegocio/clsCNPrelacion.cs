using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNPrelacion
    {
        clsADPrelacion objprelacion = new clsADPrelacion();
        public void insertarOrdenPrelacion(clsLisPrelacion listaconceptos, int idKardex)
        {
            objprelacion.insertarOrdenPrelacion(listaconceptos, idKardex);
        }
    }
}
