using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNOperacion
    {
        public clsAdOperacion ObjOperacion = new clsAdOperacion();

        public DataTable CNdtOperacion(int nNumKardex)
        {
            return ObjOperacion.ADdtOPeracion(nNumKardex);
        }

        /*
        public DataTable CNdtExtornaOpe(int nNumKardex, DateTime dFechExtorno, Int32 nIdUsuario, Int32 nIdMotivoExt, string cObsExt )
        {
            return ObjOperacion.ADdtExtornaOpe(nNumKardex, dFechExtorno, nIdUsuario, nIdMotivoExt, cObsExt);
        }
        */

        public DataTable CNdtExtornaOpe(int nNumKardex, DateTime dFechExtorno, Int32 nIdUsuario,
                                        bool lModificaSaldoLinea, bool lKardexRelacionado, int idTipoTransac, int nIdAgencia, int idMoneda, decimal nMontoExtorno)
        {
            return ObjOperacion.ADdtExtornaOpe(nNumKardex, dFechExtorno, nIdUsuario,
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
            return ObjOperacion.extornarPrePago(nNumKardex, dFechExtorno, nIdUsuario,
                                                lModificaSaldoLinea, idTipoTransac, nIdAgencia, idMoneda, nMontoExtorno);
        }

        public DataTable CNRecuperarPlanPagosValidarExtorno(int idKardex)
        {
            return ObjOperacion.ADRecuperarPlanPagosValidarExtorno(idKardex);
        }

        public DataTable CNRecuperaDatosRelOperacion(int idKardex)
        {
            return ObjOperacion.ADRecuperaDatosRelOperacion(idKardex);
        }
    }
}
