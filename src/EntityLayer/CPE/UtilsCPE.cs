using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.CPE
{
    public class UtilsCPE
    {

    }

    public enum EstadoProcesoCPEEnum
    {
        REGISTRADO = 1,
        PROCESADO = 2,
        NUMERADO = 3,
        ENARCHIVO = 4,
        ENVIOPARCIAL = 5,
        FINALIZADO = 6,
        ANULADO = 7,
    }
}
