using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAJ.AccesoDatos;
using System.Xml.Linq;
namespace CAJ.CapaNegocio
{
    public class clsCNMovimientoBanco
    {
        //=============================================================
        // listar estados de las cuentas en instituciones financieras
        //=============================================================
        public DataTable listarEstadoCuenta()
        {
           // return new clsADMovimientoBanco().listarEstadoCuenta();
           var dt = new clsADMovimientoBanco().listarEstadoCuentaXml();

            DataTable dtMovimientoBanco = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtMovimientoBanco, LoadOption.OverwriteChanges);

            return dtMovimientoBanco;
             
        }

        //=============================================================
        // Crear metodo para grabar las cuentas de las instituciones
        //=============================================================
        public DataTable grabarCuentaInstitucion(int idCuentaInst, int idEntidad, int idAgencia, int idTipoCuentaInst,
                                                 String cNumeroCuenta, String cDescripcionCuenta, int idMoneda,
                                                DateTime dFechaApertura, decimal nTEA, int nFactorInteres,
                                                int nPlazo, String cCuentaContable, int idEstado, DateTime dFechaCancelacion)
        {

            return new clsADMovimientoBanco().grabarCuentaInstitucion(idCuentaInst, idEntidad, idAgencia, idTipoCuentaInst,
                                                cNumeroCuenta, cDescripcionCuenta, idMoneda,
                                                dFechaApertura, nTEA, nFactorInteres,
                                                nPlazo, cCuentaContable, idEstado, dFechaCancelacion);



        }
        //=============================================================
        // Crear metodo listar las cuentas de las instituciones
        //=============================================================
        public DataTable listarCuentas(string idAgencia, string idTipoEntidad, string idEntidad,
                                      string idTipoCuenta, string cNumeroCuenta)
        {
            return new clsADMovimientoBanco().BuscarCuentas(idAgencia, idTipoEntidad, idEntidad,
                                    idTipoCuenta, cNumeroCuenta);
        }

        //=============================================================
        // Crear metodo guardar talonario de una institucion
        //=============================================================
        public DataTable GuardarChequeBco(int idChequeBco, int idCuentaInst,
                                      int nNroInicial, int nCantCheques, int nNroFinal)
        {
            return new clsADMovimientoBanco().GuardarChequeBco(idChequeBco, idCuentaInst,
                                    nNroInicial, nCantCheques, nNroFinal);
        }

        //=============================================================
        // Crear metodo verificar la existencia y estado de un talonario
        //=============================================================

        public DataTable VerificarExisteTalonario(int idCuentaInst)
        {
            return new clsADMovimientoBanco().VerificarExisteTalonario(idCuentaInst);
        }

        //=============================================================
        // Crear metodo listar cheques de institucion
        //=============================================================

        public DataTable ListarCheques(int idCuentaInst, int idChequeBco, int idEstadoCheque)
        {
            return new clsADMovimientoBanco().ListarCheques(idCuentaInst,idChequeBco, idEstadoCheque);
        }

        //=============================================================
        //--Emite cheque de la institucion seleccionada
        //=============================================================

        public DataTable EmitirCheque(int idChequeBco, int nNroCheque, DateTime dFechaEmision, int idCliente,
                                      string cNroDocCli, string cApNomCli, string CDireccionCli, int idMotOperBco,
                                        string cDescMot, decimal nMonto, int idEstadoCheque, int idComprobantePago,
                                        int idUsuario, int idAgencia, int x_idMoneda)
        {
            return new clsADMovimientoBanco().EmitirCheque(idChequeBco, nNroCheque, dFechaEmision, idCliente,
                                                           cNroDocCli, cApNomCli, CDireccionCli, idMotOperBco,
                                                           cDescMot, nMonto, idEstadoCheque, idComprobantePago,
                                                           idUsuario, idAgencia, x_idMoneda);
        }

        //=============================================================
        //--Valoriza los cheques seleccionados
        //=============================================================

        public DataTable ValorizarCheque(string xmlMovCheque, string xmlDetCheque, DateTime dFechaOpe ,int idUsuario ,
                                         int idAgeSaldo ,int idAgeOpera ,int idMoneda )
        {
            return new clsADMovimientoBanco().ValorizarCheque(xmlMovCheque, xmlDetCheque, dFechaOpe, idUsuario,
                                                                idAgeSaldo, idAgeOpera, idMoneda);
        }   
        //=============================================================
        // listar movimientos de las instituciones financieras
        //=============================================================
        public DataTable listarMovimientos(int idEntidad, string cNumeroCuenta, DateTime dFechaIni, DateTime dFechaFin, Boolean lFiltraFecha)
        {
            try
            {
                return new clsADMovimientoBanco().listarMovimientos(idEntidad, cNumeroCuenta, dFechaIni, dFechaFin, lFiltraFecha);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
      
        //=============================================================
        // Crear metodo para grabar las cuentas de las instituciones
        //=============================================================
        public DataTable grabarMovimientoBancos(string stgMovBco, DateTime dFechaOpe ,int idUsuario ,int idAgeSaldo,
                                                int idAgeOpera ,int idMoneda )         
        {
            try
            {
                return new clsADMovimientoBanco().grabarMovimientoBancos(stgMovBco, dFechaOpe, idUsuario, idAgeSaldo,
                                                                         idAgeOpera, idMoneda);                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        //=============================================================
        // extornar movimiento de bancos
        //=============================================================
        public DataTable ExtornarMovimientoBancos(int idMovimiento, int idCuentaInstitucion, decimal nMontoOpe)
        {
            try
            {
                return new clsADMovimientoBanco().ExtornarMovimientoBancos(idMovimiento, idCuentaInstitucion, nMontoOpe);
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
        //=============================================================
        // Crear metodo para Listar los tipo de operaciones bancos
        //=============================================================
        public DataTable CNListarTiposIdentificadosBanco()
        {
            try
            {
                return new clsADMovimientoBanco().ListarTipoidentificadOSBanco();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        

        //=============================================================
        // Crear metodo para listar Tipo de Documento del banco
        //=============================================================
        public DataTable ListarTipoDocumentoBanco()
        {
            try
            {
                return new clsADMovimientoBanco().ListarTipoDocumentoBanco();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        //=============================================================
        // Crear metodo para grabar las trasferencias bancarias
        //=============================================================
        public DataTable grabarTransferencia(string xmlTransferencia, DateTime dFechaOpe ,int idUsuario ,int idAgeSaldo,
                                            int idAgeOpera ,int idMoneda)
        {
            try
            {
                return new clsADMovimientoBanco().grabarTransferencia(xmlTransferencia,dFechaOpe, idUsuario, idAgeSaldo,
                                                                        idAgeOpera, idMoneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarTransferencia(int idCuentaOrigen,string cNroCuentaOrigen)
        {
            try
            {
                return new clsADMovimientoBanco().ListarTransferencia(idCuentaOrigen, cNroCuentaOrigen);
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
        //=============================================================
        // extornar movimiento de bancos pertenecientes a trasferencias
        //=============================================================
        public DataTable ExtornarTransferenciaBancos(int idTrasferencia, int idMovOri, int idMovDes)
        {
            try
            {
                return new clsADMovimientoBanco().ExtornarTransferenciaBancos(idTrasferencia, idMovOri, idMovDes);
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        //=============================================================
        // Listar fechas de Cierre de Bancos procesados
        //=============================================================
        public DataTable ListarPeriodosProcCierreBcos()
        {
            try
            {
                return new clsADMovimientoBanco().ListarPeriodosProcCierreBcos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //=============================================================
        // Retornar la Fecha de Cierre de Bancos
        //=============================================================
        public DataTable RetornarFecUltCierreBco()
        {
            try
            {
                return new clsADMovimientoBanco().RetornarFecUltCierreBco();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //=============================================================
        // Retornar los datos del Cierre de Bancos
        //=============================================================
        public DataTable RetornarDatosCierreBcos(DateTime dFecCierre)
        {
            try
            {
                return new clsADMovimientoBanco().RetornarDatosCierreBcos(dFecCierre);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //=============================================================
        // Graba el cierre de Bancos
        //=============================================================
        public DataTable CierreBancos(DateTime dFecCierre)
        {
            try
            {
                return new clsADMovimientoBanco().CierreBancos(dFecCierre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============================================================
        // Listado de instituciones del periodo de cierre de Bancos
        //=============================================================
        public DataTable ListInstPeriodCierreBco(DateTime dFecCierre)
        {
            try
            {
                return new clsADMovimientoBanco().ListInstPeriodCierreBco(dFecCierre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Convertir a Xml
        //=============================================================
        // Convertir Movimientos a Xml
        //=============================================================
        public string convertMovimientoXml(int idMovimiento, int idCuentaInstitucion, int idMotOpeBanco, int idTipOpeMovBco, int idTipMedPago, decimal nMontoOpera,
            int idTipoOperaBco, int idTipoDestino, int idCliente, string cDescripcion, DateTime dfechaOpe, int idTipoDocumento, string cNroDocumento, int nTipMovCapInt, int idTipoPago, string cNroOperConciliaBco)
        {


            string cxml = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "no"),
                          new XElement("dsmovbco",
                                          new XElement("tabla",
                                                              new XElement("idMovimiento", idMovimiento),
                                                              new XElement("idCuentaInstitucion", idCuentaInstitucion),
                                                              new XElement("idMotOpeBanco", idMotOpeBanco),
                                                              new XElement("idTipOpeMovBco", idTipOpeMovBco),
                                                              new XElement("idTipMedPago", idTipMedPago),                                           
                                                              new XElement("nMontoOpera", nMontoOpera),
                                                              new XElement("idTipoOpera", idTipoOperaBco),
                                                              new XElement("idTipoDestino", idTipoDestino),
                                                              new XElement("idCliente", idCliente),
                                                              new XElement("cDescripcion", cDescripcion),
                                                              new XElement("dfechaOpe", dfechaOpe),
                                                              new XElement("idTipoDocumento", idTipoDocumento),
                                                              new XElement("cNroDocumento", cNroDocumento),
                                                              new XElement("nTipMovCapInt", nTipMovCapInt),
                                                              new XElement("idTipoPago", idTipoPago),
                                                              new XElement("cNroOperConciliaBco", cNroOperConciliaBco)
                                                              ))).ToString();
            return cxml;
        }
        //=============================================================
        // Convertir trasferenias a Xml
        //=============================================================
        public string convertTransferenciaXml(int idCuentaInstOri,  int idCuentaInstDes, int idMotOpeBanco, int idMoneda, decimal nMontoOpera, string cDescripcion, DateTime dfechaOpe)
        {            
            string cxml = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "no"),
                          new XElement("dsTransBco",
                                          new XElement("Tabla",
                                                              new XElement("idCuentaInstOri", idCuentaInstOri),
                                                              new XElement("idCuentaInstDes", idCuentaInstDes),
                                                              new XElement("idMotOpeBanco", idMotOpeBanco),
                                                              new XElement("idMoneda", idMoneda),
                                                              new XElement("nMontoOpera", nMontoOpera),
                                                              new XElement("cDescripcion", cDescripcion),
                                                              new XElement("dfechaOpe", dfechaOpe)
                                                              ))).ToString();
            return cxml;
        }
        //============================================================================
        // Crear metodo para Listar los tipos de operacion en operaciones bancos
        //============================================================================
        public DataTable listarTipoOperMovBanco()
        {
            try
            {
                return new clsADMovimientoBanco().listarTipoOperMovBanco();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion

        //=============================================================
        // Listado de instituciones del periodo de cierre de Bancos
        //=============================================================
        public DataTable CNTransMovBco(string cMovBco)
        {
            try
            {
                return new clsADMovimientoBanco().ADTransMovBco(cMovBco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
