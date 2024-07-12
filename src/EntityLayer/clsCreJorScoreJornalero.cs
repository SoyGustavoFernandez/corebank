using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntityLayer
{
    public class clsCreJorScoreJornalero
    {
        public int idScoreJornalero { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }
        public int idAccionCultivo { get; set; }
        public decimal nPuntaje { get; set; }
        public decimal nMonto { get; set; }
        public bool lVigente { get; set; }

        public clsCreJorScoreCliente oExperiencia { get; set; }
        public clsCreJorScoreCliente oExpFinanciera { get; set; }
        public clsCreJorScoreCliente oReferencias { get; set; }
        public clsCreJorScoreCliente oEstadoCivil { get; set; }
        public clsCreJorScoreCliente oTiempoResidencia { get; set; }
        public clsCreJorScoreCliente oVivienda { get; set; }
        public clsCreJorScoreCliente oEstadoVivienda { get; set; }
        public clsCreJorScoreCliente oRespaldo { get; set; }
        public clsCreJorScoreCliente oEdad { get; set; }

        public DataTable dtReferencias { get; set; }

        public clsCreJorScoreJornalero()
        {
            this.idScoreJornalero = -1;
            this.idSolicitud = -1;
            this.lVigente = true;
            
            this.oExperiencia = new clsCreJorScoreCliente();
            this.oExperiencia.idItem = 1;
            this.oExpFinanciera = new clsCreJorScoreCliente();
            this.oExpFinanciera.idItem = 2;
            this.oReferencias = new clsCreJorScoreCliente();
            this.oReferencias.idItem = 3;
            this.oEstadoCivil = new clsCreJorScoreCliente();
            this.oEstadoCivil.idItem = 4;
            this.oTiempoResidencia = new clsCreJorScoreCliente();
            this.oTiempoResidencia.idItem = 5;
            this.oVivienda = new clsCreJorScoreCliente();
            this.oVivienda.idItem = 6;
            this.oEstadoVivienda = new clsCreJorScoreCliente();
            this.oEstadoVivienda.idItem = 7;
            this.oRespaldo = new clsCreJorScoreCliente();
            this.oRespaldo.idItem = 8;
            this.oEdad = new clsCreJorScoreCliente();
            this.oEdad.idItem = 9;
        }

        public int cantidadReferenciasPersonales()
        { 
            if(this.dtReferencias != null && this.dtReferencias.Rows.Count > 0)
            {
                return this.dtReferencias.Select("lVigente = 1 AND idTipoReferencia = " + 1).Length;
            }
            return 0;
        }
        public int cantidadReferenciasLaborales()
        {
            if (this.dtReferencias != null && this.dtReferencias.Rows.Count > 0)
            {
                return this.dtReferencias.Select("lVigente = 1 AND idTipoReferencia = " + 2).Length;
            }
            return 0;
        }

    }
}
