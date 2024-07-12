using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNGenAdmOpe
    {
        clsADGenAdmOpe objCtrGen = new clsADGenAdmOpe();

        //=============================================================
        //--Listado de Tipo de Operaciones
        //=============================================================
        public DataTable ListadoTipoOpe()
        {
            return objCtrGen.ListadoOperacion();
        }

        //=============================================================
        //--Listado de Tipo de Operaciones por Modulo
        //=============================================================
        public DataTable LisTipoOperacModulo(int idModulo)
        {
            return objCtrGen.ListadoOperacionModulo(idModulo);
        }

        //=============================================================
        //--Listado de Tipo de Operaciones por Producto
        //=============================================================
        public DataTable CNLisTipoOperacProduc(int idProducto)
        {
            return objCtrGen.ADLisTipoOperacProduc(idProducto);
        }

        //Lista todos los tipos de operaciones por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public DataTable LisTiposOperacProducto(int idProducto)
        {
            return objCtrGen.LisTiposOperacProducto(idProducto);
        }


        //=============================================================
        //--Listado de Modalidad de Operaciones
        //=============================================================
        public DataTable LisModalidadOperac()
        {
            return objCtrGen.ListadoModalidadOperac();
        }

        //=============================================================
        //--Retorna Saldo Disponible cuenta relacionada 
        //=============================================================
        public DataTable RetDatOpeKardexSalDisp(int idKar)
        {
            return objCtrGen.RetDatOpeKardexSalDisp(idKar);
        }

        //=============================================================
        //--Retorna Datos Kardex principal 
        //=============================================================
        public DataTable RetDatOpeKardexRel(int idKar)
        {
            return objCtrGen.RetDatOpeKardexRel(idKar);
        }

        //=============================================================
        //--Retorna Datos de la Operacion
        //=============================================================
        public DataTable RetDatosOperacion(int idKar, DateTime dFecKar, int idUsu, int idAge)
        {
            return objCtrGen.RetDatOperacion(idKar, dFecKar, idUsu, idAge);
        }

        //=============================================================
        //--Registra Solicitud
        //=============================================================
        public DataTable RegSolicitudExtorno(DateTime dFecSol, int idKar, int idMon, Decimal nMonOpe, int idAge, int idUsu, int idMod,
                                        int idTipOpe, int idMotExt, string cSust)
        {
            return objCtrGen.RegSolExtorno(dFecSol, idKar, idMon, nMonOpe, idAge, idUsu, idMod, idTipOpe, idMotExt, cSust);
        }

        //=============================================================
        //--Listado de Solicitudes Pendientes
        //=============================================================
        public DataTable ListadoSolExtPend(int idKar, DateTime dFecSol, int idAge, int idUsu, int idMod, int idTipOpe,
                                         Decimal nMonOpe, int idPerf, int idOpc)
        {
            return objCtrGen.ListadoSolPend(idKar, dFecSol, idAge, idUsu, idMod, idTipOpe,
                                               nMonOpe, idPerf, idOpc);
        }

        //=============================================================
        //--Registra Aprobacio/Rechazo de la Solicitud de Extorno
        //=============================================================
        public DataTable RegAprRechazoSolExt(int idSol, int idUsu, int idAge, int idEstSol)
        {
            return objCtrGen.RegAprRecSol(idSol, idUsu, idAge, idEstSol);
        }

        //=============================================================
        //--Retorna Fecha para Registrar Tipo de Cambio
        //=============================================================
        public DataTable RetornaFechaTipCambio(DateTime dFecSis)
        {
            return objCtrGen.RetFecTipCambio(dFecSis);
        }

        //=============================================================
        //--Registra los Tipos de Cambio
        //=============================================================
        public DataTable RegistrarTiposCambio(DateTime dFecIni, DateTime dFecFin, Decimal nTipCamFij, Decimal nTipCamCom, Decimal nTipCamVen, Decimal nTipCamPromCom, Decimal nTipCamProVen, int idUsuReg, DateTime dFechaReg)
        {
            return objCtrGen.RegTipoCambio(dFecIni, dFecFin, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamPromCom, nTipCamProVen, idUsuReg, dFechaReg);
        }

        //=============================================================
        //--Retorna Fecha para Registrar Tipo de Cambio
        //=============================================================
        public DataTable ActualizarTipoCambio(DateTime dFecReg, Decimal nTipCamFij, Decimal nTipCamCom, Decimal nTipCamVen, Decimal nTipCamPromCom, Decimal nTipCamProVen, int nOpc, int idUsuMod)
        {
            return objCtrGen.ActTipCambio(dFecReg, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamPromCom, nTipCamProVen, nOpc, idUsuMod);
        }

        //=============================================================
        //--Retorna Ultimo Tipo de Cambio
        //=============================================================
        public DataTable RetornaUltimoTipCambio(DateTime dFecSis)
        {
            return objCtrGen.RetUltTipCambio(dFecSis);
        }

        //=============================================================
        //--Retorna los Tipos de Cambio
        //=============================================================
        public DataTable RetornaTiposCambio(DateTime dFecTipCam)
        {
            return objCtrGen.RetTipCambio(dFecTipCam);
        }
        //=============================================================
        //--Retorna saldo de operador por agencia y fecha.
        //=============================================================
        public DataTable RetornaSaldoOperadorAge(DateTime dFechaOpe, int idUsuario, int idAgencia)
        {
            return objCtrGen.RetSaldoOperadorAge(dFechaOpe, idUsuario, idAgencia);
        }

        public DataTable recuperarOperacionExtorno(int idKardex, DateTime dFechaKardex, int idUsuario, int idAgencia)
        {
            return objCtrGen.recuperarOperacionExtorno(idKardex, dFechaKardex, idUsuario, idAgencia);
        }
    }
}
