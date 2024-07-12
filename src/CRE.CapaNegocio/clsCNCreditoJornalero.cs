using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNCreditoJornalero
    {
        private clsADCreditoJornalero oADCreJor = new clsADCreditoJornalero();

        public DataTable listaAccionesCultivo()
        {
            return oADCreJor.listaAccionesCultivo();
        }
        public DataSet dsItemsScore()
        {
            return oADCreJor.dsItemsScore();
        }
        public DataSet listaMontos()
        {
            return oADCreJor.listaMontos();
        }

        public clsCreJorScoreCliente dtAScoreClientePorItem(DataTable dtScoreCliente, int idItem)
        { 
            clsCreJorScoreCliente oResult = new clsCreJorScoreCliente();
            DataRow[] drFilas = dtScoreCliente.Select("idItem = " + idItem);
            dtScoreCliente = drFilas.Length > 0 ? drFilas.CopyToDataTable() : dtScoreCliente.Clone();
            if (dtScoreCliente.Rows.Count > 0) 
            {
                oResult.idScoreCliente = Convert.ToInt32(dtScoreCliente.Rows[0]["idScoreCliente"]);
                oResult.idScoreJornalero = Convert.ToInt32(dtScoreCliente.Rows[0]["idScoreJornalero"]);
                oResult.idValor = Convert.ToInt32(dtScoreCliente.Rows[0]["idValor"]);
                oResult.nValor = Convert.ToDecimal(dtScoreCliente.Rows[0]["nValor"]);
                oResult.lVigente = Convert.ToBoolean(dtScoreCliente.Rows[0]["lVigente"]);
            }
            oResult.idItem = idItem;
            return oResult;
        }

        public clsCreJorScoreJornalero listaScoreCliente(int idCli, int idSolicitud)
        {
            DataSet dsValues = this.oADCreJor.listaScoreCliente(idCli, idSolicitud);
            clsCreJorScoreJornalero oReturn = new clsCreJorScoreJornalero();
            oReturn.idCli = idCli;
            oReturn.idSolicitud = idSolicitud;
            if (dsValues.Tables[0].Rows.Count > 0) 
            {
                oReturn.idScoreJornalero = Convert.ToInt32(dsValues.Tables[0].Rows[0]["idScoreJornalero"]);
                oReturn.idCli = Convert.ToInt32(dsValues.Tables[0].Rows[0]["idCli"]);
                oReturn.idAccionCultivo = Convert.ToInt32(dsValues.Tables[0].Rows[0]["idAccionCultivo"]);
            }

            /** Cargar Items **/
            oReturn.oExperiencia = this.dtAScoreClientePorItem(dsValues.Tables[1], 1);
            oReturn.oExpFinanciera = this.dtAScoreClientePorItem(dsValues.Tables[1], 2);
            oReturn.oReferencias = this.dtAScoreClientePorItem(dsValues.Tables[1], 3);
            oReturn.oEstadoCivil = this.dtAScoreClientePorItem(dsValues.Tables[1], 4);
            oReturn.oTiempoResidencia = this.dtAScoreClientePorItem(dsValues.Tables[1], 5);
            oReturn.oVivienda = this.dtAScoreClientePorItem(dsValues.Tables[1], 6);
            oReturn.oEstadoVivienda = this.dtAScoreClientePorItem(dsValues.Tables[1], 7);
            oReturn.oRespaldo = this.dtAScoreClientePorItem(dsValues.Tables[1], 8);
            oReturn.oEdad = this.dtAScoreClientePorItem(dsValues.Tables[1], 9);

            oReturn.dtReferencias = dsValues.Tables[2];

            return oReturn;
        }

        public DataSet dsListaScoreCliente(int idCli, int idSolicitud)
        {
            return this.oADCreJor.listaScoreCliente(idCli, idSolicitud);
        }

        public clsCreJorScoreJornalero guardarScoreJornalero(clsCreJorScoreJornalero oScoreJornalero)
        {
            return this.oADCreJor.guardarScoreJornalero(oScoreJornalero);
        }

        public DataSet listaTipoVinculos()
        {
            return this.oADCreJor.listaTipoVinculos();
        }

        public DataSet listaVariablesCliente(int idCli)
        {
            return this.oADCreJor.listaVariablesCliente(idCli);
        }
    }
}
