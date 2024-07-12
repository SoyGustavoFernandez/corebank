#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using CRE.AccesoDatos;
using GEN.Funciones;
#endregion

namespace CRE.CapaNegocio
{
    public class clsCNCreditoCargaSeguro
    {
        #region Variables Globales
        private clsADCreditoCargaSeguro objADCreditoCargaSeguro { get; set; }
        #endregion

        #region Constructores
        public clsCNCreditoCargaSeguro()
        {
            objADCreditoCargaSeguro = new clsADCreditoCargaSeguro();
        }
        #endregion

        #region Metodos
        public List<clsSolicitudCreditoSeguro> CNObtenerSolicitudSeguroTipo(int idSolicitud)
        {
            DataTable dtSolicitudCreditoSeguro = objADCreditoCargaSeguro.ADObtenerSolicitudSeguroTipo(idSolicitud);

            return (dtSolicitudCreditoSeguro.Rows.Count > 0) ? dtSolicitudCreditoSeguro.ToList<clsSolicitudCreditoSeguro>() as List<clsSolicitudCreditoSeguro>: new List<clsSolicitudCreditoSeguro>();
        }

        public clsSolicitudCreditoCargaSeguro CNObtenerSolicitudCargaSeguro(int idSolicitud)
        {
            clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
            List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
            DataSet dsSolicitudCreditoSeguro = objADCreditoCargaSeguro.ADObtenerSolicitudCargaSeguro(idSolicitud);

            objSolicitudCreditoCargaSeguro      = (dsSolicitudCreditoSeguro.Tables[0].Rows.Count > 0) ? dsSolicitudCreditoSeguro.Tables[0].ToList<clsSolicitudCreditoCargaSeguro>()[0] : new clsSolicitudCreditoCargaSeguro();
            lstSolicitudCreditoSeguro           = (dsSolicitudCreditoSeguro.Tables[1].Rows.Count > 0) ? dsSolicitudCreditoSeguro.Tables[1].ToList<clsSolicitudCreditoSeguro>() as List<clsSolicitudCreditoSeguro> : new List<clsSolicitudCreditoSeguro>();
            objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro = lstSolicitudCreditoSeguro;

            return objSolicitudCreditoCargaSeguro;
        }

        public DataTable CNRegistrarSolicitudCreditoSeguro(int idSolicitud, string xmlSolicitudCreditoSeguro, int idUsuario, DateTime dFechaSistema)
        {
            return objADCreditoCargaSeguro.ADRegistrarSolicitudCreditoSeguro(idSolicitud, xmlSolicitudCreditoSeguro, idUsuario, dFechaSistema);
        }

        public DataTable CNRegistroListaSeguroCredito(int idSolicitud, string xmlCreditoSeguro, int idUsuario, DateTime dFechaSistema)
        {
            return objADCreditoCargaSeguro.ADRegistroListaSeguroCredito(idSolicitud, xmlCreditoSeguro, idUsuario, dFechaSistema );
        }

        public List<clsCreditoSeguro> CNObtenerListaCreditoSeguro(int idSolicitud)
        {
            DataTable dtCreditoSeguro = objADCreditoCargaSeguro.ADObtenerListaCreditoSeguro(idSolicitud);

            return (dtCreditoSeguro.Rows.Count > 0) ? dtCreditoSeguro.ToList<clsCreditoSeguro>() as List<clsCreditoSeguro> : new List<clsCreditoSeguro>();
        }

        public DataTable CNObtenerDatosUsuarioZona(int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosUsuarioZona(idUsuario);
        }

        public DataTable CNObtenerListaUsuarioSeguro(int idZona, int idAgencia, DateTime dFechaDesde, DateTime dFechaHasta, int idTipoSeguro)
        {
            return objADCreditoCargaSeguro.ADObtenerListaUsuarioSeguro(idZona, idAgencia, dFechaDesde, dFechaHasta, idTipoSeguro);
        }

        public DataTable CNObtenerDatosRPTSeguimientoSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTSeguimientoSeguroMultiriesgo(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNObtenerDatosRPTSolicitudes(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idEstab, string cEstados)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTSolicitudes(dFechaDesde, dFechaHasta, idZona, idAgencia, idEstab, cEstados);
        }

        public DataTable CNObtenerDatosRPTSolicitudesTasa(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idEstab, string cEstados, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTSolicitudesTasa(dFechaDesde, dFechaHasta, idZona, idAgencia, idEstab, cEstados, idUsuario);
        }
        public DataTable CNListarEstadosSolicitud(string cEstados)
        {
            return objADCreditoCargaSeguro.ADListarEstadosSolicitud(cEstados);
        }
        public DataTable CNListarEstadosSolicitudTasa()
        {
            return objADCreditoCargaSeguro.ADListarEstadosSolicitudTasa();
        }
        public DataTable CNObtenerDatosRPTSeguimientoSeguroVida(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTSeguimientoSeguroVida(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNObtenerRecibosVinculadoCuenta(int idCuenta)
        {
            return objADCreditoCargaSeguro.ADObtenerRecibosVinculadoCuenta(idCuenta);
        }

        public DataTable CNObtenerDatosRPTResumenSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTResumenSeguroMultiriesgo(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNObtenerDatosRPTResumenSeguroVida(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTResumenSeguroVida(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNVerificarProductoTipoSeguro(int idProducto)
        {
            return objADCreditoCargaSeguro.ADVerificarProductoTipoSeguro(idProducto);
        }
       
        public DataTable CNVerificarConfiguracionSeguro(int idProducto, int idPerfil, int idAgencia)
        {
            return objADCreditoCargaSeguro.ADVerificarConfiguracionSeguro(idProducto, idPerfil, idAgencia);
        }

        public DataTable CNVerificarConfiguracionSeguroActivos(int idSolicitud, int idProducto, int idPerfil, int idAgencia)
        {
            return objADCreditoCargaSeguro.ADVerificarConfiguracionSeguroActivos(idSolicitud, idProducto, idPerfil, idAgencia);
        }

        public DataTable CNObtenerDatosRPTResumenSeguroAgricola(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTResumenSeguroAgricola(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNObtenerDatosRPTSeguimientoSeguroAgricola(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerDatosRPTSeguimientoSeguroAgricola(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNValidarActaulizarDesgravamenEspecial(int idSolicitud, decimal nMontoAprobado)
        {
            return objADCreditoCargaSeguro.ADValidarActaulizarDesgravamenEspecial(idSolicitud, nMontoAprobado);
        }

        public DataTable CNValidarSeguros(int idCli, string cTipoSeguroXml, int nMesesCobertura, int idOperacion)
        {
            return objADCreditoCargaSeguro.ADValidarSeguros(idCli, cTipoSeguroXml, nMesesCobertura, idOperacion);
        }

        public DataTable CNValidarSeguroOncologico(int idCli, int nMesesCobertura, int idSolicitud)
        {
            return objADCreditoCargaSeguro.ADValidarSeguroOncologico(idCli, nMesesCobertura, idSolicitud);
        }

        /// <summary>
        /// Retorna la informacion para desafiliar un seguro multiriesgo
        /// </summary>
        /// <param name="idCli">Id del cliente</param>
        /// <returns>Una lista de clsCancelarSeguroMultiriesgo</returns>
        public List<clsDesafiliarSeguroMultiriesgo> CNConsultaDesafiliacionSeguroMultiriesgo(int idCli)
        {
            return objADCreditoCargaSeguro.ADConsultaDesafiliacionSeguroMultiriesgo(idCli);
        }

        /// <summary>
        /// Desafilia un seguro multiriesgo
        /// </summary>
        /// <param name="idSeguroMultiriesgo">Identificador del seguro multiriesgo</param>
        /// <param name="idUsuario">Identificar del usuario que realiza la desafiliacion</param>
        /// <param name="dFechaSistema">Fecha del sistema para guardar la fecha de desafiliacion</param>
        /// <returns>Una respuesta clsDBResp</returns>
        ///
        public clsDBResp CNDesafiliarSeguroMultiriesgo(int idSeguroMultiriesgo, int idUsuario, DateTime dFechaSistema)
        {
            return objADCreditoCargaSeguro.ADDesafiliarSeguroMultiriesgo(idSeguroMultiriesgo, idUsuario, dFechaSistema);
        }

        /// <summary>
        /// Consulta informacion para el reporte de seguro multiriesgo
        /// </summary>
        /// <param name="dFechaDesde">Fecha desde</param>
        /// <param name="dFechaHasta">Fecha hasta</param>
        /// <param name="idZona">Id de la zona. Puede ser 0</param>
        /// <param name="idAgencia">Id de la agencia. Puede ser 0</param>
        /// <param name="idUsuario">Id del usuario. Puede ser 0</param>
        /// <param name="idEstadoSeguroMultiriesgo">id del estado de seguro multiriesgo. Puede ser 0</param>
        /// <returns></returns>
        public DataTable CNConsultaSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario, int idEstadoSeguroMultiriesgo)
        {
            return objADCreditoCargaSeguro.ADConsultaSeguroMultiriesgo(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario, idEstadoSeguroMultiriesgo);
        }

        /// <summary>
        /// Lista los estados del seguro multiriesgo
        /// </summary>
        /// <returns>Un datatable</returns>
        public DataTable CNListarEstadoSeguroMultiriesgo()
        {
            return objADCreditoCargaSeguro.ADListarEstadoSeguroMultiriesgo();
        }
        public DataTable CNObtenerListaSegurosCliente(int idCliente)
        {
            return objADCreditoCargaSeguro.ADObtenerListaSegurosCliente(idCliente);
        }

        /// <summary>
        /// Obtiene la fecha de cobertura de seguro multiriesgo dado un idCuenta de credito
        /// </summary>
        /// <param name="idCuenta">Idcuenta de credito</param>
        /// <returns>Fecha</returns>
        public DateTime? CNObtenerFechaCoberturaSeguroMultiriesgo(int idCuenta, int idTipoPeriodo)
        {
            return objADCreditoCargaSeguro.ADObtenerFechaCoberturaSeguroMultiriesgo(idCuenta, idTipoPeriodo);
        }

        public clsSolicitudCreditoSeguro CNObtenerSolicitudCreditoSeguroPreliminar(int idSolicitud, int idTipoSeguro, DateTime dFechaSistema, int idUsuario)
        {
            return objADCreditoCargaSeguro.ADObtenerSolicitudCreditoSeguroPreliminar(idSolicitud, idTipoSeguro, dFechaSistema, idUsuario);
        }

        /// <summary>
        /// Retorna la informacion para desafiliar un paquete de seguro
        /// </summary>
        /// <param name="idCli">Id del cliente</param>
        /// <returns>Una lista de clsDesafiliarPaqueteSeguro</returns>
        public List<clsDesafiliarPaqueteSeguro> CNConsultaDesafiliacionPaqueteSeguro(int idCli)
        {
            return objADCreditoCargaSeguro.ADConsultaDesafiliacionPaqueteSeguro(idCli);
        }

        /// <summary>
        /// Desafilia un paquete de seguro
        /// </summary>
        /// <param name="idSeguroOpcional">Identificador del seguro opcional</param>
        /// <param name="idUsuario">Identificador del usuario que realiza la desafiliacion</param>
        /// <param name="dFechaSistema">Fecha del sistema para guardar la fecha de desafiliacion</param>
        /// <returns>Una respuesta clsDBResp</returns>
        ///
        public clsDBResp CNDesafiliarSeguroOpcional(int idSeguroOpcional, int idUsuario, DateTime dFechaSistema)
        {
            return objADCreditoCargaSeguro.ADDesafiliarSeguroOpcional(idSeguroOpcional, idUsuario, dFechaSistema);
        }

        /// <summary>
        /// Retorna el reporte de altas de paquetes de seguro
        /// </summary>
        /// <param name="dFechaDesde">Fecha desde</param>
        /// <param name="dFechaHasta">Fecha hasta</param>
        /// <returns>Datatable con la info del reporte</returns>
        public DataTable CNConsultaPaqueteSeguroAlta(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objADCreditoCargaSeguro.ADConsultaPaqueteSeguroAlta(dFechaDesde, dFechaHasta);
        }

        /// <summary>
        /// Retorna el reporte de bajas de paquetes de seguro
        /// </summary>
        /// <param name="dFechaDesde">Fecha desde</param>
        /// <param name="dFechaHasta">Fecha hasta</param>
        /// <returns>Datatable con la info del reporte</returns>
        public DataTable CNConsultaPaqueteSeguroBaja(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objADCreditoCargaSeguro.ADConsultaPaqueteSeguroBaja(dFechaDesde, dFechaHasta);
        }

        /// <summary>
        /// Retorna el reporte de cobros de paquetes de seguro
        /// </summary>
        /// <param name="dFechaDesde">Fecha desde</param>
        /// <param name="dFechaHasta">Fecha hasta</param>
        /// <returns>Datatable con la info del reporte</returns>
        public DataTable CNConsultaPaqueteSeguroCobro(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objADCreditoCargaSeguro.ADConsultaPaqueteSeguroCobro(dFechaDesde, dFechaHasta);
        }

        /// <summary>
        /// Valida si aplica seguro multirriesgo nuevo.
        /// </summary>
        /// <param name="idSolicitud">Idcuenta de credito</param>
        /// <returns>Fecha</returns>
        public bool CNValidaNuevoSeguroMultiriesgo(int idSolicitud)
        {
            return objADCreditoCargaSeguro.ADOValidaNuevoSeguroMultiriesgo(idSolicitud);
        }

        public DataTable CNObtenerPromotorInicialSeguro(int idSolicitud, int idTipoSeguro)
        {
            return objADCreditoCargaSeguro.ADObtenerPromotorInicialSeguro(idSolicitud, idTipoSeguro);
        }

        public DataTable CNActualizarEstadoSolicitudCreditoSeguro(int idSolicitud, int idUsuario, DateTime dFechaSistema)
        {
            return objADCreditoCargaSeguro.ADActualizarEstadoSolicitudCreditoSeguro(idSolicitud, idUsuario, dFechaSistema);
        }

        public DataTable CNRegistrarSustentoDesmarcado(string lstSegurosDesmarcadosXML)
        {
            return objADCreditoCargaSeguro.CNRegistrarSustentoDesmarcado(lstSegurosDesmarcadosXML);
        }

        public clsSolicitudCreditoSeguro CNObtenerSeguroIndividual(int idSolicitudCreditoSeguro)
        {
            return objADCreditoCargaSeguro.CNObtenerSeguroIndividual(idSolicitudCreditoSeguro);
        }

        public clsDBResp CNEnvioCorreosSeguroDesmarcados(List<string> cDestinatario, string cAsunto, string cMensaje)
        {
            string cDestinatarioSTR = string.Join(";", cDestinatario);
            return objADCreditoCargaSeguro.CNEnvioCorreosSeguroDesmarcados(cDestinatarioSTR, cAsunto, cMensaje); ;
        }

        public string CNObtenerCorreoUsuarioSolicitud(int idSolicitud)
        {
            return objADCreditoCargaSeguro.ADObtenerCorreoUsuarioSolicitud(idSolicitud); ;
        }

		 public bool CNValidaNuevoPaqueteSeguro(int idSolicitud)
        {
            return objADCreditoCargaSeguro.ADOValidaNuevoPaqueteSeguro(idSolicitud);
        }

        #endregion
    }
}
