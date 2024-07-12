using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADCreditoJornalero
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listaAccionesCultivo() 
        {
            return this.objEjeSp.EjecSP("CRE_CreJorListaAccionesCultivo_SP");
        }

        public DataSet dsItemsScore()
        {
            return this.objEjeSp.DSEjecSP("CRE_CreJorItemsScore_SP");
        }

        public DataSet listaMontos()
        {
            return this.objEjeSp.DSEjecSP("CRE_CreJorListaMonto_SP");
        }

        public DataSet listaScoreCliente(int idCli, int idSolicitud = -1)
        {
            return this.objEjeSp.DSEjecSP("CRE_CreJorListaScoreCliente_SP", idCli, idSolicitud);
        }

        public clsCreJorScoreCliente guardarScoreCliente(clsCreJorScoreCliente oScore)
        {
            DataTable dtResultado = this.objEjeSp.EjecSP("CRE_CreJorInsertarScoreCliente_SP"
                    , oScore.idScoreJornalero
                    , oScore.idItem
                    , oScore.idValor
                    , oScore.nValor
                    , oScore.lVigente
                    , oScore.idScoreCliente
                );
            
            if(dtResultado.Rows.Count > 0)
            {
                oScore.idScoreCliente = Convert.ToInt32(dtResultado.Rows[0]["id"]);
            }
            return oScore;
        }

        public clsCreJorScoreJornalero guardarScoreJornalero(clsCreJorScoreJornalero oScoreJornalero)
        {
            DataTable dtResult = this.objEjeSp.EjecSP("CRE_CreJorInsertarScoreJornalero_SP",
                oScoreJornalero.idCli,
                oScoreJornalero.idSolicitud,
                oScoreJornalero.idAccionCultivo,
                oScoreJornalero.lVigente,
                oScoreJornalero.nPuntaje,
                oScoreJornalero.nMonto,
                oScoreJornalero.idScoreJornalero
                );
            int nId = 0;
            if (dtResult.Rows.Count > 0)
            {
                int nFilas = Convert.ToInt32(dtResult.Rows[0]["nFilas"]);
                if (nFilas > 0)
                {
                    nId = Convert.ToInt32(dtResult.Rows[0]["id"]);
                }
            }
            oScoreJornalero.idScoreJornalero = nId;

            /** Guardar Scoring **/
            oScoreJornalero.oExperiencia.idScoreJornalero = nId;
            oScoreJornalero.oExperiencia = this.guardarScoreCliente(oScoreJornalero.oExperiencia);
            oScoreJornalero.oExpFinanciera.idScoreJornalero = nId;
            oScoreJornalero.oExpFinanciera = this.guardarScoreCliente(oScoreJornalero.oExpFinanciera);
            oScoreJornalero.oReferencias.idScoreJornalero = nId;
            oScoreJornalero.oReferencias = this.guardarScoreCliente(oScoreJornalero.oReferencias);
            oScoreJornalero.oEstadoCivil.idScoreJornalero = nId;
            oScoreJornalero.oEstadoCivil = this.guardarScoreCliente(oScoreJornalero.oEstadoCivil);
            oScoreJornalero.oTiempoResidencia.idScoreJornalero = nId;
            oScoreJornalero.oTiempoResidencia = this.guardarScoreCliente(oScoreJornalero.oTiempoResidencia);
            oScoreJornalero.oVivienda.idScoreJornalero = nId;
            oScoreJornalero.oVivienda = this.guardarScoreCliente(oScoreJornalero.oVivienda);
            oScoreJornalero.oEstadoVivienda.idScoreJornalero = nId;
            oScoreJornalero.oEstadoVivienda = this.guardarScoreCliente(oScoreJornalero.oEstadoVivienda);
            oScoreJornalero.oRespaldo.idScoreJornalero = nId;
            oScoreJornalero.oRespaldo = this.guardarScoreCliente(oScoreJornalero.oRespaldo);
            oScoreJornalero.oEdad.idScoreJornalero = nId;
            oScoreJornalero.oEdad = this.guardarScoreCliente(oScoreJornalero.oEdad);

            /** Guardar las referencias **/
            foreach (DataRow oRow in oScoreJornalero.dtReferencias.Rows)
            {
                DataTable dtResultado = this.guardarReferencias(
                        oScoreJornalero.idScoreJornalero,
                        Convert.ToString(oRow["cNombre"]),
                        Convert.ToString(oRow["cDireccion"]),
                        Convert.ToString(oRow["cTelefono"]),
                        Convert.ToInt32(oRow["idTipVinculoEval"]),
                        Convert.ToInt32(oRow["idTipoReferencia"]),
                        Convert.ToBoolean(oRow["lVigente"]),
                        Convert.ToInt32(oRow["idReferencia"])
                    );
                oRow["idReferencia"] = Convert.ToInt32(dtResultado.Rows[0]["id"]);
            }
            
            return oScoreJornalero;
        }
        public DataTable guardarReferencias(
            int idScoreJornalero, string cNombre, string cDireccion, string cTelefono, int idTipVinculoEval, int idTipoReferencia, bool lVigente, int idReferencia)
        {
            return this.objEjeSp.EjecSP("CRE_CreJorInsertarReferencias_SP", 
                idScoreJornalero,
                cNombre,
                cDireccion,
                cTelefono,
                idTipVinculoEval,
                idTipoReferencia,
                lVigente,
                idReferencia
                );
        }
        public DataSet listaTipoVinculos()
        {
            return this.objEjeSp.DSEjecSP("CRE_CreJorListaVinculos_SP");
        }

        public DataSet listaVariablesCliente(int idCli) 
        {
            return this.objEjeSp.DSEjecSP("CRE_CreJorVariablesRechazoAut_SP", idCli);
        }
    }
}
