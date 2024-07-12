using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using GEN.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNEvalConsumo
    {
        clsADEvalConsumo CNEvalConsumo = new clsADEvalConsumo();

        public DataTable CNdtEvalConsumo(int IdEvalConsumo)
        {            
            DataTable dtCNEvalConsumo = CNEvalConsumo.ADdtEvalConsumo(IdEvalConsumo);
            return dtCNEvalConsumo;
        }

        public DataTable CNdtDetalleEvalConsumo(int IdEvalConsumo, Int16 IdTipIngEgr)
        {
            DataTable dtCNDetaleEvalConsumo = CNEvalConsumo.ADdtDetalleEvalConsumo(IdEvalConsumo, IdTipIngEgr);
            return dtCNDetaleEvalConsumo;
        }

        public DataTable CNdtRegEvalConsumo(string xmlEvalConsumo, string xmlDetIngEvalConsumo, string xmlDetEgrEvalConsumo, string xmlDetInterv,
                                            string xmlRiesgoCambiarioCrediticio, string xmlTarjetasCredito, string xmlCreditos, string xmlReferenciasPersonales,
                                            string xmlReferenciasLaborales, string xmlBalanceGeneral, string xmlEstPerdGanancias, int IdEvalConsumoAnterior)
        {
            DataTable dtCNRegEvalConsumo = CNEvalConsumo.ADdtRegEvalConsumo(xmlEvalConsumo, xmlDetIngEvalConsumo, xmlDetEgrEvalConsumo, xmlDetInterv,
                                             xmlRiesgoCambiarioCrediticio, xmlTarjetasCredito, xmlCreditos, xmlReferenciasPersonales, xmlReferenciasLaborales, 
                                             xmlBalanceGeneral,xmlEstPerdGanancias, IdEvalConsumoAnterior);
            return dtCNRegEvalConsumo;
        }

        public DataTable CNdtLisPorcenIngReaEvaConsumo()
        {
            DataTable dtCNLisPorcenIngReaEvaConsumo = CNEvalConsumo.ADdtLisPorcenIngReaEvaConsumo();
            return dtCNLisPorcenIngReaEvaConsumo;
        }

        public DataTable CNdtLisTipPerDetEvaCons()
        {
            DataTable dtCNLisTipPerDetEvaCons = CNEvalConsumo.ADdtLisTipPerDetEvaCons();
            return dtCNLisTipPerDetEvaCons;
        }

        public DataTable CNdtLisTipGarRDS()
        {
            DataTable dtCNLisTipTipGarRDS = CNEvalConsumo.ADdtLisTipGarRDS();
            return dtCNLisTipTipGarRDS;
        }

        public DataTable CNdtListEvalConCre(int IdClient)
        {
            clsADSolicitud CNlistEvalCon = new clsADSolicitud();
            DataTable dtCNdtListEvalConCre = CNlistEvalCon.ADdtLisEvaConCre(IdClient);
            return dtCNdtListEvalConCre;
        }

        public DataTable CNdtRetornaIntervCons(int IdEvalConsumo)
        {
            DataTable dtRetornaIntervCons = CNEvalConsumo.ADdtRetornaIntervCons(IdEvalConsumo);
            return dtRetornaIntervCons;
        }

        public DataTable CNdtBuscaEvaConxCli(int IdCliente)
        {
            DataTable dtRetornaIntervCons = CNEvalConsumo.ADdtBuscaEvaConCli(IdCliente);
            return dtRetornaIntervCons;
        }

        /// <summary>
        /// Retorna las Referencia personales de la evaluación de un cliente de acuerdo a su número de evaluación Consumo
        /// </summary>
        /// <param name="idNumEva"></param>
        /// <returns></returns>
        public DataTable CNReferenciaPersonales(int idNumEva)
        {
            DataTable dtReferenciaPersonales = CNEvalConsumo.ADReferenciaPersonales(idNumEva);
            return dtReferenciaPersonales;
        }

        public DataSet CNdsRetornaOtrosDetalleEvalConsumo(int idNumEva)
        {
            DataSet dtRetornaOtrosDetalleEvalConsumo = CNEvalConsumo.ADRetornaOtrosDetalleEvalConsumo(idNumEva);
            return dtRetornaOtrosDetalleEvalConsumo;
        }

        public DataTable CNdtListaCalifRef()
        {
            return CNEvalConsumo.CNdtListaCalifRef();
        }

        public DataTable CargarEscenarioRCC()
        {
            return CNEvalConsumo.CargarEscenarioRCC();
        }

        public DataTable CargarPlantillaBalanceGeneral()
        {
            return CNEvalConsumo.CargarPlantillaBalanceGeneral();
        }

        #region Medotos Nuevos

        public DataTable CNCargarDeudaRegistrada(int idEvalCre, int nFuente)
        {
            return CNEvalConsumo.ADCargarDeudaRegistrada(idEvalCre, nFuente);
        }

        public DataTable CNListaTipoDeuda(int nCondicion)
        {
            return CNEvalConsumo.ADListaTipoDeuda(nCondicion);
        }

        public DataTable CNListarIngEgre(int idEvalCre)
        {
            return CNEvalConsumo.ADListarIngEgre(idEvalCre);
        }

        public DataTable CNListarDetIngEgr(int idTipEvalCre)
        {
            return CNEvalConsumo.ADListarDetIngEgr(idTipEvalCre);
        }

        public DataSet CNListaSolicitudCli(int idCli, int idUsuario, string cTipEval)
        {
            return CNEvalConsumo.ADListaSolicitudCli(idCli, idUsuario, cTipEval);
        }


        public DataTable CNNuevaEval(string cEvalXml, int idUsuReg, int idAgencia, DateTime dFechaSis, decimal nMontoCuotaAprox, int nAniosExperiencia, int idCatLab, int nTipoIngreso, int idTipoEval, int idEstablecimiento)
        {
            return CNEvalConsumo.ADNuevaEval(cEvalXml, idUsuReg, idAgencia, dFechaSis, nMontoCuotaAprox, nAniosExperiencia, idCatLab, nTipoIngreso, idTipoEval, idEstablecimiento);
        }

        public DataSet CNCargarEvalConsumo(int idEvalCre)
        {
            return CNEvalConsumo.ADCargarEvalConsumo(idEvalCre);
        }

        public DataTable CNInsActEvaluacionConsumo(string cEvalCre, string cEvalCual, string cReferencias, string cDeudas, string cEERR, string cIngreEgre, string cDestinosCre, string cRcc)
        {
            return CNEvalConsumo.ADInsActEvaluacionConsumo(cEvalCre, cEvalCual, cReferencias, cDeudas, cEERR, cIngreEgre, cDestinosCre, cRcc);
        }

        public DataSet CNPropuesta(int idEvalCre, int idSolicitud, int nFuente)
        {
            return CNEvalConsumo.ADPropuesta(idEvalCre, idSolicitud, nFuente);
        }
        #endregion  
    }
}
