using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CLI.AccesoDatos
{
    public class clsADFuentesIngreso
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisFuentesIngreso retornaFuentesIngreso(int idCli)
        {
            clslisFuentesIngreso lista = new clslisFuentesIngreso();
            DataTable dt = objEjeSp.EjecSP("CLI_RetFuenteIngreso_sp", idCli);

            if (dt.Rows.Count>0 )
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsFuentesIngreso()
                    {
                        idFuenteIngreso = (int)item["idFuenteIngreso"]  ,
                        idCli           = (int)item["idCli"]            ,
                        idTipoFuente    = (int)item["idTipoFuente"]     ,
                        idCliFuente     = (int)item["idCliFuente"]      ,
                        nIngresos       = (decimal)item["nIngresos"]    ,
                        idRelacLaboral  = (int)item["idRelacLaboral"]   ,
                        idCondiLaboral  = (int)item["idCondiLaboral"]   ,
                        nLaboraDesde    = (int)item["nLaboraDesde"]     ,
                        nFamMasculino   = (int)item["nFamMasculino"]    ,
                        nFamFemenino    = (int)item["nFamFemenino"]     ,
                        nNoFamMascu     = (int)item["nNoFamMascu"]      ,
                        nNoFamFeme      = (int)item["nNoFamFeme"]       ,
                        idCondicion     = (int)item["idCondicion"]      ,
                        dFechaRegistro  = (DateTime)item["dFechaRegistro"],
                        idUsuReg        = (int)item["idUsuReg"]         ,
                        idEstado        = (int)item["idEstado"]         ,
                        cCodEmpleado    = (string)item["cCodEmpleado"],
                        idActivEco      =(int)item["idEstado"]  ,
                        lIndPrincipal = (bool)item["lIndPrincipal"],
                        cReferCentroLaboral = (string)item["cReferCentroLaboral"],
                        cDetalleActivLaboral = (string)item["cDetalleActivLaboral"],
                        nAnios = (item["nAnios"]  == DBNull.Value)? 0 : Convert.ToInt32(item["nAnios"]),
                        nMeses = (item["nMeses"]  == DBNull.Value)? 0 : Convert.ToInt32(item["nMeses"]),
                        nDias = (item["nDias"] == DBNull.Value) ? 0 : Convert.ToInt32(item["nDias"])
                    });
                }
            }
            return lista;
        }

        public void insactFuentesIngreso(clslisFuentesIngreso lisfuentesIngreso)
        {            
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsfuentes",
                                          from item in lisfuentesIngreso
                                          select new XElement("dtfuentes",
                                                              new XAttribute("idFuenteIngreso", item.idFuenteIngreso),
                                                              new XAttribute("idCli", item.idCli),
                                                              new XAttribute("idTipoFuente", item.idTipoFuente),
                                                              new XAttribute("idCliFuente", item.idCliFuente),
                                                              new XAttribute("nIngresos", item.nIngresos),
                                                              new XAttribute("idRelacLaboral", item.idRelacLaboral),
                                                              new XAttribute("nLaboraDesde", item.nLaboraDesde),
                                                              new XAttribute("idCondiLaboral", item.idCondiLaboral),
                                                              new XAttribute("nFamMasculino", item.nFamMasculino),
                                                              new XAttribute("nFamFemenino", item.nFamFemenino),
                                                              new XAttribute("nNoFamMascu", item.nNoFamMascu),
                                                              new XAttribute("nNoFamFeme", item.nNoFamFeme),
                                                              new XAttribute("idCondicion", item.nNoFamFeme),
                                                              new XAttribute("dFechaRegistro", item.dFechaRegistro),
                                                              new XAttribute("idUsuReg", item.idUsuReg),
                                                              new XAttribute("idEstado", item.idEstado),
                                                              new XAttribute("dFechaModifica", clsVarGlobal.dFecSystem),
                                                              new XAttribute("idUsuModifica", clsVarGlobal.User.idUsuario),
                                                              new XAttribute("cCodEmpleado", item.cCodEmpleado),
                                                              new XAttribute("idActivEco", item.idActivEco),
                                                              new XAttribute("lIndPrincipal", item.lIndPrincipal),
                                                              new XAttribute("cReferCentroLaboral", item.cReferCentroLaboral),
                                                              new XAttribute("cDetalleActivLaboral", item.cDetalleActivLaboral),
                                                              new XAttribute("nAnios", item.nAnios),
                                                              new XAttribute("nMeses", item.nMeses),
                                                              new XAttribute("nDias", item.nDias)
                                                              ))).ToString();

            objEjeSp.EjecSP("CLI_InsActFuenteIngreso_sp", cxml);
        }

        public DataTable ADListarCondicionLaboralCliente()
        {
            return objEjeSp.EjecSP("CLI_ListarCondicionLaboral_SP");
        }
        public DataTable ADListarTipoMedTiempo()
        {
            return objEjeSp.EjecSP("GEN_ListaTipoMedTiempo_sp");
        }
        public DataTable ADValidaColByEmpresa(int idCli, int idCliJur)
        {
            return objEjeSp.EjecSP("CLI_ValidaColaboradorByEmpresa_sp", idCli, idCliJur);
        }
    }
}
