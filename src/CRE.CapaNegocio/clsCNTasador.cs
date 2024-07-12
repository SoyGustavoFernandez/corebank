using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNTasador
    {
        clsADTasador tasador = new clsADTasador();

        /// <summary>
        /// retorna el listado de tasadores vigentes
        /// </summary>
        /// <returns>coleccion de tasadores</returns>
        public List<clsTasador> listarTasador()
        {
            return tasador.listarTasador();
        }

        public clsDBResp CNGuardarTasador(clsTasador objTasador)
        {
            return tasador.ADGuardarTasador(objTasador);
        }
    }
}
