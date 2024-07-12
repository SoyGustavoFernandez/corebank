using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADRiesgos
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADRptCosechaComportamiento(int nAnio       , int nMes      , int nNumPeriodos  ,
                                                    int idAgencia   , int idTipCred , int idSubTipCred  , int idTipProd     ,
                                                    int idSubTipProd, int idAsesor  , int idOperacion   , int idZona        ,
                                                    int idUbigeo, int idActInt, string cxmlProducto)
        {
            return objEjeSp.EjecSP("RSG_CosechaComport_Sp", nAnio, nMes, nNumPeriodos, idAgencia, 
                                        idTipCred   , idSubTipCred  , idTipProd   , idSubTipProd  , idAsesor      ,
                                        idOperacion, idZona, idUbigeo, idActInt, cxmlProducto);
        }

        public DataTable ADRptConcProducto(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_ConcProducto_Sp", dFecha);
        }

        public DataTable ADRptHistConProducto(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RSG_HistConProducto_Sp", dFecIni, dFecFin);
        }

        public DataTable ADRptConcAgencia(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_ConcAgencia_Sp", dFecha);
        }

        public DataTable ADRptHistConAgencia(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RSG_HistConAgencia_Sp", dFecIni, dFecFin);
        }

        public DataTable ADRptConcTipCredito(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_ConcTipCred_Sp", dFecha);
        }

        public DataTable ADRptHistConTipCredito(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RSG_HistConTipCred_Sp", dFecIni, dFecFin);
        }

        public DataTable ADRptRCC(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_RptRCC_Sp", dFecha);
        }

        public DataTable ADRptRiesgoSobreendeud(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_RptRiesgoSobreendeud_Sp", dFecha);
        }

        #region CarteraAnalista

        public DataTable ADRptConcCartAnalista(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_RptCarteraPorAnalista_SP", dFecha);
        }

        public DataTable ADHistoricoConCarteraAnalista(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("RSG_HistoricoConCarteraAnalista_SP", dFechaIni, dFechaFin);
        }
        #endregion

        #region Cartera Zona

        public DataTable ADRptBasicosConcetracionCarteraPorZona(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RSG_RptBasicosConcetracionCarteraPorZona_SP", dFecha);
        }

        public DataTable ADRptBasicosHistoConcetracionCarteraPorZona(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("RSG_RptBasicosHistoConcetracionCarteraPorZona_SP", dFechaIni, dFechaFin);
        }
        #endregion 
        #region Reporte Quick View

        public DataTable ADQVProducto(DateTime dFecha, int nPeriodos)
        {
            return objEjeSp.EjecSP("RSG_RPTQuickViewProductos_SP", dFecha, nPeriodos);
        }

        public DataTable ADQVAgencia(DateTime dFecha, int nPeriodos)
        {
            return objEjeSp.EjecSP("RSG_RPTQuickViewOficina_SP", dFecha, nPeriodos);
        }

        public DataTable ADQVCarteraPotencial(DateTime dFecha, int nPeriodos)
        {
            return objEjeSp.EjecSP("RSG_CarteraPotencial_SP", dFecha, nPeriodos);
        }

        #endregion
    }
}
