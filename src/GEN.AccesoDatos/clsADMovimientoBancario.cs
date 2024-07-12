using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;
namespace GEN.AccesoDatos
{
    public class clsADMovimientoBancario
    {
       
        public DataTable ListarTipoCuentaBco()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_ListaTipoCuentaBco_sp");
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
                return new clsGENEjeSP().EjecSP("GEN_ListaMedioPagoSunat_sp");
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
                return new clsGENEjeSP().EjecSP("GEN_ListaMotOperacionBco_sp", idPadreMotivo);
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
                return new clsGENEjeSP().EjecSP("GEN_ListaTipoDestino_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
