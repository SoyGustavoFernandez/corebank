using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADEvalCred
    {
        public clsGENEjeSP objEjesp = new clsGENEjeSP();

        public List<clsEvalCredComite> ADGetEvalCredCli(int idCli, DateTime dFecIni, DateTime dFecFin,
                                                        decimal nMontoMin, decimal nMontoMax, int idMoneda,
                                                        int idAgencia, int idPerfil, int idUsuario,int nModo, int idCanalAproCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_BusEvalCredCli_Sp", idCli, dFecIni, dFecFin,
                                                    nMontoMin, nMontoMax, idMoneda, idAgencia, idPerfil, idUsuario, nModo, idCanalAproCred);
            return MapeaTablaEntidadEvalCred(dtResult);
        }

        public clsEvalCredComite ADGetEvalCredSolCred(int idSolicitud)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_BusEvalCredSolCred_Sp", idSolicitud);
            clsEvalCredComite objEvalCredComite = MapeaTablaEntidadEvalCred(dtResult).FirstOrDefault();
            objEvalCredComite.idSolicitud = idSolicitud;
            return objEvalCredComite;
        }

        private List<clsEvalCredComite> MapeaTablaEntidadEvalCred(DataTable dtResult)
        {
            List<clsEvalCredComite> lstEvalCred = new List<clsEvalCredComite>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsEvalCredComite objEval = new clsEvalCredComite()
                {
                    idEval = Convert.ToInt32(row["idEval"]),
                    idSolicitud = Convert.ToInt32(row["idSolicitud"]),
                    nMontoProp = Convert.ToDecimal(row["nMontoProp"]),
                    idCli = Convert.ToInt32(row["idCli"]),
                    cNombre = Convert.ToString(row["cNombre"]),
                    idMoneda = Convert.ToInt16(row["IdMoneda"]),
                    cMoneda = Convert.ToString(row["cMoneda"]),
                    idAsesor = row["idAsesor"] == DBNull.Value ? 0 : Convert.ToInt32(row["idAsesor"]),
                    cAsesor = Convert.ToString(row["cAsesor"]),
                    cProducto = Convert.ToString(row["cProducto"]),
                    idProducto = Convert.ToInt32(row["IdProducto"]),
                    idEstadoEvalCred = Convert.ToInt32(row["idEstadoEvalCred"]),
                    cCanalAproCred = row["cCanalAproCred"].ToString(),
                    cNomCorto = row["cNomCorto"].ToString(),
                    cNombreEstab = row["cNombreEstab"].ToString(),
                    idClasificacionInterna = Convert.ToInt32(row["idClasificacionInterna"]),
                    idEstSol = Convert.ToInt32(row["idEstSol"]),
                    cEstSol = Convert.ToString(row["cEstSol"])
                };
                lstEvalCred.Add(objEval);
            }

            return lstEvalCred;
        }


        public clsDBResp ADDevolverEvalCred(string xmlEvalCred, int idUsuario)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_DevolverEvalCred_Sp", xmlEvalCred, idUsuario);
            return new clsDBResp(dtResult);
        }

        public DataTable ADListarCultivo()
        {
            return objEjesp.EjecSP("CRE_ListarCultivo_SP");
        }

        public DataTable ADListarVariedadPorCultivo(int idCultivoEval)
        {
            return objEjesp.EjecSP("CRE_ListarVariedadPorCultivo_SP", idCultivoEval);
        }

        public DataTable obtenerZonaAgencia(int idAgencia)
        {
            return objEjesp.EjecSP("CRE_NombreZona_SP", idAgencia);
        }
        public DataTable listarTipDestCred(int idTipDestCred, int idPadre)
        {
            return objEjesp.EjecSP("CRE_ListarTipDestCred_SP", idTipDestCred, idPadre);
        }
        public DataTable listarUnidadProductiva()
        {
            return objEjesp.EjecSP("CRE_ListarUnidadProductiva_SP");
        }
        public DataTable listarTipoEvaluacion(int idClase)
        {
            return objEjesp.EjecSP("CRE_ListarTipoEvaluacionCredito_SP", idClase);
        }
        public DataTable ListarProductosPorTipoEvaluacion(int idTipEvalCred)
        {
            return objEjesp.EjecSP("CRE_ListarProductosPorTipoEvaluacion_SP",idTipEvalCred);
        }
        public DataTable GuardarProductosOpinionRiesgosEvalResumida(string xmlProductosOpinionRiesgos, int idUsuarioMod, DateTime dFechaSistema)
        {
            return objEjesp.EjecSP("CRE_GuardarProductosOpinionRiesgosEvalResumida_SP",xmlProductosOpinionRiesgos, idUsuarioMod, dFechaSistema);
        }

        public DataTable dtCultivoMatriz(params object[] parametros)
        {
            return objEjesp.EjecSP("CRE_ObtenerCultivosMatriz_SP", parametros);
        }

        public DataTable dtVariedadCultivoMatriz(params object[] parametros)
        {
            return objEjesp.EjecSP("CRE_ObtenerVariedadesCultivoMatriz_SP", parametros);
        }

        public DataTable dtUnidadMedidaMatriz(params object[] parametros)
        {
            return objEjesp.EjecSP("CRE_ObtenerUnidadesMedidaMatriz_SP", parametros);
        }

        public DataTable dtTipoCultivoMatriz(params object[] parametros)
        {
            return objEjesp.EjecSP("CRE_ObtenerTiposCultivoMatriz_SP", parametros);
        }

        public DataTable dtTipoFinanciamientoMatriz(params object[] parametros)
        {
            return objEjesp.EjecSP("CRE_ObtenerTiposFinanciamientoMatriz_SP", parametros);
        }
    }
}
