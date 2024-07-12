using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNMotivoOpeBanco
    {
        clsADMotivoOpeBanco ObjMovBancos = new clsADMotivoOpeBanco();

        //CARGAR LOS TIPOS DE OPERACION DE BANCOS
        public DataTable CNListarMovBancos()
        {
            return ObjMovBancos.ADListarMovBancos();
        }
        //CARGAR LOS MOTIVOS DE OPERACION SEGUN TIPO DE OPERACION
        public DataTable CNListarOperaciones(int idMotOpeBanco)
        {
            return ObjMovBancos.ADListarOperaciones(idMotOpeBanco);
        }
        //INSERTAR O MODIFICAR MOTIVO DE OPERACION DE BANCOS
        public int CNActualizaOpeBancos(int idMotOpeBanco, string cDescripcion, int idTipoOpepadre,
                                               int lVigente, string TipoOpe)
        {
            DataTable dtResultado = ObjMovBancos.ADActualizaOpeBancos(idMotOpeBanco, cDescripcion, idTipoOpepadre, lVigente, TipoOpe);
            int idConcpRec = 0;
            return idConcpRec = Convert.ToInt32(dtResultado.Rows[0][0]);
 
        }
    }
}
