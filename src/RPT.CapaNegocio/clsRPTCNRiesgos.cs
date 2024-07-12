using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNRiesgos
    {
        private clsRPTADRiesgos objCNRPTRiesgos = new clsRPTADRiesgos();
        public DataTable CNRptCosechaComportamiento(int nAnio, int nMes, int nNumPeriodos,
                                                    int idAgencia, int idTipCred, int idSubTipCred, int idTipProd,
                                                    int idSubTipProd, int idAsesor, int idOperacion, int idZona,
                                                    int idUbigeo, int idActInt, string cxmlProducto)
        {
            return objCNRPTRiesgos.ADRptCosechaComportamiento(nAnio, nMes, nNumPeriodos, idAgencia,
                                        idTipCred, idSubTipCred, idTipProd, idSubTipProd, idAsesor,
                                        idOperacion, idZona, idUbigeo, idActInt, cxmlProducto);
        }

        public DataTable CNRptConcProducto(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptConcProducto(dFecha);
        }

        public DataTable CNRptHistConProducto(DateTime dFecIni, DateTime dFecFin)
        {
            return objCNRPTRiesgos.ADRptHistConProducto(dFecIni, dFecFin);
        }

        public DataTable CNRptConcAgencia(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptConcAgencia(dFecha);
        }

        public DataTable CNRptHistConAgencia(DateTime dFecIni, DateTime dFecFin)
        {
            return objCNRPTRiesgos.ADRptHistConAgencia(dFecIni, dFecFin);
        }

        public DataTable CNRptConcTipCredito(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptConcTipCredito(dFecha);
        }

        public DataTable CNRptHistConTipCredito(DateTime dFecIni, DateTime dFecFin)
        {
            return objCNRPTRiesgos.ADRptHistConTipCredito(dFecIni, dFecFin);
        }

        public DataTable CNRptRCC(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptRCC(dFecha);
        }

        public DataTable CNRptRiesgoSobreendeud(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptRiesgoSobreendeud(dFecha);
        }
        #region CarteraAnalista

        public DataTable CNRptConcCartAnalista(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptConcCartAnalista(dFecha);
        }

        public DataTable CNHistoricoConCarteraAnalista(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objCNRPTRiesgos.ADHistoricoConCarteraAnalista(dFechaIni, dFechaFin);
        }
        #endregion

        #region Cartera Zona
        
        public DataTable CNRptBasicosConcetracionCarteraPorZona(DateTime dFecha)
        {
            return objCNRPTRiesgos.ADRptBasicosConcetracionCarteraPorZona(dFecha);
        }

        public DataTable CNRptBasicosHistoConcetracionCarteraPorZona(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objCNRPTRiesgos.ADRptBasicosHistoConcetracionCarteraPorZona(dFechaIni, dFechaFin);
        }

        #endregion 
        #region Reporte Quick View
        
        public DataTable CNQVProducto(DateTime dFecha, int nPeriodos)
        {
            return objCNRPTRiesgos.ADQVProducto(dFecha, nPeriodos);
        }
	    
        public DataTable CNQVAgencia(DateTime dFecha, int nPeriodos)
        {
            return objCNRPTRiesgos.ADQVAgencia(dFecha, nPeriodos);
        }

        public DataTable CNQVCarteraPotencial(DateTime dFecha, int nPeriodos)
        {
            return objCNRPTRiesgos.ADQVCarteraPotencial(dFecha, nPeriodos);
        }

        #endregion
    }
}
