using EntityLayer;
using GEN.Funciones;
using System;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using System.Collections.Generic;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsCNValidaReglasDinamicas
    {
        int nValidacionInterna = 0;
        public string cMensajeErrores = String.Empty;
        public clsADValidaReglasDinamicas ReglasDinamicas ;
        List<Tuple<int, string, int>> listTiposEvaluacionPresencialRemota = new List<Tuple<int, string, int>>();
        public clsCNValidaReglasDinamicas(bool lWebService)
        {
            ReglasDinamicas = new clsADValidaReglasDinamicas(lWebService);
        }

        public clsCNValidaReglasDinamicas()
        {
            ReglasDinamicas = new clsADValidaReglasDinamicas();
        }

        public DataTable ObtenerReglasConResultado(DataTable dtTablaParametros, string cNombreFormulario)
        {
            foreach (DataColumn dcColumna in dtTablaParametros.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las funciones de Base datos (Tabla SI_FinDetFunxRegla)
            //Estructura:   nIdFuncion  nIdOpcion   cFuncion    cFunRemplazado= cFuncion  cValorFun
            DataTable dtTablaFunciones = ObtenerFuncionesParaReglasDinamicas(cNombreFormulario);
            foreach (DataColumn dcColumna in dtTablaFunciones.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las reglas de Base datos (Tabla SI_FinReglas)
            //Estructura: nIdRegla  nIdOpcion   cCaracteristica cReglaNegocio   cMensajeError   lIndExcepcion   idUsuRegist   dFecRegist    idTipoOperacion cAuditUser  cAuditStation   cAuditClient    dAuditDate  lResul= 'OK' cReglaRemplazado= cReglaNegocio
            DataTable dtTablaReglas = ObtenerReglasReglasDinamicas(cNombreFormulario, 0);
            foreach (DataColumn dcColumna in dtTablaReglas.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //Recorrer la tabla de 'PARAMETROS A VALIDAR' y, reemplazar los parametros por valores en la tabla de FUNCIONES  (Tabla SI_FinDetFunxRegla)
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombreCampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorCampo"].ToString();

                for (int f = 0; f < dtTablaFunciones.Rows.Count; f++)
                {
                    //reemplazar en las funciones los parametros por valores
                    dtTablaFunciones.Rows[f]["cFunRemplazado"] = ReemplazarParametrosEnFuncion(dtTablaFunciones.Rows[f][3].ToString(), cNomCampo, cValorCampo);
                }
            }

            //asigna los valores en la base de datos y devuelve con los valores calculados
            DataSet dsFunciones = new DataSet("dsFunciones");
            dtTablaFunciones.TableName = "dtFunciones";
            dsFunciones.Tables.Add(dtTablaFunciones);
            var xmlFunciones = dsFunciones.GetXml();
            dtTablaFunciones = asignarValoresAFunciones(xmlFunciones);


            //Recorrer la tabla de REGLAS (Tabla SI_FinReglas) en funcion del numero de funciones, y reemplazar el valor de las funciones en tabla REGLAS
            for (int i = 0; i < dtTablaFunciones.Rows.Count; i++)
            {
                //obteniendo el nombreCampo -- cFuncion
                string cNomFuncion = dtTablaFunciones.Rows[i]["cFuncion"].ToString();
                //obteniendo el valorCampo -- cValorFun
                string cValorFuncion = dtTablaFunciones.Rows[i]["cValorFun"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //nIdRegla, nIdOpcion, cReglaNegocio, cReglaRemplazado = cReglaNegocio, lResul = 'OK'
                    if (dtTablaReglas.Rows[f]["cReglaNegocio"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en las reglas el valor de las funciones
                        dtTablaReglas.Rows[f]["cReglaRemplazado"] = dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString().Replace(cNomFuncion, cValorFuncion);
                    }
                    if (dtTablaReglas.Rows[f]["cCaracteristica"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en caracteristica de las reglas
                        dtTablaReglas.Rows[f]["cCaracteristica"] = dtTablaReglas.Rows[f]["cCaracteristica"].ToString().Replace(cNomFuncion, cValorFuncion);

                    }
                }
            }

            //Recorrer la tabla 'PARAMETROS A VALIDAR' y reemplazar los campos faltantes en la tabla REGLAS
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombrecampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorcampo"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //reemplazar en las reglas los valores de los campos faltantes
                    //Hacer el reemplazo en los campos: cCaracteristica y cReglaRemplazado
                    dtTablaReglas.Rows[f]["cCaracteristica"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cCaracteristica"].ToString(), cNomCampo, cValorCampo);
                    dtTablaReglas.Rows[f]["cReglaRemplazado"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString(), cNomCampo, cValorCampo);
                }
            }

            DataTable dtEvaluarExpresionLogica = new DataTable();

            //Recorrer la tabla REGLAS y calcular(verificar) el resultado de la validacion de cada regla
            for (int i = 0; i < dtTablaReglas.Rows.Count; i++)
            {
                //Evaluar los campos de caracterización si es 1: quiere decir que no se debe trabajar con este campo sino con ["cReglaRemplazado"]
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
                else//Si el campo es diferente de 1: se sebe trabajar con el campo ["cCaracteristica"] y ["cReglaRemplazado"]
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim(), "")))
                    {
                        //Evaluar las Reglas
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

        public DataTable ObtenerReglasCondicionesResultado(DataTable dtTablaParametros, string cNombreFormulario,string cTipoPersona)
        {
            foreach (DataColumn dcColumna in dtTablaParametros.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las funciones de Base datos (Tabla SI_FinDetFunxRegla)
            //Estructura:   nIdFuncion  nIdOpcion   cFuncion    cFunRemplazado= cFuncion  cValorFun
            DataTable dtTablaFunciones = ObtenerFuncionesParaReglasDinamicas(cNombreFormulario);
            foreach (DataColumn dcColumna in dtTablaFunciones.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las reglas de Base datos (Tabla SI_FinReglas)
            DataTable dtTablaReglas = ObtenerReglasReglasDinamicasCondiciones(cNombreFormulario, 0, cTipoPersona);
            foreach (DataColumn dcColumna in dtTablaReglas.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //Recorrer la tabla de 'PARAMETROS A VALIDAR' y, reemplazar los parametros por valores en la tabla de FUNCIONES  (Tabla SI_FinDetFunxRegla)
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombreCampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorCampo"].ToString();

                for (int f = 0; f < dtTablaFunciones.Rows.Count; f++)
                {
                    //reemplazar en las funciones los parametros por valores
                    dtTablaFunciones.Rows[f]["cFunRemplazado"] = ReemplazarParametrosEnFuncion(dtTablaFunciones.Rows[f][3].ToString(), cNomCampo, cValorCampo);
                }
            }

            //asigna los valores en la base de datos y devuelve con los valores calculados
            DataSet dsFunciones = new DataSet("dsFunciones");
            dtTablaFunciones.TableName = "dtFunciones";
            dsFunciones.Tables.Add(dtTablaFunciones);
            var xmlFunciones = dsFunciones.GetXml();
            dtTablaFunciones = asignarValoresAFunciones(xmlFunciones);


            //Recorrer la tabla de REGLAS (Tabla SI_FinReglas) en funcion del numero de funciones, y reemplazar el valor de las funciones en tabla REGLAS
            for (int i = 0; i < dtTablaFunciones.Rows.Count; i++)
            {
                //obteniendo el nombreCampo -- cFuncion
                string cNomFuncion = dtTablaFunciones.Rows[i]["cFuncion"].ToString();
                //obteniendo el valorCampo -- cValorFun
                string cValorFuncion = dtTablaFunciones.Rows[i]["cValorFun"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //nIdRegla, nIdOpcion, cReglaNegocio, cReglaRemplazado = cReglaNegocio, lResul = 'OK'
                    if (dtTablaReglas.Rows[f]["cReglaNegocio"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en las reglas el valor de las funciones
                        dtTablaReglas.Rows[f]["cReglaRemplazado"] = dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString().Replace(cNomFuncion, cValorFuncion);
                    }
                    if (dtTablaReglas.Rows[f]["cCaracteristica"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en caracteristica de las reglas
                        dtTablaReglas.Rows[f]["cCaracteristica"] = dtTablaReglas.Rows[f]["cCaracteristica"].ToString().Replace(cNomFuncion, cValorFuncion);

                    }
                }
            }

            //Recorrer la tabla 'PARAMETROS A VALIDAR' y reemplazar los campos faltantes en la tabla REGLAS
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombrecampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorcampo"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //reemplazar en las reglas los valores de los campos faltantes
                    //Hacer el reemplazo en los campos: cCaracteristica y cReglaRemplazado
                    dtTablaReglas.Rows[f]["cCaracteristica"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cCaracteristica"].ToString(), cNomCampo, cValorCampo);
                    dtTablaReglas.Rows[f]["cReglaRemplazado"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString(), cNomCampo, cValorCampo);
                }
            }

            DataTable dtEvaluarExpresionLogica = new DataTable();

            //Recorrer la tabla REGLAS y calcular(verificar) el resultado de la validacion de cada regla
            for (int i = 0; i < dtTablaReglas.Rows.Count; i++)
            {
                //Evaluar los campos de caracterización si es 1: quiere decir que no se debe trabajar con este campo sino con ["cReglaRemplazado"]
                if (dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim().Equals("1"))
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cReglaRemplazado"].ToString().Trim(), "")))
                    {
                        dtTablaReglas.Rows[i]["lResul"] = "CUMPLE";
                    }
                    else
                    {
                        dtTablaReglas.Rows[i]["lResul"] = "NO CUMPLE";
                    }
                }
                else//Si el campo es diferente de 1: se sebe trabajar con el campo ["cCaracteristica"] y ["cReglaRemplazado"]
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim(), "")))
                    {
                        //Evaluar las Reglas
                        if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cReglaRemplazado"].ToString().Trim(), "")))
                        {
                            dtTablaReglas.Rows[i]["lResul"] = "CUMPLE";
                        }
                        else
                        {
                            dtTablaReglas.Rows[i]["lResul"] = "NO CUMPLE";
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
        public DataTable ObtenerReglasExcepcionesConResultado(DataTable dtTablaParametros, string cNombreFormulario, int idRegistroExcep)
        {
            foreach (DataColumn dcColumna in dtTablaParametros.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las funciones de Base datos (Tabla SI_FinDetFunxRegla)
            //Estructura:   nIdFuncion  nIdOpcion   cFuncion    cFunRemplazado= cFuncion  cValorFun
            DataTable dtTablaFunciones = ObtenerFuncionesParaReglasDinamicas(cNombreFormulario);
            foreach (DataColumn dcColumna in dtTablaFunciones.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //traer en un Datatable las reglas de Base datos (Tabla SI_FinReglas)
            //Estructura: nIdRegla  nIdOpcion   cCaracteristica cReglaNegocio   cMensajeError   lIndExcepcion   idUsuRegist   dFecRegist    idTipoOperacion cAuditUser  cAuditStation   cAuditClient    dAuditDate  lResul= 'OK' cReglaRemplazado= cReglaNegocio
            DataTable dtTablaReglas = ObtenerReglasReglasDinamicas(cNombreFormulario, idRegistroExcep);
            DataColumn lCumplimientoExcepcion = dtTablaReglas.Columns.Add("lCumplimientoExcepcion", typeof(bool));
            foreach (DataColumn dcColumna in dtTablaReglas.Columns)
            {
                dcColumna.ReadOnly = false;
            }

            //Recorrer la tabla de 'PARAMETROS A VALIDAR' y, reemplazar los parametros por valores en la tabla de FUNCIONES  (Tabla SI_FinDetFunxRegla)
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombreCampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorCampo"].ToString();

                for (int f = 0; f < dtTablaFunciones.Rows.Count; f++)
                {
                    //reemplazar en las funciones los parametros por valores
                    dtTablaFunciones.Rows[f]["cFunRemplazado"] = ReemplazarParametrosEnFuncion(dtTablaFunciones.Rows[f][3].ToString(), cNomCampo, cValorCampo);
                }
            }

            //asigna los valores en la base de datos y devuelve con los valores calculados
            DataSet dsFunciones = new DataSet("dsFunciones");
            dtTablaFunciones.TableName = "dtFunciones";
            dsFunciones.Tables.Add(dtTablaFunciones);
            var xmlFunciones = dsFunciones.GetXml();
            dtTablaFunciones = asignarValoresAFunciones(xmlFunciones);


            //Recorrer la tabla de REGLAS (Tabla SI_FinReglas) en funcion del numero de funciones, y reemplazar el valor de las funciones en tabla REGLAS
            for (int i = 0; i < dtTablaFunciones.Rows.Count; i++)
            {
                //obteniendo el nombreCampo -- cFuncion
                string cNomFuncion = dtTablaFunciones.Rows[i]["cFuncion"].ToString();
                //obteniendo el valorCampo -- cValorFun
                string cValorFuncion = dtTablaFunciones.Rows[i]["cValorFun"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //nIdRegla, nIdOpcion, cReglaNegocio, cReglaRemplazado = cReglaNegocio, lResul = 'OK'
                    if (dtTablaReglas.Rows[f]["cReglaNegocio"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en las reglas el valor de las funciones
                        dtTablaReglas.Rows[f]["cReglaRemplazado"] = dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString().Replace(cNomFuncion, cValorFuncion);
                    }
                    if (dtTablaReglas.Rows[f]["cCaracteristica"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en caracteristica de las reglas
                        dtTablaReglas.Rows[f]["cCaracteristica"] = dtTablaReglas.Rows[f]["cCaracteristica"].ToString().Replace(cNomFuncion, cValorFuncion);

                    }
                    if (dtTablaReglas.Rows[f]["cCampoExcepcion"].ToString().IndexOf(cNomFuncion) != -1)
                    {
                        //reemplazar en caracteristica de las reglas
                        dtTablaReglas.Rows[f]["cCampoExcepcionReemplazado"] = dtTablaReglas.Rows[f]["cCampoExcepcionReemplazado"].ToString().Replace(cNomFuncion, cValorFuncion);

                    }
                }
            }

            //Recorrer la tabla 'PARAMETROS A VALIDAR' y reemplazar los campos faltantes en la tabla REGLAS
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                //obteniendo el nombreCampo
                string cNomCampo = dtTablaParametros.Rows[i]["cNombrecampo"].ToString();
                //obteniendo el valorCampo
                string cValorCampo = dtTablaParametros.Rows[i]["cValorcampo"].ToString();

                for (int f = 0; f < dtTablaReglas.Rows.Count; f++)
                {
                    //reemplazar en las reglas los valores de los campos faltantes
                    //Hacer el reemplazo en los campos: cCaracteristica y cReglaRemplazado
                    dtTablaReglas.Rows[f]["cCaracteristica"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cCaracteristica"].ToString(), cNomCampo, cValorCampo);
                    dtTablaReglas.Rows[f]["cReglaRemplazado"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cReglaRemplazado"].ToString(), cNomCampo, cValorCampo);
                    dtTablaReglas.Rows[f]["cCampoExcepcionReemplazado"] = ReemplazarCamposEnReglas(dtTablaReglas.Rows[f]["cCampoExcepcionReemplazado"].ToString(), cNomCampo, cValorCampo);
                }
            }

            DataTable dtEvaluarExpresionLogica = new DataTable();

            //Recorrer la tabla REGLAS y calcular(verificar) el resultado de la validacion de cada regla
            for (int i = 0; i < dtTablaReglas.Rows.Count; i++)
            {
                dtTablaReglas.Rows[i]["lCumplimientoExcepcion"] = false;
                //Evaluar los campos de caracterización si es 1: quiere decir que no se debe trabajar con este campo sino con ["cReglaRemplazado"]
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
                else//Si el campo es diferente de 1: se sebe trabajar con el campo ["cCaracteristica"] y ["cReglaRemplazado"]
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cCaracteristica"].ToString().Trim(), "")))
                    {
                        //Evaluar las Reglas
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

                //Verificar Excepciones
                if (dtTablaReglas.Rows[i]["lIndExcepcion"].ToString().Trim().Equals("1"))
                {
                    if (Convert.ToBoolean(dtEvaluarExpresionLogica.Compute(dtTablaReglas.Rows[i]["cCampoExcepcionReemplazado"].ToString().Trim(), "")))
                    {
                        dtTablaReglas.Rows[i]["lCumplimientoExcepcion"] = true;
                    }
                    else
                    {
                        dtTablaReglas.Rows[i]["lCumplimientoExcepcion"] = false;
                    }
                }
            }
            return dtTablaReglas;
        }

        private object AplicaLimitesEOB(DataTable dtTablaParametros, string cNombreFormulario)
        {
            //Tipo de Establecimiento
            if ((int)clsVarGlobal.User.idTipoEstablec != 8)// idTipo 8 = EOB
                return Tuple.Create(false, 0);

            //Formulario
            DataTable dtTipoOpeEOBMenu = ReglasDinamicas.ADObtenerTipoOpeEOBMenu();
            if (!dtTipoOpeEOBMenu.AsEnumerable().Any(row => row.Field<string>("cFormMenu") == cNombreFormulario))
                return Tuple.Create(false, 0);

            //Filtros especiales
            EnumerableRowCollection<DataRow> query = dtTipoOpeEOBMenu.AsEnumerable().Where(row => row.Field<string>("cFormMenu") == cNombreFormulario);
            if (query.Any(row => row.Field<string>("cFiltro") != "0"))
            {
                // 9 : Recaudo de servicios y cobranzas en general - 10 : Venta de Micro seguros
                var eFiltroParaRecibos = query.Where(row => row.Field<int>("idTipoOpe") == 9 || row.Field<int>("idTipoOpe") == 10);
                if (eFiltroParaRecibos.Any())
                {
                    string idConcepto = dtTablaParametros.AsEnumerable()
                        .First(row => row.Field<string>("cNombreCampo") == "idConcepto")
                        .Field<string>("cValorCampo");

                    foreach (var item in eFiltroParaRecibos)
                    {
                        var listaConceptos = item.Field<string>("cFiltro").Split(',');
                        if (listaConceptos.Contains(idConcepto))
                        {
                            return Tuple.Create(true, item.Field<int>("idTipoOpe"));
                        }
                    }
                    return Tuple.Create(false, 0);
                }

                // 3 : Retiros de dinero de sus cuentas - 4 :Transferencia de Fondos
                var eFiltroModoPagoRetiroAho = query.Where(row => row.Field<int>("idTipoOpe") == 3 || row.Field<int>("idTipoOpe") == 4 || row.Field<int>("idTipoOpe") == 7);
                if (eFiltroModoPagoRetiroAho.Any())
                {
                    string idTipoPago = dtTablaParametros.AsEnumerable()
                        .First(row => row.Field<string>("cNombreCampo") == "idTipoPago")
                        .Field<string>("cValorCampo");

                    foreach (var item in eFiltroModoPagoRetiroAho)
                    {
                        var listaConceptos = item.Field<string>("cFiltro").Split(',');
                        if (listaConceptos.Contains(idTipoPago))
                        {
                            return Tuple.Create(true, item.Field<int>("idTipoOpe"));
                        }
                    }
                    return Tuple.Create(false, 0);
                }
            }
            return Tuple.Create(true, 0);
        }

        private void cargarFormSustentoLimte(DataTable dtSolicitudExcepcionLimite, int idDocument, int idCli, int idProducto, int idMotivo, int idTipoOperacion, int idMoneda, int idEstadoOperac, int idTipoOpeExp)
        {
            int nEstadoSol = 1;
            frmSolicitudExcepcionLimite frmSolicitudExcepLimite = new frmSolicitudExcepcionLimite();
            frmSolicitudExcepLimite.cargarDatos(dtSolicitudExcepcionLimite, idDocument, idCli, idProducto, idMotivo, nEstadoSol, idTipoOperacion, idMoneda, idEstadoOperac, idTipoOpeExp);
            frmSolicitudExcepLimite.ShowDialog();
        }

        public string ValidarReglas(DataTable dtTablaParametros , string cNombreFormulario  , int idAgencia         ,   int idCliente   ,
                                    int idEstadoOperac          , int idMoneda              , int idProducto        ,   Decimal nValAproba,
                                    int idDocument              , DateTime dFecSolici       , int idMotivo          ,   int idEstadoSol ,
                                    int idUsuRegist             , ref int idSolApr)
        {
            DateTime dFecAprSol = dFecSolici;

            #region Descripción de Parámetros

            //=========================================================
            // Para el uso de Reglas Dinámicas tipo excepcionables o no
            //=========================================================
            //Campos necesarios para SP: GEN_InsSoliciAproba_SP:
            /*@x_idAgencia		INT,	 -- Agencia: SI_FinAgencia
            @x_idCliente		INT,	 -- Cliente: SI_FinCliente
            @x_idTipoOperacion	INT,	 -- Operacion: SI_FinTipoOperacion
            @x_idEstadoOperac	INT,	 -- Modalidad: SI_FinEstadoKardex
            @x_idMoneda			INT,	 -- Moneda: SI_FinMoneda
            @x_idProducto		INT,	 -- Producto: SI_FinProducto
            @x_nValAproba		DECIMAL, -- Monto de Transaccion
            @x_idDocument		INT,	 -- Documento de Transacción (Nro Kardex, Nro de solicitud, etc)
            @x_dFecSolici		DATETIME,-- Fecha de Solicitud
            @x_idMotivo			INT,	 -- Motivo: SI_FinMotivoExtorno
            @x_cSustento		VARCHAR, -- Sustento---->
            @x_idEstadoSol		INT,	 -- Estado de Solicitud: SI_FinEstadoSolicitud
            @x_dFecAprSol		DATETIME,-- Fecha de Aprobación / rechazo
            @x_idUsuRegist		INT		 -- Usuario de Registro*/

            //======================================================================
            // Par el uso de Reglas Dinámicas que requieran Niveles de Autorización
            //======================================================================
            // el parámetro idSolApr INT,  se tomará en cuenta

            #endregion

            string cResultadoValidacion="";

            //obteniene las reglas con resultado ('OK' ó 'NO')  ordenadas de acuerdo a lIndExcepcion=0 y luego lIndExcepcion=1
            DataTable dtReglas = ObtenerReglasConResultado(dtTablaParametros, cNombreFormulario);

            //--Obtener el número de reglas propias del negocio
            int nCantReglasNegocio = 0;
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"])==false)
                {
                    nCantReglasNegocio++;
                }
            }
            //--Fin obtener reglas propias del negocio

            int nContadorReglasCumplidas = 0;

            //Recorrer la Tabla de Reglas y consultar si es posible su excepción(según se a el caso), ó si es necesario nivel de autorización
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"]) == false)//Trabajar sólo con las reglas propias del negocio
                {
                    if (dtReglas.Rows[f]["lResul"].ToString().Equals("NO"))
                    {
                        if (Convert.ToInt16(dtReglas.Rows[f]["lIndExcepcion"].ToString()) > 0)//Cuando ["lIndExcepcion"]=1 Es posible excepción,["lIndExcepcion"]=2 Es necesario nivel de autorización
                        {
                            switch (Convert.ToInt16(dtReglas.Rows[f]["lIndExcepcion"].ToString()))
                            {
                                #region 1. Uso_de_excepciones

                                case 1: //--Uso de excepciones
                                    //Consultar la Tabla SI_FinSoliciAproba para ver si el cliente tiene solicitudes aprobadas
                                    DataTable dtConsultaSolicitudAprobada = ConsultaSolicitudesAprobadas(Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()), idDocument);

                                    string cSolicitudesAprobacion = "";
                                    if (dtConsultaSolicitudAprobada.Rows.Count != 0)//Siempre devolverá solo una fila
                                    {
                                        cSolicitudesAprobacion = dtConsultaSolicitudAprobada.Rows[0]["cEstadoSol"].ToString();
                                    }

                                    if (cSolicitudesAprobacion.ToUpper().Equals("SOLICITADO"))
                                    {
                                        MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine +
                                                                            "Está a la espera de: APROBACIÓN DE EXCEPCIÓN"
                                                                            , "Regla que no se cumple:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                    else if (cSolicitudesAprobacion.ToUpper().Equals("APROBADO"))
                                    {
                                        //se actualiza resultado de la regla
                                        dtReglas.Rows[f]["lResul"] = "OK";
                                        //System.Windows.Forms.MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString(), "Excepcion Aprobada");
                                        nContadorReglasCumplidas++;
                                    }
                                    else if (cSolicitudesAprobacion.ToUpper().Equals("RECHAZADO"))
                                    {
                                        //mostrar toda la reglas que no se cumplen
                                        string cReglasNoCumplen = "";
                                        for (int i = 0; i < dtReglas.Rows.Count; i++)
                                        {
                                            if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                            {
                                                cReglasNoCumplen = cReglasNoCumplen + "Regla: " + dtReglas.Rows[i]["nIdRegla"].ToString() + Environment.NewLine +
                                                                   dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                            }
                                        }
                                        MessageBox.Show(cReglasNoCumplen, "Solicitud de Excepción rechazado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cResultadoValidacion = "ExcepcionRechazada";

                                        return cResultadoValidacion;
                                    }
                                    else //cuando es por primer vez
                                    {
                                        DialogResult cRespuesta = MessageBox.Show("Regla: " + dtReglas.Rows[f]["nIdRegla"].ToString() + Environment.NewLine +
                                                                            dtReglas.Rows[f]["cMensajeError"].ToString() +Environment.NewLine + Environment.NewLine +
                                                                            "Desea solicitar Excepción?"
                                                                            , "Solicitar Excepción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (cRespuesta.Equals(DialogResult.Yes))
                                        {
                                            //llamar al formulario donde insertará el sutento
                                            string cSustento = "";
                                            bool lExcepcion = false;
                                            bool lBloqNoExcepcion = (bool)dtReglas.Rows[f]["lNoExcepcion"];

                                            if (cargarFormSustento("Registro de Excepción:", "Ingrese SUSTENTO DE EXCEPCIÓN:", ref cSustento, ref lExcepcion, lBloqNoExcepcion) == DialogResult.OK)
                                            {
                                                DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                idEstadoOperac, idMoneda, idProducto,
                                                                                nValAproba, idDocument, dFecSolici,
                                                                                idMotivo, cSustento, idEstadoSol,
                                                                                dFecAprSol, idUsuRegist, lExcepcion);
                                                if (dtRespuesta.Rows.Count == 0)
                                                {
                                                    MessageBox.Show("Se ha producido un ERROR al guardar, intente de nuevo", "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dtRespuesta.Rows[0]["idSolAproba"].ToString()) != 0)//La solicitud de Excepción se ha guardado Correctamente
                                                    {
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtRespuesta.Rows[0]["idSolAproba"].ToString(), "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    }
                                                    else//No se ha definido aprobadores para la excepción, entonces la Solicitud se ha rechazado automáticamente
                                                    {
                                                        //mostrar toda la reglas que no se cumplen
                                                        string cReglasNoCumplen = "";
                                                        for (int i = 0; i < dtReglas.Rows.Count; i++)
                                                        {
                                                            if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                                            {
                                                                cReglasNoCumplen = cReglasNoCumplen + "Regla: " + dtReglas.Rows[i]["nIdRegla"].ToString() + Environment.NewLine +
                                                                                   dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                                            }
                                                        }

                                                        //Mensaje recuperado de Base de DATOS 'La solicitud fue rechazada automaticamente, no tiene registrado niveles de aprobación'
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString()+"." + Environment.NewLine + cReglasNoCumplen, "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        cResultadoValidacion = "ExcepcionRechazada";

                                                        return cResultadoValidacion;
                                                    }
                                                }
                                            }
                                            else
                                            {//Cliente no acepta una excepción
                                                break;
                                            }
                                        }
                                        else
                                        {   //Cliente no acepta una excepción
                                        }
                                    }
                                    break;
                                #endregion

                                #region 2. Uso_Niveles_Autorizacion

                                case 2:  //Cuando Requiere Nivel de Autorización
                                    //--=============================================================================================================
                                    //---Consultar la Tabla SI_FinSoliciAproba para ver si el cliente tiene solicitudes aprobadas
                                    //--=============================================================================================================
                                    DataTable dtConsultaSolApr = ConsultaAprobacionSolicitud(Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()), idDocument, idProducto, idCliente,
                                                                                                        idMoneda, dFecSolici, idUsuRegist, nValAproba);
                                    //string cSolicitudesApr = "";
                                    int idEstSol = 0;
                                    idSolApr = 0;
                                    //---========================================================================
                                    //--Validamos si Existe Solicitudes
                                    //---========================================================================
                                    if (dtConsultaSolApr.Rows.Count > 0)//Siempre devolverá solo una fila
                                    {
                                        //--==========================================
                                        //--Asignamos el Estado de la Solicitud
                                        //--==========================================
                                        idSolApr = Convert.ToInt32(dtConsultaSolApr.Rows[0]["idSolAproba"].ToString());
                                        idEstSol = Convert.ToInt32(dtConsultaSolApr.Rows[0]["idEstadoSol"].ToString());
                                        switch (idEstSol)
                                        {
                                            case 1: //--Solicitado
                                                //--------------------------------------------------------------------
                                                //---Mensaje que Indica que Esta a la espera de la Aprobación
                                                //--------------------------------------------------------------------
                                                MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine +
                                                                            "Ya Fue Registrado, Está a la Espera de la:" + Environment.NewLine +
                                                                            "APROBACIÓN DE LA AUTORIZACIÓN:", "Niveles de Autorización:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                break;
                                            case 2: //--Aprobado
                                                //--------------------------------------------------------------------
                                                //--Cuando es Aprobado la Sol,se actualiza resultado de la regla
                                                //--------------------------------------------------------------------
                                                dtReglas.Rows[f]["lResul"] = "OK";
                                                nContadorReglasCumplidas++;
                                                break;
                                            case 4: //--Rechazado
                                                //--------------------------------------------------------------------
                                                //--mostrar toda la reglas que no se cumplen
                                                //--------------------------------------------------------------------
                                                DialogResult cRespuesta = MessageBox.Show("SU SOLICITUD DE APROBACIÓN A SIDO RECHAZADO..." + Environment.NewLine + ""
                                                                                        + Environment.NewLine +
                                                                                        "DESEA REGISTRAR NUEVAMENTE...."
                                                                                        , "Solicitud de Nivel de Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (cRespuesta.Equals(DialogResult.Yes))
                                                {
                                                    string cSustento = "Solicito Autorización, para Realizar la Operación";
                                                    DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                        idEstadoOperac, idMoneda, idProducto,
                                                                                        nValAproba, idDocument, dFecSolici,
                                                                                        idMotivo, cSustento, idEstadoSol,
                                                                                        dFecAprSol, idUsuRegist,true);
                                                    if (dtRespuesta.Rows.Count > 0)
                                                    {
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + Environment.NewLine +
                                                                                    "POR FAVOR COORDINAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("ERROR AL REGISTRAR SU SOLICITUD DE AUTORIZACIÓN,..." + Environment.NewLine +
                                                                                    "POR FAVOR VERIFICAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else  //--Si no Existe Solicitud de Aprobación Registrada
                                    {
                                        //--==========================================================================
                                        //--Registramos la Solicitu de Nivel de Autorización
                                        //--==========================================================================
                                        DialogResult cRespuesta = MessageBox.Show("Se encontro la siguiente regla: "+dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine +
                                                                                    "¿DESEA SOLICITAR EXCEPCION O AUTORIZACIÓN?"
                                                                                        , "Solicitud de Nivel de Excepcion o Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (cRespuesta.Equals(DialogResult.Yes))
                                        {
                                             //llamar al formulario donde insertará el sutento
                                            string cSustento = "";
                                            bool lExcepcion = false;
                                            bool lBloqNoExcepcion = (bool)dtReglas.Rows[f]["lNoExcepcion"];

                                            if (cargarFormSustento("Registro de Excepción:", "Ingrese SUSTENTO DE AUTORIZACION:" + dtReglas.Rows[f]["cMensajeError"].ToString(), ref cSustento, ref lExcepcion, lBloqNoExcepcion) == DialogResult.OK)
                                            {

                                                //string cSustento = "Solicito Autorización, para Realizar la Operación";
                                                DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                    idEstadoOperac, idMoneda, idProducto,
                                                                                    nValAproba, idDocument, dFecSolici,
                                                                                    idMotivo, cSustento, idEstadoSol,
                                                                                    dFecAprSol, idUsuRegist, true);
                                                if (dtRespuesta.Rows.Count > 0)
                                                {
                                                    idSolApr = Convert.ToInt32(dtRespuesta.Rows[0]["idSolAproba"].ToString());
                                                    MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine  + dtRespuesta.Rows[0]["cMensaje"].ToString() + Environment.NewLine +
                                                                                "Nro de Solicitud: " + Convert.ToString(idSolApr) + Environment.NewLine +
                                                                                "POR FAVOR COORDINAR...", "Solicitud de Nivel de Excepcion o Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("ERROR AL REGISTRAR SU SOLICITUD DE AUTORIZACIÓN,..." + Environment.NewLine +
                                                                                "POR FAVOR VERIFICAR...", "Solicitud de Nivel de Excepcion o Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                        }
                                    }
                                    break;
                        #endregion
                            }
                        }
                        else//Cuando ["lIndExcepcion"]=0
                        {
                            //======================================================================
                            //  Recorrer toda la coleccion y mostrar las reglas que no se cumplen:
                            //======================================================================
                            string cReglasNoCumplen = "";
                            for (int i = 0; i < dtReglas.Rows.Count; i++)
                            {
                                if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                {
                                    cReglasNoCumplen = cReglasNoCumplen + "Regla " + dtReglas.Rows[i]["nIdRegla"].ToString() + " : " + dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                }
                            }
                            MessageBox.Show(cReglasNoCumplen, "Validar Reglas de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        nContadorReglasCumplidas++;
                    }
                }
            }
            
            //===============================================================
            //  Verificar cumplimiento reglas del negocio
            //===============================================================
            if (nContadorReglasCumplidas == nCantReglasNegocio)
            {//actualizar Estado de la solicitud -- Tabla SI_FinSolicitud
                cResultadoValidacion = "Cumple";
            }
            else
            {
                cResultadoValidacion = "NoCumple";
            }

            //=============================================================================
            //Validacion de Excepciones de Limites EOB 
            //=============================================================================

            var resultado = AplicaLimitesEOB(dtTablaParametros, cNombreFormulario);
            var tupla = (Tuple<bool, int>)resultado;
            bool lAplicaLimites = tupla.Item1;
            int idTipoOpeEOB = tupla.Item2;
            string cResultadoValidacionEOB = "";

            if (lAplicaLimites)
            {
                decimal nValAprobaConvertido = idMoneda == 1 ? nValAproba : nValAproba * Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
                var dtSolicitudExcepcionLimite = ReglasDinamicas.ADSolicitudExcepcionLimite(cNombreFormulario, nValAprobaConvertido, idCliente, (int)clsVarGlobal.User.idEstablecimiento, idTipoOpeEOB);
                int idlimite = 0, idTipoOperacion = 0, idTipoOpeExp = 0;

                if (dtSolicitudExcepcionLimite.AsEnumerable().Any(row => row.Field<bool>("lExcepcion") == true))
                {
                    for (int i = 0; i < dtSolicitudExcepcionLimite.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dtSolicitudExcepcionLimite.Rows[i]["idTipoLimite"]) > idlimite && Convert.ToInt32(dtSolicitudExcepcionLimite.Rows[i]["idTipoOperacion"]) != 0)
                        {
                            idlimite = Convert.ToInt32(dtSolicitudExcepcionLimite.Rows[i]["idTipoLimite"]);
                            idTipoOperacion = Convert.ToInt32((dtSolicitudExcepcionLimite.Rows[i]["idTipoOperacion"]));
                            idTipoOpeExp = Convert.ToInt32((dtSolicitudExcepcionLimite.Rows[i]["idTipoOpeExp"]));
                        }
                    }

                    string limites = "";
                    DateTime dFecSolicitud = clsVarGlobal.dFecSystem.Date;
                    dFecSolicitud = dFecSolicitud.Add(DateTime.Now.TimeOfDay);
                    DataTable dtConsultaSolicitudAprobadas = ReglasDinamicas.ConsultaSolicitudesAprobadasLimiteExcepcion(idTipoOperacion, idDocument, idProducto, idCliente, idMoneda, dFecSolicitud, idUsuRegist, nValAprobaConvertido, idTipoOpeExp);

                    List<SolicitudExcepcionLimite> listaSolicitudExcepcionLimite = dtSolicitudExcepcionLimite.AsEnumerable().Select(x => new SolicitudExcepcionLimite
                    {
                        idTipoOperacion = Convert.ToInt32(x["idTipoOperacion"]),
                        idTipoLimite = Convert.ToInt32(x["idTipoLimite"]),
                        cTipoLimite = x["cTipoLimite"].ToString(),
                        lExcepcion = Convert.ToBoolean(x["lExcepcion"]),
                        nValAproba = Convert.ToDecimal(x["nValAproba"]),
                    }).ToList();

                    string cLimitesExcepcion = string.Join(",", listaSolicitudExcepcionLimite
                                            .Where(x => x.lExcepcion)
                                            .Select(x => x.idTipoLimite.ToString()));

                    for (int i = 0; i < dtSolicitudExcepcionLimite.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtSolicitudExcepcionLimite.Rows[i]["lExcepcion"]) == true)
                            limites = limites + " - " + dtSolicitudExcepcionLimite.Rows[i]["cTipoLimite"].ToString() + "\n";
                    }

                    if (dtConsultaSolicitudAprobadas.Rows.Count > 0)
                    {
                        if (cLimitesExcepcion == dtConsultaSolicitudAprobadas.Rows[0]["cLimiteExcep"].ToString())
                        {
                            string cSolicitudesAprobacion = dtConsultaSolicitudAprobadas.Rows[0]["cEstadoSol"].ToString();
                            int idSolAprob = Convert.ToInt32(dtConsultaSolicitudAprobadas.Rows[0]["idSolAproba"].ToString());

                            switch (cSolicitudesAprobacion.ToUpper())
                            {
                                case "SOLICITADO":
                                    MessageBox.Show("Ya tiene una solicitud registrado," + Environment.NewLine + "solicitud N°: " + idSolAprob + "\n\n" +
                                                    " Está a la espera de la APROBACIÓN."
                                                    , "Limite de excepcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cResultadoValidacionEOB = "NoCumple";
                                    break;

                                case "APROBADO":
                                    cResultadoValidacionEOB = "Cumple";
                                    break;

                                case "RECHAZADO":
                                    DialogResult cRespuesta = MessageBox.Show("SU SOLICITUD N° " + idSolAprob + " DE APROBACIÓN HA SIDO RECHAZADO..." + Environment.NewLine +
                                                                              "¿DESEA REGISTRAR NUEVAMENTE?"
                                                                              , "Solicitud de Nivel de Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (cRespuesta.Equals(DialogResult.Yes))
                                        cargarFormSustentoLimte(dtSolicitudExcepcionLimite, idDocument, idCliente, idProducto, idMotivo, idTipoOperacion, idMoneda, idEstadoOperac, idTipoOpeExp);

                                    cResultadoValidacionEOB = "NoCumple";
                                    break;

                                default:
                                    cargarFormSustentoLimte(dtSolicitudExcepcionLimite, idDocument, idCliente, idProducto, idMotivo, idTipoOperacion, idMoneda, idEstadoOperac, idTipoOpeExp);
                                    cResultadoValidacionEOB = "NoCumple";
                                    break;
                            }
                        }
                        else
                        {
                            cargarFormSustentoLimte(dtSolicitudExcepcionLimite, idDocument, idCliente, idProducto, idMotivo, idTipoOperacion, idMoneda, idEstadoOperac, idTipoOpeExp);
                            cResultadoValidacionEOB = "NoCumple";
                        }
                    }
                    else
                    {
                        cargarFormSustentoLimte(dtSolicitudExcepcionLimite, idDocument, idCliente, idProducto, idMotivo, idTipoOperacion, idMoneda, idEstadoOperac, idTipoOpeExp);
                        cResultadoValidacionEOB = "NoCumple";
                    }
                }
            }

            //Valicacion de Reglas de Negocio y Reglas de Limites EOB
            if (cResultadoValidacionEOB == "Cumple")
            {
                if (cResultadoValidacion == "NoCumple")
                    cResultadoValidacion = "NoCumple";
            }
            else if (cResultadoValidacionEOB == "NoCumple")
            {
                cResultadoValidacion = "NoCumple";
            }

            return cResultadoValidacion;
        }

        public DataTable ValidarReglasCondiciones(DataTable dtTablaParametros, string cNombreFormulario, string cTipoPersona)
        {

            //obteniene las reglas con resultado ('OK' ó 'NO') 
            DataTable dtReglas = ObtenerReglasCondicionesResultado(dtTablaParametros, cNombreFormulario, cTipoPersona);

            DataTable dtResultado = new DataTable();
            dtResultado.Columns.Add("Nro");
            dtResultado.Columns.Add("Condiciones");
            dtResultado.Columns.Add("Mensaje");
            dtResultado.Columns.Add("Resultado");
            dtResultado.Columns.Add("Oculto");
            dtResultado.Columns.Add("cTipoCondicion");

            for (int i = 0; i < dtReglas.Rows.Count; i++)
            {
                DataRow drfila = dtResultado.NewRow();
                drfila[0] = dtReglas.Rows[i]["nNumOrden"].ToString();
                drfila[1] = dtReglas.Rows[i]["cMensajeError"].ToString();
                drfila[2] = dtReglas.Rows[i]["CondicionPos"].ToString();
                drfila[3] = dtReglas.Rows[i]["lResul"].ToString();
                drfila[4] = dtReglas.Rows[i]["cGrupo"].ToString();
                drfila[5] = dtReglas.Rows[i]["cTipoCondicion"].ToString();
                dtResultado.Rows.Add(drfila);

            }
            return dtResultado;
        }
        public DataTable obtenerReglas(int idSolicitud)
        {
            return ReglasDinamicas.obtenerRegla(idSolicitud);
        }
        
        public string ValidarReglasCreditos(DataTable dtTablaParametros , string cNombreFormulario  , int idAgencia         ,   int idCliente   ,
                                    int idEstadoOperac          , int idMoneda              , int idProducto        ,   Decimal /*era double*/nValAproba,
                                    int idDocument              , DateTime dFecSolici       , int idMotivo          ,   int idEstadoSol ,
                                    int idUsuRegist, ref int idSolApr, bool lMostrarAlerta, bool lAndyError = false, int idRegistroExcep = 0,
                                    List<clsReglaNegocioEvaluada> aReglasEvaluadas = null)
        {
            DateTime dFecAprSol = dFecSolici;
            cMensajeErrores = string.Empty;
            #region Descripción de Parámetros

            //=========================================================
            // Para el uso de Reglas Dinámicas tipo excepcionables o no
            //=========================================================
            //Campos necesarios para SP: GEN_InsSoliciAproba_SP:
            /*@x_idAgencia		INT,	 -- Agencia: SI_FinAgencia
            @x_idCliente		INT,	 -- Cliente: SI_FinCliente
            @x_idTipoOperacion	INT,	 -- Operacion: SI_FinTipoOperacion
            @x_idEstadoOperac	INT,	 -- Modalidad: SI_FinEstadoKardex
            @x_idMoneda			INT,	 -- Moneda: SI_FinMoneda
            @x_idProducto		INT,	 -- Producto: SI_FinProducto
            @x_nValAproba		DECIMAL, -- Monto de Transaccion
            @x_idDocument		INT,	 -- Documento de Transacción (Nro Kardex, Nro de solicitud, etc)
            @x_dFecSolici		DATETIME,-- Fecha de Solicitud
            @x_idMotivo			INT,	 -- Motivo: SI_FinMotivoExtorno
            @x_cSustento		VARCHAR, -- Sustento---->
            @x_idEstadoSol		INT,	 -- Estado de Solicitud: SI_FinEstadoSolicitud
            @x_dFecAprSol		DATETIME,-- Fecha de Aprobación / rechazo
            @x_idUsuRegist		INT		 -- Usuario de Registro*/

            //======================================================================
            // Par el uso de Reglas Dinámicas que requieran Niveles de Autorización
            //======================================================================
            // el parámetro idSolApr INT,  se tomará en cuenta

            #endregion

            string cResultadoValidacion = string.Empty;
            string cExcepcionablesSI = string.Empty;
            string cExcepcionablesNO = string.Empty;
            string cNoExcepcionables = string.Empty;
            string cAlertas = string.Empty;

            int nContadorReglasCumplidas = 0;
            if (cNombreFormulario == "frmRegistroSolicitudCredito")
            {
                ValidarVisitaPresencialRemota(dtTablaParametros, cNombreFormulario);
            }
            //obteniene las reglas con resultado ('OK' ó 'NO')  ordenadas de acuerdo a lIndExcepcion=0 y luego lIndExcepcion=1
            DataTable dtReglas = ObtenerReglasExcepcionesConResultado(dtTablaParametros, cNombreFormulario, idRegistroExcep);

            if (listTiposEvaluacionPresencialRemota.Count > 0)
            {
                foreach (Tuple<int, string, int> listTipoEvaluacion in listTiposEvaluacionPresencialRemota)
                {
                    if (listTipoEvaluacion.Item3 == 1)
                    {
                        foreach (DataRow row in dtReglas.Rows)
                        {
                            if ((int)row["nIdRegla"] == 1549)
                            {
                                row["lResul"] = "OK";
                                break;
                            }
                        }
                    }
                    
                }
                
            }
            

            //--Obtener el número de reglas propias del negocio
            int nCantReglasNegocio = 0;
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"]) == false && Convert.ToInt32(dtReglas.Rows[f]["lIndExcepcion"]) !=3)
                {
                    nCantReglasNegocio++;
                }
            }
            //--Fin obtener reglas propias del negocio

            DataTable dtExcepciones = new DataTable();
            DataTable dt2 = new DataTable();
            dtExcepciones.Columns.Add("idSolicitud", typeof(int));
            dtExcepciones.Columns.Add("idAgencia", typeof(int));
            dtExcepciones.Columns.Add("idCliente", typeof(int));
            dtExcepciones.Columns.Add("idTipoOperacion", typeof(int));
            dtExcepciones.Columns.Add("nIdOpcion", typeof(int));
            dtExcepciones.Columns.Add("lAutomatico", typeof(int));
            dtExcepciones.Columns.Add("nIdRegla", typeof(int));
            dtExcepciones.Columns.Add("idEstadoOperac", typeof(int));
            dtExcepciones.Columns.Add("idMoneda", typeof(int));
            dtExcepciones.Columns.Add("idProducto", typeof(int));
            dtExcepciones.Columns.Add("nValAproba", typeof(Decimal));
            dtExcepciones.Columns.Add("dFecSolici", typeof(DateTime));
            dtExcepciones.Columns.Add("idMotivo", typeof(int));
            dtExcepciones.Columns.Add("cSustento", typeof(string));
            dtExcepciones.Columns.Add("idEstadoSol", typeof(int));
            dtExcepciones.Columns.Add("idUsuRegist", typeof(int));
            dtExcepciones.Columns.Add("lIndExcepcion", typeof(int));
            dtExcepciones.Columns.Add("lCumplimientoExcepcion", typeof(bool));
            int idExiste = 0;
            string idRegla = "";
            if (cNombreFormulario == "frmRegistroSolicitudCredito" || cNombreFormulario == "frmSolicitudCredGrupoSolidario" || cNombreFormulario == "frmEvalCredFacilito")
            {
                int idSoli = Convert.ToInt32(dtTablaParametros.Rows[0]["cValorCampo"]);
                DataTable obtenerRegla = new DataTable();
                obtenerRegla = obtenerReglas(idSoli);
                if (obtenerRegla.Rows.Count < 1)
                {
                    idExiste = 1; // no exite registro
                }
                else
                {
                    idExiste = 2; // si existe registro
                    idRegla = Convert.ToString(obtenerRegla.Rows[0]["idRegla"]);
                }

            }
            //Recorrer la Tabla de Reglas y consultar si es posible su excepción(según se a el caso), ó si es necesario nivel de autorización
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (cNombreFormulario == "frmRegistroSolicitudCredito" || cNombreFormulario == "frmSolicitudCredGrupoSolidario" || cNombreFormulario == "frmEvalCredFacilito")
                {
                    if ((Convert.ToString(dtReglas.Rows[f]["nIdRegla"])) == idRegla && idExiste == 2)
                    {
                        dtReglas.Rows[f]["lResul"] = "OK";
                    }
                }
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"]) == false)//Trabajar sólo con las reglas propias del negocio
                {

                    if (dtReglas.Rows[f]["lResul"].ToString().Equals("NO"))
                    {

                        /*DataTable dtRespuesta = GuardarSolicitudExcepciones(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                 idEstadoOperac, , idProducto,
                                                                                 nValAproba, idDocument, dFecSolici,
                                                                                 idMotivo, cSustento, idEstadoSol,
                                                                                 dFecAprSol, idUsuRegist, lExcepcion);*/


                        //dtExcepcionesGeneradas.Add();
                        dtExcepciones.Rows.Add(idDocument,idAgencia, idCliente,
                                                String.IsNullOrEmpty(dtReglas.Rows[f]["idTipoOperacion"].ToString()) ? 0 : Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"]),
                                                Convert.ToInt32(dtReglas.Rows[f]["nIdOpcion"].ToString()),
                                                1,
                                                Convert.ToInt32(dtReglas.Rows[f]["nIdRegla"].ToString()),
                                                idEstadoOperac,
                                                idMoneda,
                                                idProducto,
                                                nValAproba,
                                                dFecSolici,
                                                idMotivo,
                                                "",
                                                idEstadoSol,
                                                idUsuRegist,
                                                Convert.ToInt32(dtReglas.Rows[f]["lIndExcepcion"].ToString()),
                                                Convert.ToBoolean(dtReglas.Rows[f]["lCumplimientoExcepcion"].ToString()));

                            //======================================================================
                            //  Recorrer toda la coleccion y mostrar las reglas que no se cumplen:
                            //======================================================================
                           // string cReglasNoCumplen = "";
                        /*
                            for (int i = 0; i < dtReglas.Rows.Count; i++)
                            {
                                if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                {
                                    cReglasNoCumplen = cReglasNoCumplen + "Regla " + dtReglas.Rows[i]["nIdRegla"].ToString() + " : " + dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                }
                            }
                            MessageBox.Show(cReglasNoCumplen, "Validar Reglas de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);*/

                    }
                    else
                    {
                        nContadorReglasCumplidas++;
                    }
                }
            }
            //----
            if (aReglasEvaluadas != null)
            {
                aReglasEvaluadas.Clear();
                aReglasEvaluadas.AddRange(DataTableToList.ConvertTo<clsReglaNegocioEvaluada>(dtReglas) as List<clsReglaNegocioEvaluada>);
            }
            if (dtExcepciones.Rows.Count > 0)
            {

                for (int i = 0; i < dtReglas.Rows.Count; i++)
                {
                    if (dtReglas.Rows[i]["lIndExcepcion"].Equals(1) && dtReglas.Rows[i]["lCumplimientoExcepcion"].Equals(true))
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cExcepcionablesSI = cExcepcionablesSI + "Excepción: " + dtReglas.Rows[i]["nIdRegla"].ToString() + ": " +
                                               dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;

                        }
                    }
                    else if (dtReglas.Rows[i]["lIndExcepcion"].Equals(1) && dtReglas.Rows[i]["lCumplimientoExcepcion"].Equals(false))
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cExcepcionablesNO = cExcepcionablesNO + "Excepción: " + dtReglas.Rows[i]["nIdRegla"].ToString() + ": " +
                                               dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;

                        }
                    }
                    else if (dtReglas.Rows[i]["lIndExcepcion"].Equals(3))
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cAlertas = cAlertas + "Regla: " + dtReglas.Rows[i]["nIdRegla"].ToString() + ": " +
                                               dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;

                        }
                    }
                    else
                    {
                        if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                        {
                            cNoExcepcionables = cNoExcepcionables + "Regla " + dtReglas.Rows[i]["nIdRegla"].ToString() + ": " +
                                               dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                        }
                    }




                }


                //DataTable dtnExcepcionesManuales = obtenerCantidadExcepcionesManuales(Convert.ToInt32(dtExcepciones.Rows[0]["idSolicitud"]), cNombreFormulario);

                //nContExcepNocumplidas = nContExcepNocumplidas + Convert.ToInt32(dtnExcepcionesManuales.Rows[0]["nCantidad"]);
                //nContExcepSinSustento = Convert.ToInt32(dtnExcepcionesManuales.Rows[1]["nCantidad"]);
                //int nCantidadExcepciones = Convert.ToInt16(clsVarApl.dicVarGen["nMaximoExcepciones"]);
                //if (nContExcepNocumplidas > nCantidadExcepciones)
                //{
                //            cNoExcepcionables = cNoExcepcionables + "Regla: "+
                //                               "El número de excepciones es mayor a lo permitido" + Environment.NewLine;
                //}
                //if (nContExcepSinSustento > 0)
                //{
                //    cNoExcepcionables = cNoExcepcionables + "Regla: " +
                //                       "Debe registrar sustento para todas las excepciones." + Environment.NewLine;
                //}

                //Excepcionables
                DataView vista = new DataView(dtExcepciones);
                vista.RowFilter = "lIndExcepcion = 1 AND lCumplimientoExcepcion = true ";
                dt2 = vista.ToTable();
                //if (dt2.Rows.Count > 0)
                //{
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt2);
                    string xml = ds.GetXml();
                    DataTable dtResultado = GuardarSolicitudExcepciones(idDocument, idUsuRegist, xml, 1, cNombreFormulario);
                //}
                //NO excepcionables
                 DataView vista1 = new DataView(dtExcepciones);
                 vista1.RowFilter = "lIndExcepcion = 1 AND lCumplimientoExcepcion = false ";
                dt2 = vista1.ToTable();
                //if (dt2.Rows.Count > 0)
                //{
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Add(dt2);
                    string xml1 = ds1.GetXml();
                    DataTable dtResultado1 = GuardarSolicitudNOExcepciones(idDocument, idUsuRegist, xml1, 1, cNombreFormulario);
                //}



                
                if (!String.IsNullOrEmpty(cNoExcepcionables.Trim()) && lMostrarAlerta == true)
                {
                    MessageBox.Show("Se encontraron reglas no excepcionables:" + Environment.NewLine + cNoExcepcionables, "Reglas Generadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                 
                }
                if (!String.IsNullOrEmpty(cExcepcionablesSI.Trim() + cExcepcionablesNO.Trim()) && lMostrarAlerta == true)
                {
                    MessageBox.Show("Se encontraron reglas excepcionables:" + Environment.NewLine + cExcepcionablesSI + cExcepcionablesNO, "Excepciones Generadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (!String.IsNullOrEmpty(cAlertas.Trim()) && lMostrarAlerta == true)
                {
                    MessageBox.Show("Se encontraron alertas:" + Environment.NewLine + cAlertas, "Alertas Generadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (cNombreFormulario != "FrmRegIntervieneCre")
                {
                    cNoExcepcionables = ReglasInternas(cNoExcepcionables, Convert.ToInt32(dtExcepciones.Rows[0]["idSolicitud"]), cNombreFormulario, lAndyError);
                }
                cMensajeErrores = "Se encontraron reglas no excepcionables:" + Environment.NewLine + cNoExcepcionables + Environment.NewLine + "Se encontraron reglas excepcionables:" + Environment.NewLine + cExcepcionablesSI + cExcepcionablesNO;
                
                //DialogResult cRespuesta = DialogResult.No;
                //if (!String.IsNullOrEmpty(cReglasConExcepNoCumplen.Trim()))
                //{
                //    cRespuesta = MessageBox.Show(cReglasConExcepNoCumplen + Environment.NewLine +
                //                                            "Desea Guardar las Excepciones Generadas ?"
                //                                            , "Excepciones Generadas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //}

                //if (cRespuesta.Equals(DialogResult.Yes) ||!String.IsNullOrEmpty(cReglasNoCumplen.Trim()))
                //{
                //    DataSet ds = new DataSet();
                //    ds.Tables.Add(dtExcepciones);
                //    string xml = ds.GetXml();
                //    //DataTable dtResultado = cnCarteraRecupera.reasignarCartera(xml, Convert.ToInt32(cboUsuRecuperadoresOrigen.SelectedValue), Convert.ToInt32(cboUsuRecuperadoresDestino.SelectedValue), clsVarGlobal.User.idUsuario, txtMotivoTransferencia.Text.Trim());
                //    //DataTable dtResultado = cnCarteraRecupera.asignarCarteraCastigada(xml, Convert.ToInt32(cboUsuRecuperadoresDestino.SelectedValue), clsVarGlobal.User.idUsuario, txtMotivoTransferencia.Text.Trim());
                //    DataTable dtResultado = GuardarSolicitudExcepciones(idDocument, idUsuRegist, xml, 1);

                //}
            }
            if (dtExcepciones.Rows.Count == 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtExcepciones);
                string xml = ds.GetXml();
                DataTable dtResultado = GuardarSolicitudExcepciones(idDocument, idUsuRegist, xml, 0, cNombreFormulario);
                DataTable dtResultado1 = GuardarSolicitudNOExcepciones(idDocument, idUsuRegist, xml, 0, cNombreFormulario);

                int idSolicitud = 0;

                var dtResSol = dtTablaParametros.AsEnumerable().Where(item => item.Field<string>("cNombreCampo").In("idSolicitud", "s_idSolicitud", "e_idSolicitud") && !item.Field<string>("cValorCampo").In("","0") ).CopyToDataTable();
                idSolicitud = (dtResSol.Rows.Count > 0) ? Convert.ToInt32(dtResSol.Rows[0]["cValorCampo"]) : 0 ;
                
                if (!String.IsNullOrEmpty(cNoExcepcionables.Trim()) && lMostrarAlerta == true)
                {
                    MessageBox.Show("Se encontraron reglas no excepcionables:" + Environment.NewLine + cNoExcepcionables, "Reglas Generadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nCantReglasNegocio = -1;
                }
                if (cNombreFormulario != "FrmRegIntervieneCre")
                {
                    cNoExcepcionables = ReglasInternas("", idSolicitud, cNombreFormulario);
                }

            }



            //===============================================================
            //  Verificar cumplimiento reglas del negocio
            //===============================================================
            if (nContadorReglasCumplidas == nCantReglasNegocio)
            {//actualizar Estado de la solicitud -- Tabla SI_FinSolicitud
                cResultadoValidacion = "Cumple";
                nValidacionInterna = 0;
            }
            //else if (!String.IsNullOrEmpty(cNoExcepcionables.Trim()) && !String.IsNullOrEmpty(cExcepcionables.Trim()))
            //{
            //    cResultadoValidacion = "NoCumple";
            //}
            else if (String.IsNullOrEmpty(cNoExcepcionables.Trim()) && !String.IsNullOrEmpty(cExcepcionablesSI.Trim() + cExcepcionablesNO.Trim()) && nValidacionInterna == 0)
            {
                cResultadoValidacion = "NoCumpleSoloExcp";
                nValidacionInterna = 0;
            }
            else
            {
                cResultadoValidacion = "NoCumple";
                nValidacionInterna = 0;
            }

            return cResultadoValidacion;

        }
        public string ReglasInternas(string cNoExcepcionables, int idSolicitud, string cNombreFormulario, bool lAndyError = false)
        {

            DataTable dtnExcepcionesManuales = obtenerCantidadExcepcionesManuales(idSolicitud, cNombreFormulario);

            int nContExcepNocumplidas = Convert.ToInt32(dtnExcepcionesManuales.Rows[0]["nCantidad"]);
            int nContExcepSinSustento = Convert.ToInt32(dtnExcepcionesManuales.Rows[1]["nCantidad"]);
            int nCantidadExcepciones = Convert.ToInt16(clsVarApl.dicVarGen["nMaximoExcepciones"]);
            if (nContExcepNocumplidas > nCantidadExcepciones)
            {
                MessageBox.Show("El número de excepciones es mayor a lo permitido"
                                    , "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nValidacionInterna++;
                //cNoExcepcionables = cNoExcepcionables + "Regla: " +
                //                   "El número de excepciones es mayor a lo permitido" + Environment.NewLine;
            }
            if (nContExcepSinSustento > 0)
            {
                nValidacionInterna++;
                if (!lAndyError)
                {
                    MessageBox.Show("Debe resolver todas las excepciones a reglas crediticias pendientes."
                        , "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //cNoExcepcionables = cNoExcepcionables + "Regla: " +
                //                   "Debe registrar sustento para todas las excepciones." + Environment.NewLine;
            }
            return cNoExcepcionables;
        }
        public string ValidarReglas(DataTable dtTablaParametros, string cNombreFormulario, int idAgencia, int idCliente,
                                    int idEstadoOperac, int idMoneda, int idProducto, Decimal /*era double*/nValAproba,
                                    int idDocument, DateTime dFecSolici, int idMotivo, int idEstadoSol,
                                    int idUsuRegist, ref DataTable dtSolApr)
        {
            DateTime dFecAprSol = dFecSolici;

            dtSolApr = new DataTable();
            dtSolApr.Columns.Add("idSolApr", typeof (int));


            #region Descripción de Parámetros

            //=========================================================
            // Para el uso de Reglas Dinámicas tipo excepcionables o no
            //=========================================================
            //Campos necesarios para SP: GEN_InsSoliciAproba_SP:
            /*@x_idAgencia		INT,	 -- Agencia: SI_FinAgencia
            @x_idCliente		INT,	 -- Cliente: SI_FinCliente
            @x_idTipoOperacion	INT,	 -- Operacion: SI_FinTipoOperacion
            @x_idEstadoOperac	INT,	 -- Modalidad: SI_FinEstadoKardex
            @x_idMoneda			INT,	 -- Moneda: SI_FinMoneda
            @x_idProducto		INT,	 -- Producto: SI_FinProducto
            @x_nValAproba		DECIMAL, -- Monto de Transaccion
            @x_idDocument		INT,	 -- Documento de Transacción (Nro Kardex, Nro de solicitud, etc)
            @x_dFecSolici		DATETIME,-- Fecha de Solicitud
            @x_idMotivo			INT,	 -- Motivo: SI_FinMotivoExtorno
            @x_cSustento		VARCHAR, -- Sustento---->
            @x_idEstadoSol		INT,	 -- Estado de Solicitud: SI_FinEstadoSolicitud
            @x_dFecAprSol		DATETIME,-- Fecha de Aprobación / rechazo
            @x_idUsuRegist		INT		 -- Usuario de Registro*/

            //======================================================================
            // Par el uso de Reglas Dinámicas que requieran Niveles de Autorización
            //======================================================================
            // el parámetro idSolApr INT,  se tomará en cuenta

            #endregion

            string cResultadoValidacion = "";

            //obteniene las reglas con resultado ('OK' ó 'NO')  ordenadas de acuerdo a lIndExcepcion=0 y luego lIndExcepcion=1
            DataTable dtReglas = ObtenerReglasConResultado(dtTablaParametros, cNombreFormulario);

            //--Obtener el número de reglas propias del negocio
            int nCantReglasNegocio = 0;
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"]) == false)
                {
                    nCantReglasNegocio++;
                }
            }
            //--Fin obtener reglas propias del negocio

            int nContadorReglasCumplidas = 0;

            //Recorrer la Tabla de Reglas y consultar si es posible su excepción(según se a el caso), ó si es necesario nivel de autorización
            for (int f = 0; f < dtReglas.Rows.Count; f++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[f]["lAlertaRiesgo"]) == false)//Trabajar sólo con las reglas propias del negocio
                {
                    if (dtReglas.Rows[f]["lResul"].ToString().Equals("NO"))
                    {
                        if (Convert.ToInt16(dtReglas.Rows[f]["lIndExcepcion"].ToString()) > 0)//Cuando ["lIndExcepcion"]=1 Es posible excepción,["lIndExcepcion"]=2 Es necesario nivel de autorización
                        {
                            switch (Convert.ToInt16(dtReglas.Rows[f]["lIndExcepcion"].ToString()))
                            {
                                #region 1. Uso_de_excepciones

                                case 1: //--Uso de excepciones
                                    //Consultar la Tabla SI_FinSoliciAproba para ver si el cliente tiene solicitudes aprobadas
                                    DataTable dtConsultaSolicitudAprobada = ConsultaSolicitudesAprobadas(Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()), idDocument);

                                    string cSolicitudesAprobacion = "";
                                    if (dtConsultaSolicitudAprobada.Rows.Count != 0)//Siempre devolverá solo una fila
                                    {
                                        cSolicitudesAprobacion = dtConsultaSolicitudAprobada.Rows[0]["cEstadoSol"].ToString();
                                    }

                                    if (cSolicitudesAprobacion.ToUpper().Equals("SOLICITADO"))
                                    {
                                        MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine +
                                                                            "Está a la espera de: APROBACIÓN DE EXCEPCIÓN"
                                                                            , "Regla que no se cumple:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                    else if (cSolicitudesAprobacion.ToUpper().Equals("APROBADO"))
                                    {
                                        //se actualiza resultado de la regla
                                        dtReglas.Rows[f]["lResul"] = "OK";
                                        //System.Windows.Forms.MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString(), "Excepcion Aprobada");
                                        nContadorReglasCumplidas++;
                                    }
                                    else if (cSolicitudesAprobacion.ToUpper().Equals("RECHAZADO"))
                                    {
                                        //mostrar toda la reglas que no se cumplen
                                        string cReglasNoCumplen = "";
                                        for (int i = 0; i < dtReglas.Rows.Count; i++)
                                        {
                                            if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                            {
                                                cReglasNoCumplen = cReglasNoCumplen + "Regla: " + dtReglas.Rows[i]["nIdRegla"].ToString() + Environment.NewLine +
                                                                   dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                            }
                                        }
                                        MessageBox.Show(cReglasNoCumplen, "Solicitud de Excepción rechazado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cResultadoValidacion = "ExcepcionRechazada";

                                        return cResultadoValidacion;
                                    }
                                    else //cuando es por primer vez
                                    {
                                        DialogResult cRespuesta = MessageBox.Show("Regla: " + dtReglas.Rows[f]["nIdRegla"].ToString() + Environment.NewLine +
                                                                            dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine + Environment.NewLine +
                                                                            "Desea solicitar Excepción?"
                                                                            , "Solicitar Excepción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (cRespuesta.Equals(DialogResult.Yes))
                                        {
                                            //llamar al formulario donde insertará el sutento
                                            string cSustento = "";
                                            bool lExcepcion = false;
                                            bool lBloqNoExcepcion = (bool)dtReglas.Rows[f]["lNoExcepcion"];

                                            if (cargarFormSustento("Registro de Excepción:", "Ingrese SUSTENTO DE EXCEPCIÓN:", ref cSustento, ref lExcepcion, lBloqNoExcepcion) == DialogResult.OK)
                                            {
                                                DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                idEstadoOperac, idMoneda, idProducto,
                                                                                nValAproba, idDocument, dFecSolici,
                                                                                idMotivo, cSustento, idEstadoSol,
                                                                                dFecAprSol, idUsuRegist, lExcepcion);
                                                if (dtRespuesta.Rows.Count == 0)
                                                {
                                                    MessageBox.Show("Se ha producido un ERROR al guardar, intente de nuevo", "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dtRespuesta.Rows[0]["idSolAproba"].ToString()) != 0)//La solicitud de Excepción se ha guardado Correctamente
                                                    {
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtRespuesta.Rows[0]["idSolAproba"].ToString(), "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    }
                                                    else//No se ha definido aprobadores para la excepción, entonces la Solicitud se ha rechazado automáticamente
                                                    {
                                                        //mostrar toda la reglas que no se cumplen
                                                        string cReglasNoCumplen = "";
                                                        for (int i = 0; i < dtReglas.Rows.Count; i++)
                                                        {
                                                            if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                                            {
                                                                cReglasNoCumplen = cReglasNoCumplen + "Regla: " + dtReglas.Rows[i]["nIdRegla"].ToString() + Environment.NewLine +
                                                                                   dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                                            }
                                                        }

                                                        //Mensaje recuperado de Base de DATOS 'La solicitud fue rechazada automaticamente, no tiene registrado niveles de aprobación'
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + "." + Environment.NewLine + cReglasNoCumplen, "Registro Solicitud de Excepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        cResultadoValidacion = "ExcepcionRechazada";

                                                        return cResultadoValidacion;
                                                    }
                                                }
                                            }
                                            else
                                            {//Cliente no acepta una excepción
                                                break;
                                            }
                                        }
                                        else
                                        {   //Cliente no acepta una excepción
                                        }
                                    }
                                    break;
                                #endregion

                                #region 2. Uso_Niveles_Autorizacion

                                case 2:  //Cuando Requiere Nivel de Autorización
                                    //--=============================================================================================================
                                    //---Consultar la Tabla SI_FinSoliciAproba para ver si el cliente tiene solicitudes aprobadas
                                    //--=============================================================================================================
                                    DataTable dtConsultaSolApr = ConsultaAprobacionSolicitud(Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()), idDocument, idProducto, idCliente,
                                                                                                        idMoneda, dFecSolici, idUsuRegist, nValAproba);
                                    //string cSolicitudesApr = "";
                                    int idEstSol = 0;
                                    int idSolApr = 0;
                                    //---========================================================================
                                    //--Validamos si Existe Solicitudes
                                    //---========================================================================
                                    if (dtConsultaSolApr.Rows.Count > 0)//Siempre devolverá solo una fila
                                    {
                                        //--==========================================
                                        //--Asignamos el Estado de la Solicitud
                                        //--==========================================
                                        idSolApr = Convert.ToInt32(dtConsultaSolApr.Rows[0]["idSolAproba"].ToString());
                                        idEstSol = Convert.ToInt32(dtConsultaSolApr.Rows[0]["idEstadoSol"].ToString());
                                        switch (idEstSol)
                                        {
                                            case 1: //--Solicitado
                                                //--------------------------------------------------------------------
                                                //---Mensaje que Indica que Esta a la espera de la Aprobación
                                                //--------------------------------------------------------------------
                                                MessageBox.Show(dtReglas.Rows[f]["cMensajeError"].ToString() + Environment.NewLine +
                                                                            "Ya Fue Registrado, Está a la Espera de la:" + Environment.NewLine +
                                                                            "APROBACIÓN DE LA AUTORIZACIÓN:", "Niveles de Autorización:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                break;
                                            case 2: //--Aprobado
                                                //--------------------------------------------------------------------
                                                //--Cuando es Aprobado la Sol,se actualiza resultado de la regla
                                                //--------------------------------------------------------------------
                                                dtReglas.Rows[f]["lResul"] = "OK";
                                                nContadorReglasCumplidas++;

                                                DataRow dr = dtSolApr.NewRow();
                                                dr["idSolApr"] = idSolApr;
                                                dtSolApr.Rows.Add(dr);

                                                break;
                                            case 4: //--Rechazado
                                                //--------------------------------------------------------------------
                                                //--mostrar toda la reglas que no se cumplen
                                                //--------------------------------------------------------------------
                                                DialogResult cRespuesta = MessageBox.Show("SU SOLICITUD DE APROBACIÓN A SIDO RECHAZADO..." + Environment.NewLine + ""
                                                                                        + Environment.NewLine +
                                                                                        "DESEA REGISTRAR NUEVAMENTE...."
                                                                                        , "Solicitud de Nivel de Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (cRespuesta.Equals(DialogResult.Yes))
                                                {
                                                    string cSustento = "Solicito Autorización, para Realizar la Operación";
                                                    DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                        idEstadoOperac, idMoneda, idProducto,
                                                                                        nValAproba, idDocument, dFecSolici,
                                                                                        idMotivo, cSustento, idEstadoSol,
                                                                                        dFecAprSol, idUsuRegist, true);
                                                    if (dtRespuesta.Rows.Count > 0)
                                                    {
                                                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + Environment.NewLine +
                                                                                    "POR FAVOR COORDINAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("ERROR AL REGISTRAR SU SOLICITUD DE AUTORIZACIÓN,..." + Environment.NewLine +
                                                                                    "POR FAVOR VERIFICAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else  //--Si no Existe Solicitud de Aprobación Registrada
                                    {
                                        //--==========================================================================
                                        //--Registramos la Solicitu de Nivel de Autorización
                                        //--==========================================================================
                                        DialogResult cRespuesta = MessageBox.Show("DESEA REGISTRAR LA SOLICITUD DE AUTORIZACIÓN..."
                                                                                        , "Solicitud de Nivel de Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (cRespuesta.Equals(DialogResult.Yes))
                                        {
                                            string cSustento = "Solicito Autorización, para Realizar la Operación";
                                            DataTable dtRespuesta = GuardarSolicitudAprobac(idAgencia, idCliente, Convert.ToInt32(dtReglas.Rows[f]["idTipoOperacion"].ToString()),
                                                                                idEstadoOperac, idMoneda, idProducto,
                                                                                nValAproba, idDocument, dFecSolici,
                                                                                idMotivo, cSustento, idEstadoSol,
                                                                                dFecAprSol, idUsuRegist, true);
                                            if (dtRespuesta.Rows.Count > 0)
                                            {
                                                MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString() + Environment.NewLine +
                                                                            "POR FAVOR COORDINAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                idSolApr = Convert.ToInt32(dtRespuesta.Rows[0]["idSolAproba"].ToString());
                                            }
                                            else
                                            {
                                                MessageBox.Show("ERROR AL REGISTRAR SU SOLICITUD DE AUTORIZACIÓN,..." + Environment.NewLine +
                                                                            "POR FAVOR VERIFICAR...", "Solicitud de Nivel de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                            }
                        }
                        else//Cuando ["lIndExcepcion"]=0
                        {
                            //======================================================================
                            //  Recorrer toda la coleccion y mostrar las reglas que no se cumplen:
                            //======================================================================
                            string cReglasNoCumplen = "";
                            for (int i = 0; i < dtReglas.Rows.Count; i++)
                            {
                                if (dtReglas.Rows[i]["lResul"].Equals("NO") && (Convert.ToBoolean(dtReglas.Rows[i]["lAlertaRiesgo"]) == false))
                                {
                                    cReglasNoCumplen = cReglasNoCumplen + "Regla " + dtReglas.Rows[i]["nIdRegla"].ToString() + " : " + dtReglas.Rows[i]["cMensajeError"].ToString() + Environment.NewLine;
                                }
                            }
                            MessageBox.Show(cReglasNoCumplen, "Validar Reglas de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        nContadorReglasCumplidas++;
                    }
                }
            }
            //===============================================================
            //  Verificar cumplimiento reglas del negocio
            //===============================================================
            if (nContadorReglasCumplidas == nCantReglasNegocio)
            {//actualizar Estado de la solicitud -- Tabla SI_FinSolicitud
                cResultadoValidacion = "Cumple";
            }
            else
            {
                cResultadoValidacion = "NoCumple";

            }

            return cResultadoValidacion;
        }

        private DialogResult cargarFormSustento(string cTituloVentana, string cTextoLabel, ref string cSustento, ref bool lExcepcion, bool lBloqNoExcepcion)
        {
            frmExcepcion frmexcepcion = new frmExcepcion();
            frmexcepcion.cTituloVentana = cTituloVentana;
            frmexcepcion.cTextoLabel = cTextoLabel;
            frmexcepcion.lBloqNoExcepcion = lBloqNoExcepcion;
            var dialogResult = DialogResult.Cancel;

            frmexcepcion.ShowDialog();

            if (frmexcepcion.lAcepto)
            {
                dialogResult = DialogResult.OK;
            }

            cSustento = frmexcepcion.cSustento;
            lExcepcion = frmexcepcion.lExcepcion;

            return dialogResult;
        }

        private string ReemplazarParametrosEnFuncion(string cCadenaFuncion, string cNombreParametro, string cValorParametro)
        {
            string cResultReemplazo = "";
            cCadenaFuncion = cCadenaFuncion.Replace(" ", "");

            //funcX(A,B,C)
            //obtener solo el nombre de la funcion -- funcX
            string cNombreFuncion = cCadenaFuncion.Substring(0, cCadenaFuncion.IndexOf('('));
            //obtner solo los parametros de la funcion -- A,B,C
            string cParametrosFuncion = cCadenaFuncion.Substring(cCadenaFuncion.IndexOf('(') + 1, cCadenaFuncion.Length - cCadenaFuncion.IndexOf('(') - 2);

            string[] cParametros = cParametrosFuncion.Split(',');

            //reemplazar
            if (cParametros.Length != 0)
            {
                for (int i = 0; i < cParametros.Length; i++)
                {
                    if (cParametros[i].Equals(cNombreParametro))
                    {
                        cParametros[i] = cValorParametro;
                    }
                    //juntar los campos como una cadena
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
            //cCadenaRegla   :   Cadena sobre la cual se hará la búsqueda
            //cNombreCampo   :   nombre del 'CAMPO' a ubicar en la cCadenaRegla
            //cValorCampo    :   Valor que se desea reemplazar sobre 'CAMPO' buscado en la cCadenaRegla
            int nContCaracter;
            cCadenaRegla = cCadenaRegla.ToUpper();
            cNombreCampo = cNombreCampo.ToUpper();
            //<calcular la posible cantidad de Campos>
            int nSwitch = 0;                //servirá para salir de un bucle
            int nPosicion = 0;              //ubica la posicion de 'CAMPO' buscado dentro de la cCadenaRegla
            int cCantPosiblesCampos = 0;    //Cantidad de incidencias parecidas a 'CAMPO' buscado -- Ejemplo ABC nABC xABCy  entonces cCantPosiblesCampos=3
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
            //</calcular la posible cantidad de Campos>

            cCadenaAuxiliar = cCadenaRegla;   //cadena que se ira recortando según se encuentre el 'CAMPO' buscado para reemplazar
            nContCaracter = 0;      //contador de caracteres adicionales posteriores sobre el nombre del 'CAMPO' buscado para reemplazar
            //ejemplo CAMPO buscado = ABC campo parecido ABCnm (nContCaracter=2 debido a nm)
            string cCadCambios = cCadenaRegla.Substring(0, 0);//cadena que se irá concatenando una vez identificado el 'CAMPO' con los cambios ('VALOR CAMPO') respectivos
            //Iterar de acuerdo a la cantidad de posibles de CAMPOS sobre el cual se verificará si se debe cambiar o no por 'VALOR CAMPO'
            for (int i = 0; i < cCantPosiblesCampos; i++)
            {
                int indiceUbicacion = cCadenaAuxiliar.IndexOf(cNombreCampo);
                //Identificar al caracter anterior al 'CAMPO' buscado
                string cAntesCampo = CaracterAntes(cCadenaAuxiliar, indiceUbicacion);
                //Validar 'caracter anterior' sea un caracter permitido
                if (CompararCaracter(cAntesCampo))
                {
                    //Identificar al caracter despues del 'CAMPO' buscado
                    string cDespuesCampo = CaracterDespues(cCadenaAuxiliar, indiceUbicacion, cNombreCampo);
                    //Validar 'caracter despues' sea un caracter permitido
                    if (CompararCaracter(cDespuesCampo))
                    {
                        //reemplazar el 'CAMPO' buscado por 'VALOR CAMPO'
                        cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion) + cValorCampo;
                        //recortar la cadena en la que se irá buscando el 'CAMPO'
                        cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + cNombreCampo.Length, cCadenaAuxiliar.Length - (indiceUbicacion + cNombreCampo.Length));
                    }
                    else
                    {
                        nContCaracter = 1;//porque ya se ha consultado una caracter de adelante
                        nSwitch = 0;
                        while (nSwitch == 0)
                        {
                            //variable auxiliar que contendra el 'CAMPO' más los caracteres que lo diferencian de 'CAMPO' buscado
                            //Ejemplo 'CAMPO'  es ABC  -- podria ser cAuxiliar=ABCnm
                            string cAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion, cNombreCampo.Length + nContCaracter);

                            //Identificar al caracter después al 'CAMPO' buscado y validarlo
                            string cCaracter = cCadenaAuxiliar.Substring(indiceUbicacion + cAuxiliar.Length, 1);
                            if (CompararCaracter(cCaracter))
                            {
                                //Actualizar la cadena resultante qu e voy a retornar
                                cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion) + cAuxiliar;
                                //recortar la cadena en la que se irá buscando el 'CAMPO'
                                cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + cAuxiliar.Length, cCadenaAuxiliar.Length - (indiceUbicacion + cAuxiliar.Length));
                                nSwitch++;
                            }
                            else
                            {
                                nContCaracter++;
                            }
                        }//</fin while>
                    }//</fin else>
                }
                else
                {
                    nContCaracter = 0;
                    nSwitch = 0;
                    while (nSwitch == 0)
                    {
                        //variable auxiliar que contendra el 'CAMPO' más los caracteres que lo diferencian de 'CAMPO' buscado
                        //Ejemplo 'CAMPO'  es ABC  -- podria ser cAuxiliar = ABCnm
                        string auxiliar = cCadenaAuxiliar.Substring(indiceUbicacion, cNombreCampo.Length + nContCaracter);
                        //Identificar al caracter después al 'CAMPO' buscado y validarlo
                        string cCaracter = cCadenaAuxiliar.Substring(indiceUbicacion + auxiliar.Length, 1);
                        if (CompararCaracter(cCaracter))
                        {
                            //Actualizar la cadena resultante qu e voy a retornar
                            cCadCambios = cCadCambios + cCadenaAuxiliar.Substring(0, indiceUbicacion + cNombreCampo.Length + nContCaracter);
                            //recortar la cadena en la que se irá buscando el 'CAMPO'
                            cCadenaAuxiliar = cCadenaAuxiliar.Substring(indiceUbicacion + auxiliar.Length, cCadenaAuxiliar.Length - (indiceUbicacion + auxiliar.Length));
                            nSwitch++;
                        }
                        else
                        {
                            nContCaracter++;
                        }
                    }//</fin while>
                }//</fin else>
            }//</fin for>

            //siempre va quedar la cadena recortada en cCadenaAuxiliar
            cCadCambios = cCadCambios + cCadenaAuxiliar;
            return cCadCambios;
        }

        private string CaracterAntes(string cCadena, int nPosicion)
        {//devuelve al carcter anterior a la posicion en la cadena
            return cCadena.Substring(nPosicion - 1, 1);
        }

        private string CaracterDespues(string cCadena, int nPosicion, string cNombreCampo)
        {//devuelve al carácter posterior a la posicion en la cadena
            return cCadena.Substring(nPosicion + cNombreCampo.Length, 1);
        }

        private bool CompararCaracter(string cCaracter)
        {
            // Valida que sea un caracter permitido(válido)
            if (cCaracter.In("(", ")", "+", "-", "*", "/", "%", "=", ">", "<", " "))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Obtiene las Funciones (estado vigente) que se usan en las reglas Dinámicas de acuerdo al nombre de la Opción
        /// </summary>
        /// <param name="cNombreFormulario"></param>
        /// <returns></returns>
        public DataTable ObtenerFuncionesParaReglasDinamicas(string cNombreFormulario)
        {
            return ReglasDinamicas.ExtraeFuncionesReglasDinamicas(cNombreFormulario);
        }

        /// <summary>
        /// Obtiene todas las Funciones (En estado vigente y no vigente) que se usan en las Reglas Dinámicas de acuerdo al Identificador de la Opción
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        public DataTable ObtenerFuncionesDeReglasDinamicas(int idOpcion)
        {
            return ReglasDinamicas.ObtieneFuncionesParaReglasDinamicas(idOpcion);
        }

        /// <summary>
        /// Obtiene las Reglas (estado vigente) de acuerdo al nombre de la Opción
        /// </summary>
        /// <param name="cNombreFormulario"></param>
        /// <returns></returns>
        public DataTable ObtenerReglasReglasDinamicas(string cNombreFormulario, int idRegistroExcep)
        {
            return ReglasDinamicas.ExtraeReglasDinamicas(cNombreFormulario, idRegistroExcep);
        }

        /// <summary>
        /// Obtiene todas las Reglas (En estado vigente y no vigente) de acuerdo al Identificador de la Opción
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        public DataTable ObtenerReglasPorOpcion(int idOpcion)
        {
            return ReglasDinamicas.ObtieneReglasDinamicas(idOpcion);
        }

        private string CalcularValorFuncion(string cCadenaFuncion)
        {
            return ReglasDinamicas.CalcularValorFuncion(cCadenaFuncion);
        }

        public DataTable GuardarSolicitudAprobac(int idAgencia      , int idCliente     , int idTipoOperacion   , int idEstadoOperac    ,
                                                 int idMoneda       , int idProducto    , Decimal /*era double*/nValAproba     , int idDocument        ,
                                                 DateTime dFecSolici, int idMotivo      , string cSustento      , int idEstadoSol       ,
                                                 DateTime dFecAprSol, int idUsuRegist   , bool lExcepcion)
        {
            return ReglasDinamicas.GuardarSolicitudAprobac(idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto,
                                                           nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol,
                                                           dFecAprSol, idUsuRegist, lExcepcion);
        }

        public DataTable GuardarSolicitudExcepciones(int idSolicitud, int idUsuRegistra, string xml, int idFlag, string cNombreFormulario)
        {
            return ReglasDinamicas.GuardarSolicitudExcepciones(idSolicitud, idUsuRegistra, xml, idFlag, cNombreFormulario);
        }
        public DataTable GuardarSolicitudNOExcepciones(int idSolicitud, int idUsuRegistra, string xml, int idFlag, string cNombreFormulario)
        {
            return ReglasDinamicas.GuardarSolicitudNOExcepciones(idSolicitud, idUsuRegistra, xml, idFlag, cNombreFormulario);
        }

        /*
         * public DataTable GuardarSolicitudExcepcionesCred(int idAgencia, int idCliente, int idTipoOperacion, int idEstadoOperac,
                                                 int idMoneda       , int idProducto    , Decimal nValAproba     , int idDocument        ,
                                                 DateTime dFecSolici, int idMotivo      , string cSustento      , int idEstadoSol       ,
                                                 DateTime dFecAprSol, int idUsuRegist   , bool lExcepcion)
        {
            return ReglasDinamicas.GuardarSolicitudExcepciones(idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto,
                                                           nValAproba, idDocument, dFecSolici, idMotivo, cSustento, idEstadoSol,
                                                           dFecAprSol, idUsuRegist, lExcepcion);
        }
    */


        public DataTable ConsultaSolicitudesAprobadas(int idTipoOperacion, int idDocument)
        {
            return ReglasDinamicas.ConsultaSolicitudesAprobadas(idTipoOperacion, idDocument);
        }

        public DataTable ConsultaSolicitudesAprobadasCred(int idTipoOperacion, int idDocument)
        {
            return ReglasDinamicas.ConsultaSolicitudesAprobadasCred(idTipoOperacion, idDocument);
        }


        public DataTable CargarListaOpciones(int idModulo)
        {
            return ReglasDinamicas.CargarListaOpciones(idModulo);
        }

        public DataTable InsReglaDinamica(string XmlRegla)
        {
            return ReglasDinamicas.InsReglaDinamica(XmlRegla);
        }

        /// <summary>
        /// Consulta de Aprobación de Solicitud
        /// </summary>
        /// <param name="idTipoOperacion"></param>
        /// <param name="idDocument"></param>
        /// <param name="idProd"></param>
        /// <param name="idCli"></param>
        /// <param name="idMoneda"></param>
        /// <param name="dFechaSol"></param>
        /// <param name="idUsuReg"></param>
        /// <param name="nMontoOpe"></param>
        /// <returns></returns>
        public DataTable ConsultaAprobacionSolicitud(int idTipoOperacion, int idDocument, int idProd, int idCli,
                                        int idMoneda, DateTime dFechaSol, int idUsuReg, Decimal nMontoOpe)
        {
            return ReglasDinamicas.ConsultaAprobSolicitud(idTipoOperacion, idDocument, idProd, idCli,
                                                                idMoneda, dFechaSol, idUsuReg, nMontoOpe);
        }

        /// <summary>
        /// Actualiza Solicitud de Aprobación
        /// </summary>
        /// <param name="idSolApr"></param>
        /// <param name="idEstadoSol"></param>
        public void ActualizaSolicitudApr(int idSolApr, int idEstadoSol)
        {
            ReglasDinamicas.ActualizaSolicitudApr(idSolApr, idEstadoSol);
        }

        /// <summary>
        /// Consulta de Aprobación de Solicitud
        /// </summary>
        /// <param name="idDocument"></param>
        /// <param name="idProd"></param>
        /// <param name="idCli"></param>
        /// <param name="idMoneda"></param>
        /// <param name="dFechaSol"></param>
        /// <param name="idUsuReg"></param>
        /// <param name="nMontoOpe"></param>
        /// <returns></returns>
        public DataTable CNConsultaEstExcepExtorno(int idDocument, int idProd, int idCli, int idMoneda, DateTime dFechaSol, int idUsuReg, Decimal nMontoOpe)
        {
            return ReglasDinamicas.ADConsultaEstExcepExtorno(idDocument, idProd, idCli, idMoneda, dFechaSol, idUsuReg, nMontoOpe);
        }

        public DataTable CNUpdVigSolicitudAprob(int idDocument)
        {
            return ReglasDinamicas.ADUpdVigSolicitudAprob(idDocument);
        }

        private DataTable asignarValoresAFunciones(string xmlFunciones)
        {
            return ReglasDinamicas.asignarValoresAFunciones(xmlFunciones);
        }

        public DataTable CNValidarReglasClr(DataTable dtTablaParametros , string cNombreFormulario  , int idAgencia         ,   int idCliente   ,
                                    int idEstadoOperac          , int idMoneda              , int idProducto        ,   Decimal nValAproba,
                                    int idDocument              , DateTime dFecSolici       , int idMotivo          ,   int idEstadoSol ,
                                    int idUsuRegist)
        {
            return ReglasDinamicas.ADValidarReglasClr(dtTablaParametros , cNombreFormulario  ,  idAgencia         ,   idCliente         ,
                                                     idEstadoOperac     ,  idMoneda          ,  idProducto        ,   nValAproba ,
                                                     idDocument         ,  dFecSolici        ,  idMotivo          ,   idEstadoSol       ,
                                                     idUsuRegist);
        }

        public DataTable CNRegistrarSolAprExcepciones(string xmlReglas, int idAgencia, int idCliente, int idEstadoOperac, int idMoneda, int idProducto,
                                                        decimal nValAproba, int idDocument, DateTime dFecSolici, int idMotivo, int idEstadoSol,
                                                        DateTime dFecAprSol, int idUsuRegist)
        {
            return ReglasDinamicas.ADRegistrarSolAprExcepciones(xmlReglas, idAgencia, idCliente, idEstadoOperac, idMoneda, idProducto,
                                                        nValAproba, idDocument, dFecSolici, idMotivo, idEstadoSol, dFecAprSol, idUsuRegist);
        }

        public DataTable CNObtenerReglasConResultado(DataTable dtTablaParametros, string cNombreFormulario)
        {
            return ReglasDinamicas.ADObtenerReglasConResultado( dtTablaParametros, cNombreFormulario);
        }
        public DataTable obtenerCantidadExcepcionesManuales(int idSolicitud, string cNombreFormulario)
        {
            return ReglasDinamicas.obtenerCantidadExcepcionesManuales(idSolicitud, cNombreFormulario);
        }
        public List<clsReglaNegocio> buscarReglaNegocio(int idRegla, string cNombreForm, int idMetodoBusq, int idSolicitud)
        {
            DataTable dtReglas = this.ReglasDinamicas.buscarReglaNegocio(idRegla, cNombreForm, idMetodoBusq, idSolicitud);
            return (dtReglas.Rows.Count > 0) ?
                dtReglas.ToList<clsReglaNegocio>() as List<clsReglaNegocio> :
                new List<clsReglaNegocio>();
        }
        public DataTable ObtenerReglasReglasDinamicasCondiciones(string cNombreFormulario, int idRegistroExcep, string cTipoPer)
        {
            return ReglasDinamicas.ExtraeReglasDinamicasCondiciones(cNombreFormulario, idRegistroExcep, cTipoPer);
        }

        private DataTable ArmarTablaParametrosEvalPreRemo(DataTable dtTablaParametros, int idTipEvalConfig, string idCli1, string nMonto, string idSubProducto, string idTipEvalCred)
        {
            DataTable dtTablaParametrosEval = new DataTable();
            

            dtTablaParametrosEval.Columns.Add("cNombreCampo");
            dtTablaParametrosEval.Columns.Add("cValorCampo");

            
            DataRow drfila = dtTablaParametrosEval.NewRow();

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli1;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idTipEvalConfig";
            drfila[1] = idTipEvalConfig;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "nMontoSol";
            drfila[1] = nMonto;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "cIdTipEvalCred";
            drfila[1] = idTipEvalCred;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametrosEval.Rows.Add(drfila);


            return dtTablaParametrosEval;
        }
        private void ValidarVisitaPresencialRemota(DataTable dtTablaParametros, string cNombreFormulario)
        {
            string idCli1 = "";
            string nMonto = "";
            string idSubProducto1 = "";
            string cNombreCampo1 = "";
            string cValorCampo1 = "";
            string cModalidadCredito = "";
            for (int i = 0; i < dtTablaParametros.Rows.Count; i++)
            {
                cNombreCampo1 = dtTablaParametros.Rows[i]["cNombreCampo"].ToString();
                cValorCampo1 = dtTablaParametros.Rows[i]["cValorCampo"].ToString();
                if (cNombreCampo1 == "idCli")
                {
                    idCli1 = cValorCampo1;
                }
                if (cNombreCampo1 == "Monto")
                {
                    nMonto = cValorCampo1;
                }
                if (cNombreCampo1 == "SubProducto")
                {
                    idSubProducto1 = cValorCampo1;
                }
                if (cNombreCampo1 == "idModalidadCredito")
                {
                    cModalidadCredito = cValorCampo1;
                }
            }

            DataTable dtTipoEvaluacion = ReglasDinamicas.ADListaTipoEvaluacion();
            DataTable dtTipoEvaluacionCred = ReglasDinamicas.ADListaTipoEvaluacionCred(Convert.ToInt32(idSubProducto1), Convert.ToInt32(cModalidadCredito));

            string cMensajeEvaluacion = "";
            foreach (DataRow rowi in dtTipoEvaluacionCred.Rows)
            {
                foreach (DataRow rowj in dtTipoEvaluacion.Rows)
                {
                    int idTipEvalConfig = Convert.ToInt32(rowj["idTipEvalConfig"]);
                    string idTipEvalCred1 = rowi["idTipEvalCred"].ToString();
                    DataTable dtRespuestaEvalPreRem = ArmarTablaParametrosEvalPreRemo(dtTablaParametros, idTipEvalConfig, idCli1, nMonto, idSubProducto1, idTipEvalCred1);
                    string cCumpleReglas = new clsCNValidaReglaConfig().ValidarReglasConfig(dtRespuestaEvalPreRem, cNombreFormulario, idTipEvalConfig);

                    if (cCumpleReglas == "OK" && idTipEvalConfig == 3)
                    {
                        int idTipEvalCred2 = Convert.ToInt32(rowi["idTipEvalCred"]);
                        string cTipEvalCred2 = rowi["cEvaluacion"].ToString();
                        Tuple<int, string, int> listTipoEvaluacionTuple = new Tuple<int, string, int>(idTipEvalCred2, cTipEvalCred2, 1);
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                        cMensajeEvaluacion = cMensajeEvaluacion + idTipEvalCred2 + " :" + cTipEvalCred2 + ", Cumple con evaluación remota \n";

                    }else if (cCumpleReglas == "NO" && idTipEvalConfig == 3)
                    {
                        int idTipEvalCred2 = Convert.ToInt32(rowi["idTipEvalCred"]);
                        string cTipEvalCred2 = rowi["cEvaluacion"].ToString();
                        Tuple<int, string, int> listTipoEvaluacionTuple = new Tuple<int, string, int>(idTipEvalCred2, cTipEvalCred2, 0);
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                        cMensajeEvaluacion = cMensajeEvaluacion + idTipEvalCred2 + " :" + cTipEvalCred2 + ", No cumple con evaluación remota \n";

                    }
                }
            }
            if (cMensajeEvaluacion != "")
            {
                MessageBox.Show(cMensajeEvaluacion, "Tipo de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
