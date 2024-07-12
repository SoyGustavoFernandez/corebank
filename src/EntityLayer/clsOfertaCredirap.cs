using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Data;

namespace EntityLayer
{
    public class clsOfertaCredirap
    {
        [DataMember]
        public string message { get; set; }
        public clsClienteCredirap[] cliente { get; set; }
        public clsOferta[] propuestas { get; set; }

    }

    public class clsClienteCredirap
    {
        [DataMember]
        public int corebank_id { get; set; }
        public string documento_tipo { get; set; }
        public string documento_id { get; set; }
        public string nombre { get; set; }
        public int establecimiento_id { get; set; }
        public int asesor_id { get; set; }
    }

    public class clsOferta
    {
        [DataMember]
        public int producto { get; set; }
        public string moneda { get; set; }
        public int cuotas { get; set; }
        public decimal monto { get; set; }
        public decimal tasa_interes { get; set; }
        public int perfil_id { get; set; }
        public int tipo_grupo_campania { get; set; }
    }

    public class clsClienteOfertaCredirapPro
    {
        public int idCli { get; set; }
        public string cNomCorto { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public int idEstablecimiento { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public string cMoneda { get; set; }
        public int  nPlazo { get; set; }
        public decimal nMontoOferta { get; set; }
        public decimal nTasa { get; set; }
        public int idPerfil { get; set; }
        public int idTipoGrupoCamp { get; set; }
        public string cOferta { get; set; }
        public string cMensaje { get; set; }
        public string cMensajeSMS { get; set; }
    }
}
