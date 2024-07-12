using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;


namespace GEN.CapaNegocio
{
    public class clsCNEstadoCredito
    {
        public clsADEstadoCredito ListaEstadoCre = new clsADEstadoCredito();

        public DataTable ListarEstado(Int32 nEstadoCredito)
        {
            return ListaEstadoCre.ListarEstadoCredito(nEstadoCredito);
        }

        public DataTable ListaEstCre(Int32 nCodEstado)
        {
            return ListaEstadoCre.ListaEstCredito(nCodEstado);
        }

        public DataTable ListarEstadoActual(Int32 nEstadoActual)
        {
            //return ListaEstadoCre.ListarEstadoActual(nEstadoActual);
            var dt = ListaEstadoCre.ListarEstadoActualXml();

            DataTable dtEstadoCreditoActual = dt.Clone();

            (from item in dt.AsEnumerable()
             where (int)item["IdEstado"] == nEstadoActual
             select item).CopyToDataTable(dtEstadoCreditoActual, LoadOption.OverwriteChanges);

            return dtEstadoCreditoActual;
        }



        public DataTable CNEstadoBusqueda(string cEstado)
        {
            return ListaEstadoCre.ADEstadoBusqueda(cEstado);
        }

        public DataTable retornarTodosEstado()
        {
           return ListaEstadoCre.ListarEstadoActualXml();
        }

        public DataTable CNListarEstadoSolCredito(int idEstadoPadre)
        {
            return ListaEstadoCre.ADListarEstadoSolCredito(idEstadoPadre);
        }
    }
}
