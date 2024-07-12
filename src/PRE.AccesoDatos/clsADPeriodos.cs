using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.AccesoDatos
{
    public class clsADPeriodos
    {

        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarPeriodosTodos()
        {
            return objEjeSp.EjecSP("GEN_ListarPeriodosPresupuesto_SP", 0);
        }
        public DataTable PeriodoPresupuestal(int idPeriodo)
        {
            return objEjeSp.EjecSP("GEN_ListarPeriodosPresupuesto_SP", idPeriodo);
        }

        public DataTable InsertarPeriodo(int idPeriodo, string cPeriodo, int idEstado, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("PRE_InsertarPeriodoPres_SP", idPeriodo, cPeriodo, idEstado, idUsu, dFecha);
        }
        //===================================================================================
        //= VERIFICA CONCISTENCIA DE VALORES DE PARTIDAS
        public DataTable VerificaConsistenciaPresupuesto(int idPeriodo)
        {
            return objEjeSp.EjecSP("PRE_VerificaConsistenciaPresupuesto_SP", idPeriodo);
        }
    }
}
