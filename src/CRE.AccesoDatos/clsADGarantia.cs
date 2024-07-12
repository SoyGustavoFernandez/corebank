using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Xml.Linq;
using GEN.AccesoDatos;

namespace CRE.AccesoDatos
{
    public class clsADGarantia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCli"></param>
        /// <returns></returns>
        public clsListGarantia listarGarantias(int idCli)
        {
            clsListGarantia lisgarantias= new clsListGarantia();

            DataTable dtGarantias = objEjeSp.EjecSP("CRE_ListGarantias_sp", idCli);
            if (dtGarantias.Rows.Count > 0)
            {
                foreach (DataRow item in dtGarantias.Rows)
                {
                    lisgarantias.Add(new clsGarantia ()
                    {
                        idGarantia      = Convert.ToInt32(item["idGarantia"]),                       
                        cGarantia       = Convert.ToString(item["cGarantia"]),
                        idTipoGarantia  = Convert.ToInt32(item["idTipoGarantia"]),
                        idClaseGarantia = Convert.ToInt32(item["idClaseGarantia"]),
                        idMoneda        = Convert.ToInt32(item["idMoneda"]),
                        idEstado        = Convert.ToInt32(item["idEstado"]),
                        dFecRegistro    = Convert.ToDateTime(item["dFecRegistro"]),
                        nTipoCambio     = Convert.ToDecimal(item["nTipoCambio"]),                        
                        nMonGarantia    = Convert.ToDecimal(item["nMonGarantia"]),
                        nValorComercial = Convert.ToDecimal(item["nValorComercial"]),
                        nValorMercado   = Convert.ToDecimal(item["nValorMercado"]),
                        nValorEdifica   = Convert.ToDecimal(item["nValorEdifica"]),
                        nValorNuevo     = Convert.ToDecimal(item["nValorNuevo"]),
                        nValorRealiza   = Convert.ToDecimal(item["nValorRealiza"]),
                        cDesObserva     = Convert.ToString(item["cDesObserva"]),
                        idUbigeo        = Convert.ToInt32(item["idUbigeo"]),
                        cDireccion      = Convert.ToString(item["cDireccion"]),
                        cReferencia     = Convert.ToString(item["cReferencia"]),
                        nMonGravamen    = Convert.ToDecimal(item["nMonGravamen"]),
                        nMonGravamenSol = Convert.ToDecimal(item["nMonGravamenSol"]),
                        idGrupoGarantia = Convert.ToInt32(item["idGrupoGarantia"]),
                        nValorVenta     = Convert.ToDecimal(item["nValorVenta"]),
                        nMaxGarantia    = Convert.ToDecimal(item["nMaxGarantia"]),
                        idSituacion     = Convert.ToInt32(item["idSituacion"]),
                        cTipoEmisor     = Convert.ToString(item["cTipoEmisor"]),
                        dValorContable = Convert.ToDecimal(item["dValorContable"]),
                        dValorConstituido = Convert.ToDecimal(item["dValorConstituido"])
                        
                    });
                }
            }

            return lisgarantias;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCli"></param>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsListDetGarantia listarDetGarantia(int idGarantia)
        {
            clsListDetGarantia objDetGarantia = new clsListDetGarantia();

            DataTable dtGarantias = objEjeSp.EjecSP("CRE_RetDatGarantia_sp", idGarantia);
            if (dtGarantias.Rows.Count > 0)
            {
                foreach (DataRow item in dtGarantias.Rows)
                {
                    objDetGarantia.Add(new clsDetGarantia()
                    {
                        idCliGarantia   = Convert.ToInt32(item["idCliGarantia"]),
                        idGarantia      = Convert.ToInt32(item["idGarantia"]),
                        idCli           = Convert.ToInt32(item["idCli"]),
                        nMonGravado     = Convert.ToDecimal(item["nMonGravado"]),
                        nPorcentaje     = Convert.ToDecimal(item["nPorcentaje"]),
                        nMonGarantia    = Convert.ToDecimal(item["nMonGarantia"]),
                        nMonSaldoGrav   = Convert.ToDecimal(item["nMonSaldoGrav"]),
                        nMonGravadoSol  = Convert.ToDecimal(item["nMonGravadoSol"]),
                        nMonSaldoGravSol= Convert.ToDecimal(item["nMonSaldoGravSol"]),
                        lPropietario    = Convert.ToBoolean(item["lPropietario"])
                    });
                }
            }

            return objDetGarantia;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsLisEspecificacioGarantia listarespecificacion(int idGarantia)
        {
            clsLisEspecificacioGarantia listaespecificacion = new clsLisEspecificacioGarantia();

            DataTable dtEspecificacion= objEjeSp.EjecSP("CRE_RetEspecificacion_sp", idGarantia);

            if (dtEspecificacion.Rows.Count>0)
            {
                foreach (DataRow item in dtEspecificacion.Rows)
                {
                    listaespecificacion.Add(new clsEspecificacioGarantia
                                                {
                                                    idGarantia = Convert.ToInt32(item["idGarantia"]),
                                                    cCampo = Convert.ToString(item["cCampo"]),
                                                    cValCampo = Convert.ToString(item["cValCampo"]),
                                                    cTipoDato = Convert.ToString(item["cTipoDato"])
                                                }
                                            );
                }
            }

            return listaespecificacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGarantia"></param>
        /// <returns></returns>
        public clsDBResp insertarGarantia(clsGarantia objGarantia)
        {
            XDocument xmlGarantia = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
               new XElement("dsgarantia",
                               from item in objGarantia.lisDetGarantia
                               select new XElement("dtgarantia",
                                                   new XAttribute("idCli", item.idCli),
                                                   new XAttribute("idGarantia", item.idGarantia),
                                                   new XAttribute("nMonGravado", item.nMonGravado),
                                                   new XAttribute("nPorcentaje", item.nPorcentaje),
                                                   new XAttribute("nMonGarantia", item.nMonGarantia),
                                                   new XAttribute("nMonSaldoGrav", item.nMonSaldoGrav),
                                                   new XAttribute("lPropietario", item.lPropietario))
                                                 )
                              );
            string cxmlGarantia = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmlGarantia.ToString();

            XDocument xmlEspecificacion = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
               new XElement("dsespecifica",
                               from item in objGarantia.lisEspecificacion
                               select new XElement("dtespecifica",
                                                   new XAttribute("idGarantia", item.idGarantia),
                                                   new XAttribute("cCampo", item.cCampo),
                                                   new XAttribute("cValCampo", item.cValCampo),
                                                   new XAttribute("cTipoDato", item.cTipoDato)
                                                 )
                              ));

            string cxmlEspecificacion = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmlEspecificacion.ToString();

            DataSet dsGarPerAval = new DataSet("dsGarPerAval");
            dsGarPerAval.Tables.Add(objGarantia.dtGarPerAval);

            string cxmlGarPerAval = dsGarPerAval.GetXml();

            var ret = objEjeSp.EjecSP("CRE_InsGarantia_sp", 
                                        objGarantia.idGarantia      ,   objGarantia.cGarantia       ,
                                        objGarantia.idTipoGarantia  ,   objGarantia.idClaseGarantia ,
                                        objGarantia.idMoneda        ,   objGarantia.idEstado        ,
                                        objGarantia.dFecRegistro    ,   objGarantia.nTipoCambio     ,
                                        objGarantia.nMonGravamen    ,   objGarantia.nMonGarantia    ,
                                        objGarantia.nValorComercial ,   objGarantia.nValorMercado   ,
                                        objGarantia.nValorEdifica   ,   objGarantia.nValorNuevo     ,
                                        objGarantia.nValorRealiza   ,   objGarantia.cDesObserva     ,
                                        objGarantia.idUbigeo        ,   objGarantia.cDireccion      ,
                                        objGarantia.cReferencia     ,   cxmlGarantia                ,
                                        cxmlEspecificacion          ,   objGarantia.nValorVenta     ,
                                        objGarantia.idGrupoGarantia ,   cxmlGarPerAval              ,
                                        objGarantia.nMaxGarantia    ,   objGarantia.idSituacion     ,
                                        objGarantia.cTipoEmisor     ,   objGarantia.dValorContable  ,
                                        objGarantia.dValorConstituido);

            return new clsDBResp(ret);
        }

        public clsDBResp cambiarEstadoGarantia(clsGarantia objGarantia, int idUsuario, DateTime dFechaSIs)
        {
            return new clsDBResp(objEjeSp.EjecSP("CRE_ActualizarEstadoGarantia_SP", objGarantia.idGarantia, objGarantia.idClaseGarantia, objGarantia.idTipoGarantia, idUsuario, dFechaSIs));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGarantia"></param>
        public void actualizarGarantia(clsGarantia objGarantia)
        {
            XDocument xmlGarantia = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
               new XElement("dsgarantia",
                               from item in objGarantia.lisDetGarantia
                               select new XElement("dtgarantia",
                                                   new XAttribute("idCliGarantia", item.idCliGarantia),
                                                   new XAttribute("idCli", item.idCli),
                                                   new XAttribute("idGarantia", item.idGarantia),
                                                   new XAttribute("nMonGravado", item.nMonGravado),
                                                   new XAttribute("nPorcentaje", item.nPorcentaje),
                                                   new XAttribute("nMonGarantia", item.nMonGarantia),
                                                   new XAttribute("nMonSaldoGrav", item.nMonSaldoGrav),
                                                   new XAttribute("lPropietario", item.lPropietario))
                                                 )
                              );
            string cxmlGarantia = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmlGarantia.ToString();

            XDocument xmlEspecificacion = new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
               new XElement("dsespecifica",
                               from item in objGarantia.lisEspecificacion
                               select new XElement("dtespecifica",
                                                   new XAttribute("idGarantia", item.idGarantia),
                                                   new XAttribute("cCampo", item.cCampo),
                                                   new XAttribute("cValCampo", item.cValCampo),
                                                   new XAttribute("cTipoDato", item.cTipoDato)
                                                 )
                              ));

            string cxmlEspecificacion = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + xmlEspecificacion.ToString();


            objEjeSp.EjecSPAlm("CRE_UpdGarantia_sp",
                                                    objGarantia.idGarantia      ,
                                                    objGarantia.cGarantia       ,
                                                    objGarantia.idTipoGarantia  ,
                                                    objGarantia.idClaseGarantia ,
                                                    objGarantia.idMoneda        ,
                                                    objGarantia.idEstado        ,
                                                    objGarantia.dFecRegistro    ,
                                                    objGarantia.nTipoCambio     ,
                                                    objGarantia.nMonGravamen    ,
                                                    objGarantia.nMonGarantia    ,
                                                    objGarantia.nValorComercial ,
                                                    objGarantia.nValorMercado   ,
                                                    objGarantia.nValorEdifica   ,
                                                    objGarantia.nValorNuevo     ,
                                                    objGarantia.nValorRealiza   ,
                                                    objGarantia.cDesObserva     ,
                                                    objGarantia.idUbigeo        ,
                                                    objGarantia.cDireccion      ,
                                                    objGarantia.cReferencia     ,
                                                    cxmlGarantia                ,
                                                    cxmlEspecificacion);
        }

        public clsDBResp ADActualizaGravamenGarantia(int idGarantia)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizaGravamenGarantia_Sp", idGarantia);
            return new clsDBResp(dtResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarTipoGarantia()
        {
            return objEjeSp.EjecSP("CRE_ListTipoGarantia_sp");
        }

        public DataTable listarTipoGarantiaFiltroCambioEstado(int idClase)
        {
            return objEjeSp.EjecSP("CRE_ListTipoGarantiaFiltroCambioEstado_sp",idClase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarClaseGarantia()
        {
            return objEjeSp.EjecSP("CRE_ListClaseGarantia_sp");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarClaseGarantiaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FINClaseGarantia");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public clsListGarantia buscarGarantias(string codigo)
        {
            clsListGarantia lisgarantias = new clsListGarantia();

            DataTable dtGarantias = objEjeSp.EjecSP("CRE_BuscaGarantiaEspeci_sp", codigo);
            if (dtGarantias.Rows.Count > 0)
            {
                foreach (DataRow item in dtGarantias.Rows)
                {
                    lisgarantias.Add(new clsGarantia()
                    {
                        idGarantia = Convert.ToInt32(item["idGarantia"]),
                        cGarantia = Convert.ToString(item["cGarantia"]),
                        idTipoGarantia = Convert.ToInt32(item["idTipoGarantia"]),
                        idClaseGarantia = Convert.ToInt32(item["idClaseGarantia"]),
                        idMoneda = Convert.ToInt32(item["idMoneda"]),
                        idEstado = Convert.ToInt32(item["idEstado"]),
                        dFecRegistro = Convert.ToDateTime(item["dFecRegistro"]),
                        nTipoCambio = Convert.ToDecimal (item["nTipoCambio"]),
                        nMonGarantia = Convert.ToDecimal (item["nMonGarantia"]),
                        nValorComercial = Convert.ToDecimal (item["nValorComercial"]),
                        nValorMercado = Convert.ToDecimal (item["nValorMercado"]),
                        nValorEdifica = Convert.ToDecimal (item["nValorEdifica"]),
                        nValorNuevo = Convert.ToDecimal (item["nValorNuevo"]),
                        nValorRealiza = Convert.ToDecimal (item["nValorRealiza"]),
                        cDesObserva = Convert.ToString(item["cDesObserva"]),
                        idUbigeo = Convert.ToInt32(item["idUbigeo"]),
                        cDireccion = Convert.ToString(item["cDireccion"]),
                        cReferencia = Convert.ToString(item["cReferencia"]),
                        nMonGravamen = Convert.ToDecimal (item["nMonGravamen"]),
                        nMaxGarantia = Convert.ToDecimal (item["nMaxGarantia"])

                    });
                }
            }

            return lisgarantias;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarCriterioBus()
        {
            return objEjeSp.EjecSP("GEN_ListaCriBusGar_sp");
        }

        public DataTable listarCriterioBusXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinCriBusGar");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable buscarGarantiaCli(int nCriterio, string cValBusqueda)
        {
            return objEjeSp.EjecSP("CRE_BuscaGarCli_sp", nCriterio, cValBusqueda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="listagarantias"></param>
        /// <param name="idUsuario"></param>
        public clsDBResp insertaVinSolGar(int idSolicitud, clsListDetGarantia listagarantias, int idUsuario)
        {
            string cxmlGarantia = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                                    new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                                    new XElement("dsgarvin",
                                                  from item in listagarantias
                                                  select new XElement("dtgarvin",
                                                                      new XAttribute("idCliGarantia", item.idCliGarantia),
                                                                      new XAttribute("nGravamen", item.nMonGravado),
                                                                      new XAttribute("nPorcentaje", item.nPorcentaje))
                                                                    )).ToString();

            DataTable dtResult = objEjeSp.EjecSP("CRE_InsVinSolGar_sp", idSolicitud, cxmlGarantia, idUsuario);
            return new clsDBResp(dtResult);
        }

        public DataTable listarGarantiasByCli(int idSol,int idCli)
        {
            return objEjeSp.EjecSP("CRE_RetGarantiaInterv_sp",idSol, idCli);
        }

        public clsListDetGarantia listarGarVinculadasSol(int idSolicitud)
        {
            clsListDetGarantia lista = new clsListDetGarantia();

            DataTable dt = objEjeSp.EjecSP("CRE_ListVinSolGar_sp", idSolicitud);

            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsDetGarantia()
                    {
                        idCli = (int)item["idCli"],
                        idCliGarantia = (int)item["idCliGarantia"],
                        idGarantia = (int)item["idGarantia"],
                        nPorcentaje = (decimal)item["nPorcentaje"],
                        nMonGarantia = (decimal)item["nMonGarantia"],
                        nMonGravado = (decimal)item["nGravamen"],
                        cGarantia = item["cGarantia"].ToString(),
                        lReqCtaDep = (bool)item["lReqCtaDep"]
                    });

                }
                
            }

            return lista;
        }
        
        public DataTable listarGrupoGarantia()
        {
            return objEjeSp.EjecSP("CRE_ListGrupoGarantia_sp");
        }

        public DataTable listarGrupoGarantiaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FINGrupoGarantia");
        }

        public DataTable ADSaldoTasado(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaValorTasadoGarantia_sp", idSolicitud);
        }

        public DataTable ListaGarantiasCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ListaGarantiasCliente_SP", idCli);
        }
         
        public DataTable listarEstadosGarantiaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoGarantia");
        }

        public DataTable DatosGarantiaCredito(int idGarantia)
        {
            return objEjeSp.EjecSP("CRE_DatosGarantiaCredito_sp", idGarantia);
        }

        public DataTable RptControlInsBloGar(int nDias)
        {
            return objEjeSp.EjecSP("CRE_RptControlInsBloGar_sp", nDias);
        }

        public DataTable RptCreditosGarantias(DateTime dFecIni, DateTime dFecFin, int idTipoGarantia)
        {
            return objEjeSp.EjecSP("CRE_RptCreditosGarantias_SP", dFecIni, dFecFin, idTipoGarantia);
        }
        
        public clsDBResp insertaCambioVinCreGar(int idCuenta, clsListDetGarantia listagarantias, int idUsuario)
        {
            string cxmlGarantia = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                                    new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                                    new XElement("dsgarvin",
                                                  from item in listagarantias
                                                  select new XElement("dtgarvin",
                                                                      new XAttribute("idCliGarantia", item.idCliGarantia),
                                                                      new XAttribute("nGravamen", item.nMonGravado),
                                                                      new XAttribute("nPorcentaje", item.nPorcentaje))
                                                                    )).ToString();

            DataTable dtResult = objEjeSp.EjecSP("CRE_InsCambioVinCreGar_sp", idCuenta, cxmlGarantia, idUsuario);
            return new clsDBResp(dtResult);

        }

        public DataTable ADlistarGarPerAval(int idGarantia)
        {
            return objEjeSp.EjecSP("CRE_ListarGarPersonaAvalaId_SP", idGarantia);
        }

        public DataTable ADRptVencimientoTasacion(int nDias)
        {
            return objEjeSp.EjecSP("CRE_RptVencimientoTasacion_SP", nDias);
        }

        public DataTable ADrptCreditosConGarantia(int idProducto, int idMoneda, int idAgencia, int idAsesor)
        {
            return objEjeSp.EjecSP("CRE_RptCreditosConGarantia_SP", idProducto, idMoneda, idAgencia, idAsesor);
        }

        public DataTable ADHistoricoValorizacion(int idGarantia,int idEstado)
        {
            return objEjeSp.EjecSP("CRE_HistoricoValorizacion_SP", idGarantia,idEstado);
        }

        public DataTable ADValidaCuentaGarantia(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ValidaCuentaGarantia_SP", idCuenta);
        }

        public DataTable ADRetGarantiasIntervinientes(int idSolicitud, string xmlIntervinientes)
        {
            return objEjeSp.EjecSP("CRE_RetGarantiasIntervinientes_sp", idSolicitud, xmlIntervinientes);
        }

        public DataTable ADrptGarantiasCliente(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_rptGarantiasCliente_SP", idCli, idEstado);
        }

        public DataSet ADListaGarantiasIdClienteYDetalle(int idCli, int idEstado)
        {
            return objEjeSp.DSEjecSP("CRE_ListaGarantiasIdCliente_SP", idCli, idEstado);
        }

        public DataTable ADValidarGarEstadoCre(int idGarantia)
        {
            return objEjeSp.EjecSP("CRE_ValidarGarEstadoCre_SP", idGarantia);
        }

        public DataTable ADRegistrarSalidaGarantia(int idGarantia,
                                                        int idTipoGarantia,
                                                        DateTime dFechaSalida,
                                                        int idMotivoSalida,
                                                        decimal nAdjudicacionGarantia,
                                                        decimal nGastosAdjudicacion,
                                                        decimal nVentaGarantiaSinImp,
                                                        decimal nGastosVenta,
                                                        int idModalidadVentaGarantia,
                                                        int idUsuarioReg)
        {
            return objEjeSp.EjecSP("CRE_RegistrarSalidaGarantia_SP", 
                                                                idGarantia,
                                                                idTipoGarantia,
                                                                dFechaSalida,
                                                                idMotivoSalida,
                                                                nAdjudicacionGarantia,
                                                                nGastosAdjudicacion,
                                                                nVentaGarantiaSinImp,
                                                                nGastosVenta,
                                                                idModalidadVentaGarantia,
                                                                idUsuarioReg)
                ;
        }

        public DataTable ADListarModalidadVentaGarantia()
        {
            return objEjeSp.EjecSP("CRE_ListarModalidadVentaGarantia_SP");
        }

        public DataTable ADListarMotivoSalida()
        {
            return objEjeSp.EjecSP("CRE_ListarMotivoSalida_SP");
        }

        public DataTable ADListarSituacionGarantiaIdTipoSituacion(int idTipoSituacion)
        {
            return objEjeSp.EjecSP("CRE_ListarSituacionGarantiaIdTipoSituacion_SP", idTipoSituacion);
        }

        public DataTable ADListarTipoEmisorGarantia()
        {
            return objEjeSp.EjecSP("CRE_ListarTipoEmisorGarantia_SP");
        }

        public DataTable ADGetGarantiasIntervSol(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_GetGarantiasIntervSol_SP", idSolicitud);
        }

        public DataTable rptGarantiasPreferidas(int idClaseGarantia, DateTime dFecha, int nIdRegion, int nIdAgencia, int idTipoGarantiaGlobal)
        {
            return objEjeSp.EjecSP("CRE_rptGarantiasPreferidas2_SP", idClaseGarantia, dFecha, nIdRegion, nIdAgencia, idTipoGarantiaGlobal);
        }
        public DataTable rptContradepositos(string cXmlAgencias, int idClaseGarantia, DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_rptContradepositos_SP", cXmlAgencias, idClaseGarantia, dFecha);
        }
        public DataTable rptContradepositosGar(int idClaseGarantia, DateTime dFecha, int nIdRegion, int nIdAgencia, int idTipoGarantiaGlobal)
        {
            return objEjeSp.EjecSP("CRE_rptContradepositosGar_SP", idClaseGarantia, dFecha, nIdRegion, nIdAgencia, idTipoGarantiaGlobal);
        }

        public DataTable ADValidaCuentaDeposito(int idGarantia, decimal nMontoCoberturar, int idSolicitud )
        {
            return objEjeSp.EjecSP("AHO_ValidaCuentaDeposito_SP", idGarantia, nMontoCoberturar, idSolicitud);
        } 
    }
}
