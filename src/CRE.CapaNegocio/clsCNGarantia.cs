using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNGarantia
    {
        clsADGarantia objgarantia = new clsADGarantia();

        /// <summary>
        /// lista las garantia de un cliente
        /// </summary>
        /// <param name="idCli">id del cliente a consultar</param>
        /// <returns>listado de la entidad garantia</returns>
        public clsListGarantia listarGarantias(int idCli)
        {
            return objgarantia.listarGarantias(idCli);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCli"></param>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsListDetGarantia listarDetGarantia(int idGarantia)
        {
            return objgarantia.listarDetGarantia(idGarantia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGarantia"></param>
        /// <returns></returns>
        public clsLisEspecificacioGarantia listarespecificacion(int idGarantia)
        {
            return objgarantia.listarespecificacion(idGarantia);
        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="objGarantia"></param>
        /// <returns></returns>
        public clsDBResp insertarGarantia(clsGarantia objGarantia)
        {
            return objgarantia.insertarGarantia(objGarantia);
        }

        public clsDBResp cambiarEstadoGarantia(clsGarantia objGarantia, int idUsuario, DateTime dFecchaSis)
        {
            return objgarantia.cambiarEstadoGarantia(objGarantia, idUsuario,dFecchaSis);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGarantia"></param>
        public void actualizarGarantia(clsGarantia objGarantia)
        {
            objgarantia.actualizarGarantia(objGarantia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarTipoGarantia()
        {
            return objgarantia.listarTipoGarantia();
        }

        public DataTable listarTipoGarantiaFiltroCambioEstado( int idClase)
        {
            return objgarantia.listarTipoGarantiaFiltroCambioEstado( idClase );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarClaseGarantia()
        {
            var dt = objgarantia.listarClaseGarantiaXml();

            DataTable dtClaseGarantia = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lEstado"] == true
             select item).CopyToDataTable(dtClaseGarantia, LoadOption.OverwriteChanges);

            return dtClaseGarantia;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public clsListGarantia buscarGarantias(string codigo)
        {
            return objgarantia.buscarGarantias(codigo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable listarCriterioBus()
        {
            //return objgarantia.listarCriterioBus();
            return objgarantia.listarCriterioBusXML();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCriterio"></param>
        /// <param name="cValBusqueda"></param>
        /// <returns></returns>
        public DataTable buscarGarantiaCli(int nCriterio, string cValBusqueda)
        {
            return objgarantia.buscarGarantiaCli(nCriterio, cValBusqueda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="listagarantias"></param>
        /// <param name="idUsuario"></param>
        public clsDBResp insertaVinSolGar(int idSolicitud, clsListDetGarantia listagarantias, int idUsuario)
        {
            return objgarantia.insertaVinSolGar(idSolicitud, listagarantias, idUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCli"></param>
        /// <returns></returns>
        public DataTable listarGarantiasByCli(int idSol, int idCli)
        {
            return objgarantia.listarGarantiasByCli(idSol,idCli);
        }

        public clsListDetGarantia listarGarVinculadasSol(int idSolicitud)
        {
            return objgarantia.listarGarVinculadasSol(idSolicitud);
        }

        public DataTable listarGrupoGarantia()
        {
            return objgarantia.listarGrupoGarantia();
        }

        public DataTable listarGrupoGarantiaXML()
        {
            return objgarantia.listarGrupoGarantiaXml();
        }

        public DataTable CNSaldoTasado(int idSolicitud)
        {
            return objgarantia.ADSaldoTasado(idSolicitud);
        }

        public DataTable ListaGarantiasCliente(int idCli)
        {
            return objgarantia.ListaGarantiasCliente(idCli);
        }

        public DataTable listarEstadosGarantia()
        {
            var dt = objgarantia.listarEstadosGarantiaXml();

            DataTable dtEstadoGarantia = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoGarantia, LoadOption.OverwriteChanges);

            return dtEstadoGarantia;
        }

        public DataTable DatosGarantiaCredito(int idGarantia)
        {
            return objgarantia.DatosGarantiaCredito(idGarantia);
        }

        public DataTable RptControlInsBloGar(int nDias)
        {
            return objgarantia.RptControlInsBloGar(nDias);
        }

        public DataTable RptCreditosGarantias(DateTime dFecIni, DateTime dFecFin, int idTipoGarantia)
        {
            return objgarantia.RptCreditosGarantias(dFecIni, dFecFin, idTipoGarantia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="listagarantias"></param>
        /// <param name="idUsuario"></param>
        public clsDBResp insertaCambioVinCreGar(int idCuenta, clsListDetGarantia listagarantias, int idUsuario)
        {
            return objgarantia.insertaCambioVinCreGar(idCuenta, listagarantias, idUsuario);
        }

        public DataTable CNlistarGarPerAval(int idGarantia)
        {
            return objgarantia.ADlistarGarPerAval(idGarantia);
        }

        public DataTable CNRptVencimientoTasacion(int nDias)
        {
            return objgarantia.ADRptVencimientoTasacion(nDias);
        }

        public DataTable CNrptCreditosConGarantia(int idProducto, int idMoneda, int idAgencia, int idAsesor)
        {
            return objgarantia.ADrptCreditosConGarantia(idProducto, idMoneda, idAgencia, idAsesor);
        }

        public DataTable CNHistoricoValorizacion(int idGarantia, int idEstado)
        {
            return objgarantia.ADHistoricoValorizacion(idGarantia, idEstado);
        }

        public DataTable CNValidaCuentaGarantia(int idCuenta)
        {
            return objgarantia.ADValidaCuentaGarantia(idCuenta);
        }

        public DataTable CNRetGarantiasIntervinientes(int idSolicitud, string xmlIntervinientes)
        {
            return objgarantia.ADRetGarantiasIntervinientes(idSolicitud, xmlIntervinientes);
        }

        public DataTable CNrptGarantiasCliente(int idCli, int idEstado)
        {
            return objgarantia.ADrptGarantiasCliente(idCli, idEstado);
        }

        public DataSet CNListaGarantiasIdClienteYDetalle(int idCli, int idEstado)
        {
            return objgarantia.ADListaGarantiasIdClienteYDetalle(idCli, idEstado);
        }

        public DataTable CNValidarGarEstadoCre(int idGarantia)
        {
            return objgarantia.ADValidarGarEstadoCre(idGarantia);
        }

        public DataTable CNRegistrarSalidaGarantia(
                                                        int idGarantia,
                                                        int idTipoGarantia,
                                                        DateTime dFechaSalida,
                                                        int idMotivoSalida,
                                                        decimal nAdjudicacionGarantia,
                                                        decimal nGastosAdjudicacion,
                                                        decimal nVentaGarantiaSinImp,
                                                        decimal nGastosVenta,
                                                        int idModalidadVentaGarantia,
                                                        int idUsuarioReg

            )
        {
            return objgarantia.ADRegistrarSalidaGarantia(
                                                        idGarantia,
                                                        idTipoGarantia,
                                                        dFechaSalida,
                                                        idMotivoSalida,
                                                        nAdjudicacionGarantia,
                                                        nGastosAdjudicacion,
                                                        nVentaGarantiaSinImp,
                                                        nGastosVenta,
                                                        idModalidadVentaGarantia,
                                                        idUsuarioReg
                );
        }

        public DataTable CNListarModalidadVentaGarantia()
        {
            return objgarantia.ADListarModalidadVentaGarantia();
        }

        public DataTable CNListarMotivoSalida()
        {
            return objgarantia.ADListarMotivoSalida();
        }

        public DataTable CNListarSituacionGarantiaIdTipoSituacion(int idTipoSituacion)
        {
            return objgarantia.ADListarSituacionGarantiaIdTipoSituacion( idTipoSituacion);
        }

        public DataTable CNListarTipoEmisorGarantia()
        {
            return objgarantia.ADListarTipoEmisorGarantia();
        }

        public DataTable CNGetGarantiasIntervSol(int idSolicitud)
        {
            return objgarantia.ADGetGarantiasIntervSol(idSolicitud);
        }

        public clsDBResp CNActualizaGravamenGarantia(int idGarantia)
        {
            return objgarantia.ADActualizaGravamenGarantia(idGarantia);
        }

        public DataTable CNRptGarantiasPreferidas(int idClaseGarantia, DateTime dFecha, int nIdRegion, int nIdAgencia, int idTipoGarantiaGlobal)
        {
            return objgarantia.rptGarantiasPreferidas(idClaseGarantia,dFecha,nIdRegion,nIdAgencia,idTipoGarantiaGlobal);
        }
        public DataTable CNRptContradepositos(string cXmlAgencias, int idClaseGarantia, DateTime dFecha)
        {
            return objgarantia.rptContradepositos(cXmlAgencias, idClaseGarantia, dFecha);
        }
        public DataTable CNRptContradepositosGar(int idClaseGarantia, DateTime dFecha, int nIdRegion, int nIdAgencia,int idTipoGarantiaGlobal)
        {
            return objgarantia.rptContradepositosGar(idClaseGarantia, dFecha,nIdRegion,nIdAgencia,idTipoGarantiaGlobal);
        }

        public DataTable CNValidaCuentaDeposito(int idGarantia, decimal nMontoCoberturar, int idSolicitud)
        {
            return objgarantia.ADValidaCuentaDeposito(idGarantia, nMontoCoberturar, idSolicitud);
        }
    }
}
