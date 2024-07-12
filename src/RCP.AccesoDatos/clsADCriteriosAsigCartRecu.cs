using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADCriteriosAsigCartRecu
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarCriteriosAsigCartRecu(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ListarCriteriosAsigCartRecu_SP", idUsuario);
        }

        public DataTable registrarCriteriosAsigCartRecu(int idUsuario, int idTipo, int valor)
        {
            return objEjeSp.EjecSP("RCP_InsertarCriteriosAsigCartRecu_SP", idUsuario, idTipo, valor);
        }

        public DataTable actualizarCriteriosAsigCartRecu(int idSeleccionado, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_ActualizarCriteriosAsigCartRecu_SP", idSeleccionado, lVigente);
        }
    }
}
