using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

using System.Windows.Forms;
using EntityLayer;
using System.Collections.Generic;

namespace GEN.CapaNegocio
{
    public class clsCNValidaReglaConfig
    {
        public clsADValidaReglasDinamicas ReglasDinamicas = new clsADValidaReglasDinamicas();

        public DataTable CNObtenerListaReglasConfig(String cNombreFormulario, int nTipoEvalConfig)
        {
            return ReglasDinamicas.ADObtenerListaReglasConfig(cNombreFormulario, nTipoEvalConfig);
        }
        public DataTable CNObtenerListaFuncionesConfig(String cNombreFormulario, int nTipoEvalConfig)
        {
            return ReglasDinamicas.ADObtenerListaFuncionesConfig(cNombreFormulario, nTipoEvalConfig);
        }

        public string ValidarReglasConfig(DataTable dtTablaParametros, string cNombreFormulario, int nTipoEvalConfig)
        {
            string cResultadoValidacion = "NO";
            DataTable dtReglas = ObtenerReglasConfig(dtTablaParametros, cNombreFormulario, nTipoEvalConfig);
            int nCantReglasNegocio = 0;
  
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (!dtReglas.Rows[f]["lResul"].ToString().Equals("OK"))
                {
                    nCantReglasNegocio++;
                }
            }
            if (nCantReglasNegocio == 0)
            {
                cResultadoValidacion = "OK";
            }
            return cResultadoValidacion;
        }

        public DataTable ObtenerReglasConfig(DataTable dtTablaParametros, string cNombreFormulario, int nTipoEvalConfig)
        {
            foreach (DataColumn dcColumna in dtTablaParametros.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            DataTable dtTablaFunciones = CNObtenerListaFuncionesConfig(cNombreFormulario, nTipoEvalConfig);
            foreach (DataColumn dcColumna in dtTablaFunciones.Columns)
            {
                dcColumna.ReadOnly = false;
            }
            DataTable dtTablaReglas = CNObtenerListaReglasConfig(cNombreFormulario, nTipoEvalConfig);
            foreach (DataColumn dcColumna in dtTablaReglas.Columns)
            {
                dcColumna.ReadOnly = false;
            }
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                string cNomCampo = dtTablaParametros.Rows[i]["cNombreCampo"].ToString();
                string cValorCampo = dtTablaParametros.Rows[i]["cValorCampo"].ToString();

                for (int f = 0; f < dtTablaFunciones.Rows.Count; f++)
                {
                    dtTablaFunciones.Rows[f]["cFunRemplazado"] = ReemplazarParametrosEnFuncion(dtTablaFunciones.Rows[f][3].ToString(), cNomCampo, cValorCampo);
                }
            }

            DataSet dsFunciones = new DataSet("dsFunciones");
            dtTablaFunciones.TableName = "dtFunciones";
            dsFunciones.Tables.Add(dtTablaFunciones);
            var xmlFunciones = dsFunciones.GetXml();
            dtTablaFunciones = asignarValoresAFunciones(xmlFunciones);


            for (int i = 0; i < dtTablaFunciones.Rows.Count; i++)
            {
                string cNomFuncion = dtTablaFunciones.Rows[i]["cFuncion"].ToString();
                string cValorFuncion = dtTablaFunciones.Rows[i]["cValorFun"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    if (dtTablaReglas.Rows[f]["cReglaConfig"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        dtTablaReglas.Rows[f]["cReglaRemplazado"] = dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString().Replace(cNomFuncion, cValorFuncion);
                    }
                    if (dtTablaReglas.Rows[f]["cCaracteristica"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        dtTablaReglas.Rows[f]["cCaracteristica"] = dtTablaReglas.Rows[f]["cCaracteristica"].ToString().Replace(cNomFuncion, cValorFuncion);

                    }
                }
            }
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                string cNomCampo = dtTablaParametros.Rows[i]["cNombrecampo"].ToString();
                string cValorCampo = dtTablaParametros.Rows[i]["cValorcampo"].ToString();
                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    dtTablaReglas.Rows[f]["cCaracteristica"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cCaracteristica"].ToString(), cNomCampo, cValorCampo);
                    dtTablaReglas.Rows[f]["cReglaRemplazado"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString(), cNomCampo, cValorCampo);
                }
            }

            DataTable dtEvaluarExpresionLogica = new DataTable();
            for (int i = 0; i < dtTablaReglas.Rows.Count; i++)
            {
                if (dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim().Equals("1"))
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cReglaRemplazado"].ToString().Trim(), "")))
                    {
                        dtTablaReglas.Rows[i]["lResul"] = "OK";
                    }
                    else
                    {
                        dtTablaReglas.Rows[i]["lResul"] = "NO";
                    }
                }
                else
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim(), "")))
                    {
                        if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cReglaRemplazado"].ToString().Trim(), "")))
                        {
                            dtTablaReglas.Rows[i]["lResul"] = "OK";
                        }
                        else
                        {
                            dtTablaReglas.Rows[i]["lResul"] = "NO";
                        }
                    }
                    else
                    {
                        dtTablaReglas.Rows[i]["lResul"] = "NA";
                    }
                }
            }
            return dtTablaReglas;
        }
        private DataTable asignarValoresAFunciones(string xmlFunciones)
        {
            return ReglasDinamicas.asignarValoresAFuncionesConfig(xmlFunciones);
        }
        private string ReemplazarParametrosEnFuncion(string cCadenaFuncion, string cNombreParametro, string cValorParametro)
        {
            string cResultReemplazo = "";
            cCadenaFuncion = cCadenaFuncion.Replace(" ", "");
            string cNombreFuncion = cCadenaFuncion.Substring(0, cCadenaFuncion.IndexOf('('));
            string cParametrosFuncion = cCadenaFuncion.Substring(cCadenaFuncion.IndexOf('(') + 1, cCadenaFuncion.Length - cCadenaFuncion.IndexOf('(') - 2);

            string[] cParametros = cParametrosFuncion.Split(',');

            if (cParametros.Length != 0)
            {
                for (int i = 0; i < cParametros.Length; i++)
                {
                    if (cParametros[i].Equals(cNombreParametro))
                    {
                        cParametros[i] = cValorParametro;
                    }
                    cResultReemplazo = cResultReemplazo + cParametros[i];
                    if (i + 1 < cParametros.Length)
                    {
                        cResultReemplazo = cResultReemplazo + ",";
                    }
                }
            }
            cResultReemplazo = cNombreFuncion + "(" + cResultReemplazo + ")";
            return cResultReemplazo;
        }
        private string ReemplazarCamposEnReglas(string cCadenaRegla, string cNombreCampo, string cValorCampo)
        {
            int nContCaracter;
            cCadenaRegla = cCadenaRegla.ToUpper();
            cNombreCampo = cNombreCampo.ToUpper();
            int nSwitch = 0;  
            int nPosicion = 0;
            int cCantPosiblesCampos = 0; 
            string cCadenaAuxiliar = cCadenaRegla;
            while (nSwitch == 0)
            {
                nPosicion = cCadenaAuxiliar.IndexOf(cNombreCampo);
                if (nPosicion > 0 && nPosicion <= cCadenaRegla.Length)
                {
                    cCadenaAuxiliar = cCadenaAuxiliar.Substring(nPosicion + cNombreCampo.Length, cCadenaAuxiliar.Length - (nPosicion + cNombreCampo.Length));
                    cCantPosiblesCampos++;
                }
                else
                {
                    nSwitch++;
                }
            }

            cCadenaAuxiliar = cCadenaRegla;
            nContCaracter = 0;
            string cCadCambios = cCadenaRegla.Substring(0, 0);
            for (int i = 0; i < cCantPosiblesCampos; i++)
            {
                int indiceUbicacion = cCadenaAuxiliar.IndexOf(cNombreCampo);
                string cAntesCampo = CaracterAntes(cCadenaAuxiliar, indiceUbicacion);
                if (CompararCaracter(cAntesCampo))
                {
                    string cDespuesCampo = CaracterDespues(cCadenaAuxiliar, indiceUbicacion, cNombreCampo);
                    if (CompararCaracter(cDespuesCampo))
                    {
                        cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion) + cValorCampo;
                        cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + cNombreCampo.Length, cCadenaAuxiliar.Length - (indiceUbicacion + cNombreCampo.Length));
                    }
                    else
                    {
                        nContCaracter = 1;
                        nSwitch = 0;
                        while (nSwitch == 0)
                        {
                            string cAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion, cNombreCampo.Length + nContCaracter);
                            string cCaracter = cCadenaAuxiliar.Substring(indiceUbicacion + cAuxiliar.Length, 1);
                            if (CompararCaracter(cCaracter))
                            {
                                cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion) + cAuxiliar;
                                cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + cAuxiliar.Length, cCadenaAuxiliar.Length - (indiceUbicacion + cAuxiliar.Length));
                                nSwitch++;
                            }
                            else
                            {
                                nContCaracter++;
                            }
                        }
                    }
                }
                else
                {
                    nContCaracter = 0;
                    nSwitch = 0;
                    while (nSwitch == 0)
                    {
                        string auxiliar = cCadenaAuxiliar.Substring(indiceUbicacion, cNombreCampo.Length + nContCaracter);
                        string cCaracter = cCadenaAuxiliar.Substring(indiceUbicacion + auxiliar.Length, 1);
                        if (CompararCaracter(cCaracter))
                        {
                            cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion + cNombreCampo.Length + nContCaracter);
                            cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + auxiliar.Length, cCadenaAuxiliar.Length - (indiceUbicacion + auxiliar.Length));
                            nSwitch++;
                        }
                        else
                        {
                            nContCaracter++;
                        }
                    }
                }
            }
            cCadCambios = cCadCambios + cCadenaAuxiliar;
            return cCadCambios;
        }
        private string CaracterAntes(string cCadena, int nPosicion)
        {
            return cCadena.Substring(nPosicion - 1, 1);
        }
        private bool CompararCaracter(string cCaracter)
        {
            if (cCaracter.In("(", ")", "+", "-", "*", "/", "%", "=", ">", "<", " "))
            {
                return true;
            }
            else return false;
        }
        private string CaracterDespues(string cCadena, int nPosicion, string cNombreCampo)
        {
            return cCadena.Substring(nPosicion + cNombreCampo.Length, 1);
        }


    }
}
