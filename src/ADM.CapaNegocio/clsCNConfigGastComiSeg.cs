using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADM.AccesoDatos;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNConfigGastComiSeg
    {
        clsADConfigGastComiSeg ConfigGastComiSeg = new clsADConfigGastComiSeg();

        public int InsertaActualizaConfigGastComiSeg(String tConfigCredito,Int32 nIndicadorNivelProducto, int idDetalleGasto)
        {
            return ConfigGastComiSeg.InsUpdConfigGastComiSeg(tConfigCredito, nIndicadorNivelProducto, idDetalleGasto);
        }

        public DataTable CargarTipoDeuda(Int32 nTipoDeudas)
        {
            return ConfigGastComiSeg.ListarTipoDeuda(nTipoDeudas);
        }

        public DataTable CargarCondicionContable()
        {
            return ConfigGastComiSeg.ListarCondicionContable();
        }

        public DataTable CargarAplicaConcepto()
        {
            return ConfigGastComiSeg.ListarAplicaConcepto();
        }

        public DataTable CargarAplicarCuota()
        {
            return ConfigGastComiSeg.ListarAplicarCuota();
        }

        public DataTable BuscarConfigGastoComisionSeguro(Int32 IdModulo, Int32 IdAgencia, Int32 IdMoneda, Int32 IdGrupoGasto)
        {
            return ConfigGastComiSeg.BuscarConfigGastoComisionSeguro(IdModulo, IdAgencia, IdMoneda, IdGrupoGasto);
        }

        public DataTable CargarGrupoGasto()
        {
            return ConfigGastComiSeg.CargarGrupoGasto();
        }

        public DataTable CargarConcepto(Int32 nIdGrupoConcepto)
        {
            return ConfigGastComiSeg.CargarConcepto(nIdGrupoConcepto);
        }
        
        public DataTable ValidarSolicitudConfigGastComiSeg(Int32 nNumSolicitud, Int32 nTipoOperacion, Int32 nIdMenu,int idCanal, int idCuenta)
        {
            return ConfigGastComiSeg.ValidarSolicitudConfigGastComiSeg(nNumSolicitud, nTipoOperacion, nIdMenu, idCanal, idCuenta);
        }
        //Actualizar las Configuraciones 
        public DataTable ActualizaConfigGastComiSeg(string XmlConfigGastComiSeg)
        {
            return ConfigGastComiSeg.ActualizaConfigGastComiSeg(XmlConfigGastComiSeg);
        }

        public DataTable ValidaConfigGastComiSeg(int idTipoOperacion, int idCanal, int idProducto, int idRecurso, int idMoneda, int idAgencia, int idTipopersona, int idModulo, decimal nMonto)
        {
            return ConfigGastComiSeg.ValidaConfigGastComiSeg(idTipoOperacion, idCanal, idProducto, idRecurso, idMoneda, idAgencia, idTipopersona, idModulo, nMonto);
        }

        public DataTable ListaTipDocGastos()
        {
            return ConfigGastComiSeg.ListaTipDocGastos();
        }

        public DataTable CNValidarAplicacionSeguroDesgravamen(int idSolicitud, decimal nMontoSolicitado, int idCuenta)
        {
            return ConfigGastComiSeg.ADValidarAplicacionSeguroDesgravamen(idSolicitud, nMontoSolicitado, idCuenta);
        }

        public DataTable CNGetConfigGastosCuenta(int idCuenta)
        {
            return ConfigGastComiSeg.ADGetConfigGastosCuenta(idCuenta);
        }
    }
}
