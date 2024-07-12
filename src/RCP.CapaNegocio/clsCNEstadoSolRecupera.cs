using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNEstadoSolRecupera
    {
        clsADEstadoSolRecupera estadosolrecupera = new clsADEstadoSolRecupera();

        public DataTable ListarEstadoSolRecupera()
        { 
            //return estadosolrecupera.ListarEstadoRecupera();
            var dt = estadosolrecupera.ListarEstadoSolRecuperaXml();

            DataTable dtEstadoSolRecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoSolRecupera, LoadOption.OverwriteChanges);

            return dtEstadoSolRecupera;
        }

        public DataTable ListarEstadoSolRecuperaid(int idEstadoSolRec)
        {
            return estadosolrecupera.ListarEstadoSolRecuperaid( idEstadoSolRec);
        }

        public DataTable InsertarEstadoSolRecupera(string cEstadoSolRec, bool lVigente)
        {
            return estadosolrecupera.InsertarEstadoSolRecupera( cEstadoSolRec, lVigente);
        }

        public DataTable ActualizarEstadoSolRecupera(string cEstadoSolRec, bool lVigente, int idEstadoSolRec)
        {
            return estadosolrecupera.ActualizarEstadoSolRecupera( cEstadoSolRec, lVigente, idEstadoSolRec);
        }

        public DataTable EliminarEstadoSolRecupera(int idEstadoSolRec)
        {
            return estadosolrecupera.EliminarEstadoSolRecupera( idEstadoSolRec);
        }
    }
}
