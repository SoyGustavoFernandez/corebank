using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNMantenimientoCanales
    {
        clsADMantenimientoCanales clsMantenimientoCanales = new clsADMantenimientoCanales();

        public DataTable ListaMantenimientoCanales(int idTipoList)
        {
            DataTable dtMantenimientoCanales = clsMantenimientoCanales.ListaMantenimientoCanales(idTipoList);
            return dtMantenimientoCanales;
        }

        public DataTable ListaMantenimientoVendedores(int idTipoList, int idCanal, int idAgencia = 0) {
            DataTable dtMantenimientoVendedores = clsMantenimientoCanales.ListaMantenimientoVendedores(idTipoList, idCanal, idAgencia);
            return dtMantenimientoVendedores;
        }

        public DataTable RegistrarCanal(int idCanal, string cDescripcion, bool lInterno, bool lActivo, bool lVigente)
        {
            return clsMantenimientoCanales.RegistrarCanal(idCanal, cDescripcion, lInterno, lActivo, lVigente);
        }

        public DataTable RegistrarVendedores(int idVendedor, int idCanal, int idUsuario, string cNombreVendedor, int idRegion, int idOficina, string cNombreCorto, bool lActivo, bool lVigente)
        {
            return clsMantenimientoCanales.RegistrarVendedores(idVendedor, idCanal, idUsuario, cNombreVendedor, idRegion, idOficina, cNombreCorto, lActivo, lVigente);
        }
    }
}
