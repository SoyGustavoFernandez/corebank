using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNCompaniaSeguro
    {
        clsADCompaniaSeguro objcompania = new clsADCompaniaSeguro();
        clslisCompaniaSeguro lista = new clslisCompaniaSeguro();

        /// <summary>
        /// retorna todas las companias de seguros registradas
        /// </summary>
        /// <returns></returns>
        public clslisCompaniaSeguro listarTodas()
        {
           // return objcompania.listarCompanias();
            return objcompania.listarCompaniasXML();
        }

        /// <summary>
        /// Solo retorna el listado de compania activas
        /// </summary>
        /// <returns></returns>
        public clslisCompaniaSeguro listarActivas()
        {
            //var listafiltro = from item in objcompania.listarCompanias()
            //                  where item.idEstado == 1
            //                  select item;

            var listafiltro = from item in objcompania.listarCompaniasXML()
                              where item.idEstado == 1
                              select item;
            lista.Clear();
            lista.AddRange(listafiltro);
            return lista;
        }

    }
}
