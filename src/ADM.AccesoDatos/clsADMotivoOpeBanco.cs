using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADMotivoOpeBanco
    {
        clsGENEjeSP ObjEjSp = new clsGENEjeSP();

        //CARGAR LOS TIPOS DE OPERACION DE BANCOS
        public DataTable ADListarMovBancos()
        {
            return ObjEjSp.EjecSP("ADM_ListarMovBancos_SP");
        }

        //CARGAR LOS MOTIVOS DE OPERACION SEGUN TIPO DE OPERACION
        public DataTable ADListarOperaciones(int idMotOpeBanco)
        {
            return ObjEjSp.EjecSP("ADM_ListarTipOpeBancos_SP", idMotOpeBanco);
        }

        //INSERTAR O MODIFICAR MOTIVO DE OPERACION DE BANCOS
        public DataTable ADActualizaOpeBancos(int idMotOpeBanco, string cDescripcion, int idTipoOpepadre, int lVigente, string TipoOpe)
        {
            return ObjEjSp.EjecSP("ADM_ActualizaTipOpeBancos_SP", idMotOpeBanco, cDescripcion, idTipoOpepadre, lVigente, TipoOpe);
 
        }
    }
}
