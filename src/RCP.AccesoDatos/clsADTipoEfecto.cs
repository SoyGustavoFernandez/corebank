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
    public class clsADTipoEfecto
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoEfecto()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoEfecto_SP");
        }

        public DataTable InsertarTipoEfecto(string cTipoEfecto, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarTipoEfecto_SP", cTipoEfecto, lVigente);
        }

        public DataTable ActualizarTipoEfecto(string cTipoEfecto, bool lVigente, int idTipoEfecto)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTipoEfecto_SP", cTipoEfecto, lVigente, idTipoEfecto);
        }

        public DataTable EliminarTipoEfecto(int idTipoEfecto)
        {
            return objEjeSp.EjecSP("RCP_EliminarTipoEfecto_SP",idTipoEfecto);
        }

        public DataTable ListarTipoEfectoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoEfecto");
        }
    }
}
