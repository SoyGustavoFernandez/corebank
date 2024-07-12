using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADDireccion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        private clsDireccionCliente DataTableRowToDireccion(DataTable dtDireccion)
        {
            clsDireccionCliente direccion = new clsDireccionCliente();            
            if (dtDireccion.Rows.Count > 0)
            {
                string idDireccion = dtDireccion.Rows[0]["idDireccion"].ToString();
                direccion.idDireccion = string.IsNullOrEmpty(idDireccion) ? 0 : Int32.Parse(idDireccion);
                string idSector = dtDireccion.Rows[0]["idSector"].ToString();
                direccion.idSector = string.IsNullOrEmpty(idSector) ? 0 : Int32.Parse(idSector);
                string idTipoVivienda = dtDireccion.Rows[0]["idTipoVivienda"].ToString();
                direccion.idTipoVivienda = string.IsNullOrEmpty(idTipoVivienda) ? 0 : Int32.Parse(idTipoVivienda);
                string idTipoConstruccion = dtDireccion.Rows[0]["idTipoConstruccion"].ToString();
                direccion.idTipoConstruccion = string.IsNullOrEmpty(idTipoConstruccion) ? 0 : Int32.Parse(idTipoConstruccion);
                string nAñoReside = dtDireccion.Rows[0]["nAñoReside"].ToString();
                direccion.nAñoReside = string.IsNullOrEmpty(nAñoReside) ? 0 : Int32.Parse(nAñoReside);
                //foreach (var prop in direccion.GetType().GetProperties())
                //{
                //    direccion.GetType().GetProperty(prop.Name).SetValue(dtDireccion.Rows[0][prop.Name], null);
                //}                
            }
            return direccion;        
        }

        public clsDireccionCliente recuperarDireccion (int idDireccion)
        {            
            DataTable dtDireccion = objEjeSp.EjecSP("", idDireccion);
            return DataTableRowToDireccion(dtDireccion);
        }

        public clsDireccionCliente recuperarDireccion(int idCli, int idTipoDireccion)
        {
            DataTable dtDireccion = objEjeSp.EjecSP("GEN_RecuperaDirPrincipal_SP", idCli, idTipoDireccion);
            return DataTableRowToDireccion(dtDireccion);
        }
    }
}
