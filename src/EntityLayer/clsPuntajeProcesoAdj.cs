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
   public class clsPuntajeProcesoAdj
    {
       public int? idPuntaje { set; get;}
       public int? idProceso {set;get;}
       public int? idGrupo {set;get;}

       public decimal nPuntajeMin {set;get;}
       public decimal nEvaEconomica {set;get;}
       public decimal nEvaTecnica {set;get;}
       public decimal nFacEconomica {set;get;}
       public decimal nFacTecnica {set;get;}

       public int idUsuReg {set;get;}
       public int? idUsuMod {set;get;}
       public DateTime dFechReg {set;get;}
       public DateTime? dFechaMod { set; get; }
       public bool lVigente { set; get; }

       public clsPuntajeProcesoAdj(clsPuntajeProcesoAdj objPtjAdj)
       {
           this.idPuntaje = objPtjAdj.idPuntaje;
           this.idProceso = objPtjAdj.idProceso;
           this.idGrupo = objPtjAdj.idGrupo;
           this.nPuntajeMin = objPtjAdj.nPuntajeMin;
           this.nEvaEconomica = objPtjAdj.nEvaEconomica;
           this.nEvaTecnica = objPtjAdj.nEvaTecnica;
           this.nFacEconomica = objPtjAdj.nFacEconomica;
           this.nFacTecnica = objPtjAdj.nFacTecnica;
           this.idUsuReg = objPtjAdj.idUsuReg;
           this.idUsuMod = objPtjAdj.idUsuMod;
           this.dFechReg = objPtjAdj.dFechReg;
           this.dFechaMod = objPtjAdj.dFechaMod;
           this.lVigente = objPtjAdj.lVigente;          
       }

       public clsPuntajeProcesoAdj()
       {
       }
   }
   public class clsListaPuntajeProcesoAdj : BindingList<clsPuntajeProcesoAdj>
   {
       public clsListaPuntajeProcesoAdj(IList<clsPuntajeProcesoAdj> lstPtjeProc)
       {
           foreach (var obj in lstPtjeProc)
           {
               this.Add(new clsPuntajeProcesoAdj(obj));
           }
       }

       public clsListaPuntajeProcesoAdj() { }

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
