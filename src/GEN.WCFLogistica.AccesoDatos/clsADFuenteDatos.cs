using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.WCFLogistica.AccesoDatos
{
    public class clsADFuenteDatos
    {
        private IntConexion objEjeSp;

        public clsADFuenteDatos()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }

        public DataTable obtenerVariable(params object[] parametros)
        {            
            return this.objEjeSp.EjecSP("ADM_ObtenerVariable_SP", parametros);
        }

        public DataTable buscarProveedor(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("GEN_RetornaDatosProveedor_SP", parametros);
        }

        public DataTable obtenerConceptosRecibo(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CAJ_ListaConcepPer_Sp", parametros);
        }

        public DataTable obtenerConfigTipoComprobante(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("Caj_RetConfigTipoComp_Sp", parametros);
        }     
    }
}
