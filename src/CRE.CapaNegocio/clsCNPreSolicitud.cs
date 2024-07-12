using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNPreSolicitud
    {
        clsADPreSolicitud adpresolicitud = new clsADPreSolicitud();

        public DataTable CNlistarTipoCaptacion()
        {
            return adpresolicitud.ADlistarTipoCaptacion();
        }

        public DataTable CNListarPreSolicitud(int idEstado, int idUsuario)
        {
            return adpresolicitud.ADListarPreSolicitud(idEstado, idUsuario);
        }

        public DataTable CNListarPreSolicitudId(int idPreSolicitud)
        {
            return adpresolicitud.ADListarPreSolicitudId(idPreSolicitud);
        }

        public DataTable CNInsertarPreSolicitud(int idEstado, decimal nMontoSolicitado, int nCuotas, int nPlazoCuota, int idTipoPeriodo, int idTipoDocumento,
                                              int idTipoCaptacion, int idCli, int idMoneda, string cDocumento, string cNombreCompleto, string cApellidoPaterno,
            string cApellidoMaterno, string cNombre, string nNumeroTelefono, string cNumeroTelefono2, int idAgencia, DateTime dFechaRegistro, int idUsuario, 
            int idUbigeo, string cDireccion, string cObservaciones)
        {
            return adpresolicitud.ADInsertarPreSolicitud(idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo, idTipoDocumento,
                                              idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto, cApellidoPaterno,
            cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario,idUbigeo,cDireccion, cObservaciones);
        }

        public DataTable CNActualizarPreSolicitud(int idPreSolicitud, int idEstado, decimal nMontoSolicitado, int nCuotas, int nPlazoCuota, int idTipoPeriodo, int idTipoDocumento,
                                              int idTipoCaptacion, int idCli, int idMoneda, string cDocumento, string cNombreCompleto, string cApellidoPaterno,
            string cApellidoMaterno, string cNombre, string nNumeroTelefono, string cNumeroTelefono2, int idAgencia, DateTime dFechaRegistro, int idUsuario, 
            int idUbigeo, string cDireccion, string cObservaciones)
        {
            return adpresolicitud.ADActualizarPreSolicitud(idPreSolicitud, idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo, idTipoDocumento,
                                              idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto, cApellidoPaterno,
            cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario,idUbigeo, cDireccion, cObservaciones);
        }

        public DataTable ADBuscarPreSolicitud(int idTipoDocumento, string cDocumento)
        {
            return adpresolicitud.ADBuscarPreSolicitud(idTipoDocumento, cDocumento);
        }
    }
}
