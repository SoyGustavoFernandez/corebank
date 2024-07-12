using PRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.CapaNegocio
{
    public class clsCNPeriodos
    {

        clsADPeriodos clsadperiodo = new clsADPeriodos();

        public DataTable listarPeriodosTodos()
        {
            return clsadperiodo.ListarPeriodosTodos();
        }
        //--obtiene un periodo X id-- //
        public DataTable PeriodosPresupuesto(int idPeriodo)
        {
            return clsadperiodo.PeriodoPresupuestal(idPeriodo);
        }

        //-- INSERTAR NUEVO PERIODO --//
        public DataTable InsertarPeriodo(int idPeriodo, string cPeriodo, int idEstado, int idUsu, DateTime dFecha)
        {
            return clsadperiodo.InsertarPeriodo(idPeriodo, cPeriodo, idEstado, idUsu, dFecha);
        } 
        //===================================================================================
        //= VERIFICA CONCISTENCIA DE VALORES DE PARTIDAS
        public DataTable VerificaConsistenciaPresupuesto(int idPeriodo)
        {
            return clsadperiodo.VerificaConsistenciaPresupuesto(idPeriodo);
        }
    }
}
