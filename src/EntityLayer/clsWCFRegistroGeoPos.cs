using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFRegistroGeoPos
    {
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        //public string cNombres { get; set; }
        //public string cApellidoPaterno { get; set; }
        //public string cApellidoMaterno { get; set; }
        public List<clsImagenesBase64> listaImagenesBase64 { get; set; } 
    }

    public class clsImagenesBase64
    {
        public string cNombreImagen {get; set;}
        public string cExtencion {get; set;}
        public string cImagenBase64 {get; set;}
    }

    public class clsTipoVisita 
    {
        public int idTipoVisita  { get; set; }
        public string cNombre { get; set; }
        public string cDescripcion { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsEstadoVisita
    { 
        public int idEstadoVisita { get; set; }
        public string cNombre	{ get; set; }
        public string cDescripcion	{ get; set; }
        public bool lVigente { get; set; }
    }

    public class clsVisita
    { 
        public int idVisita	{ get; set; }
        public int idUsuario{ get; set; }
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
        public string cWinUser { get; set; }
        public string dfechaVisita { get; set; }
        public int idCliente	{ get; set; }
        public int idDireccion	{ get; set; }
        public int idTipoVisita	{ get; set; }
        public string cTipoVisita	{ get; set; }
        public int idEstadoVisita	{ get; set; }
        public string cEstadoVisita	{ get; set; }
        public string cObservacion	{ get; set; }
        public DateTime dtFechaVisita	{ get; set; }
        public double nLat { get; set; }
        public double nLong { get; set; }
        public string cDireccion { get; set; }
        public string cNombre { get; set; }
        public Boolean lVinc { get; set; }

        //Lista de registros de respuestas de ficha
        public List<clsRespuestaFicha> listaRespuestaFicha { get; set; }

        //Lista de registros de información de ficha
        public List<clsInformacionFicha> listaInformacionFicha { get; set; }

        //Para registro  de resultado de visita
        public clsWCFResultadoRecuperacionVisita resultadoRecuperacionVisita { get; set; }

        public int idSexo { get; set; }
        public string cDocumentoID { get; set; }

        public List<clsDetalleVisita> listaArchivos { get; set; }

        public clsDireccion oDireccion { get; set; }

        public clsCliente oCliente { get; set; }

        public List<clsArchivo> ObtenerArchivos()
        {
            List<clsArchivo> lista = new List<clsArchivo>();
            
            foreach (clsDetalleVisita item in this.listaArchivos)
            {
                lista.Add(item.ToArchivo());
            }

            return lista;
        }

        public clsWCFRespuesta oResultado { get; set; }

        public int idActividad { get; set; }
        public int idTipoDocumento { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }

        public string cRazonSocial { get; set; }
        public int idTipoDireccion { get; set; }
        public int idTipoPersona { get; set; }
        public int idUbigeo { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cCorreoCli { get; set; }
        public string cNombres { get{
            return this.cApellidoPaterno + " " + this.cApellidoMaterno + " " + this.cNombre;
        } }
        public string cFechaVisita { get; set; }
        public int idAgencia { get; set; }
        public int idCuenta { get; set; }
    }

    public class clsRespuestaFicha
    {
        public int idFVFichaPregOpc { get; set; }
        public String cInfoPregunta { get; set; }
        public String cRespuestaTexto { get; set; }
        public int idVisita { get; set; }
    }

    public class clsInformacionFicha
    {
        public int cInfo { get; set; }
        public int idFVGrupo { get; set; }            
        public string cPregunta { get; set; }
    }

    public class clsDetalleVisita 
    {
        public int idDetalleVisita { get; set; }
        public int idArchivo { get; set; } 
		public int idVisita { get; set; } 
		public int idTipoArchivo { get; set; } 
		public string cNombre { get; set; } 
		public string cArchivo{ get; set; } 
		public string cDescripcion { get; set; }
        public string dtFechaRegistro { get; set; }
        public float nLat { get; set; }
        public float nLong { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }
        public int idModulo { get; set; }
        public int idCategoriaArchivo { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public string dFechaMod { get; set; }
        public int idDescTipoDoc { get; set; }
        public bool lVigente { get; set; }

        public clsArchivo ToArchivo()
        {
            clsArchivo Obj = new clsArchivo();
            
            Obj.idSolicitud = this.idSolicitud;
            Obj.cNombreArchivo = this.cNombre;
            Obj.idTipoArchivo = this.idTipoArchivo;
            Obj.cArchivo = this.cArchivo;
            Obj.cDetalleArchivo = this.cNombre;
            Obj.idCli = this.idCli;
            Obj.idVisita = this.idVisita;
            Obj.idSolicitud = this.idSolicitud;
            Obj.idModulo = this.idModulo;
            Obj.idCategoriaArchivo = this.idCategoriaArchivo;
            Obj.idUsuReg = this.idUsuReg;
            Obj.dFechaReg = this.dtFechaRegistro;
            Obj.idUsuMod = this.idUsuMod;            
            Obj.dFechaMod = this.dFechaMod;
            Obj.idDescTipoDoc = this.idDescTipoDoc;
            Obj.lVigente = this.lVigente;
            Obj.idArchivos = this.idArchivo;
            Obj.idDetalleVisita = this.idDetalleVisita;

            return Obj;
        }

        public clsWCFRespuesta oResultado { get; set; }
    }

    public class clsClienteWFC 
    {
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; }        
        public string cDocumentoID { get; set; }
        public int nIdActivEco { get; set; }
        public int idActivEcoAdicional { get; set; }
        public int idActivEcoInterna { get; set; }
        public int IdTipoPersona{ get; set; }
        public string cApellidoPaterno  { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cNombre { get; set; }
        public string cRazonSocial { get; set; }
        public int idCodTelFijo { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cNumeroTelefono2 { get; set; }
        public string cCorreoCli { get; set; }
        public int idSexo { get; set; }
        public clsDireccion oDireccion { get; set; }
        public int idDireccion { get; set; }
        public int idUsuario { get; set; }
        public clsWCFRespuesta oResultado { get; set; }
        public string cNombres
        {
            get
            {
                return this.cApellidoPaterno + " " + this.cApellidoMaterno + " " + this.cNombre;
            }
        }
        public int idCargo { get; set; }
        public int idAgencia { get; set; }
        public int nDigitoVerificador { get; set; }
        public int idEstadoCivil { get; set; }
        public int idUbigeoNacimiento { get; set; }
        public string dFechaNacimiento { get; set; }
        public int nNumPerDepend { get; set; }
        public int idCli_vinculado { get; set; }
        public List<clsWFCDireccionCliente> xmlDireccion { get; set; }
    }

    public class clsDireccion
    {
        public int idDireccion { get; set; }
        public int idCli { get; set; }
        public int idUbigeo { get; set; }
        public string cDireccion { get; set; }
        public string cReferenciaDireccion { get; set; }
        public bool lVigente { get; set; }
        public int idTipoDireccion { get; set; }
        public int idTipoZona { get; set; }
        public string cDesZona { get; set; }
        public int idTipoVia { get; set; }
        public string cDesVia { get; set; }
        public string cDepartamento { get; set; }
        public string cInterior { get; set; }
        public string cManzana { get; set; }
        public string cLote { get; set; }
        public string cKilometro { get; set; }
        public string cBlock { get; set; }
        public string cEtapa { get; set; }
        public string cNumero { get; set; }
        public int idTipoVivienda { get; set; }
        public string cdescOtros { get; set; }
        public string cNombrePropietario { get; set; }
        public bool lDirPrincipal { get; set; }
        public int idSector { get; set; }
        public string cCodSuministro { get; set; }
        public int idTipoConstruccion { get; set; }
        public int nAñoReside { get; set; }
        public DateTime dFecHorReg { get; set; }
        public int idSuministro { get; set; }
        public double nLat { get; set; }
        public double nLong { get; set; } 
    }

    public class EstadoVisita
    { 
        public static int PLANIFICADO = 1;
        public static int VISITADO =2;
        public static int ANULADO = 3;
        public static int REPROGRAMADO= 4;
    }

    public class reglaValidacion
    {
        public  string type { get; set; }
        public  string value { get; set; }
        public  string msgError { get; set; }
    }
}
