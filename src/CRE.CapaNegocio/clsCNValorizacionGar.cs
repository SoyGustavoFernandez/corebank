using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNValorizacionGar
    {
        clsADValorizacionGar objvalorizaciongar = new clsADValorizacionGar();

        /// <summary>
        /// inserta o actualiza la valorizacion de una garantia
        /// </summary>
        /// <param name="objvaloriza"></param>
        public void insertaactValorizacion(clsValorizacionGar objvaloriza)
        {
            objvalorizaciongar.insertaactValorizacion(objvaloriza);
        }

        /// <summary>
        /// retorna los datos de la valorizacion
        /// </summary>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsValorizacionGar retornaDatValoriza(int idGarantia)
        {
            return objvalorizaciongar.retornaDatValoriza(idGarantia);
        }
    }
}
