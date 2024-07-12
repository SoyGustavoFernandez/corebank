using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNProcesoRecupera
    {
        clsADProcesoRecupera procesorecupera = new clsADProcesoRecupera();

        public DataTable ListarProcesoRecupera() 
        {
            //return procesorecupera.ListarProcesoRecupera();
            var dt = procesorecupera.ListarProcesoRecuperaXml();

            DataTable dtprocesorecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtprocesorecupera, LoadOption.OverwriteChanges);

            return dtprocesorecupera;
        }

        public DataTable InsertarProcesoRecupera(string cProcesoRecupera, bool lVigente)
        {
            return procesorecupera.InsertarProcesoRecupera( cProcesoRecupera, lVigente);
        }

        public DataTable ActualizarProcesoRecupera(string cProcesoRecupera, bool lVigente, int idProcesoRecupera)
        {
            return procesorecupera.ActualizarProcesoRecupera( cProcesoRecupera, lVigente, idProcesoRecupera);
        }

        public DataTable EliminarProcesoRecupera(int idProcesoRecupera)
        {
            return procesorecupera.EliminarProcesoRecupera( idProcesoRecupera);
        }
    }
}
