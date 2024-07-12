using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Bus.Response
{
    [DataContract]
    public class clsBusConsultaCliente
    {
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public int success { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public clsUpdateFieldsValues data { get; set; }
    }

    public class clsUpdateFieldsValues
    {
        public string ejecutadoConsultaCliente { get; set; }
        public string digitoVerificadorPersonaNatural { get; set; }
        public string clasificacionTipoPersona { get; set; }
        public string idDocumentoAdicional { get; set; }
        public string documentoAdicional { get; set; }
        public string otorgaMismoFamiliar { get; set; }
        public string respuestaServicioOffline { get; set; }
        public string respuestaServicioOfflineSunat { get; set; }
        public string codigoUsuario { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string otrosNombres { get; set; }
        public string apellidosCasada { get; set; }
        public string fotografiaCliente { get; set; }
        public string UrlFotografiaCliente { get; set; }
        public string VisorDNI1 { get; set; }
        public string UrlDNI1 { get; set; }
        public string VisorDNI2 { get; set; }
        public string UrlDNI2 { get; set; }
        public string dniTitular { get; set; }
        public string codigoCliente { get; set; }
        public string tipoDocumentoConyuge { get; set; }
        public string numeroDocumentoConyuge { get; set; }
        public string correoElectronico { get; set; }
        public string nacionalidadCliente { get; set; }
        public string fechaNacimientoCliente { get; set; }
        public string codigoUbigeoNacimiento { get; set; }
        public string codigoPaisNacimiento { get; set; }
        public string nombrePaisNacimiento { get; set; }
        public string codigoDepartamentoNacimiento { get; set; }
        public string nombreDepartamentoNacimiento { get; set; }
        public string codigoProvinciaNacimiento { get; set; }
        public string nombreProvinciaNacimiento { get; set; }
        public string codigoDistritoNacimiento { get; set; }
        public string nombreDistritoNacimiento { get; set; }
        public string codigoAnexoNacimiento { get; set; }
        public string nombreAnexoNacimiento { get; set; }
        public string generoCliente { get; set; }
        public string estadoCivilInstitucionCliente { get; set; }
        public string estadoCivilSBSCliente { get; set; }
        public string tipoDireccion { get; set; }
        public string idDireccion { get; set; }
        public string codigoDepartamentoDomicilio { get; set; }
        public string nombreDepartamentoDomicilio { get; set; }
        public string codigoProvinciaDomicilio { get; set; }
        public string nombreProvinciaDomicilio { get; set; }
        public string codigoDistritoDomicilio { get; set; }
        public string nombreDistritoDomicilio { get; set; }
        public string codigoAnexoDomicilio { get; set; }
        public string nombreAnexoDomicilio { get; set; }
        public string direccionDomicilio { get; set; }
        public string referenciaDomicilio { get; set; }
        public string tipoZonaDomicilio { get; set; }
        public string codigoZona { get; set; }
        public string nombreZona { get; set; }
        public string codigoVia { get; set; }
        public string nombreVia { get; set; }
        public string nivelInstruccion { get; set; }
        public string tipoViviendaDomicilio { get; set; }
        public string tipoConstruccionDomicilio { get; set; }
        public string aniosResidenciaDomicilio { get; set; }
        public string telefonoCelular { get; set; }
        public string numeroReferenciasTelefonicas { get; set; }
        public string ocupacion { get; set; }
        public string otroOcupacion { get; set; }
        public string cargo { get; set; }
        public string otroCargo { get; set; }
        public string codigoCIIUInterno { get; set; }
        public string nombreCIIUInterno { get; set; }
        public string inicioActividadEconomicaTitular { get; set; }
        public string tiempoEnActividadEconomicaMeses { get; set; }
        public string codigoPorcentajeRural { get; set; }
        public string nombrePorcentajeRural { get; set; }
        public string codigoPorcentajeUrbano { get; set; }
        public string nombrePorcentajeUrbano { get; set; }
        public string codigoTipoEvaluacion { get; set; }
        public string nombreTipoEvaluacion { get; set; }
        public string codigoCIIUInternoSecUno { get; set; }
        public string nombreCIIUInternoSecUno { get; set; }
        public string inicioActividadEconomicaTitularSecUno { get; set; }
        public string tiempoEnActividadEconomicaMesesSecUno { get; set; }
        public string cantidadPersonasDependientes { get; set; }
        public string cantidadHijos { get; set; }
        public string titularMasVinculacion { get; set; }
        public string razonSocialClienteJuridico { get; set; }
        public string nombreComercialClienteJuridico { get; set; }
        public string siglasJuridico { get; set; }
        public string zonaRegistralJuridico { get; set; }
        public string oficinaRegistralJuridico { get; set; }
        public string partidaRegistralJuridico { get; set; }
        public string fechaConstitucionJuridico { get; set; }
        public string condicionDomicilioJuridico { get; set; }
        public string magnitudEmpresarialJuridico { get; set; }
        public string codigoCIIUInternoJuridico { get; set; }
        public string nombreCIIUInternoJuridico { get; set; }
        public string inicioActividadEconomicaJuridico { get; set; }
        public string tiempoEnActividadEconomicaJuridicoMeses { get; set; }
        public string numeroEmpleadosJuridico { get; set; }
        public string estadoContribuyenteJuridico { get; set; }
        public string fechaEstadoJuridico { get; set; }
        public string codigoSBS { get; set; }
        public string tipoDocumentoRepresentanteLegal { get; set; }
        public string numeroDocumentoRepresentanteLegal { get; set; }
        public string referencias { get; set; }
        public string vinculados { get; set; }
        public string inmuebles { get; set; }
        public string documentoAdicionalRUC { get; set; }
        public string tipoIdentificacionJuridico { get; set; }
        public string seleccionarCreditosActivos { get; set; }
        public string tieneCreditosActivos { get; set; }
        public string fechaInicioActividadSunat { get; set; }
        public string codigoEstadoContribuyenteSunat { get; set; }
        public string codigoCondicionDomicilioSunat { get; set; }
        public string codigoCIIUInternoSunat { get; set; }
    }
}
