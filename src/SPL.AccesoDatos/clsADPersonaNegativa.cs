using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SPL.AccesoDatos
{
    public class clsADPersonaNegativa
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public clsListaPersonaNegativa ListarPersonaNegativa()
        { 
            clsListaPersonaNegativa listaNegativa = new clsListaPersonaNegativa();
            //ds = objEjeSp.EjecSP("GEN_ListarSPL_Credito", idKardex, idModulo);


            return listaNegativa;                
        }
         
        public void InsertarListaNegativa(clsListaPersonaNegativa listaNegativa)
        {
            try
            {
                XDocument xmldetalle = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                   new XElement("dsdataset",
                                   from item in listaNegativa
                                   select new XElement("dsdatatable",
                                       
                                                        new XAttribute("idPerNegativa", item.idPerNegativa),
                                                        new XAttribute("idTipoPersona", item.idTipoPersona),
                                                        new XAttribute("cNombres", item.cNombre),                                      
                                                        new XAttribute("cApePaterno", item.cApePaterno),
                                                        new XAttribute("cApeMaterno", item.cApeMaterno),
                                                        new XAttribute("cApeCasado", item.cApeCasado),
                                                        new XAttribute("cNombre", item.cNombre),
                                                        new XAttribute("idEstado", item.idEstado),
                                                        new XAttribute("idTipoDoc", item.idTipoDoc),
                                                        new XAttribute("cNumDoc", item.cNumDoc),
                                                        new XAttribute("idTipoLista", item.idTipoLista),
                                                        new XAttribute("dFechaRegistro", item.dFechaRegistro))
                                                        )
                                );
                string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmldetalle.ToString();
                ds = objEjeSp.EjecSP("GEN_InsertarListaNegativa", xmldetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
