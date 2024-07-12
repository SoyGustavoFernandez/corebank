using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace CAJ.AccesoDatos
{
    public class clsADRemesa
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADBuscarDatosPersonal(int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_BuscarDatosPersonal_SP", idUsuario);
        }
        public DataTable ADListarEstadoRemesa(int idTipoRemesa,int nAcceso, int idEstadoRemesa)
        {
            return objEjeSp.EjecSP("CAJ_ListarEstadoRemesa_SP", idTipoRemesa, nAcceso, idEstadoRemesa);
        }
        public DataTable ADListarModalidadRemesa(int idTipoRemesa)
        {
            return objEjeSp.EjecSP("CAJ_ListarModalidadRemesa_SP", idTipoRemesa);
        }
        public DataTable ADListarTiposRemesa()
        {
            return objEjeSp.EjecSP("CAJ_ListarTiposRemesa_SP");
        }
        public DataTable ADListarRemesas(int idUsuario, int idEstablecimiento, int idTipoRemesa, int idEstadoRemesa, DateTime dFechaDesde,DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CAJ_ListarRemesas_SP", idUsuario, idEstablecimiento, idTipoRemesa, idEstadoRemesa, dFechaDesde, dFechaHasta);
        }
        public DataTable ADBuscarRemesa(int idRemesa)
        {
            return objEjeSp.EjecSP("CAJ_BuscarRemesa_SP", idRemesa);
        }
        public clsDBResp InsertarActualizarRemesa(clsRemesa objRemesa, clsMontoRemesa objMontoRemesa, int idRemesa)
        {
            List<clsRemesa> lstRemesa = new List<clsRemesa>();
            List<clsMontoRemesa> lstMontoRemesa = new List<clsMontoRemesa>();
            lstRemesa.Add(objRemesa);
            lstMontoRemesa.Add(objMontoRemesa);
            string xmlRemesa = lstRemesa.GetXml<clsRemesa>();
            string xmlMontoRemesa = lstMontoRemesa.GetXml<clsMontoRemesa>();
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult = objEjeSp.EjecSP("CAJ_InsertarActualizarRemesa_SP", xmlRemesa, xmlMontoRemesa, idRemesa);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            return objDbResp;
        }
    }
}
