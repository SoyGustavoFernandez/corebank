using CRE.AccesoDatos;
using EntityLayer;
using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEvalEmp
    {

        public DataSet CNdsEvalEmpr(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdsEvalEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtEvalEmpr(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtEvalEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtEvalEmprIdCliente(int IdCliente)
        {
            try
            {
                return new clsADEvalEmp().ADdtEvalEmpIdCliente(IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtDetEvalEmpr(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtDetEvalEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtCosteoDetalleEvalEmpr(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtCosteoDetalleEvalEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtDetCreNegocio(int IdEvalEmpr, int IdPerteneceDeuda)
        {
            try
            {
                return new clsADEvalEmp().ADdtDetCreNegocio(IdEvalEmpr,IdPerteneceDeuda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtDetGastPersonal(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtDetGastPersonal(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtDetGastNeg(int IdEvalEmpr, int IdPerteneceDeuda)
        {
            try
            {
                return new clsADEvalEmp().ADdtDetGastNeg(IdEvalEmpr, IdPerteneceDeuda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtBalance(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtBalance(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtEstPerGanan(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtEstPerGanan(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtFotosEvaEmp(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtFotosEvaEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtIntervEvaEmp(int IdEvalEmpr)
        {
            try
            {
                return new clsADEvalEmp().ADdtIntervEvaEmp(IdEvalEmpr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtRegEvalEmpr(string xmlEvaEmpr, string xmlDetEvaEmpr, string xmlCosteoEvaEmpr, string xmlCredNeg,
                                        string xmlCredUniFam, string xmlGastPersonal, string xmlGastNeg, string xmlGastUniFam,
                                        string xmlBalGeneral, string xmlEstPerdGanan, string xmlDetFotos, string xmlDetInterv,
                                        string xmlDetGarant,
                                        string xmlPorcentVariacionFlujoCaja, string xmlFlujoCaja, int idNumEva)
        {
            try
            {
                return new clsADEvalEmp().ADdtRegEvalEmpr(xmlEvaEmpr, xmlDetEvaEmpr, xmlCosteoEvaEmpr, xmlCredNeg,
                                                            xmlCredUniFam, xmlGastPersonal, xmlGastNeg, xmlGastUniFam,
                                                            xmlBalGeneral, xmlEstPerdGanan, xmlDetFotos, xmlDetInterv,
                                                            xmlDetGarant,
                                                            xmlPorcentVariacionFlujoCaja, xmlFlujoCaja, idNumEva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtActRutasFotos(int IdEval, string xmlDetFotos)
        {
            try
            {
                return new clsADEvalEmp().ADdtActRutasFotos(IdEval, xmlDetFotos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtListEvalEmprCre(int IdClient)
        {
            try
            {
                clsADSolicitud CNlistEvalEmpr = new clsADSolicitud();
                DataTable dtCNdtListEvalEmprCre = CNlistEvalEmpr.ADdtLisEvaEmprCre(IdClient);
                return dtCNdtListEvalEmprCre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtLstTipoGiro()
        {
            try
            {
                return new clsADEvalEmp().ADdtLstTipoGiro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtLstTipoIngresos()
        {
            try
            {
                return new clsADEvalEmp().ADdtLstTipoIngresos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtLstMetCosteo()
        {
            try
            {
                return new clsADEvalEmp().ADdtLstMetCosteo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtLstUnidadMed()
        {
            try
            {
                return new clsADEvalEmp().ADdtLstUnidadMed();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtLstMoneda()
        {
            try
            {
                return new clsADEvalEmp().ADdtLstMoneda();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CNdsObtenerParametrosFlujoCajaEvalEmp()
        {
            try
            {
                return new clsADEvalEmp().ADdsObtenerParametrosFlujoCajaEvalEmp();
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
                return new clsADEvalEmp().CNdtInsertarParametrosFlujoCajaEvalEmp(XmlParametrosFlujoCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
