using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADPreSolicitud
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADlistarTipoCaptacion()
        {
            return objEjeSp.EjecSP("CRE_ListarTipoCaptacion_SP");
        }

        public DataTable ADListarPreSolicitud(int idEstado, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListarPreSolicitud_SP", idEstado, idUsuario);
        }

        public DataTable ADListarPreSolicitudId(int idPreSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarPreSolicitudidPreSolicitud_SP", idPreSolicitud);
        }

        public DataTable ADInsertarPreSolicitud(int idEstado, decimal nMontoSolicitado, int nCuotas, int nPlazoCuota, int idTipoPeriodo, int idTipoDocumento,
                                              int idTipoCaptacion, int idCli, int idMoneda, string cDocumento, string cNombreCompleto, string cApellidoPaterno,
            string cApellidoMaterno, string cNombre, string nNumeroTelefono, string cNumeroTelefono2, int idAgencia, DateTime dFechaRegistro, int idUsuario,
            int idUbigeo,string cDireccion, string cObservaciones)
        {
            return objEjeSp.EjecSP("CRE_InsertarPreSolicitud_SP", idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo, idTipoDocumento,
                                              idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto, cApellidoPaterno,
            cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario,idUbigeo, cDireccion, cObservaciones);
        }

        public DataTable ADActualizarPreSolicitud(int idPreSolicitud, int idEstado, decimal nMontoSolicitado, int nCuotas, int nPlazoCuota, int idTipoPeriodo, int idTipoDocumento,
                                              int idTipoCaptacion, int idCli, int idMoneda, string cDocumento, string cNombreCompleto, string cApellidoPaterno,
            string cApellidoMaterno, string cNombre, string nNumeroTelefono, string cNumeroTelefono2, int idAgencia, DateTime dFechaRegistro, int idUsuario, 
            int idUbigeo, string cDireccion, string cObservaciones)
        {
            return objEjeSp.EjecSP("CRE_ActualizarPreSolicitud_SP",idPreSolicitud, idEstado, nMontoSolicitado, nCuotas, nPlazoCuota, idTipoPeriodo, idTipoDocumento,
                                              idTipoCaptacion, idCli, idMoneda, cDocumento, cNombreCompleto, cApellidoPaterno,
            cApellidoMaterno, cNombre, nNumeroTelefono, cNumeroTelefono2, idAgencia, dFechaRegistro, idUsuario, idUbigeo, cDireccion, cObservaciones);
        }

        public DataTable ADBuscarPreSolicitud(int idTipoDocumento, string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_BuscarPreSolicitud_SP", idTipoDocumento, cDocumento);
        }
    }
}
