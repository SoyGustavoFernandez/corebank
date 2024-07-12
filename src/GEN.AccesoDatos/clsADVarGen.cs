using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADVarGen
    {
        public void Listar(int nIDAgencia)
        {
            try
            {
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                List<clsVarGen> lisVars = new List<clsVarGen>();

                var query = objEjeSp.EjecSP("GEN_LisVarsGen_sp", nIDAgencia);
                foreach (DataRow dr in query.Rows)
                {
                    lisVars.Add(new clsVarGen()
                    {
                        idVariable = (int)dr["idVariable"],
                        cVariable = (string)dr["cVariable"],
                        cValVar = (string)dr["cValVar"],
                        cTipoVariable = (string)dr["cTipoVariable"],
                        lVigente = (bool)dr["lVigente"],
                        cDescripcion = (string)dr["cDescripcion"],
                        nidAgencia = (int)dr["nidAgencia"],
                      
                    });
                }
                clsVarGlobal.lisVars.AddRange(lisVars);

                //Fecha Actual del sistema (fecha servidor)
                DateTime fecha = Convert.ToDateTime((from r in lisVars
                                                     where r.cVariable == "dFechaAct"
                                                     select r.cValVar).Min());

                string cURLReport = Convert.ToString((from r in lisVars
                                                     where r.cVariable == "cURLReport"
                                                     select r.cValVar).Min());

                string cNomImpTer = Convert.ToString((from r in lisVars
                                                      where r.cVariable == "cNomImpTer"
                                                      select r.cValVar).Min());
                string cNomAge = Convert.ToString((from r in lisVars
                                                   where r.cVariable == "cNomAge"
                                                      select r.cValVar).Min());
                decimal nITF = Convert.ToDecimal((from r in lisVars
                                                  where r.cVariable == "nITF"
                                                  select r.cValVar).Min());

                clsVarGlobal.dFecSystem = fecha;
                clsVarGlobal.cURLReport = cURLReport;
                clsVarGlobal.cNomImpTer = cNomImpTer;
                clsVarGlobal.cNomAge = cNomAge;
                clsVarGlobal.nITF = nITF;
                //clsVarGlobal.nIdAgencia = 1;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GetVarGlobal(int idAgencia,clsVarGlobalClone objVarGlobal)
        {
            try
            {
                clsGENEjeSP objEjeSp = new clsGENEjeSP();
                List<clsVarGen> lisVars = new List<clsVarGen>();

                var query = objEjeSp.EjecSP("GEN_LisVarsGen_sp", idAgencia);
                foreach (DataRow dr in query.Rows)
                {
                    lisVars.Add(new clsVarGen()
                    {
                        idVariable = (int)dr["idVariable"],
                        cVariable = (string)dr["cVariable"],
                        cValVar = (string)dr["cValVar"],
                        cTipoVariable = (string)dr["cTipoVariable"],
                        lVigente = (bool)dr["lVigente"],
                        cDescripcion = (string)dr["cDescripcion"],
                        nidAgencia = (int)dr["nidAgencia"],

                    });
                }
                objVarGlobal.lisVars.AddRange(lisVars);

                DateTime fecha = Convert.ToDateTime((from r in lisVars
                                                     where r.cVariable == "dFechaAct"
                                                     select r.cValVar).Min());

                string cURLReport = Convert.ToString((from r in lisVars
                                                      where r.cVariable == "cURLReport"
                                                      select r.cValVar).Min());

                string cNomImpTer = Convert.ToString((from r in lisVars
                                                      where r.cVariable == "cNomImpTer"
                                                      select r.cValVar).Min());
                string cNomAge = Convert.ToString((from r in lisVars
                                                   where r.cVariable == "cNomAge"
                                                   select r.cValVar).Min());
                decimal nITF = Convert.ToDecimal((from r in lisVars
                                                  where r.cVariable == "nITF"
                                                  select r.cValVar).Min());

                objVarGlobal.dFecSystem = fecha;
                objVarGlobal.cURLReport = cURLReport;
                objVarGlobal.cNomImpTer = cNomImpTer;
                objVarGlobal.cNomAge = cNomAge;
                objVarGlobal.nITF = nITF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
