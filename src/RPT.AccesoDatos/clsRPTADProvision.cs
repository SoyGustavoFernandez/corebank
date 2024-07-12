using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADProvision
    {
        public DataTable ADAnexo05(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05_sp", dFecha);
        }
        public DataTable ADAnexo05D_A(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05D_A_sp", dFecha);
        }
        public DataTable ADAnexo05D_B(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05D_B_sp", dFecha);
        }
        public DataTable ADAnexo05D_C(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05D_C_sp", dFecha);
        }
        public DataTable ADAnexo05D_D(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05D_D_sp", dFecha);
        }
        public DataTable ADAnexo05D_E(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05D_E_sp", dFecha);
        }
        public DataSet ADAnexo05A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05A_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_A_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_AP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_AP_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_B_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_C(DateTime dFecha,string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_C_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_CP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_CP_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_D(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_D_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_DP(DateTime dFecha,string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_DP_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_DPP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_DPP_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_E(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_E_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_F(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_F_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_G(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_G_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_H(DateTime dFecha,string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_H_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_I_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_J(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_J_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_K(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_K_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_V(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05_V_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05CredInd_V(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05CredIndirectos_V_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo05_W(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05CredIndirectos_W_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataTable ADAnexo05B_A(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05B_A_sp", dFecha);
        }
        public DataTable ADAnexo05B_B(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RPT_Anexo05B_B_sp", dFecha);
        }
        public DataSet ADAnexo05B_C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return new clsGENEjeSP().DSEjecSP("RPT_Anexo05B_C_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
    }
}
