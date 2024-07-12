using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNPagare 
    {
        clsADPagare adpagare = new clsADPagare();

        public DataTable CNAnularPagareCredito(int idPagareCredito)
        {
            return adpagare.ADAnularPagareCredito(idPagareCredito);
        }

        public DataTable CNInsertarPagareCredito(string cPagare, int idSolicitud, DateTime dFechaReg, int idUsuReg, bool lVigente, int idTipoPagare, int idSolicitudCredGrupoSol)
        {
            return adpagare.ADInsertarPagareCredito(cPagare, idSolicitud, dFechaReg, idUsuReg, lVigente, idTipoPagare, idSolicitudCredGrupoSol);
        }

        public DataTable CNValidarPagareCredito(string cPagare, int idTipoPagare)
        {
            return adpagare.ADValidarPagareCredito(cPagare, idTipoPagare);
        }

        public DataTable CNDesvincularPagareCredito(int idSolicitud, DateTime dFechaReg, int idUsuReg)
        {
            return adpagare.ADDesvinculaPagareCredito(idSolicitud, dFechaReg, idUsuReg);
        }

        public DataTable CNObtenerDatosPagareCredito(int idSolicitud, int idSolicitudCreditoGrupal = 0)
        {
            return adpagare.ADObtenerDatosPagareCredito(idSolicitud, idSolicitudCreditoGrupal);
        }
        public DataTable CNDesvincularPagareGeneralCredito(int idSolicitud, DateTime dFechaSistema, int idUsuario, int idSolicitudCreditoGrupal = 0)
        {
            return adpagare.ADDesvincularPagareGeneralCredito(idSolicitud, dFechaSistema, idUsuario, idSolicitudCreditoGrupal);
        }

        public DataTable CNAnularPagareGeneralCredito(int idSolicitud, DateTime dFechaSistema, int idUsuario, int idSolicitudCreditoGrupal = 0)
        {
            return adpagare.ADAnularPagareGeneralCredito(idSolicitud, dFechaSistema, idUsuario, idSolicitudCreditoGrupal);
        }
    }
}
