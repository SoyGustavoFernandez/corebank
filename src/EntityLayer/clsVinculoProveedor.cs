using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsVinculoProveedor
    {
        public int idVinculoProveedor { get; set; }
        public int? idProcesoAdj { get; set; }
        public int idProveedor { get; set; }
        public string cNroDocumento { get; set; }
        public string cProveedor { get; set; }
        public DateTime dFechaReg { get; set; }
        public int idUsuReg { get; set; }
        public int? idUsuMod { get; set; }
        public DateTime? dFechMod { get; set; }
        public bool lvigente { get; set; }
        public int? nGrupo { get; set; }
        public int idEstadoEvaProveedor { get; set; }
        public decimal? nValRef { get; set; }
        public string cEstadoEvaProveedor { get; set; }
        public bool lContinuar { get; set; }
        public decimal? nPuntFacEco { get; set; }
        public decimal? nPuntFacTec { get; set; }
        public decimal? nPuntaje { get; set; }
        public bool? lGanadorTemp { get; set; }
        public int nCalificacion { get; set; }

        public clsVinculoProveedor() { }

        public clsVinculoProveedor(clsVinculoProveedor objVincProv)
        {
            this.idVinculoProveedor = objVincProv.idVinculoProveedor;
            this.idProcesoAdj = objVincProv.idProcesoAdj;
            this.idProveedor = objVincProv.idProveedor;
            this.cNroDocumento = objVincProv.cNroDocumento;
            this.cProveedor = objVincProv.cProveedor;
            this.dFechaReg = objVincProv.dFechaReg;
            this.idUsuReg = objVincProv.idUsuReg;
            this.idUsuMod = objVincProv.idUsuMod;
            this.dFechMod = objVincProv.dFechMod;
            this.lvigente = objVincProv.lvigente;
            this.nGrupo = objVincProv.nGrupo;
            this.idEstadoEvaProveedor = objVincProv.idEstadoEvaProveedor;
            this.nValRef = objVincProv.nValRef;
            this.cEstadoEvaProveedor = objVincProv.cEstadoEvaProveedor;
            this.lContinuar = objVincProv.lContinuar;
            this.nPuntFacEco = objVincProv.nPuntFacEco;
            this.nPuntFacTec = objVincProv.nPuntFacTec;
            this.nPuntaje = objVincProv.nPuntaje;
            this.lGanadorTemp = objVincProv.lGanadorTemp;            
        }
        
    }
    public class clslistaVinculoProveedor : BindingList<clsVinculoProveedor> 
    {
        public clslistaVinculoProveedor() { }

        public clslistaVinculoProveedor(IList<clsVinculoProveedor> lstVincProv)
        {
            foreach (var item in lstVincProv)
            {
                this.Add(new clsVinculoProveedor(item));
            }
        }

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
   
}
