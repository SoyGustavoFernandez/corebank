using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNBalanceEva
    {
        clsADBalanceEva objbalance = new clsADBalanceEva();

        public clsBalance retornarPlantilla(int idPlantilla)
        {
            return objbalance.retornarPlantilla(idPlantilla);
        }
    }

    public class clsCNBalanceFueIng
    {
        clsADBalanceFueIng objbalances = new clsADBalanceFueIng();

        public clslisBalanceFueIng retornarBalances(int idCli, int idClidFuente)
        {
            return objbalances.retornarBalances(idCli, idClidFuente);
        }

        public clslisDetalleBalance retornaDetallBalance(int idBalance)
        {
            return objbalances.retornaDetallBalance(idBalance);
        }
        public void insertarBalance(clsBalanceFueIng objBalance, clslisDetalleBalance detalleBalance)
        {
            objbalances.insertarBalance(objBalance, detalleBalance);
        }
    }
}
