using EntityLayer;
using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNEvalCred
    {
        clsADEvalCred objADEvalCred = new clsADEvalCred();
        public List<clsEvalCredComite> CNGetEvalCredCli(int idCli, DateTime dFecIni, DateTime dFecFin,
                                                        decimal nMontoMin, decimal nMontoMax, int idMoneda,
                                                        int idAgencia, int idPerfil, int idUsuario, int nModo=0, int idCanalAproCred=1)
        {
            return new clsADEvalCred().ADGetEvalCredCli(idCli, dFecIni, dFecFin, nMontoMin, nMontoMax, idMoneda,
                                                        idAgencia, idPerfil, idUsuario, nModo, idCanalAproCred);
        }

        public clsEvalCredComite CNGetEvalCredSolCred(int idSolicitud)
        {
            return new clsADEvalCred().ADGetEvalCredSolCred(idSolicitud);
        }

        public clsDBResp CNDevolverEvalCred(string xmlEvalCred)
        {
            int idUsuario = clsVarGlobal.User.idUsuario;
            return new clsADEvalCred().ADDevolverEvalCred(xmlEvalCred, idUsuario);
        }

        public DataTable CNListarCultivo()
        {
            return new clsADEvalCred().ADListarCultivo();
        }

        public DataTable CNListarVariedadPorCultivo(int idCultivoEval)
        {
            return new clsADEvalCred().ADListarVariedadPorCultivo(idCultivoEval);
        }

        public DataTable obtenerZonaAgencia(int idAgencia)
        {
            return this.objADEvalCred.obtenerZonaAgencia(idAgencia);
        }
        public DataTable listarTipDestCred(int idTipDestCred, int idPadre)
        {
            return this.objADEvalCred.listarTipDestCred(idTipDestCred, idPadre);
        }
        public DataTable listarUnidadProductiva()
        {
            return this.objADEvalCred.listarUnidadProductiva();
        }

        public DataTable listarTipoEvaluacion(int idClase)
        {
            return this.objADEvalCred.listarTipoEvaluacion(idClase);
        }
        public DataTable ListarProductosPorTipoEvaluacion(int idTipEvalCred)
        {
            return this.objADEvalCred.ListarProductosPorTipoEvaluacion(idTipEvalCred);
        }

        public DataTable GuardarProductosOpinionRiesgosEvalResumida(string xmlProductosOpinionRiesgos ,  int idUsuarioMod , DateTime dFechaSistema )
        {
            return this.objADEvalCred.GuardarProductosOpinionRiesgosEvalResumida(xmlProductosOpinionRiesgos ,   idUsuarioMod ,  dFechaSistema );
        }

        public DataTable dtCultivoMatriz(int idRegistroMatriz, int idAgencia)
        {
            return this.objADEvalCred.dtCultivoMatriz(idRegistroMatriz, idAgencia);
        }

        public DataTable dtVariedadCultivoMatriz(int idRegistroMatriz, int idAgencia, int idCultivo)
        {
            return this.objADEvalCred.dtVariedadCultivoMatriz(idRegistroMatriz, idAgencia, idCultivo);
        }

        public DataTable dtTipoCultivoMatriz(int idRegistroMatriz, int idAgencia, int idCultivo, int idVariedadCultivo)
        {
            return this.objADEvalCred.dtTipoCultivoMatriz(idRegistroMatriz, idAgencia, idCultivo, idVariedadCultivo);
        }

        public DataTable dtTipoFinanciamientoMatriz(int idRegistroMatriz, int idAgencia, int idCultivo, int idVariedadCultivo)
        {
            return this.objADEvalCred.dtTipoFinanciamientoMatriz(idRegistroMatriz, idAgencia, idCultivo, idVariedadCultivo);
        }

        public DataTable dtUnidadMedidaMatriz(int idRegistroMatriz, int idAgencia, int idCultivo, int idVariedadCultivo, int idTipoCultivo, int idTipoFinanciamiento)
        {
            return this.objADEvalCred.dtUnidadMedidaMatriz(idRegistroMatriz, idAgencia, idCultivo, idVariedadCultivo, idTipoCultivo, idTipoFinanciamiento);
        }
    }
}
