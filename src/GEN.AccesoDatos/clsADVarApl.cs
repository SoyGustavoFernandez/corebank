using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADVarApl
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void Listar(int nIDAgencia)
        {   
            string cVariable;
            dynamic dnValor;

            clsVarApl.dicVarGen.Clear();

            var query = objEjeSp.EjecSP("GEN_LisVarsGen_sp", nIDAgencia);
            foreach (DataRow dr in query.Rows)
            {
                cVariable = dr["cVariable"].ToString();
                
                switch (dr["cTipoVariable"].ToString().ToLower())
                {
                    case "string": 
                        dnValor = Convert.ToString(dr["cValVar"]);
                        break;
                    case "int":
                        dnValor = Convert.ToInt32(dr["cValVar"]);
                        break;
                    case "decimal":
                        dnValor = Convert.ToDecimal(dr["cValVar"]);
                        break;
                    case "numeric":
                        dnValor = Convert.ToDecimal(dr["cValVar"]);
                        break;
                    case "datetime":
                        dnValor = Convert.ToDateTime(dr["cValVar"]);
                        break;
                    case "boolean":
                        dnValor = Convert.ToBoolean(dr["cValVar"]);
                        break;
                    default:
                        dnValor = Convert.ToString(dr["cValVar"]);
                        break;
                }
                clsVarApl.dicVarGen.Add(cVariable, dnValor);
            }
        }

        public void GetVarApl(int nIDAgencia,clsVarAplClone objVarApl)
        {
            string cVariable;
            dynamic dnValor;

            objVarApl.dicVarGen.Clear();

            var query = objEjeSp.EjecSP("GEN_LisVarsGen_sp", nIDAgencia);
            foreach (DataRow dr in query.Rows)
            {
                cVariable = dr["cVariable"].ToString();

                switch (dr["cTipoVariable"].ToString().ToLower())
                {
                    case "string":
                        dnValor = Convert.ToString(dr["cValVar"]);
                        break;
                    case "int":
                        dnValor = Convert.ToInt32(dr["cValVar"]);
                        break;
                    case "decimal":
                        dnValor = Convert.ToDecimal(dr["cValVar"]);
                        break;
                    case "numeric":
                        dnValor = Convert.ToDecimal(dr["cValVar"]);
                        break;
                    case "datetime":
                        dnValor = Convert.ToDateTime(dr["cValVar"]);
                        break;
                    case "boolean":
                        dnValor = Convert.ToBoolean(dr["cValVar"]);
                        break;
                    default:
                        dnValor = Convert.ToString(dr["cValVar"]);
                        break;
                }
                objVarApl.dicVarGen.Add(cVariable, dnValor);
            }
        }
    }
}
