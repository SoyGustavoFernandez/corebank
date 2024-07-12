using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using System.Xml.Serialization;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmNuevaEvConsumo : frmBase
    {
        #region Variable Globales

        int idCli = 0;
        int idSolicitud = 0;
        clsCNEvalConsumo cnEvalConsumo = new clsCNEvalConsumo();
        string cTituloMensaje = "Nueva evaluación";
        public int idEvalCre;
        public string cNombreCliente = "";
        public string cNroDocumento = "";
        public string cOperacion = "";
        public string cModalidaCre = "";
        private int idTipoEvalCre = 1;
        private string cEvaluacion = "";

        private DataTable dtValidarEvalProd;
        private bool lVinculaSolEvalExistente = false;

        private clsCreditoProp clsProp;
        private clsEvalCred clsEvalCre;

        public string cNombreFormulario = "";
        clsCNSeleccionarDocEvalAnterior objCNCargaArchivoDocEval = new clsCNSeleccionarDocEvalAnterior();
        int idEvalCred = 0;
        string cIdTipEvalCred = "";
        #endregion

        public frmNuevaEvConsumo()
        {
            InitializeComponent();
            activarForm(false);
            limpiar();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            this.idCli = this.conBusCli1.idCli;

            if (this.idCli != 0)
            {
                cargarSolicitudCli();
            }
        }


        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            if (idSolicitud == 0)
            {
                if (this.lVinculaSolEvalExistente)
                {
                    MessageBox.Show("No se puede vincular la evaluación si no hay una solicitud del cliente, seleccione una solicitud de la lista y haga click en el boton Vincular", cTituloMensaje
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DialogResult dRes = MessageBox.Show("¿Desea crear una evaluacion sin una solicitud de crédito vinculada?", cTituloMensaje
                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dRes == DialogResult.No)
                {
                    MessageBox.Show("Ud. a seleccionado no crear la evaluación para poder vincular una solicitud", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            cNombreCliente = conBusCli1.txtNombre.Text;
            cNroDocumento = conBusCli1.txtNroDoc.Text;

            if (dtgSolicitud.SelectedRows.Count > 0)
            {
                cOperacion = dtgSolicitud.SelectedRows[0].Cells["cOperacion"].Value.ToString();
                cModalidaCre = dtgSolicitud.SelectedRows[0].Cells["cModalidadCredito"].Value.ToString();
            }

            if (this.lVinculaSolEvalExistente)
            {
                vincularEvalSolicitud();
            }
            else
            {
                guardarNuevaEvaluacion();
            }

            #region ValidarPDS
            DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(idSolicitud);
            if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
            {
                MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }



        private void btn_Vincular1_Click(object sender, EventArgs e)
        {
            vincularSolicitudAEvaluacion();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            activarForm(false);
        }

        private void cboCatLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCatLab.SelectedIndex < 0)
                return;

            if (Convert.ToInt32(cboCatLab.SelectedValue) == 1)
            {
                rbtnIndependiente.Checked = true;

                rbtnDependiente.Enabled = true;
                rbtnIndependiente.Enabled = true;
            }
            else
            {
                rbtnDependiente.Checked = true;

                rbtnDependiente.Enabled = false;
                rbtnIndependiente.Enabled = false;
            }

        }

        private void frmNuevaEvConsumo_Shown(object sender, EventArgs e)
        {
            if (this.lVinculaSolEvalExistente)
            {
                conBusCli1.CargardatosCli(this.idCli);
                conCreditoTasa1.AsignarDatos(this.clsProp);
                cargarSolicitudCli();
                cboCatLab.SelectedValue = this.clsEvalCre.idCatLab;
                rbtnDependiente.Checked = (this.clsEvalCre.nTipIngreso == 1) ? true : false;
                rbtnIndependiente.Checked = (this.clsEvalCre.nTipIngreso == 2) ? true : false;
                nudAniosExperiencia.Value = this.clsEvalCre.nActPriAnios;

                cNombreCliente = conBusCli1.txtNombre.Text;
                cNroDocumento = conBusCli1.txtNroDoc.Text;

                if (dtgSolicitud.SelectedRows.Count > 0)
                {
                    cOperacion = dtgSolicitud.SelectedRows[0].Cells["cOperacion"].Value.ToString();
                    cModalidaCre = dtgSolicitud.SelectedRows[0].Cells["cModalidadCredito"].Value.ToString();
                }
            }
        }

        #endregion

        #region Métodos

        private void vincularSolicitudAEvaluacion()
        {
            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente", cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtgSolicitud.RowCount == 0)
            {
                MessageBox.Show("El cliente no tiene solicitudes", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtgSolicitud.SelectedCells.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado la solicitud a vincular con la evaluacion", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.lVinculaSolEvalExistente)
            {
                if (Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idProducto"].Value) != conCreditoTasa1.ObtenerIdProducto())
                {
                    MessageBox.Show("Los productos de la evaluación y la solicitud deben ser iguales", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idMoneda"].Value) != conCreditoTasa1.idMoneda)
                {
                    MessageBox.Show("Las monedas de la evaluación y la solicitud deben ser iguales", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                idSolicitud = Convert.ToInt32(dtgSolicitud.SelectedRows[0].Cells["idSolicitud"].Value);
            }
            else
            {
                vincularSolicitudCreEval(dtgSolicitud.SelectedRows[0]);
            }
            MessageBox.Show("Se ha vinculado la solicitud, proceda a guardar los cambios", cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.conCreditoTasa1.Enabled = false;
        }

        public void cargarTipoEvaluacion(int idTipEval, string cEval)
        {
            this.idTipoEvalCre = idTipEval;
            this.cEvaluacion = cEval;
            this.Text = cTituloMensaje + " " + cEval;
            
            if (this.idTipoEvalCre == Convert.ToInt32(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"])) 
            {
                grbCatLab.Visible = false;
            }
            else
            {
                grbCatLab.Visible = true;
            }
        }

        public void cargarEvalSinSolicitud(int idCliente, clsCreditoProp objCreSolProp, clsEvalCred objEvalCre)
        {
            this.Text = "Vinculando evaluación a una solicitud del cliente";

            this.idCli = idCliente;
            this.idEvalCre = objEvalCre.idEvalCred;
            this.clsProp = objCreSolProp;
            this.clsEvalCre = objEvalCre;

            // conBusCli1.CargardatosCli(idCliente);
            // conCreditoTasa1.AsignarDatos(objCreSolProp);
            // cargarSolicitudCli();
            this.lVinculaSolEvalExistente = true;

            /* --  bloqueando la busque da de un nuevo cliente -- */
            conBusCli1.Enabled = false;
            btnCancelar1.Enabled = false;
            grbEvalDet.Enabled = false;
            grbCatLab.Enabled = false;

        }

        private void activarForm(Boolean lBol)
        {
            this.conCreditoTasa1.Enabled = lBol;
            this.cboCatLab.Enabled = lBol;
            this.rbtnDependiente.Enabled = lBol;
            this.rbtnIndependiente.Enabled = lBol;
            this.nudAniosExperiencia.Enabled = lBol;
            this.btn_Vincular1.Enabled = lBol;
        }

        private bool validar()
        {
            clsMsjError clsError = conCreditoTasa1.Validar();

            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente", cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsError.HasErrors)
            {
                return false;
            }

            if (grbCatLab.Visible && cboCatLab.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la categoría laboral", cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (grbCatLab.Visible &&  !rbtnDependiente.Checked && !rbtnIndependiente.Checked)
            {
                MessageBox.Show("Seleccione el tipo de ingreso", cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (grbCatLab.Visible &&  nudAniosExperiencia.Value == 0)
            {
                MessageBox.Show("Los años de experiencia deben ser mayores", cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool lres = false;
            foreach (DataRow item in dtValidarEvalProd.Rows)
            {
                if (Convert.ToInt32(item["idProducto"]) == Convert.ToInt32(conCreditoTasa1.ObtenerIdProducto()))
                {
                    lres = true;
                }
            }

            if (!lres)
            {
                MessageBox.Show("El sub producto seleccionado no seleccionado no se puede vincular con la evaluación: " + this.cEvaluacion, cTituloMensaje
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgSolicitud.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgSolicitud.Columns["nMonto"].Visible = true;
            dtgSolicitud.Columns["cMoneda"].Visible = true;
            dtgSolicitud.Columns["cDescripTipoPeriodo"].Visible = true;
            dtgSolicitud.Columns["cOperacion"].Visible = true;
            dtgSolicitud.Columns["cModalidadCredito"].Visible = true;
            dtgSolicitud.Columns["cSubProducto"].Visible = true;
            dtgSolicitud.Columns["cEstado"].Visible = true;


            dtgSolicitud.Columns["nMonto"].HeaderText = "Monto Solicitado";
            dtgSolicitud.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolicitud.Columns["cDescripTipoPeriodo"].HeaderText = "T. Periodo";
            dtgSolicitud.Columns["cOperacion"].HeaderText = "Operación";
            dtgSolicitud.Columns["cModalidadCredito"].HeaderText = "Modalidad";
            dtgSolicitud.Columns["cSubProducto"].HeaderText = "Sub Producto";
            dtgSolicitud.Columns["cEstado"].HeaderText = "Estado";
        }

        private void limpiar()
        {
            conCreditoTasa1.LimpiarFormulario();
            conBusCli1.limpiarControles();
            if ((DataTable)dtgSolicitud.DataSource != null)
            {
                ((DataTable)dtgSolicitud.DataSource).Clear();
            }

            cboCatLab.SelectedIndex = -1;
            rbtnDependiente.Checked = false;
            rbtnIndependiente.Checked = false;
            idCli = 0;
            idSolicitud = 0;
            idEvalCre = 0;
            nudAniosExperiencia.Value = 0;
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
        }

        private void vincularSolicitudCreEval(DataGridViewRow drv)
        {
            this.conCreditoTasa1.LimpiarFormulario();
            idSolicitud = Convert.ToInt32(drv.Cells["idSolicitud"].Value);
            dtgSolicitud.Enabled = false;

            this.conCreditoTasa1.AsignarDatos(new clsCreditoProp()
            {
                idSolicitud = idSolicitud,
                idMoneda = Convert.ToInt32(drv.Cells["idMoneda"].Value),
                nMonto = Convert.ToDecimal(drv.Cells["nMonto"].Value),
                nCuotas = Convert.ToInt32(drv.Cells["nCuotas"].Value),
                idTipoPeriodo = Convert.ToInt32(drv.Cells["idTipoPeriodo"].Value),
                nPlazoCuota = Convert.ToInt32(drv.Cells["nPlazoCuota"].Value),
                nDiasGracia = Convert.ToInt32(drv.Cells["nDiasGracia"].Value),
                dFechaDesembolso = Convert.ToDateTime(drv.Cells["dFechaDesembolso"].Value),
                idProducto = Convert.ToInt32(drv.Cells["idProducto"].Value),
                idTasa = Convert.ToInt32(drv.Cells["idTasa"].Value),
                nTasaCompensatoria = Convert.ToDecimal(drv.Cells["nTasaCompensatoria"].Value),
                idCli = Convert.ToInt32(drv.Cells["idCli"].Value),
                idClasificacionInterna = Convert.ToInt32(drv.Cells["idClasificacionInterna"].Value),

            });
        }

        private void cargarSolicitudCli()
        {
            DataSet dsSolCli = cnEvalConsumo.CNListaSolicitudCli(idCli, clsVarGlobal.User.idUsuario, idTipoEvalCre.ToString());

            //TODO: SolTechnologies - 11.Cambio de formulario entre consumo normal y resumido
            if (dsSolCli.Tables[0].Rows.Count > 0)
            {
                DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(Convert.ToInt32(dsSolCli.Tables[0].Rows[0]["idSolicitud"]));
                if (existe.Rows.Count > 0)
                {
                    decimal monto = Convert.ToDecimal(dsSolCli.Tables[0].Rows[0]["nMonto"].ToString());

                    clsVarGen nMontoDecisionEngine = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecision"));
                    decimal montoParametrisable = Convert.ToDecimal(nMontoDecisionEngine.cValVar);

                    if (monto < montoParametrisable)
                    {
                        MessageBox.Show("¡Debe registrar una evaluacion resumida!",
                        "Modelo no bancarizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            DataTable dtSolCli = dsSolCli.Tables[0];
            dtValidarEvalProd = dsSolCli.Tables[1];
            if (dtSolCli.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontrado una solicitud de crédito del cliente", cTituloMensaje
                          , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dtgSolicitud.DataSource = dtSolCli;
            formatoGrid();
            activarForm(true);

            if (dtSolCli.Rows.Count > 0)
            {
                DialogResult dResult = MessageBox.Show("Desea vincular esta evaluación con la solicitud nro: " + Convert.ToString(dtSolCli.Rows[0]["idSolicitud"]), cTituloMensaje
                          , MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if(dResult == DialogResult.OK)
                    vincularSolicitudAEvaluacion();
            }
            
        }

        private void vincularEvalSolicitud()
        {
            clsCNEvaluacion cnEval = new clsCNEvaluacion();
            DataTable dtRes = cnEval.CNActualizarSolicitudAEval(this.idEvalCre, this.idSolicitud);
            if (dtRes.Rows.Count > 0)
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), cTituloMensaje
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Convert.ToInt32(dtRes.Rows[0]["nResultado"]) == 1)
                {
                    this.Close();
                }
            }
        }

        private void guardarNuevaEvaluacion()
        {
            clsCreditoProp oEvalCredTemp = this.conCreditoTasa1.ObtenerCreditoPropuesto();
            oEvalCredTemp.idCli = this.idCli;
            oEvalCredTemp.idSolicitud = this.idSolicitud;

            string cEval = oEvalCredTemp.GetXml();
            int idCatLab = Convert.ToInt32(cboCatLab.SelectedValue);
            int nTipoIngreso = (rbtnDependiente.Checked == true) ? 1 : 2;
            int nAniosExpe = Convert.ToInt32(nudAniosExperiencia.Value);

            DataTable dtResultado = cnEvalConsumo.CNNuevaEval(cEval, 
                clsVarGlobal.User.idUsuario, 
                clsVarGlobal.nIdAgencia, 
                clsVarGlobal.dFecSystem, 
                0, 
                nAniosExpe, 
                idCatLab, 
                nTipoIngreso, 
                this.idTipoEvalCre, 
                clsVarGlobal.User.idEstablecimiento
            );

            ValidarVisitaPresencialRemota(oEvalCredTemp.nMonto, Convert.ToInt32(dtResultado.Rows[0]["idEvalCre"]));

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                {
                    idEvalCre = Convert.ToInt32(dtResultado.Rows[0]["idEvalCre"]);
                    this.Close();
                }
            }
        }
        
        #endregion
        #region Evaluacion Presencial-remota
        private void ValidarVisitaPresencialRemota(decimal nMonto, int idEvalCred)
        {
            List<Tuple<int, string>> listTiposEvaluacionPresencialRemota = new List<Tuple<int, string>>();

            DataTable dtTipoEvaluacion = objCNCargaArchivoDocEval.CNListaTipoEvaluacion();

            foreach (DataRow row in dtTipoEvaluacion.Rows)
            {
                int idTipEvalConfig = Convert.ToInt32(row["idTipEvalConfig"]);
                DataTable dtRespuestaEvalPreRem = ArmarTablaParametrosEvalPreRemo(idTipEvalConfig, nMonto);
                string cCumpleReglas = new clsCNValidaReglaConfig().ValidarReglasConfig(dtRespuestaEvalPreRem, this.cNombreFormulario, idTipEvalConfig);

                if (cCumpleReglas == "OK")
                {
                    string cTipEvalConfig = row["cTipEvalConfig"].ToString();
                    Tuple<int, string> listTipoEvaluacionTuple = new Tuple<int, string>(idTipEvalConfig, cTipEvalConfig);

                    if (idTipEvalConfig == 3)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                    else if (idTipEvalConfig == 2)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                }
            }

            if (listTiposEvaluacionPresencialRemota.Count > 0)
            {
                RecuperarDocEvalAnterior(listTiposEvaluacionPresencialRemota, idEvalCred);
            }
            else
            {
                MessageBox.Show("No cumple con las reglas de validación para una solicitud anterior.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable ArmarTablaParametrosEvalPreRemo(int idTipEvalConfig, decimal nMonto)
        {
            DataTable dtTablaParametrosEval = new DataTable();
            dtTablaParametrosEval.Columns.Add("cNombreCampo");
            dtTablaParametrosEval.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametrosEval.NewRow();

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.idCli;
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
            drfila[1] = this.cIdTipEvalCred;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametrosEval.Rows.Add(drfila);

            return dtTablaParametrosEval;
        }

        private void RecuperarDocEvalAnterior(List<Tuple<int, string>> listTiposEvaluacion, int idEvalCred)
        {
            int idSolicitudAnterior = 0;
            int idSolicitud = this.idSolicitud;
            int idEvalCredAnterior = 0;
            int idTipEvalConfig = listTiposEvaluacion[0].Item1;
            int idTipEvalConfigRespuesta = 0;

            DataTable dtSolicitudEvalAnterior = objCNCargaArchivoDocEval.CNRecuperaSolicitudAnterior(this.idCli, Convert.ToDateTime(Evaluacion.FechaActualEval), cIdTipEvalCred, idTipEvalConfig);

            if (Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]) == 0)
            {
                MessageBox.Show("La validación de las reglas remota y presencial ha fallado.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtSolicitudEvalAnterior.Rows.Count > 0)
            {
                idSolicitudAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]);

                frmSeleccionarDocEvalAnterior frmSeleccionarDoc = new frmSeleccionarDocEvalAnterior(idSolicitudAnterior, idSolicitud, listTiposEvaluacion);
                frmSeleccionarDoc.ShowDialog();
                idTipEvalConfigRespuesta = frmSeleccionarDoc.idTipEvalConfig;
                frmSeleccionarDoc.Dispose();

                idEvalCredAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idEvalCred"]);
                ActualizaInformacionEvaluacion(idEvalCred, idEvalCredAnterior, idTipEvalConfigRespuesta, cIdTipEvalCred);
            }
        }

        public void RecuperarNombreFormulario(string cNombreFormulario, string cIdTipEvalCred)
        {
            this.cNombreFormulario = cNombreFormulario;
            this.cIdTipEvalCred = cIdTipEvalCred;
        }

        private void ActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            DataTable dt = objCNCargaArchivoDocEval.CNActualizaInformacionEvaluacion(idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
            
        }
}
