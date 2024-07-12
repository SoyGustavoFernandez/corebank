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
    public class clsADProcesoRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarProcesoRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarProcesoRecupera_SP");
        }

        public DataTable InsertarProcesoRecupera(string cProcesoRecupera, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarProcesoRecupera_SP", cProcesoRecupera, lVigente);
        }

        public DataTable ActualizarProcesoRecupera(string cProcesoRecupera, bool lVigente, int idProcesoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarProcesoRecupera_SP", cProcesoRecupera, lVigente, idProcesoRecupera);
        }

        public DataTable EliminarProcesoRecupera(int idProcesoRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarProcesoRecupera_SP",idProcesoRecupera);
        }

        public DataTable ListarProcesoRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinProcesoRecupera");
        }
    }
}
