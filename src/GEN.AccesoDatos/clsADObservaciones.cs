using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADObservaciones
    {
        public clsGENEjeSP objEjesp = new clsGENEjeSP();

        public clsDBResp ADGuardarObservaciones(string xmlObservaciones)
        {
            DataTable dtResult = objEjesp.EjecSP("GEN_GuardarObservaciones_Sp", xmlObservaciones);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }
        public List<clsObservacion> ADGetObservaciones(int idRegistro,int idTipoOperacion)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstObservaciones_Sp", idRegistro, idTipoOperacion);
            return MapeaTablaEntidadObservacion(dtResult);
        }

        private List<clsObservacion> MapeaTablaEntidadObservacion(DataTable dtResult)
        {
            List<clsObservacion> lstObservaciones = new List<clsObservacion>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsObservacion objObservacion = new clsObservacion()
                {
                    idObservacion = Convert.ToInt32(row["idObservacion"]),
                    idRegistro = Convert.ToInt32(row["idRegistro"]),
                    idCli = Convert.ToInt32(row["idCli"]),
                    idTipoOperacion = Convert.ToInt32(row["idTipoOperacion"]),
                    idSolAproba = Convert.ToInt32(row["idSolAproba"]),
                    idNivelAprRanOpe = Convert.ToInt32(row["idNivelAprRanOpe"]),
                    idGrupoObs =  Convert.ToInt32(row["idGrupoObs"]),
                    cGrupoObs = Convert.ToString(row["cGrupoObs"]),
                    idOrigenObs = Convert.ToInt32(row["idOrigenObs"]),
                    cOrigenObs = Convert.ToString(row["cOrigenObs"]),
                    idTipObs = Convert.ToInt32(row["idTipObs"]),
                    cTipObs = Convert.ToString(row["cTipObs"]),
                    cObservacion = Convert.ToString(row["cObservacion"]),
                    lSubsanado = Convert.ToBoolean(row["lSubsanado"]),
                    cNivelAproba = Convert.ToString(row["cNivelAproba"]),
                    dFecha = Convert.ToDateTime(row["dFecReg"])
                };
                lstObservaciones.Add(objObservacion);
            }
            return lstObservaciones;
        }

        public DataTable ADGetTipObs(int idOrigenObs, int idGrupoObs, int idEtapaEvalCred)
        {
            return objEjesp.EjecSP("CRE_LstTipObs_Sp", idOrigenObs, idGrupoObs, idEtapaEvalCred);
        }

        public DataTable ADGetGrupoObs()
        {
            return objEjesp.EjecSP("CRE_LstGrupoObs_Sp");
        }

        public DataTable ADGetEstObs(int idEstado)
        {
            return objEjesp.EjecSP("CRE_LstEstadoObs_SP", idEstado);
        }

    }
}
