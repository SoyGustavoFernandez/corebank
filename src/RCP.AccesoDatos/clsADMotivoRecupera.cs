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
    public class clsADMotivoRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarMotivoRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarMotivoRecupera_SP");
        }

        public DataTable InsertarMotivoRecupera(string cMotivoRecupera, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarMotivoRecupera_SP", cMotivoRecupera, lVigente);
        }

        public DataTable ActualizarMotivoRecupera(string cMotivoRecupera, bool lVigente, int idMotivoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarMotivoRecupera_SP", cMotivoRecupera, lVigente, idMotivoRecupera);
        }

        public DataTable InsertarMotivoRecupera( int idMotivoRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarMotivoRecupera_SP", idMotivoRecupera);
        }

        public DataTable ListarMotivoRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinMotivoRecupera");
        }
    }
}
