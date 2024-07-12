using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADGenAdmOpe
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //=============================================================
        //--Listado de Tipo de Operaciones
        //=============================================================
        public DataTable ListadoOperacion()
        {
            return objEjeSp.EjecSP("GEN_TipoOperacion_Sp");
        }

        //=============================================================
        //--Listado de Tipo de Operaciones por Modulo
        //=============================================================
        public DataTable ListadoOperacionModulo(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_LisTipoOperacModulo_SP", idModulo);
        }

        //=============================================================
        //--Listado de Tipo de Operaciones por Producto
        //=============================================================
        public DataTable ADLisTipoOperacProduc(int idProducto)
        {
            return objEjeSp.EjecSP("GEN_ListarTipOpeProduc_SP", idProducto);
        }

        //Lista todos los tipos de operaciones por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public DataTable LisTiposOperacProducto(int idProducto)
        {
            return objEjeSp.EjecSP("GEN_ListarTipOperacionProd_SP", idProducto);
        }


        //=============================================================
        //--Listado de Modalidad de Operaciones
        //=============================================================
        public DataTable ListadoModalidadOperac()
        {
            return objEjeSp.EjecSP("GEN_LisModalidadOperac_SP");
        }


        //=============================================================
        //--Retorna Saldo Disponible cuenta relacionada 
        //=============================================================
        public DataTable RetDatOpeKardexSalDisp(int idKar)
        {
            return objEjeSp.EjecSP("GEN_BuscarOpeKardexSalDisp_SP", idKar);
        }

        //=============================================================
        //--Retorna Datos Kardex principal 
        //=============================================================
        public DataTable RetDatOpeKardexRel(int idKar)
        {
            return objEjeSp.EjecSP("GEN_BuscarOpeKardexRel_SP", idKar);
        }

        //=============================================================
        //--Retorna Datos de la Operación
        //=============================================================
        public DataTable RetDatOperacion(int idKar, DateTime dFecKar, int idUsu, int idAge)
        {
            return objEjeSp.EjecSP("GEN_BuscarOpeExt_Sp", idKar, dFecKar, idUsu, idAge);
        }

        //=============================================================
        //--Registrar Solicitud de Extorno
        //=============================================================
        public DataTable RegSolExtorno(DateTime dFecSol, int idKar,int idMon, Decimal nMonOpe,int idAge,int idUsu,int idMod,
                                        int idTipOpe,int idMotExt,string cSust)
        {
            return objEjeSp.EjecSP("GEN_RegSolExtornos_Sp", dFecSol, idKar,idMon, nMonOpe,idAge,idUsu,idMod,idTipOpe,idMotExt,cSust);
        }

        //=============================================================
        //--Listado de Solicitudes para Aprobacion
        //=============================================================
        public DataTable ListadoSolPend(int idKar, DateTime dFecSol, int idAge, int idUsu, int idMod, int idTipOpe,
                                         Decimal nMonOpe, int idPerf, int idOpc)
        {
            return objEjeSp.EjecSP("GEN_ListaSolExtorno_Sp", idKar, dFecSol, idAge, idUsu, idMod, idTipOpe,
                                                    nMonOpe, idPerf, idOpc);
        }

        //=============================================================
        //--Registrar Aprobacion/Rechazo Solicitud de Extorno
        //=============================================================
        public DataTable RegAprRecSol(int idSol, int idUsu, int idAge, int idEstSol)
        {
            return objEjeSp.EjecSP("GEN_AprRecSolExt_Sp", idSol, idUsu, idAge, idEstSol);
        }

        //=============================================================
        //--Retorna Primera Fecha a Guardar del Tipo de Cambio
        //=============================================================
        public DataTable RetFecTipCambio(DateTime dFecSis)
        {
            return objEjeSp.EjecSP("GEN_FechaTiposCambio_Sp", dFecSis);
        }

        //=============================================================
        //--Registro Tipos de Cambio de un Rango de Fechas
        //=============================================================
        public DataTable RegTipoCambio(DateTime dFecIni, DateTime dFecFin, Decimal nTipCamFij, Decimal nTipCamCom, Decimal nTipCamVen, Decimal nTipCamPromCom, Decimal nTipCamProVen, int idUsuReg, DateTime dfechaReg)
        {
            return objEjeSp.EjecSP("GEN_RegistraTipCambio_Sp", dFecIni, dFecFin, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamPromCom, nTipCamProVen, idUsuReg, dfechaReg);
        }

        //=============================================================
        //--Actualizar los Tipo de Cambio
        //=============================================================
        public DataTable ActTipCambio(DateTime dFecReg, Decimal nTipCamFij, Decimal nTipCamCom, Decimal nTipCamVen, Decimal nTipCamPromCom, Decimal nTipCamProVen, int nOpc, int idUsuMod)
        {
            return objEjeSp.EjecSP("GEN_ActualizarTiposCambio_Sp", dFecReg, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamPromCom, nTipCamProVen, nOpc, idUsuMod);
        }

        //=============================================================
        //--Retorna Ultimo Tipo de Cambio
        //=============================================================
        public DataTable RetUltTipCambio(DateTime dFecSis)
        {
            return objEjeSp.EjecSP("GEN_RetUltTipoCambio_Sp", dFecSis);
        }

        //=============================================================
        //--Retorna Tipos de Cambio
        //=============================================================
        public DataTable RetTipCambio(DateTime dFecTipCam)
        {
            return objEjeSp.EjecSP("GEN_RetornaTiposCambio_Sp", dFecTipCam);
        }
        //=============================================================
        //--Retorna saldo de operador por agencia y fecha.
        //=============================================================
        public DataTable RetSaldoOperadorAge(DateTime dFechaOpe, int idUsuario, int idAgencia)
        {
            return objEjeSp.EjecSP("Gen_RetornaSaldoEnLinea_Sp", dFechaOpe, idUsuario, idAgencia);
        }

        public DataTable recuperarOperacionExtorno(int idKardex, DateTime dFechaKardex, int idUsuario, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_RecuperarOperacionExtorno_SP", idKardex, dFechaKardex, idUsuario, idAgencia);
        }
    }
}
