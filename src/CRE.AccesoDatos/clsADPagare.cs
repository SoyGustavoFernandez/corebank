using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADPagare
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADAnularPagareCredito(int idPagareCredito)
        {
            return objEjeSp.EjecSP("CRE_AnularPagareCredito_SP", idPagareCredito);
        }

        public DataTable ADInsertarPagareCredito(string cPagare, int idSolicitud, DateTime dFechaReg, int idUsuReg, bool lVigente, int idTipoPagare, int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_InsertarPagareCredito_SP", cPagare, idSolicitud, dFechaReg, idUsuReg, lVigente, idTipoPagare, idSolicitudCredGrupoSol);
        }

        public DataTable ADValidarPagareCredito(string cPagare, int idTipoPagare)
        {
            return objEjeSp.EjecSP("CRE_ValidarPagareCredito_SP", cPagare, idTipoPagare);
        }

        public DataTable ADDesvinculaPagareCredito(int Idsolicitud, DateTime dFechaReg, int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_DesvincularPagareCredito_SP", Idsolicitud, dFechaReg, idUsuReg);
        }

        public DataTable ADObtenerDatosPagareCredito(int idSolicitud, int idSolicitudCreditoGrupal = 0)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosPagareCredito_SP", idSolicitud, idSolicitudCreditoGrupal);
        }

        public DataTable ADDesvincularPagareGeneralCredito(int idSolicitud, DateTime dFechaSistema, int idUsuario, int idSolicitudCreditoGrupal = 0)
        {
            return objEjeSp.EjecSP("CRE_DesvincularPagareGeneralCredito_SP", idSolicitud, dFechaSistema, idUsuario, idSolicitudCreditoGrupal);
        }

        public DataTable ADAnularPagareGeneralCredito(int idSolicitud, DateTime dFechaSistema, int idUsuario, int idSolicitudCreditoGrupal = 0)
        {
            return objEjeSp.EjecSP("CRE_AnularPagareGeneralCredito_SP", idSolicitud, dFechaSistema, idUsuario, idSolicitudCreditoGrupal);
        }
    }
}
