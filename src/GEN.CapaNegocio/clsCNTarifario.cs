using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTarifario
    {
        clsADTarifario objTasas = new clsADTarifario();

        // Crear metodo para recibir datos en un datatable
        public DataTable ListaTarifas(String TipFiltro,int filtro)
        {
            return objTasas.ListaTarifas(TipFiltro, filtro);
        }

        public DataTable ListaTarifasConfigurables(String TipFiltro, int filtro)
        {
            return objTasas.ListaTarifasConfigurables(TipFiltro, filtro);
        }

        public DataTable RetDatosProducto(int idproduc)
        {
            return objTasas.RetDatosprod(idproduc);
        }

        
        public DataTable ActualizarTar(String XMLActTarif)
        {
            return objTasas.ActualizarTar(XMLActTarif);

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
        public int GuardarTar(Decimal TasaMor, Decimal TasaCom, Decimal TasaComMax, int idProducto, int idAgencia, int idMoneda, int idTipPersona, int idMonto, int idPlazo, int idTipoTasaCredito)
        {
            DataTable tbIDTasa = objTasas.GuardarTar(TasaMor, TasaCom, TasaComMax, idProducto, idAgencia, idMoneda, idTipPersona, idMonto, idPlazo, idTipoTasaCredito);
            int NuevoId = Convert.ToInt32(tbIDTasa.Rows[0][0]);
            return NuevoId;

        }
        public DataTable ControlDuplicidad(int idProducto, int idAgencia, int idMoneda, int idTipPersona, int idMonto, int idPlazo)
        {
            return objTasas.ValidarDup(idProducto, idAgencia, idMoneda, idTipPersona, idMonto, idPlazo);
        }

        public DataTable GuardarTarifasX(string xmlTarifas)
        {
            return objTasas.GuardarTarifasX(xmlTarifas);
        }

        public DataTable RetornaTarifasDupX(string xmlTarifasDup)
        {
            return objTasas.RetornaTarifasDupX(xmlTarifasDup);
        }

    }
}
