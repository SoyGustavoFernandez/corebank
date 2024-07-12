using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;

namespace CLI.CapaNegocio
{
    public class clsCNBaseNegativaClientes
    {
        clsADBaseNegativaClientes objBaseNegativa = new clsADBaseNegativaClientes();

        public DataTable CNListarClientesBaseNegativa(int idModulo, int idBaseNegativa)
        {
            return objBaseNegativa.ADListarClientesBaseNegativa(idModulo, idBaseNegativa);
        }

        public DataTable CNInsertarClienteBaseNegativa(int idModulo, int idCli, int idTipoPersona, int idTipoDocumento, string cDocumentoID,
                                                       string cNombre, string cApPaterno, string cApMaterno, string cRazonSocial, string cDescripcion,
                                                        int idMotivoBloq,int idSolCred, DateTime dFechaReg, int idUsuarioReg)
        {
            return objBaseNegativa.ADInsertarClienteBaseNegativa(idModulo, idCli, idTipoPersona, idTipoDocumento, cDocumentoID,
                                                                 cNombre, cApPaterno, cApMaterno, cRazonSocial, cDescripcion,
                                                                 idMotivoBloq, idSolCred, dFechaReg, idUsuarioReg);
        }

        public DataTable CNEliminarClienteBaseNegativa(int idBaseNegativa, DateTime dFechaMod, int idUsuarioMod, int x_idSolApr)
        {
            return objBaseNegativa.ADEliminarClienteBaseNegativa(idBaseNegativa, dFechaMod, idUsuarioMod, x_idSolApr);
        }

        public DataTable CNRegPersonaBaseNegativa(int idUsuario, DateTime dFechaReg, string xmlDatosPerBN)
        {
            return objBaseNegativa.ADRegPersonaBaseNegativa(idUsuario,dFechaReg, xmlDatosPerBN);
        }

        public DataTable CNEnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                        int idUsuario, int lExcepcion)
        {
            return objBaseNegativa.ADEnviarSolicitud(idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, lExcepcion);
        }

        public DataTable CNRegSolicitudDesbloqPersonaBN(int idCli, int idTipoPersona, int idTipoDocumento, string cNroDocumento, string cNombre,int xidBaseNegativa)
        {
            return objBaseNegativa.ADRegSolicitudDesbloqPersonaBN(idCli, idTipoPersona, idTipoDocumento, cNroDocumento, cNombre, xidBaseNegativa);
        }

        public DataTable CNObtenerEstadoSolAproPersonaBN(int x_idBaseNeg,int x_idAgencia,DateTime x_dFecha)
        {
            return objBaseNegativa.ADObtenerEstadoSolAproPersonaBN(x_idBaseNeg, x_idAgencia, x_dFecha);
        }

        public DataTable CNValidaBaseNegativa(string xmlDatosPerBN)
        {
            return objBaseNegativa.ADValidaBaseNegativa(xmlDatosPerBN);
        }

        public DataTable CNActualizarClienteBaseNegativa(int idBaseNegativa,string cNombre, string cApPaterno, string cApMaterno,
                                                        string cRazonSocial, string cDescripcion, int idMotivoBloq, DateTime dFechaReg, int idUsuarioReg, int idModulo)
        {
            return objBaseNegativa.ADActualizarClienteBaseNegativa(idBaseNegativa, cNombre, cApPaterno, cApMaterno,
                                                                    cRazonSocial, cDescripcion, idMotivoBloq, dFechaReg, idUsuarioReg, idModulo);
        }
    }
}
