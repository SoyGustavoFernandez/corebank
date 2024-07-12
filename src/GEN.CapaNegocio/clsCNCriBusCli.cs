using System;
using System.Linq;
using GEN.AccesoDatos;
using System.Data;


namespace GEN.CapaNegocio
{
    public class clsCNCriBusCli
    {
        clsCriBusCli objCriBus = new clsCriBusCli();

        // Crear Método para recibir los datos de la capa de Datos
        public DataTable ListarCriBusCli()
        {
            var dt = objCriBus.listarCriBusCliXML();

            DataTable dtCribus = dt.Clone();

            //(from item in dt.AsEnumerable()
            // orderby (int)item["idCriBusCli"] descending
            // select item).CopyToDataTable(dtCribus, LoadOption.OverwriteChanges);


            (from item in dt.AsEnumerable()
             orderby (string)item["cCreterioCli"] ascending
             select item).CopyToDataTable(dtCribus, LoadOption.OverwriteChanges);

            return dtCribus;
        }
 
    }
}
