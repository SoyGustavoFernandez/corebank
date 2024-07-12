using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ClsOfertaClienteExclusivo
    {
        public int idOferta {get; set;}
        public int idCli { get; set; }
        public int nPlazo { get; set; }
        public decimal nMontoOferta { get; set; }
        public string cGrupoProducto { get; set; }
        public string cTipoClienteExclusivo { get; set; }
        public string cTipoGrupoCamp { get; set; }
        public string cPeriodoCred { get; set; }
        public int idGrupoProducto	{ get; set; }
        public int idTipoClienteExclusivo{ get; set; }
        public int idTipoGrupoCamp	{ get; set; }
        public int idPeriodoCre { get; set; }
        public int idOperacion	{ get; set; }
        public string cOperacion{ get; set; }
        public int idModalidadCredito { get; set; }
        public string cModalidadCredito { get; set; }
        public int nMeses { get; set; }
        public int idGrupoCamp { get; set; }
        public string cGrupoCamp { get; set; }
        public string cDocumentoID { get; set; }
        public int idTipoDocumento { get; set; }
        public string cTipoDocumento { get; set; }
        public string cNombreCliOferta { get; set; }
        public int idDestinoCredito { get; set; }
        public string cDestinoCredito { get; set; }
        public bool lCargaAutomaticoProd { get; set; }
        public int idClasifInterna { get; set; }

    }
}
