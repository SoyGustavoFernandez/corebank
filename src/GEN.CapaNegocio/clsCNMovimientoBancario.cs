using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;
namespace GEN.CapaNegocio
{
    public class clsCNMovimientoBancario
    {
        public DataTable ListarTipoCuentaBco()
        {
            try
            {
            return new clsADMovimientoBancario().ListarTipoCuentaBco();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ListarMedioPagoSunat()
        {
            try
            {
                return new clsADMovimientoBancario().ListarMedioPagoSunat();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ListarMotOperacionBco(int idPadreMotivo)
        {
            try
            {
                return new clsADMovimientoBancario().ListarMotOperacionBco(idPadreMotivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ListarTipoDestino()
        {
            try
            {
                return new clsADMovimientoBancario().ListarTipoDestino();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
