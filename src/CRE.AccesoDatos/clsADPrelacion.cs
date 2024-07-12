using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Xml.Linq;

namespace CRE.AccesoDatos
{
    public class clsADPrelacion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void insertarOrdenPrelacion(clsLisPrelacion listaconceptos,int idKardex)
        {   
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsconcepto",
                                          from item in listaconceptos
                                          select new XElement("dtconcepto",
                                                              new XAttribute("idCuenta", item.idcuenta),
                                                              new XAttribute("cConcepto", item.cConcepto),
                                                              new XAttribute("nOrden", item.nOrden)))).ToString();
            objEjeSp.EjecSPAlm("CRE_InsDetPagoPrelacion_sp", idKardex, cxml);
        }

    }
}
