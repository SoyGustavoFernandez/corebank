using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Validaciones.Interface;
using EntityLayer;

namespace WCF.CoreBank.Validaciones
{
    public class clsObjetoValidar : IObjetoValidado
    {
        private object obj;


        public void setObjeto<T>(T _obj)
        {
            this.obj = _obj;
        }

        public object getObjeto()
        {
            return this.obj;
        }
    }
}