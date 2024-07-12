using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADConfigGastComiSeg
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public int InsUpdConfigGastComiSeg(String tConfigCredito,Int32 nIndicadorNivelProducto, int idDetalleGasto)
        {
            return Convert.ToInt32(objEjeSp.EjecSP("ADM_InsUpdConfigGastComiSeg_sp", tConfigCredito, nIndicadorNivelProducto, idDetalleGasto).Rows[0][0].ToString());
        }

        public DataTable ListarTipoDeuda(Int32 nTipoDeudas)
        {
            return objEjeSp.EjecSP("CAJ_ListarTipoDeuda_sp", nTipoDeudas);
        }

        public DataTable ListarCondicionContable()
        {
            return objEjeSp.EjecSP("GEN_ListarCondicionContable_sp");
        }

        public DataTable ListarAplicaConcepto()
        {
            return objEjeSp.EjecSP("GEN_ListarAplicaConcepto_sp");
        }

        public DataTable ListarAplicarCuota()
        {
            return objEjeSp.EjecSP("GEN_ListarAplicarCuota_sp");
        }

        public DataTable BuscarConfigGastoComisionSeguro(Int32 IdModulo,Int32 IdAgencia,Int32 IdMoneda,Int32 IdGrupoGasto)
        {
            return objEjeSp.EjecSP("ADM_BuscarConfigGastComiSeg_sp", IdModulo, IdAgencia, IdMoneda, IdGrupoGasto);
        }

        public DataTable CargarGrupoGasto()
        {
            return objEjeSp.EjecSP("GEN_ListarGrupoConcepto_sp");
        }

        public DataTable CargarConcepto(Int32 nIdGrupoConcepto)
        {
            return objEjeSp.EjecSP("GEN_ListarConcepto_sp", nIdGrupoConcepto);
        }

        public DataTable ValidarSolicitudConfigGastComiSeg(Int32 nNumSolicitud, Int32 nTipoOperacion, Int32 nIdMenu, int idCanal, int idCuenta)
        {
            return objEjeSp.EjecSP("ADM_ValidaSolicitudConfigGastComiSeg_sp", nNumSolicitud, nTipoOperacion, nIdMenu, idCanal, idCuenta);
        }
        //Actualizar las Configuraciones 
        public DataTable ActualizaConfigGastComiSeg(string XmlConfigGastComiSeg)
        {
            return objEjeSp.EjecSP("ADM_UpdConfigGastComiSeg_sp", XmlConfigGastComiSeg);
        }

        public DataTable ValidaConfigGastComiSeg(int idTipoOperacion, int idCanal, int idProducto, int idRecurso, int idMoneda, int idAgencia, int idTipopersona, int idModulo, decimal nMonto)
        {
            return objEjeSp.EjecSP("ADM_ValidaConfigGastComiSeg_sp", idTipoOperacion, idCanal, idProducto, idRecurso, idMoneda, idAgencia, idTipopersona, idModulo, nMonto);
        }

        public DataTable ListaTipDocGastos()
        {
            return objEjeSp.EjecSP("GEN_LstTipDocGastos_Sp");
        }

        public DataTable ADValidarAplicacionSeguroDesgravamen(int idSolicitud, decimal nMontoSolicitado, int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ValidarSiAplicaSeguro_SP", idSolicitud, nMontoSolicitado, idCuenta);
        }

        public DataTable ADGetConfigGastosCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_GetConfigGastosCuenta_Sp", idCuenta);
        }
    }
}
