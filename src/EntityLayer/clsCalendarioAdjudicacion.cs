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
   public class clsCalendarioAdjudicacion
    {
       public int  idCalendario	{get;set;}
       public int   idProceso {get;set;}
       public int  idEtapaCalendario {get;set;}
       public string cEtapaCalendario { get; set; }
       public DateTime dFechaInicio	{get;set;}
       public DateTime dFechaFin	{get;set;}
       public string cObservaciones	{get;set;}
       public int idUsuReg	{get;set;}
       public int?  idUsuMod	{get;set;}
       public DateTime dFechaReg	{get;set;}
       public DateTime? dFechaMod	{get;set;}
       public string lIndPlantilla {get;set;}
       public bool lVigente { get; set; }
       public int nOrden { get; set; }
       public clsListaDocumentoPorCalendario listaDocCal{get; set;}

       public clsCalendarioAdjudicacion() { }

       public clsCalendarioAdjudicacion(clsCalendarioAdjudicacion objCalAdj) 
       {
           this.idCalendario=objCalAdj.idCalendario;
           this.idProceso = objCalAdj.idProceso;
           this.idEtapaCalendario = objCalAdj.idEtapaCalendario;
           this.cEtapaCalendario = objCalAdj.cEtapaCalendario;
           this.dFechaInicio = objCalAdj.dFechaInicio;
           this.dFechaFin = objCalAdj.dFechaFin;
           this.cObservaciones = objCalAdj.cObservaciones;
           this.idUsuReg = objCalAdj.idUsuReg;
           this.idUsuMod = objCalAdj.idUsuMod;
           this.dFechaReg = objCalAdj.dFechaReg;
           this.dFechaMod = objCalAdj.dFechaMod;
           this.lIndPlantilla = objCalAdj.lIndPlantilla;
           this.lVigente = objCalAdj.lVigente;
           this.nOrden = objCalAdj.nOrden;	
       }
    }
   public class clsListaCalendarioAdj : List<clsCalendarioAdjudicacion>
   {
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
