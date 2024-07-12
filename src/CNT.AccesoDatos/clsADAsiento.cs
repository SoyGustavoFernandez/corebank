using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNT.AccesoDatos
{
    public class clsADAsiento
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADConsultaAsiento(int idVoucher)
        {
            return objEjeSp.EjecSP("CNT_ListaAsientoxVoucher_sp", idVoucher);
        }
        public DataTable ADInsertaAsiento(DateTime dFecha, int idAgencia, int idTipAsi, string cXmlAsiento, string cGlosa, int idUsuRegistra)
        {
            return objEjeSp.EjecSP("CNT_GeneraAsientoManual_sp", dFecha, idAgencia, idTipAsi, cXmlAsiento, cGlosa,idUsuRegistra);
        }
        public DataTable ADActualizaAsiento(DateTime dFecha, int idAgencia, int idTipAsi, int nVoucher, string cXmlAsiento, int idUsuReg, int idAgeReg, string cGlosaAct)
        {
            return objEjeSp.EjecSP("CNT_ActualizaAsientoManual_sp", dFecha, idAgencia, idTipAsi, nVoucher, cXmlAsiento, idUsuReg, idAgeReg, cGlosaAct );
        }
        public DataTable ADEliminarAsientoManual(DateTime dFecha, int idAgencia, int nVoucher, int idUsuReg, int idAgeReg, string cGlosa)
        {
            return objEjeSp.EjecSP("CNT_EliminarAsientoManual_sp", dFecha, idAgencia,nVoucher, idUsuReg, idAgeReg, cGlosa);
        }
        public DataTable ADPLELibroDiario(DateTime dFecIni, DateTime dFecFin, int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_ExportaLibEleDiario_sp", dFecIni, dFecFin, idMoneda);
        }
        public DataTable ADPLERegCompras(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CNT_DatosPLERegCompras_sp", dFecIni, dFecFin);
        }
        public DataTable ADPLELibroMayor(DateTime dFecIni, DateTime dFecFin, int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_ExportarLibroMayor_SP", dFecIni, dFecFin, idMoneda);
        }
        public DataTable ADPLERegVentas(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CNT_DatosPLERegVentas_sp", dFecIni, dFecFin);
        }
        public DataSet ADTotalLibroDia(DateTime dFecha, int idAsiento, int idMoneda, int idAgencia)
        {
            return objEjeSp.DSEjecSP("CNT_TotalLibroDiario_sp", dFecha, idAsiento, idMoneda, idAgencia);
        }
        public DataTable ADPLELibroGeneral(DateTime dFecIni, DateTime dFecFin, int idMoneda, string idLibro, string cNombreSp)
        {
            switch (idLibro)
            {
                case "010100":
                    cNombreSp = "CNT_ExportaLibEleMovEfec_sp";
                    break;
                case "010200":
                    cNombreSp = "CNT_ExportaLibEleMovCtaCte_sp";
                    break;
            }
            return objEjeSp.EjecSP(cNombreSp, dFecIni, dFecFin, idMoneda);
        }
        public DataTable ADPLELibroGeneralInvBal(DateTime dFecProceso, string cNombreSp)
        {
            return objEjeSp.EjecSP(cNombreSp, dFecProceso);
        }
        public DataTable CNListaLESBS()
        {

            return objEjeSp.EjecSP("CNT_ListaSPLibroE_sp");
        }
    }
}
