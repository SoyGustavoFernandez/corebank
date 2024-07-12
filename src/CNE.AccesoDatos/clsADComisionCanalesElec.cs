using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace CNE.AccesoDatos
{
    public class clsADComisionCanalesElec
    {
        private clsGENEjeSP objEjeSp;

        public clsADComisionCanalesElec()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ObtenerCanalesElectronicos(int idCanal = 0)
        {
            return this.objEjeSp.EjecSP("CNE_ObtenerConfigCanalElect_SP", idCanal);
        }

        public DataTable ObtenerTipoCanalServicio()
        {
            return this.objEjeSp.EjecSP("CNE_ObtieneTipoCanalServicio_SP");
        }

        public DataTable ObtenerTipoAsumeComision()
        {
            return this.objEjeSp.EjecSP("CNE_ObtieneTipoAsumecomision_SP");
        }

        public DataTable ObtenerTipoRango()
        {
            return this.objEjeSp.EjecSP("CNE_ObtieneTipoRango_SP");
        }

        public DataTable ObtenerTipoModalidadPago()
        {
            return this.objEjeSp.EjecSP("CNE_ObtieneTipoModalidadPago_SP");
        }

        public DataSet ObtenerConfComisiones(int idCanal)
        {
            return this.objEjeSp.DSEjecSP("CNE_ObtenerConfComisionesCanEle_SP", idCanal);
        }

        public DataTable GuardaConfComisiones(string xmlConfComisionM, string xmlConfComisionD, string cUsuarioReg)
        {
            return this.objEjeSp.EjecSP("CNE_GuardaConfComisiones_sp", xmlConfComisionM, xmlConfComisionD, cUsuarioReg);
        }

        public DataSet ObtenerComisionesAuditoria(int idCanal, DateTime fechaDesde, DateTime fechaHasta)
        {
            return this.objEjeSp.DSEjecSP("CNE_ObtenerComisionesAuditoria_SP", idCanal, fechaDesde, fechaHasta);
        }

        public DataTable ObtenerComisionesCore(string xmlPagos)
        {
            return this.objEjeSp.EjecSP("CNE_CalculaComisiones_SP", xmlPagos);
        }
    }
}
