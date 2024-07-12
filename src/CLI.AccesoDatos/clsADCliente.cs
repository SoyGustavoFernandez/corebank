using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADCliente
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //===============================================================
        // Registrar exoneración de Cliente a FSD
        //===============================================================
        public DataTable ADRegistrarExoneracionFSD(int idCliente, bool lExoneraFSD, DateTime dFechaExonera, string cMotivoExonera)
        {
            return objEjeSp.EjecSP("CLI_RegistrarExoneracionFSD_SP", idCliente, lExoneraFSD, dFechaExonera, cMotivoExonera);
        }

        //===============================================================
        // Listar clientes exonerados de FSD
        //===============================================================
        public DataTable ADListarExoneracionFSD()
        {
            return objEjeSp.EjecSP("CLI_ListarExoneracionFSD_SP");
        }
        //===============================================================
        // LISTA SI EL CLIENTE ESTA REGISTRADO COMO SOCIO
        //===============================================================
        public DataTable ADBuscaClienteSocio(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_BuscaSocios_SP", idCliente);
        }
        //===============================================================
        // BUSCA EL RUC COMO DOCUMENTO DEL CLIENTE 
        //===============================================================
        public DataTable ADBuscaDocumentoCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_BuscaDocumentoCliente_SP", idCliente);
        }
        //===============================================================
        // OBTIENE EDAD DE CLIENTE
        //===============================================================

        public int ADCalcularEdad(int idCliente, DateTime dFechaActual)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_ObtenerEdadCli_SP", idCliente, dFechaActual);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        //===============================================================
        // LISTA LOS CÓDIGOS DE CIUDADES 
        //===============================================================
        public DataTable ADListaCodCiudad()
        {
            return objEjeSp.EjecSP("CLI_ListaCodigoCiudad_sp");
        }
        //===============================================================
        //VALIDA LA EDAD DE REGISTRO PERMITIDA
        //===============================================================
        public DataTable ADValidaEdadCliente(DateTime dtFechaNac, DateTime dFechaSis )
        {
            return objEjeSp.EjecSP("CLI_ValidaEdadCli_sp", dtFechaNac, dFechaSis);
        }
        //===============================================================
        //VALIDA CÓDIGO DE SUMINISTRO
        //===============================================================
        public DataTable ADValidaCodSuministro(int idSuministro, string cCodSuministro, int idCli)
        {
            return objEjeSp.EjecSP("GEN_ValidaCodigoSuministro_sp", idSuministro, cCodSuministro, idCli);
        }
        //===============================================================
        //VALIDA HOMONIMOS
        //===============================================================
        public DataTable ADValidaHomonimos(string cNombre, string cDocIdentidad)
        {
            return objEjeSp.EjecSP("CLI_ValidaHomonimia_sp", cNombre, cDocIdentidad);
        }
		//===============================================================
        // Reporte Estado de Contribuyente PN-PJ
        //===============================================================
		public DataTable ADListarEstContribuyente()
        {
            return objEjeSp.EjecSP("CLI_ListEstadoContrib_SP");
        }        

        public DataTable ADRptEstadoContribuyenteNJ(int nEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CLI_RptEstContribNJ_SP", nEstado, dFechaInicial, dFechaFinal);
        }
        public DataTable CNBuscarClienteBaseNegativas(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_BuscarClienteBaseNegativas_SP", idCliente);
        }

        public DataTable ListaCreditos(int idCliente)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosCliente_SP", idCliente);
        }

        public DataTable BuscarPersonaPorDocumento(int idTipoDocumento, string cNroDocumento)
        {
            return objEjeSp.EjecSP("GEN_BuscarPersonaPorDocumento_SP", idTipoDocumento, cNroDocumento);
        }

        //===============================================================
        // Metodos para el proceso de inserción de Registros de Teléfonos
        //===============================================================

        public DataTable ADPrepararDatosTelefono(int idCli)
        {
            return objEjeSp.EjecSP("Cli_InsDatosTelefono_sp", idCli);
        }

        public DataTable ADListarDatosTelefono(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objEjeSp.EjecSP("Gen_AdministrarTelefonos_sp", idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel,idCodTelFijo, 1);
        }
        public DataTable ADCambiarPrincipal(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objEjeSp.EjecSP("Gen_AdministrarTelefonos_sp", idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel,idCodTelFijo, 1);
        }
        public DataTable ADValidaCadena(string cCadena)
        {
            return objEjeSp.EjecSP("Gen_ValidarNumTelef_sp", cCadena);
        }
        public DataTable ADDevuelveCodCore(string cNivelIns, string cIdSexo, string cIdEstCivil, string cZona, string cVia,string UbiDir,string UbiNac)
        {
            return objEjeSp.EjecSP("GEN_DevuelveCodCore_sp", cNivelIns, cIdSexo, cIdEstCivil,cZona,cVia,UbiDir,UbiNac);
        }
        public DataTable ADDevuelveSunat(string cDocumento)
        {
            return objEjeSp.EjecSP("GEN_ConsultaSunat_sp", cDocumento);
        }
        public DataTable ADDevuelveSunatJur(string cDocumento)
        {
            return objEjeSp.EjecSP("GEN_ConsultaSunatJur_sp", cDocumento);
        }

        public DataTable ADDevuelveTelefonosActivosCliente(int idCli)
        {
            return objEjeSp.EjecSP("GEN_DevuelveTelefonosActivosCliente_SP", idCli);
        }

        //===============================================================
        // Metodos para el proceso de Gestión de Contacto
        //===============================================================

        public DataTable ADListarDatosGestionContacto(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objEjeSp.EjecSP("Gen_GestionContacto_sp", idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel, idCodTelFijo, 1);
        }
        public DataTable ADListarPropietarioRecurso()
        {
            return objEjeSp.EjecSP("Gen_PropietarioRecurso_sp");
        }

        public DataTable ADGrabarGestionContactoTelefono(int idcli, string cNumeroTel, int idTipoTel, int idUsuario, int idPropietarioTelefono)
        {
            return objEjeSp.EjecSP("Gen_GrabarGestionContactoTelefono_sp", idcli, cNumeroTel, idTipoTel, idUsuario, idPropietarioTelefono);
        }
        public DataTable ADGrabarGestionContactoCorreo(int idCli, int idUsuario, string cCorreo, int idPropietarioCorreo)
        {
            return objEjeSp.EjecSP("Gen_GrabarGestionContactoCorreo_sp", idCli, idUsuario, cCorreo, idPropietarioCorreo);
        }
        public DataTable ListarEStablecimientoPorListaAgencia(string cXmlAgencias)
        {
            return objEjeSp.EjecSP("CRE_RetornaEstablecimientoPorListaAgencia_SP", cXmlAgencias);
        }
        public DataTable ActualizarModulo(string cDocumento, int idModulo, int idMenu)
        {
            return objEjeSp.EjecSP("GEN_ActualizaModuloGC_SP", cDocumento, idModulo, idMenu);
        }


        //===============================================================
        // Metodos para el proceso de Geolocalización
        //===============================================================
        public DataTable ADListarAgenciaGeolocalizacion(int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListarAgenciaGeolocalizacion_sp", idAgencia);
        }

        public DataTable ADRegistrarGeolocalizacion(string cLatitud, string cLongitud, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("GEN_RegistrarGeolocalizacion_SP", cLatitud, cLongitud, idUsuario, dFecha);
        }

        public DataTable ADActualizarGeolocalizacion(int idGeo, string cLatitud, string cLongitud, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("GEN_ActualizarGeolocalizacion_SP", idGeo, cLatitud, cLongitud, idUsuario, dFecha);
        }

        public DataTable ADListarDireccionGeolocalizacion(int idGeolocalizacion)
        {
            return objEjeSp.EjecSP("GEN_ObtenerDireccionGeolocalizacion_SP", idGeolocalizacion);
        }

        public DataTable ADListarUbigeo(string cUbigeo)
        {
            return objEjeSp.EjecSP("GEN_ObtenerListaUbigeo_SP", cUbigeo);
        }

        public DataTable ADObtenerDirUbigeo(string dirUbigeo)
        {
            return objEjeSp.EjecSP("GEN_ObtenerUbigeo_SP", dirUbigeo);
        }

        public DataTable ADObtenerSegmentoCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ObtenerSegmentoCliente_SP", idCliente);
        }

        public DataTable ADObtenerAsesorCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ObtenerAsesorCliente_SP", idCliente);
        }

        public DataTable ADObtenerCalificacionCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ObtenerCalificacionCliente_SP", idCliente);
        }

        public DataTable ADListaCtaActivaCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CLI_ListaCtaActivaClie_SP", idCliente);
        }

        public DataTable ADObtenerClientePorDocumento(int idTipoDoc, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CLI_ObtenerClientePorDocumento_SP", idTipoDoc, cDocumentoID);
        }        
        public DataTable MostrarNombreCompletoCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_MuestraNombreCliente_SP", idCli);
        }

        public bool ValidarSiEsClienteNatural(int idCli)
        {
            clsDBResp dbResp = objEjeSp.OEjecutar<clsDBResp>("CRE_ValidarSiEsClienteNatural_SP", idCli);
            return Convert.ToBoolean(dbResp.nMsje);
        }
        public DataTable ADBuscarCliente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objEjeSp.EjecSP("SER_BuscarClienteGiro_SP", idTipoDocumento, cNumeroDocumento);
        }
        public DataTable ADBuscarNoCliente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objEjeSp.EjecSP("SER_BuscarNoClienteGiro_SP", idTipoDocumento, cNumeroDocumento);
        }

        public DataTable ADBuscarTablaSunat(string cNumeroDocumento)
        {
            return objEjeSp.EjecSP("SER_BuscarPersonaJuridicaDBSunat_SP", cNumeroDocumento);
        }
        public DataTable ADRegistroActualizacionNoCliente(clsNoCliente objNoCliente)
        {
            return objEjeSp.EjecSP("CLI_RegistraActualizaNoCliente_SP", 
                    objNoCliente.idNoCliente,
                    objNoCliente.idTipoDocumento,
                    objNoCliente.cNroDocumento,
                    objNoCliente.cNombres,
                    objNoCliente.cDireccion,
                    objNoCliente.cCelular
                );
        }


    }
}
