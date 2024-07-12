using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;


namespace GEN.AccesoDatos
{
      public class clsADGuardarFeriado
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void GuardarFeriados(string XMLFeriado, int idUsuario)
        {
            objEjeSp.EjecSP("Gen_GuardarFeriado_sp", XMLFeriado, idUsuario);

        }

        public DataTable LisFeriados(int TipoFeriado, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_LisTotalFeriados_SP", TipoFeriado, idAgencia);
        }

    }
}
