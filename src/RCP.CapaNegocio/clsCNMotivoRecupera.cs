using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNMotivoRecupera
    {
        clsADMotivoRecupera motivorecupera = new clsADMotivoRecupera();

        public DataTable ListarMotivoRecupera()
        {
            //return motivorecupera.ListarMotivoRecupera(); 
            var dt = motivorecupera.ListarMotivoRecuperaXml();

            DataTable dtmotivorecupera = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtmotivorecupera, LoadOption.OverwriteChanges);

            return dtmotivorecupera;
        }

        public DataTable InsertarMotivoRecupera(string cMotivoRecupera, bool lVigente)
        {
            return motivorecupera.InsertarMotivoRecupera( cMotivoRecupera, lVigente);
        }


        public DataTable ActualizarMotivoRecupera(string cMotivoRecupera, bool lVigente, int idMotivoRecupera)
        {
            return motivorecupera.ActualizarMotivoRecupera(cMotivoRecupera, lVigente, idMotivoRecupera);
        }

        public DataTable InsertarMotivoRecupera(int idMotivoRecupera)
        {
            return motivorecupera.InsertarMotivoRecupera(idMotivoRecupera);
        }
    }
}
