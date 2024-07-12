using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsBiometriaExcep
    {
        public int idBiometriaExcep { get; set; }
        public string cBiometriaExcep { get; set; }
        public string cDocumentoID { get; set; }
        public int idEstadoSolicitud { get; set; }
        public int idMotivoBiometriaExcep { get; set; }
        public string cNombreArchivo { get; set; }
        public string cExtencion { get; set; }
        public byte[] bArchivo { get; set; }
        public int idUsuReg { get; set; }
        public DateTime dFechaReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime dFechaMod { get; set; }
        public bool lVigente { get; set; }
        public int idTipoArchivo { get; set; }
        public int idKardexOperacion { get; set; }
        public int idEstadoExcepcion { get; set; }
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        public int idCliente { get; set; }
        public int idTipoDocumento { get; set; }


        public int idCli { get; set; }
        public string cNombres { get; set; }
        public string cMotivoBiometriaExcep { get; set; }
        public string cNombreUsuarioReg { get; set; }
        public string cWinUserReg { get; set; }
        public string cTipoArchivo { get; set; }
        public string cEstadoSolicitud { get; set; }
        public string cEstadoExcepcion { get; set; }
        public string cAgencia { get; set; }
        public string cEstablecimiento { get; set; }

        public int idSolAproba { get; set; }
        public int idTipoOperacion { get; set; }
        public string cTipoOperacion { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public decimal nMonto { get; set; }
        public string cMoneda { get; set; } 
        [XmlIgnore]
        public List<clsAprobaSolici> lstAprobaSolici { get; set; }

        public clsBiometriaExcep()
        {
            idBiometriaExcep        = 0;
            cBiometriaExcep         = String.Empty;
            cDocumentoID            = String.Empty;
            idEstadoSolicitud       = 0;
            idMotivoBiometriaExcep  = 0;
            cNombreArchivo          = String.Empty;
            cExtencion              = String.Empty;
            bArchivo                = new byte[0];
            idUsuReg                = 0;
            dFechaReg               = clsVarGlobal.dFecSystem;
            idUsuMod                = 0;
            dFechaMod               = clsVarGlobal.dFecSystem;
            lVigente                = false;
            idTipoArchivo           = 0;
            idKardexOperacion       = 0;
            idEstadoExcepcion       = 0;
            idAgencia               = 0;
            idEstablecimiento       = 0;
            idCliente               = 0;
            idTipoDocumento         = 0;

            idCli                   = 0;
            cNombres                = String.Empty;
            cMotivoBiometriaExcep   = String.Empty;
            cNombreUsuarioReg       = String.Empty;
            cWinUserReg             = String.Empty;
            cTipoArchivo            = String.Empty;
            cEstadoSolicitud        = String.Empty;
            cEstadoExcepcion        = String.Empty;
            cAgencia                = String.Empty;
            cEstablecimiento        = String.Empty;

            idSolAproba             = 0;
            idTipoOperacion         = 0;
            cTipoOperacion          = String.Empty;
            idProducto              = 0;
            cProducto               = String.Empty;
            nMonto                  = 0;
            cMoneda                 = String.Empty;

            lstAprobaSolici         = new List<clsAprobaSolici>();
        }
    }
}
