using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using EntityLayer.Soyuz.Creditos.OtorgamientoCredito.Evaluacion;
using CRE.AccesoDatos.Soyuz.OtorgamientoCredito;

namespace CRE.CapaNegocio.Soyuz.OtorgamientoCredito.Evaluacion
{
    public class clsCNSYEvaluacion
    {
        private clsADSYEvaluacion ObjADSYEvaluacion = new clsADSYEvaluacion();

        public clsSYEvaluacion CNSYObtenerEvaluacionBase(int idEvalCred)
        {
            DataTable res = this.ObjADSYEvaluacion.ADSYObtenerEvaluacionBase(idEvalCred);
            return res.Rows[0].ToObject<clsSYEvaluacion>();
        }

        public IList<clsSYItemEvaluacionCualitativa> CNSYObtenerEvaluacionCualitativa(int idEvalCred)
        {
            DataTable res = this.ObjADSYEvaluacion.ADSYObtenerEvaluacionCualitativa(idEvalCred);
            return res.SoftToList<clsSYItemEvaluacionCualitativa>();
        }

        public DataTable CNSYActualizarEvaluacionCualitativa(int idEvalCred, List<clsSYItemEvaluacionCualitativa> lstItemsEvalCualit)
        {            
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCualitativa", typeof(int));
            dt.Columns.Add("idItemCualit", typeof(int));
            dt.Columns.Add("nPuntaje", typeof(decimal));
            dt.Columns.Add("nComputado", typeof(decimal));
            dt.Columns.Add("lAutomatico", typeof(bool));

            foreach (clsSYItemEvaluacionCualitativa obj in lstItemsEvalCualit)
            {
                dt.Rows.Add(
                    obj.idEvalCualitativa,
                    obj.idItemCualit,
                    Convert.ToDecimal(obj.nPuntaje),
                    obj.nComputado,
                    obj.lAutomatico
                );
            }
            string xmlItemsEvalCred = clsUtils.ConvertToXML(dt.Copy(), "EvalCualitativa", "Item");
            DataTable res = this.ObjADSYEvaluacion.ADSYActualizarEvaluacionCualitativa(idEvalCred, xmlItemsEvalCred);
            return res;
        }

        public clsSYResEvalCredBase CNSYVerificarExistenciaEvaluacion(int idSolicitud)
        {
            DataTable res = this.ObjADSYEvaluacion.ADSYVerificarExistenciaEvaluacion(idSolicitud);
            var objRes = new clsSYResEvalCredBase();
            objRes.idMensaje = Convert.ToInt32(res.Rows[0]["idMensaje"]);
            objRes.cMensaje = Convert.ToString(res.Rows[0]["cMensaje"]);
            objRes.idSolicitud = Convert.ToInt32(res.Rows[0]["idSolicitud"]);
            objRes.idEvalCred = Convert.ToInt32(res.Rows[0]["idEvalCred"]);
            objRes.idTipEvalCred = Convert.ToInt32(res.Rows[0]["idTipEvalCred"]);
            return objRes;
        }
    }
}
