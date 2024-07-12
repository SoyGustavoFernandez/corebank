using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsClienteOfertas
    {
        public int idCli { get; set; }
        public string cTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public int idEstablecimiento { get; set; }
        public int idAsesor { get; set; }

        public int idProducto { get; set; }
        public string cMoneda { get; set; }
        public int nCuotas { get; set; }
        public decimal nMonto { get; set; }
        public decimal nTaza { get; set; }
        public int idPerfil { get; set; }
        public int idTipoGrupoCamp { get; set; }

        public string cMensaje { get; set; }
        public string cMensajeSMS { get; set; }

        public clsClienteOfertas()
        {
            this.idCli = 0;
            this.cTipoDocumento = string.Empty;
            this.cDocumentoID = string.Empty;
            this.cNombre = string.Empty;
            this.idEstablecimiento = 0;
            this.idAsesor = 0;

            this.idProducto = 0;
            this.cMoneda = string.Empty;
            this.nCuotas = 0;
            this.nMonto = decimal.Zero;
            this.nTaza = decimal.Zero;
            this.idPerfil = 0;
            this.idTipoGrupoCamp = 0;

            this.cMensaje = string.Empty;
            this.cMensajeSMS = string.Empty;
        }
    }
}
