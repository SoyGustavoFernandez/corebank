using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using System.Xml.Linq;
using EntityLayer;
using GEN.Funciones;
using System.Text.RegularExpressions;

namespace GEN.CapaNegocio
{
    public class clsCNSolicitud
    {
        public clsADSolicitud objADSolicitud;

        public clsCNSolicitud()
        {
            objADSolicitud = new clsADSolicitud();
        }

        public clsCNSolicitud(bool lWS)
        {
            objADSolicitud = new clsADSolicitud(lWS);
        }

        public DataTable ConsultaSolicitud(Int32 CodigoSol)
        {
            return objADSolicitud.ExtraeDatosSolicitud(CodigoSol);
        }
        public clsSolicitudCreditoDetalle obtenerSolicitudCreditoDetalle(int idSolicitud)
        {
            DataTable dtSolicitudCreditoDetalle = this.objADSolicitud.obtenerSolicitudCreditoDetalle(idSolicitud);

            return (dtSolicitudCreditoDetalle.Rows.Count > 0) ?
                dtSolicitudCreditoDetalle.ToList<clsSolicitudCreditoDetalle>()[0] :
                new clsSolicitudCreditoDetalle();
        }
        public DataTable ConsultaSolicitudAprobacion(Int32 CodigoSol)
        {
            return objADSolicitud.ExtraeDatosSolicitudAprobacion(CodigoSol);
        }
        public DataTable ConsultaSolicitudTNegociable(Int32 CodigoSol, int idTasaNegociada)
        {
            return objADSolicitud.ExtraeDatosSolicitudTNegAproba(CodigoSol, idTasaNegociada);
        }

        public DataTable ExtraeDatosSolicitudTNegociable(Int32 CodigoSol, int idUsuarioReg)
        {
            return objADSolicitud.ExtraeDatosSolicitudTNegociable(CodigoSol, idUsuarioReg);
        }
        public DataTable ConsultaSolicitudCapitalSol(Int32 CodigoSol)
        {
            return objADSolicitud.ExtraeDatosSolicitudCapitalSol(CodigoSol);
        }
        public DataTable RegistraSolicitudTasaNegociable(int idSolicitud, int idTasa, decimal nTasaSolicitada,
                                                    decimal nTasaMoratoriaSol, string cJustificacion, int idUsuReg,
                                                    int idTasaAnt, decimal nTasaAprobadaAnt, int idAgencia, DateTime dFechaSolicitada,
                                                    int nTipCre, int nSubTip, int nProdu, int nSubPro, int idMoneda,
                                                    Decimal nCapitalSolicitado, int nCuotas, int idTipoPeriodo,
                                                    int nPlazoCuota, int nDiasGracia, DateTime dFechaDesembolso)
        {
            return objADSolicitud.ADRegistraSolicitudTasaNegociable(idSolicitud, idTasa, nTasaSolicitada,
                                                    nTasaMoratoriaSol, cJustificacion, idUsuReg,
                                                    idTasaAnt, nTasaAprobadaAnt, idAgencia, dFechaSolicitada,
                                                    nTipCre, nSubTip, nProdu, nSubPro, idMoneda,
                                                    nCapitalSolicitado, nCuotas, idTipoPeriodo,
                                                    nPlazoCuota, nDiasGracia, dFechaDesembolso, 
                                                    "", 0, "", 0, 4, "", 0, 0, 1, 0, clsVarGlobal.User.idEstablecimiento, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public DataTable CNRegistraSolicitudTasaNegociable(int idSolicitud, int idTasa, decimal nTasaSolicitada,
                                            decimal nTasaMoratoriaSol, string cJustificacion, int idUsuReg,
                                            int idTasaAnt, decimal nTasaAprobadaAnt, int idAgencia, DateTime dFechaSolicitada,
                                            int nTipCre, int nSubTip, int nProdu, int nSubPro, int idMoneda,
                                            Decimal nCapitalSolicitado, int nCuotas, int idTipoPeriodo,
                                            int nPlazoCuota, int nDiasGracia, DateTime dFechaDesembolso, string cNombreEntidadFinanciera, decimal nTasaEntidad,
                                            string cComentarioEntidad, decimal nMontoEntidad, int idMotivoTasa, string cComenMotivoTasa, int idEntidad, int idTasaNegociada, int ntipoDesembolso, int nTipoOperacion, int idEstablecimiento, int idPerfil)
        {
            return objADSolicitud.ADRegistraSolicitudTasaNegociable(idSolicitud, idTasa, nTasaSolicitada,
                                                    nTasaMoratoriaSol, cJustificacion, idUsuReg,
                                                    idTasaAnt, nTasaAprobadaAnt, idAgencia, dFechaSolicitada,
                                                    nTipCre, nSubTip, nProdu, nSubPro, idMoneda,
                                                    nCapitalSolicitado, nCuotas, idTipoPeriodo,
                                                    nPlazoCuota, nDiasGracia, dFechaDesembolso, cNombreEntidadFinanciera, nTasaEntidad,
                                                    cComentarioEntidad, nMontoEntidad, idMotivoTasa, cComenMotivoTasa, idEntidad, idTasaNegociada, ntipoDesembolso, nTipoOperacion, idEstablecimiento, idPerfil);
        }

        public DataTable RegistroAbprobacionTasaNegociable(int idTasaNegociada, int idUsuario, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual, string cJustificacionAprobacion)
        {
            return objADSolicitud.ADRegistroAbprobacionTasaNegociable(idTasaNegociada, idUsuario, nTasaInteres, nTasaMoratoria, nTasaInteresMensual, cJustificacionAprobacion);
        }
        public DataTable CNRegistroPreAprobacionTasaNegociable(int idTasaNegociada, int idUsuario, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual)
        {
            return objADSolicitud.ADRegistroPreAprobacionTasaNegociable(idTasaNegociada, idUsuario, nTasaInteres, nTasaMoratoria, nTasaInteresMensual);
        }
        public DataTable DenegarAprobacionTasaNegociable(int idTasaNegociada, int idUsuario)
        {
            return objADSolicitud.ADDenegarAprobacionTasaNegociable(idTasaNegociada, idUsuario);
        }
        public DataTable AnularSolicitudTasaNegociable(int idTasaNegociada, int idEstado, int idUsuario, int idSolAproba)
        {
            return objADSolicitud.AnularSolicitudTasaNegociable(idTasaNegociada, idEstado, idUsuario, idSolAproba);
        }
        public DataTable CNAnularDenegarSolicitudTasaNegociable(int idTasaNegociada, int idEstado, int idUsuario, int idMotivoAnula, string cOtros, string cTipoEvento)
        {
            return objADSolicitud.ADAnularDenegarSolicitudTasaNegociable(idTasaNegociada, idEstado, idUsuario, idMotivoAnula, cOtros, cTipoEvento);
        }
        public DataTable CNBuscaSolicitudxidTasaNegociable(int idTasaNegociada)
        {
            return objADSolicitud.ADBuscaSolicitudxidTasaNegociable(idTasaNegociada);
        }
        public DataTable CNListaSolicitudesTasaNegociable(int idUsuario, int idPerfilUsuario)
        {
            return objADSolicitud.ADListaSolicitudesTasaNegociableUnificado(idUsuario, idPerfilUsuario);
        }
        public DataTable CNListaSoliciPreTasaNegociable(int idUsuario, int idPerfilUsuario, int idSolAproba, int idSolicitud)
        {
            return objADSolicitud.ADListaSoliciPreTasaNegociable(idUsuario, idPerfilUsuario, idSolAproba, idSolicitud);
        }

        public DataTable SeguimientoTasaNegociable(int idSolicitud, int idUsuario)
        {
            return objADSolicitud.SeguimientoTasaNegociable(idSolicitud, idUsuario);
        }

        public DataTable InsertaActualizaSolicitud(String tSolicitud, string xmlCreditoProp, Int32 nIdAgencia, int idCuenta, int idSoliCambio,
                                                String XmlSolCreAmp, Boolean lBaseNegativa, DateTime dFechaSis, int idUsuario, int idOferta = 0, int idCanalVend = 0, bool lOpinionRiesgos = false)
        {
            return objADSolicitud.InsUpdSolicitud(tSolicitud, xmlCreditoProp, nIdAgencia, idCuenta, idSoliCambio,
                                            XmlSolCreAmp, lBaseNegativa, dFechaSis, idUsuario, idOferta, idCanalVend, lOpinionRiesgos);
        }

        public DataTable InsertaEvaluacionSolicitudExt(int idSolicitud_INI, int idSolicitud_FIN, String tipo)
        {
            return objADSolicitud.InsertaEvaluacionSolicitudExt(idSolicitud_INI, idSolicitud_FIN, tipo);
        }

        public DataTable SolicitudClienteEstado(Int32 nidCli, Int32 nIdEstado)
        {
            return objADSolicitud.ExtraeSolicitudesClienteEstado(nidCli, nIdEstado);
        }

        public DataTable SolicitudDesembolso(Int32 nidSolicitud)
        {
            return objADSolicitud.ExtraeSolicitudDesembolso(nidSolicitud);
        }
        public DataTable CNEsDesembolsoVirtual(Int32 idCuenta)
        {
            return objADSolicitud.ADEsDesembolsoVirtual(idCuenta);
        }
        public Boolean NivelAprobacion(int idCargo, decimal nMonSoli, Int32 idSol)
        {
            DataTable DesembolsoCliente = objADSolicitud.ADDesembolsoCliente(idSol);
            decimal nMonto = Convert.ToDecimal(DesembolsoCliente.Rows[0]["nSaldo"]);
            if (nMonto + nMonSoli >= 1500 && idCargo == 1)
            {
                return true;
            }
            return false;
        }

        public DataTable CNdtValidaRegSol(Int32 nNumcliente, Int16 nIdProducto)
        {
            return objADSolicitud.ADdtValidaRegSol(nNumcliente, nIdProducto);
        }

        public DataTable CNdtLisSolEstSol(Int32 nNumcliente)
        {
            return objADSolicitud.ADdtLisSolEstSol(nNumcliente);
        }

        public DataTable CNdtLisSolEstSolxTipoEva(Int32 nNumcliente, int idTipoEvaluac)
        {
            return objADSolicitud.ADdtLisSolEstSolxTipoEva(nNumcliente, idTipoEvaluac);
        }

        public DataTable CNdtRegRelEvaConSol(Int32 IdSolicitud, Int32 IdEvaCons, Int32 IdUsuReg, DateTime dFecReg)
        {
            return objADSolicitud.ADdtRegRelEvaConSol(IdSolicitud, IdEvaCons, IdUsuReg, dFecReg);
        }

        public DataTable CNdtRegRelEvaEmprSol(Int32 IdSolicitud, Int32 IdEvaCons, Int32 IdUsuReg, DateTime dFecReg)
        {
            return objADSolicitud.ADdtRegRelEvaEmprSol(IdSolicitud, IdEvaCons, IdUsuReg, dFecReg);
        }

        public DataTable CNUpdtasaSolCre(Int32 idSolicitud, Decimal nTasaCosEfe)
        {
            return objADSolicitud.ADUpdTasaSolCre(idSolicitud, nTasaCosEfe);
        }

        public DataTable CNListaEstadoSolCre(Int32 idSolicitud)
        {
            return objADSolicitud.ADListaEstadoSolCre(idSolicitud);
        }

        public DataTable CNBuscaAgenciaSolCre(Int32 idSolicitud)
        {
            return objADSolicitud.ADBusAgenciaSolCre(idSolicitud);
        }

        public clsSolicitudReprogramacion obtenerSolicitudReprogramacion(int idSolicitud)
        {
            DataTable dtSolicitudReprog = objADSolicitud.retornaDatSolReprograma(idSolicitud);
            return (dtSolicitudReprog.Rows.Count > 0) ?
                dtSolicitudReprog.ToList<clsSolicitudReprogramacion>()[0] :
                new clsSolicitudReprogramacion();
        }

        public DataTable CNRetCuentasAmpliadas(int idCodSol)
        {
            return objADSolicitud.ADRetCuentasAmpliadas(idCodSol);
        }

        public DataTable CNRetornaEvalCredito(int idCodSol, int idTipoCredito)

        {
            return objADSolicitud.ADRetornaEvalCredito(idCodSol, idTipoCredito);
        }

        public DataTable CNClasificarCredito(string cNumDocuId)
        {
            return objADSolicitud.ADClasificarCredito(cNumDocuId);
        }

        public DataTable CNBusFamCred(int IdProducto, int IdSubProducto)
        {
            return objADSolicitud.ADBusFamCred(IdProducto, IdSubProducto);
        }

        /// <summary>
        /// Obtener el total de dias del crédito
        /// </summary>
        /// <param name="dFecDesemb"></param>
        /// <param name="nNumCuoCta"></param>
        /// <param name="nDiaGraCta"></param>
        /// <param name="nTipPerPag"></param>
        /// <param name="nDiaFecPag"></param>
        /// <returns></returns>
        public int ObtieneTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            //  double nTasEfeDia = Math.Pow((1.0 + nTasEfeMen), (1.0 / 30.0)) - 1; //Tasa de interes efectiva diaria

            int nTotalDiasCredito = 0;

            int nDiaAcumul = 0;

            DateTime dFecNewCuo = dFecDesemb.AddDays(Convert.ToDouble(nDiaGraCta)); //la fecha de la cuota siguiente será la del desembolso + la gracia
            DateTime DfecVeriFec;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));

            int nNumMesCuo = 0;
            int nNumAñoCuo = 0;

            if (nTipPerPag == 1) //Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)
            {
                if (nDiaGraCta == 0) // Para evitar que la primera cuota se genere el mismo día del desembolso (con 0 días)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                }
                for (int i = 1; i <= nNumCuoCta; i++)//Recorrer las cuotas para definir las fechas de pago
                {
                    DataRow fila = ppg.NewRow();
                    if (i == 1) // Si primera cuota
                    {
                        if ((dFecNewCuo.Day > nDiaFecPag)) // La primera cuota caerá el siguiente mes de la (fecha de desembolso + los días de gracia)
                        {
                            nNumMesCuo = dFecNewCuo.Month + 1;
                        }
                        else //La cuota caera en el mismo mes de la (fecha de desembolso + los días de gracia)
                        {
                            nNumMesCuo = dFecNewCuo.Month;
                        }
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else // A partir de la 2da cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    nDiaFecAux = nDiaFecPag;
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (DateTime.TryParse((nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString()), out DfecVeriFec))
                        {
                            dFecNewCuo = DateTime.Parse(nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString());
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1; // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                    }

                    fila["fecha"] = dFecNewCuo;
                    // calulando la cantidad de días para la cuota
                    if (i == 1) // para la primera cuota
                    {
                        fila["dias"] = (dFecNewCuo - dFecDesemb).Days;
                    }
                    else //Para las cuotas de la segunda en adelante
                    {
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(ppg.Rows[i - 2]["fecha"])).Days;
                    }
                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;
                    ppg.Rows.Add(fila);
                }

                //Total de Dias del Crédito
                nTotalDiasCredito = nDiaAcumul;

            }
            else //Periodo Fijo
            {
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    if (i == 1) //Para la primera cuota
                    {
                        nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaAcumul - nDiaGraCta));// se le resta los días de gracia porque ya se le sumo al inico (se duplicaría)
                    }
                    else
                    {
                        nDiaAcumul = nDiaAcumul + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                    }
                }
                //Total de Dias del Crédito
                nTotalDiasCredito = nDiaAcumul;
            }
            return nTotalDiasCredito;
        }

        public DataTable retornaDatSolRefinanciacion(int idSolicitud)
        {
            return objADSolicitud.retornaDatSolRefinanciacion(idSolicitud);
        }

        public DataTable CNdtBuscarPropuestaCreConsumo(int nidCliente)
        {
            return objADSolicitud.ADdtBuscarPropuestaCreConsumo(nidCliente);
        }

        public DataTable CNdtBuscarDatosSolCreEmpresarial(int nidCliente)
        {
            return objADSolicitud.ADdtBuscarDatosSolCreEmpresarial(nidCliente);
        }

        public DataTable ValidaGarantiasSolicitud(int idSolicitud)
        {
            return objADSolicitud.ValidaGarantiasSolicitud(idSolicitud);
        }

        public DataTable RetornaGravamenSolicitud(int idSolicitud)
        {
            return objADSolicitud.RetornaGravamenSolicitud(idSolicitud);
        }

        public DataTable retornaDatosAsesorDeCliente(int idCli)
        {
            return objADSolicitud.retornaDatosAsesorDeCliente(idCli);
        }

        public DataTable CNListarSolicitudesSinAsesor(int idAgencia)
        {
            return objADSolicitud.ADListarSolicitudesSinAsesor(idAgencia);
        }

        public DataTable CNAsignarAsesorSolicitud(int idSolicitud, int idAsesor)
        {
            return objADSolicitud.ADAsignarAsesorSolicitud(idSolicitud, idAsesor);
        }

        public DataTable CNListarGarantiasxSolicitud(int idSolicitud)
        {
            return objADSolicitud.ADListarGarantiasxSolicitud(idSolicitud);
        }

        public DataTable CNRegDesvinculacionSolGar(int idSolicitud, int idUsuMod, DateTime dFecModReg)
        {
            return objADSolicitud.ADRegDesvinculacionSolGar(idSolicitud, idUsuMod, dFecModReg);
        }

        public DataTable CNGetDatGenCreSolCre(int idSolicitud)
        {
            return objADSolicitud.ADGetDatGenCreSolCre(idSolicitud);
        }

        public clsDBResp CNActualizaEstadoSolCre(int idSolicitud, int idEstado)
        {
            return objADSolicitud.ADActualizaEstadoSolCre(idSolicitud, idEstado);
        }

        public clsDBResp CNAprobacionesCapacitacion(int idSolicitud, int idEstado)
        {
            return objADSolicitud.ADAprobacionesCapacitacion(idSolicitud, idEstado);
        }
        public clsDBResp CNAprobacionesSolicitud(int idSolicitud, int idEstado, int idnivelAprobacion, int idUsuApro, int nIdUsuarioModifica, DateTime dFechaMod)
        {
            return objADSolicitud.ADAprobacionesSolicitud(idSolicitud, idEstado, idnivelAprobacion, idUsuApro, nIdUsuarioModifica, dFechaMod, clsVarGlobal.PerfilUsu.idPerfil);
        }
        public clsDBResp CNAprobacionesSolicitudRNC(int idRNC, string cSustento, int idNivelAprobacion, int lAprobDesaprob, int idUsuReg)
        {
            return objADSolicitud.ADAprobacionesSolicitudRNC(idRNC, cSustento, idNivelAprobacion, lAprobDesaprob, idUsuReg);
        }
        public clsDBResp CNDatosReporteRNC(int idSoli, string cActividadPrincial, string cActividadSecundaria, string cInicial, string cDatosAval, string cCuotaNuevoCred, string cUtilidad, string cSuste, string cDesDestino, int idRNC)
        {
            return objADSolicitud.ADDatosReporteRNC(idSoli, cActividadPrincial, cActividadSecundaria, cInicial, cDatosAval, cCuotaNuevoCred, cUtilidad, cSuste, cDesDestino, idRNC);
        }

        public clsDBResp CNEnviaAEvaluacion(string xmlSolicitud, string xmlCreditoProp, int idUsuario, DateTime dFecha)
        {
            return objADSolicitud.ADEnviaAEvaluacion(xmlSolicitud, xmlCreditoProp, idUsuario, dFecha);
        }

        public bool ValidaProdRefinanciacion(int idCuenta)
        {
            DataTable dtValida = objADSolicitud.ValidaProdRefinanciacion(idCuenta);
            return (dtValida.Rows.Count > 0);
        }
        public DataTable obtenerDatosReporteRNC(int idSolicitud, int idRNC)
        {
            return objADSolicitud.obtenerDatosReporteRNC(idSolicitud, idRNC);
        }
        public DataTable obtenerCreditosRefinanciar(int idCli)
        {
            return objADSolicitud.obtenerCreditosRefinanciar(idCli);
        }
        public DataTable CNExcepcionesGeneradas(int nIdSolicitud)
        {
            return objADSolicitud.ADExcepcionesGeneradas(nIdSolicitud);
        }
        public DataTable CNReglasPorFormulario(string cIdsReglas, String cIdOpcion)
        {
            return objADSolicitud.ADReglasPorFormulario(cIdsReglas, cIdOpcion);
        }
        public DataTable CNInsertarExcepcionManual(int nIdSolicitud, int nIdAgencia, int nIdCliente, int nIdMoneda, int nIdProducto, decimal nValAproba, int nIdUsuRegist, String xml)
        {
            return objADSolicitud.ADInsertarExcepcionManual(nIdSolicitud, nIdAgencia, nIdCliente, nIdMoneda, nIdProducto, nValAproba, nIdUsuRegist, xml);
        }
        public DataTable listarCreditosSolEvalAsesor(int idUsuario)
        {
            return objADSolicitud.listarCreditosSolEvalAsesor(idUsuario);
        }
        public DataTable insertarSolReglaNoContemplada(int idSolicitud, int idReglaNoContem, int idExcepGen, int idNivelAprob, int idUsuario, string sustento)
        {
            return objADSolicitud.insertarSolReglaNoContemplada(idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
        }
        public DataTable consultaSolReglaNoContemplada(int idSolicitud, int idReglaNoContem, int idExcepGen, int idNivelAprob, int idUsuario, string sustento)
        {
            return objADSolicitud.consultaSolReglaNoContemplada(idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
        }
        public DataTable listarReglaSolicitud(int idUsuario)
        {
            return objADSolicitud.listarReglaSolicitud(idUsuario);
        }
        public DataTable listarBandejaAprobDenegSolicitud(int idUsuario, int idAgencia, int idPerfil)
        {
            return objADSolicitud.listarBandejaAprobDenegSolicitud(idUsuario, idAgencia, idPerfil);
        }
        public DataTable listarBandejaDatosSolicitud(int idSolicitud)
        {
            return objADSolicitud.listarBandejaDatosSolicitud(idSolicitud);
        }
        public DataTable cargarSustentoSolicitudRNC(int idRNC, int idNivelAprob)
        {
            return objADSolicitud.cargarSustentoSolicitudRNC(idRNC, idNivelAprob);
        }
        public DataTable ObtenerReporteRNC(int idSolicitud)
        {
            return objADSolicitud.ObtenerReporteRNC(idSolicitud);
        }
        public clsDBResp anularExcepcionNC(int idRNC, DateTime dFechaMod, int idPerfil)
        {
            return objADSolicitud.anularExcepcionNC(idRNC, dFechaMod, idPerfil);
        }
        public DataTable ObtenerReporteRNC1(int idSolicitud)
        {
            return objADSolicitud.ObtenerReporteRNC1(idSolicitud);
        }
        public DataTable ObtenerReporteRNCIni(int idSolicitud, int idRegla, string sustento)
        {
            return objADSolicitud.ObtenerReporteRNCIni(idSolicitud, idRegla, sustento);
        }
        public DataTable cargarLblBtnSolicitudRNC(int idRNC, int idNivelAprob)
        {
            return objADSolicitud.cargarLblBtnSolicitudRNC(idRNC, idNivelAprob);
        }
        public DataTable verificarSolOpiRecu(int idSolicitud)
        {
            return objADSolicitud.verificarSolOpiRecu(idSolicitud);
        }

        public DataTable actualizarMontosSolRefi(int idSolicitud)
        {
            return objADSolicitud.actualizarMontosSolRefi(idSolicitud);
        }

        public DataTable verificarSolReaprobacion(int idSolicitud)
        {
            return objADSolicitud.verificarSolReaprobacion(idSolicitud);
        }


        public decimal obtenerValorActualSoliRefi(int idSolicitud)
        {
            DataTable dtValor = objADSolicitud.obtenerValorActualSoliRefi(idSolicitud);
            decimal nMontoSolicitudActual = 0.00m;
            if (dtValor.Rows.Count > 0)
            {
                nMontoSolicitudActual = Convert.ToDecimal(dtValor.Rows[0][0]);
            }
            return nMontoSolicitudActual;
        }

        public DataTable CNBuscaSolicitudesGS(int idGrupo)
        {
            return objADSolicitud.ADBuscaSolicitudesGS(idGrupo);
        }

        public DataTable CNEnviarAEvaluacionWS(string clsPropuesta, int idUsuario, int idSolicitud, string cXML)
        {
            return objADSolicitud.ADEnviarAEvaluacionWS(clsPropuesta, idUsuario, idSolicitud, cXML);
        }
        public DataTable CNConsultaRegistroGarantias(int idCli, int idProducto, int idSolicitud)
        {
            return objADSolicitud.ADConsultaRegistroGarantias(idCli, idProducto, idSolicitud);
        }

        public List<clsDatosCampana> ObtenerDatosCampana(int idCliente)
        {
            DataTable dtDatosCampana = objADSolicitud.ObtenerDatosCampana(idCliente);

            List<clsDatosCampana> lstDatosCampana = (from DataRow drDatosCampana in dtDatosCampana.Rows select new clsDatosCampana() {
                idDetalle = Convert.ToInt32(drDatosCampana["idDetalle"]),
                idCreditosPreAprobados = Convert.ToInt32(drDatosCampana["idCreditosPreAprobados"]),
                idGrupoCamp = Convert.ToInt32(drDatosCampana["idGrupoCamp"]),
                idTipoGrupoCamp = Convert.ToInt32(drDatosCampana["idTipoGrupoCamp"]),
                idDestino = Convert.ToInt32(drDatosCampana["idDestino"]),
                idCli = Convert.ToInt32(drDatosCampana["idCli"]),
                nTasa = Convert.ToDecimal(drDatosCampana["nTasa"]),
                nMonto = Convert.ToDecimal(drDatosCampana["nMonto"]),
                nPlazo = Convert.ToDecimal(drDatosCampana["nPlazo"]),
                idAsesor = Convert.ToInt32(drDatosCampana["idAsesor"]),
                lVigente = Convert.ToInt32(drDatosCampana["lVigente"]),
                idOperacion = Convert.ToInt32(drDatosCampana["idOperacion"]),
                idMoneda = Convert.ToInt32(drDatosCampana["idMoneda"]),
                idModalidadDesembolso = Convert.ToInt32(drDatosCampana["idModalidadDesembolso"]),
                idActividad = Convert.ToInt32(drDatosCampana["idActividad"]),
                idTipoPeriodo = Convert.ToInt32(drDatosCampana["idTipoPeriodo"]),
                idRecurso = Convert.ToInt32(drDatosCampana["idRecurso"]),
                idModalidadCredito = Convert.ToInt32(drDatosCampana["idModalidadCredito"]),
                idActividadInterna = Convert.ToInt32(drDatosCampana["idActividadInterna"]),
                idTipoCredito = Convert.ToInt32(drDatosCampana["idTipoCredito"]),
                idSubTipoCredito = Convert.ToInt32(drDatosCampana["idSubTipoCredito"]),
                idProducto = Convert.ToInt32(drDatosCampana["idProducto"]),
                idSubProducto = Convert.ToInt32(drDatosCampana["idSubProducto"])
            }).ToList();

            return lstDatosCampana;
        }
        public DataTable ObtenerEstablecimientoEOB()
        {
            return objADSolicitud.ObtenerEstablecimientoEOB();
        }

        public DataTable CargarDatosAprobadorCampana(int idSolicitud)
        {
            return objADSolicitud.CargarDatosAprobadorCampana(idSolicitud);
        }

        public DataTable ObtenerDatosValidacionCampana(int idSolicitud)
        {
            return objADSolicitud.ObtenerDatosValidacionCampana(idSolicitud);
        }

        public DataTable ObtenerVinculados(int idSolicitud)
        {
            return objADSolicitud.ObtenerVinculados(idSolicitud);
        }

        public DataTable BuscarClientesVincular(int idTipoDocumento, string cDocumentoID)
        {
            return objADSolicitud.BuscarClientesVincular(idTipoDocumento, cDocumentoID);
        }

        public DataTable BuscarClienteCriterioExpresion(int idCriterio, string cExpresion)
        {
            cExpresion = cExpresion.Trim();
            if (idCriterio == 3)
            {
                cExpresion = Regex.Replace(cExpresion, @"(\s+)", "%") + "%";
            }
            return objADSolicitud.BuscarClienteCriterioExpresion(idCriterio, cExpresion);
        }

        public Boolean RegistroInterviniente(int idSolicitud, int idCli, int idTipoInterviniente, int idUsuario, DateTime dFechaSistema)
        {
            return objADSolicitud.RegistroInterviniente(idSolicitud, idCli, idTipoInterviniente, idUsuario, dFechaSistema);
        }

        public Boolean EliminarInterviniente(int idIntervinienteCredito, int idUsuario, int idAgencia, DateTime dFechaSistema)
        {
            return objADSolicitud.EliminarInterviniente(idIntervinienteCredito, idUsuario, idAgencia, dFechaSistema);
        }

        public string ValidaBaseNegativa(string cDocumentoID)
        {
            DataTable dt = objADSolicitud.ValidaBaseNegativa(cDocumentoID);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            return "El cliente se encuentra en base negativa por el siguiente motivo: " + dt.Rows[0]["cMotivo"].ToString();
        }

        public string ValidaPep(string cDocumentoID)
        {
            DataTable dt = objADSolicitud.ValidaPep(cDocumentoID);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            if (dt.Rows[0]["idVigente"].ToString() == "1")
            {
                return "El cliente es una persona Políticamente Expuesta";
            }
            return "El cliente esta registrado como Políticamente Expuesto, debe completar su registro en el CoreBank";
        }

        public DataTable VincularCuentaDepositoCredito(int idSolicitud, int idCuentaDeposito, int idCuentaCredito, bool lPeticionNuevaCuenta)
        {
            return objADSolicitud.VincularCuentaDepositoCredito(idSolicitud, idCuentaDeposito, idCuentaCredito, lPeticionNuevaCuenta);
        }

        public DataTable ObtenerDestinoCreditoEvaluacion(int idSolicitud, int idTipoDestinoCreditoBusqueda)
        {
            return objADSolicitud.ObtenerDestinoCreditoEvaluacion(idSolicitud, idTipoDestinoCreditoBusqueda);
        }

        public DataTable CNBuscarCuentaAmpliacion(int idSolicitud)
        {
            return this.objADSolicitud.ADBuscarCuentaAmpliacion(idSolicitud);
        }


        public DataTable CNObtenerEstadoSolicitud(int idSolicitud)
        {
            return this.objADSolicitud.ADObtenerEstadoSolicitud(idSolicitud);
        }

        public DataTable CNObtenerIntervinienteSolicitudBiometrico(int idSolicitud)
        {
            return objADSolicitud.ADObtenerIntervinienteSolicitudBiometrico(idSolicitud);
        }

        public DataTable CNValidarMontoCampanaCliente(int idCliente, int idProducto, int idOperacion)
        {
            return objADSolicitud.ADValidarMontoCampanaCliente(idCliente, idProducto, idOperacion);
        }

        public DataTable CNValidarSolicitudEAI(int idSolicitud)
        {
            return objADSolicitud.ADValidarSolicitudEAI(idSolicitud);
        }

        public DataTable CNValidarSolicitudAct(int idCli, int nCodigoSol, int idSubProducto)
        {
            return objADSolicitud.ADValidarSolicitudAct(idCli, nCodigoSol, idSubProducto);
        }

        public DataTable CNValidarBloqueoEAI(int idCli, int idSubProducto)
        {
            return objADSolicitud.ADValidarBloqueoEAI(idCli, idSubProducto);
        }
        
        public DataTable validarAutorizacionDesembolso(int idSolicitud)
        {
            return objADSolicitud.validarAutorizacionDesembolso(idSolicitud, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario);
        }

        public DataTable CNObtenerRastreoTasaNegociable(int idSolicitud, int idTasaNegociada, int idUsuario)
        {
            return objADSolicitud.ADObtenerRastreoTasaNegociable(idSolicitud, idTasaNegociada, idUsuario);
        }
        public DataTable CNObtenerRastreoTasaNegociableAPR(int idSolicitud, int idTasaNegociada, int idUsuario)
        {
            return objADSolicitud.ADObtenerRastreoTasaNegociableAPR(idSolicitud, idTasaNegociada, idUsuario);
        }
        public DataTable CNObtenerRastreoTasaNegociableRepo(int idSolicitud, int idTipoTasa)
        {
            return objADSolicitud.ADObtenerRastreoTasaNegociableRepo(idSolicitud, idTipoTasa);
        }
        public DataTable CNObtenerSolicitudExtornoPendiente(int idCuenta)
        {
            return objADSolicitud.ADObtenerSolicitudExtornoPendiente(idCuenta);
        }
        public DataTable CNObtenerPlanPagosOrigen(int idCuenta)
        {
            return objADSolicitud.ADObtenerPlanPagosOrigen(idCuenta);
        }
        public DataTable CNGuardarExtraPrima(decimal nExtraPrima, string cSustento, int idSolicitud, int idUsuario, int idPerfil)
        {
            return objADSolicitud.ADGuardarExtraPrima(nExtraPrima, cSustento, idSolicitud, idUsuario, idPerfil);
        }

        public DataTable CNObtenerExtraPrima(int idSolicitud)
        {
            return objADSolicitud.ADObtenerExtraPrima(idSolicitud);
        }

        public DataTable CNValidarAutorizacionPoliza(int idSolicitud)
        {
            return objADSolicitud.ADAutorizacionPoliza(idSolicitud);
        }

        public DataTable CNRecuperarBonoClienteCamp(int idCliente, int idSolicitud)
        {
            return objADSolicitud.ADRecuperarBonoClienteCamp(idCliente, idSolicitud);
        }

        #region Modelo Scoring
        public DataTable CNGuardarModeloScoring(int idEvalCred, int idSolicitud)
        {
            return objADSolicitud.ADGuardarModeloScoring(idEvalCred, idSolicitud);
        }

        public DataTable CNGuardarDecisionModeloScoring(int idSolicitud)
        {
            return objADSolicitud.ADGuardarDecisionModeloScoring(idSolicitud);
        }

        #endregion


        #region Solicitud Simplificado
        public DataTable CNRecuperarConfigSolicitudCred(int idTipEvalCred)
        {
            return objADSolicitud.ADRecuperarConfigSolicitudCred(idTipEvalCred);
        }

        public DataTable CNRecuperarSectorEconomico(string cSectorEcon = "")
        {
            return this.objADSolicitud.ADRecuperarSectorEconomico(cSectorEcon);
        }

        public DataTable CNRecuperarProductoTipEval(string cIDsTipEvalCred)
        {
            return this.objADSolicitud.ADRecuperarProductoTipEval(cIDsTipEvalCred);
        }

        public List<clsProductoCredSimp> CNRecuperarProductoSimpTipEval(string cIDsTipEvalCred)
        {
            DataTable dtProducto = this.objADSolicitud.ADRecuperarProductoSimpTipEval(cIDsTipEvalCred);
            List<clsProductoCredSimp> lstProducto = (dtProducto.Rows.Count > 0) ? dtProducto.ToList<clsProductoCredSimp>() as List<clsProductoCredSimp> : new List<clsProductoCredSimp>();
            return lstProducto;
        }

        public DataTable CNRecuperarSectorCliente(int idCliente)
        {
            return this.objADSolicitud.ADRecuperarSectorCliente(idCliente);
        }

        public DataTable CNRecuperarSaldoRCCCliente(int idCliente)
        {
            return this.objADSolicitud.ADRecuperarSaldoRCCCliente(idCliente);
        }

        public DataTable CNRecuperarDatosCreditoCliente(int idCliente)
        {
            return this.objADSolicitud.ADRecuperarDatosCreditoCliente(idCliente);
        }

        public DataTable CNObtienePlanPagoSimulado(DateTime dFechaDesembolso, int nCuotas, int nDiasGracia, short idTipoPeriodo, int nPlazoCuota, DateTime dFecPrimeraCuota, int nCuotasGracia = 0)
        {

            #region Realizando la definición de la tabla de plan de pagos

            int nDiaAcumul = 0;
            DateTime dFecNewCuo = dFecPrimeraCuota;

            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));

            #endregion

            #region Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)

            if (idTipoPeriodo == 1)
            {
                if (nDiasGracia == 0)
                // Para evitar que la primera cuota se genere el mismo día del desembolso (con 0 días)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(1);
                }
                for (int i = 1; i <= nCuotas; i++) //Recorrer las cuotas para definir las fechas de pago
                {
                    DataRow fila = dtPlanPago.NewRow();
                    fila["cuota"] = i;
                    int nNumMesCuo;
                    int nNumAñoCuo;
                    if (i == 1) // Si primera cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else // A partir de la 2da cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    var nDiaFecAux = nPlazoCuota;
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (i == 1)
                        {
                            dFecNewCuo = dFecPrimeraCuota;
                            break;
                        }
                        DateTime dfecVeriFec;
                        if (DateTime.TryParse(string.Format("{0}/{1}/{2}", nDiaFecAux, nNumMesCuo, nNumAñoCuo),
                            out dfecVeriFec))
                        {
                            dFecNewCuo = DateTime.Parse(string.Format("{0}/{1}/{2}", nDiaFecAux, nNumMesCuo, nNumAñoCuo));
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1;
                        // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                    }
                    fila["fecha"] = dFecNewCuo;
                    // calculando la cantidad de días para la cuota
                    if (i == 1) // para la primera cuota
                    {
                        fila["dias"] = (dFecNewCuo - dFechaDesembolso).Days;
                    }
                    else //Para las cuotas de la segunda en adelante
                    {
                        fila["dias"] =
                            (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days;
                    }

                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;

                    dtPlanPago.Rows.Add(fila);
                }
            }

            #endregion

            #region Periodo Fijo

            else
            {
                for (int i = 1; i <= nCuotas; i++)
                {
                    DataRow fila = dtPlanPago.NewRow();
                    fila["cuota"] = i; //registrando la cuota
                    if (i == 1) //Para la primera cuota
                    {
                        nDiaAcumul = nDiaAcumul + nDiasGracia + nPlazoCuota;
                        dFecNewCuo = dFecPrimeraCuota;
                        fila["fecha"] = dFecNewCuo;
                        fila["dias"] = nPlazoCuota + nDiasGracia;
                        fila["dias_acu"] = nDiaAcumul;
                    }
                    else
                    {
                        nDiaAcumul = nDiaAcumul + nPlazoCuota;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nPlazoCuota));
                        fila["fecha"] = dFecNewCuo;
                        fila["dias"] =
                            (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days;
                        fila["dias_acu"] = nDiaAcumul;
                    }

                    dtPlanPago.Rows.Add(fila);
                }
            }

            #endregion

            dtPlanPago.AcceptChanges();

            return dtPlanPago;
        }

        public DataTable CNRecuperarModalidadPago()
        {
            return this.objADSolicitud.ADRecuperarModalidadPago();
        }

        public DataTable CNRecuperarTipoCredito()
        {
            return this.objADSolicitud.ADRecuperarTipoCredito();
        }
        #endregion

        public DataTable CNObtenerDestinoOpeRefNov(int idCuenta)
        {
            return objADSolicitud.ADObtenerDestinoOpeRefNov(idCuenta);
        }

        public DataTable CNObtenerProdCampImpulMyperu(int idCuenta)
        {
            return objADSolicitud.ADObtenerProdCampImpulMyperu(idCuenta);
        }

        public DataTable CNValidaCuentasProgImpulsoMyPeru(int idCli, string cCuentas)            // Modificaciones rgomez
        {
            return objADSolicitud.ADValidaCuentasProgImpulsoMyPeru(idCli, cCuentas);
        }

        public DataTable CNVerificaCampImpulsoMyperu(int idGrupoCamp)
        {
            return objADSolicitud.ADVerificaCampImpulsoMyperu(idGrupoCamp);
        }
        public DataTable CNVerificarOpinionRiesgosReprogramacion(int idSolicitud, int idOperacion, int idCli, int idTipoPersona)
        {
            return objADSolicitud.ADVerificarOpinionRiesgosReprogramacion(idSolicitud, idOperacion, idCli, idTipoPersona);
        }
        public DataTable CNVerificaOpinionRiesgo(int idSolicitud)
        {
            return objADSolicitud.ADVerificaOpinionRiesgo(idSolicitud);
        }
        public DataTable CNListaEntidadFinanciera()
        {
            return objADSolicitud.ADListaEntidadFinanciera();
        }
        public DataTable CNListaMotivosolicitudTasa(string cTipo)
        {
            return objADSolicitud.ADListaMotivosolicitudTasa(cTipo);
        }
        public DataTable CNListaMotivoAnulaTasa()
        {
            return objADSolicitud.ADListaMotivoAnulaTasa();
        }
        public DataTable CNMostrarEstadoTasaNegociable(int idSolicitud, int idTipoSol)
        {
            return objADSolicitud.ADMostrarEstadoTasaNegociable(idSolicitud, idTipoSol);
        }
        public DataTable CNMostrarHistoricoTEACliente(int idTipoDocumento, string cDocumento)
        {
            return objADSolicitud.ADMostrarHistoricoTEACliente(idTipoDocumento, cDocumento);
        }
        public DataTable CNObtenerZonaUsuario(int idUsuario)
        {
            return objADSolicitud.ADObtenerZonaUsuario(idUsuario);
        }
        public DataTable CNMostrarTasaPromedioPonderada(DateTime dFechaSistema, int idAgencia, int idZona, int idUsuario)
        {
            return objADSolicitud.ADMostrarTasaPromedioPonderada(dFechaSistema, idAgencia, idZona, idUsuario);
        }
        public DataTable CNObtenerSolicitudTasaNegociable(int idUsuario, int idSolicitud, int idTipoSolicitud)
        {
            return objADSolicitud.ADObtenerSolicitudTasaNegociable(idUsuario, idSolicitud, idTipoSolicitud);
        }
        public DataTable CNObtenerMotivoSolicitudTasaNegociable(int idSolicitud, int idTipoSolicitud)
        {
            return objADSolicitud.ADObtenerMotivoSolicitudTasaNegociable(idSolicitud, idTipoSolicitud);
        }
        public DataTable CNEnviarSolicitudTasaNegociable(int idTasaNegociada, int idEstado, DateTime dFechaSistema)
        {
            return objADSolicitud.ADEnviarSolicitudTasaNegociable(idTasaNegociada, idEstado, dFechaSistema);
        }
        public DataTable CNDevolverSolicitudTasaNegociable(int idTasaNegociada, int idEstado, string cMotivoAD, int idUsuario)
        {
            return objADSolicitud.ADDevolverSolicitudTasaNegociable(idTasaNegociada, idEstado, cMotivoAD, idUsuario);
        }
        public DataTable CNDevolverSolicitudTasaNegociablePRE(int idTasaNegociada, int idEstado, int idSolTasa, string cMotivoAD, int idUsuario)
        {
            return objADSolicitud.ADDevolverSolicitudTasaNegociablePRE(idTasaNegociada, idEstado, idSolTasa, cMotivoAD, idUsuario);
        }
        public DataTable CNListaTasaCreditoNegociable(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, int idOperacion, int idClasificacionInterna)
        {
            return objADSolicitud.ADListaTasa(nPlazo, idProducto, nMonto, idMoneda, idAgencia, true, idOperacion, idClasificacionInterna);
        }
        public DataTable CNObtenerEstadoSolicitudTasaNegociable()
        {
            return objADSolicitud.ADObteneridTasaNegociable();
        }
        public DataTable CNObtenerEstadoTasaNegociable()
        {
            return objADSolicitud.ADObtenerEstadosTasaNegociable();
        }
        //--================================================================================
        //--Obtener correos de aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable CNObtenerCuerpoMensajeAprobacionSMS(string cEstado, string cTasa, string cPerfil, string cFechahora)
        {
            return objADSolicitud.ADObtenerCuerpoMensajeAprobacionSMS(cEstado, cTasa, cPerfil, cFechahora);
        }
        public DataTable CNObtenerCuerpoMensajeAprobacion(string cEstadoSol, string cCliente, string cTasa, string cMonto, string cComentario, string cUsuario, string cFechaHora)
        {
            return objADSolicitud.ADObtenerCuerpoMensajeAprobacionEMAIL(cEstadoSol, cCliente, cTasa, cMonto, cComentario, cUsuario, cFechaHora);
        }
        public DataTable CNObtenerCuerpoMensajeSMS(string cUsuario, string cAgencia, string cCliente, string cTasa, string cMonto, string cPerfil)
        {
            return objADSolicitud.ADObtenerCuerpoMensajeSMS(cUsuario, cAgencia, cCliente, cTasa, cMonto, cPerfil);
        }
        public DataTable CNObtenerCuerpoMensaje(string cUsuario, string cAgencia, string cCliente, string cTasa, string cMonto, string cPerfil, string cTasaPizarra)
        {
            return objADSolicitud.ADObtenerCuerpoMensajeEMAIL(cUsuario, cAgencia, cCliente, cTasa, cMonto, cPerfil, cTasaPizarra);
        }
        public DataTable CNListarCorreoAprobaSol(string cPerfil, int idZona, int idAgencia, int idUsuario, int idPerfil)
        {
            return objADSolicitud.ADListarCorreoAprobaSol(cPerfil, idZona, idAgencia, idUsuario, idPerfil);
        }
        public DataTable CNListarCorreoADN(int idUsuario, int idPerfil)
        {
            return objADSolicitud.ADListarCorreoADN(idUsuario, idPerfil);
        }
        public DataTable CNListarCorreoPRE(int idUsuarioADN, int idAgencia, int idPerfil)
        {
            return objADSolicitud.ADListarCorreoPRE(idUsuarioADN, idAgencia, idPerfil);
        }
        public DataTable CNListarCorreoPREGerNegociable(int idUsuarioADN, int idAgencia)
        {
            return objADSolicitud.ADListarCorreoPREGerNegociable(idUsuarioADN, idAgencia);
        }
        //--================================================================================
        //--Obtener celulares de aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable CNListarCelularAprobaSol(string cPerfil, int idZona, int idAgencia, int idUsuario, int idPerfil)
        {
            return objADSolicitud.ADListarCelularAprobaSol(cPerfil, idZona, idAgencia, idUsuario, idPerfil);
        }
        public DataTable CNListarCelularPRE(int idUsuarioADN, int idAgencia, int idPerfil)
        {
            return objADSolicitud.ADListarCelularPRE(idUsuarioADN, idAgencia, idPerfil);
        }
        public DataTable CNListarCelularPREGerNegociable(int idUsuarioADN, int idAgencia)
        {
            return objADSolicitud.ADListarCelularPREGerNegociable(idUsuarioADN, idAgencia);
        }
        //--================================================================================
        //--Envío de correos a los aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable CNEnviarCorreoAprobadorTN(string cPerfil, string cDestinatario, string cCuerpo, string cAsunto)
        {
            return objADSolicitud.ADEnviarCorreoAprobadorTN(cPerfil, cDestinatario, cCuerpo, cAsunto);
        }
        //--================================================================================
        //--Switch de envio EMAIL solicitud Tasa Negociable
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioMail()
        {
            return objADSolicitud.ADVerificarParametrosEnvioMail();
        }
        //--================================================================================
        //--Switch de envio SMS solicitud Tasa Negociable
        //--================================================================================
        public DataTable CNVerificarParametrosEnvioSMS()
        {
            return objADSolicitud.ADVerificarParametrosEnvioSMS();
        }
        public DataTable CNGuardaPdfTasaNegociable(int idSolicitud, string cNombreArchivo, byte[] binario, DateTime dFechReg, int idUsuario, bool laproba, string cPerfilUsuario, int idTasaNegociada)
        {
            return objADSolicitud.ADGuardaPdfTasaNegociable(idSolicitud, cNombreArchivo, binario, dFechReg, idUsuario, laproba, cPerfilUsuario, idTasaNegociada);
        }
        public DataTable CNGuardaPdfTasaNegociablePost(int idSolicitud, string cNombreArchivo, byte[] binario, DateTime dFechReg, int idUsuario, bool laproba, string cPerfilUsuario, int idTasaNegociada)
        {
            return objADSolicitud.ADGuardaPdfTasaNegociablePost(idSolicitud, cNombreArchivo, binario, dFechReg, idUsuario, laproba, cPerfilUsuario, idTasaNegociada);
        }
        //--================================================================================
        //--Bloqueo de Solicitudes
        //--================================================================================
        public DataTable CNVerifEstCuenta(int idCuenta)
        {
            return objADSolicitud.ADVerifEstCuenta(idCuenta);
        }
        public DataTable CNBusUsuBlo(int idUsuario)
        {
            return objADSolicitud.ADBusUsuBlo(idUsuario);
        }
        public DataTable CNUpdEstCuenta(int idCuenta, Nullable<int> idUsuario)
        {
            return objADSolicitud.ADUpdEstCuenta(idCuenta, idUsuario);
        }
        public DataTable CNDesbloqueaCuenta(int idCuenta)
        {
            return objADSolicitud.ADDesbloqueaCuenta(idCuenta);
        }
        public DataTable CNAnulaSolaproba(int idSolicitud)
        {
            return objADSolicitud.ADAnulaSolaproba(idSolicitud);
        }
        public DataTable CNObtenerCuentaXSolicitudAll(int idSolicitud)
        {
            return objADSolicitud.ADObtenerCuentaXSolicitudAll(idSolicitud);
        }
        public DataTable CNObtenerRepoTasaNegociable(int idSolicitud, bool lRetencion)
        {
            return objADSolicitud.ADObtenerRepoTasaNegociable(idSolicitud, lRetencion);
        }
        public DataTable CNObtenerClasifInterna(string cDocumento)
        {
            return objADSolicitud.ADObtenerClasifInterna(cDocumento);
        }
    }

}
