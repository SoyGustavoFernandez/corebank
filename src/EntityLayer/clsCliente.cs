using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{

    /// <summary>
    /// entidad cliete de la empresa
    /// </summary>
    public class clsCliente
    {
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; }
        public int IdTipoPersona { get; set; }
        public string cDocumentoID { get; set; }
        public string cDocumentoAdicional { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cCorreoCli { get; set; }
        public int nIdActivEco { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cApellidoCasado { get; set; }
        public string cNombre { get; set; }
        public DateTime dFechaNacimiento { get; set; }
        public int idEstadoCivil { get; set; }
        public int idSexo { get; set; }
        public int idNivelInstruccion { get; set; }
        public int idProfesion { get; set; }
        public int idOcupacion { get; set; }
        public int idUbigeoNacimiento { get; set; }
        public int nNumPerDepend { get; set; }
        public int nNumHijos { get; set; }
        public int idEstadoCivilSBS { get; set; }
        public int idCargo { get; set; }
        public string cDescCargo { get; set; }
        

        public string cRazonSocial { get; set; }
        public string cNombreComercial { get; set; }
        public string cSiglas { get; set; }
        public DateTime dFechaConstitucion { get; set; }
        public string nNumPartReg { get; set; }
        public int nIdZonaReg { get; set; }
        public int nIdEstado { get; set; }
        public int idIdentificacion { get; set; }
        public bool lEmpleador { get; set; }
        public int idUbigeoPadre { get; set; }
        public int idPadreActividad { get; set; }

        private string _cNomCli;
        public string cNomCli
        {
            get { return _cNomCli; }
            set { _cNomCli = value; }
        }        

        public override string ToString()
        {
            return cNomCli;
        }

        public int idNacionalidad { get; set; }
        public int idResiddencia { get; set; }
        public int idPaisResidencia { get; set; }
        public int IdtipoDocAdicional { get; set; }
        public string cNumeroTelefono2 { get; set; }
        public int idTipoPerClasifica { get; set; }
        public string cNombreSeg { get; set; }
        public string cNombreOtros { get; set; }

        public string cCodCliente { get; set; }
        public int cCantEmpl { get; set; }
        public int idActivEcoInt { get; set; }
        public clslisFuentesIngreso lisFuentesIngreso = new clslisFuentesIngreso();
        public string cNombres
        {
            get
            {
                return this.cApellidoPaterno + " " + this.cApellidoMaterno + " " + this.cNombre;
            }
        }
        public int idClasifInterna { get; set; }
        public bool lIndDatosBasic { get; set; }

        public int nAniosActEco { get; set; }
        public int idTipoCliente { get; set; }

    }

    /// <summary>
    /// coleccion de la entidad cliente
    /// </summary>
    public class clsLisCliente:List<clsCliente>
    {
        
    }

    public class clsClienteRegistros
    {
        public int idCli { get; set; }
        public int idRegTel { get; set; }
        public int idCondicionTelf { get; set; }
        public string cNumeroTelefonico { get; set; }
        public int idTipoTelefono { get; set; }
    }
}
