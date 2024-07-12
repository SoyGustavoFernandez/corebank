using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNEstadoConservacion
    {
        clsADEstadoConservacion objestado = new clsADEstadoConservacion();
        clslisEstadoConservacion lista = new clslisEstadoConservacion();

        /// <summary>
        /// lista todos los estados de conservacion de los registros en la base de datos
        /// </summary>
        /// <returns></returns>
        public clslisEstadoConservacion listarTodos()
        {
            return objestado.listarEstadosConservacion();
        }

        /// <summary>
        /// solo retorna los registros activos
        /// </summary>
        /// <returns></returns>
        public clslisEstadoConservacion listarActivos()
        {
            var listafiltro = from item in objestado.listarEstadosConservacion()
                              where item.idEstado == 1
                              select item;
            lista.Clear();
            lista.AddRange(listafiltro);
            return lista;
        }
    }
}
