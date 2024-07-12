using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.CoreBank.Interface;
using EntityLayer;
using CRE.CapaNegocio;
using System.Data;
using GEN.Funciones;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RCP.CapaNegocio;

namespace WCF.CoreBank.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TipoVisita" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select TipoVisita.svc or TipoVisita.svc.cs at the Solution Explorer and start debugging.
	
    public class Visita : AbstractConexion , IVisita 
	{
        DataTable dtReset = new DataTable();
        public List<string[]> lsDataCliente = new List<string[]>();
        List<int> seccion = new List<int>();
        
        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        public DataTable dtEstadoresultados = new DataTable();
        public DataTable dtBalanceGeneral = new DataTable();
        public DataTable dtCliFicha = new DataTable();        

        public Visita()
        {
            this.setConectionString();
        }

        public IList<clsWCFTipoDocVisita> ListarTipoDocVisita(String cToken) 
        {
            IList<clsWCFTipoDocVisita> arr = dtReset.SoftToList<clsWCFTipoDocVisita>();
            DataTable dt = new clsCNVisitas(true).CNWSListarTipoDocVisita();
            arr = dt.SoftToList<clsWCFTipoDocVisita>();
            return arr;
        }

        public IList<clsWCFTipoVisitaPerfil> ListarTipoVisitaPerfil(String cToken)
        {
            clsDatosToken datosToken = new clsDatosToken();

            IList<clsWCFTipoVisitaPerfil> arr = dtReset.SoftToList<clsWCFTipoVisitaPerfil>();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dt = new clsCNEvaluacion(true).WCFCNGetTiposVisita(datosToken.idPerfil);
                arr = dt.SoftToList<clsWCFTipoVisitaPerfil>();
            }
            return arr;
        }

        public IList<clsWCFCreditosRecuperaciones> ListaCreditoRecuperacionesVisita(String cToken, int idCli)
        {
            IList<clsWCFCreditosRecuperaciones> objCredRecuperaciones = dtReset.SoftToList<clsWCFCreditosRecuperaciones>(); 

            clsDatosToken token = new clsDatosToken();
            DataTable dtCredRecuperaciones = new clsCNEvaluacion(true).WCFCNGetCreditoRecuperacionesVisita(idCli);

            objCredRecuperaciones = dtCredRecuperaciones.SoftToList<clsWCFCreditosRecuperaciones>();

            for (int i = 0; i < objCredRecuperaciones.Count; i++)
            {
                DataTable dtPlanPagosPendientes = new clsCNEvaluacion(true).WCFCNGetPlanPagosPendientes(objCredRecuperaciones[i].idCuenta);
                objCredRecuperaciones[i].pagosPendientes = dtPlanPagosPendientes.SoftToList<clsWCFPlanPagosPendientes>();
            }

            return objCredRecuperaciones;
        }

        public IList<clsWCFVisita> ListarVisitasFechaAsesor(String cToken)
        {         
            clsDatosToken datosToken = new clsDatosToken();

            IList<clsWCFVisita> arr = dtReset.SoftToList<clsWCFVisita>();
             datosToken = usuario.obtenerDatosToken(cToken);
             if (usuario.validaToken(cToken))
             {
                 DataTable dtVisitas = new clsCNEvaluacion(true).WCFCNGetVisitasFechaAsesor(datosToken.idUsuario, 6);
                 arr = dtVisitas.SoftToList<clsWCFVisita>();
             }
             return arr;
        }

        public clsWCFFichaVisita ListarFichaTipoVisita(String cToken, int  idCli, int nFicha, int idCuenta = 0)
		{
            clsDatosToken datosToken = new clsDatosToken();
            clsWCFFichaVisita obj = new clsWCFFichaVisita();
            clsCNEvaluacion cnEvaluacion = new clsCNEvaluacion(true);
            clsCNIntervCre cninterviniente = new clsCNIntervCre();
            clsCNBuscarCli cncliente = new clsCNBuscarCli();
            clsCNHojaRuta hojaRuta = new clsCNHojaRuta(true);
            DataTable dt = new DataTable();

            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                /*
                |---------------------------------------------------------------------
                | GENERAMOS LA FICHA CON PREGUNTAS
                |---------------------------------------------------------------------
                */
                DateTime dtime = DateTime.Now;
                obj.cCodigoFicha = dtime.ToString("yyMMddHHmmss"); //Generación de codigo único de ficha

                // DATOS DE FICHA :. (1) Pre desembolso | (2) Post desembolso 
               dtCliFicha = cnEvaluacion.WCFCNGetDataFichaCliente(idCli, nFicha, idCuenta);


                if (dtCliFicha.Rows.Count > 0)
                {
                    DataTable dtDirecciones = hojaRuta.CNDirNumTelPar(idCli, -1);
                    DataTable dtPregFicha = cnEvaluacion.WCFCNGetFichaVisita(nFicha);

                    //Data 
                    List<string> clave = new List<string>();

                    //Destino préstamo
                    if (dtCliFicha.Rows[0]["idEvalCred"] != DBNull.Value)
                    {
                        DataTable dtEval = cnEvaluacion.WCFCNDestinoCreditoEval(Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));
                        if (dtEval.Rows.Count > 0)
                        {
                            dtCliFicha.Columns.Remove("cDestinoPrestamo");
                            dtCliFicha.Columns.Add("cDestinoPrestamo", typeof(System.String));

                            dtCliFicha.Rows[0]["cDestinoPrestamo"] = "";
                            String temp = "";
                            foreach(DataRow row in dtEval.Rows) {
                                temp += "#" + row["cDestino"] + "......" + Convert.ToString(Convert.ToDecimal(row["nPorcentaje"]) * 100) + "%\n";
                            }
                            dtCliFicha.Rows[0]["cDestinoPrestamo"] = temp;

                        }
                    }

                    // DATA DE FICHA PARA SOLICITUDES CON EVALUACION
                    if (nFicha == 1)
                    {
                        if (dtCliFicha.Rows[0]["idTipEvalCred"] != DBNull.Value && dtCliFicha.Rows[0]["idEvalCred"] != DBNull.Value)
                        {
                            // Para balance general
                            dtBalanceGeneral = cnEvaluacion.WCFCNGetBalanceGeneral(Convert.ToInt32(dtCliFicha.Rows[0]["idTipEvalCred"]), Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));

                            if (dtBalanceGeneral.Rows.Count > 0)
                            {
                                this.crearItemBalanceGeneral(2, "nActivo"); //Activo total
                                this.crearItemBalanceGeneral(13, "nPasivo"); //Pasivo total
                                this.crearItemBalanceGeneral(21, "nPatrimonio"); //Patrimonio
                            }
                            else
                            {
                                dtPregFicha.AcceptChanges();

                                foreach (DataRow row in dtPregFicha.Rows)
                                {
                                    if (row["cName"].In("nActivo", "nPasivo", "nPatrimonio") || row["idFVPreg"].Equals(11))
                                    {
                                        row.Delete();
                                    }
                                }
                                dtPregFicha.AcceptChanges();
                            }

                            // Para Estado Resultados
                            dtEstadoresultados = cnEvaluacion.WCFCNGetEstadoResultados(Convert.ToInt32(dtCliFicha.Rows[0]["idTipEvalCred"]), Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));

                            if (dtEstadoresultados.Rows.Count > 0)
                            {
                                this.crearItemEstadoResultados(24, "nVentas"); //ventas
                                this.crearItemEstadoResultados(25, "nCostos"); //costos
                                this.crearItemEstadoResultados(28, "nUtilidadOperativa"); //utilidad operativa
                                this.crearItemEstadoResultados(31, "nOtrosIngresos"); //otros ingresos
                                this.crearItemEstadoResultados(35, "nIngresosNetosTitular"); //ingresos netos titular
                                this.crearItemEstadoResultados(36, "nIngresosNetosConyuge"); //ingresos netos conyuge
                                this.crearItemEstadoResultados(53, "nSaldoDisponible"); //saldo disponible
                                this.crearItemEstadoResultados(54, "nCuotaMaxEnd"); //Cuota máxima endeudamiento
                                this.crearItemEstadoResultados(57, "nCuotaMaxDisp"); //Cuota máxima disponible
                                this.crearItemEstadoResultados(34, "nUtilDispExcedente"); //Utilidad disponible excedente
                                this.crearItemEstadoResultados(35, "nIngresoBrutoBoleta"); //Ingreso bruto (boleta pago)
                                this.crearItemEstadoResultados(46, "nDescuentosJudc"); //Descuentos judiciales
                                this.crearItemEstadoResultados(47, "nDescuentosLeg"); //Descuentos legales/
                            }
                            else
                            {
                                dtPregFicha.AcceptChanges();
                                foreach (DataRow row in dtPregFicha.Rows)
                                {
                                    if (row["cName"].In("nVentas", "nCostos", "nUtilidadOperativa", "nOtrosIngresos") || row["idFVPreg"].Equals(15))
                                    {
                                        row.Delete();
                                    }
                                }
                                dtPregFicha.AcceptChanges();
                            }
                        }
                    }

                    //Secciones de ficha
                    //Cada uno de las posiciones de secciones de ficha pueden ser alteradas para su visualización
                    //addDataFicha(orden_de_seccion, titulo, datos_de_muestra)

                    addDataFicha(1, "titulo", "DATOS DEL CLIENTE");
                    if (nFicha == 2) { 
                        addDataFicha(1, "Nro de cuenta", dtCliFicha.Rows[0]["idCuenta"].ToString()); 
                    }

                    addDataFicha(1, "Cliente",          dtCliFicha.Rows[0]["cNombre"].ToString());
                    addDataFicha(1, "Tipo de cliente",  dtCliFicha.Rows[0]["cTipoCliente"].ToString());
                    addDataFicha(1, "Código",           dtCliFicha.Rows[0]["idCli"].ToString());

                    addDataFicha(3, "titulo", "DIRECCIONES");

                    if (dtCliFicha.Rows[0]["idSolicitud"] != DBNull.Value)
                    {
                        addDataFicha(2, "Titulo", "DATOS DE LA SOLICITUD");
                        addDataFicha(2, "Producto",         dtCliFicha.Rows[0]["cProducto"].ToString());
                        addDataFicha(2, "Sub producto",     dtCliFicha.Rows[0]["cSubProducto"].ToString());
                        addDataFicha(2, "Nro de solicitud", dtCliFicha.Rows[0]["idSolicitud"].ToString());
                        addDataFicha(2, "Moneda",           dtCliFicha.Rows[0]["cMoneda"].ToString());
                        addDataFicha(2, "Monto",            dtCliFicha.Rows[0]["nCapitalAprobado"].ToString());
                        addDataFicha(2, "Plazo",            dtCliFicha.Rows[0]["nPlazoCuota"].ToString()+" meses");
                        addDataFicha(2, "Cuotas",           dtCliFicha.Rows[0]["nCuotas"].ToString());
                        addDataFicha(2, "Cuotas de gracia", dtCliFicha.Rows[0]["nCuotasGracia"].ToString());
                        addDataFicha(2, "Cuota Aprox.",     dtCliFicha.Rows[0]["nCuotaAprox"].ToString());
                    }

                    if (nFicha == 1)
                    {
                        addDataFicha(2, "Asesor Actual", dtCliFicha.Rows[0]["cNombreUsuario"].ToString());
                    }
                    else if (nFicha == 2)
                    {
                        addDataFicha(2, "Fecha Desembolso", dtCliFicha.Rows[0]["dFechaDesembolso"].ToString());
                        addDataFicha(2, "Fecha Prox Pago",  dtCliFicha.Rows[0]["dFechaProxPago"].ToString());
                        addDataFicha(2, "Fecha Ult Cuota",  dtCliFicha.Rows[0]["dUltCuota"].ToString());
                        addDataFicha(2, "Asesor Origen" ,    dtCliFicha.Rows[0]["cNombreAsesorOrigen"].ToString());
                        addDataFicha(2, "Asesor Actual",    dtCliFicha.Rows[0]["cNombreAsesorActual"].ToString());
                    }

                    addDataFicha(4, "titulo", "DATOS DE LA EVALUACIÓN");                    
                    addDataFicha(5, "titulo", "OTRAS CONSIDERACIONES");

                    int totalSeccion = contarSeccion();
                    int i = 0;

                    IList<clsFVItems> myList = new List<clsFVItems>();
                    DataTable dtClear = new DataTable();

                    for (int x = 0; x < totalSeccion; x++)
                    {
                        for (int y = 0; y < lsDataCliente.Count; y++)
                        {
                            if (Convert.ToInt32(lsDataCliente[y][0]) == seccion[x])
                            {
                                clsFVItems listDataLocal = new clsFVItems();
                                listDataLocal.idFVGrupo = Convert.ToInt32(lsDataCliente[y][0]);
                                listDataLocal.cPregunta = lsDataCliente[y][1];
                                listDataLocal.cInfo = lsDataCliente[y][2];
                                listDataLocal.listOpciones = dtClear.SoftToList<clsFVOpcionPregunta>();
                                myList.Add(listDataLocal);
                            }
                        }

                        foreach (DataRow row in dtPregFicha.Rows)
                        {
                            if (Convert.ToInt32(row["idFVGrupo"]) == seccion[x])
                            {
                                if (Convert.ToInt32(row["idFVPreg"]) != i)
                                {
                                    int idPreg = Convert.ToInt32(row["idFVPreg"]);                                   

                                    if (row["idFVFichaPregOpc"] == DBNull.Value || row["idFVFichaPregOpc"].Equals(""))
                                    {
                                        dt = new DataTable();
                                    }
                                    else
                                    {
                                        DataRow[] selectedRows = dtPregFicha.Select("idFVPreg=" + idPreg);
                                        dt = selectedRows.CopyToDataTable<DataRow>();
                                    }

                                    clsFVItems preg = new clsFVItems();

                                    // SECCION 3 - Para direcciones
                                    if (Convert.ToInt32(row["idFVGrupo"]) == 3)
                                    {
                                        foreach (DataRow rowd in dtDirecciones.Rows)
                                        {
                                            clsFVItems pregd = new clsFVItems();
                                            pregd.idFVPreg = Convert.ToInt32(row["idFVPreg"]);
                                            pregd.idFVGrupo = Convert.ToInt32(row["idFVGrupo"]);
                                            pregd.cPregunta = "";
                                            pregd.cInfo =
                                                rowd["cTipoDir"].ToString() + "\n" +
                                                rowd["cDireccion"].ToString() + "\n" +
                                                "Referencia: " + rowd["cReferenciaDireccion"].ToString();
                                            pregd.cPreguntaAdicional = row["cPreguntaAdicional"].ToString();
                                            pregd.cName = row["cName"].ToString();                                           
                                            pregd.lOrientacionVertical = false;
                                            pregd.listOpciones = dt.SoftToList<clsFVOpcionPregunta>();
                                            myList.Add(pregd);
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            preg.idFVPreg = Convert.ToInt32(row["idFVPreg"]);
                                            preg.idFVGrupo = Convert.ToInt32(row["idFVGrupo"]);
                                            preg.cPregunta = row["cPregunta"].ToString();
                                            preg.cPreguntaAdicional = row["cPreguntaAdicional"].ToString();
                                            preg.cName = row["cName"].ToString();
                                            preg.cInfo = row["cName"].Equals("") ? "" : dtCliFicha.Rows[0][row["cName"].ToString()].ToString();
                                            preg.lOrientacionVertical = Convert.ToBoolean(row["lOrientacionVertical"]);
                                            preg.listOpciones = dt.SoftToList<clsFVOpcionPregunta>();                                           
                                            myList.Add(preg);
                                        } catch(Exception e) {
                                            Console.WriteLine(e);
                                        }
                                    }
                                    i = idPreg;
                                }
                            }
                        }
                    }
                    obj.listItems = myList;
                }
                else {
                    obj.listItems = dt.SoftToList<clsFVItems>();
                }
            }            
            return obj;
		}

        public IList<clsFVItemsRespuesta> ListarFichaTipoVisitaRespuesta(int idVisita)
        {
            clsDatosToken datosToken = new clsDatosToken();
            IList<clsFVItemsRespuesta> obj = new List<clsFVItemsRespuesta>();
            clsCNEvaluacion cnEvaluacion = new clsCNEvaluacion(true);
            clsCNIntervCre cninterviniente = new clsCNIntervCre();
            clsCNBuscarCli cncliente = new clsCNBuscarCli();
            clsCNHojaRuta hojaRuta = new clsCNHojaRuta(true);
            DataTable dt = new DataTable();

            DataTable datosVisita = cnEvaluacion.WCFCNGetDatosVisita(idVisita);

            if (datosVisita.Rows.Count > 0)
            {
                int idCli = Convert.ToInt32(datosVisita.Rows[0]["idCliente"].ToString());
                int idCuenta = Convert.ToInt32(datosVisita.Rows[0]["idCuenta"].ToString());
                int nFicha = Convert.ToInt32(datosVisita.Rows[0]["nFicha"].ToString());

                if (nFicha != 0)
                {
                    // DATOS DE FICHA :. (1) Pre desembolso | (2) Post desembolso 
                    dtCliFicha = cnEvaluacion.WCFCNGetDataFichaCliente(idCli, nFicha, idCuenta);


                    if (dtCliFicha.Rows.Count > 0)
                    {
                        DataTable dtDirecciones = hojaRuta.CNDirNumTelPar(idCli, -1);
                        DataTable dtPregFicha = cnEvaluacion.WCFCNGetFichaVisitaRespuesta(nFicha, idVisita);

                        //Data 
                        List<string> clave = new List<string>();

                        //Destino préstamo
                        if (dtCliFicha.Rows[0]["idEvalCred"] != DBNull.Value)
                        {
                            DataTable dtEval = cnEvaluacion.WCFCNDestinoCreditoEval(Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));
                            if (dtEval.Rows.Count > 0)
                            {
                                dtCliFicha.Columns.Remove("cDestinoPrestamo");
                                dtCliFicha.Columns.Add("cDestinoPrestamo", typeof(System.String));

                                dtCliFicha.Rows[0]["cDestinoPrestamo"] = "";
                                String temp = "";
                                foreach (DataRow row in dtEval.Rows)
                                {
                                    temp += "#" + row["cDestino"] + "......" + Convert.ToString(Convert.ToDecimal(row["nPorcentaje"]) * 100) + "%\n";
                                }
                                dtCliFicha.Rows[0]["cDestinoPrestamo"] = temp;

                            }
                        }

                        // DATA DE FICHA PARA SOLICITUDES CON EVALUACION
                        if (nFicha == 1)
                        {
                            if (dtCliFicha.Rows[0]["idTipEvalCred"] != DBNull.Value && dtCliFicha.Rows[0]["idEvalCred"] != DBNull.Value)
                            {
                                // Para balance general
                                dtBalanceGeneral = cnEvaluacion.WCFCNGetBalanceGeneral(Convert.ToInt32(dtCliFicha.Rows[0]["idTipEvalCred"]), Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));

                                if (dtBalanceGeneral.Rows.Count > 0)
                                {
                                    this.crearItemBalanceGeneral(2, "nActivo"); //Activo total
                                    this.crearItemBalanceGeneral(13, "nPasivo"); //Pasivo total
                                    this.crearItemBalanceGeneral(21, "nPatrimonio"); //Patrimonio
                                }
                                else
                                {
                                    dtPregFicha.AcceptChanges();

                                    foreach (DataRow row in dtPregFicha.Rows)
                                    {
                                        if (row["cName"].In("nActivo", "nPasivo", "nPatrimonio") || row["idFVPreg"].Equals(11))
                                        {
                                            row.Delete();
                                        }
                                    }
                                    dtPregFicha.AcceptChanges();
                                }

                                // Para Estado Resultados
                                dtEstadoresultados = cnEvaluacion.WCFCNGetEstadoResultados(Convert.ToInt32(dtCliFicha.Rows[0]["idTipEvalCred"]), Convert.ToInt32(dtCliFicha.Rows[0]["idEvalCred"]));

                                if (dtEstadoresultados.Rows.Count > 0)
                                {
                                    this.crearItemEstadoResultados(24, "nVentas"); //ventas
                                    this.crearItemEstadoResultados(25, "nCostos"); //costos
                                    this.crearItemEstadoResultados(28, "nUtilidadOperativa"); //utilidad operativa
                                    this.crearItemEstadoResultados(31, "nOtrosIngresos"); //otros ingresos
                                    this.crearItemEstadoResultados(35, "nIngresosNetosTitular"); //ingresos netos titular
                                    this.crearItemEstadoResultados(36, "nIngresosNetosConyuge"); //ingresos netos conyuge
                                    this.crearItemEstadoResultados(53, "nSaldoDisponible"); //saldo disponible
                                    this.crearItemEstadoResultados(54, "nCuotaMaxEnd"); //Cuota máxima endeudamiento
                                    this.crearItemEstadoResultados(57, "nCuotaMaxDisp"); //Cuota máxima disponible
                                    this.crearItemEstadoResultados(34, "nUtilDispExcedente"); //Utilidad disponible excedente
                                    this.crearItemEstadoResultados(35, "nIngresoBrutoBoleta"); //Ingreso bruto (boleta pago)
                                    this.crearItemEstadoResultados(46, "nDescuentosJudc"); //Descuentos judiciales
                                    this.crearItemEstadoResultados(47, "nDescuentosLeg"); //Descuentos legales/
                                }
                                else
                                {
                                    dtPregFicha.AcceptChanges();
                                    foreach (DataRow row in dtPregFicha.Rows)
                                    {
                                        if (row["cName"].In("nVentas", "nCostos", "nUtilidadOperativa", "nOtrosIngresos") || row["idFVPreg"].Equals(15))
                                        {
                                            row.Delete();
                                        }
                                    }
                                    dtPregFicha.AcceptChanges();
                                }
                            }
                        }

                        //Secciones de ficha
                        //Cada uno de las posiciones de secciones de ficha pueden ser alteradas para su visualización
                        //addDataFicha(orden_de_seccion, titulo, datos_de_muestra)

                        addDataFicha(1, "titulo", "DATOS DEL CLIENTE");
                        if (nFicha == 2)
                        {
                            addDataFicha(1, "Nro de cuenta", dtCliFicha.Rows[0]["idCuenta"].ToString());
                        }

                        addDataFicha(1, "Cliente", dtCliFicha.Rows[0]["cNombre"].ToString());
                        addDataFicha(1, "Tipo de cliente", dtCliFicha.Rows[0]["cTipoCliente"].ToString());
                        addDataFicha(1, "Código", dtCliFicha.Rows[0]["idCli"].ToString());

                        addDataFicha(3, "titulo", "DIRECCIONES");

                        if (dtCliFicha.Rows[0]["idSolicitud"] != DBNull.Value)
                        {
                            addDataFicha(2, "Titulo", "DATOS DE LA SOLICITUD");
                            addDataFicha(2, "Producto", dtCliFicha.Rows[0]["cProducto"].ToString());
                            addDataFicha(2, "Sub producto", dtCliFicha.Rows[0]["cSubProducto"].ToString());
                            addDataFicha(2, "Nro de solicitud", dtCliFicha.Rows[0]["idSolicitud"].ToString());
                            addDataFicha(2, "Moneda", dtCliFicha.Rows[0]["cMoneda"].ToString());
                            addDataFicha(2, "Monto", dtCliFicha.Rows[0]["nCapitalAprobado"].ToString());
                            addDataFicha(2, "Plazo", dtCliFicha.Rows[0]["nPlazoCuota"].ToString() + " meses");
                            addDataFicha(2, "Cuotas", dtCliFicha.Rows[0]["nCuotas"].ToString());
                            addDataFicha(2, "Cuotas de gracia", dtCliFicha.Rows[0]["nCuotasGracia"].ToString());
                            addDataFicha(2, "Cuota Aprox.", dtCliFicha.Rows[0]["nCuotaAprox"].ToString());
                        }

                        if (nFicha == 1)
                        {
                            addDataFicha(2, "Asesor Actual", dtCliFicha.Rows[0]["cNombreUsuario"].ToString());
                        }
                        else if (nFicha == 2)
                        {
                            addDataFicha(2, "Fecha Desembolso", dtCliFicha.Rows[0]["dFechaDesembolso"].ToString());
                            addDataFicha(2, "Fecha Prox Pago", dtCliFicha.Rows[0]["dFechaProxPago"].ToString());
                            addDataFicha(2, "Fecha Ult Cuota", dtCliFicha.Rows[0]["dUltCuota"].ToString());
                            addDataFicha(2, "Asesor Origen", dtCliFicha.Rows[0]["cNombreAsesorOrigen"].ToString());
                            addDataFicha(2, "Asesor Actual", dtCliFicha.Rows[0]["cNombreAsesorActual"].ToString());
                        }

                        addDataFicha(4, "titulo", "DATOS DE LA EVALUACIÓN");
                        addDataFicha(5, "titulo", "OTRAS CONSIDERACIONES");

                        int totalSeccion = contarSeccion();
                        int i = 0;

                        IList<clsFVItemsRespuesta> myList = new List<clsFVItemsRespuesta>();
                        DataTable dtClear = new DataTable();

                        for (int x = 0; x < totalSeccion; x++)
                        {
                            for (int y = 0; y < lsDataCliente.Count; y++)
                            {
                                if (Convert.ToInt32(lsDataCliente[y][0]) == seccion[x])
                                {
                                    clsFVItemsRespuesta listDataLocal = new clsFVItemsRespuesta();
                                    listDataLocal.idFVGrupo = Convert.ToInt32(lsDataCliente[y][0]);
                                    listDataLocal.cPregunta = lsDataCliente[y][1];
                                    listDataLocal.cInfo = lsDataCliente[y][2];
                                    myList.Add(listDataLocal);
                                }
                            }

                            foreach (DataRow row in dtPregFicha.Rows)
                            {
                                if (Convert.ToInt32(row["idFVGrupo"]) == seccion[x])
                                {
                                    if (Convert.ToInt32(row["idFVPreg"]) != i)
                                    {
                                        int idPreg = Convert.ToInt32(row["idFVPreg"]);

                                        if (row["idFVFichaPregOpc"] == DBNull.Value || row["idFVFichaPregOpc"].Equals(""))
                                        {
                                            dt = new DataTable();
                                        }
                                        else
                                        {
                                            DataRow[] selectedRows = dtPregFicha.Select("idFVPreg=" + idPreg);
                                            dt = selectedRows.CopyToDataTable<DataRow>();
                                        }

                                        clsFVItemsRespuesta preg = new clsFVItemsRespuesta();

                                        // SECCION 3 - Para direcciones
                                        if (Convert.ToInt32(row["idFVGrupo"]) == 3)
                                        {
                                            foreach (DataRow rowd in dtDirecciones.Rows)
                                            {
                                                clsFVItemsRespuesta pregd = new clsFVItemsRespuesta();
                                                pregd.idFVPreg = Convert.ToInt32(row["idFVPreg"]);
                                                pregd.idFVGrupo = Convert.ToInt32(row["idFVGrupo"]);
                                                pregd.cPregunta = "";
                                                pregd.cInfo =
                                                    rowd["cTipoDir"].ToString() + "\n" +
                                                    rowd["cDireccion"].ToString() + "\n" +
                                                    "Referencia: " + rowd["cReferenciaDireccion"].ToString();
                                                pregd.cPreguntaAdicional = row["cPreguntaAdicional"].ToString();
                                                pregd.cName = row["cName"].ToString();
                                                pregd.cOpcionRespuesta = row["cOpcion"].ToString();
                                                pregd.cRespuestaTexto = row["cRespuestaTexto"].ToString();
                                                myList.Add(pregd);
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                preg.idFVPreg = Convert.ToInt32(row["idFVPreg"]);
                                                preg.idFVGrupo = Convert.ToInt32(row["idFVGrupo"]);
                                                preg.cPregunta = row["cPregunta"].ToString();
                                                preg.cPreguntaAdicional = row["cPreguntaAdicional"].ToString();
                                                preg.cName = row["cName"].ToString();
                                                preg.cInfo = row["cName"].Equals("") ? "" : dtCliFicha.Rows[0][row["cName"].ToString()].ToString();
                                                preg.cOpcionRespuesta = row["cOpcion"].ToString();
                                                preg.cRespuestaTexto = row["cRespuestaTexto"].ToString();
                                                myList.Add(preg);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e);
                                            }
                                        }
                                        i = idPreg;
                                    }
                                }
                            }
                        }
                        obj = myList;
                    }
                    else
                    {
                        obj = dt.SoftToList<clsFVItemsRespuesta>();
                    }
                }
            }
            return obj;
        }

        //Crea campos para tabla balance general
        public void crearItemBalanceGeneral(int referencia, string name)
        {
            if (dtBalanceGeneral.Select("idEEFF=" + referencia).Count() != 0)
            {
                dtCliFicha.Columns.Add(name, typeof(System.Decimal));
                dtCliFicha.Rows[0][name] = Convert.ToDecimal(dtBalanceGeneral.Select("idEEFF=" + referencia).AsEnumerable().Take(1).CopyToDataTable().Rows[0]["nTotalMA"]);
            }
        }

        //Crea campos para tabla estado resultados
        public void crearItemEstadoResultados(int referencia, string name)
        {
            if (dtEstadoresultados.Select("idEEFF=" + referencia).Count() != 0)
            {
                dtCliFicha.Columns.Add(name, typeof(System.Decimal));
                dtCliFicha.Rows[0][name] = Convert.ToDecimal(dtEstadoresultados.Select("idEEFF=" + referencia).AsEnumerable().Take(1).CopyToDataTable().Rows[0]["nTotalMA"]);
            }
        }   
        
        public int contarSeccion()
        {
            int temp = 0;
            int cont = 0;
            for (int i = 0; i < lsDataCliente.Count; i++)
            {
                if (Convert.ToInt32(lsDataCliente[i][0]) != temp)
                {
                    cont++;
                    seccion.Add(Convert.ToInt32(lsDataCliente[i][0]));
                    temp = Convert.ToInt32(lsDataCliente[i][0]);
                }
            }
            return cont;
        }
        public void addDataFicha(int idGrupo, string cLabel, string cInfo)
        {
            String[] c = new String[3];
                c[0] = idGrupo.ToString();
                c[1] = cLabel;
                c[2] = cInfo;
            lsDataCliente.Add(c);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        
        public static bool In<T>(T obj, params T[] args)
        {
            return args.Contains(obj);
        }
	}
}
