using EntityLayer;
using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPL.CapaNegocio
{
    public class clsCNScoring
    {
        private DataTable _dtCalificacion;
        private readonly clsADScoring _adScoring;

        public clsCNScoring()
        {
            _adScoring = new clsADScoring();
        }

        public DataTable ListaFactoresCalificacion(int idTipoEval, int idFactor, int idPadre)
        {
            return _adScoring.ListaFactoresCalificacion(idTipoEval,idFactor, idPadre);
        }

        public DataTable ListaTiposEvaluacion(int idGrupoEval,int idTipoPersona)
        {
            return _adScoring.ListaTiposEvaluacion(idGrupoEval, idTipoPersona);
        }

        public DataTable ListaGruposFactoresCalific(int idTipoEval)
        {
            return _adScoring.ListaGruposFactoresCalific(idTipoEval);
        }

        public DataTable InsertarFactorCalificacion(int idTipoEval, int idFactor, int idFactorPadre, string cCodEvenRiesgo,
                                                    string cFactores, decimal nIdFactEnTabla, decimal nValorMaximo, string cCodigo,
                                                    decimal nPonderado, int idUsu, DateTime dFecha, string cColumna,
                                                    bool lConId, decimal nPuntaje, bool lVigente, bool lPorRangos)
        {
            return _adScoring.InsertarFactorCalificacion(idTipoEval, idFactor, idFactorPadre, cCodEvenRiesgo,
                                                            cFactores, nIdFactEnTabla, nValorMaximo, cCodigo,
                                                            nPonderado, idUsu, dFecha, cColumna,
                                                            lConId, nPuntaje, lVigente, lPorRangos);
        }

        public DataTable EliminaFactorCalific(int idFactor, int idUsu, DateTime dFecha)
        {
            return _adScoring.EliminaFactorCalific(idFactor, idUsu, dFecha);
        }

        public DataTable ListaDatosCliEvaluacion(List<int> lstClientes)
        {
            return _adScoring.ListaDatosCliEvaluacion(lstClientes);
        }

        public DataTable ListaRegimenes(int idRegimen)
        {
            return _adScoring.ListaRegimenes(idRegimen);
        }

        public DataTable ListaDesCalificacion(int idCalificativo)
        {
            return _adScoring.ListaDesCalificacion(idCalificativo);
        }

        public DataTable GuardaDesCalificacion(int idCalificativo, string cCalificativo, decimal nRangoMin, decimal nRangoMax,
                                                bool lRequiereAprob, bool lVigente, int idUsu, DateTime dFecha, string cColor)
        {
            return _adScoring.GuardaDesCalificacion(idCalificativo, cCalificativo, nRangoMin, nRangoMax, lRequiereAprob, lVigente, idUsu, dFecha, cColor);
        }

        public DataTable GuardaEvaluacionScoring(int idCli, int idTipoEval, int idAgencia, decimal nPuntaje, int idCalificativo,
                                                    int idUsu, DateTime dFecha, string cEvalBatch, bool lBatch, string xmlDetalle)
        {
            return _adScoring.GuardaEvaluacionScoring(idCli, idTipoEval, idAgencia, nPuntaje, idCalificativo, 
                                                        idUsu, dFecha, cEvalBatch, lBatch, xmlDetalle);
        }

        public DataTable ListarEvaluacionesScoring(int idCli, DateTime dFechaDesde, DateTime dFechaHasta, int idRiesgo,
                                                    int idRegimen, int idAgencia, bool lNuevos, bool lRecurrentes)
        {
            return _adScoring.ListarEvaluacionesScoring(idCli, dFechaDesde, dFechaHasta, idRiesgo, idRegimen, idAgencia, lNuevos, lRecurrentes);
        }

        public DataTable ListarEvaluacionHistoricoScoring(int idCli, bool lIncluirBatch)
        {
            return _adScoring.ListarEvaluacionHistoricoScoring(idCli, lIncluirBatch);
        }

        public DataTable ListarDetalleEvalScoring(int idEval)
        {
            return _adScoring.ListarDetalleEvalScoring(idEval);
        }

        public DataTable ActualizarAvistoEval(int idEval, int idUsu, DateTime dFecha)
        {
            return _adScoring.ActualizarAvistoEval(idEval, idUsu, dFecha);
        }

        public DataTable ListaEvalScoringReporte(string cIdsEval)
        {
            return _adScoring.ListaEvalScoringReporte(cIdsEval);
        }

        public DataTable ListarClientesConProd(int idAgencia, DateTime dFecha)
        {
            return _adScoring.ListarClientesConProd(idAgencia, dFecha);
        }

        public DataTable ListarPerfilSuperEvalScoring()
        {
            return _adScoring.ListarPerfilSuperEvalScoring();
        }

        public DataTable VerificarDatosActualCli(int idKardex, string cDocumentoID, int idAgencia, int idTipoOpe, int idCliTitular)
        {
            return _adScoring.VerificarDatosActualCli(idKardex, cDocumentoID, idAgencia, idTipoOpe, idCliTitular);
        }

        public DataTable VerificarDatosActualCliWeb(int idCli)
        {
            return _adScoring.VerificarDatosActualCliWeb(idCli);
        }

        //MANTENIMIENTO DE BLOQUEO DE OPERACIONES
        public DataTable ListarGrupBloqOpe(int idGrupoBloq)
        {
            return _adScoring.ListarGrupBloqOpe(idGrupoBloq);
        }

        public DataTable ListarDetalleBloOpe(int idGrupoBloq)
        {
            return _adScoring.ListarDetalleBloOpe(idGrupoBloq);
        }

        public DataTable GuardaConfiBloqueOpe(int idGrupoBloq, string cDescripcion, DateTime dFechaIni, DateTime dFechaFin,
                                                bool lVigencia, int idUsu, DateTime dFecha, string xmlDetalle)
        {
            return _adScoring.GuardaConfiBloqueOpe(idGrupoBloq, cDescripcion, dFechaIni, dFechaFin, lVigencia, idUsu, dFecha, xmlDetalle);
        }

        public DataTable GetTipoRiesgoSPLAFT()
        {
            return _adScoring.GetTipoRiesgoSPLAFT();
        }

        public DataTable GeneraEvaluacion(int idTipoEval, DataRow drDatCli, DataTable dtFactores, DataTable dtCriterios)
        {
            _dtCalificacion = CreaDtCalifCli();

            if (drDatCli == null || dtFactores == null || idTipoEval == 0)
                return _dtCalificacion;

            foreach (DataRow item in dtFactores.Rows)
            {
                int idFactor = Convert.ToInt32(item["idFactor"].ToString());
                var filterCriterios = dtCriterios.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoEval"]) == idTipoEval
                                                                        && Convert.ToInt16(x["idGrupo"]) == idFactor);
                DataTable dtCriteriosFilter = filterCriterios.Any() ? filterCriterios.CopyToDataTable() : dtCriterios.Clone();
                Evaluacion(dtCriteriosFilter, drDatCli, 0);
            }

            return _dtCalificacion;
        }

        private void Evaluacion(DataTable dtCriterios, DataRow drDatCli, int idFactor)
        {
            var dtFilterCrit = dtCriterios.AsEnumerable().Where(x => x.Field<int>("idFactorPadre") == idFactor);
            foreach (DataRow row in dtFilterCrit)
            {
                bool lAgregar = false;
                DataRow drCalifCli0 = _dtCalificacion.NewRow();
                drCalifCli0["idFactor"] = row.Field<int>("idFactor");
                drCalifCli0["idFactorPadre"] = row.Field<int>("idFactorPadre");
                drCalifCli0["idGrupo"] = row.Field<int>("idGrupo");
                drCalifCli0["Criterios"] = row.Field<string>("cDescripcion");
                drCalifCli0["Ponderacion"] = row.Field<decimal>("nPonderado");
                drCalifCli0["lUltimo"] = row.Field<int>("lUltimo");
                drCalifCli0["Valor"] = row.Field<decimal>("nPuntaje");

                if (!string.IsNullOrEmpty(row.Field<string>("cColumna")))
                {
                    string cColumna = row.Field<string>("cColumna");
                    drCalifCli0["cColumna"] = cColumna;
                    if (!drDatCli.Table.Columns.Contains(cColumna))
                        continue;

                    if (!string.IsNullOrEmpty(row["nValorMaximo"].ToString()))// valida con rangos
                    {
                        decimal nValMin = row.Field<decimal>("nIdFactEnTabla");
                        decimal nValMax = row.Field<decimal>("nValorMaximo");
                        decimal nValor = Convert.ToDecimal(drDatCli[cColumna]);
                        if (nValor >= nValMin && nValor <= nValMax)
                        {
                            drCalifCli0["idDatoCliente"] = nValor;
                            drCalifCli0["DatoCliente"] = nValor;
                            drCalifCli0["Puntaje"] = row.Field<decimal>("nPonderado") * row.Field<decimal>("nPuntaje");
                            lAgregar = true;
                        }
                    }
                    else if (Convert.ToBoolean(row["lUsarValorCalculo"]))// valida con IDs
                    {
                        decimal nValor = Convert.ToDecimal(drDatCli[cColumna]);
                        drCalifCli0["idDatoCliente"] = Convert.ToDecimal(drDatCli[cColumna]);
                        drCalifCli0["DatoCliente"] = nValor;
                        drCalifCli0["Puntaje"] = nValor * row.Field<decimal>("nPuntaje");
                        lAgregar = true;
                    }
                    else if (Convert.ToBoolean(row["lPreferId"]))// valida con IDs
                    {
                        int idTabla = Convert.ToInt32(row["nIdFactEnTabla"]);
                        int nValor = Convert.ToInt32(drDatCli[cColumna]);
                        if (idTabla == nValor)
                        {
                            drCalifCli0["idDatoCliente"] = Convert.ToDecimal(drDatCli[cColumna]);
                            if (drDatCli.Table.Columns.Contains("c" + cColumna))
                            {
                                drCalifCli0["DatoCliente"] = Convert.ToString(drDatCli["c" + cColumna]);
                            }
                            else
                            {
                                if(!(drDatCli[cColumna] is bool))
                                drCalifCli0["DatoCliente"] = Convert.ToString(drDatCli[cColumna]);
                            }
                            drCalifCli0["Puntaje"] = row.Field<decimal>("nPonderado") * row.Field<decimal>("nPuntaje");
                            lAgregar = true;
                        }
                        else
                        {
                            int idFactorInterno = row.Field<int>("idFactor");
                            var result = dtCriterios.AsEnumerable().Where(x => x.Field<int>("idFactorPadre") == idFactorInterno);
                            if (result.Any())
                                continue;
                        }
                    }
                    else
                    {
                        if (drDatCli[cColumna].ToString().Contains(row["cFactores"].ToString()))//valida con la cadena
                        {
                            drCalifCli0["idDatoCliente"] = 0;
                            drCalifCli0["DatoCliente"] = drDatCli[cColumna].ToString();
                            drCalifCli0["Puntaje"] = row.Field<decimal>("nPonderado") * row.Field<decimal>("nPuntaje");
                            lAgregar = true;
                        }
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row["lUltimo"]))
                    {
                        lAgregar = true;
                    }
                }

                if (lAgregar)
                    _dtCalificacion.Rows.Add(drCalifCli0);

                if (!Convert.ToBoolean(row["lUltimo"]))
                {
                    Evaluacion(dtCriterios, drDatCli, row.Field<int>("idFactor"));
                    drCalifCli0["Valor"] = _dtCalificacion.AsEnumerable()
                                                            .Where(x => x.Field<int>("idFactorPadre") == row.Field<int>("idFactor"))
                                                            .Sum(x => x.Field<decimal>("Puntaje"));
                    drCalifCli0["Puntaje"] = drCalifCli0.Field<decimal>("Valor")* drCalifCli0.Field<decimal>("Ponderacion");
                }

            }

        }

        private DataTable CreaDtCalifCli()
        {
            DataTable dtCalificacion = new DataTable();
            dtCalificacion.Columns.Add("idFactor", typeof(int));
            dtCalificacion.Columns.Add("idFactorPadre", typeof(int));
            dtCalificacion.Columns.Add("idGrupo", typeof(int));
            dtCalificacion.Columns.Add("Criterios", typeof(string));
            dtCalificacion.Columns.Add("Ponderacion", typeof(decimal));
            dtCalificacion.Columns.Add("idDatoCliente", typeof(decimal));
            dtCalificacion.Columns.Add("DatoCliente", typeof(string));
            dtCalificacion.Columns.Add("cColumna", typeof(string));
            dtCalificacion.Columns.Add("Valor", typeof(decimal));
            dtCalificacion.Columns.Add("Puntaje", typeof(decimal));
            dtCalificacion.Columns.Add("lUltimo", typeof(int));
            dtCalificacion.Columns.Add("idCalificativo", typeof(int));
            dtCalificacion.Columns.Add("cCalificativo", typeof(string));
            dtCalificacion.Columns.Add("cColorCalific", typeof(string));

            return dtCalificacion;
        }

        public clsDBResp SaveConfigProductoEvalScoring(int idProducto, decimal nPonderado, bool lVigente)
        {
            return _adScoring.SaveConfigProductoEvalScoring(idProducto, nPonderado, lVigente);
        }

        public DataTable GetConfigProductoEvalScoring(int id)
        {
            return _adScoring.GetConfigProductoEvalScoring(id);
        }

        public clsDBResp SaveEscalaMontosEvalScoring(int id, decimal nRanMin, decimal nRanMax, decimal nPonderado, bool lVigente)
        {
            return _adScoring.SaveEscalaMontosEvalScoring(id, nRanMin, nRanMax, nPonderado, lVigente);
        }

        public DataTable GetEscalaMontosEvalScoring(int id)
        {
            return _adScoring.GetEscalaMontosEvalScoring(id);
        }

        public DataTable GetRegimenScoring()
        {
            return _adScoring.GetRegimenScoring();
        }

        public DataTable CNImpresionMasiva(int idEvalIni, int idEvalFin,int idTipoEvaluacion)
        {
            return _adScoring.ADImpresionMasiva(idEvalIni, idEvalFin, idTipoEvaluacion);
        }
        public clsDBResp CNProcesaDatos(string cIdMes, string cIdAnio)
        {
            return _adScoring.ADProcesaDatos(cIdMes, cIdAnio);
        }
    }
}
