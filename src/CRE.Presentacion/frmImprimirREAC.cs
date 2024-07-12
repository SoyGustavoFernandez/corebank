using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmImprimirREAC : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        clsCNSolicitud cnSolicitud = new clsCNSolicitud();
        DataTable dtIntervinientes;
        DataTable dtGarantias;
        DataTable dtDatosREAC;
        int idSolicitud;
        int idMoneda;
        bool lClienteRecurente = false;
        clsCNAprobacion cnAprobacion = new clsCNAprobacion();


        public frmImprimirREAC()
        {
            InitializeComponent();
        }

        private void frmImprimirREAC_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[1,13]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.txtNroBusqueda.Focus();
            txtMontoSolicitado.Enabled = false;
            txtPlazoSolicitado.Enabled = false;
            txtFechaInicoSolicitado.Enabled = false;
            txtFechaFinSolicitado.Enabled = false;
            txtNombreBenficiario.Enabled = false;
            txtTipoCartaFianza.Enabled = false;
            txtCodigoProceso.Enabled = false;
            txtMontoPropuesto.Enabled = false;
            txtComision.Enabled = false;
            txtFechaInicioPropuesto.Enabled = false;
            txtFechaFinPropuesto.Enabled = false;
            txtGiroNegocio.Enabled = false;
            txtDestino.Enabled = false;
            txtGarantia.Enabled = false;
            txtConclusiones.Enabled = false;
            btnContinuar1.Enabled = false;
            btnImprimir1.Enabled = false;
            btnCancelar1.Enabled = false;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro Solicitud: ";
            formatearIntervinientes();
            formatearGarantias();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (conBusCuentaCli1.txtNroBusqueda.Text != "")
                cargarDatos();
        }
        private bool estaEnDatos(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');
            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }
        private void cargarDatos()
        {
            idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);
            DataTable dtSolicitud = cnSolicitud.ConsultaSolicitud(idSolicitud);
            if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]))) //carta fianza
            {
                MessageBox.Show("La solicitud no corresponde a una carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarControles();
                btnCancelar1.Enabled = false;
                btnImprimir1.Enabled = false;
                btnContinuar1.Enabled = false;
                this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                this.conBusCuentaCli1.Focus();
                return;
            }
            else
            {
                dtDatosREAC = cnCartaFianza.obtenerDatosClienteREAC(idSolicitud, Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]), Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]));
                if (Convert.ToInt32(dtDatosREAC.Rows[0]["idEstadoCartaFianza"]) != 2 && Convert.ToInt32(dtDatosREAC.Rows[0]["idEstadoCartaFianza"]) != 3)
                {
                    MessageBox.Show("La carta fianza no se encuentra en estado SOLICITADO", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarControles();
                    btnCancelar1.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnContinuar1.Enabled = false;
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    this.conBusCuentaCli1.Focus();
                    return;
                }
                dtIntervinientes = cnCartaFianza.listarIntervinientes(idSolicitud);
                dtGarantias = cnCartaFianza.listarGarantias(idSolicitud);
                if (dtGarantias.Rows.Count > 0)
                {
                    dtgGarantia.DataSource = dtGarantias;
                    formatearGarantias();
                }
                else
                {
                    dtgGarantia.DataSource = null;
                }
                if (dtIntervinientes.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtIntervinientes;
                    formatearIntervinientes();
                }
                else
                {
                    dtgIntervinientes.DataSource = null;
                }
                if (dtDatosREAC.Rows.Count > 0)
                {
                    idMoneda = Convert.ToInt32(dtDatosREAC.Rows[0]["idMoneda"].ToString());
                    lClienteRecurente = Convert.ToBoolean(dtDatosREAC.Rows[0]["lRecurente"].ToString());
                    txtMontoSolicitado.Text = dtDatosREAC.Rows[0]["nCapitalSolicitado"].ToString();
                    txtPlazoSolicitado.Text = dtDatosREAC.Rows[0]["nPlazoCuota"].ToString() + " Día(s)";
                    txtFechaInicoSolicitado.Text = dtDatosREAC.Rows[0]["dFechaDesembolsoSugerido"].ToString();
                    txtFechaFinSolicitado.Text = dtDatosREAC.Rows[0]["dFechaVenSolicitado"].ToString();
                    txtNombreBenficiario.Text = dtDatosREAC.Rows[0]["cBeneficiario"].ToString();
                    txtTipoCartaFianza.Text = dtDatosREAC.Rows[0]["cTipoCartaFianza"].ToString();
                    txtCodigoProceso.Text = dtDatosREAC.Rows[0]["cProcesoSelec"].ToString();
                    txtMontoPropuesto.Text = dtDatosREAC.Rows[0]["nCapitalPropuesto"].ToString();
                    txtComision.Text = dtDatosREAC.Rows[0]["cTEA"].ToString();
                    txtFechaInicioPropuesto.Text = dtDatosREAC.Rows[0]["dFechaDesembolsoPropuesto"].ToString();
                    txtFechaFinPropuesto.Text = dtDatosREAC.Rows[0]["dFechaVenPropuesto"].ToString();
                    txtGiroNegocio.Text = dtDatosREAC.Rows[0]["cDescGiroNegocio"].ToString();
                    txtDestino.Text = dtDatosREAC.Rows[0]["cDescDestino"].ToString();
                    txtGarantia.Text = dtDatosREAC.Rows[0]["cDescGarantia"].ToString();
                    txtConclusiones.Text = dtDatosREAC.Rows[0]["cConclusiones"].ToString();
                    btnCancelar1.Enabled = true;

                }

                DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idSolicitud);
                if (dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Validación: " + System.Environment.NewLine + dtValidar.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnContinuar1.Enabled = false;
                    btnImprimir1.Enabled = false;
                }
                else
                {
                    btnContinuar1.Enabled = ((Convert.ToInt32(dtDatosREAC.Rows[0]["nSolicitudesPendientes"].ToString()) > 0) ? false : true);
                    btnImprimir1.Enabled = true;
                }
                btnCancelar1.Enabled = true;
            }

        }

        private void limpiarControles()
        {
            conBusCuentaCli1.limpiarControles();
            dtIntervinientes.Rows.Clear();
            dtGarantias.Rows.Clear();
            dtgIntervinientes.DataSource = dtIntervinientes;
            formatearIntervinientes();
            dtgGarantia.DataSource = dtGarantias;
            formatearGarantias();
            txtMontoSolicitado.Text = "";
            txtPlazoSolicitado.Text = "";
            txtFechaInicoSolicitado.Text = "";
            txtFechaFinSolicitado.Text = "";
            txtNombreBenficiario.Text = "";
            txtTipoCartaFianza.Text = "";
            txtCodigoProceso.Text = "";
            txtMontoPropuesto.Text = "";
            txtComision.Text = "";
            txtFechaInicioPropuesto.Text = "";
            txtFechaFinPropuesto.Text = "";
            txtGiroNegocio.Text = "";
            txtDestino.Text = "";
            txtGarantia.Text = "";
            txtConclusiones.Text = "";
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
            btnCancelar1.Enabled = false;
            btnImprimir1.Enabled = false;
            btnContinuar1.Enabled = false;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.Focus();
            btnCargarFile1.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsIntervinientes", dtIntervinientes));
            dtslist.Add(new ReportDataSource("dsCartaFianza", dtDatosREAC));
            dtslist.Add(new ReportDataSource("dsGarantias", dtGarantias));

            string reportpath = "rptREAC.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void formatearIntervinientes()
        {
            if (dtgIntervinientes.DataSource != null)
            {
                foreach (DataGridViewColumn columna in dtgIntervinientes.Columns)
                {
                    columna.Visible = false;
                }
                dtgIntervinientes.Columns["cNombre"].Visible = true;
                dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;
                dtgIntervinientes.Columns["idCli"].Visible = true;

                dtgIntervinientes.Columns["cNombre"].HeaderText = "Nombre";
                dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Tipo Intervencion";
                dtgIntervinientes.Columns["idCli"].HeaderText = "Cod. Cliente";
            }
        }

        private void formatearGarantias()
        {
            if (dtgGarantia.DataSource != null)
            {
                dtgGarantia.Columns["cTipoGarantia"].HeaderText = "Tipo Garan.";
                dtgGarantia.Columns["cTipoGarantia"].Width = 110;
                dtgGarantia.Columns["nGravamen"].HeaderText = "Monto";
                dtgGarantia.Columns["nPorcentaje"].HeaderText = "%";
                dtgGarantia.Columns["nPorcentaje"].Width = 60;
            }
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            frmBuscarCartasFianza frmBuscarCartasFianza = new frmBuscarCartasFianza();
            frmBuscarCartasFianza.cargarCartasFianza(2);
            frmBuscarCartasFianza.ShowDialog();
            if (frmBuscarCartasFianza.idSolicitud > 0 && frmBuscarCartasFianza.lAceptar)
            {
                btnCargarFile1.Enabled = false;
                this.conBusCuentaCli1.txtNroBusqueda.Text = frmBuscarCartasFianza.idSolicitud.ToString();
                this.conBusCuentaCli1.consultar();
            }
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            DataTable dtActualizarEstado = cnCartaFianza.ActualizarEstadoCartaFianza(idSolicitud, 3);
            if (dtActualizarEstado.Rows.Count > 0 && Convert.ToInt32(dtActualizarEstado.Rows[0][0]) > 0)
            {
                MessageBox.Show(dtActualizarEstado.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string cSustento = "APROBACIÓN DE CARTA FIANZA";
            if (Convert.ToInt32(dtDatosREAC.Rows[0]["idPadre"]) > 0)
            {
                cSustento = "RENOVACION: APROBACIÓN DE CARTA FIANZA";
            }

            decimal nTipCamFij = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);


            int idAgencia = clsVarGlobal.nIdAgencia;
            int idCli = conBusCuentaCli1.nIdCliente;
            int idProducto = Convert.ToInt32(dtDatosREAC.Rows[0]["idProducto"]);
            decimal nMonto = Convert.ToDecimal(txtMontoPropuesto.Text);
            decimal nValAproba = (idMoneda == 1) ? nMonto : nMonto * nTipCamFij;

            clsCreditoProp objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idSolicitud);
            objCreditoProp.idOrigenCredProp = 5;
            string xmlCreditoProp = objCreditoProp.GetXml();

            clsDBResp objDbResp = cnCartaFianza.EnviarPropCartaFianza(idAgencia, idCli, 120, idProducto, nValAproba,
                                                                        idSolicitud, 1, cSustento, xmlCreditoProp,
                                                                        clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
            if (objDbResp.nMsje == 0)
            {
                btnContinuar1.Enabled = false;
                MessageBox.Show(objDbResp.cMsje, "Validación registro REPC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GeneraInformeRiesgos();
            }
            else
            {
                MessageBox.Show("Error al realizar la solicitud de aprobacion de carta fianza.", "Validación registro REPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private bool ValidarReglas()
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglas(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: this.Name,
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: 0,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: 1,
                                                                            idProducto: 1,
                                                                            nValAproba: 0,
                                                                            idDocument: 0,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 0,
                                                                            idEstadoSol: 1,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto);

            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            return false;
        }

        private DataTable ArmarTablaParametros()
        {
            clsCreditoProp objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idSolicitud);
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            int idCli = objCreditoProp.idCli;

            //Obtenemos los datos generales del cliente

            DataTable dtDatCli = new clsCNBuscarCli().GetDatosGenCli(idCli);

            foreach (DataColumn column in dtDatCli.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatCli.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatCli.Rows[0][column.ColumnName].ToString());
                }
            }

            DataTable dtDatSolCre = new clsCNSolicitud().CNGetDatGenCreSolCre(idSolicitud);

            foreach (DataColumn column in dtDatSolCre.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatSolCre.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatSolCre.Rows[0][column.ColumnName].ToString());
                }
            }
            decimal nMonCFOpiRiesgosCliNue = Convert.ToDecimal(clsVarApl.dicVarGen["nMonCFOpiRiesgosCliNue"]);
            decimal nMonCFOpiRiesgosCliRec = Convert.ToDecimal(clsVarApl.dicVarGen["nMonCFOpiRiesgosCliRec"]);



            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonCFOpiRiesgosCliNue";
            drfila[1] = nMonCFOpiRiesgosCliNue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonCFOpiRiesgosCliRec";
            drfila[1] = nMonCFOpiRiesgosCliRec;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipCamFij";
            drfila[1] = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nValAproba";
            drfila[1] = objCreditoProp.nMonto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTasaCompForm";
            drfila[1] = objCreditoProp.nTasaCompensatoria;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMonedaForm";
            drfila[1] = objCreditoProp.idMoneda;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacionForm";
            drfila[1] = objCreditoProp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProductoForm";
            drfila[1] = objCreditoProp.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelAprRanOpeForm";
            drfila[1] = objCreditoProp.idNivelAprRanOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotasForm";
            drfila[1] = objCreditoProp.nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTEAForm";
            drfila[1] = objCreditoProp.nTea;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOpe";
            drfila[1] = 120;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.Year.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void GeneraInformeRiesgos()
        {
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
            DataSet dsSolInfRiesgo = new DataSet("dssolici");
            DataTable dtSolInfRiesgo = new DataTable("dtSolInfRiesgo");
            dtSolInfRiesgo.Columns.Add("nIdRegla", typeof(int));
            dtSolInfRiesgo.Columns.Add("cMensajeError", typeof(string));


            DataTable dtReglasConResultado = new clsCNValidaReglasDinamicas().ObtenerReglasConResultado(dtParametros, this.Name);

            var resultReglasRiesgos = dtReglasConResultado.AsEnumerable()
                                            .Where(x => Convert.ToBoolean(x["lAlertaRiesgo"])
                                                && x["lResul"].ToString().Trim().ToUpper().Equals("OK"));

            if (resultReglasRiesgos.Any())
            {
                DataTable dtReglasRiesgos = resultReglasRiesgos.CopyToDataTable();
                DataRow drRegla = dtReglasRiesgos.Rows[0];
                DataRow drfila = dtSolInfRiesgo.NewRow();
                drfila["nIdRegla"] = Convert.ToInt32(drRegla["nIdRegla"]);
                drfila["cMensajeError"] = Convert.ToString(drRegla["cMensajeError"]);
                dtSolInfRiesgo.Rows.Add(drfila);

                dsSolInfRiesgo.Tables.Add(dtSolInfRiesgo);
                string XmlSoli = dsSolInfRiesgo.GetXml();
                XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                dsSolInfRiesgo.Clear();
                new clsCNInformeRiesgos().InsertSolicitudInformeRiesgos(XmlSoli, idSolicitud);

                MessageBox.Show("Se agregó el informe de riesgos para la solicitud.", "Actualizar estado de solicitud",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
