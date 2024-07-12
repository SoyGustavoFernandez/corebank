using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipAutUsoDatos
    {
        clsADTipAutUsoDatos adObjSector = new clsADTipAutUsoDatos();
        public DataTable CNListaTipoAutUsoDatos()
        {
            return adObjSector.ADListaTipAutUsoDatos();
        }
        public DataTable CNEstadoAutUsoDatos()
        {
            return adObjSector.ADEstadoAutUsoDatos();
        }
        public DataTable CNMotivoAutUsoDatos(bool esRemoto)
        {
            return adObjSector.ADMotivoAutUsoDatos(esRemoto);
        }

        public DataTable CNObtenerIntervinienteBiometrico(int idCliente)
        {
            return adObjSector.ADObtenerIntervinienteBiometrico(idCliente);
        }
        public DataTable CNListaMotivoDesistimientoAutUsoDatos()
        {
            return adObjSector.ADObtenerMotivoDesistimientoAutUsoDato();
        }
        public DataTable CNListaCanalRegistro()
        {
            return adObjSector.ADListaCanalRegistro();
        }
        public DataTable ListarReporteAutTratamientoUsoDatos(object parametros)
        {
            DataTable dtRespuesta = this.adObjSector.listarReporteAutoUsoTratamientoDatos(parametros);
            return dtRespuesta;
        }
    }
}
