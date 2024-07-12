namespace CRE.Presentacion
{
    partial class frmEvalCredFacilito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalCredFacilito));
            this.tabEval = new System.Windows.Forms.TabControl();
            this.tbpRegistroSolicitud = new System.Windows.Forms.TabPage();
            this.btnTasaN = new GEN.BotonesBase.Boton();
            this.conSolicitudSimp = new GEN.ControlesBase.ConSolicitudSimp();
            this.tbpReferencias = new System.Windows.Forms.TabPage();
            this.conDetalleSaldoInterviniente = new GEN.ControlesBase.ConDetalleSaldoInterviniente();
            this.conReferenciasSimp = new GEN.ControlesBase.ConReferenciasSimp();
            this.tbpEstadosfinanciero = new System.Windows.Forms.TabPage();
            this.conEstadosFinancieros = new CRE.ControlBase.ConEstadosFinancieros();
            this.tbpCondicionesPropuestaCredito = new System.Windows.Forms.TabPage();
            this.conPropuestaSimpCred = new GEN.ControlesBase.ConPropuestaSimpCred();
            this.conCondiCredito = new CRE.ControlBase.ConCondiCredito();
            this.btnEnviarSolicitud = new GEN.BotonesBase.btnEnviar();
            this.btnEditarSolicitud = new GEN.BotonesBase.btnEditar();
            this.btnCancelarSolicitud = new GEN.BotonesBase.btnCancelar();
            this.btnGrabarSolicitud = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.conBusCliSimp = new GEN.ControlesBase.ConBusCliSimp();
            this.conBusSolEval = new GEN.ControlesBase.ConBusSolEval();
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnVincularVisita = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.btnExcepciones = new GEN.BotonesBase.Boton();
            this.btnObservacion = new GEN.BotonesBase.btnObservacion();
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.btnGestObs = new GEN.BotonesBase.btnBlanco();
            this.tabEval.SuspendLayout();
            this.tbpRegistroSolicitud.SuspendLayout();
            this.tbpReferencias.SuspendLayout();
            this.tbpEstadosfinanciero.SuspendLayout();
            this.tbpCondicionesPropuestaCredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEval
            // 
            this.tabEval.Controls.Add(this.tbpRegistroSolicitud);
            this.tabEval.Controls.Add(this.tbpReferencias);
            this.tabEval.Controls.Add(this.tbpEstadosfinanciero);
            this.tabEval.Controls.Add(this.tbpCondicionesPropuestaCredito);
            this.tabEval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEval.Location = new System.Drawing.Point(7, 81);
            this.tabEval.Name = "tabEval";
            this.tabEval.SelectedIndex = 0;
            this.tabEval.Size = new System.Drawing.Size(840, 516);
            this.tabEval.TabIndex = 3;
            this.tabEval.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabEval_Selecting);
            // 
            // tbpRegistroSolicitud
            // 
            this.tbpRegistroSolicitud.Controls.Add(this.conSolicitudSimp);
            this.tbpRegistroSolicitud.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistroSolicitud.Name = "tbpRegistroSolicitud";
            this.tbpRegistroSolicitud.Size = new System.Drawing.Size(832, 490);
            this.tbpRegistroSolicitud.TabIndex = 4;
            this.tbpRegistroSolicitud.Text = "Solicitud";
            this.tbpRegistroSolicitud.UseVisualStyleBackColor = true;
            // 
            // btnTasaN
            // 
            this.btnTasaN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTasaN.Location = new System.Drawing.Point(484, 603);
            this.btnTasaN.Name = "btnTasaN";
            this.btnTasaN.Size = new System.Drawing.Size(60, 50);
            this.btnTasaN.TabIndex = 82;
            this.btnTasaN.Text = "Solicitud Tasa ";
            this.btnTasaN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTasaN.UseVisualStyleBackColor = true;
            this.btnTasaN.Click += new System.EventHandler(this.boton1_Click);
            // 
            // conSolicitudSimp
            // 
            this.conSolicitudSimp.idProductoDefecto = 0;
            this.conSolicitudSimp.idTipEvalCred = 0;
            this.conSolicitudSimp.Location = new System.Drawing.Point(4, 4);
            this.conSolicitudSimp.Name = "conSolicitudSimp";
            this.conSolicitudSimp.objCliente = null;
            this.conSolicitudSimp.Size = new System.Drawing.Size(797, 394);
            this.conSolicitudSimp.TabIndex = 0;
            this.conSolicitudSimp.EventoPostIntervinientes += new System.EventHandler(this.conSolicitudSimp_EventoPostIntervinientes);
            this.conSolicitudSimp.EventoValidarReglas += new System.EventHandler(this.conSolicitudSimp_EventoValidarReglas);
            // 
            // tbpReferencias
            // 
            this.tbpReferencias.Controls.Add(this.conDetalleSaldoInterviniente);
            this.tbpReferencias.Controls.Add(this.conReferenciasSimp);
            this.tbpReferencias.Location = new System.Drawing.Point(4, 22);
            this.tbpReferencias.Name = "tbpReferencias";
            this.tbpReferencias.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReferencias.Size = new System.Drawing.Size(832, 490);
            this.tbpReferencias.TabIndex = 1;
            this.tbpReferencias.Text = "Referencias";
            this.tbpReferencias.UseVisualStyleBackColor = true;
            // 
            // conDetalleSaldoInterviniente
            // 
            this.conDetalleSaldoInterviniente.Location = new System.Drawing.Point(6, 197);
            this.conDetalleSaldoInterviniente.Name = "conDetalleSaldoInterviniente";
            this.conDetalleSaldoInterviniente.Size = new System.Drawing.Size(740, 140);
            this.conDetalleSaldoInterviniente.TabIndex = 1;
            // 
            // conReferenciasSimp
            // 
            this.conReferenciasSimp.Location = new System.Drawing.Point(6, 6);
            this.conReferenciasSimp.Name = "conReferenciasSimp";
            this.conReferenciasSimp.Size = new System.Drawing.Size(740, 176);
            this.conReferenciasSimp.TabIndex = 0;
            // 
            // tbpEstadosfinanciero
            // 
            this.tbpEstadosfinanciero.Controls.Add(this.conEstadosFinancieros);
            this.tbpEstadosfinanciero.Location = new System.Drawing.Point(4, 22);
            this.tbpEstadosfinanciero.Name = "tbpEstadosfinanciero";
            this.tbpEstadosfinanciero.Size = new System.Drawing.Size(832, 490);
            this.tbpEstadosfinanciero.TabIndex = 2;
            this.tbpEstadosfinanciero.Text = "Estados Financieros";
            this.tbpEstadosfinanciero.UseVisualStyleBackColor = true;
            // 
            // conEstadosFinancieros
            // 
            this.conEstadosFinancieros.BalanceGeneralEnabled = false;
            this.conEstadosFinancieros.ButtonBalanceGeneral = false;
            this.conEstadosFinancieros.ButtonDeudas = true;
            this.conEstadosFinancieros.ButtonEstadosResultados = true;
            this.conEstadosFinancieros.lHabilitarBalanceGeneral = true;
            this.conEstadosFinancieros.lHabilitarBotones = true;
            this.conEstadosFinancieros.lHabilitarEtadosResultados = true;
            this.conEstadosFinancieros.ListBalanceGeneral = null;
            this.conEstadosFinancieros.ListEstadoResultados = null;
            this.conEstadosFinancieros.lMostrarBalanceGeneral = false;
            this.conEstadosFinancieros.lMostrarBotones = true;
            this.conEstadosFinancieros.lMostrarEtadosResultados = true;
            this.conEstadosFinancieros.Location = new System.Drawing.Point(89, 13);
            this.conEstadosFinancieros.Name = "conEstadosFinancieros";
            this.conEstadosFinancieros.Size = new System.Drawing.Size(575, 474);
            this.conEstadosFinancieros.TabIndex = 0;
            this.conEstadosFinancieros.UltEvaluacionChecked = false;
            this.conEstadosFinancieros.UltEvaluacionEnabled = true;
            this.conEstadosFinancieros.DeudasClick += new System.EventHandler(this.conEstadosFinancieros_DeudasClick);
            this.conEstadosFinancieros.EERRClick += new System.EventHandler(this.conEstadosFinancieros_EERRClick);
            this.conEstadosFinancieros.EHZTLClick += new System.EventHandler(this.conEstadosFinancieros_EHZTLClick);
            // 
            // tbpCondicionesPropuestaCredito
            // 
            this.tbpCondicionesPropuestaCredito.Controls.Add(this.conPropuestaSimpCred);
            this.tbpCondicionesPropuestaCredito.Controls.Add(this.conCondiCredito);
            this.tbpCondicionesPropuestaCredito.Location = new System.Drawing.Point(4, 22);
            this.tbpCondicionesPropuestaCredito.Name = "tbpCondicionesPropuestaCredito";
            this.tbpCondicionesPropuestaCredito.Size = new System.Drawing.Size(832, 490);
            this.tbpCondicionesPropuestaCredito.TabIndex = 3;
            this.tbpCondicionesPropuestaCredito.Text = "Condiciones y Propuesta";
            this.tbpCondicionesPropuestaCredito.UseVisualStyleBackColor = true;
            // 
            // conPropuestaSimpCred
            // 
            this.conPropuestaSimpCred.lHabilitarTipActividad = true;
            this.conPropuestaSimpCred.Location = new System.Drawing.Point(338, 241);
            this.conPropuestaSimpCred.Name = "conPropuestaSimpCred";
            this.conPropuestaSimpCred.Size = new System.Drawing.Size(486, 249);
            this.conPropuestaSimpCred.TabIndex = 1;
            this.conPropuestaSimpCred.TxtDatosClienteEnabled = true;
            this.conPropuestaSimpCred.TxtDatosCreditoEnabled = true;
            // 
            // conCondiCredito
            // 
            this.conCondiCredito.lHabilitarActividad = true;
            this.conCondiCredito.lHabilitarCondicionesCredito = true;
            this.conCondiCredito.lHabilitarDestinoCredito = true;
            this.conCondiCredito.lHabilitarRCC = true;
            this.conCondiCredito.lMostrarBtnPropDesembolsos = false;
            this.conCondiCredito.lMostrarCondicionesCredito = true;
            this.conCondiCredito.lMostrarDestinoCredito = true;
            this.conCondiCredito.lMostrarRCC = false;
            this.conCondiCredito.Location = new System.Drawing.Point(0, 3);
            this.conCondiCredito.Name = "conCondiCredito";
            this.conCondiCredito.Size = new System.Drawing.Size(827, 487);
            this.conCondiCredito.TabIndex = 0;
            this.conCondiCredito.ActividadInternaSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged += new System.EventHandler(this.conCondiCredito_PlazoChanged);
            // 
            // btnEnviarSolicitud
            // 
            this.btnEnviarSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviarSolicitud.BackgroundImage")));
            this.btnEnviarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviarSolicitud.Location = new System.Drawing.Point(64, 603);
            this.btnEnviarSolicitud.Name = "btnEnviarSolicitud";
            this.btnEnviarSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnEnviarSolicitud.TabIndex = 5;
            this.btnEnviarSolicitud.Text = "&Enviar";
            this.btnEnviarSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviarSolicitud.UseVisualStyleBackColor = true;
            this.btnEnviarSolicitud.Click += new System.EventHandler(this.btnEnviarSolicitud_Click);
            // 
            // btnEditarSolicitud
            // 
            this.btnEditarSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarSolicitud.BackgroundImage")));
            this.btnEditarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarSolicitud.Location = new System.Drawing.Point(244, 603);
            this.btnEditarSolicitud.Name = "btnEditarSolicitud";
            this.btnEditarSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnEditarSolicitud.TabIndex = 4;
            this.btnEditarSolicitud.Text = "&Editar";
            this.btnEditarSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarSolicitud.UseVisualStyleBackColor = true;
            this.btnEditarSolicitud.Click += new System.EventHandler(this.btnEditarSolicitud_Click);
            // 
            // btnCancelarSolicitud
            // 
            this.btnCancelarSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarSolicitud.BackgroundImage")));
            this.btnCancelarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarSolicitud.Location = new System.Drawing.Point(304, 603);
            this.btnCancelarSolicitud.Name = "btnCancelarSolicitud";
            this.btnCancelarSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarSolicitud.TabIndex = 3;
            this.btnCancelarSolicitud.Text = "&Cancelar";
            this.btnCancelarSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarSolicitud.UseVisualStyleBackColor = true;
            this.btnCancelarSolicitud.Click += new System.EventHandler(this.btnCancelarSolicitud_Click);
            // 
            // btnGrabarSolicitud
            // 
            this.btnGrabarSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarSolicitud.BackgroundImage")));
            this.btnGrabarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarSolicitud.Location = new System.Drawing.Point(184, 603);
            this.btnGrabarSolicitud.Name = "btnGrabarSolicitud";
            this.btnGrabarSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarSolicitud.TabIndex = 2;
            this.btnGrabarSolicitud.Text = "&Grabar";
            this.btnGrabarSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarSolicitud.UseVisualStyleBackColor = true;
            this.btnGrabarSolicitud.Click += new System.EventHandler(this.btnGrabarSolicitud_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(786, 603);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(304, 603);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(244, 603);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(184, 603);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(4, 603);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(64, 603);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Location = new System.Drawing.Point(726, 603);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 10;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // conBusCliSimp
            // 
            this.conBusCliSimp.BackColor = System.Drawing.Color.Transparent;
            this.conBusCliSimp.idCli = 0;
            this.conBusCliSimp.lMostrarDireccion = false;
            this.conBusCliSimp.Location = new System.Drawing.Point(6, 5);
            this.conBusCliSimp.Name = "conBusCliSimp";
            this.conBusCliSimp.Size = new System.Drawing.Size(446, 72);
            this.conBusCliSimp.TabIndex = 13;
            this.conBusCliSimp.EventoPostBuscar += new System.EventHandler(this.conBusCliSimp_EventoPostBuscar);
            // 
            // conBusSolEval
            // 
            this.conBusSolEval.BackColor = System.Drawing.Color.Transparent;
            this.conBusSolEval.cModalidad = null;
            this.conBusSolEval.cOperacion = null;
            this.conBusSolEval.Enabled = false;
            this.conBusSolEval.idEvalCred = 0;
            this.conBusSolEval.idSolicitud = 0;
            this.conBusSolEval.Location = new System.Drawing.Point(458, 5);
            this.conBusSolEval.Name = "conBusSolEval";
            this.conBusSolEval.Size = new System.Drawing.Size(390, 55);
            this.conBusSolEval.TabIndex = 14;
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(424, 603);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 16;
            this.btnCargaArhivos.Text = "Carga de Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
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
            this.btnVincularVisita.Location = new System.Drawing.Point(546, 603);
            this.btnVincularVisita.Name = "btnVincularVisita";
            this.btnVincularVisita.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita.TabIndex = 17;
            this.btnVincularVisita.Text = "Vincular Visita";
            this.btnVincularVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita.UseVisualStyleBackColor = true;
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Enabled = false;
            this.btnExcepciones.Image = global::CRE.Presentacion.Properties.Resources.success;
            this.btnExcepciones.Location = new System.Drawing.Point(606, 603);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 18;
            this.btnExcepciones.Text = "Excepc.";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnObservacion
            // 
            this.btnObservacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservacion.BackgroundImage")));
            this.btnObservacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservacion.Enabled = false;
            this.btnObservacion.Location = new System.Drawing.Point(124, 603);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(60, 50);
            this.btnObservacion.TabIndex = 28;
            this.btnObservacion.Text = "&Obs.";
            this.btnObservacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Visible = false;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Enabled = false;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(364, 603);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 62;
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
            this.btnGestObs.Location = new System.Drawing.Point(666, 603);
            this.btnGestObs.Name = "btnGestObs";
            this.btnGestObs.Size = new System.Drawing.Size(60, 50);
            this.btnGestObs.TabIndex = 67;
            this.btnGestObs.Text = "Observ.";
            this.btnGestObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestObs.UseVisualStyleBackColor = true;
            this.btnGestObs.Click += new System.EventHandler(this.btnGestObs_Click);
            // 
            // frmEvalCredFacilito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 686);
            this.Controls.Add(this.btnTasaN);
            this.Controls.Add(this.btnGestObs);
            this.Controls.Add(this.btnHabilitarSeguro);
            this.Controls.Add(this.btnCancelarSolicitud);
            this.Controls.Add(this.btnEditarSolicitud);
            this.Controls.Add(this.btnEnviarSolicitud);
            this.Controls.Add(this.btnGrabarSolicitud);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnObservacion);
            this.Controls.Add(this.btnVincularVisita);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.conBusSolEval);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabEval);
            this.Controls.Add(this.conBusCliSimp);
            this.Name = "frmEvalCredFacilito";
            this.Text = "Evaluacion de Credito Pyme Facilito";
            this.Load += new System.EventHandler(this.frmEvalCredFacilito_Load);
            this.Controls.SetChildIndex(this.conBusCliSimp, 0);
            this.Controls.SetChildIndex(this.tabEval, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.conBusSolEval, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita, 0);
            this.Controls.SetChildIndex(this.btnObservacion, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.btnGrabarSolicitud, 0);
            this.Controls.SetChildIndex(this.btnEnviarSolicitud, 0);
            this.Controls.SetChildIndex(this.btnEditarSolicitud, 0);
            this.Controls.SetChildIndex(this.btnCancelarSolicitud, 0);
            this.Controls.SetChildIndex(this.btnHabilitarSeguro, 0);
            this.Controls.SetChildIndex(this.btnGestObs, 0);
            this.Controls.SetChildIndex(this.btnTasaN, 0);
            this.tabEval.ResumeLayout(false);
            this.tbpRegistroSolicitud.ResumeLayout(false);
            this.tbpReferencias.ResumeLayout(false);
            this.tbpEstadosfinanciero.ResumeLayout(false);
            this.tbpCondicionesPropuestaCredito.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabEval;
        private System.Windows.Forms.TabPage tbpReferencias;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnValidar btnValidar;
        private System.Windows.Forms.TabPage tbpEstadosfinanciero;
        private System.Windows.Forms.TabPage tbpCondicionesPropuestaCredito;
        private ControlBase.ConCondiCredito conCondiCredito;
        private GEN.ControlesBase.ConPropuestaSimpCred conPropuestaSimpCred;
        private GEN.ControlesBase.ConReferenciasSimp conReferenciasSimp;
        private ControlBase.ConEstadosFinancieros conEstadosFinancieros;
        private GEN.ControlesBase.ConBusCliSimp conBusCliSimp;
        private GEN.ControlesBase.ConBusSolEval conBusSolEval;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita;
        private GEN.BotonesBase.Boton btnExcepciones;
        private GEN.BotonesBase.btnObservacion btnObservacion;
        private GEN.ControlesBase.ConDetalleSaldoInterviniente conDetalleSaldoInterviniente;
        private System.Windows.Forms.TabPage tbpRegistroSolicitud;
        private GEN.ControlesBase.ConSolicitudSimp conSolicitudSimp;
        private GEN.BotonesBase.btnEnviar btnEnviarSolicitud;
        private GEN.BotonesBase.btnEditar btnEditarSolicitud;
        private GEN.BotonesBase.btnCancelar btnCancelarSolicitud;
        private GEN.BotonesBase.btnGrabar btnGrabarSolicitud;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;
        private GEN.BotonesBase.btnBlanco btnGestObs;
        private GEN.BotonesBase.Boton btnTasaN;
    }
}