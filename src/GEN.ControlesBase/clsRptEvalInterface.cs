using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    interface clsRptEvalInterface
    {
        void ImpPropuestaEval();

        void ImpEvalCualitativa();

        void ImpEEFF();

        void ImpHojaTrabajo();

        void ImpFlujoCaja();

        void ImpSolicitud();

        void ImpActaAprob();

        void ImpOpRiesgos();

        void ImpOpRecu();

        void ImpAproRapida();

        void VerVisita();

        /*  Funcion para Imprimir el Reporte de Score Crédito  */
        void impScore();
    }
}