using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data; 

namespace GEN.AccesoDatos
{
    public class clsADTarifario
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaTarifas(String TipFiltro, int filtro)
        {
            return objEjeSp.EjecSP("Gen_ListaTasas_Sp", TipFiltro, filtro);
        }
        public DataTable  ListaTarifasConfigurables(String TipFiltro, int filtro)
        {
            return objEjeSp.EjecSP("Gen_ListaTasasConfigurables_Sp", TipFiltro, filtro);
        }
        public DataTable RetDatosprod(int idproduc)
        {
            return objEjeSp.EjecSP("ADM_DatosProducto_SP", idproduc);
        }
              
       
        public DataTable ActualizarTar(String XMLActTarif)
        {
            return objEjeSp.EjecSP("ADM_ActTasas_Sp", XMLActTarif);

        }
        /// <summary>
        /// Se agregá el campo idTipoTasaCredito
        /// </summary>
        /// <param name="TasaMor"></param>
        /// <param name="TasaCom"></param>
        /// <param name="TasaComMax"></param>
        /// <param name="idProducto"></param>
        /// <param name="idAgencia"></param>
        /// <param name="idMoneda"></param>
        /// <param name="idTipPersona"></param>
        /// <param name="idMonto"></param>
        /// <param name="idPlazo"></param>
        /// <param name="idTipoTasaCredito"></param>
        /// <returns></returns>
        public DataTable GuardarTar(Decimal TasaMor, Decimal TasaCom,Decimal TasaComMax, 
                                int idProducto, int idAgencia, int idMoneda, int idTipPersona, int idMonto, int idPlazo,int idTipoTasaCredito)
        {
            return objEjeSp.EjecSP("ADM_GuardarTasas_Sp", TasaMor, TasaCom, TasaComMax,
                                                   idProducto, idAgencia, idMoneda, idTipPersona, idMonto, idPlazo, idTipoTasaCredito);

        }
        public DataTable ValidarDup(int idProducto, int idAgencia, int idMoneda, int idTipPersona, int idMonto, int idPlazo)
        {

            return objEjeSp.EjecSP("ADM_TasasProdDup_Sp", idProducto, idAgencia, idMoneda, idTipPersona, idMonto, idPlazo);
        }
        
        public DataTable GuardarTarifasX(string xmlTarifas)
        {
            return objEjeSp.EjecSP("ADM_GuardarTarifas_SP", xmlTarifas);
        }

        public DataTable RetornaTarifasDupX(string xmlTarifasDup)
        {
            return objEjeSp.EjecSP("ADM_RetornaTarifasDup_SP", xmlTarifasDup);
        }
    }
}
