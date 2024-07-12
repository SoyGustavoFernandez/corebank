using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;


namespace GEN.CapaNegocio
{
    public class clsCNDetalleGasto
    {
        public clsADDetalleGasto clsTipoSeguro = new clsADDetalleGasto();

        public DataTable CNListarDetalleTipoGasto(int idConcepto)
        {
            return clsTipoSeguro.ADListarDetalleTipoGasto(idConcepto);
        }
    }
}
