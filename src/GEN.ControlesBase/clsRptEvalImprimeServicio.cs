using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    class clsRptEvalImprimeServicio
    {
        private clsRptEvalInterface obj;

        public clsRptEvalImprimeServicio(clsRptEvalInterface objEval)
        {
            if (objEval == null)
            {
                MessageBox.Show("El objeto para impresión de formatos no esta implementado", "Validar Objeto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.obj = objEval;
        }

        public void ImprimeCascada()
        {
            this.obj.ImpPropuestaEval();
            this.obj.ImpEEFF();
            this.obj.ImpFlujoCaja();
            this.obj.ImpEvalCualitativa();
            this.obj.ImpHojaTrabajo();
        }

        public void ImpPropuestaEval()
        {
            this.obj.ImpPropuestaEval();
        }

        public void ImpEEFF()
        {
            this.obj.ImpEEFF();
        }

        public void ImpFlujoCaja()
        {
            this.obj.ImpFlujoCaja();
        }

        public void ImpEvalCualitativa()
        {
            this.obj.ImpEvalCualitativa();
        }

        public void ImpHojaTrabajo()
        {
            this.obj.ImpHojaTrabajo();
        }

        public void ImpSolicitud()
        {
            this.obj.ImpSolicitud();
        }

        public void ImpActaAprob()
        {
            this.obj.ImpActaAprob();
        }

        public void ImpOpRiesgos()
        {
            this.obj.ImpOpRiesgos();
        }

        public void ImpOpRecu()
        {
            this.obj.ImpOpRecu();
        }

        public void ImpAproRapida()
        {
            this.obj.ImpAproRapida();
        }

        public void VerVisita()
        {
            this.obj.VerVisita();
        }

        /*  Funcion para Imprimir el Reporte de Score Crédito  */
        public void impScore()
        {
            this.obj.impScore();
        }
    }
}
