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
    public class clsADSocio
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable insertarActSocioBeneficiario(clsSocio socio, clslisBeneficiario beneficiarios, clsAporte aporte, clsFondoMortuorio fondo, Decimal nMontoInscripcion,
                        Boolean lUsaMontoEspecInscrip, int idMonedaEspecInscrip, decimal nMontoEspecInscrip, string cMotivoEspecInscrip,
                        Boolean lUsaMontoEspecAporte, int idMonedaEspecAporte, decimal nMontoEspecAporte, string cMotivoEspecAporte,
                        Boolean lUsaMontoEspecFondoSeg, int idMonedaEspecFondoSeg, decimal nMontoEspecFondoSeg, string cMotivoEspecFondoSeg,
                        Boolean lInscribirConFondoSeguro,Boolean lEsMayorEdad,
                        string xmlActvLaboralDepEconom, string xmlActvLaboralIndepEconom, string xmlRefLabSocio)
        {
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsbeneficiario",
                                          from item in beneficiarios
                                          select new XElement("dtbeneficiario",
                                                              new XAttribute("idBeneficiario", item.idBeneficiario),
                                                              new XAttribute("cBeneficiario", item.cBeneficiario),
                                                              new XAttribute("cNombres", item.cNombres),
                                                              new XAttribute("cApePatBen", item.cApePatBen),
                                                              new XAttribute("cApeMatBen", item.cApeMatBen),
                                                              new XAttribute("cApeCasBen", item.cApeCasBen),
                                                              new XAttribute("cDocIdeBen", item.cDocIdeBen),
                                                              new XAttribute("cDireccion", item.cDireccion),
                                                              new XAttribute("idUbigeo", item.idUbigeo),
                                                              new XAttribute("idTipoRela", item.idTipoRela),
                                                              new XAttribute("nBeneficio", item.nBeneficio),
                                                              new XAttribute("dFecRegBen", item.dFecRegBen),
                                                              new XAttribute("idUsuRegBen", item.idUsuRegBen),
                                                              new XAttribute("dFecBajBen", item.dFecBajBen),
                                                              new XAttribute("idMotivBaj", item.idMotivBaj),
                                                              new XAttribute("idEstado", item.idEstado),
                                                              new XAttribute("idCli", item.idCli)))).ToString();

            return objEjeSp.EjecSP("CLI_InsActSocioBeneficiarios_sp", socio.obtenerXml(), cxml, aporte.obtenerXml(), fondo.obtenerXml(), nMontoInscripcion,
                        lUsaMontoEspecInscrip, idMonedaEspecInscrip, nMontoEspecInscrip, cMotivoEspecInscrip,
                        lUsaMontoEspecAporte, idMonedaEspecAporte, nMontoEspecAporte, cMotivoEspecAporte,
                        lUsaMontoEspecFondoSeg, idMonedaEspecFondoSeg, nMontoEspecFondoSeg, cMotivoEspecFondoSeg,
                        lInscribirConFondoSeguro,lEsMayorEdad,
                        xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom, xmlRefLabSocio);
        }
		public DataTable ActualizarBeneficiario(string xmlSocio, string xmlRefLabSocio, string xmlBeneficiarioReg, string xmlActvLaboralDepEconom, string xmlActvLaboralIndepEconom)
        {
            return objEjeSp.EjecSP("CLI_ActSocioBeneficiarios_sp", xmlSocio, xmlRefLabSocio, xmlBeneficiarioReg, xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom);
        }
        public clsSocio retornardatossocio(int idCli)
        {
            clsSocio socio = null;
            DataTable dt = objEjeSp.EjecSP("CLI_RetDatSocio_sp", idCli);

            if (dt.Rows.Count > 0)
            {
                socio = new clsSocio();
                socio.idCli = idCli;
                socio.idSocio = (int)dt.Rows[0]["idSocio"];
                socio.idAporte = (int)dt.Rows[0]["idAporte"];
                socio.idTipoFondoSeguro = dt.Rows[0]["idTipoFondoSeguro"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idTipoFondoSeguro"];
                socio.idFondo = dt.Rows[0]["idFondo"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idFondo"];
                socio.idInscripcion = (int)dt.Rows[0]["idInscripcion"];
                socio.nInscripcion = Convert.ToDecimal (dt.Rows[0]["nInscripcion"]);
                socio.nNumBene = (int)dt.Rows[0]["nNumBene"];
                socio.idAgencia = (int)dt.Rows[0]["idAgencia"];
                socio.idTipoSocio = (int)dt.Rows[0]["idTipoSocio"];
                socio.dFecRegSoc = (DateTime)dt.Rows[0]["dFecRegSoc"];
                socio.idUsuRegSoc = dt.Rows[0]["idUsuRegSoc"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idUsuRegSoc"];
                socio.dFecModSoc = dt.Rows[0]["dFecModSoc"] == DBNull.Value ? null : (DateTime?)dt.Rows[0]["dFecModSoc"];
                socio.idUsuModSoc = (int)dt.Rows[0]["idUsuModSoc"];
                socio.idEstado = (int)dt.Rows[0]["idEstado"];

                socio.lTrabajaAct = dt.Rows[0]["lTrabajaAct"] == System.DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["lTrabajaAct"]);
                socio.idTipoVinculac = dt.Rows[0]["idTipoVinculac"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idTipoVinculac"];
                socio.idActvLab = dt.Rows[0]["idActvLab"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idActvLab"];
                socio.cInfOtrasActvEcon = dt.Rows[0]["cInfOtrasActvEcon"].ToString();
                socio.idCliApoderado = dt.Rows[0]["idCliApoderado"] == System.DBNull.Value ? 0 : (int)dt.Rows[0]["idCliApoderado"]; 
            }

            return socio;
        }

        public DataTable retornarDatosSocioComoTabla(int idCli)
        {
            return objEjeSp.EjecSP("CLI_RetDatSocio_sp", idCli);
        }

        public clsListBaseNegaSocio retornarBaseNegativaSocio(int idCli)
        {
            clsListBaseNegaSocio baseNegSocio = new clsListBaseNegaSocio();
            DataTable dt = objEjeSp.EjecSP("CLI_ListarBaseNegativaSocios_SP", idCli);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    baseNegSocio.Add(new clsBaseNegaSocio()
                    {
                        idCli = (int)dt.Rows[0]["idCli"],
                        cMotivo = (string)dt.Rows[0]["cMotivo"],
                        idAgencia = (int)dt.Rows[0]["idAgencia"],
                        idUsuReg = (int)dt.Rows[0]["idUsuReg"],
                        idUsuMod = (int)dt.Rows[0]["idUsuMod"],
                        idEstado = (int)dt.Rows[0]["idEstado"],
                        dFechaReg = (DateTime)dt.Rows[0]["dFechaReg"],
                        dFechaMod = (DateTime)dt.Rows[0]["dFechaMod"],
                        idBaseNegSoc = (int)dt.Rows[0]["idBaseNegSoc"],
                        cSustento = (string)dt.Rows[0]["cSustento"]
                    });
                }
            }

            return baseNegSocio;
        }

        public void insertarActBaseNegativaSocio(int opcion, clsBaseNegaSocio BasNegSocio)
        {

            objEjeSp.EjecSP("CLI_InsUpdSI_FINBaseNegativaSocios_Sp", opcion, BasNegSocio.idCli, BasNegSocio.cMotivo, BasNegSocio.dFechaReg,
                                                                     BasNegSocio.idUsuReg, BasNegSocio.idUsuMod, BasNegSocio.idAgencia,
                                                                     BasNegSocio.dFechaMod, BasNegSocio.idEstado, BasNegSocio.cSustento);

        }

        public int validarSocioXidCli(int idcli)
        {
            int rsult = 0;
            var lisParametros = new clsGENEjeSP().EjecSPOut("CLI_ListarSocios_SP", idcli, rsult);
            rsult = Convert.ToInt32(lisParametros[0].Parametro.Value);
            return rsult;

        }

        public DataTable registrarPagoAporteFondo(clslisDetalleAporte detallaporte, clslisDetalleFondo detallefondo, Boolean lPagarInscripcion, int idInscripcion, string xmlUsuarioPagador, int idTipoAporte, bool lModificaSaldoLinea, int idTipoTransac, decimal nMontoOpe, int idMoneda_Saldo)
        {
            string cxmlAporte = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetalleaporte",
                                          from item in detallaporte
                                          select new XElement("dtdetalleaporte",
                                                              new XAttribute("idDetAporte", item.idDetAporte),
                                                              new XAttribute("idAporte", item.idAporte),
                                                              new XAttribute("cPeriodo", item.cPeriodo),
                                                              new XAttribute("nMonApoPac", item.nMonApoPac),
                                                              new XAttribute("nMonApoPag", item.nMonApoPag),
                                                              new XAttribute("dFecVenApo", item.dFecVenApo),
                                                              new XAttribute("idEstado", item.idEstado)
                                                              ))).ToString();


            string cxmlFondo = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetallefondo",
                                          from item in detallefondo
                                          select new XElement("dtdetallefondo",
                                                              new XAttribute("idDetFondo", item.idDetFondo),
                                                              new XAttribute("idFondo", item.idFondo),
                                                              new XAttribute("cPeriodo", item.cPeriodo),
                                                              new XAttribute("dFecVenApo", item.dFecVenApo),
                                                              new XAttribute("nMontoPac", item.nMontoPac),
                                                              new XAttribute("nMontoPag", item.nMontoPag),
                                                              new XAttribute("idEstado", item.idEstado)
                                                              ))).ToString();

            return objEjeSp.EjecSP("CLI_RegistraAporteFondo_sp", cxmlAporte, cxmlFondo, clsVarGlobal.idCanal, clsVarGlobal.dFecSystem,
                                    clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, lPagarInscripcion, idInscripcion, xmlUsuarioPagador, idTipoAporte,
                                                        lModificaSaldoLinea, idTipoTransac, nMontoOpe, idMoneda_Saldo);
        }

        public DataTable retornaAportesSocio(DateTime dFechaFin, int idAgencia)
        {
            DataTable dt = objEjeSp.EjecSP("RPT_AportesxSocios_SP", dFechaFin, idAgencia);
            return dt;
        }
        public DataTable retornaFondoSeguroSocio(DateTime dFechaFin, int idAgencia)
        {
            DataTable dt = objEjeSp.EjecSP("RPT_FondoSeguroxSocios_SP", dFechaFin, idAgencia);
            return dt;
        }

        public DataTable retornarUltFecAporte(int idAporte, int idFondo, int Opcion)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_BuscaUltimaFechaPago_SP", idAporte, idFondo, Opcion);
            return dt;
        }
        public DataTable RegistarDevolucionAportes(int idAportes, int idSocio, string xmlUsuarioRecibeDevol, int nModalidad, Decimal nValRedondeo,
    Decimal nMonTotDevRed, bool lEstRegitradoDevolucion)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RegistraDevolucionAporte_sp", idAportes, idSocio, clsVarGlobal.idCanal, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, xmlUsuarioRecibeDevol, nModalidad, nValRedondeo,
     nMonTotDevRed, lEstRegitradoDevolucion);
            return dt;
        }

        public DataTable validaConyugueBen(string cNumDocIde)
        {
            return objEjeSp.EjecSP("CLI_ValBeneConugue_sp", cNumDocIde);
        }


        public DataTable retornarSaldosAportesfondo(DateTime dFecha, int idAgencia)
        {
            return objEjeSp.EjecSP("CLI_RptSaldosAportesFondo_sp", dFecha, idAgencia);
        }

        public DataTable ObtenerFechaNacCli(int idCli)
        {
            return objEjeSp.EjecSP("CLI_ObtenerFechaNacCli_SP", idCli);
        }

        public DataTable listarTipoFondoSeguro()
        {
            return objEjeSp.EjecSP("GEN_ListarTiposFondoSeguro_Sp");
        }

        public DataTable RecuperarSolAprobacMontosEspeciales(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_RecuperarSolAprobacMontosEspeciales_Sp", idSocio);
        }

        public DataTable ADDatosSocio(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_rptDatosSocio_Sp", idSocio);
        }
        public DataTable ADBenficiariosFondoSeguro(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_rptBeneficiariosFondoSeguro_Sp", idSocio);
        }

        public Boolean EstaPagadoInscripcion(int idInscripcion)
        {
            DataTable dtRpta = objEjeSp.EjecSP("CLI_EstaPagadoInscripcionSocio_Sp", idInscripcion);
            return Convert.ToBoolean(dtRpta.Rows[0]["lPagado"]);
        }

        public DataTable ListarMotivoDevolAportes()
        {
            return objEjeSp.EjecSP("CLI_ListarMotivoDevolAportes_Sp");
        }

        public DataTable ListarModalidadDevolAportes(Boolean lEsClienteInstitucion)
        {
            return objEjeSp.EjecSP("CLI_ListarModalidadDevolAportes_Sp", lEsClienteInstitucion);
        }
        public DataTable ListarModalidadPagoAportesFondo(Boolean lEsClienteInstitucion)
        {
            return objEjeSp.EjecSP("CLI_ListarModalidadPagoAporteFondo_Sp", lEsClienteInstitucion);
        }


        public DataTable ADReportePagoAporteFondo(int idKarInscr, int idKarAporte, int idKarFondo, int idCli, int idMoneda, int idUsuario)
        {
            return objEjeSp.EjecSP("CLI_rptVoucherAporteFondoSeg_Sp", idKarInscr, idKarAporte, idKarFondo, idCli, idMoneda, idUsuario);
        }

        public DataTable ObtenerTipoOperacSocios()
        {
            return objEjeSp.EjecSP("CLI_ObtenerTipoOperacSocios_Sp");
        }


        public DataTable RetornarDetActividadLaboralEconom(int pIdSocio)
        {
            return objEjeSp.EjecSP("CLI_RetornaDetActividadLaboralEconom_Sp", pIdSocio);
        }


        public DataTable ReferenciasLaboralEconomica(int pIdSocio)
        {
            return objEjeSp.EjecSP("CLI_RetornaRefLaboralEconom_Sp", pIdSocio);
        }

        public DataTable ADRegFirmasSocio(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_RptRegistroFirmasSocio_Sp", idSocio);
        }

        public DataTable ADDatosApoderadoSocio(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_RptDatosApoderadoSocio_Sp", idSocio);
        }

        //Retorna el detalle de actividad laboral INDEPENDIENTE para un socio
        public DataTable ADRetornaActvLabEconomIndependiente(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_RptDetActividadLaboralIndepEconom_Sp", idSocio);
        }

        //Retorna el detalle de actividad laboral DEPENDIENTE para un socio
        public DataTable ADRetornaActvLabEconomDependiente(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_RptDetActividadLaboralDepEconom_Sp", idSocio);
        }

        public DataTable ListarModalidadPagoIndemnizacion(bool lEsClienteInstitucion)
        {
            return objEjeSp.EjecSP("CLI_ListarModalidadPagoIndemnizac_Sp", lEsClienteInstitucion);
        }

        public DataTable ListarModalidadPagoSepelio(bool lPagadorSepelioEsClienteInstitucion)
        {
            return objEjeSp.EjecSP("CLI_ListarModalidadPagoSepelio_Sp", lPagadorSepelioEsClienteInstitucion);
        }

        public DataTable RegistrarIndemnizacion(int idMoneda, Boolean lEstaPagandoSepelio, int nModalidadPagoSepelio,
                                               Decimal nMontoPagoSepelio, string xmlPagadorSepelio, int idVarMontoIndemnizacion,
                                               Decimal nMontoIndemnizacion, Boolean lEstaPagandoABeneficiario, string xmlIndemnizac,
                                               int nModalidadPago, int idCuentaTransf, int idCuentaTransfPagoSepelio, int idSocio, string xmlTipPagoIndemnizacion, string xmlTipPagoSepelio)
        {
            return objEjeSp.EjecSP("CLI_RegistrarIndemnizacion_Sp", clsVarGlobal.idCanal, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                                                                    idMoneda, lEstaPagandoSepelio, nModalidadPagoSepelio,
                                                                    nMontoPagoSepelio, xmlPagadorSepelio, idVarMontoIndemnizacion,
                                                                    nMontoIndemnizacion, lEstaPagandoABeneficiario, xmlIndemnizac,
                                                                    nModalidadPago, idCuentaTransf, idCuentaTransfPagoSepelio, idSocio, xmlTipPagoIndemnizacion, xmlTipPagoSepelio);
        }

        //HISTORICO
        public DataTable ADHistoricoAportes(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("RPT_AportesxCli_SP", idCli, idEstado);
        }

        public DataTable ADHistoricoFondoSeguro(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("RPT_FondoSeguroxCli_SP", idCli, idEstado);
        }

        public DataTable ADHistoricoCliComoAval(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_HistoricoCreCliAval_sp", idCli, idEstado);
        }

        public DataTable ADHistoricoCre(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_HistoricoCreCli_sp", idCli, idEstado);
        }

        public DataTable ADHistoricoDeposito(int idCli, int idEstado)
        {
            return objEjeSp.EjecSP("DEP_HistoricoAhorroCli_SP", idCli, idEstado);
        }

        public DataTable ADDatosPagoSepelio(int idSocio)
        {
            return objEjeSp.EjecSP("CLI_DatosPagoSepelio_SP", idSocio);
        }
		
		//Retorna IdCli por el Nro.Aporte o Nro.Fondo
        public DataTable ADDatosCli(int idkarFondo, int idKarAporte)
        {
            return objEjeSp.EjecSP("CLI_RetornaCodCli_sp", idkarFondo, idKarAporte);
        }
        public DataTable retornaAporteXSocio(int idCliente)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptAporteXSocio_SP", idCliente);
            return dt;
        }
        public DataTable retornaAporteXSocioKardex(int idCliente)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptAporteXSocioKardex_SP", idCliente);
            return dt;
        }
        public DataTable retornaFondoMortXSocio(int idCliente)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptFondoMortXSocio_SP", idCliente);
            return dt;
        }
        public DataTable retornaFondoMortXSocioKardex(int idCliente)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptFondoMortXSocioKardex_SP", idCliente);
            return dt;
        }
        public DataTable retornaSociosCumplenMayoriaEdad(DateTime dFechaIni, DateTime dFechaFin)
        {
            DataTable dt = objEjeSp.EjecSP("RPT_SocioCumpleMayorEdad_sp", dFechaIni, dFechaFin);
            return dt;
        }
		public DataTable retornarDatosSocioConvenio(int idConvenio)
        {
            return objEjeSp.EjecSP("CLI_ListaAporteFondoPagMasivo_SP", idConvenio);
        }
        public DataTable ListarAportexPagar(int idAporte)
        {
            return objEjeSp.EjecSP("CLI_ListarAportesxPagar_Sp", idAporte);
        }
         public DataTable ListarFondoxPagar(int idFondo)
        {
            return objEjeSp.EjecSP("CLI_ListarFondoSeguro_Sp", idFondo);
        }
         public DataTable RegistrarPagoMasivoAporteFondo(string cxmlAporte, string cxmlFondo, string xmlUsuarioPagador, Decimal nTotalAportes, Decimal nTotalFondoSeg)
         {
             return objEjeSp.EjecSP("CLI_RegistraPagoMasivoAporteFondo_sp", cxmlAporte, cxmlFondo, clsVarGlobal.idCanal, clsVarGlobal.dFecSystem,
                                     clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, xmlUsuarioPagador, nTotalAportes, nTotalFondoSeg);
         }
         public DataTable retornarCodCliXConvenio(int idConvenio)
         {
             return objEjeSp.EjecSP("CLI_ObtieneIdCliConvenio_SP", idConvenio);
         }
    }
}
