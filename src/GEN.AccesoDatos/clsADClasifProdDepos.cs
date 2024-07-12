using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace GEN.AccesoDatos
{
    public class clsADClasifProdDepos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ListarClasifProd()
        {
            return objEjeSp.EjecSP("Gen_ListaClasifProdDep_sp");
        } 

        public DataTable ListarClasifProdXml()
        {
            return cnadtabla.retonarTablaXml("SI_FINClasifProdDeposito");
        } 

    }
}
