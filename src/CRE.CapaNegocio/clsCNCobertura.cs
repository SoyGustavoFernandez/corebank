using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNCobertura
    {
        clsADCobertura objcobertura = new clsADCobertura();
        clslisCobertura lista = new clslisCobertura();

        public clslisCobertura listarTodas()
        {
           // return objcobertura.listarCoberturas();
            return objcobertura.listarCoberturasXML();
        }

        

        public clslisCobertura listarActivas()
        {
            //var listafiltro = from item in objcobertura.listarCoberturas()
            //                  where item.idEstado == 1
            //                  select item;

            var listafiltro = from item in objcobertura.listarCoberturasXML()
                              where item.idEstado == 1
                              select item;
            lista.Clear();
            lista.AddRange(listafiltro);
            return lista;
        }
    }
}
