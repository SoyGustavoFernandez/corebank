using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.AccesoDatos
{
    public class clsADConciliacionKasNet
    {
        private clsGENEjeSP objEjeSp;

        public clsADConciliacionKasNet()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ADListarCargaArchivoFecha(DateTime dFechaCarga)
        {
            return this.objEjeSp.EjecSP("CNE_ListarCargaArchivoFechaKasNet_SP", dFechaCarga);
        }

        public DataTable ADCargarArchivoConciliacion(DateTime dFechaRegistro, string dsConciliacion)
        {
            return this.objEjeSp.EjecSP("CNE_CargarArchivoConciliacionKasNet_SP", dFechaRegistro, dsConciliacion);
        }        
        
        public DataTable ADListarPagosCarga(int idAPICargaConciTransacKasNet)
        {
            return this.objEjeSp.EjecSP("CNE_ListarPagosCargaKasNet_SP", idAPICargaConciTransacKasNet);
        }
            
        public DataTable ADListarPagosConci(int idAPICargaConciTransacKasNet)
        {
            return this.objEjeSp.EjecSP("CNE_ListarPagosConciKasNet_SP", idAPICargaConciTransacKasNet);
        }

        public DataTable ADListarPagosCore(DateTime dtFechaPago)
        {
            return this.objEjeSp.EjecSP("CNE_ListarPagosCoreKasNet_SP", dtFechaPago);
        }

        public DataTable ADListarBitacoraConciKasNet(DateTime dtFechaConci)
        {
            return this.objEjeSp.EjecSP("CNE_ListarBitacoraConciKasNet_SP", dtFechaConci);
        }

        public DataTable ADGrabarBitacoraConciKasNet(DateTime dtFechaConci, string cEstado, string cDescripcion, string cWinUser)
        {
            return this.objEjeSp.EjecSP("CNE_GrabarBitacoraConciKasNet_SP", dtFechaConci, cEstado, cDescripcion, cWinUser);
        }
    }
}
