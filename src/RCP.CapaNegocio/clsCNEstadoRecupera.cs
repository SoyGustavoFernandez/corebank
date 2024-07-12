using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNEstadoRecupera
    {
        clsADEstadoRecupera estadorecupera = new clsADEstadoRecupera();

        public DataTable ListarEstadoRecupera()
        {
            //return estadorecupera.ListarEstadoRecupera(); 
            var dt = estadorecupera.ListarEstadoRecuperaXml();

            DataTable dtEstadoRecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoRecupera, LoadOption.OverwriteChanges);

            return dtEstadoRecupera;
        }

        public DataTable InsertarEstadoRecupera(string cEstadoRecupera, bool lVigente)
        {
            return estadorecupera.InsertarEstadoRecupera( cEstadoRecupera, lVigente);
        }

        public DataTable ActualizarEstadoRecupera(string cEstadoRecupera, bool lVigente, int idEstadoRecupera)
        {
            return estadorecupera.ActualizarEstadoRecupera( cEstadoRecupera, lVigente, idEstadoRecupera);
        }

        public DataTable EliminarEstadoRecupera(int idEstadoRecupera)
        {
            return estadorecupera.EliminarEstadoRecupera( idEstadoRecupera);
        }
    }
}
