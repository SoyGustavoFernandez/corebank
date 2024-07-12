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
    public class clsCNSYEvaluacionCualitativa
    {
        private clsADSYEvaluacion ObjADSYEvaluacion = new clsADSYEvaluacion();

        public clsSYEvaluacion CNSYObtenerSolicitudBase(int idEvalCred)
        {
            DataTable res = this.ObjADSYEvaluacion.ADSYObtenerEvaluacionBase(idEvalCred);
            return res.Rows[0].ToObject<clsSYEvaluacion>();
        }
    }
}
