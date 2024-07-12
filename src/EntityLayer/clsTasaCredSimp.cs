using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTasaCredSimp
    {
        public int idTasa { get; set; }
        public int idPlazo { get; set; }
        public int nPlazoMin { get; set; }
        public int nPlazoMax { get; set; }
        public int idProducto { get; set; }
        public int idMonto { get; set; }
        public decimal nMontoMin { get; set; }
        public decimal nMontoMax { get; set; }
        public int idMoneda { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public bool lVigente { get; set; }
        public int idAgencia { get; set; }
        public int idTipoPersona { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public bool EnUso { get; set; }
        public int idTipoTasa { get; set; }
        public string cTipoTasa { get; set; }
        public bool lNegociable { get; set; }
        public decimal nTasaNegAprobada { get; set; }
        public decimal nTasaMoratoriaAproba { get; set; }

        public decimal nTasaSeleccionada { get; set; }
        
        public string cNombreCompuesto
        {
            get
            {
                return "TEA: " + nTasaSeleccionada + "% " + cTipoTasa +" - TIM: " + nTasaMoratoria + "%"; ;
            }
        }

        public clsTasaCredSimp()
        {
            idTasa                  = 0;
            idPlazo                 = 0;
            nPlazoMin               = 0;
            nPlazoMax               = 0;
            idProducto              = 0;
            idMonto                 = 0;
            nMontoMin               = 0;
            nMontoMax               = 0;
            idMoneda                = 0;
            nTasaCompensatoria      = 0;
            nTasaMoratoria          = 0;
            lVigente                = false;
            idAgencia               = 0;
            idTipoPersona           = 0;
            nTasaCompensatoriaMax   = 0;
            EnUso                   = false;
            idTipoTasa              = 0;
            lNegociable             = false;
            cTipoTasa               = String.Empty;
            nTasaNegAprobada        = 0;
            nTasaMoratoriaAproba    = 0;
            nTasaSeleccionada       = 0;
        }
    }
}
