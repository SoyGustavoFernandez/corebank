using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
   public class clsCNGuardarFeriado
    {
       clsADGuardarFeriado objGuardarFe = new clsADGuardarFeriado();

       public void GuardarFeriados(string XMLFeriado, int idUsuario) 
        {
            objGuardarFe.GuardarFeriados(XMLFeriado, idUsuario);
        }

        public DataTable LisFeriados(int TipoFeriado,int idAgencia)
        {
            return objGuardarFe.LisFeriados(TipoFeriado,idAgencia);
        }

      
    }
}
