using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNPersonal
    {
        public clsADPersonal objPersonal = new clsADPersonal();
        public DataTable ListaPersonal(int idAgencia)
        {
            return objPersonal.ADListaPersonal(idAgencia);
        }

        //lista al Personal por agencia y area
        public DataTable CNListaPersonalxArea(int idAgencia, int idArea)
        {
            return objPersonal.ADListaPersonalxArea(idAgencia, idArea);
        }

        //lista al Personal por idusuario
        public DataTable CNBuscaPersonal(int idUsuario)
        {
            return objPersonal.ADBuscaPersonal(idUsuario);
        }

        public DataTable ListaPersonalCargo(string cVariable, int idAgencia)
        {
            return objPersonal.ListaPersonalCargo(cVariable, idAgencia);
        }

        public DataTable listarNuevoPersonal(DateTime dFecha)
        {
            return this.objPersonal.listarNuevoPersonal(dFecha);
        }

        public DataTable listarCumpleaPersonal(DateTime dFecha)
        {
            return this.objPersonal.listarCumpleaPersonal(dFecha);
        }
    }
}
