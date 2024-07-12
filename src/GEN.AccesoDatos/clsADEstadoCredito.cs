using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADEstadoCredito
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEstadoCredito(Int32 nEstadoPadre)
        {
            return objEjeSp.EjecSP("CRE_ListaEstadoCre_sp", nEstadoPadre);
        }

        public DataTable ListaEstCredito(Int32 nEstadoPadre)
        {
            return objEjeSp.EjecSP("CRE_ListaEstCredito_sp", nEstadoPadre);
        }        
        
        public DataTable ListarEstadoActual(Int32 nEstadoActual)
        {
            return objEjeSp.EjecSP("CRE_ListaEstadoActualCre_sp", nEstadoActual);
        }
        public DataTable ListarEstadoActualXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstCredito");
        }

        public DataTable ADEstadoBusqueda(string cEstado)
        {
            return objEjeSp.EjecSP("CRE_DescripcionEstado_sp", cEstado);
        }

        public DataTable ADListarEstadoSolCredito(int idEstadoPadre)
        {
            return objEjeSp.EjecSP("CRE_ListEstSolCred_SP", idEstadoPadre);
        }
        
    }
}
