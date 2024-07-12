using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADEvalConsumo
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADdtEvalConsumo(int IdEvalConsumo)
        {
            return objEjeSp.EjecSP("Cre_BusEvaConsumo_Sp", IdEvalConsumo);
        }

        public DataTable ADdtDetalleEvalConsumo(int IdEvalConsumo, Int16 IdTipIngEgr)
        {
            return objEjeSp.EjecSP("Cre_LisDetEvaConsumo_Sp", IdEvalConsumo, IdTipIngEgr);
        }

        public DataTable ADdtRegEvalConsumo(string xmlEvalConsumo, string xmlDetIngEvalConsumo, string xmlDetEgrEvalConsumo, string xmlDetInterv,
                                            string xmlRiesgoCambiarioCrediticio, string xmlTarjetasCredito, string xmlCreditos, string xmlReferenciasPersonales, 
                                            string xmlReferenciasLaborales, string xmlBalanceGeneral, string xmlEstPerdGanancias, int IdEvalConsumoAnterior)
        {
            return objEjeSp.EjecSP("Cre_RegEvalConsumo_Sp", xmlEvalConsumo, xmlDetIngEvalConsumo, xmlDetEgrEvalConsumo, xmlDetInterv,
                                     xmlRiesgoCambiarioCrediticio, xmlTarjetasCredito, xmlCreditos, xmlReferenciasPersonales, xmlReferenciasLaborales,
                                     xmlBalanceGeneral, xmlEstPerdGanancias, IdEvalConsumoAnterior);
        }

        public DataTable ADdtLisPorcenIngReaEvaConsumo()
        {
            return objEjeSp.EjecSP("Cre_LisPorcenIngReaEvaConsumo_Sp");
        }

        public DataTable ADdtLisTipPerDetEvaCons()
        {
            return objEjeSp.EjecSP("Cre_LisTipPerDetalleEvalCons_Sp");
        }

        public DataTable ADdtLisTipGarRDS()
        {
            return objEjeSp.EjecSP("Cre_LisTipGarRDS_Sp");
        }

        public DataTable ADdtRetornaIntervCons(int IdEvalConsumo)
        {
            return objEjeSp.EjecSP("Cre_BusIntervEvaCon_Sp", IdEvalConsumo);
        }

        public DataTable ADdtBuscaEvaConCli(int IdCliente)
        {
            return objEjeSp.EjecSP("Cre_BuscaEvalConxCli_Sp", IdCliente);
        }

        public DataTable ADReferenciaPersonales(int idNumEva)
        {
            return objEjeSp.EjecSP("Cre_ReferenciaPersonales_Sp", idNumEva);
        }

        public DataSet ADRetornaOtrosDetalleEvalConsumo(int idNumEva)
        {
            return objEjeSp.DSEjecSP("Cre_OtrosDetalleEvalConsumo_Sp", idNumEva);
        }

        public DataTable CNdtListaCalifRef()
        {
            return objEjeSp.EjecSP("Cre_CalificRefPersonalesLaborales_Sp");
        }

        public DataTable CargarEscenarioRCC()
        {
            return objEjeSp.EjecSP("Cre_CargarEscenarioRCC_Sp");
        }

        public DataTable CargarPlantillaBalanceGeneral()
        {
            return objEjeSp.EjecSP("Cre_CargarPlantillaBalanceGeneral_Sp");
        }

        #region Medotos Nuevos

        public DataTable ADCargarDeudaRegistrada(int idEvalCre, int nFuente)
        {
            return objEjeSp.EjecSP("CRE_DeudasConsumo_SP", idEvalCre, nFuente); 
        }

        public DataTable ADListaTipoDeuda(int nCondicion)
        {
            return objEjeSp.EjecSP("CRE_ListaTipoDeudaEval_SP", nCondicion); 
        }

        public DataTable ADListarIngEgre(int idEvalCre)
        {
            return objEjeSp.EjecSP("CRE_ListarIngresosEgresosConsumo_SP", idEvalCre);
        }

        public DataTable ADListarDetIngEgr(int idTipEvalCre)
        {
            return objEjeSp.EjecSP("CRE_ListaDetalleIngrEgre_SP", idTipEvalCre);
        }

        public DataSet ADListaSolicitudCli(int idCli, int idUsuario, string cTipEval)
        {
            return objEjeSp.DSEjecSP("CRE_RetSolicitudCreCli_SP", idCli, idUsuario, cTipEval);
        }

        public DataTable ADNuevaEval(string cEvalXml, int idUsuReg, int idAgencia, DateTime dFechaSis, decimal nMontoCuotaAprox, int nAniosExperiencia, int idCatLab, int nTipoIngreso, int idTipoEval, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_GuardaNuevaEvalConsumo_SP", cEvalXml, idUsuReg, idAgencia, dFechaSis, nMontoCuotaAprox, nAniosExperiencia, idCatLab, nTipoIngreso, idTipoEval, idEstablecimiento);
        }

        public DataSet ADCargarEvalConsumo(int idEvalCre)
        {
            return objEjeSp.DSEjecSP("CRE_RetornaEvalConsumo_SP", idEvalCre);
        }

        public DataTable ADInsActEvaluacionConsumo(string cEvalCre, string cEvalCual, string cReferencias, string cDeudas, string cEERR, string cIngreEgre, string cDestinosCre, string cRcc)
        {
            return objEjeSp.EjecSP("CRE_InsActEvaluacionConsumo_SP", cEvalCre, cEvalCual, cReferencias, cDeudas, cEERR, cIngreEgre, cDestinosCre, cRcc);
        }

        public DataSet ADPropuesta(int idEvalCre, int idSolicitud, int nFuente)
        {
            return objEjeSp.DSEjecSP("CRE_PropuestaEvalConsumo_SP", idEvalCre, idSolicitud, nFuente);
        }

        #endregion  
    }
}
