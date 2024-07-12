using EntityLayer;
using LOG.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.CapaNegocio
{
    public class clsCNEvalProcAdj
    {
        public string GrabarProcesoEvaluacionAdj(clsProcesoAdjudicacion Adjudicacion, ref int nResp)
        {
            string cResultado = new clsADEvalProcAdj().GrabarProcesoEvaluacionAdj(Adjudicacion, ref nResp);
            return cResultado;
        }

        public DataTable RetornaEvaReMinByProv(int idProveedor, int idProceso)
        {
            return new clsADEvalProcAdj().ADRetornaEvaReMinByProv(idProveedor, idProceso);
        }

        public DataTable RetornaEvaDocByProv(int idProveedor, int idProceso)
        {
            return new clsADEvalProcAdj().ADRetornaEvaDocByProv(idProveedor, idProceso);
        }

        public DataTable RetornaEvaFacTec(int idProveedor, int idProceso)
        {
            return new clsADEvalProcAdj().ADRetornaEvaFacTec(idProveedor, idProceso);
        }

        public DataTable RetornaEvaEco(int idVinculoPro)
        {
            return new clsADEvalProcAdj().ADRetornaEvaEco(idVinculoPro);
        }

        public clsDBResp cnGrabarEvaReqMin(int idVincuProveedor, int idProceso, int idProveedor, DateTime dFechaReg, int idUsuReg,
                                          int nGrupo, int idEstadoEvaPro, bool lEstadoCalifica, clsListaEvaRequisitosMinimos lstEvaReqMinimos)
        {

            return new clsADEvalProcAdj().GrabarEvaReqMin(idVincuProveedor, idProceso, idProveedor, dFechaReg, idUsuReg,
                                         nGrupo, idEstadoEvaPro, lEstadoCalifica, lstEvaReqMinimos);
        }

        /*idVincuProveedor, pIdProceso, pIdProveedor, dFechaReg, idUsuReg, idEstadoEva, lEstadoCalifica, lstEvaDocPro*/
        public DataTable cnGrabarEvaDocumentos(int idVincuProveedor, DateTime dFechaReg, int idUsuReg,
                                          int idEstEvaGen, bool lEstadoCalifica, clsListaEvaDocumentoProceso lstEvaDocumentos)
        {

            return new clsADEvalProcAdj().GrabarEvaDocumentos(idVincuProveedor, dFechaReg, idUsuReg,
                                            idEstEvaGen, lEstadoCalifica, lstEvaDocumentos);
        }

        /*idVincuProveedor, dFechaReg, idUsuReg, idEstadoEva, lEstadoCalifica, lstEvaFacTec*/
        public DataTable cnGrabarEvaFactoreTecnicos(int idVincuProveedor, int idProveedor, DateTime dFechaReg, int idUsuReg, int idEstadoEva,
                                                    bool lEstadoCalifica, clsListaEvaFactorTecnico lstEvaFacTecnicos)
        {

            return new clsADEvalProcAdj().GrabarEvaFactoreTecnicos(idVincuProveedor, idProveedor, dFechaReg, idUsuReg, idEstadoEva, lEstadoCalifica,
                                                                    lstEvaFacTecnicos);
        }

        public DataTable cnGrabarEvaEconomica(int idVinculoProveedor, int idProceso, int idProveedor, int idEstadoEvaPro, int nGrupo, decimal nMontoPropuesto, clsListaDetalleProcesoAdj lstEvaDetallePro)
        {
            return new clsADEvalProcAdj().GrabarEvaEconomica(idVinculoProveedor, idProceso, idProveedor, idEstadoEvaPro, nGrupo, nMontoPropuesto, lstEvaDetallePro);
        }

        public clsListaEvaDocumentoProceso buscarDocumentoProcesoEvaluacion(int idProcesoAdj)
        {
            return new clsADEvalProcAdj().buscarDocumentoProcesoEva(idProcesoAdj);
        }

        public clsListaEvaRequisitosMinimos buscarReqMinProcesoEvaluacion(int idProcesoAdj)
        {
            return new clsADEvalProcAdj().buscarReqMinProcesoEva(idProcesoAdj);
        }

        public DataTable buscarEstadoEvaDoc()//clsListaEstadoEvaDoc buscarEstadoEvaDoc()
        {
            return new clsADEvalProcAdj().buscarEstadoEvaDoc();
        }

        public clsListaEvaFactorTecnico buscarPlantillaEvaFacTecnico(int idProcesoAdj, int idProveedor = 0)
        {
            return new clsADEvalProcAdj().buscarPlantillaEvaFacTecnico(idProcesoAdj, idProveedor);
        }
    }
}
