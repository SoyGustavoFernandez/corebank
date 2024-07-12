using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNDestinoCredito
    {
        public clsADDestinoCredito DestinoCredito = new clsADDestinoCredito();
        public bool lTasa = false; 
        public DataTable listaDestinoCredito(int idProducto)
        {
            return DestinoCredito.ListaDestinoCredito(idProducto);
        }
        public DataTable ListaDestino()
        {
            //return DestinoCredito.ListaDestinoCredito();
            var dt = DestinoCredito.ListaDestinoCreditoXml();

            DataTable dtDestinoCredito = dt.Clone();

            if (lTasa == true) 
            {
                (from item in dt.AsEnumerable()
                 where (bool)item["lVigente"] == true 
                 orderby (string)item["cDestino"]
                 select item).CopyToDataTable(dtDestinoCredito, LoadOption.OverwriteChanges);
            }
            else 
            {
                (from item in dt.AsEnumerable()
                 where (bool)item["lVigente"] == true &&
                 (bool)item["lCasoEspecial"] == false
                 orderby (string)item["cDestino"]
                 select item).CopyToDataTable(dtDestinoCredito, LoadOption.OverwriteChanges);
            }

            return dtDestinoCredito;
            
        }

        public DataTable ListaDestinoEspeciales()
        {
            var dt = DestinoCredito.ListaDestinoCreditoXml();

            DataTable dtDestinoCredito = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true &
                    (bool)item["lCasoEspecial"] == true
             orderby (string)item["cDestino"]
             select item).CopyToDataTable(dtDestinoCredito, LoadOption.OverwriteChanges);

            return dtDestinoCredito;
        }
    }
}
