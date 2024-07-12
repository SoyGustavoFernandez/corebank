using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.AccesoDatos
{
    public class clsADEvalProcAdj
    {
        public string GrabarProcesoEvaluacionAdj(clsProcesoAdjudicacion Adjudicacion, ref int nResp)
        {
            try
            {
                DataTable ds = new DataTable();
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                ds = objEjeSp.EjecSP("LOG_GrabarEvalProcesoAdquisicion_Sp", Adjudicacion.obtenerXml());
                nResp = Convert.ToInt32(ds.Rows[0]["nResp"].ToString());
                return ds.Rows[0]["mResp"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADRetornaEvaReMinByProv(int idProveedor, int idProceso)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaEvaReqMinbyProv_sp", idProveedor, idProceso);
        }

        //ADRetornaEvaDocByProv
        public DataTable ADRetornaEvaDocByProv(int idProveedor, int idProceso)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaEvaDocByProv_sp", idProveedor, idProceso);
        }

        public DataTable ADRetornaEvaFacTec(int idProveedor, int idProceso)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaEvaFacTec_sp", idProveedor, idProceso);
        }

        public DataTable ADRetornaEvaEco(int idVinculoPro)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaEvaEcoPro_sp", idVinculoPro);
        }

        public clsDBResp GrabarEvaReqMin(int idVincuProveedor, int idProceso, int idProveedor,
                                            DateTime dFechaReg, int idUsuReg, int nGrupo,
                                            int idEstadoEvaPro, bool lEstadoCalifica, clsListaEvaRequisitosMinimos lstEvaReqMinimos)
        {
            try
            {
                var dt = new clsGENEjeSP().EjecSP("LOG_GrabarEvalReqisitosMinimos_Sp", idVincuProveedor, idProceso, idProveedor, dFechaReg, idUsuReg,
                                      nGrupo, idEstadoEvaPro, lEstadoCalifica, lstEvaReqMinimos.obtenerXml());
                return new clsDBResp(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GrabarEvaDocumentos(int idVincuProveedor, DateTime dFechaReg, int idUsuReg,
                                          int idEstEvaGen, bool lEstadoCalifica, clsListaEvaDocumentoProceso lstEvaDocumentos)
        {
            try
            {
                DataTable dt = new DataTable();
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                dt = objEjeSp.EjecSP("LOG_GrabarEvalDocumentos_Sp", idVincuProveedor, dFechaReg, idUsuReg,
                                            idEstEvaGen, lEstadoCalifica, lstEvaDocumentos.obtenerXml());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GrabarEvaFactoreTecnicos(int idVincuProveedor, int idProveedor, DateTime dFechaReg, int idUsuReg, int idEstadoEva,
                                                    bool lEstadoCalifica, clsListaEvaFactorTecnico lstEvaFacTecnicos)
        {
            try
            {
                DataTable dt = new DataTable();
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                dt = objEjeSp.EjecSP("LOG_GrabarEvalFactorTecnico_Sp", idVincuProveedor, idProveedor, dFechaReg, idUsuReg, idEstadoEva, lEstadoCalifica,
                                                                        lstEvaFacTecnicos.obtenerXml());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GrabarEvaEconomica(int idVinculoProveedor, int idProceso, int idProveedor,
                                            int idEstadoEvaPro, int nGrupo, decimal nMontoPropuesto,
                                            clsListaDetalleProcesoAdj lstEvaDetallePro)
        {
            try
            {
                DataTable dt = new DataTable();
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                dt = objEjeSp.EjecSP("LOG_GrabarEvalEconomica_Sp", idVinculoProveedor, idProceso, idProveedor, idEstadoEvaPro, nGrupo, nMontoPropuesto, lstEvaDetallePro.obtenerXml());
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public clsListaEvaDocumentoProceso buscarDocumentoProcesoEva(int idProcesoAdj)
        {
            clsListaEvaDocumentoProceso evaDoc = new clsListaEvaDocumentoProceso();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarDocCalendarioProceso_SP", idProcesoAdj);

            foreach (DataRow item in ds.Rows)
            {
                evaDoc.Add(new clsEvaDocumentoProceso()
                {
                    cTipoDocProAdqui = item["cTipoDocProAdqui"].ToString(),
                    idCalendario = Convert.ToInt32(item["idCalendario"].ToString()),
                    idEstadoEvaDoc = Convert.ToInt32(item["idEstadoEvaDoc"].ToString()),
                    idProceso = Convert.ToInt32(item["idProceso"].ToString()),
                    idTipoDocProAdqui = Convert.ToInt32(item["idTipoDocProAdqui"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                    idEtapaCalendario = Convert.ToInt32(item["idEtapaCalendario"].ToString())
                });
            }
            return evaDoc;
        }

        public clsListaEvaRequisitosMinimos buscarReqMinProcesoEva(int idProcesoAdj)
        {
            clsListaEvaRequisitosMinimos evaDoc = new clsListaEvaRequisitosMinimos();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarReqMinimos_SP", idProcesoAdj);

            foreach (DataRow item in ds.Rows)
            {
                evaDoc.Add(new clsEvaRequisitosMinimos()
                {
                    cSustento = item["cSustento"].ToString(),
                    cTipoReqMinimo = item["cTipoReqMinimo"].ToString(),
                    idProcesoAdj = Convert.ToInt32(item["idProceso"].ToString()),
                    idTipoReqMinimo = Convert.ToInt32(item["idTipoReqMinimo"].ToString()),
                    idDetalleNotaPedido = Convert.ToInt32(item["idDetalleNotaPedido"]),
                    nItem = Convert.ToInt32(item["nItem"].ToString())
                });
            }
            return evaDoc;
        }

        public DataTable buscarEstadoEvaDoc()// clsListaEstadoEvaDoc buscarEstadoEvaDoc()
        {
            DataTable ds = new DataTable();
            // clsListaEstadoEvaDoc lstEstadoEvaDoc = new clsListaEstadoEvaDoc();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarEstadoEvaDocProceso_SP");
            //foreach (DataRow  nRow in ds.Rows)
            //{
            //    lstEstadoEvaDoc.Add(new clsEstadoEvaDoc(){
            //        cDescripcion = nRow["cDescripcion"].ToString(),
            //        idEstadoEvaDoc = Convert.ToInt32(nRow["idEstadoEvaDoc"].ToString())
            //    });
            //}
            return ds;//lstEstadoEvaDoc;
        }

        public clsListaEvaFactorTecnico buscarPlantillaEvaFacTecnico(int idProceso, int idProveedor)
        {
            clsListaEvaFactorTecnico lstplaEvaFacTec = new clsListaEvaFactorTecnico();

            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarPlantillaEvaFactoresTecnicos_SP", idProceso, idProveedor);
            foreach (DataRow item in ds.Rows)
            {

                lstplaEvaFacTec.Add(new clsEvaFactorTecnico()
                {
                    cDecripcion = item["cDecripcion"].ToString(),
                    cTipoEval = item["cTipoEval"].ToString(),
                    idFacTecnicos = Convert.ToInt32(item["idFacTecnicos"].ToString()),
                    idGrupo = Convert.ToInt32(item["idGrupo"].ToString()),
                    idPadre = Convert.ToInt32(item["idPadre"].ToString()),
                    idProceso = Convert.ToInt32(item["idProceso"].ToString()),

                    idTipoEvaFacTec = Convert.ToInt32(item["idTipoEvaFacTec"].ToString()),
                    lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                    nOrden = Convert.ToInt32(item["nOrden"].ToString()),
                    nPuntaje = Convert.ToDecimal(item["nPuntaje"].ToString()),
                    P_Grupo = Convert.ToDecimal(item["P_Grupo"].ToString()),
                    nPuntajeMax = Convert.ToDecimal(item["nPuntajeMax"])
                });
            }
            return lstplaEvaFacTec;
        }

    }
}
