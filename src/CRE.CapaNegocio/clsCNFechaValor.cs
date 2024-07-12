using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNFechaValor
    {
        clsADFechaValor clsADFechaValor = new clsADFechaValor();

        public void CNInsArchivoSustento(string cNombreArchivo, byte[] cByteArchivo, string extension, int idUsuario, int idCabecera)
        {
            try
            {
                clsADFechaValor.ADInsArchivoSustento(cNombreArchivo, cByteArchivo, extension, idUsuario, idCabecera);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar el archivo de sustento: {ex.Message}");
            }
        }

        public int CNInsPagoFechaValor(string nombrePlantilla, byte[] archivoPlantilla, int idUsuario, int idMotivo, string txtSustento, string xmlDetalle)
        {
            try
            {
                DataTable dtResultado = clsADFechaValor.ADInsPagoFechaValor(nombrePlantilla, archivoPlantilla, idUsuario, idMotivo, txtSustento, xmlDetalle);
                return Convert.ToInt32(dtResultado.Rows[0]["idCabecera"]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar el registro: {ex.Message}");
            }
        }

        public DataTable CNListarMotivosPago()
        {
            return clsADFechaValor.ADListarMotivosPago();
        }

        public bool CNValidarOperacion(clsPlanPagoFechaValor fila)
        {
            bool resultado = false;
            try
            {
                DataTable dtResultado = clsADFechaValor.ADValidarOperacion(fila);
                if (dtResultado.Rows.Count > 0)
                {
                    resultado = Convert.ToBoolean(dtResultado.Rows[0]["lExiste"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar la operación: {ex.Message}");
            }
            return resultado;
        }

        public clsImpresionFechaValor CNValidarPlantilla(string xmlPlantilla, BackgroundWorker worker = null)
        {
            clsImpresionFechaValor objImpresionFechaValor = new clsImpresionFechaValor();
            List<clsPlantillaFechaValor> lsPlantillaFechaValor = new List<clsPlantillaFechaValor>();
            List<clsPlanPagoFechaValor> lsPlanPago = new List<clsPlanPagoFechaValor>();
            try
            {
                DataSet dsImpresionFechaValor = clsADFechaValor.ADValidarPlantilla(xmlPlantilla);

                //Valido si el dataset tiene datos
                if (dsImpresionFechaValor != null && dsImpresionFechaValor.Tables.Count > 0)
                {
                    // Determinar qué tabla contiene los datos a validar (tabla 0 o tabla 1)
                    int tablaDatosIndex = dsImpresionFechaValor.Tables[0].Rows.Count > 0 ? 0 : 1;

                    // Obtener el número total de filas a procesar
                    int totalFilas = dsImpresionFechaValor.Tables[tablaDatosIndex].Rows.Count;
                    int filasProcesadas = 0;

                    foreach (DataRow row in dsImpresionFechaValor.Tables[tablaDatosIndex].Rows)
                    {
                        if (tablaDatosIndex == 0)
                        {
                            lsPlantillaFechaValor.Add(row.ToObject<clsPlantillaFechaValor>());
                        }
                        else
                        {
                            lsPlanPago.Add(row.ToObject<clsPlanPagoFechaValor>());
                        }
                        // Reportar el progreso
                        if (worker != null)
                        {
                            filasProcesadas++;
                            int porcentaje = (int)(((double)filasProcesadas / totalFilas) * 100);
                            worker.ReportProgress(porcentaje);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar la plantilla: {ex.Message}");
            }
            finally
            {
                worker?.ReportProgress(100);
            }

            //Asigno las listas a la clase clsImpresionFechaValor
            objImpresionFechaValor.lsPlantilla = lsPlantillaFechaValor;
            objImpresionFechaValor.lsPlanPagos = lsPlanPago;
            return objImpresionFechaValor;
        }

        public List<clsRPTCabecereFechaValor> CNListarPagosRealizados(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            try
            {
                DataTable dtResultado = clsADFechaValor.ADListarPagosRealizados(dFechaDesde, dFechaHasta);
                return (List<clsRPTCabecereFechaValor>)dtResultado.ToList<clsRPTCabecereFechaValor>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar los pagos realizados: {ex.Message}");
            }
        }

        public DataTable CNListarDetallePagosRealizados(int idRegistro)
        {
            try
            {
                return clsADFechaValor.ADListarDetallePagosRealizados(idRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar el detalle de los pagos realizados: {ex.Message}");
            }
        }

        public List<clsArchivoCargadoFechaValor> CNListarSustentos(int idRegistro)
        {
            try
            {
                DataTable dtResultado = clsADFechaValor.ADListarSustentos(idRegistro);
                return (List<clsArchivoCargadoFechaValor>)dtResultado.ToList<clsArchivoCargadoFechaValor>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar los sustentos de los pagos realizados: {ex.Message}");
            }
        }
    }
}