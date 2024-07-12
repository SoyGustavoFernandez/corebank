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
    public class clsADEstadoRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEstadoRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarEstadoRecupera_SP" );
        }
        public DataTable ListarEstadoRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoRecupera");
        }

        public DataTable InsertarEstadoRecupera(string cEstadoRecupera, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarEstadoRecupera_SP", cEstadoRecupera, lVigente);
        }

        public DataTable ActualizarEstadoRecupera(string cEstadoRecupera, bool lVigente, int idEstadoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarEstadoRecupera_SP", cEstadoRecupera, lVigente, idEstadoRecupera);
        }

        public DataTable EliminarEstadoRecupera(int idEstadoRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarEstadoRecupera_SP",idEstadoRecupera);
        }
    }
}
