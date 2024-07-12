using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsProcesoAdjudicacion
    {
        public int idProceso { get; set; }
        public int idTipoProceso { get; set; }
        public int idUsuReg { get; set; }
        public string cUsuReg { get; set; }
        public int? idUsuMod { get; set; }
        public DateTime? dFechaReg { get; set; }
        public DateTime? dFechaMod { get; set; }
        public int idEstado { get; set; }
        public int idTipoEvaluacion { get; set; }
        public string cObservacion { get; set; }
        public string cObjetoAdquisicion { get; set; }
        public int idMoneda { set; get; }
        public int idTipoPedido { get; set; }
        public Boolean? lConfirmacion { get; set; }
        public string dfechaCulminacion { get; set; }
        public clslistaVinculoNotaPedido listarVinNotapedido { get; set; }
        public clsListaDetalleProcesoAdj listaDetalleProAdj { get; set; }
        public bool lIgv { get; set; }
        public decimal nMontoTotalIgv { get; set; }
        public List<clsVinculoProveedor> LstProveedores { get; set; }

        public clsProcesoAdjudicacion(int idProceso)
        {
            this.idProceso = idProceso;
            this.idTipoProceso = 0;
            this.idUsuReg = clsVarGlobal.User.idUsuario;
            this.dFechaReg = clsVarGlobal.dFecSystem;
            this.idEstado = 0;
            this.idTipoEvaluacion = 0;
            this.cObservacion = string.Empty;
            this.cObjetoAdquisicion = string.Empty;
            this.idMoneda = 1;
            this.idTipoPedido = 0;
        }

        public clsProcesoAdjudicacion() : this(0) { }

        public string obtenerXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

    }
    public class clsListaProcesoAdj : List<clsProcesoAdjudicacion>
    {
    }

}
