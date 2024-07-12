using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADGrupoEconomico
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisTipoGrupoEconomico listartipoGrupoEco()
        {
            clslisTipoGrupoEconomico listagrupoeco = new clslisTipoGrupoEconomico();

            DataTable dt = objEjeSp.EjecSP("CRE_listTipoGrupoEco_sp");

            foreach (DataRow item in dt.Rows)
            {
                listagrupoeco.Add(new clsTipoGrupoEconomico()
                {
                    idTipoGrupoEco  = (int)item["idTipoGrupoEco"],
                    cTipoGrupoEco   = item["cTipoGrupoEco"].ToString()
                });
            }

            return listagrupoeco;
        }

        public clslisGrupoEconomico listarGrupoEco()
        {
            clslisGrupoEconomico listagrupoeco = new clslisGrupoEconomico();

            DataTable dt = objEjeSp.EjecSP("CRE_listGrupoEco_sp");

            foreach (DataRow item in dt.Rows)
            {
                listagrupoeco.Add(new clsGrupoEconomico
                {
                    idTipoGrupoEco      = (int)item["idTipoGrupoEco"],
                    cGrupoEconomico     = item["cGrupoEconomico"].ToString(),
                    idEstado            = (int)item["idEstado"],
                    idGrupoEconomico    = (int)item["idGrupoEconomico"],
                    dFechaRegistro      = (DateTime)item["dFechaRegistro"]
                });
            }

            return listagrupoeco;
        }

        public void insertarGrupoEco(clsGrupoEconomico grupo,clsLisCliente participantes)
        {
            
            string cxml  =@"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsgrueco",
                                          from item in participantes
                                          select new XElement("dtgrueco",
                                                              new XAttribute("idCli", item.idCli)))).ToString();

            objEjeSp.EjecSP("CRE_InsGrupoEconomico_sp", grupo.cGrupoEconomico, grupo.idTipoGrupoEco, cxml);
        }

        public DataTable listarparticipantes(int idGrupoEconomico)
        {
           return objEjeSp.EjecSP("CRE_listPartiGrupoEco_sp", idGrupoEconomico);
        }

        public void actualizarGrupoEco(int idGrupoEconomico, string cGrupoEconomico, bool lVigente, clsLisCliente participantes)
        {
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsgrueco",
                                          from item in participantes
                                          select new XElement("dtgrueco",
                                                              new XAttribute("idGrupoEconomico", idGrupoEconomico),
                                                              new XAttribute("idCli", item.idCli),
                                                              new XAttribute("dFechaRegistro", clsVarGlobal.dFecSystem),
                                                              new XAttribute("idEstado", 1)))).ToString();


            objEjeSp.EjecSP("CRE_ActGrupoEconomico_sp", idGrupoEconomico, cGrupoEconomico, lVigente, cxml);
        }

        public DataTable ADListaGrupoEc(int idTipoGrupoEco)
        {
            return objEjeSp.EjecSP("CRE_ListaGrupoEconomico_SP", idTipoGrupoEco);
        }

    }
}
