using CNT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNT.CapaNegocio
{
    public class clsCNProcesosAsientos
    {
        clsADProcesosAsientos objctactb = new clsADProcesosAsientos();
        public DataTable ListarProcAsientos()
        {
            return objctactb.ListarProcAsientos();
        }
        public DataTable ReProcesoAsiento(string NombreSP, DateTime FecReproceso)
        {
            return objctactb.ReProcesoAsiento(NombreSP, FecReproceso);
        }
        public DataTable CargaProcesosCierreCNT(DateTime FecProceso, int nFrecuencia)
        {
            return objctactb.CargaProcesosCierreCNT(nFrecuencia, FecProceso);
        }
        public DataTable InsertaProcesosCierreCNT(DateTime FecProceso, int nFrecuencia)
        {
            return objctactb.InsertaProcesosCierreCNT(nFrecuencia, FecProceso);
        }
        public DataTable ProcesoCierre(string NombreSP, int idProceso, int nFrecuencia, DateTime FecReproceso)
        {
            return objctactb.ProcesoCierre(NombreSP, idProceso, nFrecuencia, FecReproceso);
        }
        public DataTable CNCargarNotaEEFF(int idNotasEEFF, DateTime dPerContable, string cNomArchivo, string cExtension, byte[] Archivo, DateTime dFecha, int lVigente, string cDescripcion)
        {
            return objctactb.ADCargarNotaEEFF(idNotasEEFF, dPerContable, cNomArchivo, cExtension, Archivo, dFecha, lVigente, cDescripcion);
        }
        public DataTable CNListarNotaEEFF(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objctactb.ADListarNotaEEFF(dFechaDesde,dFechaHasta);
        }
    }
}
