using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using DEP.AccesoDatos.AhorroWeb;

namespace DEP.CapaNegocio.AhorroWeb
{
    public class clsCNAWCliente
    {
        #region Variables Privadas
        private clsADAWCliente objADAWCliente;
        private clsCNAWGeneral objCNAWGeneral;

        private DateTime dFechaSistema;
        private int idUsuario;
        private int idAgencia;
        #endregion

        #region Variables Públicas
        public clsAWCliente objAWCliente;
        public clsAWClienteNatural objAWClienteNatural;
        public List<clsAWDireccion> lstAWDireccion = new List<clsAWDireccion>();

        public clsAWLog objAWLog;
        public clsAWTramite objAWTramite;
        #endregion

        #region Constructores
        public clsCNAWCliente(bool conexion, clsAWTramite objAWTramite)
        {
            this.objADAWCliente = new clsADAWCliente(true);
            this.objCNAWGeneral = new clsCNAWGeneral(true, objAWTramite);

            this.idAgencia = objAWTramite.idAgencia;
            this.idUsuario = objAWTramite.idUsuario;
            this.dFechaSistema = objAWTramite.dFechaSistema;
        }
        #endregion

        #region Métodos Públicos
        public clsAWRegistrarCliente registrarCliente()
        {
            clsAWRegistrarCliente objAWRegistrarCliente = new clsAWRegistrarCliente();
            clsAWCliente objAWCliente = this.objCNAWGeneral.buscarCliente(0, this.objAWTramite.cDocumentoID);
            this.construirClienteTramite();
            this.construirClienteNaturalTramite();
            this.construirDireccionesTramite(objAWCliente);            
            List<clsAWVinculado> lstAWVinculado = new List<clsAWVinculado>();
            string xmlAWDirecciones = this.lstAWDireccion.ListObjectToXml<clsAWDireccion>("Table1", "dsDireccion");
            string xmlAWVinculados = lstAWVinculado.ListObjectToXml<clsAWVinculado>("Table1", "dsVinculo");            
                      
            if (objAWCliente != null)
            {
                this.objAWCliente.idCli = objAWCliente.idCli;
                this.objAWCliente.idTipoCliente = objAWCliente.idTipoCliente;                
                DataTable dt = objADAWCliente.actualizarCliente(
                    this.objAWCliente.idCli,
                    this.objAWCliente.cNumeroTelefono2,
                    this.objAWCliente.cCorreoCli,
                    this.objAWCliente.cDigitoVerificador,
                    this.objAWCliente.IdTipoPersona,
                    this.objAWCliente.idActivEcoInterna,
                    this.objAWClienteNatural.idUbigeoNacimiento,
                    this.objAWClienteNatural.idEstadoCivil,
                    this.objAWClienteNatural.idEstadoCivilSBS,
                    this.objAWClienteNatural.idNivelInstruccion,
                    this.objAWClienteNatural.idCargo,
                    this.objAWClienteNatural.idProfesion,
                    this.objAWClienteNatural.idOcupacion,
                    this.objAWClienteNatural.dFechaIniActEco,
                    xmlAWDirecciones
                );
                objAWRegistrarCliente.idCli = objAWCliente.idCli;
            }
            else
            {
                this.objAWCliente.idTipoCliente = 1;
                List<string> nombres = new List<string>();
                if (!string.IsNullOrEmpty(this.objAWClienteNatural.cApellidoPaterno)) nombres.Add(this.objAWClienteNatural.cApellidoPaterno.Trim());
                if (!string.IsNullOrEmpty(this.objAWClienteNatural.cApellidoMaterno)) nombres.Add(this.objAWClienteNatural.cApellidoMaterno.Trim());
                if (!string.IsNullOrEmpty(this.objAWClienteNatural.cApellidoCasada)) nombres.Add(this.objAWClienteNatural.cApellidoCasada.Trim());
                if (!string.IsNullOrEmpty(this.objAWClienteNatural.cNombre)) nombres.Add(this.objAWClienteNatural.cNombre.Trim());
                string cNombreCliente = string.Join(" ", nombres);
                DataTable dt = objADAWCliente.guardarCliente(
                    cNombreCliente,
                    this.objAWCliente.idTipoDocumento,
                    this.objAWCliente.IdTipoPersona,
                    this.objAWCliente.cDocumentoID,
                    this.objAWCliente.cDocumentoAdicional,
                    this.objAWCliente.IdtipoDocAdicional,
                    this.objAWCliente.idNacionalidad,
                    this.objAWCliente.idResiddencia,
                    this.objAWCliente.idPaisResidencia,
                    this.objAWCliente.idCodTelFijo,
                    this.objAWCliente.nNumeroTelefono,
                    this.objAWCliente.cNumeroTelefono2,
                    this.objAWCliente.cNumeroTelefono3,
                    this.objAWCliente.cCorreoCli,
                    this.objAWCliente.cCorreoCliAdicional,
                    this.objAWCliente.idActivEcoInterna,
                    xmlAWDirecciones,
                    this.objAWClienteNatural.cApellidoPaterno,
                    this.objAWClienteNatural.cApellidoMaterno,
                    this.objAWClienteNatural.cApellidoCasada,
                    this.objAWClienteNatural.cNombre,
                    this.objAWClienteNatural.CNombreSeg,
                    this.objAWClienteNatural.cNombreOtros,
                    this.objAWClienteNatural.dFechaNacimiento,
                    this.objAWClienteNatural.idUbigeoNacimiento,
                    this.objAWClienteNatural.idSexo,
                    this.objAWClienteNatural.idEstadoCivil,
                    this.objAWClienteNatural.idEstadoCivilSBS,
                    this.objAWClienteNatural.idProfesion,
                    this.objAWClienteNatural.cDescProfesion,
                    this.objAWClienteNatural.idNivelInstruccion,
                    this.objAWClienteNatural.idOcupacion,
                    this.objAWClienteNatural.idCargo,
                    this.objAWClienteNatural.cDescCargo,
                    xmlAWVinculados,
                    this.objAWClienteNatural.nNumHijos,
                    this.objAWClienteNatural.nNumPerDepend,
                    this.dFechaSistema,
                    this.idUsuario,
                    this.idAgencia,
                    this.objAWCliente.idTipoPerClasifica,
                    this.objAWCliente.lIndDatosBasic,
                    this.objAWClienteNatural.dFechaIniActEco,
                    this.objAWCliente.idEstadoCli,
                    this.objAWCliente.idActivEcoInterna,
                    this.objAWCliente.idActivEcoAdicional,                    
                    this.objAWClienteNatural.idRolHogar,
                    this.objAWClienteNatural.idSegmentoSocioEc,
                    this.objAWCliente.idMagnitudEmpresarial,     
                    this.objAWCliente.idEstadoContribuyente,
                    this.objAWCliente.idCondDomicilio,     
                    this.objAWCliente.dFechaEstadoCont,
                    this.objAWCliente.cDigitoVerificador
                );
                clsAWCliente objAWClienteReg = this.objCNAWGeneral.buscarCliente(0, this.objAWTramite.cDocumentoID);
                objAWRegistrarCliente.idCli = objAWClienteReg.idCli;                                
            }
            objAWRegistrarCliente.cPrimerNombre = this.primerNombre(this.objAWClienteNatural.cNombre);
            objAWRegistrarCliente.cNombre = this.objAWCliente.cNombre;
            objAWRegistrarCliente.idTipoCliente = this.objAWCliente.idTipoCliente;
            return objAWRegistrarCliente;
        }

        private string primerNombre(string cNombres)
        {
            return cNombres.IndexOf(' ') > 0 ? cNombres.Substring(0, cNombres.IndexOf(' ')) : cNombres;
        }

        public void construirClienteTramite()
        {
            this.objAWCliente.cNombre += " " + this.objAWClienteNatural.cApellidoPaterno + " " + this.objAWClienteNatural.cApellidoMaterno;
            this.objAWCliente.idTipoDocumento = 1; // DNI
            this.objAWCliente.IdTipoPersona = 1; //natural           
            this.objAWCliente.idNacionalidad = 0; //peruana
            this.objAWCliente.idResiddencia = 1; //reside en perú
            this.objAWCliente.idPaisResidencia = 173; //Perú
            this.objAWCliente.cNumeroTelefono2 = this.objAWTramite.cNumeroCelular1;
            this.objAWCliente.cNumeroTelefono3 = this.objAWTramite.cNumeroCelular2;
            this.objAWCliente.cCorreoCli = this.objAWTramite.cCorreoElectronico1;
            this.objAWCliente.cCorreoCliAdicional = this.objAWTramite.cCorreoElectronico2;
            this.objAWCliente.idActivEcoInterna = this.objAWTramite.idActivEcoInterna;            
            this.objAWCliente.lIndDatosBasic = true; //datos basicos            
            this.objAWCliente.idEstadoCli = 1; //activo
            this.objAWCliente.cDigitoVerificador = this.objAWTramite.nDigitoVerificador;
        }

        public void construirClienteNaturalTramite()
        {
            this.objAWClienteNatural.idProfesion = this.objAWTramite.idProfesion;
            int idEstadoCivil = this.objAWClienteNatural.idEstadoCivil;
            int idEstadoCivilSBS = idEstadoCivil == 5 ? 1 : idEstadoCivil == 6 ? 2 : idEstadoCivil;
            this.objAWClienteNatural.idEstadoCivilSBS = idEstadoCivilSBS;
        }

        public void construirDireccionesTramite(clsAWCliente objAWCliente)
        {
            if (objAWCliente == null)
            {
                this.lstAWDireccion[0].lDirPrincipal = true;                
            }
            else
            {
                this.lstAWDireccion[0].lDirPrincipal = false;
            }
            this.lstAWDireccion[0].idTipoDireccion = 5; //DIRECCION RENIEC
            this.lstAWDireccion[0].Estado = 'N'; //DIRECCION NUEVA
        }
        #endregion
    }
}
