using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNT.AccesoDatos
{
    public class clsADProcesosAsientos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarProcAsientos()
        {
            return objEjeSp.EjecSP("CNT_ListaProcesosAsiento_sp");
        }
        public DataTable ReProcesoAsiento(string NombreSP, DateTime FecReproceso)
        {
            return objEjeSp.EjecSP( NombreSP, FecReproceso, 0);
        }
        public DataTable CargaProcesosCierreCNT(int nFrecuencia, DateTime FecProceso)
        {
            return objEjeSp.EjecSP("SI_CargaProcesosCierreCNT_sp",nFrecuencia, FecProceso);
        }
        public DataTable InsertaProcesosCierreCNT(int nFrecuencia, DateTime FecProceso)
        {
            return objEjeSp.EjecSP("SI_InsertaProcesosCierreCNT_sp", nFrecuencia, FecProceso);
        }
        public DataTable ProcesoCierre(string NombreSP, int idProceso, int nFrecuencia, DateTime FecReproceso)
        {
            return objEjeSp.EjecSP(NombreSP, idProceso, FecReproceso, nFrecuencia);
        }
        public DataTable ADCargarNotaEEFF(int idNotasEEFF, DateTime dPerContable, string cNomArchivo, string cExtension, byte[] Archivo, DateTime dFecha, int lVigente, string cDescripcion)
        {
            return objEjeSp.EjecSP("CNT_GuardarNotasEEFF_Sp", idNotasEEFF, dPerContable, cNomArchivo, cExtension, Archivo, dFecha, lVigente, cDescripcion);
        }
        public DataTable ADListarNotaEEFF(DateTime dFechaDesde,DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CNT_ListarNotasEEFF_Sp", dFechaDesde, dFechaHasta);
        }
    }
}
