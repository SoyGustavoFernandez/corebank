
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace EntityLayer
{
public class clsModPagoOperacion
  {

      public int idTipoPago {get;set;}
      public string cDesTipoPago {get;set;}      
      public bool lOpeRetiro {get;set;}
      public bool lOpeApertura {get;set;}
      public bool lOpePagoComPago {get;set;}
      public bool lPagoCredito {get;set;}
      public bool lOpeDeposito { get; set; }
      public bool lOpeCancelacion { get; set; }

      public clsModPagoOperacion (){}

      public clsModPagoOperacion(clsModPagoOperacion objClas)
      {
          this.idTipoPago=objClas.idTipoPago;
          this.cDesTipoPago=objClas.cDesTipoPago;
          this.lOpeRetiro=objClas.lOpeRetiro;
          this.lOpeApertura=objClas.lOpeApertura;       
          this.lOpePagoComPago=objClas.lOpePagoComPago;
          this.lPagoCredito=objClas.lPagoCredito;
          this.lOpeCancelacion = objClas.lOpeCancelacion;
          this.lOpeDeposito = objClas.lOpeDeposito;
      }

  }
    public class clsListaModPagoOperacion : List<clsModPagoOperacion>
    {
        public string obtenerXml(){
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
