using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsCNTasaCredito
    {
        public clsADTasaCredito ObjTasaCredito;

        public clsCNTasaCredito(bool lWS = false)
        {
            if (lWS)
            {
                ObjTasaCredito = new clsADTasaCredito(lWS);
            }
            else
            {
                ObjTasaCredito = new clsADTasaCredito();
            }
        }

        public DataTable ListaTasaCredito(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion, int idClasificacionInterna)
        {
            return ObjTasaCredito.ListaTasa(nPlazo, idProducto, nMonto, idMoneda, idAgencia, false, idOperacion, idClasificacionInterna);
        }

        public DataTable ListaTasaCreditoNegociable(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion, int idClasificacionInterna)
        {
            return ObjTasaCredito.ListaTasa(nPlazo, idProducto, nMonto, idMoneda, idAgencia, true, idOperacion, idClasificacionInterna);
        }
        public DataTable TasaCreditoNegociable(int idTasa)
        {
            return ObjTasaCredito.TasaCreditoNegociable(idTasa);
        }
        public DataTable SeguimientoSolicitudTasasNegociables(int idSolicitud)
        {
            return ObjTasaCredito.SeguimientoSolicitudTasasNegociables(idSolicitud);
        }
        public DataTable ListaTasaEval(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            return ObjTasaCredito.ListaTasaEval(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idSolicitud, idClasificacionInterna);
        }

        public DataTable ListaTasaEvalGrupoSol(int nPlazo, int idProducto, decimal nMontoMinimo, decimal nMontoMaxima, int idMoneda, int idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            return ObjTasaCredito.ListaTasaEvalGrupoSol(nPlazo, idProducto, nMontoMinimo, nMontoMaxima, idMoneda, idAgencia, idSolicitud, idClasificacionInterna);
        }

        //public DataTable ListaTasaCreditoRefiNov(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion)
        //{
        //    return ObjTasaCredito.ListaTasa(nPlazo, idProducto, nMonto, idMoneda, idAgencia, false, 0);
        //}

        #region Solicitud Simp
        

        public List<clsTasaCredSimp> CNListaTasaCreditoSimp(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion, int idClasificacionInterna)
        {
            DataTable dtTasaNormal = ObjTasaCredito.ADListaTasaSolicitudSimp(nPlazo, idProducto, nMonto, idMoneda, idAgencia, false, idOperacion, idClasificacionInterna);
            List<clsTasaCredSimp> lstTasaNormal = (dtTasaNormal.Rows.Count > 0) ? dtTasaNormal.ToList<clsTasaCredSimp>() as List<clsTasaCredSimp> : new List<clsTasaCredSimp>(); ;
            return lstTasaNormal;
        }

        public List<clsTasaCredSimp> CNListaTasaNegocibleSimp(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idSolicitud, int idClasificacionInterna)
        {
            DataTable dtTasaNegociable = ObjTasaCredito.ADListaTasaNegocibleSimp(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idSolicitud, idClasificacionInterna);
            List<clsTasaCredSimp> lstTasaNegociable = (dtTasaNegociable.Rows.Count > 0) ? dtTasaNegociable.ToList<clsTasaCredSimp>() as List<clsTasaCredSimp> : new List<clsTasaCredSimp>(); ;

            return lstTasaNegociable;
        }

        public clsTasaCredSimp CNRecuperarTasaSolicutdSimp(int idTasa, decimal nTasaSeleccionada = 0)
        {
            DataTable dtTasaNegociable = ObjTasaCredito.ADRecuperarTasaSolicutdSimp(idTasa, nTasaSeleccionada);
            List<clsTasaCredSimp> lstTasaNegociable = (dtTasaNegociable.Rows.Count > 0) ? dtTasaNegociable.ToList<clsTasaCredSimp>() as List<clsTasaCredSimp> : new List<clsTasaCredSimp>(); ;

            return (lstTasaNegociable.Count > 0) ? lstTasaNegociable[0] : new clsTasaCredSimp();
        }


        #endregion



    }
}
