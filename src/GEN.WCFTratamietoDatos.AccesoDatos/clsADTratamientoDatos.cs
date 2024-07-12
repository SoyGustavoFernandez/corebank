using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.WCFTratamietoDatos.AccesoDatos
{
    public class clsADTratamientoDatos
    {
        private IntConexion objEjeSp;

        public clsADTratamientoDatos()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }

        #region Tipo Autorización

        public DataTable listarTipoAutorizacion(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaTipAutTraDatos_SP");
        }
        public DataTable InsertarTipoAutorizacion(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_InsTipoAutTraDatos_SP", parametros);
        }
        public DataTable ActualizarTipoAutorizacion(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_UpdTipoAutTraDatos_SP", parametros);
        }
        #endregion

        #region Autorización tratamiento uso de datos

        public DataTable listarAutoUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaAutTraDatos_SP", parametros);
        }
        public DataTable listarValidacionAutoUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaValAutTraDatos_SP", parametros);
        }
        public DataTable listarMantAutUsoTraDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaManAutTraDatos_SP", parametros);
        }
        public DataTable listarReporteAutoUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaRptAutTraDatos_SP", parametros);
        }
        public DataTable listarHistoricoAutTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaHisAutTraDatos_SP", parametros);
        }
        public DataTable ObtenerDocAutTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ObtieneArchivoAutTraDatos_SP", parametros);
        }
        public DataTable InsertarAutUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_InsAutTraDatos_SP", parametros);
        }
        public DataTable ActualizarAutUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_UpdAutTraDatos_SP", parametros);
        }
        public DataTable QuitarAutUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_UpdEstAutTraDatos_SP", parametros);
        }
        #endregion


        #region Autorización tratamiento uso de datos

    
        public DataTable listarAutoUsoTratamientoDatosDesistimiento(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_ListaSolDesistimientoTipAutTraDatos_SP", parametros);
        }
        public DataTable InsertarSolicitudAutUsoTratamientoDatos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("TDP_InsSolDesistimientoAutTraDatos_SP", parametros);
        } 
        #endregion

    }
}
