using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADPersonal
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaPersonal(int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListaPersonal_sp", idAgencia);
        }

        //lista al Personal por agencia y area
        public DataTable ADListaPersonalxArea(int idAgencia, int idArea)
        {
            return objEjeSp.EjecSP("LOG_ListaPersonalxArea_SP", idAgencia, idArea);
        }

        //lista al Personal por idusuario
        public DataTable ADBuscaPersonal(int idUsuario)
        {
            return objEjeSp.EjecSP("Gen_BusPersonalxCod_sp", idUsuario);
        }

        /// <summary>
        /// Lista personal segun el cargo que requiera
        /// </summary>
        /// <param name="cVariable"></param>
        /// <param name="idAgencia"></param>
        /// <returns></returns>
        public DataTable ListaPersonalCargo(string cVariable, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListaPersonalCargo_sp", cVariable,idAgencia);
        }

        public DataTable listarNuevoPersonal(DateTime dFecha)
        {
            return this.objEjeSp.EjecSP("GRH_ListarNuevoPersonal_SP", dFecha);
        }

        public DataTable listarCumpleaPersonal(DateTime dFecha)
        {
            return this.objEjeSp.EjecSP("GRH_ListarCumpleaPersonal_SP", dFecha);
        }
    }
}
