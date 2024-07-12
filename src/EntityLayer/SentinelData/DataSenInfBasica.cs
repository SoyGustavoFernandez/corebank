using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenInfBasica
    {
        [DataMember]
        public string TDoc { get; set; }
        [DataMember]
        public string NDoc { get; set; }
        [DataMember]
        public string RelTDoc { get; set; }
        [DataMember]
        public string RelNDoc { get; set; }
        [DataMember]
        public string RazSoc { get; set; }
        [DataMember]
        public string NomCom { get; set; }
        [DataMember]
        public string TipCon { get; set; }
        [DataMember]
        public string IniAct { get; set; }
        [DataMember]
        public string ActEco { get; set; }
        [DataMember]
        public string FchInsRRPP { get; set; }
        [DataMember]
        public string NumParReg { get; set; }
        [DataMember]
        public string Fol { get; set; }
        [DataMember]
        public string Asi { get; set; }
        [DataMember]
        public string AgeRet { get; set; }
        [DataMember]
        public string ApeMat { get; set; }
        [DataMember]
        public string ApePat { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string DigVer { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string FecNac { get; set; }
        [DataMember]
        public string EstCon { get; set; }
        [DataMember]
        public string EstDom { get; set; }
        [DataMember]
        public string EstDomic { get; set; }
        [DataMember]        
        public string CondDomic { get; set; }
 
    }
}
