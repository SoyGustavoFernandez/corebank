using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CLI.AccesoDatos;
using System.Data;

namespace CLI.CapaNegocio
{
    public class clsCNSocio
    {
        clsADSocio adsocio = new clsADSocio();

        public DataTable insertarActSocioBeneficiario(clsSocio socio, clslisBeneficiario beneficiarios, clsAporte aporte, clsFondoMortuorio fondo, Decimal nMontoInscripcion,
                        Boolean lUsaMontoEspecInscrip,  int idMonedaEspecInscrip,   decimal nMontoEspecInscrip,  string cMotivoEspecInscrip,
                        Boolean lUsaMontoEspecAporte,   int idMonedaEspecAporte,    decimal nMontoEspecAporte,   string cMotivoEspecAporte,
                        Boolean lUsaMontoEspecFondoSeg, int idMonedaEspecFondoSeg,  decimal nMontoEspecFondoSeg, string cMotivoEspecFondoSeg,
                        Boolean lInscribirConFondoSeguro, Boolean lEsMayorEdad,
                        string xmlActvLaboralDepEconom, string xmlActvLaboralIndepEconom, string xmlRefLabSocio)
        {
            return adsocio.insertarActSocioBeneficiario(socio, beneficiarios, aporte, fondo, nMontoInscripcion,
                        lUsaMontoEspecInscrip,  idMonedaEspecInscrip,   nMontoEspecInscrip,     cMotivoEspecInscrip,
                        lUsaMontoEspecAporte,   idMonedaEspecAporte,    nMontoEspecAporte,      cMotivoEspecAporte, 
                        lUsaMontoEspecFondoSeg, idMonedaEspecFondoSeg,  nMontoEspecFondoSeg,    cMotivoEspecFondoSeg,
                        lInscribirConFondoSeguro,lEsMayorEdad,
                         xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom, xmlRefLabSocio);
        }
		public DataTable ActualizarBeneficiario(string xmlSocio, string xmlRefLabSocio, string xmlBeneficiarioReg, string xmlActvLaboralDepEconom, string xmlActvLaboralIndepEconom)
        {
            return adsocio.ActualizarBeneficiario(xmlSocio, xmlRefLabSocio, xmlBeneficiarioReg, xmlActvLaboralDepEconom, xmlActvLaboralIndepEconom);
        }
        public clsSocio retornardatossocio(int idCli)
        {
            return adsocio.retornardatossocio(idCli);
        }

        public DataTable retornarDatosSocioComoTabla(int idCli)
        {
            return adsocio.retornarDatosSocioComoTabla(idCli);
        }

        public clsListBaseNegaSocio retornarBaseNegativaSocio(int idCli, ref int idPertenece)
        {
            clsListBaseNegaSocio lstBaseNeg;
            lstBaseNeg = adsocio.retornarBaseNegativaSocio(idCli);
            if (lstBaseNeg.Count > 0)
            {
                idPertenece = 1;              
            }
            return lstBaseNeg;
        }

        public DateTime ObtenerFechaNacCli(int idCli)
        {
            DataTable dfechaNacCli = adsocio.ObtenerFechaNacCli(idCli);
            return Convert.ToDateTime(dfechaNacCli.Rows[0]["dFechaNac"]);
        }

        public int validarSocioXidCli(int idCli)
        {
            return adsocio.validarSocioXidCli(idCli);
        }

        public void insertarActBaseNegativSocio(int nopcion, clsBaseNegaSocio baseNegsocio)
        {
            adsocio.insertarActBaseNegativaSocio(nopcion, baseNegsocio);
        }

        public DataTable registrarPagoAporteFondo(clslisDetalleAporte detallaporte, clslisDetalleFondo detallefondo, Boolean lPagarInscripcion, int idInscripcion, string xmlUsuarioPagador, int idTipoAporte, bool lModificaSaldoLinea, int idTipoTransac, decimal nMontoOpe, int idMoneda_Saldo)
        {
            return adsocio.registrarPagoAporteFondo(detallaporte, detallefondo, lPagarInscripcion, idInscripcion, xmlUsuarioPagador, idTipoAporte,
                                                         lModificaSaldoLinea, idTipoTransac, nMontoOpe, idMoneda_Saldo);
        }

        public DataTable retornarAportesSocio( DateTime dFechaFin, int idAgencia)
        {
            return adsocio.retornaAportesSocio( dFechaFin, idAgencia);
        }
        public DataTable retornaFondoSeguroSocio(DateTime dFechaFin, int idAgencia)
        {
            return adsocio.retornaFondoSeguroSocio(dFechaFin, idAgencia);
        }

        public DataTable retornarUltFecAporte(int idAporte,int idFondo, int Opcion)
        {
            return adsocio.retornarUltFecAporte(idAporte, idFondo, Opcion);
        }      
        public DataTable RegistarDevolucionAportes(int idAporte, int idSocio, string xmlUsuarioRecibeDevol, int nModalidad,  Decimal nValRedondeo,
		Decimal nMonTotDevRed, bool lEstRegitradoDevolucion)
        {
            return adsocio.RegistarDevolucionAportes(idAporte,idSocio, xmlUsuarioRecibeDevol, nModalidad,  nValRedondeo		,
			nMonTotDevRed,  lEstRegitradoDevolucion);
        }

        public DataTable validaConyugueBen(string cNumDocIde)
        {
            return adsocio.validaConyugueBen(cNumDocIde);
        }

        public DataTable retornarSaldosAportesfondo(DateTime dFecha, int idAgencia)
        {
            return adsocio.retornarSaldosAportesfondo(dFecha, idAgencia);
        }

        public DataTable listarTipoFondoSeguro()
        {
            return adsocio.listarTipoFondoSeguro();
        }

        public DataTable RecuperarSolAprobacMontosEspeciales(int idSocio)
        {
            return adsocio.RecuperarSolAprobacMontosEspeciales(idSocio);
        }

        public DataTable CNDatosSocio(int idSocio)
        {
            return adsocio.ADDatosSocio(idSocio);
        }
        public DataTable CNBenficiariosFondoSeguro(int idSocio)
        {
            return adsocio.ADBenficiariosFondoSeguro(idSocio);
        }

        public Boolean EstaPagadoInscripcion(int idInscripcion)
        {
            return adsocio.EstaPagadoInscripcion(idInscripcion);
        }

        public DataTable ListarMotivoDevolAportes()
        {
            return adsocio.ListarMotivoDevolAportes();
        }
        public DataTable ListarModalidadDevolAportes(Boolean lEsClienteInstitucion)
        {
            return adsocio.ListarModalidadDevolAportes(lEsClienteInstitucion);
        }
        public DataTable ListarModalidadPagoAportesFondo(Boolean lEsClienteInstitucion)
        {
            return adsocio.ListarModalidadPagoAportesFondo(lEsClienteInstitucion);
        }

        public DataTable CNReportePagoAporteFondo(int idKarInscr, int idKarAporte, int idKarFondo, int idCli, int idMoneda, int idUsuario)
        {
            return adsocio.ADReportePagoAporteFondo(idKarInscr, idKarAporte, idKarFondo, idCli, idMoneda, idUsuario);
        }

        //Retorna los tipos de operaciones para poder realizar las acciones de extorno de acciones de socios
        public DataTable ObtenerTipoOperacSocios()
        {
            return adsocio.ObtenerTipoOperacSocios();
        }

        //Retorna el Detalle de Actividad Laboral Económica de un socio y sus referencia Laborales
        //ACTIVIDAD LABORAL INDEPENDIENTE -- DEPENDIENTE
        public DataTable RetornarDetActividadLaboralEconom(int pIdSocio)
        {
            return adsocio.RetornarDetActividadLaboralEconom(pIdSocio);
        }

        public DataTable ReferenciasLaboralEconomica(int pIdSocio)
        {
            return adsocio.ReferenciasLaboralEconomica(pIdSocio);
        }

        public DataTable CNRegFirmasSocio(int idSocio)
        {
            return adsocio.ADRegFirmasSocio(idSocio);
        }

        public DataTable CNDatosApoderadoSocio(int idSocio)
        {
            return adsocio.ADDatosApoderadoSocio(idSocio);
        }

        public DataTable CNRetornaActvLabEconomIndependiente(int idSocio)
        {
            return adsocio.ADRetornaActvLabEconomIndependiente(idSocio);
        }

        public DataTable CNRetornaActvLabEconomDependiente(int idSocio)
        {
            return adsocio.ADRetornaActvLabEconomDependiente(idSocio);
        }

        public DataTable ListarModalidadPagoIndemnizacion(bool lEsClienteInstitucion)
        {
            return adsocio.ListarModalidadPagoIndemnizacion(lEsClienteInstitucion);
        }

        public DataTable ListarModalidadPagoSepelio(bool lPagadorSepelioEsClienteInstitucion)
        {
            return adsocio.ListarModalidadPagoSepelio(lPagadorSepelioEsClienteInstitucion);
        }

        public DataTable RegistrarIndemnizacion(int idMoneda, Boolean lEstaPagandoSepelio, int nModalidadPagoSepelio,
                                                Decimal nMontoPagoSepelio, string xmlPagadorSepelio, int idVarMontoIndemnizacion,
                                                Decimal nMontoIndemnizacion, Boolean lEstaPagandoABeneficiario, string xmlIndemnizac,

                                                int nModalidadPago, int idCuentaTransf, int idCuentaTransfPagoSepelio, int idSocio, string xmlTipPagoIndemnizacion, string xmlTipPagoSepelio)
        {
            return adsocio.RegistrarIndemnizacion(idMoneda, lEstaPagandoSepelio, nModalidadPagoSepelio,
                                                    nMontoPagoSepelio, xmlPagadorSepelio, idVarMontoIndemnizacion,

                                                    nMontoIndemnizacion, lEstaPagandoABeneficiario, xmlIndemnizac,
                                                    nModalidadPago, idCuentaTransf, idCuentaTransfPagoSepelio, idSocio, xmlTipPagoIndemnizacion, xmlTipPagoSepelio);
        }

        //HISTORICO
        public DataTable CNHistoricoAportes(int idCli, int idEstado)
        {
            return adsocio.ADHistoricoAportes(idCli, idEstado);
        }

        public DataTable CNHistoricoFondoSeguro(int idCli, int idEstado)
        {
            return adsocio.ADHistoricoFondoSeguro(idCli,idEstado);
        }

        public DataTable CNHistoricoCliComoAval(int idCli, int idEstado)
        {
            return adsocio.ADHistoricoCliComoAval(idCli, idEstado);
        }

        public DataTable CNHistoricoCre(int idCli, int idEstado)
        {
            return adsocio.ADHistoricoCre(idCli, idEstado);
        }

        public DataTable CNHistoricoDeposito(int idCli, int idEstado)
        {
            return adsocio.ADHistoricoDeposito(idCli, idEstado);
        }

        public DataTable CNDatosPagoSepelio(int idSocio)
        {
            return adsocio.ADDatosPagoSepelio(idSocio);
        }
		//Retorna IdCli por el Nro.Aporte o Nro.Fondo
        public DataTable CNDatosCli(int idkarFondo, int idKarAporte)
        {
            return adsocio.ADDatosCli(idkarFondo, idKarAporte);
        }
		public DataTable retornarAportesXSocio(int idCliente)
        {
            return adsocio.retornaAporteXSocio(idCliente);
        }
        public DataTable retornarAportesXSocioKardex(int idCliente)
        {
            return adsocio.retornaAporteXSocioKardex(idCliente);
        }
        public DataTable retornarFondoMortXSocio(int idCli)
        {
            return adsocio.retornaFondoMortXSocio(idCli);
        }
        public DataTable retornarFondoMortXSocioKardex(int idCli)
        {
            return adsocio.retornaFondoMortXSocioKardex(idCli);
        }
        public DataTable retornaSociosCumplenMayoriaEdad(DateTime dFechaIni, DateTime dFechaFin)
        {
            return adsocio.retornaSociosCumplenMayoriaEdad(dFechaIni,dFechaFin);
        }
		public DataTable retornarDatosSocioConvenio(int idConvenio)
        {
            return adsocio.retornarDatosSocioConvenio(idConvenio);
        }
		public DataTable listarAporteAPagar(int idAporte,Decimal nPagaDeudaAporte)
        {
            DataTable dtAporteXPagar = adsocio.ListarAportexPagar(idAporte);
                 for (int j = 0; j < dtAporteXPagar.Rows.Count; j++)
                    {
                        if (nPagaDeudaAporte <= Convert.ToDecimal (dtAporteXPagar.Rows[j]["nSaldoApotar"]))
                        {
                            dtAporteXPagar.Rows[j]["nMonApoPag"] = nPagaDeudaAporte;
                            dtAporteXPagar.Rows[j]["idEstado"] = 2;
                            break;
                        }
                        dtAporteXPagar.Rows[j]["nMonApoPag"] = dtAporteXPagar.Rows[j]["nSaldoApotar"];
                        dtAporteXPagar.Rows[j]["idEstado"] = 2;
                        nPagaDeudaAporte = nPagaDeudaAporte - Convert.ToDecimal (dtAporteXPagar.Rows[j]["nSaldoApotar"]);
                    }

                 return dtAporteXPagar;
        }
		public DataTable listarFondoAPagar(int idFondo, Decimal nPagaDeudaFondo)
        {
            DataTable dtFondoXPagar=adsocio.ListarFondoxPagar(idFondo);

            for (int k = 0; k < dtFondoXPagar.Rows.Count; k++)
            {
                if (nPagaDeudaFondo <= Convert.ToDecimal (dtFondoXPagar.Rows[k]["nSaldoFondo"]))
                {
                    dtFondoXPagar.Rows[k]["nMontoPag"] = nPagaDeudaFondo;
                    dtFondoXPagar.Rows[k]["idEstado"] = 2;
                    break;
                }
                dtFondoXPagar.Rows[k]["nMontoPag"] = dtFondoXPagar.Rows[k]["nSaldoFondo"];
                dtFondoXPagar.Rows[k]["idEstado"] = 2;
                nPagaDeudaFondo = nPagaDeudaFondo - Convert.ToDecimal (dtFondoXPagar.Rows[k]["nSaldoFondo"]);
            }
            return dtFondoXPagar;
        }
		public DataTable RegistrarPagoMasivoAporteFondo(string xmlDetallaporte, string xmlDetallefondo, string xmlUsuarioPagador, Decimal nTotalAportes, Decimal nTotalFondoSeg)
        {
            return adsocio.RegistrarPagoMasivoAporteFondo(xmlDetallaporte, xmlDetallefondo, xmlUsuarioPagador,nTotalAportes, nTotalFondoSeg);
        }
		public DataTable retornarCodCliXConvenio(int idConvenio)
        {
            return adsocio.retornarCodCliXConvenio(idConvenio);
        }
    }
}
