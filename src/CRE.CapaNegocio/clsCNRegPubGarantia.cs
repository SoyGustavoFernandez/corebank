using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNRegPubGarantia
    {
        private clsADRegPubGarantia regpubgar = new clsADRegPubGarantia();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRegPub"></param>
        public void insertaactRegPubGarantia(clsRegPubGarantia objRegPub)
        {
            regpubgar.insertaactRegPubGarantia(objRegPub);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsRegPubGarantia retornadatRegPubGar(int idGarantia)
        {
            return regpubgar.retornadatRegPubGar(idGarantia);
        }
           
    }
}
