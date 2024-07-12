using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsADTasaCredito
    {
        public IntConexion objEjeSp;

        public clsADTasaCredito()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADTasaCredito(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ListaTasa(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, bool lNegociable, int idOperacion, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("Cre_ExtraeTasaSolicitud_sp", nPlazo, idProducto, nMonto, idMoneda, idAgencia, lNegociable, idOperacion, idClasificacionInterna);
        }

        public DataTable TasaCreditoNegociable(int idTasa)
        {
            return objEjeSp.EjecSP("Cre_TasaCreditoNegociable_SP", idTasa);
        }

        public DataTable SeguimientoSolicitudTasasNegociables(int idSolicitud)
        {
            return objEjeSp.EjecSP("WCF_SeguimientoSolicitudTasasNegociables_SP", idSolicitud);
        }

        public DataTable ListaTasaEval(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("Cre_ExtraeTasaSolicitudEval_sp", nPlazo, idProducto, nMonto, idMoneda, idAgencia, idSolicitud, idClasificacionInterna);
        }


        public DataTable ListaTasaEvalGrupoSol(int nPlazo, int idProducto, decimal nMontoMinimo, decimal nMontoMaxima, int idMoneda, int idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("Cre_ExtraeTasaSolicitudGrupSolEval_sp", idProducto, idMoneda, idAgencia, nPlazo, nMontoMinimo, nMontoMaxima, idSolicitud, idClasificacionInterna);
        }

        #region Solicitud Simp
        public DataTable ADListaTasaSolicitudSimp(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, bool lNegociable, int idOperacion, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("CRE_ExtraerTasaSolicitudSimp_SP", nPlazo, idProducto, nMonto, idMoneda, idAgencia, lNegociable, idOperacion, idClasificacionInterna);
        }
        public DataTable ADListaTasaNegocibleSimp(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("CRE_ExtraerTasaSolicitudEvalSimp_SP", nPlazo, idProducto, nMonto, idMoneda, idAgencia, idSolicitud, idClasificacionInterna);
        }
        public DataTable ADRecuperarTasaSolicutdSimp(int idTasa, decimal nTasaSeleccionada = 0)
        {
            return objEjeSp.EjecSP("CRE_RecuperarTasaSolicitudSimp_SP", idTasa, nTasaSeleccionada);
        }
        
        #endregion
    }
}
