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
    public  class clsFactoresTecnicos
    {
        public int? idFacTec { get; set; }
        public int nOrden { get; set; }
        public int? idProceso	{get;set;}
        public int idGrupo	{get;set;}
        public int idFacTecnicos {get;set;}
        public bool lVigente {get;set;}
        public string cDecripcion {get;set;}
        public decimal nPuntaje	{get;set;}
        public decimal P_Grupo	{get;set;}
        public int idTipoEvaFacTec	{get;set;}
        public string cTipoEval { get; set; }
        public int? idPadre { get; set; }
        public bool lSelect { get; set; }
        public clsFactoresTecnicos() { }
        public clsFactoresTecnicos(clsFactoresTecnicos objFacTec)
        {
            this.idFacTec = objFacTec.idFacTec;
            this.nOrden=objFacTec.nOrden;
            this.idProceso=objFacTec.idProceso;
            this.idGrupo = objFacTec.idGrupo;
            this.idFacTecnicos = objFacTec.idFacTecnicos;
            this.lVigente=objFacTec.lVigente;
            this.cDecripcion=objFacTec.cDecripcion;
            this.nPuntaje=objFacTec.nPuntaje;
            this.P_Grupo=objFacTec.P_Grupo;
            this.idTipoEvaFacTec=objFacTec.idTipoEvaFacTec;
            this.cTipoEval=objFacTec.cTipoEval;
            this.idPadre=objFacTec.idPadre;
            this.lSelect = objFacTec.lSelect;
        }

    }
    public class clsListaFactoresTecnicos:BindingList<clsFactoresTecnicos>
    {
       public clsListaFactoresTecnicos(IList<clsFactoresTecnicos> lstFacTec)
       {
           foreach (var obj in lstFacTec)
           {
               this.Add(new clsFactoresTecnicos(obj));
           }
       }

       public clsListaFactoresTecnicos() { }

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
    public class clsTipoFactoresTecnicos
    {
        public int idFacTecnicos {get;set;}
        public string cFacTecnicos{get;set;}
        public int? idPadre {get; set; }
        public int idTipoPedido { get; set; }
        public decimal nPuntaje {get; set;}
        public bool lSelec { get; set; }
        public bool lVigente {get; set;}
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
    public class clsListaTipoFacTecnicos : List<clsTipoFactoresTecnicos>
    {
        
    }
    public class clsEvaFactorTecnico
    {
        public int idEvaFacTec { get; set; }
        public int? idProveedor { get; set; }
        public int idProceso { get; set; }
        public int idFacTecnicos { get; set; }
        public int nOrden { get; set; }       
        public int idGrupo { get; set; }        
        public bool lVigente { get; set; }
        public string cDecripcion { get; set; }
        public decimal nPuntaje { get; set; }
        public decimal P_Grupo { get; set; }
        public bool CumpleReq { get; set; }
        public int idTipoEvaFacTec { get; set; }
        public string cTipoEval { get; set; }
        public int? idPadre { get; set; }
        public decimal nPuntajeMax {get;set;}
        public clsEvaFactorTecnico() { }

        public clsEvaFactorTecnico(clsEvaFactorTecnico objEvaFacTec)
        {
            this.idEvaFacTec = objEvaFacTec.idEvaFacTec;
            this.idProveedor =objEvaFacTec.idProveedor;
            this.idProceso = objEvaFacTec.idProceso;
            this.idFacTecnicos = objEvaFacTec.idFacTecnicos;
            this.nOrden = objEvaFacTec.nOrden;
            this.idGrupo = objEvaFacTec.idGrupo;
            this.lVigente = objEvaFacTec.lVigente;
            this.cDecripcion = objEvaFacTec.cDecripcion;
            this.nPuntaje = objEvaFacTec.nPuntaje;
            this.P_Grupo = objEvaFacTec.P_Grupo;
            this.CumpleReq = objEvaFacTec.CumpleReq;
            this.idTipoEvaFacTec = objEvaFacTec.idTipoEvaFacTec;
            this.cTipoEval = objEvaFacTec.cTipoEval;
            this.idPadre = objEvaFacTec.idPadre;
            this.nPuntajeMax = objEvaFacTec.nPuntajeMax;
        }
        
    }
    public class clsListaEvaFactorTecnico : List<clsEvaFactorTecnico>
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
