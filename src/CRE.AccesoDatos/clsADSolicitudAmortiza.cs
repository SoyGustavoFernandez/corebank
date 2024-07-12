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
    public class clsADSolicitudAmortiza
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsSolicitudAmortiza retornarDatSolAmortiza(int idCli)
        {
            clsSolicitudAmortiza soliAmortiza=null;

            DataTable dt=objEjeSp.EjecSP("CRE_RetSoliAmortiza_sp", idCli);
            if (dt.Rows.Count>0)
            {
                soliAmortiza= new clsSolicitudAmortiza();

                foreach (DataRow item in dt.Rows)
                {

                    soliAmortiza.idSolicitudAmortiza = (int)item["idSolicitudAmortiza"] ;
                    soliAmortiza.idCli              = (int)item["idCli"]                ;
                    soliAmortiza.idSolicitud        = (int)item["idSolicitud"]          ;
                    soliAmortiza.dFechaReg          = (DateTime)item["dFechaReg"]       ;
                    soliAmortiza.idUsuReg           = (int)item["idUsuReg"]             ;
                    soliAmortiza.idEstado           = (int)item["idEstado"]             ;

                    soliAmortiza.listaDetalle.Add(new clsDetSolAmortiza()
                    {
                        idDetSolAmortiza    = (int)item["idDetSolAmortiza"]     ,
                        idSolicitudAmortiza = (int)item["idSolicitudAmortiza"]  ,
                        idCuenta            = (int)item["idCuenta"]             ,
                        nCapital            = (decimal)item["nCapital"]         ,
                        nInteres            = (decimal)item["nInteres"]         ,
                        nIntComp            = (decimal)item["nIntComp"]         ,
                        nMora               = (decimal)item["nMora"]            ,
                        nGastos             = (decimal)item["nGastos"]          ,
                        idMoneda            = (int)item["idMoneda"]             ,
                        idEstado            = (int)item["idEstadoDet"]
                    });
                }
            }

            return soliAmortiza;
        }

        public void insertaActSolAmortiza(clsSolicitudAmortiza solAmortiza,clslisDetSolAmortiza listaDEtAmortiza)
        {

            string cxmlDetalle = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetamortiza",
                                          from item in listaDEtAmortiza
                                          select new XElement("dtdetamortiza",
                                                              new XAttribute("idDetSolAmortiza", item.idDetSolAmortiza),
                                                              new XAttribute("idSolicitudAmortiza", item.idSolicitudAmortiza),
                                                              new XAttribute("idCuenta", item.idCuenta),
                                                              new XAttribute("nCapital", item.nCapital),
                                                              new XAttribute("nInteres", item.nInteres),
                                                              new XAttribute("nIntComp", item.nIntComp),
                                                              new XAttribute("nMora", item.nMora),
                                                              new XAttribute("nGastos", item.nGastos),
                                                              new XAttribute("idEstado", item.idEstado),
                                                              new XAttribute("dFechaReg", item.dFechaReg),
                                                              new XAttribute("idUsuReg", item.idUsuReg)))).ToString();

            objEjeSp.EjecSP("CLI_InsActSolAmortiza_sp", solAmortiza.idSolicitudAmortiza,
                                                        solAmortiza.idCli,
                                                        solAmortiza.idSolicitud,
                                                        solAmortiza.idUsuReg,
                                                        solAmortiza.dFechaReg,
                                                        solAmortiza.idEstado,
                                                        cxmlDetalle);
        }

        public void actualizaDetSolAmortiza(int idDetSolAmortiza)
        {
            objEjeSp.EjecSP("CLI_ActDetSolAmortiza_sp", idDetSolAmortiza);
        }

        public DataTable ADLisSolOpinionRecupera()
        {
            return objEjeSp.EjecSP("CRE_LisSolOpinionRecupera_SP");
        }

        public DataTable ADInsertarOpinionRefinanciacion(int idSolicitud, bool lFavorable, string cOpinion)
        {
            return objEjeSp.EjecSP("CRE_InsertarOpinionRefinanciacion_SP", idSolicitud, lFavorable, cOpinion, clsVarGlobal.User.idUsuario);
        }

        public DataTable ADrptOpinionRefinanciacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_rptOpinionRefinanciacion_SP", idSolicitud);
        }

        public DataTable ADlistaOpinionRefinaXUsuarios(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_listaOpinionRefinaXUsuarios_SP", idUsuario);
        }

        public DataTable ObtenerDetSoliRefinancia(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDetalleSolicitudRefi_SP", idSolicitud);
        }
        public DataTable consultarOpinionRecuperacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaOpinionRecu_SP", idSolicitud);
        }
    }
}
