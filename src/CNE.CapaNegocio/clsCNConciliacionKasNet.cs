using CNE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.CapaNegocio
{
    public class clsCNConciliacionKasNet
    {
        clsADConciliacionKasNet objADConciliacionKasNet;

        public clsCNConciliacionKasNet()
        {
            this.objADConciliacionKasNet = new clsADConciliacionKasNet();
        }

        public DataTable CNListarCargaArchivoFecha(DateTime dFechaCarga)
        {
            return this.objADConciliacionKasNet.ADListarCargaArchivoFecha(dFechaCarga);
        }

        public DataTable CNCargarArchivoConciliacion(DateTime dFechaRegistro, string dsConciliacion)
        {
            return this.objADConciliacionKasNet.ADCargarArchivoConciliacion(dFechaRegistro, dsConciliacion);
        }

        public DataTable CNListarPagosCarga(int idAPICargaConciTransacKasNet)
        {
            return this.objADConciliacionKasNet.ADListarPagosCarga(idAPICargaConciTransacKasNet);
        }

        public DataTable CNListarPagosConci(int idAPICargaConciTransacKasNet)
        {
            return this.objADConciliacionKasNet.ADListarPagosConci(idAPICargaConciTransacKasNet);
        }

        public DataTable CNListarPagosCore(DateTime dtFechaPago)
        {
            return this.objADConciliacionKasNet.ADListarPagosCore(dtFechaPago);
        }

        public DataTable CNListarBitacoraConciKasNet(DateTime dtFechaConci)
        {
            return this.objADConciliacionKasNet.ADListarBitacoraConciKasNet(dtFechaConci);
        }

        public DataTable CNGrabarBitacoraConciKasNet(DateTime dtFechaConci, string cEstado, string cDescripcion, string cWinUser)
        {
            return this.objADConciliacionKasNet.ADGrabarBitacoraConciKasNet(dtFechaConci, cEstado, cDescripcion, cWinUser);
        }
    }
}