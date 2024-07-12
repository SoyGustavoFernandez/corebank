using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADMantenimientoCanales
    {
        public DataTable ListaMantenimientoCanales(int idTipoList)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_ListarCanalVendedor_SP", idTipoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListaMantenimientoVendedores(int idTipoList, int idCanal, int idAgencia = 0)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_ListarVendedor_SP", idTipoList, idCanal, idAgencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RegistrarCanal(int idCanal, string cDescripcion, bool lInterno, bool lActivo, bool lVigente)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_RegOrUpCanalVendedores_SP", idCanal, cDescripcion, lInterno, lActivo, lVigente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RegistrarVendedores(int idVendedor, int idCanal, int idUsuario, string cNombreVendedor, int idRegion, int idOficina, string cNombreCorto, bool lActivo, bool lVigente)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_RegOrUpVendedores_SP", idVendedor, idCanal, idUsuario, cNombreVendedor, idRegion, idOficina, cNombreCorto, lActivo, lVigente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
