using EntityLayer;
using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNRegistroOperacion
    {
        clsADRegistroOperacion adregistroope = new clsADRegistroOperacion();
        public void insertarRegOpeDetalle(clsRegistroOperacion regope)
        {
            adregistroope.insertarRegistroOperaciones(regope);
        }

        public clsRegistroOperacion DevolverRegOpe(int idkardex)
        {
            return adregistroope.DevolverRegOpe(idkardex);
        }

        public DataTable DevolverRegOpeDataTable(int idkardex)
        {
            return adregistroope.DevolverRegOpeDataTable(idkardex);
        }


        public void ActualizarRegOpe(clsRegistroOperacion regope)
        {
            adregistroope.actualizarReOpPe(regope);
        }

        public bool ExisteRegistro(int idKardex)
        {
            return adregistroope.ExisteRegistro(idKardex);
        }

        public DataTable CNListarSplaftDetNotaPedido()
        {
            return adregistroope.ADListarSplaftDetNotaPedido();
        }
    }
}
