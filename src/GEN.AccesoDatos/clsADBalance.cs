using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADBalanceEva
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsBalance retornarPlantilla(int idPlantilla)
        {
            clsBalance lista = new clsBalance();
            DataTable dt = objEjeSp.EjecSP("GEN_RetBalancePtl_sp", idPlantilla);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsItemBalance()
                    {
                        idItem = (int)item["idItem"],
                        nOrden = (int)item["nOrden"],
                        idItemPadre = (int)item["idItemPadre"],
                        nNivel = (int)item["nNivel"],
                        lVigente = (int)item["lVigente"],
                        cDesItem = item["cDesItem"].ToString()
                    });
                }
            }

            return lista;
        }
    }

    public class clsADBalanceFueIng
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clslisBalanceFueIng retornarBalances(int idCli, int idClidFuente)
        {
            clslisBalanceFueIng lista = new clslisBalanceFueIng();
            DataTable dt = objEjeSp.EjecSP("CLI_RetlisBalFuenIng_sp", idCli, idClidFuente);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsBalanceFueIng()
                    {
                        idBalance       = (int)item["idBalance"]        ,
                        cDateBalance    = item["cDateBalance"].ToString(),
                        idFuenteIngreso = (int)item["idFuenteIngreso"]  ,
                        lAuditado       = (bool)item["lAuditado"]       ,
                        lMonExtran      = (bool)item["lMonExtran"]      ,
                        cContador       = item["cContador"].ToString()  ,
                        cMailConta      = item["cMailConta"].ToString() ,
                        cDirConta       = item["cDirConta"].ToString()  ,
                        cDocideCon      = item["cDocideCon"].ToString(),
                        cNumTelCon      = item["cNumTelCon"].ToString() ,
                        cCodCpp         = item["cCodCpp"].ToString()    ,
                        dFechaReg       = (DateTime)item["dFechaReg"]   ,
                        idUsuReg        = (int)item["idUsuReg"]         ,
                        idEstado        = (int)item["idEstado"]
                    });
                }
            }

            return lista;
        }

        public clslisDetalleBalance retornaDetallBalance(int idBalance)
        {
            clslisDetalleBalance lista = new clslisDetalleBalance();
            DataTable dt = objEjeSp.EjecSP("CLI_RetDetalleBalance_sp", idBalance);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsDetalleBalance()
                    {
                        idBalance   = (int)item["idBalance"]        ,
                        nOrden      = (int)item["nOrden"]           ,
                        cDesItem    = item["cDesItem"].ToString()   ,
                        nNivel      = (int)item["nNivel"]           ,
                        lVigente    = (int)item["lVigente"]         ,
                        nMonto      = (decimal)item["nMonto"]
                    });
                }
            }

            return lista;
        }

        public void insertarBalance(clsBalanceFueIng objBalance, clslisDetalleBalance detaleBalance)
        {

            
            string xmBalance  =@"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsbalance",
                                          from item in detaleBalance
                                          select new XElement("dtbalance",
                                                              new XAttribute("idBalance", item.idBalance),
                                                              new XAttribute("cDesItem", item.cDesItem),
                                                              new XAttribute("lVigente", item.lVigente),
                                                              new XAttribute("nMonto", item.nMonto),
                                                              new XAttribute("nNivel", item.nNivel),
                                                              new XAttribute("nOrden", item.nOrden)))).ToString();

            objEjeSp.EjecSPAlm("CLI_InsBalFuenIng_sp", objBalance.idFuenteIngreso,
                                                                 objBalance.lAuditado,
                                                                 objBalance.lMonExtran,
                                                                 objBalance.cContador,
                                                                 objBalance.cMailConta,
                                                                 objBalance.cDirConta,
                                                                 objBalance.cDocideCon,
                                                                 objBalance.cNumTelCon,
                                                                 objBalance.cCodCpp,
                                                                 objBalance.dFechaReg,
                                                                 objBalance.idUsuReg,
                                                                 objBalance.idEstado,
                                                                 xmBalance);	
        }

    }
}
