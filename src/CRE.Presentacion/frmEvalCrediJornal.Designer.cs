namespace CRE.Presentacion
{
    partial class frmEvalCrediJornal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalCrediJornal));
            this.grbDatosCliente = new GEN.ControlesBase.grbBase(this.components);
            this.lblNombre = new GEN.ControlesBase.lblBase();
            this.lblDocumentoID = new GEN.ControlesBase.lblBase();
            this.txtDocumentoID = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbDatosEvaluacion = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtModCredito = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.txtIDEvalCred = new GEN.ControlesBase.txtBase(this.components);
            this.txtIDSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.tabEval = new System.Windows.Forms.TabControl();
            this.tbpEvCualitativa = new System.Windows.Forms.TabPage();
            this.conEvalCualitReferencias = new CRE.ControlBase.ConEvalCualitReferencias();
            this.tbpEstFinancieros = new System.Windows.Forms.TabPage();
            this.conEstadosFinancieros = new CRE.ControlBase.ConEstadosFinancieros();
            this.tbpCondCredito = new System.Windows.Forms.TabPage();
            this.conCondiCredito = new CRE.ControlBase.ConCondiCredito();
            this.conPropuestaCrediJornal = new GEN.ControlesBase.ConPropuestaCrediJornal();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.btnVincularVisita = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnExcepciones = new GEN.BotonesBase.Boton();
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.btnGestObs = new GEN.BotonesBase.btnBlanco();
            this.btnTasaN = new GEN.BotonesBase.Boton();
            this.grbDatosCliente.SuspendLayout();
            this.grbDatosEvaluacion.SuspendLayout();
            this.tabEval.SuspendLayout();
            this.tbpEvCualitativa.SuspendLayout();
            this.tbpEstFinancieros.SuspendLayout();
            this.tbpCondCredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosCliente
            // 
            this.grbDatosCliente.Controls.Add(this.lblNombre);
            this.grbDatosCliente.Controls.Add(this.lblDocumentoID);
            this.grbDatosCliente.Controls.Add(this.txtDocumentoID);
            this.grbDatosCliente.Controls.Add(this.txtNombre);
            this.grbDatosCliente.Location = new System.Drawing.Point(6, 3);
            this.grbDatosCliente.Name = "grbDatosCliente";
            this.grbDatosCliente.Size = new System.Drawing.Size(497, 61);
            this.grbDatosCliente.TabIndex = 2;
            this.grbDatosCliente.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(6, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(145, 13);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre o Razón Social:";
            // 
            // lblDocumentoID
            // 
            this.lblDocumentoID.AutoSize = true;
            this.lblDocumentoID.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDocumentoID.ForeColor = System.Drawing.Color.Navy;
            this.lblDocumentoID.Location = new System.Drawing.Point(28, 14);
            this.lblDocumentoID.Name = "lblDocumentoID";
            this.lblDocumentoID.Size = new System.Drawing.Size(123, 13);
            this.lblDocumentoID.TabIndex = 11;
            this.lblDocumentoID.Text = "Nro. de Documento:";
            // 
            // txtDocumentoID
            // 
            this.txtDocumentoID.Enabled = false;
            this.txtDocumentoID.Location = new System.Drawing.Point(151, 10);
            this.txtDocumentoID.Name = "txtDocumentoID";
            this.txtDocumentoID.Size = new System.Drawing.Size(100, 20);
            this.txtDocumentoID.TabIndex = 10;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(151, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(340, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // grbDatosEvaluacion
            // 
            this.grbDatosEvaluacion.Controls.Add(this.lblBase7);
            this.grbDatosEvaluacion.Controls.Add(this.lblBase6);
            this.grbDatosEvaluacion.Controls.Add(this.lblBase5);
            this.grbDatosEvaluacion.Controls.Add(this.lblBase4);
            this.grbDatosEvaluacion.Controls.Add(this.lblBase3);
            this.grbDatosEvaluacion.Controls.Add(this.txtModCredito);
            this.grbDatosEvaluacion.Controls.Add(this.txtTipoCambio);
            this.grbDatosEvaluacion.Controls.Add(this.txtIDEvalCred);
            this.grbDatosEvaluacion.Controls.Add(this.txtIDSolicitud);
            this.grbDatosEvaluacion.Controls.Add(this.txtOperacion);
            this.grbDatosEvaluacion.Location = new System.Drawing.Point(509, 3);
            this.grbDatosEvaluacion.Name = "grbDatosEvaluacion";
            this.grbDatosEvaluacion.Size = new System.Drawing.Size(532, 61);
            this.grbDatosEvaluacion.TabIndex = 3;
            this.grbDatosEvaluacion.TabStop = false;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 14);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(88, 13);
            this.lblBase7.TabIndex = 16;
            this.lblBase7.Text = "Nro. Solicitud:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(392, 14);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(69, 13);
            this.lblBase6.TabIndex = 15;
            this.lblBase6.Text = "T. Cambio:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(-1, 37);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(101, 13);
            this.lblBase5.TabIndex = 14;
            this.lblBase5.Text = "Nro. Evaluación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(199, 37);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Modalidad:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(198, 14);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(70, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Operación:";
            // 
            // txtModCredito
            // 
            this.txtModCredito.Enabled = false;
            this.txtModCredito.Location = new System.Drawing.Point(268, 33);
            this.txtModCredito.Name = "txtModCredito";
            this.txtModCredito.Size = new System.Drawing.Size(115, 20);
            this.txtModCredito.TabIndex = 9;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Location = new System.Drawing.Point(461, 10);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(60, 20);
            this.txtTipoCambio.TabIndex = 5;
            // 
            // txtIDEvalCred
            // 
            this.txtIDEvalCred.Enabled = false;
            this.txtIDEvalCred.Location = new System.Drawing.Point(100, 33);
            this.txtIDEvalCred.Name = "txtIDEvalCred";
            this.txtIDEvalCred.Size = new System.Drawing.Size(90, 20);
            this.txtIDEvalCred.TabIndex = 6;
            // 
            // txtIDSolicitud
            // 
            this.txtIDSolicitud.Enabled = false;
            this.txtIDSolicitud.Location = new System.Drawing.Point(100, 10);
            this.txtIDSolicitud.Name = "txtIDSolicitud";
            this.txtIDSolicitud.Size = new System.Drawing.Size(90, 20);
            this.txtIDSolicitud.TabIndex = 7;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(268, 10);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(115, 20);
            this.txtOperacion.TabIndex = 8;
            // 
            // tabEval
            // 
            this.tabEval.Controls.Add(this.tbpEvCualitativa);
            this.tabEval.Controls.Add(this.tbpEstFinancieros);
            this.tabEval.Controls.Add(this.tbpCondCredito);
            this.tabEval.Location = new System.Drawing.Point(6, 71);
            this.tabEval.Name = "tabEval";
            this.tabEval.SelectedIndex = 0;
            this.tabEval.Size = new System.Drawing.Size(1035, 532);
            this.tabEval.TabIndex = 4;
            // 
            // tbpEvCualitativa
            // 
            this.tbpEvCualitativa.Controls.Add(this.conEvalCualitReferencias);
            this.tbpEvCualitativa.Location = new System.Drawing.Point(4, 22);
            this.tbpEvCualitativa.Name = "tbpEvCualitativa";
            this.tbpEvCualitativa.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEvCualitativa.Size = new System.Drawing.Size(1027, 506);
            this.tbpEvCualitativa.TabIndex = 0;
            this.tbpEvCualitativa.Text = "Eval. Cualitativa - Referencias";
            this.tbpEvCualitativa.UseVisualStyleBackColor = true;
            // 
            // conEvalCualitReferencias
            // 
            this.conEvalCualitReferencias.Location = new System.Drawing.Point(7, 0);
            this.conEvalCualitReferencias.Name = "conEvalCualitReferencias";
            this.conEvalCualitReferencias.Size = new System.Drawing.Size(1013, 506);
            this.conEvalCualitReferencias.TabIndex = 1;
            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            // 
            // tbpEstFinancieros
            // 
            this.tbpEstFinancieros.Controls.Add(this.conEstadosFinancieros);
            this.tbpEstFinancieros.Location = new System.Drawing.Point(4, 22);
            this.tbpEstFinancieros.Name = "tbpEstFinancieros";
            this.tbpEstFinancieros.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEstFinancieros.Size = new System.Drawing.Size(1027, 506);
            this.tbpEstFinancieros.TabIndex = 1;
            this.tbpEstFinancieros.Text = "Estados Financieros";
            this.tbpEstFinancieros.UseVisualStyleBackColor = true;
            // 
            // conEstadosFinancieros
            // 
            this.conEstadosFinancieros.BalanceGeneralEnabled = true;
            this.conEstadosFinancieros.ButtonBalanceGeneral = false;
            this.conEstadosFinancieros.ButtonDeudas = true;
            this.conEstadosFinancieros.ButtonEstadosResultados = true;
            this.conEstadosFinancieros.lHabilitarBalanceGeneral = true;
            this.conEstadosFinancieros.lHabilitarBotones = true;
            this.conEstadosFinancieros.lHabilitarEtadosResultados = true;
            this.conEstadosFinancieros.ListBalanceGeneral = null;
            this.conEstadosFinancieros.ListEstadoResultados = null;
            this.conEstadosFinancieros.lMostrarBalanceGeneral = true;
            this.conEstadosFinancieros.lMostrarBotones = true;
            this.conEstadosFinancieros.lMostrarEtadosResultados = true;
            this.conEstadosFinancieros.Location = new System.Drawing.Point(1, 1);
            this.conEstadosFinancieros.Name = "conEstadosFinancieros";
            this.conEstadosFinancieros.Size = new System.Drawing.Size(1030, 510);
            this.conEstadosFinancieros.TabIndex = 0;
            this.conEstadosFinancieros.UltEvaluacionChecked = false;
            this.conEstadosFinancieros.UltEvaluacionEnabled = true;
            this.conEstadosFinancieros.DeudasClick += new System.EventHandler(this.conEstadosFinancieros_DeudasClick);
            this.conEstadosFinancieros.EERRClick += new System.EventHandler(this.conEstadosFinancieros_EERRClick);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            // 
            // tbpCondCredito
            // 
            this.tbpCondCredito.Controls.Add(this.conCondiCredito);
            this.tbpCondCredito.Controls.Add(this.conPropuestaCrediJornal);
            this.tbpCondCredito.Location = new System.Drawing.Point(4, 22);
            this.tbpCondCredito.Name = "tbpCondCredito";
            this.tbpCondCredito.Size = new System.Drawing.Size(1027, 506);
            this.tbpCondCredito.TabIndex = 2;
            this.tbpCondCredito.Text = "Condiciones y Propuesta del Crédito";
            this.tbpCondCredito.UseVisualStyleBackColor = true;
            // 
            // conCondiCredito
            // 
            this.conCondiCredito.lHabilitarActividad = true;
            this.conCondiCredito.lHabilitarCondicionesCredito = true;
            this.conCondiCredito.lHabilitarDestinoCredito = false;
            this.conCondiCredito.lHabilitarRCC = true;
            this.conCondiCredito.lMostrarBtnPropDesembolsos = false;
            this.conCondiCredito.lMostrarCondicionesCredito = true;
            this.conCondiCredito.lMostrarDestinoCredito = true;
            this.conCondiCredito.lMostrarRCC = false;
            this.conCondiCredito.Location = new System.Drawing.Point(0, 0);
            this.conCondiCredito.Name = "conCondiCredito";
            this.conCondiCredito.Size = new System.Drawing.Size(341, 463);
            this.conCondiCredito.TabIndex = 0;
            this.conCondiCredito.ActividadInternaSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged += new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged += new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            // 
            // conPropuestaCrediJornal
            // 
            this.conPropuestaCrediJornal.Location = new System.Drawing.Point(347, 3);
            this.conPropuestaCrediJornal.Name = "conPropuestaCrediJornal";
            this.conPropuestaCrediJornal.Size = new System.Drawing.Size(405, 486);
            this.conPropuestaCrediJornal.TabIndex = 0;
            this.conPropuestaCrediJornal.TxtDatosClienteEnabled = true;
            this.conPropuestaCrediJornal.TxtDatosCreditoEnabled = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(900, 605);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(840, 605);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(780, 605);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(720, 605);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 8;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Location = new System.Drawing.Point(660, 605);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 9;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnVincularVisita
            // 
            this.btnVincularVisita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincularVisita.BackgroundImage")));
            this.btnVincularVisita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularVisita.idCli = 0;
            this.btnVincularVisita.idGrupoSolidario = 0;
            this.btnVincularVisita.idSolicitud = 0;
            this.btnVincularVisita.idSolicitudGrupoSol = 0;
            this.btnVincularVisita.lIndividual = true;
            this.btnVincularVisita.lLectura = false;
            this.btnVincularVisita.Location = new System.Drawing.Point(468, 605);
            this.btnVincularVisita.Name = "btnVincularVisita";
            this.btnVincularVisita.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita.TabIndex = 10;
            this.btnVincularVisita.Text = "Vincular Visita";
            this.btnVincularVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(71, 605);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(11, 605);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(342, 605);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 14;
            this.btnCargaArhivos.Text = "Cargar Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(981, 605);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(660, 605);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 16;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Enabled = false;
            this.btnExcepciones.Image = global::CRE.Presentacion.Properties.Resources.success;
            this.btnExcepciones.Location = new System.Drawing.Point(528, 605);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 31;
            this.btnExcepciones.Text = "Excepc.";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Enabled = false;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(282, 605);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 61;
            this.btnHabilitarSeguro.Text = "Habilitar Seguros";
            this.btnHabilitarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitarSeguro.UseVisualStyleBackColor = true;
            this.btnHabilitarSeguro.Click += new System.EventHandler(this.btnHabilitarSeguro_Click);
            // 
            // btnGestObs
            // 
            this.btnGestObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestObs.BackgroundImage")));
            this.btnGestObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestObs.Enabled = false;
            this.btnGestObs.Location = new System.Drawing.Point(594, 605);
            this.btnGestObs.Name = "btnGestObs";
            this.btnGestObs.Size = new System.Drawing.Size(60, 50);
            this.btnGestObs.TabIndex = 62;
            this.btnGestObs.Text = "Observ.";
            this.btnGestObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestObs.UseVisualStyleBackColor = true;
            this.btnGestObs.Click += new System.EventHandler(this.btnGestObs_Click);
            // 
            // btnTasaN
            // 
            this.btnTasaN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTasaN.Location = new System.Drawing.Point(404, 605);
            this.btnTasaN.Name = "btnTasaN";
            this.btnTasaN.Size = new System.Drawing.Size(60, 50);
            this.btnTasaN.TabIndex = 82;
            this.btnTasaN.Text = "Solicitud Tasa ";
            this.btnTasaN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTasaN.UseVisualStyleBackColor = true;
            this.btnTasaN.Click += new System.EventHandler(this.boton1_Click);
            // 
            // frmEvalCrediJornal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 680);
            this.Controls.Add(this.btnTasaN);
            this.Controls.Add(this.btnGestObs);
            this.Controls.Add(this.btnHabilitarSeguro);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnVincularVisita);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tabEval);
            this.Controls.Add(this.grbDatosEvaluacion);
            this.Controls.Add(this.grbDatosCliente);
            this.Controls.Add(this.btnVincular);
            this.Name = "frmEvalCrediJornal";
            this.Text = "Evaluación Tu Credi Chamba";
            this.Load += new System.EventHandler(this.frmEvalCrediJornal_Load);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.grbDatosCliente, 0);
            this.Controls.SetChildIndex(this.grbDatosEvaluacion, 0);
            this.Controls.SetChildIndex(this.tabEval, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.btnHabilitarSeguro, 0);
            this.Controls.SetChildIndex(this.btnGestObs, 0);
            this.Controls.SetChildIndex(this.btnTasaN, 0);
            this.grbDatosCliente.ResumeLayout(false);
            this.grbDatosCliente.PerformLayout();
            this.grbDatosEvaluacion.ResumeLayout(false);
            this.grbDatosEvaluacion.PerformLayout();
            this.tabEval.ResumeLayout(false);
            this.tbpEvCualitativa.ResumeLayout(false);
            this.tbpEstFinancieros.ResumeLayout(false);
            this.tbpCondCredito.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosCliente;
        private GEN.ControlesBase.grbBase grbDatosEvaluacion;
        private GEN.ControlesBase.lblBase lblNombre;
        private GEN.ControlesBase.lblBase lblDocumentoID;
        private GEN.ControlesBase.txtBase txtDocumentoID;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtModCredito;
        private GEN.ControlesBase.txtBase txtTipoCambio;
        private GEN.ControlesBase.txtBase txtIDEvalCred;
        private GEN.ControlesBase.txtBase txtIDSolicitud;
        private GEN.ControlesBase.txtBase txtOperacion;
        private System.Windows.Forms.TabControl tabEval;
        private System.Windows.Forms.TabPage tbpEvCualitativa;
        private System.Windows.Forms.TabPage tbpEstFinancieros;
        private System.Windows.Forms.TabPage tbpCondCredito;
        private ControlBase.ConEvalCualitReferencias conEvalCualitReferencias;
        private GEN.ControlesBase.ConPropuestaCrediJornal conPropuestaCrediJornal;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnValidar btnValidar;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private GEN.BotonesBase.btnSalir btnSalir;
        private ControlBase.ConEstadosFinancieros conEstadosFinancieros;
        private ControlBase.ConCondiCredito conCondiCredito;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.BotonesBase.Boton btnExcepciones;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;
        private GEN.BotonesBase.btnBlanco btnGestObs;
        private GEN.BotonesBase.Boton btnTasaN;
    }
}