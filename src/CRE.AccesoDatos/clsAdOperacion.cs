using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsAdOperacion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        /// <summary>
        /// Retorna datos de la una operacion realizada segun el kardex
        /// </summary>
        /// <param name="nNumKardex">id del kardex a buscar</param>
        /// <returns>Datos de la operacion</returns>
        public DataTable ADdtOPeracion(int nNumKardex)
        {            
            return objEjeSp.EjecSP("CRE_BusKardex_SP", nNumKardex);
        }

        /*
        public DataTable ADdtExtornaOpe(int nNumKardex, DateTime dFechExtorno, Int32 nIdUsuario, Int32 nIdMotivoExt, string cObsExt)
        {
            
            return objEjeSp.EjecSP("CRE_ExtornaRegCobro_SP", nNumKardex, dFechExtorno, nIdUsuario, nIdMotivoExt, cObsExt);
        }
         */
        public DataTable ADdtExtornaOpe(int nNumKardex, DateTime dFechExtorno, Int32 nIdUsuario,
                                        bool lModificaSaldoLinea, bool lKardexRelacionado, int idTipoTransac, int nIdAgencia, int idMoneda, decimal nMontoExtorno)
        {
            return objEjeSp.EjecSP("CRE_ExtornaRegCobro_SP", nNumKardex, dFechExtorno, nIdUsuario,
                                                             lModificaSaldoLinea, lKardexRelacionado, idTipoTransac, nIdAgencia, idMoneda, nMontoExtorno);
        }

        /// <summary>
        /// realiza el extorno de una operacion de prepago
        /// </summary>
        /// <param name="nNumKardex">numero de kardex a extornar</param>
        /// <param name="dFechExtorno">fecha de extorno</param>
        /// <param name="nIdUsuario">id del usuario que extorna</param>
        /// <param name="nIdMotivoExt">id del motivo de extorno</param>
        /// <param name="cObsExt">descripcion de las observaciones</param>
        /// <returns>retorna el id del kardex de extorno</returns>
        public int extornarPrePago(int nNumKardex, DateTime dFechExtorno, int nIdUsuario,
                                    bool lModificaSaldoLinea, int idTipoTransac, int nIdAgencia, int idMoneda, decimal nMontoExtorno)
        {
            return (int)objEjeSp.EjecSP("CRE_ExtornaPrePago_SP", nNumKardex, dFechExtorno, nIdUsuario,
                                                                 lModificaSaldoLinea, idTipoTransac, nIdAgencia, idMoneda, nMontoExtorno).Rows[0][0];
        }

        public DataTable ADRecuperarPlanPagosValidarExtorno(int idKardex)
        {
            return objEjeSp.EjecSP("CRE_RecuperarPlanPagosValidarExtorno_SP", idKardex);
        }

        public DataTable ADRecuperaDatosRelOperacion(int idKardex)
        {
            return objEjeSp.EjecSP("CRE_RecuperarDatosRelOperacion_SP", idKardex);
        }
    }
}
