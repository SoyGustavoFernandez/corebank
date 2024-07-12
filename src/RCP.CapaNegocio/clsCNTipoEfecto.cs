using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNTipoEfecto
    {
        clsADTipoEfecto tipoefecto = new clsADTipoEfecto();

        public DataTable ListarTipoEfecto()
        {
            //return tipoefecto.ListarTipoEfecto(); 
            var dt = tipoefecto.ListarTipoEfectoXml();

            DataTable dttipoefecto = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dttipoefecto, LoadOption.OverwriteChanges);

            return dttipoefecto;
        }

        public DataTable InsertarTipoEfecto(string cTipoEfecto, bool lVigente)
        {
            return tipoefecto.InsertarTipoEfecto( cTipoEfecto, lVigente);
        }

        public DataTable ActualizarTipoEfecto(string cTipoEfecto, bool lVigente, int idTipoEfecto)
        {
            return tipoefecto.ActualizarTipoEfecto( cTipoEfecto, lVigente, idTipoEfecto);
        }

        public DataTable EliminarTipoEfecto(int idTipoEfecto)
        {
            return tipoefecto.EliminarTipoEfecto( idTipoEfecto);
        }
    }
}
