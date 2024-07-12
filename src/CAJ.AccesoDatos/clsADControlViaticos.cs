using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CAJ.AccesoDatos
{
    public class clsADControlViaticos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=============================================================
        //--Retorna Conceptos de Recibos por Viaticos y ER
        //=============================================================
        public DataTable ADListadoConcepVia()
        {
            return objEjeSp.EjecSP("CAJ_ListaConcepViaticos_Sp");
        }

        //=============================================================
        //--Listado de Finalidad para Viaticos y ER
        //=============================================================
        public DataTable ADListadoFinalidadVia()
        {
            return objEjeSp.EjecSP("CAJ_ListadoFinalidadViaER_SP");
        }

        //=============================================================
        //--Retorna Monto de Viaticos de Acuerdo al Ubigeo
        //=============================================================
        public DataTable ADRetornaMontoVia(int idUbigeo)
        {
            return objEjeSp.EjecSP("CAJ_RetornaMontoVia_Sp", idUbigeo);
        }

    }
}
