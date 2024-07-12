using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNGenVariables
    {
        clsADGenVariables objVar = new clsADGenVariables();

        //=============================================================
        // Crear Metodo para Validar Inicio de Operaciones
        //=============================================================
        public string RetornaVariable(string cVar, int idAge)
        {
            string cValvar;
            try
            {
                DataTable tbVar = objVar.RetValVar(cVar, idAge);
                cValvar = tbVar.Rows[0]["cValVar"].ToString();
                // Si variable es: dFechaAct --> retorna Fecha del ssistema
            }
            catch (Exception e)
            {
                cValvar = e.Message;
            }
            return cValvar;
        }
        //=============================================================
        // Actualiza el Saldo
        //=============================================================
        public int ActualizarSaldo(int idAgencia, int idUsuario, DateTime dfechaOpe, int idTipoMoneda, int IdTipoTransac_I_E, decimal nMontoOperacion)
        {
            int nRespuesta=0;
            try
            {
                DataTable dtActSal = objVar.ActualizarSaldo(idAgencia, idUsuario, dfechaOpe, idTipoMoneda, IdTipoTransac_I_E, nMontoOperacion);
                nRespuesta = Convert.ToInt32(dtActSal.Rows[0]["nRespuesta"]);
            }
            catch (Exception e)
            {            
              nRespuesta = 0;
            }
            return nRespuesta;
        }
        //=============================================================
        // Actualiza el Saldo
        //=============================================================
        public void ActualizarSaldoHabilitacion(int idAgencia, int idUsuarioOri, int idUsuarioDes, DateTime dfechaOpe, int idTipoMoneda, decimal nMontoOperacion, string idHabBovIngEgre)
        {
            try
            {
                objVar.ActualizarSaldoHabilitacion(idAgencia, idUsuarioOri, idUsuarioDes, dfechaOpe, idTipoMoneda, nMontoOperacion, idHabBovIngEgre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
