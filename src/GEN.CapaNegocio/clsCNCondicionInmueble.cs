using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNCondicionInmueble
    {
        clsADCondicionInmueble condiinmueble = new clsADCondicionInmueble();

        /// <summary>
        /// retorna el listado de condiciones de inmueble
        /// </summary>
        /// <returns></returns>
        public clslisCondicionInmueble listarCondicionInmueble()
        {
            //return condiinmueble.listarCondicionInmueble();
            return condiinmueble.listarCondicionInmuebleXML();
        }
    }
}
