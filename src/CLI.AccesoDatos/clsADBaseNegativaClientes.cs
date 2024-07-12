using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADBaseNegativaClientes
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarClientesBaseNegativa(int idModulo, int idBaseNegativa)
        {
            return objEjeSp.EjecSP("CLI_ListarClientesBaseNegativa_SP", idModulo, idBaseNegativa);
        }

        public DataTable ADInsertarClienteBaseNegativa(int idModulo, int idCli, int idTipoPersona, int idTipoDocumento, string cDocumentoID,
                                                       string cNombre, string cApPaterno, string cApMaterno, string cRazonSocial,string cDescripcion, 
                                                        int idMotivoBloq,int idSolCred, DateTime dFechaReg, int idUsuarioReg)
        {
            return objEjeSp.EjecSP("CLI_InsertarClienteBaseNegativa_SP", idModulo, idCli, idTipoPersona, idTipoDocumento, cDocumentoID,
                                                                         cNombre, cApPaterno, cApMaterno, cRazonSocial, cDescripcion,
                                                                         idMotivoBloq, idSolCred, dFechaReg, idUsuarioReg);
        }

        public DataTable ADEliminarClienteBaseNegativa(int idBaseNegativa, DateTime dFechaMod, int idUsuarioMod, int x_idSolApr)
        {
            return objEjeSp.EjecSP("CLI_EliminarClienteBaseNegativa_SP", idBaseNegativa, dFechaMod, idUsuarioMod, x_idSolApr);
        }

        public DataTable ADRegPersonaBaseNegativa(int idUsuario,DateTime dFechaReg, string xmlDatosPerBN)
        {
            return objEjeSp.EjecSP("CLI_RegPersonaBaseNegativa_SP", idUsuario,dFechaReg, xmlDatosPerBN);
        }

        public DataTable ADEnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                        int idUsuario, int lExcepcion, int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSp.EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, lExcepcion, idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }

        public DataTable ADRegSolicitudDesbloqPersonaBN(int idCli, int idTipoPersona, int idTipoDocumento, string cNroDocumento, string cNombre, int xidBaseNegativa)
        {
            return objEjeSp.EjecSP("CLI_RegSolicitudDesbloqPersonaBN_SP", idCli, idTipoPersona, idTipoDocumento, cNroDocumento, cNombre, xidBaseNegativa);
        }

        public DataTable ADObtenerEstadoSolAproPersonaBN(int x_idBaseNeg, int x_idAgencia, DateTime x_dFecha)
        {
            return objEjeSp.EjecSP("CLI_ObtenerEstSolAproPersonaBN_SP", x_idBaseNeg, x_idAgencia, x_dFecha);
        }

        public DataTable ADValidaBaseNegativa(string xmlDatosPerBN)
        {
            return objEjeSp.EjecSP("CLI_ValidaBaseNegativa_SP", xmlDatosPerBN);
        }

        public DataTable ADActualizarClienteBaseNegativa(int idBaseNegativa, string cNombre, string cApPaterno, string cApMaterno,
                                                        string cRazonSocial, string cDescripcion, int idMotivoBloq, DateTime dFechaReg, int idUsuarioReg, int idModulo)
        {
            return objEjeSp.EjecSP("CLI_ActualizaClienteBaseNegativa_SP", idBaseNegativa, cNombre, cApPaterno, cApMaterno,
                                                                    cRazonSocial, cDescripcion, idMotivoBloq, dFechaReg, idUsuarioReg, idModulo);
        }
    }
}
