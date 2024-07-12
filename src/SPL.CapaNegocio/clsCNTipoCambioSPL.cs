using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNTipoCambioSPL
    {
        clsADTipoCambioSPL objTiCa = new clsADTipoCambioSPL();
        public DataTable ListarTipoCambio(int tipo)                 
        {            
            return objTiCa.listarTipoCambio(tipo);
        }

        public void insertarTipoCambioSPL(DateTime dFecIni, DateTime dFecFin, Decimal nTipoCambio) 
        {
            objTiCa.insertarTipoCambioSplaft(dFecIni, dFecFin, nTipoCambio);
        } 

        public void actualizarTipoCambioSPL(int idTipoCambio, Decimal nTipoCambio) 
        {
            objTiCa.actualizarTipoCambioSPL(idTipoCambio, nTipoCambio);
        } 
    }
}
