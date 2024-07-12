using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace ADM.AccesoDatos
{
   public class clsADMantenimientos
    {
       //clsGENEjeSP objEjeSp = new clsGENEjeSP();
       IntConexion objEjeSp;
       #region variables

        public clsADMantenimientos(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADMantenimientos()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ADRecuperarVariable(string cVariable)
        {
            return objEjeSp.EjecSP("ADM_RecuperarVariable_SP", cVariable);
        }
        
        public DataTable ADlistarVariable(int idAgencia)
        {
            return objEjeSp.EjecSP("ADM_ListarVariables", idAgencia);
        }

        public DataTable ADlistarTipoDatos()
        {
            return objEjeSp.EjecSP("ADM_ListarTiposDeDatos");
        }
        public DataTable ADGrabarTipoDatos(int idVariable, string cVariable, string cDescripcion,
             string cTipoVariable, string cValVar, bool lVigente, int idAgencia, bool lCargaVarApl)
        {
            return objEjeSp.EjecSP("ADM_MantenimientoVariable", idVariable, cVariable, cDescripcion,
                cTipoVariable, cValVar, lVigente, idAgencia, lCargaVarApl);
        }

        public DataTable ADActualizarValorVariables(string cVariable, string cValVar)
        {
            return objEjeSp.EjecSP("ADM_ActualizarValorVariable_SP", cVariable, cValVar);
        }

        //Variables de Crédito
        public DataTable ADListarAgenciaVariablesCredito()
        {
            return objEjeSp.EjecSP("GEN_LisAgenciaVariablesCredito_SP");
        }
        public DataTable ADlistarVariableTasa(int idAgencia)
        {
            return objEjeSp.EjecSP("ADM_ListarVariablesTasa_SP", idAgencia);
        }
        public DataTable ADGrabarTipoDatosCredito(int idVariable, string cVariable, string cDescripcion,
             string cTipoVariable, string cValVar, bool lVigente, int idAgencia, bool lCargaVarApl, int idUsuario, DateTime dFecha, int idAgenciaUs)
        {
            return objEjeSp.EjecSP("ADM_MantenimientoVariableCredito_SP", idVariable, cVariable, cDescripcion,
                cTipoVariable, cValVar, lVigente, idAgencia, lCargaVarApl, idUsuario, dFecha, idAgenciaUs);
        }

       #endregion       

        #region Perfiles
        public DataTable ADlistarPerfiles()
       {
           return objEjeSp.EjecSP("ADM_ListarPerfiles");
       }
       public DataTable ADGrabarPerfiles(int idPerfil	, string cPerfil,string cDescripcion, bool lVigente	,bool lLimCobertura)
       {
           return objEjeSp.EjecSP("ADM_GrabarPerfiles", idPerfil	, cPerfil,cDescripcion, lVigente	, lLimCobertura);
       }
       #endregion

       #region Agencias
       public DataTable ADlistarTipoOficina()
       {
           return objEjeSp.EjecSP("ADM_ListarTipoOficina");
       }
       
       public DataTable ADlistarMantAgencias()
       {
           return objEjeSp.EjecSP("ADM_ListarMantAgencias");
       }
       public DataTable ListadoEstablec(int idAgencia)
       {
           return objEjeSp.EjecSP("GRH_ListarEstablecimientos_SP", idAgencia);
       }
       public DataTable ADGrabarMantAgencias(int idAgencia, string cNombreAge, string cNomCorto, int idUbigeo,
                                                string cDirección, string cRefDirec, string cFono, bool lEstado,
                                                string cCodSBS, int idTipoOficina, DateTime dFechaAprob, string cResolucion,
                                                string dtAreas, string dtEstablecimientos, int idTipEsquemaCaja)

       {
           return objEjeSp.EjecSP("ADM_GrabarMantAgencias", idAgencia, cNombreAge, cNomCorto, idUbigeo,
                                                           cDirección, cRefDirec, cFono, lEstado,
                                                           cCodSBS, idTipoOficina, dFechaAprob, cResolucion,
                                                           dtAreas, dtEstablecimientos, idTipEsquemaCaja);

       }

       public DataTable ADGeneraCtasContablesAgencia(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_GeneraCtasContablesAgencia_SP", idAgencia);
       }
       
       public DataTable ListarAreas(int idAgencia)
       {
           return objEjeSp.EjecSP("GRH_AreasXAgencias_SP", idAgencia);
       }
       public DataTable ListarEstablecimiento(int idAgencia)
       {
           return objEjeSp.EjecSP("GRH_EstablecimientosXAgencias_SP", idAgencia);
       }
       public DataTable ListarTiposMovimiento(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_MovimientoOficinas_sp", idAgencia);
       }
       public DataTable ListarDatosAgenciaMovimiento(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_DatosMovimientoOficina_sp", idAgencia);
       }
       public DataTable InsUpdMovimientoOficina(
            int idAgencia,string nNroResolucion, DateTime dFechaRes,
            int idTipoOficina, int idTipoMovimiento, int? idEntCom, int idUbigeo,
            string cDireccion, string cCorreoElectronico, DateTime dFechaRegistro, int idUsuarioRegistro,
            DateTime dFechaNot, int nNroPersonal, int nNroCajCorresponsal,  int idOfiDep, 
            Boolean lConta, int nNroCajero, string cFono)
       {
           return objEjeSp.EjecSP("ADM_InsUpdDatosMovimientoOficina_sp", idAgencia, nNroResolucion, dFechaRes,
               idTipoOficina, idTipoMovimiento, idEntCom == null ? (object)DBNull.Value : (object)idEntCom, idUbigeo,
               cDireccion, cCorreoElectronico, dFechaRegistro, idUsuarioRegistro,
               dFechaNot, nNroPersonal, nNroCajero, nNroCajCorresponsal,
               idOfiDep, lConta, cFono);
       }
       public DataTable InsUpdMovimientoOficina(string xmlMovimientos)
       {
           return objEjeSp.EjecSP("ADM_InsUpdDatosMovimientoOficina_sp", xmlMovimientos);
       }
       #endregion

       #region Condicion Contable
       public DataTable ADInsertarConCtbProduc(int idProducto, int idCondicionContable, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarConCtbProduc_SP", idProducto, idCondicionContable, lVigente);
       }

       public DataTable ADActualizarConCtbProduc(int idConCtbProduc, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarConCtbProduc_SP", idConCtbProduc , lVigente);
       }
       #endregion
       
       #region Tipo de Persona
       public DataTable ADInsertarTipPerProduc(int idProducto, int idTipoPersona, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarTipPerProduc_SP", idProducto, idTipoPersona, lVigente);
       }

       public DataTable ADActualizarTipPerProduc(int idTipPerProduc, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarTipPerProduc_SP", idTipPerProduc, lVigente);
       }
       #endregion

       #region Tipo de Operacion
       public DataTable ADInsertarTipOpeProduc(int idProducto, int idTipoOperacion, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarTipOpeProduc_SP", idProducto, idTipoOperacion, lVigente);
       }

       public DataTable ADActualizarTipOpeProduc(int idTipOpeProduc, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarTipOpeProduc_SP", idTipOpeProduc, lVigente);
       }
       #endregion

       #region Tipo de Canal
       public DataTable ADInsertarCanalTipOpe(int idTipOpeProduc, int idCanal, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarCanalTipOpe_SP", idTipOpeProduc, idCanal, lVigente);
       }

       public DataTable ADActualizarCanalTipOpec(int idCanalTipOpe, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarCanalTipOpe_SP", idCanalTipOpe, lVigente);
       }
       #endregion

       #region Tipo de Pago
       public DataTable ADInsertarTipPagCanal(int idCanalTipOpe, int idTipoPago, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarTipPagCanal_SP", idCanalTipOpe, idTipoPago, lVigente);
       }

       public DataTable ADActualizarTipPagCanal(int idTipPagCanal, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarTipPagCanal_SP", idTipPagCanal, lVigente);
       }
       #endregion

       #region Concepto
       public DataTable ADInsertarConcepTipPag(int idTipPagCanal, int idConcepto, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_InsertarConcepTipPag_SP", idTipPagCanal, idConcepto, lVigente);
       }

       public DataTable ADActualizarConcepTipPag(int idConcepTipPag, bool lVigente)
       {
           return objEjeSp.EjecSP("ADM_ActualizarConcepTipPag_SP", idConcepTipPag, lVigente);
       }
       #endregion

       public DataTable ADlistarPerfilAsigXUsuario(int idUsuario, int idOpcion)
       {
           return objEjeSp.EjecSP("ADM_ListarPerfilAsignado", idUsuario, idOpcion);
       }
       public DataTable ADGrabarPerfilAsignado(string xmlPerfilAsig,string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension)
       {
           return objEjeSp.EjecSP("ADM_GrabarPerfilesAsignado", xmlPerfilAsig,cDocumentoSesion, vDocumentoSesion.ToArray(),  cExtension);
       }
       public DataTable ADValidaProduct(int idProducto)
       {
           return objEjeSp.EjecSP("ADM_ValidaPoducto_Sp", idProducto);
       }
       public DataTable ADListaEsquemaCaja()
       {
           return objEjeSp.EjecSP("ADM_ListaEsquemaTrabajo_SP");
       }
       public DataTable ADAgeSinInicioOpe(int idAgencia,DateTime dFecSis)
       {
           return objEjeSp.EjecSP("ADM_ValidaInicioCajaAgencia_SP", idAgencia, dFecSis);
       }
        #region Zona
       public DataTable ADListarZona()
       {
           return objEjeSp.EjecSP("ADM_ListarZonaVigentes_SP");
       }
       public DataTable ADListarOficinaByZona(int idZona)
       { 
           return objEjeSp.EjecSP("ADM_ListarOficinaByZona_SP", idZona);
       }
       public DataTable ADObtenerEstablecimiento(int idEstablecimiento)
       {
           return objEjeSp.EjecSP("ADM_ObtenerEstabById_SP", idEstablecimiento);
       }
       public DataTable ADObtenerZonaAgencia(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_ObtenerZonaByIdAge_SP", idAgencia);
       }
       public DataTable ADObtenerZonaEstab(int idEstab)
       {
           return objEjeSp.EjecSP("ADM_ObtenerZonaByIdEstab_SP", idEstab);
       }
       public DataTable ADObtenerAgenciaZona(int idZona)
       {
           return objEjeSp.EjecSP("ADM_ObtenerAgeByZona_SP", idZona);
       }
       public DataTable ADObtenerEstabAgencia(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_ObtenerEstabByAgencia_SP", idAgencia);
       }
       public DataTable ADObtenerUsuarioAgencia(int idAgencia)
       {
           return objEjeSp.EjecSP("ADM_ObtenerUsuarioByAgencia_SP", idAgencia);
       }
       public DataTable ADListarZonas()
       {
           return objEjeSp.EjecSP("ADM_ListarZonas_SP");
       }
       public DataTable ADObtenerSolicitudPerfil(string cPerfil)
       {
           return objEjeSp.EjecSP("GEN_RetornaValorVariable_sp", cPerfil);
       }
       public DataTable ADObtenerSolicitudEstados(string cEstados)
       {
           return objEjeSp.EjecSP("GEN_RetornaValorVariable_sp", cEstados);
       }
        #endregion

        #region Encaje

        public DataTable ADRegistrarEncajeMN(string cPeriodo, decimal x_nTasaEncaje, decimal x_nTasaEncLegal, decimal x_nPatrimonio, 
                                            DateTime x_dFechaReg, int x_idUsuReg, int x_idInserMod)
       {
           return objEjeSp.EjecSP("DEP_RegistraParametrosEncajeMN_SP", cPeriodo, x_nTasaEncaje, x_nTasaEncLegal, x_nPatrimonio,
                                                                        x_dFechaReg, x_idUsuReg, x_idInserMod);
       }
       public DataTable ADListarEncajeMN(string cPeriodo)
       {
           return objEjeSp.EjecSP("DEP_ListaParametrosEncajeMN_SP", cPeriodo);
       }

       public DataTable ADRegistrarEncajeME(string cPeriodo, string cPeriodoTose, decimal x_nMontoTose, string x_cPeriodoEncaje,
                                            decimal x_nMontoEncExig, decimal x_nTasaEncaje, decimal x_nTasaMarginal, decimal x_nTasaEncMin,
                                            DateTime x_dFechaReg, int x_idUsuReg, int x_idInserMod)
       {
           return objEjeSp.EjecSP("DEP_RegistraParametrosEncajeME_SP", cPeriodo, cPeriodoTose, x_nMontoTose, x_cPeriodoEncaje,
                                                                        x_nMontoEncExig, x_nTasaEncaje, x_nTasaMarginal, x_nTasaEncMin,
                                                                        x_dFechaReg, x_idUsuReg, x_idInserMod);
       }
       public DataTable ADListarEncajeME(string cPeriodo)
       {
           return objEjeSp.EjecSP("DEP_ListaParametrosEncajeME_SP", cPeriodo);
       }
       
       #endregion
       public DataTable ADListaMovimiento()
       {
           return objEjeSp.EjecSP("ADM_ListarMovAgencia_sp");
       }

       public DataTable ADListaEntidades(int idEntidad)
       {
           return objEjeSp.EjecSP("ADM_ListaEntidadesEmp_SP", idEntidad);
       }
        public DataTable ADListarOficinaByZonaUbigeo(int idZona)
        { 
            return objEjeSp.EjecSP("ADM_ListarOficinaByZonaUbigeo_SP", idZona);
        }

        public DataTable ADListarZonaAsiganado(int idUsuario)
        {
            return objEjeSp.EjecSP("ADM_ListarZonaAsiganadoUsuario_SP", idUsuario);
        }

        public DataTable ADFiltrarPorZonaAgenciaTodos(int idZona)
        {
            return objEjeSp.EjecSP("GEN_LisAgenciaVigente_SP", idZona);
        }
        public DataTable ADObtenerPerfilReproteExtorno(string cPerfil)
        {
            return objEjeSp.EjecSP("GEN_RetornaValorVariable_sp", cPerfil);
        }
        public DataTable CNObtenerZonasAgenciaGeneral(int idAgencia)
        {
            return objEjeSp.EjecSP("ADM_ObtenerZonaByIdAgencia_SP", idAgencia);
        }
        public DataTable ADRetornaValorVariable(string cPerfil)
        {
            return objEjeSp.EjecSP("GEN_RetornaValorVariableTasa_sp", cPerfil);
        }
        public DataTable ADRetornaValorVariableGen(string cPerfil)
        {
            return objEjeSp.EjecSP("GEN_RetornaValorVariable_sp", cPerfil);
        }

    }
}
