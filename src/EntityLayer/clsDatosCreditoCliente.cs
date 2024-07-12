using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsDatosCreditoCliente
    {
        public int idCuenta { get; set; }
        [XmlIgnore]
        public int idContable { get; set; }
        [XmlIgnore]
        public string cContable { get; set; }
        [XmlIgnore]
        public int idEstado { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        [XmlIgnore]
        public string cNombre { get; set; }
        public int idCliente { get; set; }
        [XmlIgnore]
        public DateTime dFechaDesembolso { get; set; }
        [XmlIgnore]
        public int nFrecuencia { get; set; }
        [XmlIgnore]
        public decimal nMonto { get; set; }
        [XmlIgnore]
        public int nCuotas { get; set; }
        [XmlIgnore]
        public int idMoneda { get; set; }
        [XmlIgnore]
        public int idProducto { get; set; }
        [XmlIgnore]
        public string cProducto { get; set; }
        [XmlIgnore]
        public decimal nMontoCuota { get; set; }
        [XmlIgnore]
        public int nAtraso { get; set; }
        [XmlIgnore]
        public string cDocumentoID { get; set; }
        [XmlIgnore]
        public string cDireccion { get; set; }
        [XmlIgnore]
        public string cCodCliente { get; set; }
        [XmlIgnore]
        public string cMoneda { get; set; }
        [XmlIgnore]
        public int idTipoDocumento { get; set; }
        [XmlIgnore]
        public bool lCoberturaSegDesg { get; set; }
        [XmlIgnore]
        public bool lSeleccionado { get; set; }

        public clsDatosCreditoCliente()
        {
            idCuenta                = 0;
            idEstado                = 0;
            cEstado                 = String.Empty;
            cNombre                 = String.Empty;
            idCliente               = 0;
            dFechaDesembolso        = clsVarGlobal.dFecSystem;
            nFrecuencia             = 0;
            nMonto                  = 0;
            nCuotas                 = 0;
            idMoneda                = 0;
            idProducto              = 0;
            cProducto               = String.Empty;
            nMontoCuota             = 0;
            nAtraso                 = 0;
            cDocumentoID            = String.Empty;
            cDireccion              = String.Empty;
            cCodCliente             = String.Empty;
            cMoneda                 = String.Empty;
            idTipoDocumento         = 0;
            lCoberturaSegDesg       = false;
            lSeleccionado           = false;

        }
    }
    public class clsDatosCreditoClienteComparer : IEqualityComparer<clsDatosCreditoCliente>
    {
        public bool Equals(clsDatosCreditoCliente x, clsDatosCreditoCliente y)
        {
            bool lValida = false;
            if (Object.ReferenceEquals(x, y)) return true;

            lValida = x != null && y != null && x.idCuenta.Equals(y.idCuenta) && x.idCliente.Equals(x.idCliente);

            return lValida;
        }

        public int GetHashCode(clsDatosCreditoCliente obj)
        {
            int hashIdCliente = obj.idCliente.GetHashCode();
            int hashIdCuenta = obj.idCuenta.GetHashCode();

            return hashIdCliente ^ hashIdCuenta;

        }
    }

}
