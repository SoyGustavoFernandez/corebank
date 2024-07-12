using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace CNT.AccesoDatos
{
    public class clsADAccionistaEmp
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListaAccionesRegistrasdas(int idCli)
        {
            return objEjeSp.EjecSP("CNT_ListaAccionesEmpresa_sp", idCli);
        }

        public DataTable ADRegistraAccionesEmp(int idAccioneEmp, int idCli, int idTipoAccionesEmp, int idTipoAccionEmp, decimal nNroAcciones,
            decimal nValNominal, string cObservaciones, int idUsuario, DateTime dFecAdquisicion, DateTime dFechaOpe, bool lVigente, int nNroFolio,
            string cCodAccionista, string cDescAccionista, decimal nPorcParticipacion, int nTipoEmision, int idTipoOperacionAccion)
        {
            return objEjeSp.EjecSP("CNT_RegistrasAccionesEmp_Sp", idAccioneEmp, idCli, idTipoAccionesEmp, idTipoAccionEmp, nNroAcciones, nValNominal,
                cObservaciones, idUsuario, dFecAdquisicion, dFechaOpe, lVigente, nNroFolio, cCodAccionista, cDescAccionista, nPorcParticipacion, nTipoEmision, idTipoOperacionAccion);
        }
        public DataTable ADListaTipoEmisionAccione()
        {
            return objEjeSp.EjecSP("CNT_ListaTipoEmisionAcc_Sp");
        }
        public DataTable ADListaTipoOperacionAccion()
        {
            return objEjeSp.EjecSP("CNT_ListaTipoOperacionAccion_Sp");
        }

        public DataTable ADListaAccionistas()
        {
            return objEjeSp.EjecSP("CNT_ListaAccionistas_SP");
        }
    }
}
