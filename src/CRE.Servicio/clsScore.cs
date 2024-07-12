using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace CRE.Servicio
{
    public class clsScore
    {
        #region Atributos

        private int idTipoScore;
        private clsCNScoreCreditos objCN;
        private clsParamScore objParamScore;
        private List<clsScoreVarCond> objScoreVarCond;
        private List<clsScoreVariable> objScoreVarVal;

        #endregion
        
        #region Constructor

        public clsScore(bool lBol)
        {
            if (lBol)
            {
                objCN = new clsCNScoreCreditos(lBol);
            }
            else
            {
                objCN = new clsCNScoreCreditos();
            }
            this.idTipoScore = 0;
        }

        

        #endregion

        #region Metodos Publicos

        public void setObjParamScore(clsParamScore _objParamScore)
        {
            this.objParamScore = _objParamScore;
        }

        public void setIdTipoScore(int _idTipoScore)
        {
            this.idTipoScore = _idTipoScore;
        }

        public clsScoreEnt ejecutarScore()
        {
            if (this.objParamScore == null)
            {
                return null;
            }

            if (this.idTipoScore == 0)
            {
                return null;
            }

            clsScoreEnt objVal =  ValidarExitenciaScore();

            if (objVal == null)
            {
                this.preparaVariables();
                this.reemplazarVariable();
                this.obtenerScoreVarCond();
                return this.guardarResultadoScore();
            }
            else
            {
                return objVal;
            }
        }
        public clsScoreEnt ObtenerScoreSolicitud()
        {
            return ValidarExitenciaScore();
        }
        #endregion

        #region Metodos Publicos
        private void preparaVariables()
        {
            this.objScoreVarCond = objCN.CNObtenerScoreVarCond(this.idTipoScore);
            this.objScoreVarVal = objCN.CNIniciarScore(this.objParamScore);
        }

        private void reemplazarVariable()
        {
            foreach (clsScoreVariable item in this.objScoreVarVal)
            {
                foreach (clsScoreVarCond item2 in this.objScoreVarCond)
                {
                    item2.idScore = item.idScore;
                    item2.cCondicionExpreReemplazo = this.ReemplazarValores(item2.cCondicionExpreReemplazo, item.cNombreVariable, item.cValorVariable);
                }
            }
        }

        private clsScoreEnt guardarResultadoScore()
        {
            DataSet dsRespuesta =  objCN.CNGuardaScoreResultado(this.objScoreVarCond);

            if (dsRespuesta.Tables.Count == 1)
            {
                return null;
            }

            List<clsWCFRespuesta> dtResp1 = DataTableToList.ConvertTo<clsWCFRespuesta>(dsRespuesta.Tables[0]) as List<clsWCFRespuesta>;
            if (dtResp1[0].idRespuesta == 1)
            {
                List<clsScoreEnt> dtResp2 = DataTableToList.ConvertTo<clsScoreEnt>(dsRespuesta.Tables[1]) as List<clsScoreEnt>;
                List<clsScoreDetalleVarCond> dtResp3 = DataTableToList.ConvertTo<clsScoreDetalleVarCond>(dsRespuesta.Tables[2]) as List<clsScoreDetalleVarCond>;
                dtResp2[0].listScoreDetalle = dtResp3;
                dtResp2[0].lCumpleBasico = 1;
                return dtResp2[0];
            }

            return null;
        }

        private void obtenerScoreVarCond()
        {
            foreach (clsScoreVarCond item2 in this.objScoreVarCond)
            {
                item2.lCumpleCond = this.ValidarExpresion(item2.cCondicionExpreReemplazo);
            }
        }

        /// <summary>
        /// Valida Expresion enviada por parametro sintaxis Visual Basic
        /// </summary>
        /// <param name="cCadenaValidar">cadena a evaluar</param>
        /// <returns></returns>
        private bool ValidarExpresion(string cCadenaValidar)
        {
            DataTable dtComputable = new DataTable();
            if (Convert.ToBoolean(dtComputable.Compute(cCadenaValidar.Trim(), "")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ReemplazarValores(string cCadenaBase, string cTextoInicial, string cTextoReemplazo)
        {
            return cCadenaBase.Replace(cTextoInicial, cTextoReemplazo);
        }

        private clsScoreEnt ValidarExitenciaScore()
        {
            DataSet dsRes = objCN.CNValidaSiExisteScore(this.objParamScore.idSolicitud);

            if (dsRes.Tables.Count == 1)
            {
                return null;
            }

            List<clsWCFRespuesta> dtResp1 = DataTableToList.ConvertTo<clsWCFRespuesta>(dsRes.Tables[0]) as List<clsWCFRespuesta>;
            if (dtResp1[0].idRespuesta == 1)
            {
                List<clsScoreEnt> dtResp2 = DataTableToList.ConvertTo<clsScoreEnt>(dsRes.Tables[1]) as List<clsScoreEnt>;
                List<clsScoreDetalleVarCond> dtResp3 = DataTableToList.ConvertTo<clsScoreDetalleVarCond>(dsRes.Tables[2]) as List<clsScoreDetalleVarCond>;
                dtResp2[0].listScoreDetalle = dtResp3;
                dtResp2[0].lCumpleBasico = 1;
                return dtResp2[0];
            }

            return null;
        }
        #endregion
    }
}
