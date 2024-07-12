using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;
namespace DEP.CapaNegocio
{
    public class clsCNTipoCuenta
    {
        clsADTipoCuenta objTipoCuenta = new clsADTipoCuenta();
        public DataTable LisTipoCuenta()
        {
            return objTipoCuenta.LisTipoCuenta();
        }

        public DataTable ListaObjetoAhorro()
        {
            return objTipoCuenta.LisObjetoAhorro();
        }

        public DataTable ListaOrigenFondos()
        {
            return objTipoCuenta.LisOrigenFondos();
        }

        public DataTable ListaEnvioEstCta()
        {
            return objTipoCuenta.ListaEnvioEstCta();
        }
    }
}
