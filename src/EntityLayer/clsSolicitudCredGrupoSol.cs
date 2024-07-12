using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudCredGrupoSol
    {
        public int idSolicitudCredGrupoSol { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idProducto { get; set; }
        public int idOperacion { get; set; }
        public int idMoneda { get; set; }
        public int idUsuario { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public int idAgencia { get; set; }
        public int nDiasGracia { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idUsuRegistro { get; set; }
        public int idUsuModifica { get; set; }
        public int nCuotasGracia { get; set; }
        public decimal nTea { get; set; }
        public int idTasa { get; set; }
        public int idModalidadCredito { get; set; }
        public int idModalidadDes { get; set; }

        public bool lreglas { get; set; }
        public string cProcesado { get; set; }
        public string cNombreGrupo { get; set; }
        public int idGrupoSolidarioCiclo { get; set; }
        public int idGrupoSolidarioTipo { get; set; }
        public DateTime dFechaPrimeraCuota { get; set; }
        public DateTime dFecDesemb { get; set; }
        public DateTime dFechaUltimaCuota { get {

            int nTotalDiasCredito = 0;

            int nDiaAcumul = 0;

            DateTime dFecNewCuo = dFechaPrimeraCuota; //la fecha de la cuota siguiente será la del desembolso + la gracia
            DateTime DfecVeriFec;

            nDiaAcumul = (int)(dFechaPrimeraCuota - dFecDesemb).TotalDays;
            int nDiaFecAux = nPlazoCuota;

            if (idTipoPeriodo == 1) //Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)
            {
                for (int i = 1; i < nCuotas; i++) //Recorrer las cuotas para definir las fechas de pago
                {
                    nDiaAcumul = nDiaAcumul + (int)(dFecNewCuo.AddMonths(1) - dFecNewCuo.AddDays(1)).TotalDays;
                    dFecNewCuo = dFecNewCuo.AddMonths(1);
                }
            }
            else
            {
                for (int i = 1; i < nCuotas; i++)
                {
                    nDiaAcumul = nDiaAcumul + (int)(dFecNewCuo.AddDays(nPlazoCuota) - dFecNewCuo.AddDays(1) ).TotalDays;
                    dFecNewCuo = dFecNewCuo.AddDays(nPlazoCuota);
                }
            }

            nTotalDiasCredito = nDiaAcumul;
            return dFecNewCuo;
        } }

    }
}
