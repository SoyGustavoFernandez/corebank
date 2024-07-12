using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;

namespace CLI.CapaNegocio
{
    public class clsCNCliente
    {
        clsADCliente objCliente = new clsADCliente();

        //===============================================================
        // Registrar exoneración de Cliente a FSD
        //===============================================================
        public DataTable CNRegistrarExoneracionFSD(int idCliente, bool lExoneraFSD, DateTime dFechaExonera, string cMotivoExonera)
        {
            return objCliente.ADRegistrarExoneracionFSD(idCliente, lExoneraFSD, dFechaExonera, cMotivoExonera);
        }

        //===============================================================
        // Listar clientes exonerados de FSD
        //===============================================================
        public DataTable CNListarExoneracionFSD()
        {
            return objCliente.ADListarExoneracionFSD();
        }
        //===============================================================
        // LISTA SI EL CLIENTE ESTA REGISTRADO COMO SOCIO
        //===============================================================
        public DataTable CNBuscaClienteSocio(int idCliente)
        {
            return objCliente.ADBuscaClienteSocio(idCliente);
        }
        //===============================================================
        // BUSCA EL RUC COMO DOCUMENTO DEL CLIENTE 
        //===============================================================
        public DataTable CNBuscaDocumentoCliente(int idCliente)
        {
            return objCliente.ADBuscaDocumentoCliente(idCliente);
        }
        //===============================================================
        // OBTIENE EDAD DE CLIENTE
        //===============================================================
        public int CalcularEdad(int idCliente, DateTime dFechaActual)
        {
            return objCliente.ADCalcularEdad(idCliente, dFechaActual);
        }
        //===============================================================
        // LISTA LOS CÓDIGOS DE CIUDADES 
        //===============================================================
        public DataTable CNListaCodCiudad()
        {
            return objCliente.ADListaCodCiudad();
        }
        //===============================================================
        //VALIDA LA EDAD DE CLIENTE
        //===============================================================
        public DataTable CNValidaEdadCliente(DateTime dtFechaNac, DateTime dFechaSis)
        {
            return objCliente.ADValidaEdadCliente(dtFechaNac, dFechaSis);
        }
        //===============================================================
        //VALIDA CÓDIGO DE SUMINISTRO
        //===============================================================
        public DataTable CNValidaCodSuministro(int idSuministro, string cCodSuministro, int idCli)
        {
            return objCliente.ADValidaCodSuministro(idSuministro, cCodSuministro, idCli);
        }
        //===============================================================
        //VALIDA HOMONIMOS
        //===============================================================
        public DataTable CNValidaHomonimos(string cNombre, string cDocIdentidad)
        {
            return objCliente.ADValidaHomonimos(cNombre, cDocIdentidad);
        }
        //
        // Reporte Estado de Contribuyente PN-PJ 
        //===============================================================

        public DataTable CNListarEstContribuyente()
        {

            return objCliente.ADListarEstContribuyente();
        }
        public DataTable CNRptEstadoContribuyenteNJ(int nEstado, DateTime dFechaInicial, DateTime dFechaFinal)
        {

            return objCliente.ADRptEstadoContribuyenteNJ(nEstado, dFechaInicial, dFechaFinal);
        }

        //===============================================================
        // VERIFICA CLIENTE EN LAS BASES NEGATIVAS
        //===============================================================
        public DataTable CNBuscarClienteBaseNegativas(int idCliente)
        {
            return objCliente.CNBuscarClienteBaseNegativas(idCliente);
        }


        public DataTable ListaCreditos(int idCliente)
        {
            return objCliente.ListaCreditos(idCliente);
        }

        public DataTable BuscarPersonaPorDocumento(int idTipoDocumento, string cNroDocumento)
        {
            return objCliente.BuscarPersonaPorDocumento(idTipoDocumento, cNroDocumento);
        }

        //===============================================================
        // Metodos para el proceso de inserción de Registros de Teléfonos
        //===============================================================

        public DataTable CNPrepararDatosTelefono(int idCli)
        {
            return objCliente.ADPrepararDatosTelefono(idCli);
        }

        public DataTable CNListarDatosTelefono(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objCliente.ADListarDatosTelefono(idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel, idCodTelFijo);
        }

        public DataTable CNCambiarPrincipal(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objCliente.ADCambiarPrincipal(idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel, idCodTelFijo);
        }
        public DataTable CNValidaCadena(string cCadena)
        {
            return objCliente.ADValidaCadena(cCadena);
        }
        public DataTable CNDevuelveCodCore(string cNivelIns, string cIdSexo, string cIdEstCivil, string cZona, string cVia, string UbiDir, string UbiNac)
        {
            return objCliente.ADDevuelveCodCore(cNivelIns, cIdSexo, cIdEstCivil, cZona, cVia, UbiDir, UbiNac);
        }
        public DataTable CNDevuelveSunat(string cDocumento)
        {
            return objCliente.ADDevuelveSunat(cDocumento);
        }
        public DataTable CNDevuelveSunatJur(string cDocumento)
        {
            return objCliente.ADDevuelveSunatJur(cDocumento);
        }
        public DataTable CNDevuelveTelefonosActivosCliente(int idCli)
        {
            return objCliente.ADDevuelveTelefonosActivosCliente(idCli);
        }

        //===============================================================
        // Metodos para el proceso de Gestión de Contacto
        //===============================================================
        public DataTable CNListarDatosGestionContacto(int idCli, int idProceso, string cDocumento, string cNumeroTel, int idTipoTel, int lPrincipal, int idUsuario, int idRegTel, int idCodTelFijo)
        {
            return objCliente.ADListarDatosGestionContacto(idCli, idProceso, cDocumento, cNumeroTel, idTipoTel, lPrincipal, idUsuario, idRegTel, idCodTelFijo);
        }
        public DataTable CNListarPropietarioRecurso()
        {
            return objCliente.ADListarPropietarioRecurso();
        }
        public DataTable CNGrabarGestionContactoTelefono(int idcli, string cNumeroTel, int idTipoTel, int idUsuario, int idPropietarioTelefono)
        {
            return objCliente.ADGrabarGestionContactoTelefono(idcli, cNumeroTel, idTipoTel, idUsuario, idPropietarioTelefono);
        }
        public DataTable CNGrabarGestionContactoCorreo(int idCli, int idUsuario, string cCorreo, int idPropietarioCorreo)
        {
            return objCliente.ADGrabarGestionContactoCorreo(idCli, idUsuario, cCorreo, idPropietarioCorreo);
        }
        public DataTable ListarEStablecimientoPorListaAgencia(string cXmlAgencias)
        {
            return objCliente.ListarEStablecimientoPorListaAgencia(cXmlAgencias);
        }
        public DataTable ActualizarModulo(string cDocumento, int idModulo, int idMenu)
        {
            return objCliente.ActualizarModulo(cDocumento, idModulo, idMenu);
        }

        //===============================================================
        // Metodos para el proceso de Geolocalización
        //===============================================================
        public DataTable CNListarAgenciaGeolocalizacion(int idAgencia)
        {
            return objCliente.ADListarAgenciaGeolocalizacion(idAgencia);
        }

        public DataTable CNRegistrarGeolocalizacion(string cLatitud, string cLongitud, int idUsuario, DateTime dFecha)
        {
            return objCliente.ADRegistrarGeolocalizacion(cLatitud, cLongitud, idUsuario, dFecha);
        }

        public DataTable CNActualizarGeolocalizacion(int idGeo, string cLatitud, string cLongitud, int idUsuario, DateTime dFecha)
        {
            return objCliente.ADActualizarGeolocalizacion(idGeo, cLatitud, cLongitud, idUsuario, dFecha);
        }

        public DataTable CNListarDireccionGeolocalizacion(int idGeolocalizacion)
        {
            return objCliente.ADListarDireccionGeolocalizacion(idGeolocalizacion);
        }

        public DataTable CNListarUbigeo(string cUbigeo)
        {
            return objCliente.ADListarUbigeo(cUbigeo);
        }

        public DataTable CNObtenerDirUbigeo(string dirUbigeo)
        {
            return objCliente.ADObtenerDirUbigeo(dirUbigeo);
        }

        public string CNObtenerSegmentoCliente(int idCliente)
        {
            DataTable dt = objCliente.ADObtenerSegmentoCliente(idCliente);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }

        public string CNObtenerCalificacionCliente(int idCliente)
        {
            DataTable dt = objCliente.ADObtenerCalificacionCliente(idCliente);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }

        public DataTable CNObtenerAsesorCliente(int idCliente)
        {
            return objCliente.ADObtenerAsesorCliente(idCliente);
        }

        public DataTable CNListaCtaActivaCliente(int idCliente)
        {
            return objCliente.ADListaCtaActivaCliente(idCliente);
        }

        public DataTable CNObtenerClientePorDocumento(int idTipoDoc, string cDocumentoID)
        {
            return objCliente.ADObtenerClientePorDocumento(idTipoDoc, cDocumentoID);
        }       
        public DataTable MostrarNombreCompletoCliente(int idCli)
        {
            return objCliente.MostrarNombreCompletoCliente(idCli);
        }

        public bool ValidarSiEsClienteNatural(int idCli)
        {
            return objCliente.ValidarSiEsClienteNatural(idCli);
        }
        public DataTable CNBuscarCliente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objCliente.ADBuscarCliente(idTipoDocumento, cNumeroDocumento);            
        }
        public DataTable CNBuscarNoCliente(int idTipoDocumento, string cNumeroDocumento)
        {
            return objCliente.ADBuscarNoCliente(idTipoDocumento, cNumeroDocumento);
        }
        public DataTable CNBuscarTablaSunat(string cNumeroDocumento)
        {
            return objCliente.ADBuscarTablaSunat(cNumeroDocumento);
        }
        public DataTable CNRegistroActualizacionNoCliente(clsNoCliente objNoCliente)
        {
            return objCliente.ADRegistroActualizacionNoCliente(objNoCliente);
        }

    }
}
