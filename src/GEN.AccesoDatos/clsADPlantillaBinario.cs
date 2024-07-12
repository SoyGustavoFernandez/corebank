using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADPlantillaBinario
    {
        private clsGENEjeSP ObjEjesp = new clsGENEjeSP();

        public DataTable obtenerPlantilla(string cNombrePlantilla)
        {
            return this.ObjEjesp.EjecSP("GEN_ObtenerPlantillaBinario_SP", cNombrePlantilla);
        }

        public DataTable registrarPlantila(string cNombrePlantilla,  byte[] bPlantillaBimario, int idExtencion, bool lVigente)
        {
            return this.ObjEjesp.EjecSP("GEN_RegistrarPlantillaBinario_SP", cNombrePlantilla, bPlantillaBimario, idExtencion, lVigente);
        }
    }
}
