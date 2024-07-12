using GEN.WCFTratamietoDatos.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.WCFTratamietoDatos.CapaNegocio
{
    public class clsCNTratamientoDatos
    {
        clsADTratamientoDatos adTratamientoDatos;

        public clsCNTratamientoDatos()
        {
            this.adTratamientoDatos = new clsADTratamientoDatos();
        } 
  
        #region Tipo Autorizacion

        public DataTable ListarTipoAutTratamientoUsoDatos(object parametros)
        {
            DataTable dtRespuesta= this.adTratamientoDatos.listarTipoAutorizacion(parametros);
            return dtRespuesta;
        }
        public DataTable InsertarTipoAutTratamientoUsoDatos(string dato)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.InsertarTipoAutorizacion(dato);
            return dtRespuesta;
        }
        public DataTable ActualizarTipoAutTratamientoUsoDatos(string dato)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.ActualizarTipoAutorizacion(dato);
            return dtRespuesta;
        }

        #endregion

        #region Autorización uso de datos

        public DataTable ListarAutTratamientoUsoDatos(string cNroDoc, int idEstado, int idTipoDoc)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarAutoUsoTratamientoDatos(cNroDoc, idEstado, idTipoDoc);
            return dtRespuesta;
        }
        public DataTable ListarValidacionAutoUsoTratamientoDatos(string cNroDoc, int idEstado, int idTipoDoc)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarValidacionAutoUsoTratamientoDatos(cNroDoc, idEstado, idTipoDoc);
            return dtRespuesta;
        }
        public DataTable ListarManAutTraUsoDatos(object parametros)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarMantAutUsoTraDatos(parametros);
            return dtRespuesta;
        }
        public DataTable ListarReporteAutTratamientoUsoDatos(object parametros)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarReporteAutoUsoTratamientoDatos(parametros);
            return dtRespuesta;
        }
        public DataTable ListarHisAutTratamientoUsoDatos(string cNroDoc, int idTipoDoc)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarHistoricoAutTratamientoDatos(cNroDoc, idTipoDoc);
            return dtRespuesta;
        }
        public DataTable ObtieneDocAutTratamientoUsoDatos(  int idDocumento)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.ObtenerDocAutTratamientoDatos( idDocumento);
            return dtRespuesta;
        }
        public DataTable InsertarAutTratamientoUsoDatos(string dato)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.InsertarAutUsoTratamientoDatos(dato);
            return dtRespuesta;
        }
        public DataTable ActualizarAutTratamientoUsoDatos(string dato)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.ActualizarAutUsoTratamientoDatos(dato);
            return dtRespuesta;
        }
        public DataTable QuitarAutTratamientoUsoDatos(string id, string usuario, string fecha)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.QuitarAutUsoTratamientoDatos(id, usuario, fecha);
            return dtRespuesta;
        }   
        #endregion

        #region Desistimiento de autorización uso de datos 
 
        public DataTable ListarAutTratamientoUsoDatosDesistimiento(string cNroDoc, int idEstado, int idTipoDoc)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.listarAutoUsoTratamientoDatosDesistimiento(cNroDoc, idEstado, idTipoDoc);
            return dtRespuesta;
        }
        public DataTable InsertarSolicitudAutTratamientoUsoDatos(string dato)
        {
            DataTable dtRespuesta = this.adTratamientoDatos.InsertarSolicitudAutUsoTratamientoDatos(dato);
            return dtRespuesta;
        } 
        #endregion


    }
}
