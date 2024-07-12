using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADImpresion
    {
        public clsGENEjeSP ObjEjeSP = new clsGENEjeSP();
        public DataTable ADDatosOperacion(int idkardex, int idModulo, decimal nMontoRecibido, decimal nMontoDev, int idUsuario, int idAgencia)
        {
            return ObjEjeSP.EjecSP("GEN_DatosOperacion_sp", idkardex, idModulo,nMontoRecibido,nMontoDev,idUsuario,idAgencia);
        }
        public DataTable ADListarParamImp(int idModulo, int idtipoOpe, int idAgencia, int idCanal, int idEstadoKardex, bool lCliente, bool lEmpresa, int idTipoImpre, int idTipoPlantillaImpresion)
        {
            return ObjEjeSP.EjecSP("GEN_RetornaDetPlanti_sp", idModulo, idtipoOpe, idAgencia, 1, idEstadoKardex, lCliente, lEmpresa, idTipoImpre, idTipoPlantillaImpresion);
        }
        public DataTable ADDetalleOpe(int IdKardex, int IdAgencia, int idModulo)
        {
            return ObjEjeSP.EjecSP("GEN_DetalleOperacion_sp", IdKardex, IdAgencia, idModulo);
        }
        public DataTable ADDetalleOpeImpRelacionado(int IdKardex, int IdAgencia, int idModulo, int idTipoPlantilla)
        {
            return ObjEjeSP.EjecSP("GEN_DetalleImprOpeRelacionada_SP", IdKardex, IdAgencia, idModulo,idTipoPlantilla);
        }
        
        //Retorna el Numero de Impresion de un Doc de una Cuenta
        public DataTable ADRetornaNumImpresion(int idCuenta,int idModulo )
        {
            return ObjEjeSP.EjecSP("GEN_RetornaNumImpresion_sp", idCuenta, idModulo);
        }
        //Guarda el kardex vinculado a la impresion
        public DataTable ADGuardaImpresion(int idCuenta, int idModulo, int nNumImpresion, int idKardex, 
                                           int idUsario, int idTipoImpresion, DateTime dFechaImpresion,
                                            string cMotivo, bool lIndExoner, int idSolicitud)
        {
            return ObjEjeSP.EjecSP("GEN_GuardaImpresion_sp", idCuenta, idModulo, nNumImpresion, idKardex,
                                                            idUsario, idTipoImpresion, dFechaImpresion, cMotivo,
                                                            lIndExoner, idSolicitud);
        }
        //Valida Nro de kardex
        public DataTable ADValidaKardex(int idKardex, bool lIndCertificado, int idAgencia)
        {
            return ObjEjeSP.EjecSP("GEN_ValidaKardex_sp", idKardex, lIndCertificado, idAgencia);
        }
        //Valida Vinculacion Nro de kardex
        public DataTable ADValidaVinculacionKardex(int idKardex, int idModulo)
        {
            return ObjEjeSP.EjecSP("GEN_ValidaVinculacionKar_sp", idKardex, idModulo);
        }
        //Busca Nro de Kardex
        public DataTable ADBuscaKardex(int idKardex, int idAgencia)
        {
            return ObjEjeSP.EjecSP("GEN_BuscaDatosKardex_sp", idKardex, idAgencia);
        }
        //Devuelve Operador por Kardex
        public DataTable ADDevuelveOperadorKardex(int idKardex)
        {
            return ObjEjeSP.EjecSP("ADM_DevuelveOperadorKardex_SP", idKardex);
        }
		//Buscar Kardex de cancelación de ahorros
        public DataTable ADDatosCancelacion(int idKardex)
        {
            return ObjEjeSP.EjecSP("DEP_DetalleCancelAho_sp", idKardex);
        }
        //Busca Kardex Compra/Venta Dólares
        public DataTable ADDatosCompraVentaDol(int idKardex)
        {
            return ObjEjeSP.EjecSP("SER_BuscaOpeDol_sp", idKardex);
        }
        public DataTable ADBuscaKardexIndem(int idKardex, int idAgencia)
        {
            return ObjEjeSP.EjecSP("CLI_RetornaDatosIndem_sp", idKardex, idAgencia);
        }

        public DataTable ADListadoDocsReimpresion(int idCuenta, int idSolicitud)
        {
            return ObjEjeSP.EjecSP("DEP_ListaDocsReimprimir_Sp", idCuenta, idSolicitud);
        }
        public DataTable ADDetalleIniOpe(int IdIniOpe)
        {
            return ObjEjeSP.EjecSP("GEN_DetalleIniOpe_sp", IdIniOpe);
        }
        public DataTable ADDatosIniOpe(int idIniOpe)
        {
            return ObjEjeSP.EjecSP("GEN_DatosIniOpe_sp", idIniOpe);
        }

        public DataTable ADOrdenImpresionKardex(int idKardex)
        {
            return ObjEjeSP.EjecSP("GEN_OrdenImpresionVouchers_Sp", idKardex);
        }

        //Retorna el Numero Máximo de Folio entregado en la agencia
        public DataTable ADRetornaMaxFolioPFAge(int idAgencia)
        {
            return ObjEjeSP.EjecSP("GEN_RetornaFolioMaximoAge_sp", idAgencia);
        }

        public DataTable ADActualizaPerfilAprUsuarioCesado(int idSolAproba)
        {
            return ObjEjeSP.EjecSP("CRE_ActualizaPerfilAprobador_SP", idSolAproba);
        }

    }
}

