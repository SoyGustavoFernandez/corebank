using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAJ.AccesoDatos;
using EntityLayer;

namespace CAJ.CapaNegocio
{
    public class clsCNRemesa
    {
        clsADRemesa objADRemesa = new clsADRemesa();

        public DataTable CNBuscarDatosPersonal(int idUsuario)
        {
            return objADRemesa.ADBuscarDatosPersonal(idUsuario);
        }
        public DataTable CNListarEstadoRemesa(int idTipoRemesa, int nAcceso, int idEstadoRemesa)
        {
            return objADRemesa.ADListarEstadoRemesa(idTipoRemesa, nAcceso, idEstadoRemesa);
        }
        public DataTable CNListarModalidadRemesa(int idTipoRemesa)
        {
            return objADRemesa.ADListarModalidadRemesa(idTipoRemesa);
        }
        public DataTable CNListarTiposRemesa()
        {
            return objADRemesa.ADListarTiposRemesa();
        }
        public DataTable CNListarRemesa(int idUsuario, int idEstablecimiento, int idTipoRemesa, int idEstadoRemesa, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objADRemesa.ADListarRemesas(idUsuario, idEstablecimiento, idTipoRemesa, idEstadoRemesa, dFechaDesde, dFechaHasta);
        }
        public DataTable CNBuscarRemesa(int idRemesa)
        {
            return objADRemesa.ADBuscarRemesa(idRemesa);
        }
        public clsDBResp InsertarActualizarRemesa(clsRemesa objRemesa, clsMontoRemesa objMontoRemesa,int idRemesa)
        {
            return objADRemesa.InsertarActualizarRemesa(objRemesa, objMontoRemesa, idRemesa);
        }
    }
}
