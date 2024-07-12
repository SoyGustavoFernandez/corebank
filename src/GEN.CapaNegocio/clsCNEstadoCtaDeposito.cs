using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;


namespace DEP.CapaNegocio
{
    public class clsCNEstadoCtaDeposito
    {
        clsADEstadoCtaDeposito ListaEstadoDep = new clsADEstadoCtaDeposito();
        public DataTable ListarEstadoDep()
        {
           //return ListaEstadoDep.ListarEstadoDep();
            var dt = ListaEstadoDep.ListarEstadoDepXml();

            DataTable dtEstadoCtaDeposito = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoCtaDeposito, LoadOption.OverwriteChanges);

            return dtEstadoCtaDeposito;
             
        }
    }

}
