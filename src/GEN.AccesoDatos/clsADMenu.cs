using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using System.Xml.Linq;

namespace GEN.AccesoDatos
{
    public class clsADMenu
    {
        clsGENEjeSP objejecuta = new clsGENEjeSP();
        public DataTable LisTreeMenByPer(int idPerfil)
        {
            try
            {
                return objejecuta.EjecSP("GEN_LisTreeMenByPer_sp", idPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable listarMenuPorPerfil(int idPerfil)
        {
            return objejecuta.EjecSP("GEN_listaMenuPerfil_sp", idPerfil);
        }

        public void insertarMenuPerfil(clslisMenu listamenu, int idPerfil)
        {
            
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsmenuperfil",
                                          from item in listamenu
                                          select new XElement("dtmenuperfil",
                                                              new XAttribute("idMenuPerfil", item.idMenuPerfil),
                                                              new XAttribute("idMenu", item.idMenu),
                                                              new XAttribute("idPerfil", idPerfil),
                                                              new XAttribute("lvigente", item.lActivo)))).ToString();

            objejecuta.EjecSP("GEN_InsActMenuPerfil_sp", cxml);
        }

        public DataTable listaropcionesmenu(int idModulo)
        {
            return objejecuta.EjecSP("GEN_listarMenu_sp", idModulo);
        }

        public void insertActMenu(clsMenu menu)
        {
            objejecuta.EjecSP("GEN_InsActMenu_sp", menu.idMenu    , menu.idMenuPadre  ,
                                                   menu.idModulo  , menu.nOrden       ,
                                                   menu.cMenu     , menu.cNameSpace   ,
                                                   menu.cFormMenu , menu.idTipoClass  ,
                                                   menu.idTipoMenu, menu.idTipoProc   ,
                                                   menu.lVigente  , menu.lBaseNegativa);
        }
    }
}
