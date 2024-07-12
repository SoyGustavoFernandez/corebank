using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using GEN.Funciones;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{

    public partial class frmSolicitudCredGrupoSolidario : frmBase
    {

        clsCNGrupoSolidario objCNGrupoSolidario = new clsCNGrupoSolidario();
        clsCreditoProp objCreditoPropGrupo = new clsCreditoProp();
        private const string cTituloForm = "Registro Grupo Solidario";

        clsSolicitudCredGrupoSol objSolicitudCredGrupoSol = new clsSolicitudCredGrupoSol();
        List<clsSolCredGSIntegrante> lstSolCredGSIntegrante = new List<clsSolCredGSIntegrante>();
        List<clsCreditoGrupoSolInt> lstSolicitudIntegrante;
        clsCreditoGrupoSolInt objSolicitudIntegrante;

        DataSet dsSolicitudGrupoSolidario = null;

        clsGrupoSolidarioAmpliacion objGrupoSolidarioAmpliacion;
        List<clsGrupoSolAmpliacionDetalle> lstGrupoSolAmpliacionDetalle;

        int idOperacion = (int)OperacionCredito.Otorgamiento;
        int idGrupoSolidario = 0;
        int idSolicitudCredGrupoSol = 0;
        int idEstado = 0;
        bool lValidacion = false;
        string idSolicitudGS = "";

        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        public frmSolicitudCredGrupoSolidario()
        {
            InitializeComponent();

            this.inicializarDatos();

            this.Habilitar(false);

            this.cboAsesorNegociosGrupoSolidario.ListarPorAgencia(0);
            this.cboModDesemb.Enabled = false;
            this.cboAsesorNegociosGrupoSolidario.Enabled = false;


            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnEnviar.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnExcepciones.Enabled = false;
            btnVincularVisita1.lIndividual = false;
        }
        public void inicializarDatos()
        {
            this.objGrupoSolidarioAmpliacion = new clsGrupoSolidarioAmpliacion();
            this.lstGrupoSolAmpliacionDetalle = new List<clsGrupoSolAmpliacionDetalle>();
            this.lstSolicitudIntegrante = new List<clsCreditoGrupoSolInt>();
            this.objSolicitudIntegrante = new clsCreditoGrupoSolInt();

            this.bsSolicitudIntegrante.DataSource = this.lstSolicitudIntegrante;
        }
        private void LimpiarControles()
        {
            this.LimpiarFormulario();
        }

        private void FormatearDataGrid(bool lEstacional = false)
        {
            dtgIntegrantes.ReadOnly = false;
            dtgIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                dtgIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgIntegrantes.Columns["nMontoCancelacion"].Visible = true;
                dtgIntegrantes.Columns["nMontoAmpliado"].Visible = true;
            }
            else
            {                
                dtgIntegrantes.Columns["nMontoCancelacion"].Visible = false;
                dtgIntegrantes.Columns["nMontoAmpliado"].Visible = false;
            }
            dtgIntegrantes.Columns["lSolicitudActiva"].Visible = lEstacional;
            dtgIntegrantes.Columns["lSolicitudActiva"].ReadOnly = !lEstacional;
        }

        private void conBusGrupoSol_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                return;
            }


            bool lIndDatosBasic;
            string cIdCli= "";
            string cNombre= "";
            int nContador = 0;
            string cNombreMensaje = "";

            foreach (DataRow row in this.conBusGrupoSol.dtIntegrantes.Rows)
            {
                lIndDatosBasic = Convert.ToBoolean(row["lIndDatosBasic"]);
                cIdCli = Convert.ToString(row["idCli"]);
                cNombre = Convert.ToString(row["cNombre"]);
                
                if (lIndDatosBasic)
                {
                    cNombreMensaje = cNombreMensaje + "\n" + cIdCli + "-" + cNombre;
                    nContador++;
                }

            }

            if (nContador > 0)
            {
                MessageBox.Show("Por favor, debe registrar los datos completos del cliente o los clientes: \n" + cNombreMensaje, "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                btnCancelar.PerformClick();
                return;           
            }

            this.cboOperacionCre.SelectedIndexChanged -= this.cboOperacionCre_SelectedIndexChanged;
            this.lstSolicitudIntegrante.Clear();
            this.lstSolicitudIntegrante.AddRange(this.conBusGrupoSol.listaSolicitudIntegrante());
            this.InsertarDatos(this.conBusGrupoSol.dtGrupo);
            this.cboOperacionCre.SelectedIndexChanged += this.cboOperacionCre_SelectedIndexChanged;
        }

        private void frmSolicitudCredGrupoSolidario_Load(object sender, EventArgs e)
        {
            this.Text = cTituloForm;
            this.cboModalidadCredito.Enabled = false;
            //this.cboOperacionCre.Enabled = false;
            this.cboOperacionCre.ListarOperacionCredito("1,4");
            this.cboModDesemb.Enabled = false;

            this.conBusGrupoSol.txtIdGrupoSolidario.Enabled = true;
            this.conBusGrupoSol.txtNombreGrupo.Enabled = true;

            this.conCondiCreditoGrupoSol.cargarProductoSol(Convert.ToInt32(clsVarApl.dicVarGen["nProductoGrupoSolMicro"]));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        private void cancelar()
        {
            this.LimpiarFormulario();
            this.btnEditar.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnExcepciones.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.cboOperacionCre.Enabled = true;
            this.cboOperacionCre.SelectedValue = (int)OperacionCredito.Otorgamiento;
            this.cboModalidadCredito.Enabled = true;
            this.conCondiCreditoGrupoSol.bloquearNivelesProducto(true);
            this.lblClicloAmpliacion.Visible = false;
            this.cboCicloAmpliacion.Visible = false;
        }

        private void LimpiarFormulario()
        {
            this.conCondiCreditoGrupoSol.LimpiarControl();
            this.conCondiCreditoGrupoSol.cargarProductoSol(Convert.ToInt32(clsVarApl.dicVarGen["nProductoGrupoSolMicro"]));
            this.conBusGrupoSol.LimpiarControl();

            this.lstSolicitudIntegrante.Clear();
            this.bsSolicitudIntegrante.ResetBindings(false);
            this.dtgIntegrantes.Refresh();
            this.objSolicitudIntegrante = new clsCreditoGrupoSolInt();

            this.txtBase1.Text = null;
            this.idSolicitudCredGrupoSol = 0;
            this.idOperacion = 0;
            this.idGrupoSolidario = 0;
        }

        private void Habilitar(bool lEstado)
        {
            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                this.cboOperacionCre.Enabled = false;
                this.cboModalidadCredito.Enabled = false;
                this.conCondiCreditoGrupoSol.bloquearNivelesProducto(false);
                this.cboAsesorNegociosGrupoSolidario.Enabled = false;
            }
            else
            {
                this.cboModalidadCredito.Enabled = lEstado;                
                this.cboAsesorNegociosGrupoSolidario.Enabled = lEstado;
            }
            this.conCondiCreditoGrupoSol.Enabled = lEstado;
            this.dtgIntegrantes.Enabled = lEstado;
            btnEditCondiIntegrante.Enabled = lEstado;
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!this.RecolectarDatos()) return;

            if (Convert.ToInt32(this.cboModalidadCredito.SelectedValue) == (int)ModalidadCredito.Estacional)
            {
                this.lstSolicitudIntegrante.RemoveAll(x => !x.lSolicitudActiva);
                this.bsSolicitudIntegrante.ResetBindings(false);
                this.dtgIntegrantes.Refresh();
            }

            //if (!NotificarPorSMSPaqueteSeguro())
            //    return;

            this.lstSolicitudIntegrante.ForEach(x => { if (x.idFrmPaqueteSeguro == 0) x.idFrmPaqueteSeguro = 1; });

            DataTable dtResultado = (new clsCNGrupoSolidario()).RegistrarSolGrupoSolidario(this.dsSolicitudGrupoSolidario.GetXml(), this.lstSolicitudIntegrante, this.idOperacion);
            if (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
            {
                this.Habilitar(false);
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnImprimir.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnExcepciones.Enabled = true;
                this.btnEnviar.Enabled = true;

                this.idSolicitudCredGrupoSol = Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]);

                ActualizarSolicitudCredGrupoSol();
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString() + idSolicitudGS + " registrada correctamente.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            registrarInter();
        }
        private void registrarInter()
        {
            if (!this.RecolectarDatos()) return;
            DataTable dtResultado = (new clsCNGrupoSolidario()).RegistrarSolGrupoSolidario(this.dsSolicitudGrupoSolidario.GetXml(), this.lstSolicitudIntegrante, this.idOperacion);
            //if (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
            //{
            //    MessageBox.Show("Registro de Intervinientes, Registrado Correctamente ", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.validarReglas();
            if (!this.lValidacion)
            {
                return;
            }

            this.RecolectarDatos();

            DataTable dtResultado = (new clsCNGrupoSolidario()).EnviarSolCredGSaEvaluacion(this.idSolicitudCredGrupoSol, this.dsSolicitudGrupoSolidario.GetXml(), this.lstSolicitudIntegrante);

            if (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
            {
                this.Habilitar(false);
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnImprimir.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.btnEnviar.Enabled = false;
            }

            MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), cTituloForm);

            if (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
            {
                /*  Guardar Expedientes - Solicitud GS  */
                clsProcesoExp.guardarCopiaExpediente("GS - Solicitud de Credito", this.idSolicitudCredGrupoSol, this, "grupal");
            }
        }

        private void ActualizarSolicitudCredGrupoSol()
        {
            DataSet ds = objCNGrupoSolidario.ObtenerSolCredGrupoSolidario(idGrupoSolidario, this.idSolicitudCredGrupoSol);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se pudo obtener datos para actualizar el formulario", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.conCondiCreditoGrupoSol.LimpiarControl();

            this.lstSolicitudIntegrante.Clear();
            this.lstSolicitudIntegrante.AddRange((ds.Tables[1].Rows.Count > 0)?
                ds.Tables[1].ToList<clsCreditoGrupoSolInt>() as List<clsCreditoGrupoSolInt>:
                new List<clsCreditoGrupoSolInt>());

            this.InsertarDatos(ds.Tables[0]);
            this.ObtenerIdSolicitud(ds.Tables[0]);
        }

        private void ObtenerIdSolicitud(DataTable dtGrupo)
        {
            int idSolicitud = Convert.ToInt32(dtGrupo.Rows[0]["idSolicitudCredGrupoSol"]);
            idSolicitudGS = Convert.ToString(idSolicitud);
            this.btnVincularVisita1.idGrupoSolidario = this.idGrupoSolidario;
            this.btnVincularVisita1.idSolicitudGrupoSol = idSolicitud;
        }

        private void InsertarDatos(DataTable dtGrupo)
        {
            this.objCreditoPropGrupo = null;
            this.objCreditoPropGrupo = new clsCreditoProp();

            this.idGrupoSolidario = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]);
            this.idSolicitudCredGrupoSol = Convert.ToInt32(dtGrupo.Rows[0]["idSolicitudCredGrupoSol"]);
            this.idEstado = Convert.ToInt32(dtGrupo.Rows[0]["idEstado"]);

            this.objCreditoPropGrupo.idMoneda = Convert.ToInt32(dtGrupo.Rows[0]["idMoneda"]);
            this.objCreditoPropGrupo.nCuotas = Convert.ToInt32(dtGrupo.Rows[0]["nCuotas"]);
            this.objCreditoPropGrupo.idTipoPeriodo = Convert.ToInt32(dtGrupo.Rows[0]["idTipoPeriodo"]);
            this.objCreditoPropGrupo.nPlazoCuota = Convert.ToInt32(dtGrupo.Rows[0]["nPlazoCuota"]);
            this.objCreditoPropGrupo.nDiasGracia = Convert.ToInt32(dtGrupo.Rows[0]["nDiasGracia"]);
            this.objCreditoPropGrupo.nCuotasGracia = Convert.ToInt32(dtGrupo.Rows[0]["nCuotasGracia"]);
            this.objCreditoPropGrupo.dFechaDesembolso = Convert.ToDateTime(dtGrupo.Rows[0]["dFechaDesembolso"]);
            //this.objCreditoPropGrupo.dFechaDesembolso = clsVarGlobal.dFecSystem;
            this.objCreditoPropGrupo.idAsesor = Convert.ToInt32(dtGrupo.Rows[0]["idAsesor"]);
            this.objCreditoPropGrupo.idAgencia = clsVarGlobal.nIdAgencia;
            this.objCreditoPropGrupo.idProducto = Convert.ToInt32(dtGrupo.Rows[0]["idProducto"]);
            this.objCreditoPropGrupo.idSubProducto = Convert.ToInt32(dtGrupo.Rows[0]["idSubProducto"]);
            this.objCreditoPropGrupo.idOperacion = Convert.ToInt32(dtGrupo.Rows[0]["idOperacion"]);
            this.objCreditoPropGrupo.idModalidadCredito = Convert.ToInt32(dtGrupo.Rows[0]["idModalidadCredito"]);
            this.objCreditoPropGrupo.idModalidadDes = Convert.ToInt32(dtGrupo.Rows[0]["idModalidadDes"]);
            this.objCreditoPropGrupo.idTasa = Convert.ToInt32(dtGrupo.Rows[0]["idTasa"]);
            this.objCreditoPropGrupo.idGrupoSolidarioCiclo = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidarioCiclo"]);
            this.objCreditoPropGrupo.idGrupoSolidarioTipo = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidarioTipo"]);
            this.objCreditoPropGrupo.idGrupoSolidario = this.idGrupoSolidario;
            this.objCreditoPropGrupo.idSolicitudCredGrupoSol = this.idSolicitudCredGrupoSol;
            this.txtBase1.Text = Convert.ToString(idSolicitudCredGrupoSol);            

            this.btnVincularVisita1.idSolicitudGrupoSol = idSolicitudCredGrupoSol;
            this.btnVincularVisita1.idGrupoSolidario = idGrupoSolidario;

            this.idOperacion = this.objCreditoPropGrupo.idOperacion;

            this.bsSolicitudIntegrante.ResetBindings(false);
            this.dtgIntegrantes.Refresh();
            if (this.lstSolicitudIntegrante.Count> 0)
            {
                this.objCreditoPropGrupo.nMonto = this.lstSolicitudIntegrante.Sum(x => x.nMonto);
                this.objCreditoPropGrupo.nMontoMinimo = this.lstSolicitudIntegrante.Max(x => x.nMonto);
                this.objCreditoPropGrupo.nMontoMaximo = this.lstSolicitudIntegrante.Min(x => x.nMonto);

                this.txtMontoSuma.Text = this.objCreditoPropGrupo.nMonto.ToString();
            }
            else
            {
                this.objCreditoPropGrupo.nMonto = 0;
            }

            if (this.idSolicitudCredGrupoSol != 0)
            {
                if (idEstado.In(0, 1))
                {
                    this.btnEditar.Enabled = true;
                    this.btnEnviar.Enabled = true;
                    this.btnExcepciones.Enabled = true;
                }
                else
                {
                    this.btnEditar.Enabled = false;
                    this.btnEnviar.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    this.Text = this.Text + " - (Solo Lectura)";
                }

                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnImprimir.Enabled = true;

                this.Habilitar(false);

                this.cboOperacionCre.SelectedValue = this.objCreditoPropGrupo.idOperacion;
                this.cboAsesorNegociosGrupoSolidario.SelectedValue = this.objCreditoPropGrupo.idAsesor;
                this.cboModalidadCredito.SelectedValue = this.objCreditoPropGrupo.idModalidadCredito;
                this.cboModDesemb.SelectedValue = this.objCreditoPropGrupo.idModalidadDes;
            }
            else
            {
                this.btnGrabar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnImprimir.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.Habilitar(true);
            }

            this.conCondiCreditoGrupoSol.ChangeCondiCredito -= conCondiCreditoGrupoSol_ChangeCondiCredito;
            this.conCondiCreditoGrupoSol.AsignarDatos(objCreditoPropGrupo);
            this.conCondiCreditoGrupoSol.idTipoGrupoSolidario = this.objCreditoPropGrupo.idGrupoSolidarioTipo;
            this.conCondiCreditoGrupoSol.ChangeCondiCredito += conCondiCreditoGrupoSol_ChangeCondiCredito;

            this.cboAsesorNegociosGrupoSolidario.SelectedValue = clsVarGlobal.User.idUsuario;
            this.FormatearDataGrid();
        }

        private bool RecolectarDatos()
        {
            conCondiCreditoGrupoSol.idTipoGrupoSolidario = conBusGrupoSol.obtenerTipoGrupoSol();
            clsMsjError objError = conCondiCreditoGrupoSol.Validar();
            if (objError.HasErrors)
            {
                MessageBox.Show(objError.GetErrors(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            this.dsSolicitudGrupoSolidario = null;

            clsCreditoProp objCreditoProp = new clsCreditoProp();
            objCreditoProp = this.conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            if (objCreditoProp.nCuotas <= 0)
            {
                MessageBox.Show("El Nro. de cuotas debe de ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (objCreditoProp.idTipoPeriodo <= 0)
            {
                MessageBox.Show("Seleccione el Periodo del Crédito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (objCreditoProp.idProducto <= 0)
            {
                MessageBox.Show("Seleccione un producto para la solictud", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataTable dtRes = objCNGrupoSolidario.CNValidaProductoTipoGrupoSolidario(conBusGrupoSol.obtenerTipoGrupoSol(), objCreditoProp.idProducto);
            if (!Convert.ToBoolean(dtRes.Rows[0]["nRes"]))
            {
                MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            clsMsjError objErrorInt = new clsMsjError();
            bool lSolicitud = false;
            foreach (clsCreditoGrupoSolInt objSolicitud in this.lstSolicitudIntegrante)
            {
                lSolicitud = objSolicitud.lSolicitudActiva;

                if (lSolicitud)
                {
                    if (objSolicitud.nTea == decimal.Zero)
                    {
                        objErrorInt.AddError("A :" + objSolicitud.cNombre + " no se le asignado TEA");
                    }

                    if (objSolicitud.nTasaMoratoria == decimal.Zero)
                    {
                        objErrorInt.AddError("A : " + objSolicitud.cNombre + " no se le asignado TIM");
                    }
                }
            }

            if (objErrorInt.HasErrors)
            {
                MessageBox.Show(objErrorInt.GetErrors(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            

            foreach (clsCreditoGrupoSolInt objSolicitud in this.lstSolicitudIntegrante)
            {

                if (objSolicitud.lSolicitudActiva)
                {
                    if (objSolicitud.nMonto <= 100)
                    {
                        MessageBox.Show("Ingrese un valor mayor a S/.100 del cliente: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objSolicitud.idDetalleGasto <= 0)
                    {
                        MessageBox.Show("Seleccione un Tipo de Seguro de Desgravamen del Crédito para el cliente: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objSolicitud.idPaqueteSeguro == 0)
                    {
                        MessageBox.Show("Seleccione un plan de seguro del Crédito para el cliente: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objSolicitud.idDestino <= 0)
                    {
                        MessageBox.Show("Seleccione un Destino del Crédito para el cliente: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objSolicitud.idActividad <= 0)
                    {
                        MessageBox.Show("Seleccione una Actividad Económica para el cliente: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objSolicitud.idTasa <= 0)
                    {
                        MessageBox.Show("Debe seleccionar una tasa para el siguiente socio: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (this.idOperacion == (int)OperacionCredito.Ampliacion && objSolicitud.nMontoAmpliado <= decimal.Zero)
                    {
                        MessageBox.Show("Debe Modificar el monto de la solicitud para que el MONTO AMPLIADO no sea CERO para el siguiente socio: " + Environment.NewLine + objSolicitud.cNombre, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }           

            DataTable dtSolCredGrupoSol = new DataTable();
            dtSolCredGrupoSol.Columns.Add("idSolicitudCredGrupoSol", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idGrupoSolidario", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idProducto", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idOperacion", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idMoneda", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idUsuario", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nMontoSolicitado", typeof(decimal));
            dtSolCredGrupoSol.Columns.Add("nCuotas", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nPlazoCuota", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idAgencia", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nDiasGracia", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idTipoPeriodo", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idUsuRegistro", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idUsuModifica", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nCuotasGracia", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nTem", typeof(decimal));
            dtSolCredGrupoSol.Columns.Add("nTea", typeof(decimal));
            dtSolCredGrupoSol.Columns.Add("idTasa", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idModalidadCredito", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idModalidadDes", typeof(int));
            dtSolCredGrupoSol.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dtSolCredGrupoSol.Columns.Add("idGrupoSolidarioCiclo", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idEstado", typeof(int));

            dtSolCredGrupoSol.Columns.Add("idSolCredGrupoSolOrigen", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idSolCredGrupoSolAnterior", typeof(int));
            dtSolCredGrupoSol.Columns.Add("idGrupoSolidarioAmpliacion", typeof(int));
            dtSolCredGrupoSol.Columns.Add("nNroAmpliacion", typeof(int));
            
            
            DataRow drSolCredGrupoSol = dtSolCredGrupoSol.NewRow();
            drSolCredGrupoSol["idSolicitudCredGrupoSol"] = this.idSolicitudCredGrupoSol;
            drSolCredGrupoSol["idGrupoSolidario"] = this.idGrupoSolidario;
            drSolCredGrupoSol["idProducto"] = objCreditoProp.idProducto;
            drSolCredGrupoSol["idOperacion"] = Convert.ToInt32(this.cboOperacionCre.SelectedValue);
            drSolCredGrupoSol["idMoneda"] = objCreditoProp.idMoneda;
            drSolCredGrupoSol["idUsuario"] = Convert.ToInt32(this.cboAsesorNegociosGrupoSolidario.SelectedValue);
            drSolCredGrupoSol["nMontoSolicitado"] = this.lstSolicitudIntegrante.Sum(x=>x.nMonto);
            drSolCredGrupoSol["nCuotas"] = objCreditoProp.nCuotas;
            drSolCredGrupoSol["nPlazoCuota"] = objCreditoProp.nPlazoCuota;
            drSolCredGrupoSol["idAgencia"] = Convert.ToInt32(clsVarGlobal.nIdAgencia);
            drSolCredGrupoSol["nDiasGracia"] = objCreditoProp.nDiasGracia;
            drSolCredGrupoSol["idTipoPeriodo"] = objCreditoProp.idTipoPeriodo;
            drSolCredGrupoSol["idUsuRegistro"] = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
            drSolCredGrupoSol["idUsuModifica"] = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
            drSolCredGrupoSol["nCuotasGracia"] = objCreditoProp.nCuotasGracia;
            drSolCredGrupoSol["nTem"] = objCreditoProp.nTIM;
            drSolCredGrupoSol["nTea"] = objCreditoProp.nTea;
            drSolCredGrupoSol["idTasa"] = objCreditoProp.idTasa;
            drSolCredGrupoSol["idModalidadCredito"] = Convert.ToInt32(this.cboModalidadCredito.SelectedValue);
            drSolCredGrupoSol["idModalidadDes"] = Convert.ToInt32(this.cboModDesemb.SelectedValue);
            drSolCredGrupoSol["dFechaDesembolso"] = objCreditoProp.dFechaDesembolso;
            drSolCredGrupoSol["idGrupoSolidarioCiclo"] = this.objGrupoSolidarioAmpliacion.idGrupoSolidarioCiclo;
            drSolCredGrupoSol["idEstado"] = (int)Estado.REGISTRADO;

            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                drSolCredGrupoSol["idSolCredGrupoSolOrigen"] = this.objGrupoSolidarioAmpliacion.idSolCredGrupoSolOrigen;
                drSolCredGrupoSol["idSolCredGrupoSolAnterior"] = this.objGrupoSolidarioAmpliacion.idSolCredGrupoSolAnterior;
                drSolCredGrupoSol["idGrupoSolidarioAmpliacion"] = this.objGrupoSolidarioAmpliacion.idGrupoSolidarioAmpliacion;
                drSolCredGrupoSol["nNroAmpliacion"] = this.objGrupoSolidarioAmpliacion.nNroAmpliacion;
            }
            else
            {
                drSolCredGrupoSol["idSolCredGrupoSolOrigen"] = 0;
                drSolCredGrupoSol["idSolCredGrupoSolAnterior"] = 0;
                drSolCredGrupoSol["idGrupoSolidarioAmpliacion"] = 0;
                drSolCredGrupoSol["nNroAmpliacion"] = 0;
            }

            dtSolCredGrupoSol.Rows.Add(drSolCredGrupoSol);

            dsSolicitudGrupoSolidario = new DataSet("dsSolicitudGrupoSolidario");
            dsSolicitudGrupoSolidario.Tables.Add(dtSolCredGrupoSol);

            return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Habilitar(true);
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnImprimir.Enabled = false;
            this.btnExcepciones.Enabled = false;
            this.btnCancelar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
        }

        private void btnEditCondiIntegrante_Click(object sender, EventArgs e)
        {
            if (this.lstSolicitudIntegrante.Count == 0) return;
            
            conCondiCreditoGrupoSol.idTipoGrupoSolidario = conBusGrupoSol.obtenerTipoGrupoSol();
            clsMsjError objError = conCondiCreditoGrupoSol.Validar();
            
            if (objError.HasErrors)
            {
                MessageBox.Show(objError.GetErrors(), "Solicitud creditos grupos solidarios", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            //frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(nMonto, idDestino, cDestino, idActividad, idActividadInterna);
            frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(obtenerSolCreditoIndividual(), 1);
            objCondiCredInt.ShowDialog();

            if (!objCondiCredInt.lAcepta)
                return;

            this.objSolicitudIntegrante.nMonto = objCondiCredInt.nMonto;
            this.objSolicitudIntegrante.idDetalleGasto = objCondiCredInt.idDetalleGasto;
            this.objSolicitudIntegrante.idDestino = objCondiCredInt.idDestino;
            this.objSolicitudIntegrante.cDestino = objCondiCredInt.cDestino;
            this.objSolicitudIntegrante.idActividad = objCondiCredInt.idActividad;
            this.objSolicitudIntegrante.idActividadInterna = objCondiCredInt.idActividadInterna;
            this.objSolicitudIntegrante.cActividadInterna = objCondiCredInt.cActividadInterna;
            this.objSolicitudIntegrante.nTea = objCondiCredInt.objCreditoProp.nTea;
            this.objSolicitudIntegrante.nTasaMoratoria = objCondiCredInt.objCreditoProp.nTasaMoratoria;
            this.objSolicitudIntegrante.idTasa = objCondiCredInt.objCreditoProp.idTasa;
            this.objSolicitudIntegrante.nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
            this.objSolicitudIntegrante.nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;
            objSolicitudIntegrante.idPaqueteSeguro = objCondiCredInt.idPaqueteSeguro;

            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                this.objSolicitudIntegrante.nMontoAmpliado =
                    objCondiCredInt.nMonto - this.objSolicitudIntegrante.nMontoCancelacion;
            }
            
            this.objCreditoPropGrupo.nMonto = this.lstSolicitudIntegrante.Sum(x => x.nMonto);
            this.objCreditoPropGrupo.nMontoMinimo = this.lstSolicitudIntegrante.Min(x => x.nMonto);
            this.objCreditoPropGrupo.nMontoMaximo = this.lstSolicitudIntegrante.Max(x => x.nMonto);
            
            this.txtMontoSuma.Text = this.objCreditoPropGrupo.nMonto.ToString();

            this.bsSolicitudIntegrante.ResetBindings(false);
            if (Convert.ToInt32(this.cboModalidadCredito.SelectedValue) == (int)ModalidadCredito.Estacional)
            {
                this.colorearGrupoSolidarioIntegrante();
            }
            this.dtgIntegrantes.Refresh();            
        }

        private clsCreditoProp obtenerSolCreditoIndividual()
        {
            clsCreditoProp obj = conCondiCreditoGrupoSol.ObtenerCondicionesCreditoGrupoSol(0);

            obj.nMonto = this.objSolicitudIntegrante.nMonto;
            obj.idDetalleGasto = this.objSolicitudIntegrante.idDetalleGasto;
            obj.cDestino = this.objSolicitudIntegrante.cDestino;
            obj.idDestino = this.objSolicitudIntegrante.idDestino;
            obj.idActividad = this.objSolicitudIntegrante.idActividad;
            obj.idActividadInterna = this.objSolicitudIntegrante.idActividadInterna;
            obj.cNombreCli = this.objSolicitudIntegrante.cNombre;
            obj.idCli = this.objSolicitudIntegrante.idCli;
            obj.cNombreGrupoSol = conBusGrupoSol.txtNombreGrupo.Text;
            obj.lTieneTasa = this.objSolicitudIntegrante.lTieneTasa;
            obj.nTasaCompensatoria = this.objSolicitudIntegrante.nTea;
            obj.idTasa = this.objSolicitudIntegrante.idTasa;
            obj.nTasaMoratoria = this.objSolicitudIntegrante.nTasaMoratoria;
            obj.lConTasaNegociable = this.objSolicitudIntegrante.lConTasaNegociable;
            obj.idSolicitud = this.objSolicitudIntegrante.idSolicitud;
            obj.idModalidadCredito = Convert.ToInt32(this.cboModalidadCredito.SelectedValue);
            obj.idClasificacionInterna = this.objSolicitudIntegrante.idClasificacionInterna;
            obj.idPaqueteSeguro = objSolicitudIntegrante.idPaqueteSeguro;
            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                obj.nSaldoCapital = this.objSolicitudIntegrante.nSaldoCapital;
                obj.nMontoCancelacion = this.objSolicitudIntegrante.nMontoCancelacion;
                obj.nMontoAmpliar = this.objSolicitudIntegrante.nMontoAmpliado;
            }
            return obj;
        }

        private void obtenerSolicitudGrupo()
        {
            clsCreditoProp objCreditoProp = new clsCreditoProp();
            objCreditoProp = this.conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            objSolicitudCredGrupoSol.idSolicitudCredGrupoSol = this.idSolicitudCredGrupoSol;
            objSolicitudCredGrupoSol.idGrupoSolidario = this.idGrupoSolidario;
            objSolicitudCredGrupoSol.idProducto = objCreditoProp.idProducto;
            objSolicitudCredGrupoSol.idOperacion = Convert.ToInt32(this.cboOperacionCre.SelectedValue);
            objSolicitudCredGrupoSol.idMoneda = objCreditoProp.idMoneda;
            objSolicitudCredGrupoSol.idUsuario = Convert.ToInt32(this.cboAsesorNegociosGrupoSolidario.SelectedValue);
            objSolicitudCredGrupoSol.nCuotas = objCreditoProp.nCuotas;
            objSolicitudCredGrupoSol.nPlazoCuota = objCreditoProp.nPlazoCuota;
            objSolicitudCredGrupoSol.idAgencia = Convert.ToInt32(clsVarGlobal.nIdAgencia);
            objSolicitudCredGrupoSol.nDiasGracia = objCreditoProp.nDiasGracia;
            objSolicitudCredGrupoSol.idTipoPeriodo = objCreditoProp.idTipoPeriodo;
            objSolicitudCredGrupoSol.idUsuRegistro = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
            objSolicitudCredGrupoSol.idUsuModifica = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
            objSolicitudCredGrupoSol.nCuotasGracia = objCreditoProp.nCuotasGracia;
            objSolicitudCredGrupoSol.nTea = objCreditoProp.nTea;
            objSolicitudCredGrupoSol.idTasa = objCreditoProp.idTasa;
            objSolicitudCredGrupoSol.idModalidadCredito = Convert.ToInt32(this.cboModalidadCredito.SelectedValue);
            objSolicitudCredGrupoSol.idModalidadDes = Convert.ToInt32(this.cboModDesemb.SelectedValue);
            objSolicitudCredGrupoSol.cNombreGrupo = this.conBusGrupoSol.txtNombreGrupo.Text;
            objSolicitudCredGrupoSol.idGrupoSolidarioCiclo = objCreditoProp.idGrupoSolidarioCiclo;
            objSolicitudCredGrupoSol.idGrupoSolidarioTipo = objCreditoProp.idGrupoSolidarioTipo;
            objSolicitudCredGrupoSol.dFecDesemb = objCreditoProp.dFechaDesembolso;
            objSolicitudCredGrupoSol.dFechaPrimeraCuota = objCreditoProp.dFechaPrimeraCuota;
        }
        private void obtenerSolicitudes()
        {
            foreach (clsCreditoGrupoSolInt objSolicitud in this.lstSolicitudIntegrante)
            {
                lstSolCredGSIntegrante.Add(
                    new clsSolCredGSIntegrante()
                    {
                        idSolicitud = objSolicitud.idSolicitud,
                        idSolicitudCredGrupoSol = this.idSolicitudCredGrupoSol,
                        idOperacion = objSolicitud.idOperacion,
                        idCli = objSolicitud.idCli,
                        nMonto = objSolicitud.nMonto,
                        idDestino = objSolicitud.idDestino,
                        idDetalleGasto = objSolicitud.idDetalleGasto,
                        cNombreCompleto = objSolicitud.cNombre,
                    }
                );
            }
        }
        private void validarReglas()
        {
            obtenerSolicitudGrupo();
            obtenerSolicitudes();
            string cNombreFormulario = this.Name;
            frmReglasGrupo frmExcepcionesGrupo = new frmReglasGrupo(2, cNombreFormulario, objSolicitudCredGrupoSol, lstSolCredGSIntegrante);
            frmExcepcionesGrupo.ShowDialog();
            lstSolCredGSIntegrante.Clear();
            this.lValidacion = frmExcepcionesGrupo.lEstado;
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            validarReglas();
        }

        public void ObtenerSolCredGrupoSolidario()
        {
            DataSet ds = objCNGrupoSolidario.ObtenerSolCredGrupoSolidario(idGrupoSolidario, this.idSolicitudCredGrupoSol);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (btnEnviar.Enabled)
            {
                MessageBox.Show("Para imprimir la ficha debe de enviar la solicitud a evaluación", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reporte();
        }
        private void Reporte()
        {
            clsCNGrupoSolidario cnRep = new clsCNGrupoSolidario();
            int idGrupoSol = idGrupoSolidario;
            int idSolicitudGrupoSol = Convert.ToInt32(objCreditoPropGrupo.idSolicitudCredGrupoSol);


            DataTable dtData1 = cnRep.ReporteSolicitud1(idGrupoSol, idSolicitudGrupoSol);
            DataTable dtData2 = cnRep.ReporteSolicitud2(idGrupoSol, idSolicitudGrupoSol);
            DataTable dtData3 = cnRep.ReporteSolicitud3(idGrupoSol, idSolicitudGrupoSol);

            if (dtData1.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idGrupo", idGrupoSol.ToString(), false));

                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSoli1", dtData1));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData2));
                dtsList.Add(new ReportDataSource("dsSoli3", dtData3));


                string reportPath = "rptSolCrediSolidario.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta solicitud ", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void conCondiCreditoGrupoSol_ChangeCondiCredito(object sender, EventArgs e)
        {
            actualizarCondCredIntegrantes();
        }

        private void actualizarCondCredIntegrantes(bool lCambioProducto = false)
        {
            if (this.lstSolicitudIntegrante.Count == 0)
                return;

            clsMsjError objError = conCondiCreditoGrupoSol.Validar();

            if (objError.HasErrors)
            {
                return;
            }

            foreach (clsCreditoGrupoSolInt objSolicitud in this.lstSolicitudIntegrante)
            {
                if (objSolicitud.nMonto == decimal.Zero)
                { 

                    frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(obtenerSolCreditoIndividual(), 1);
                    objCondiCredInt.CalcularCuotaAproxIntegrante(false);
                    objSolicitud.nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
                    objSolicitud.nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;
                    objSolicitud.idPaqueteSeguro = objCondiCredInt.idPaqueteSeguro;

                    if (lCambioProducto)
                    {
                        objSolicitud.idTasa = 0;
                        objSolicitud.nTea = decimal.Zero;
                        objSolicitud.nTasaMoratoria = decimal.Zero;
                    }
                }
            }
            this.bsSolicitudIntegrante.ResetBindings(false);
            this.colorearGrupoSolidarioIntegrante();
            dtgIntegrantes.Refresh();
        }

        private void conCondiCreditoGrupoSol_ChangeProducto(object sender, EventArgs e)
        {
            actualizarCondCredIntegrantes(true);
        }

        private void cboModalidadCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSolicitudIntegrante.Count == 0)
                return;

            if(Convert.ToInt32(cboModalidadCredito.SelectedValue) == 3) //ESTACIONAL
            {
                this.dtgIntegrantes.CurrentCellDirtyStateChanged -= dtgIntegrantes_CurrentCellDirtyStateChanged;
                this.FormatearDataGrid(true);
                this.dtgIntegrantes.CurrentCellDirtyStateChanged += dtgIntegrantes_CurrentCellDirtyStateChanged;
            }
            else
            {
                this.dtgIntegrantes.CurrentCellDirtyStateChanged -= dtgIntegrantes_CurrentCellDirtyStateChanged;
                this.FormatearDataGrid();                
            }
        }

        private void dtgIntegrantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(this.objSolicitudIntegrante != null && this.objSolicitudIntegrante.idCli > 0))
                return;

            if (this.dtgIntegrantes.Columns[e.ColumnIndex].DataPropertyName.Equals("lSolicitudActiva"))
            {
                cargaEventoEstacional(this.dtgIntegrantes.Rows[e.RowIndex], this.lstSolicitudIntegrante[e.RowIndex].lSolicitudActiva);
            }
        }

        private void dtgIntegrantes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgIntegrantes.IsCurrentCellDirty)
            {
                dtgIntegrantes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgIntegrantes_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgIntegrantes.SelectedRows.Count > 0)
            {
                int nFila = this.dtgIntegrantes.SelectedRows[0].Index;
                this.objSolicitudIntegrante = this.lstSolicitudIntegrante[nFila];
                if (this.objSolicitudIntegrante.idOperacion != (int)OperacionCredito.Ampliacion)
                {
                    this.btnEditar.Enabled = true;
                    cargaEventoEstacional(this.dtgIntegrantes.SelectedRows[0], this.objSolicitudIntegrante.lSolicitudActiva);
                }
            }
            else
            {
                this.objSolicitudIntegrante = new clsCreditoGrupoSolInt();
            }
        }

        private void cargaEventoEstacional(DataGridViewRow dtgvRow,  bool lCheck)
        {
            if (!lCheck)
            {
                dtgvRow.DefaultCellStyle.BackColor = Color.DarkGray;
                btnEditCondiIntegrante.Enabled = false;
            }
            else
            {
                dtgvRow.DefaultCellStyle.BackColor = Color.White;
                btnEditCondiIntegrante.Enabled = true;
            }
        }

        public void colorearGrupoSolidarioIntegrante()
        {
            foreach (DataGridViewRow dtgRow in this.dtgIntegrantes.Rows)
            {
                clsCreditoGrupoSolInt objCreditoGrupoSolInt = (clsCreditoGrupoSolInt)dtgRow.DataBoundItem;
                if (objCreditoGrupoSolInt.lSolicitudActiva)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            if (txtBase1.Text != "")
            {
                frmExpedienteGrupoSolidario frmExpediente = new frmExpedienteGrupoSolidario();
                frmExpediente.idSolicitud = Convert.ToInt32(txtBase1.Text);
                frmExpediente.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha encontrado una Solicitud de Crédito", "Carga de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private DataTable obtenerSolCredGrupoSolAmpliable(int idSolicitudCredGrupoSol)
        {
            DataTable dtSolCredAmpliable = this.objCNGrupoSolidario.obtenerSolCredGrupoSolAmpliable(idSolicitudCredGrupoSol);

            this.objGrupoSolidarioAmpliacion.idGrupoSolidarioAmpliacion = Convert.ToInt32(dtSolCredAmpliable.Rows[0]["idGrupoSolidarioAmpliacion"]);
            this.objGrupoSolidarioAmpliacion.idSolCredGrupoSolOrigen = Convert.ToInt32(dtSolCredAmpliable.Rows[0]["idSolCredGrupoSolOrigen"]);
            this.objGrupoSolidarioAmpliacion.idSolCredGrupoSolAnterior = Convert.ToInt32(dtSolCredAmpliable.Rows[0]["idSolCredGrupoSolAnterior"]);
            this.objGrupoSolidarioAmpliacion.nNroAmpliacion = Convert.ToInt32(dtSolCredAmpliable.Rows[0]["nNroAmpliacion"]);
            this.objGrupoSolidarioAmpliacion.idGrupoSolidarioCiclo = Convert.ToInt32(dtSolCredAmpliable.Rows[0]["idGrupoSolidarioCiclo"]);

            this.cboCicloAmpliacion.SelectedValue = this.objGrupoSolidarioAmpliacion.idGrupoSolidarioCiclo;

            return dtSolCredAmpliable;
        }

        private void cboOperacionCre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperacionCre.SelectedIndex == -1) return;

            this.idOperacion = this.cboOperacionCre.nValorSeleccionado;

            if (this.cboOperacionCre.nValorSeleccionado == (int)OperacionCredito.Ampliacion && this.idGrupoSolidario > 0)
            {
                frmGrupoSolidarioAmpliacion objFrmGrupoSolAmpliacion = new frmGrupoSolidarioAmpliacion(this.idGrupoSolidario);
                objFrmGrupoSolAmpliacion.ShowDialog();

                if (objFrmGrupoSolAmpliacion.lAceptado)
                {
                    this.idSolicitudCredGrupoSol = 0;
                    this.idSolicitudGS = "0";
                    this.idEstado = 0;

                    this.lstSolicitudIntegrante.Clear();
                    this.lstSolicitudIntegrante.AddRange(objFrmGrupoSolAmpliacion.lstCreditoGrupoInt);
                    this.InsertarDatos(
                        this.obtenerSolCredGrupoSolAmpliable(objFrmGrupoSolAmpliacion.lstCreditoGrupoInt[0].idSolicitudCredGrupoSol));
                    int i = 0;
                    this.lstSolicitudIntegrante.ForEach(x =>
                    {
                        x.nNro = ++i;
                        x.idSolicitudCredGrupoSol = 0;
                        x.idEstado = (int)Estado.REGISTRADO;
                    });

                    this.cboOperacionCre.Enabled = false;
                    this.cboModalidadCredito.Enabled = false;
                    this.cboModalidadCredito.SelectedValue = ModalidadCredito.Principal;
                    this.conCondiCreditoGrupoSol.bloquearNivelesProducto(false);
                    this.cboAsesorNegociosGrupoSolidario.Enabled = false;
                    this.lblClicloAmpliacion.Visible = true;
                    this.cboCicloAmpliacion.Visible = true;
                }
                else
                {
                    this.cancelar();
                }
            }
            else
            {
                if(this.cboOperacionCre.lDatosCargados)
                    this.cboOperacionCre.SelectedValue = (int)OperacionCredito.Otorgamiento;
            }
        }
        private void dtgIntegrantes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.dtgIntegrantes.Columns[e.ColumnIndex].DataPropertyName.Equals("nMontoAmpliado"))
            {
                double nValor;
                if (!double.TryParse(e.FormattedValue.ToString(), out nValor))
                {
                    MessageBox.Show("¡El valor del MONTO ingresado no debe estar VACIO ni contener LETRAS ni ESPACIOS!", "MONTO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }

                if (nValor < 0.00)
                {
                    MessageBox.Show("¡El Monto a Ampliar no puede ser Menor que Cero!", "MONTO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }
        private bool NotificarPorSMSPaqueteSeguro()
        {
            if (lstSolicitudIntegrante.All(x => x.idPaqueteSeguro == -1))
                return true;

            var listaPaquetesSeleccionados = lstSolicitudIntegrante.Where(x => x.idPaqueteSeguro != -1).ToList();

            clsCNPaqueteSeguro cnPaqueteSeguro = new clsCNPaqueteSeguro();
            clsCNCliente cnCliente = new clsCNCliente();
            clsServicioSMS cnServicioSMS = new clsServicioSMS();
            var listaPaquetesSeguro = cnPaqueteSeguro.CNListarTodosLosPaqueteDeSeguro();
            var clsListaPaquetesSeguro = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(listaPaquetesSeguro) as List<clsMantenimientoPaqueteSeguro>;;
            var listaTelefonos = new List<clsRegistroTelefono>();

            foreach (var item in listaPaquetesSeleccionados)
            {
                var dtTelefonos = (DataTableToList.ConvertTo<clsRegistroTelefono>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(item.idCli)) as List<clsRegistroTelefono>).FirstOrDefault();
                if (dtTelefonos == null || string.IsNullOrEmpty(dtTelefonos.cNumeroTelefonico))
                {
                    MessageBox.Show("El cliente " + item.cNombre + " no tiene registrado su número de teléfono. No se puede enviar el mensaje de texto. Actualice y vuelva a intentar", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                listaTelefonos.Add(dtTelefonos);
            }

            foreach (var item in listaPaquetesSeleccionados)
            {
                clsMantenimientoPaqueteSeguro objpaquete = clsListaPaquetesSeguro.Where(x => x.idPaqueteSeguro == item.idPaqueteSeguro).FirstOrDefault();
                string cTelefono = listaTelefonos.Where(x => x.idCli == item.idCli).FirstOrDefault().cNumeroTelefonico;
                clsSmsRequest requestSMS = new clsSmsRequest
                {
                    phone = cTelefono,
                    content = "Caja Los Andes informa que se ha adquirido el plan de seguros " + objpaquete.cNombreCompleto + " en etapa de solicitud, el cual podrá consultar en el siguiente enlace: " + objpaquete.cLink
                };
                clsSmsResponse responseSMS = cnServicioSMS.EnviarSMS(requestSMS);
                cnServicioSMS.GuardarTramaSMS(requestSMS, responseSMS, item.idCli);
            }

            MessageBox.Show("Se ha enviado los SMS a los clientes con algún plan de seguro seleccionado", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
