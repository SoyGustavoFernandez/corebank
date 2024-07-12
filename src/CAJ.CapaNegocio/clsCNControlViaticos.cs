using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;
using System.Data;

namespace CAJ.CapaNegocio
{
    public class clsCNControlViaticos
    {
        clsADControlViaticos objVia = new clsADControlViaticos();

        //=============================================================
        // Crear metodo para recibir datos en un datatable
        //=============================================================
        public DataTable CNListadoConcepViatico()
        {
            return objVia.ADListadoConcepVia();
        }

        //=============================================================
        // Listado de Finalidad de los Viaticos y ER
        //=============================================================
        public DataTable CNListadoFinalidadViatico()
        {
            return objVia.ADListadoFinalidadVia();
        }

        //=============================================================
        //--Retorna Monto de Viaticos de Acuerdo al Ubigeo
        //=============================================================
        public DataTable CNRetornaMontoVia(int idUbigeo)
        {
            return objVia.ADRetornaMontoVia(idUbigeo);
        }

    }
}
