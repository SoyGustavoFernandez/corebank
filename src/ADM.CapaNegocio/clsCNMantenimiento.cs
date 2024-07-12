using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;
namespace ADM.CapaNegocio
{
    public class clsCNMantenimiento
    {
        clsADMantenimientos objMantenimiento = new clsADMantenimientos();

        public clsCNMantenimiento(bool cConex)
        {
            objMantenimiento = new clsADMantenimientos(cConex);
        }

        public clsCNMantenimiento()
        {
            objMantenimiento = new clsADMantenimientos();
        }

        #region variables
        public DataTable ListarTipodeDatos()
        {
            return objMantenimiento.ADlistarTipoDatos();
        }
        public DataTable CNRecuperarVariable(string cVariable)
        {
            return objMantenimiento.ADRecuperarVariable(cVariable);
        }
        public DataTable ListarVariables(int idAgencia)
        {
            return objMantenimiento.ADlistarVariable(idAgencia);
        }
        public DataTable GrabarVariables(int idVariable, string cVariable, string cDescripcion,
            string cTipoVariable, string cValVar, bool lVigente, int idAgencia, bool lCargaVarApl)
        {
            return objMantenimiento.ADGrabarTipoDatos(idVariable, cVariable, cDescripcion,
               cTipoVariable, cValVar, lVigente, idAgencia, lCargaVarApl);
        }

        //Variables de crédito
        public DataTable CNListarAgenciaVariablesCredito()
        {
            return objMantenimiento.ADListarAgenciaVariablesCredito();
        }
        public DataTable CNListarVariablesTasa(int idAgencia)
        {
            return objMantenimiento.ADlistarVariableTasa(idAgencia);
        }
        public DataTable CNGrabarVariablesCredito(int idVariable, string cVariable, string cDescripcion,
        string cTipoVariable, string cValVar, bool lVigente, int idAgencia, bool lCargaVarApl, int idUsuario, DateTime dFecha, int idAgenciaUs)
        {
            return objMantenimiento.ADGrabarTipoDatosCredito(idVariable, cVariable, cDescripcion,
               cTipoVariable, cValVar, lVigente, idAgencia, lCargaVarApl, idUsuario, dFecha, idAgenciaUs);
        }
        public DataTable CNActualizarValorVariables(string cVariable, string cValVar)
        {
            return objMantenimiento.ADActualizarValorVariables(cVariable, cValVar);
        }
        #endregion

        #region perfiles
        public DataTable ListarPerfiles()
        {
            return objMantenimiento.ADlistarPerfiles();
        }
        public DataTable GrabarPerfiles(int idPerfil, string cPerfil, string cDescripcion, bool lVigente, bool lLimCobertura)
        {
            return objMantenimiento.ADGrabarPerfiles(idPerfil, cPerfil, cDescripcion, lVigente, lLimCobertura);
        }
        #endregion

        #region agencias
        public DataTable ListarTipoDeOficina()
        {
            return objMantenimiento.ADlistarTipoOficina();
        }

        public DataTable ListarAgencias()
        {
            return objMantenimiento.ADlistarMantAgencias();
        }

        public int GrabarManAgencias(int idAgencia, string cNombreAge, string cNomCorto, int idUbigeo,
                                             string cDirección, string cRefDirec, string cFono, bool lEstado,
                                             string cCodSBS, int idTipoOficina, DateTime dFechaAprob, string cResolucion,
                                             string dtAreas, string dtEstablecimientos, int idTipEsquemaCaja)

        {
            DataTable dtResul = objMantenimiento.ADGrabarMantAgencias(idAgencia, cNombreAge, cNomCorto, idUbigeo,
                                                        cDirección, cRefDirec, cFono, lEstado,
                                                        cCodSBS, idTipoOficina, dFechaAprob, cResolucion,
                                                        dtAreas, dtEstablecimientos, idTipEsquemaCaja);

            int idRetorno = Convert.ToInt32(dtResul.Rows[0][0]);
            return idRetorno;
        }

        public DataTable CNGeneraCtasContablesAgencia(int idAgencia)
        {
            return objMantenimiento.ADGeneraCtasContablesAgencia(idAgencia);
        }

        public DataTable ListarAreas(int idAgencia)
        {
            return objMantenimiento.ListarAreas(idAgencia);
        }
        public DataTable ListarEstablecimiento(int idAgencia)
        {
            return objMantenimiento.ListarEstablecimiento(idAgencia);
        }
        public DataTable ListarTiposMovimiento(int idAgencia)
        {
            return objMantenimiento.ListarTiposMovimiento(idAgencia);
        }
        public DataTable ListarDatosAgenciaMovimiento(int idAgencia)
        {
            return objMantenimiento.ListarDatosAgenciaMovimiento(idAgencia);
        }
        public DataTable InsUpdMovimientoOficina(
            int idAgencia, string nNroResolucion, DateTime dFechaRes,
            int idTipoOficina, int idTipoMovimiento, int? idEntCom, int idUbigeo,
            string cDireccion, string cCorreoElectronico, DateTime dFechaRegistro, int idUsuarioRegistro,
            DateTime dFechaNot, int nNroPersonal, int nNroCajCorresponsal, int idOfiDep,
            Boolean lConta, int nNroCajero, string cFono)
        {
            return objMantenimiento.InsUpdMovimientoOficina(idAgencia, nNroResolucion, dFechaRes,
                idTipoOficina, idTipoMovimiento, idEntCom, idUbigeo,
                cDireccion, cCorreoElectronico, dFechaRegistro, idUsuarioRegistro,
                dFechaNot, nNroPersonal, nNroCajCorresponsal, idOfiDep, lConta, nNroCajero, cFono);
        }
        public DataTable InsUpdMovimientoOficina(string xmlMovimientos)
        {
            return objMantenimiento.InsUpdMovimientoOficina(xmlMovimientos);
        }
        #endregion

        #region Condicion Contable
        public DataTable CNInsertarConCtbProduc(int idProducto, int idCondicionContable, bool lVigente)
        {
            return objMantenimiento.ADInsertarConCtbProduc(idProducto, idCondicionContable, lVigente);
        }


        public DataTable CNActualizarConCtbProduc(int idConCtbProduc, bool lVigente)
        {
            return objMantenimiento.ADActualizarConCtbProduc(idConCtbProduc, lVigente);
        }
        #endregion

        #region Tipo de Persona
        public DataTable CNInsertarTipPerProduc(int idProducto, int idTipoPersona, bool lVigente)
        {
            return objMantenimiento.ADInsertarTipPerProduc(idProducto, idTipoPersona, lVigente);
        }

        public DataTable CNActualizarTipPerProduc(int idTipPerProduc, bool lVigente)
        {
            return objMantenimiento.ADActualizarTipPerProduc(idTipPerProduc, lVigente);
        }
        #endregion

        #region Tipo de Operacion
        public DataTable CNInsertarTipOpeProduc(int idProducto, int idTipoOperacion, bool lVigente)
        {
            return objMantenimiento.ADInsertarTipOpeProduc(idProducto, idTipoOperacion, lVigente);
        }

        public DataTable CNActualizarTipOpeProduc(int idTipOpeProduc, bool lVigente)
        {
            return objMantenimiento.ADActualizarTipOpeProduc(idTipOpeProduc, lVigente);
        }
        #endregion

        #region Tipo de Canal
        public DataTable CNInsertarCanalTipOpe(int idTipOpeProduc, int idCanal, bool lVigente)
        {
            return objMantenimiento.ADInsertarCanalTipOpe(idTipOpeProduc, idCanal, lVigente);
        }

        public DataTable CNActualizarCanalTipOpec(int idCanalTipOpe, bool lVigente)
        {
            return objMantenimiento.ADActualizarCanalTipOpec(idCanalTipOpe, lVigente);
        }
        #endregion

        #region Tipo de Pago
        public DataTable CNInsertarTipPagCanal(int idCanalTipOpe, int idTipoPago, bool lVigente)
        {
            return objMantenimiento.ADInsertarTipPagCanal(idCanalTipOpe, idTipoPago, lVigente);
        }

        public DataTable CNActualizarTipPagCanal(int idTipPagCanal, bool lVigente)
        {
            return objMantenimiento.ADActualizarTipPagCanal(idTipPagCanal, lVigente);
        }
        #endregion

        #region Concepto
        public DataTable CNInsertarConcepTipPag(int idTipPagCanal, int idConcepto, bool lVigente)
        {
            return objMantenimiento.ADInsertarConcepTipPag(idTipPagCanal, idConcepto, lVigente);
        }

        public DataTable CNActualizarConcepTipPag(int idConcepTipPag, bool lVigente)
        {
            return objMantenimiento.ADActualizarConcepTipPag(idConcepTipPag, lVigente);
        }
        #endregion

        public DataTable ListarPerfilAsigXUsuario(int idUsuario, int idOpcion)
        {
            return objMantenimiento.ADlistarPerfilAsigXUsuario(idUsuario, idOpcion);
        }
        public DataTable GrabarPerfilAsignado(string xmlPerfilAsignado, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension)
        {
            return objMantenimiento.ADGrabarPerfilAsignado(xmlPerfilAsignado, cDocumentoSesion, vDocumentoSesion, cExtension);
        }
        public DataTable CNValidaProduto(int idProducto)
        {
            return objMantenimiento.ADValidaProduct(idProducto);
        }
        public DataTable CNListaEsquemaCaja()
        {
            return objMantenimiento.ADListaEsquemaCaja();
        }
        public DataTable CNAgeSinInicioOpe(int idAgencia, DateTime dFecSis)
        {
            return objMantenimiento.ADAgeSinInicioOpe(idAgencia, dFecSis);
        }
        #region Zona
        public DataTable CNListarZona()
        {
            return objMantenimiento.ADListarZona();
        }
        public DataTable CNListarOficinaByZona(int idZona)
        {
            return objMantenimiento.ADListarOficinaByZona(idZona);
        }
        public DataTable CNObtenerEstablecimiento(int idEstablecimiento)
        {
            return objMantenimiento.ADObtenerEstablecimiento(idEstablecimiento);
        }
        public DataTable CNObtenerZonaAgencia(int idAgencia)
        {
            return objMantenimiento.ADObtenerZonaAgencia(idAgencia);
        }
        public DataTable CNObtenerZonaEstab(int idEstab)
        {
            return objMantenimiento.ADObtenerZonaEstab(idEstab);
        }
        public DataTable CNObtenerAgenciaZona(int idZona)
        {
            return objMantenimiento.ADObtenerAgenciaZona(idZona);
        }
        public DataTable CNObtenerEstabAgencia(int idAgencia)
        {
            return objMantenimiento.ADObtenerEstabAgencia(idAgencia);
        }
        public DataTable CNObtenerUsuarioAgencia(int idAgencia)
        {
            return objMantenimiento.ADObtenerUsuarioAgencia(idAgencia);
        }
        public DataTable CNListarZonas()
        {
            return objMantenimiento.ADListarZonas();
        }
        public DataTable CNObtenerSolicitudPerfil(string cPerfil)
        {
            return objMantenimiento.ADObtenerSolicitudPerfil(cPerfil);
        }
        public DataTable CNObtenerSolicitudEstados(string cEstados)
        {
            return objMantenimiento.ADObtenerSolicitudEstados(cEstados);
        }
        #endregion

        #region Encaje

        public DataTable CNRegistrarEncajeMN(string cPeriodo, decimal x_nTasaEncaje, decimal x_nTasaEncLegal, decimal x_nPatrimonio,
                                            DateTime x_dFechaReg, int x_idUsuReg, int x_idInserMod)
        {
            return objMantenimiento.ADRegistrarEncajeMN(cPeriodo, x_nTasaEncaje, x_nTasaEncLegal, x_nPatrimonio,
                                                                        x_dFechaReg, x_idUsuReg, x_idInserMod);
        }

        public DataTable CNListarEncajeMN(string cPeriodo)
        {
            return objMantenimiento.ADListarEncajeMN(cPeriodo);
        }

        public DataTable CNRegistrarEncajeME(string cPeriodo, string cPeriodoTose, decimal x_nMontoTose, string x_cPeriodoEncaje,
                                            decimal x_nMontoEncExig, decimal x_nTasaEncaje, decimal x_nTasaMarginal, decimal x_nTasaEncMin,
                                            DateTime x_dFechaReg, int x_idUsuReg, int x_idInserMod)
        {
            return objMantenimiento.ADRegistrarEncajeME(cPeriodo, cPeriodoTose, x_nMontoTose, x_cPeriodoEncaje,
                                                        x_nMontoEncExig, x_nTasaEncaje, x_nTasaMarginal, x_nTasaEncMin,
                                                        x_dFechaReg, x_idUsuReg, x_idInserMod);
        }

        public DataTable CNListarEncajeME(string cPeriodo)
        {
            return objMantenimiento.ADListarEncajeME(cPeriodo);
        }

        #endregion

        public DataTable CNListaMovimiento()
        {
            return objMantenimiento.ADListaMovimiento();
        }

        public DataTable CNListaEntidades(int idEntidad)
        {
            return objMantenimiento.ADListaEntidades(idEntidad);
        }
        public DataTable CNListarOficinaByZonaUbigeo(int idZona)
        {
            return objMantenimiento.ADListarOficinaByZonaUbigeo(idZona);
        }

        public DataTable CNListarZonaAsiganado(int idUsuario)
        {
            return objMantenimiento.ADListarZonaAsiganado(idUsuario);
        }

        public DataTable CNFiltrarPorZonaAgenciaTodos(int idZona)
        {
            return objMantenimiento.ADFiltrarPorZonaAgenciaTodos(idZona);
        }
        public DataTable CNObtenerPerfilReporteExtorno(string cPerfil)
        {
            return objMantenimiento.ADObtenerPerfilReproteExtorno(cPerfil);
        }
        public DataTable ListadoEstablec(int idAgencia)
        {

            return objMantenimiento.ListadoEstablec(idAgencia);
        }
        public DataTable CNObtenerZonasAgenciaGeneral(int idAgencia)
        {
            return objMantenimiento.CNObtenerZonasAgenciaGeneral(idAgencia);
        }
        public DataTable CNRetornaValorVariable(string cPerfil)
        {
            return objMantenimiento.ADRetornaValorVariable(cPerfil);
        }
        public DataTable CNRetornaValorVariableGen(string cPerfil)
        {
            return objMantenimiento.ADRetornaValorVariableGen(cPerfil);
        }

    }
}