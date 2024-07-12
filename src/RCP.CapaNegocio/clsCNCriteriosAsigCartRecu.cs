using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNCriteriosAsigCartRecu
    {
        clsADCriteriosAsigCartRecu adCriteriosAsigCartRecu = new clsADCriteriosAsigCartRecu();
        public DataTable ListarCriteriosAsigCartRecu(int idUsuario)
        {
            return adCriteriosAsigCartRecu.ListarCriteriosAsigCartRecu(idUsuario);
        }

        public DataTable registrarCriteriosAsigCartRecu(int idUsuario, int idTipo, int valor)
        {
            return adCriteriosAsigCartRecu.registrarCriteriosAsigCartRecu(idUsuario, idTipo, valor);
        }

        public DataTable actualizarCriteriosAsigCartRecu(int idSeleccionado, bool lVigente)
        {
            return adCriteriosAsigCartRecu.actualizarCriteriosAsigCartRecu(idSeleccionado, lVigente);
        }
    }
}
