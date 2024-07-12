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
    public class clsADEstadoSolRecupera
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEstadoSolRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarEstadoSolRecupera_SP");
        }

        public DataTable ListarEstadoSolRecuperaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoSolRecupera");
        }

        public DataTable ListarEstadoSolRecuperaid(int idEstadoSolRec)
        {
            return objEjeSp.EjecSP("RCP_ListarEstadoSolRecuperaidEstadoSolRec_SP", idEstadoSolRec);
        }

        public DataTable InsertarEstadoSolRecupera(string cEstadoSolRec, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarEstadoSolRecupera_SP", cEstadoSolRec, lVigente);
        }

        public DataTable ActualizarEstadoSolRecupera(string cEstadoSolRec, bool lVigente, int idEstadoSolRec)
        {
            return objEjeSp.EjecSP("RCP_ActualizarEstadoSolRecupera_SP", cEstadoSolRec, lVigente, idEstadoSolRec);
        }

        public DataTable EliminarEstadoSolRecupera(int idEstadoSolRec)
        {
            return objEjeSp.EjecSP("RCP_EliminarEstadoSolRecupera_SP",idEstadoSolRec);
        }       
    }
}
