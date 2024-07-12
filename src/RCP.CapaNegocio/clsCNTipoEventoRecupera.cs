using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNTipoEventoRecupera
    {
        clsADTipoEventoRecupera tipoeventorecupera = new clsADTipoEventoRecupera();

        public DataTable ListarTipoEventoRecupera()
        {
            //return tipoeventorecupera.ListarTipoEventoRecupera();
            var dt = tipoeventorecupera.ListarTipoEventoRecuperaXml();

            DataTable dttipoeventorecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dttipoeventorecupera, LoadOption.OverwriteChanges);

            return dttipoeventorecupera;
        }

        public DataTable InsertarTipoEventoRecupera(string cTipoEventoRecupera, bool lVigente)
        {
            return tipoeventorecupera.InsertarTipoEventoRecupera(cTipoEventoRecupera, lVigente);
        }

        public DataTable ActualizarTipoEventoRecupera(string cTipoEventoRecupera, bool lVigente, int idTipoEventoRecupera)
        {
            return tipoeventorecupera.ActualizarTipoEventoRecupera( cTipoEventoRecupera, lVigente, idTipoEventoRecupera);
        }

        public DataTable EliminarTipoEventoRecupera(int idTipoEventoRecupera)
        {
            return tipoeventorecupera.EliminarTipoEventoRecupera( idTipoEventoRecupera);
        }
    }
}
