using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace GEN.AccesoDatos
{
    public class clsEstadoActual
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEstadoActual()
        {
            return objEjeSp.EjecSP("Gen_ListaEstadoCredito_sp");
        }

        public DataTable ListarEstadoActualXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstCredito");
        }
        public DataTable ListarEstadoCuentaCli()
        {
            return objEjeSp.EjecSP("RPT_EstadoCuentasCliente_SP");
        }
    }
}
