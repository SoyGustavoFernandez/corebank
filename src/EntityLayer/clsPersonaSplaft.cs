using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsPersonaSplaft:ICloneable
    {
        public string cNombreCompleto { get; set; }
        public int nCodOperacion { get; set; }
        public int nCodCli { get; set; }
        public int nTipoRol { get; set; }
        public int nTipoRelacion { get; set; }
        public int nCondicionResidencia { get; set; }
        public int nTipoPersona { get; set; }
        public int nTipoDocumento { get; set; }
        public int nTipoDocSPLAFT { get; set; }
        public string cNumeroDocumento { get; set; }
        public string cNumeroRuc { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cApellidoCasado { get; set; }
        public string cNombres { get; set; }
        public int nTipoOcupacion { get; set; }
        public int nCodCIUU { get; set; }
        public int idCIIUNivel1 { get; set; }
        public int idCIIUNivel2 { get; set; }
        public string cDescripcionOcupacion { get; set; }
        public int nTipoCargo { get; set; }
        public int NIdUbigeo { get; set; }
        public string cDireccion { get; set; }
        public string codPais { get; set; }
        public string cPais { get; set; }
        public string codDepartamento { get; set; }
        public string cDepartamento { get; set; }
        public string codProvincia { get; set; }
        public string cProvincia { get; set; }
        public string codDistrito { get; set; }
        public string cDistrito { get; set; }
        public string cTelefono { get; set; }
        public string cRazonSocial { get; set; }
        public bool bPresencia { get; set; }
        public string cPartidaRegistral { get; set; }
        public string cNombreComercial { get; set; }
        public int idLista { get; set; }
        public bool bNegocio { get; set; }
        public int nTipoPerClas { get; set; }
        public string cCargo { get; set; }
        public string cOcupacion { get; set; }
        public string ctipoPersona { get; set; }
        public DateTime dFecNac { get; set; }
        public string cCodPostal { get; set; }
        public bool lSocio { get; set; }
        public int nidNacionalidad { get; set; }
        public string cNacionalidad { get; set; }
        public string cCorreoCli { get; set; }
        public string cOcupacionOtros { get; set; }
        public string nRucAlterno { get; set; } 

        public object Clone()
        {
            clsPersonaSplaft p = (clsPersonaSplaft)this.MemberwiseClone();
            return p;
        }
    }

    public class clsListaPersonaSplaft : List<clsPersonaSplaft>, ICloneable
    {
        public object Clone()
        {
            var clone = new clsListaPersonaSplaft();
            ForEach(item => clone.Add((clsPersonaSplaft)item.Clone()));
            return clone;
        }
    }

    public class clsRegistroOperacion
    {
        public int nidKardex { get; set; }
        public DateTime dfechaOperacion { get; set; }
        public DateTime dhoraOperacion { get; set; }
        public int ncodEmpresa { get; set; }
        public string cdescripcion { get; set; }
        public int nidModalidad { get; set; }
        public int nidDetalleRO { get; set; }
        public clsListaPersonaSplaft detalle { get; set; }
        public int idInusual { get; set; }
        public int idDetalleInusual { get; set; }
        public string corigen { get; set; }
        public string cdestino { get; set; }
        public decimal dMontoOperacion { get; set; }
        public int nCodMoneda { get; set; }
        public int nCuenta { get; set; }
        public int nModulo { get; set; }
        public int idTipoOperacion { get; set; }
        public int idTipoPago { get; set; }
        public int idSplaftDetOrdenPago { get; set; }
        public string cSplaftDetOrdenPago { get; set; }
    }

}
