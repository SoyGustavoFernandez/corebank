using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;

namespace RPT.CapaNegocio
{
    public class clsRPTCNProvision
    {
        clsRPTADProvision ADProvision = new clsRPTADProvision();
        public DataTable CNAnexo05(DateTime dFecha)
        {
            return ADProvision.ADAnexo05(dFecha);
        }
        public DataTable CNAnexo05D_A(DateTime dFecha)
        {
            return ADProvision.ADAnexo05D_A(dFecha);
        }
        public DataTable CNAnexo05D_B(DateTime dFecha)
        {
            return ADProvision.ADAnexo05D_B(dFecha);
        }
        public DataTable CNAnexo05D_C(DateTime dFecha)
        {
            return ADProvision.ADAnexo05D_C(dFecha);
        }
        public DataTable CNAnexo05D_D(DateTime dFecha)
        {
            return ADProvision.ADAnexo05D_D(dFecha);
        }
        public DataTable CNAnexo05D_E(DateTime dFecha)
        {
            return ADProvision.ADAnexo05D_E(dFecha);
        }
        public DataTable CNAnexo05B_A(DateTime dFecha)
        {
            return ADProvision.ADAnexo05B_A(dFecha);
        }
        public DataTable CNAnexo05B_B(DateTime dFecha)
        {
            return ADProvision.ADAnexo05B_B(dFecha);
        }
        public DataSet CNAnexo05B_C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05B_C(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05A(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_A(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_AP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_AP(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_B(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_C(DateTime dFecha,string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_C(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_CP(DateTime dFecha,string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_CP(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_D(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_D(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_DP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_DP(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_DPP(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_DPP(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_E(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_E(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_F(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_F(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_G(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_G(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_H(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_H(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_I(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_J(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_J(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_K(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_K(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_V(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_V(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05CredInd_V(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05CredInd_V(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo05_W(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADProvision.ADAnexo05_W(dFecha, cReporteSBS, cAnexoSbs);
        }
    }
}
