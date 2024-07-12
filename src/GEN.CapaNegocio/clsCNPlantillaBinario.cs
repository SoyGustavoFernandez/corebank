using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNPlantillaBinario
    {
        private clsADPlantillaBinario objADPlantillaBinario = new clsADPlantillaBinario();

        public DataTable obtenerPlantilla(string cNombrePlantilla)
        {
            return this.objADPlantillaBinario.obtenerPlantilla(cNombrePlantilla);
        }

        public DataTable registrarPlantilla(string cNombrePlantilla,  byte[] bPlantillaBimario, int idExtencion, bool lVigente)
        {
            return this.objADPlantillaBinario.registrarPlantila(cNombrePlantilla, bPlantillaBimario, idExtencion, lVigente);
        }
    }
}
