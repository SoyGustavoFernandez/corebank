using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using EntityLayer;

namespace SPL.AccesoDatos
{
    public class clsADUmbralSPLAFT
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        DataTable ds = new DataTable();

        public DataTable listarUmbral(int tipo, int idTipoOperacion)
        {
            ds = objEjeSp.EjecSP("GEN_ListaUmbralSPL", tipo, clsVarGlobal.nIdAgencia, idTipoOperacion);       
            return ds;
        }


        public void insertarUmbral(int idUmbral, int idAgencia, int nTipoUmbral, decimal nValor, DateTime dFechaInicio, DateTime dFechaFin, string cTipoOperaciones)
        {
            objEjeSp.EjecSP("GEN_InsertarUmbralSPL_SP", idUmbral, idAgencia, nTipoUmbral, nValor, dFechaInicio, dFechaFin, cTipoOperaciones);
        }
        public DataTable ListarTipoOperaciones()
        {
            return objEjeSp.EjecSP("SPL_RetornoTipoOperaciones_SP");
        }
        public DataTable ListarUmbralIdAgencia(int nTipoUmbral, int idAgencia, int idTipoOperacion)
        {
            return objEjeSp.EjecSP("GEN_ListaUmbralSPL", nTipoUmbral, idAgencia, idTipoOperacion);
        }
        public DataTable retornoUmbralPorId(int idUmbral)
        {
            return objEjeSp.EjecSP("SPL_RetornoUmbralPorId_SP", idUmbral);
        }
        public DataTable ListarTipoOperacionesPorIdUmbral(int idUmbral)
        {
            return objEjeSp.EjecSP("SPL_RetornoDetalleUmbral_SP", idUmbral);
        }
        public DataTable ADValidandoUmbralExistente(int idUmbral, int nTipoUmbral, int idAgencia, DateTime dFechaInicio, DateTime dFechaFin, string cTipoOpe)
        {
            return objEjeSp.EjecSP("SPL_ValidandoUmbralExistente_SP", idUmbral, nTipoUmbral, idAgencia, dFechaInicio, dFechaFin, cTipoOpe);
        }

        public DataTable ADListarUmbralKardex(int idTipoUmbral, int idKardex)
        {
            return objEjeSp.EjecSP("GEN_ListaUmbralSPLKardex_SP", idTipoUmbral, clsVarGlobal.nIdAgencia, idKardex);
        }
        public DataTable ListarTipoOperacionesUlt()
        {
            return objEjeSp.EjecSP("SPL_RetornoTipoOperacionesUlt_SP");
        }
        public DataTable ListarTipoOperacionesPorIdUmbralUlt(int idUmbral)
        {
            return objEjeSp.EjecSP("SPL_RetornoDetalleUmbralUlt_SP", idUmbral);
        }
    }
}
