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
    public class clsADTipoEventoRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoEventoRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoEventoRecupera_SP");
        }

        public DataTable InsertarTipoEventoRecupera(string cTipoEventoRecupera, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarTipoEventoRecupera_SP",cTipoEventoRecupera,  lVigente);
        }

        public DataTable ActualizarTipoEventoRecupera(string cTipoEventoRecupera, bool lVigente, int idTipoEventoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTipoEventoRecupera_SP",cTipoEventoRecupera, lVigente, idTipoEventoRecupera);
        }

        public DataTable EliminarTipoEventoRecupera(int idTipoEventoRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarTipoEventoRecupera_SP", idTipoEventoRecupera);
        }

        public DataTable ListarTipoEventoRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoEventoRecupera");
        }
    }
}
