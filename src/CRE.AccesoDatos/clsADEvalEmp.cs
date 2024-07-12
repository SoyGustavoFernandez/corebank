using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADEvalEmp
    {
     
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet ADdsEvalEmp(int IdEvalEmp)
        {
            try
            {
                return objEjeSp.DSEjecSP("Cre_BusEvaEmpresarial_Sp", IdEvalEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtEvalEmp(int IdEvalEmp)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusEvaEmpr_Sp", IdEvalEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtEvalEmpIdCliente(int IdCliente)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusEvaEmprCliente_Sp", IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtDetEvalEmp(int IdEvalEmp)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusDetEvaEmpr_Sp", IdEvalEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtCosteoDetalleEvalEmp(int IdEvalEmp)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusCosteoDetEvaEmpr_Sp", IdEvalEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtDetCreNegocio(int IdEvalEmpr, int IdPerteneceDeuda)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusDetCredNegEvaEmpr_Sp", IdEvalEmpr, IdPerteneceDeuda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtDetGastPersonal(int IdEvalEmpr)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusDetGastPersEvaEmpr_Sp", IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtDetGastNeg(int IdEvalEmpr, int IdPerteneceDeuda)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusDetGastosNegoEvaEmpr_Sp", IdEvalEmpr, IdPerteneceDeuda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtBalance(int IdEvalEmpr)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusBalGenEvaEmp_Sp", IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtEstPerGanan(int IdEvalEmpr)
        {
            try
            {
                if (IdEvalEmpr == 0)
                {
                    return objEjeSp.EjecSP("Cre_BusPlantiEstPerdGan_Sp");
                }
                else
                {
                    return objEjeSp.EjecSP("Cre_BusEstPerdGanEvaEmp_Sp", IdEvalEmpr);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtFotosEvaEmp(int IdEvalEmpr)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusFotosEvaEmp_Sp", IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtIntervEvaEmp(int IdEvalEmpr)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_BusIntervEvaEmp_Sp", IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtRegEvalEmpr(string xmlEvaEmpr, string xmlDetEvaEmpr, string xmlCosteoEvaEmpr,string xmlCredNeg,
                                        string xmlCredUniFam,string xmlGastPersonal,string xmlGastNeg,string xmlGastUniFam,
                                        string xmlBalGeneral, string xmlEstPerdGanan, string xmlDetFotos, string xmlDetInterv,
                                        string xmlDetGarant, string xmlPorcentVariacionFlujoCaja, string xmlFlujoCaja, int idNumEva)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_RegEvaEmpr_Sp", xmlEvaEmpr, xmlDetEvaEmpr, xmlCosteoEvaEmpr,xmlCredNeg,
                                        xmlCredUniFam,xmlGastPersonal,xmlGastNeg,xmlGastUniFam,xmlBalGeneral,
                                        xmlEstPerdGanan, xmlDetFotos, xmlDetInterv,xmlDetGarant,
                                        xmlPorcentVariacionFlujoCaja, xmlFlujoCaja, idNumEva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtActRutasFotos(int IdEval, string xmlDetFotos)
        {
            try
            {
                return objEjeSp.EjecSP("Cre_ActRutasFotos_Sp", IdEval, xmlDetFotos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLstTipoGiro()
        {
            try
            {
                return objEjeSp.EjecSP("Gen_ListarTipoGiro_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLstTipoIngresos()
        {
            try
            {
                return objEjeSp.EjecSP("Gen_ListarTipoIngreso_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLstMetCosteo()
        {
            try
            {
                return objEjeSp.EjecSP("Gen_ListarMetCosteo_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLstUnidadMed()
        {
            try
            {
                return objEjeSp.EjecSP("Gen_ListarUnidadMed_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLstMoneda()
        {
            try
            {
                return objEjeSp.EjecSP("Cre_LstMonedaEvaEmp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ADdsObtenerParametrosFlujoCajaEvalEmp()
        {
            try
            {
                return objEjeSp.DSEjecSP("CRE_ObtenerParametrosFlujoCajaEvalEmp_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CNdtInsertarParametrosFlujoCajaEvalEmp(string XmlParametrosFlujoCaja)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_InsUpdParametrosFlujoCajaEvalEmp_Sp", XmlParametrosFlujoCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
