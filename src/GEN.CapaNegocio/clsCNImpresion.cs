﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using GEN.PrintHelper;
using System.Drawing.Printing;
using EntityLayer;
using System.Drawing;
using System.Windows.Forms;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;


namespace GEN.CapaNegocio
{

    public class clsCNImpresion
    {
        public clsADImpresion objImpresion = new clsADImpresion();
        public DataTable CNDatosOperacion(int idkardex, int idModulo, decimal nMontoRecibido, decimal nMontoDev, int idUsuario, int idAgencia)
        {
            return objImpresion.ADDatosOperacion(idkardex, idModulo, nMontoRecibido, nMontoDev,idUsuario,idAgencia);
        }

        /// <summary>
        /// imprime con numero de impresiones configurado en la base de datos
        /// </summary>
        /// <param name="idModulo"></param>
        /// <param name="idTipoOpe"></param>
        /// <param name="dtValImprime"></param>
        /// <returns></returns>
        public bool CNImpresionVoucher(int idModulo, int idTipoOpe, DataTable dtValImprime)
        {
            int nNumImpresion = (int)dtValImprime.Rows[0]["nNumIpresionVou"];
            return  CNImpresionVoucher(idModulo,idTipoOpe,dtValImprime,nNumImpresion);
        }

        /// <summary>
        /// imprime configurando el numero de veces que requieras
        /// </summary>
        /// <param name="idModulo"></param>
        /// <param name="idTipoOpe"></param>
        /// <param name="dtValImprime"></param>
        /// <param name="nNumImpresion"></param>
        /// <returns></returns>
        
        public bool CNImpresionVoucher(int idModulo, int idTipoOpe, DataTable dtValImprime, int nNumImpresion)
        {

            int idAgencia = clsVarGlobal.nIdAgencia;
            int idkardex = Convert.ToInt32(dtValImprime.Rows[0]["idKardex"]);
            int idTipoPlantImpresion = clsVarGlobal.idTipoPlantillaImpresion;
            DataTable dtParametrosImp = objImpresion.ADListarParamImp(idModulo, idTipoOpe, idAgencia, 1, 1, true, true, 1, idTipoPlantImpresion);
            DataTable dtDetOperacion = objImpresion.ADDetalleOpe(idkardex, idAgencia, clsVarGlobal.idModulo);
            string cPlantilla = "", cDetalle = "";
            if (dtValImprime.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < dtParametrosImp.Rows.Count; i++)
                {
                    cPlantilla += dtParametrosImp.Rows[i]["cLineaPlanti"].ToString()+"\r\n";
                }
                //Concatenando el Detalle
                for (int j = 0; j < dtDetOperacion.Rows.Count; j++)
                {
                    cDetalle +=  dtDetOperacion.Rows[j]["cNombreCorto"].ToString() + " " + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(24,' ') + "\r\n";
                }
                //Añadiendo el Nro de Columnas
                for (int i = 0; i < dtDetOperacion.Columns.Count; i++)
                {
                    dtValImprime.Columns.Add(dtDetOperacion.Columns[i].ColumnName, typeof(string));
                    dtValImprime.Rows[0][dtDetOperacion.Columns[i].ColumnName] = dtDetOperacion.Rows[0][i].ToString(); ;
                }
                dtValImprime.Rows[0]["cDetalle"] = cDetalle.ToString();
                foreach (DataRow item in dtParametrosImp.Rows)
                {
                    cPlantilla = cPlantilla.Replace(item["cNombreCampo"].ToString(), dtValImprime.Rows[0][item["cNombreCampo"].ToString()].ToString());   
                }
                
                MessageBox.Show(cPlantilla);
                for (int i = 0; i < nNumImpresion; i++)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();

                    RawPrinterHelper.SendStringToPrinter(clsVarGlobal.cNomImpTer, cPlantilla);
                    string cSaltoLinea = "\x1B" + "d" + "\x09";
                    RawPrinterHelper.SendStringToPrinter(clsVarGlobal.cNomImpTer, cSaltoLinea);
                    string cCortaPapel = "\x1B" + "m";
                    RawPrinterHelper.SendStringToPrinter(clsVarGlobal.cNomImpTer, cCortaPapel);
                }                     
            }

            return true;
        }

        //Retorna el Numero de Impresion de un Doc de una Cuenta
        public DataTable CNRetornaNumImpresion(int idCuenta, int idModulo)
        {
            return objImpresion.ADRetornaNumImpresion( idCuenta, idModulo);
        }

        //Guarda el kardex vinculado a la impresion
        public DataTable CNGuardaImpresion(int idCuenta, int idModulo, int nNumImpresion, int idKardex, int idUsuario, int idTipoImpresion, DateTime dFechaImpresion, string cMotivo, bool lIndExoner,int idSolicitud)
        {
            return objImpresion.ADGuardaImpresion(idCuenta, idModulo, nNumImpresion, idKardex, idUsuario, idTipoImpresion, dFechaImpresion, cMotivo, lIndExoner, idSolicitud);
        }

      
        //Valida Nro de kardex
        public DataTable CNValidaKardex(int idKardex, bool lIndCertificado, int idAgencia)
        {
            return objImpresion.ADValidaKardex(idKardex, lIndCertificado, idAgencia);
        }
      
        //Valida Vinculacion con Kardex
        public DataTable CNValidaVinculacionKardex(int idKardex, int idModulo)
        {
            return objImpresion.ADValidaVinculacionKardex(idKardex, idModulo);
        }
        
        //Busca Nro de Kardex
        public DataTable CNBuscaKardex(int idKardex, int idAgencia)
        {
            return objImpresion.ADBuscaKardex( idKardex, idAgencia);
        }
        //Devuelve Operador por Kardex
        public DataTable CNDevuelveOperadorKardex(int idKardex)
        {
            return objImpresion.ADDevuelveOperadorKardex(idKardex);
        }
        
		//Busca kardex de cancelación de ahorros
        public DataTable CNDatosCancelación(int idkardex)
        {
            return objImpresion.ADDatosCancelacion(idkardex);
        }
        //Busca Kardex Compra/Venta Dólares
        public DataTable CNDatosCompraVentaDol(int idKardex)
        {
            return objImpresion.ADDatosCompraVentaDol(idKardex);
        }
        public DataTable CNBuscaKardexIndem(int idKardex, int idAgencia)
        {
            return objImpresion.ADBuscaKardexIndem(idKardex, idAgencia);
        }

        public DataTable CNListadoDocsReimpresion(int idCuenta, int idSolicitud)
        {
            return objImpresion.ADListadoDocsReimpresion(idCuenta, idSolicitud);
        }

        public DataTable CNListarParamImp(int idModulo, int idtipoOpe, int idAgencia, int idCanal, int idEstadoKardex, bool lCliente, bool lEmpresa,int idTipoImpre)
        {
            int idTipoPlantImpresion = clsVarGlobal.idTipoPlantillaImpresion;
            return objImpresion.ADListarParamImp(idModulo, idtipoOpe, idAgencia, idCanal, idEstadoKardex, lCliente, lEmpresa, idTipoImpre, idTipoPlantImpresion);
        }
        public DataTable CNDetalleOpe(int IdKardex, int IdAgencia, int idModulo)
        {
            return objImpresion.ADDetalleOpe( IdKardex, IdAgencia, idModulo);
        }
        public DataTable CNDetalleOpeImpRelacionado(int IdKardex, int IdAgencia, int idModulo, int idTipoPlantilla)
        {
            return objImpresion.ADDetalleOpeImpRelacionado(IdKardex, IdAgencia, idModulo, idTipoPlantilla);
        }
        
        public string CNValorImpIniOpe(int IdIniOpe, int IdAgencia,int idModulo,int idTipoOpe)
        {                  
            int idEstadoKardex = 0;

            DataTable dtDatosOperacion = CNDatosIniOpe(IdIniOpe);
            if (dtDatosOperacion.Rows.Count > 0)
            {
                //Recuperando el estado de la cuenta
                DataTable dtParametrosImp = CNListarParamImp(idModulo, idTipoOpe, IdAgencia, 1, idEstadoKardex,true,true,1);
                DataTable dtDetOperacion = CNDetalleIniOpe(IdIniOpe);
                string cPlantilla = "", cDetalle = "";
                for (int i = 0; i < dtParametrosImp.Rows.Count; i++)
                {
                    cPlantilla += dtParametrosImp.Rows[i]["cLineaPlanti"].ToString() + Environment.NewLine;
                }
                //Concatenando el Detalle
                for (int j = 0; j < dtDetOperacion.Rows.Count; j++)
                {
                    //cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().PadRight(15, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(12, '*') + Environment.NewLine;
                    if (clsVarGlobal.idTipoPlantillaImpresion == 2)
                    {
                        cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().PadRight(13, ' ') + ": " + (Convert.ToDecimal(dtDetOperacion.Rows[j]["nMonto"]).ToString("N2")).PadLeft(21, '*') + Environment.NewLine;
                    }
                    else 
                    {
                        cDetalle += dtDetOperacion.Rows[j]["cNombreCorto"].ToString().PadRight(15, ' ') + ":" + (dtDetOperacion.Rows[j]["nMonto"].ToString()).PadLeft(14, '*') + Environment.NewLine;
                    }
                    
                }

                //Añadiendo el Nro de Columnas
                for (int i = 0; i < dtDetOperacion.Columns.Count; i++)
                {
                    dtDatosOperacion.Columns.Add(dtDetOperacion.Columns[i].ColumnName, typeof(string));
                    dtDatosOperacion.Rows[0][dtDetOperacion.Columns[i].ColumnName] = dtDetOperacion.Rows[0][i].ToString(); ;
                }
                dtDatosOperacion.Columns["cDetalle"].ReadOnly = false;
                dtDatosOperacion.Columns["cDetalle"].MaxLength = 500;

                dtDatosOperacion.Rows[0]["cDetalle"] = cDetalle;

                foreach (DataColumn Column in dtDatosOperacion.Columns)
                {
                    cPlantilla = cPlantilla.Replace(Column.ColumnName, dtDatosOperacion.Rows[0][Column.ColumnName].ToString());
                }

                if (string.IsNullOrEmpty(cPlantilla))
                {
                    MessageBox.Show("Ocurrió un problema al intentar imprimir", "Extorno de Operacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
                else
                {
                    return cPlantilla;
                }
            }
            else
            {
                return "";
            }
        }
        public DataTable CNDetalleIniOpe(int IdIniOpe)
        {
            return objImpresion.ADDetalleIniOpe(IdIniOpe);
        }
        public DataTable CNDatosIniOpe(int IdIniOpe)
        {
            return objImpresion.ADDatosIniOpe(IdIniOpe);
        }

        public DataTable CNOrdenImpresionKardex(int idKardex)
        {
            return objImpresion.ADOrdenImpresionKardex(idKardex);
        }

        //Retorna el Numero Máximo de Folio entregado en la agencia
        public DataTable CNRetornaMaxFolioPFAge(int idAgencia)
        {
            return objImpresion.ADRetornaMaxFolioPFAge(idAgencia);
        }

        public DataTable CNActualizaPerfilAprUsuarioCesado(int idSolAproba)
        {
            return objImpresion.ADActualizaPerfilAprUsuarioCesado(idSolAproba);
        }

    }
}
