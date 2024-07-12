using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNContactoRecupera
    {
        clsADContactoRecupera contactorecupera = new clsADContactoRecupera();

        public DataTable ListarContactoRecupera()
        {
           // return contactorecupera.ListarContactoRecupera();
            var dt = contactorecupera.ListarContactoRecuperaXml();

            DataTable dtContactoRecupera = dt.Clone();  

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtContactoRecupera, LoadOption.OverwriteChanges);

            return dtContactoRecupera;
        }

        public DataTable InsertarContactoRecupera(string cContactoRecupera, bool lVigente)
        {
            return contactorecupera.InsertarContactoRecupera(cContactoRecupera, lVigente);
        }

        public DataTable ActualizarContactoRecupera(string cContactoRecupera, bool lVigente, int idContactoRecupera)
        {
            return contactorecupera.ActualizarContactoRecupera(cContactoRecupera, lVigente, idContactoRecupera);
        }

        public DataTable EliminarContactoRecupera(int idContactoRecupera)
        {
            return contactorecupera.EliminarContactoRecupera(idContactoRecupera);
        }
    }
}
