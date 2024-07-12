using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADGenVariables
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=============================================================
        //--Retorna el Valor de la Variable Indicada
        //=============================================================
        public DataTable RetValVar(string idVar, int idAge)
        {
            return objEjeSp.EjecSP("Gen_RetVariable_Sp", idVar, idAge);
        }
        //=============================================================
        //--Actualiza los saldos del Operador
        //=============================================================
        public DataTable ActualizarSaldo(int idAgencia, int idUsuario, DateTime dfechaOpe, int idTipoMoneda, int IdTipoTransac_I_E, decimal nMontoOperacion)
        {
           return objEjeSp.EjecSP("Gen_MonitoreoSaldo_sp", idAgencia, idUsuario, dfechaOpe, idTipoMoneda, IdTipoTransac_I_E, nMontoOperacion);
        }
        //=============================================================
        //--Actualiza los saldos de los operadores de Habilitaciones
        //=============================================================
        public void ActualizarSaldoHabilitacion(int idAgencia, int idUsuarioOri, int idUsuarioDes, DateTime dfechaOpe, int idTipoMoneda, decimal nMontoOperacion, string idHabBovIngEgre)
        {
            objEjeSp.EjecSP("Gen_MonitoreoSaldoHab_sp", idAgencia, idUsuarioOri, idUsuarioDes, dfechaOpe, idTipoMoneda,
                nMontoOperacion, idHabBovIngEgre);
        }
    }
}
