using SolIntEls.GEN.Helper;
using System.Data;
using System;
using System.Data.SqlClient;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADFechaValor
    {
        clsGENEjeSP objGENEjeSP = new clsGENEjeSP();

        public void ADInsArchivoSustento(string cNombreArchivo, byte[] cByteArchivo, string extension, int idUsuario, int idCabecera)
        {
            try
            {
                objGENEjeSP.EjecSP("CRE_InsArchivoSustentoFechaValor_SP", cNombreArchivo, cByteArchivo, extension, idUsuario, idCabecera);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADInsPagoFechaValor(string nombrePlantilla, byte[] archivoPlantilla, int idUsuario, int idMotivo, string txtSustento, string xmlDetalle)
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_InsPagoFechaValor_SP", xmlDetalle, nombrePlantilla, archivoPlantilla, idUsuario, idMotivo, txtSustento);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADListarMotivosPago()
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_ListaMotivosPagoFechaValor_SP");
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADValidarOperacion(clsPlanPagoFechaValor fila)
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_ValidaOperacionFechaValor_SP", fila.nNumeroCredito, fila.nNumeroOperacionCanalExterno);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataSet ADValidarPlantilla(string xmlPlantilla)
        {
            try
            {
                return objGENEjeSP.DSEjecSP("CRE_ValidaPlantillFechaValor_SP", xmlPlantilla);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADListarPagosRealizados(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_RPTFechaValor_SP", dFechaDesde, dFechaHasta);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADListarDetallePagosRealizados(int idRegistro)
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_RPTDetalleFechaValor_SP", idRegistro);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }

        public DataTable ADListarSustentos(int idRegistro)
        {
            try
            {
                return objGENEjeSP.EjecSP("CRE_RPTSustentosFechaValor_SP", idRegistro);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado en la base de datos : {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la capa de datos al procesar la solicitud: {ex}");
            }
        }
    }
}