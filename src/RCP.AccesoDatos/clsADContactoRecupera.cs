using GEN.AccesoDatos;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADContactoRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarContactoRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarContactoRecupera_SP");
        }

        public DataTable ListarContactoRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinContactoRecupera");
        }

        public DataTable InsertarContactoRecupera(string cContactoRecupera, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarContactoRecupera_SP", cContactoRecupera, lVigente);
        }

        public DataTable ActualizarContactoRecupera(string cContactoRecupera, bool lVigente, int idContactoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarContactoRecupera_SP", cContactoRecupera, lVigente, idContactoRecupera);
        }

        public DataTable EliminarContactoRecupera(int idContactoRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarContactoRecupera_SP", idContactoRecupera);
        }

       
    }
}
