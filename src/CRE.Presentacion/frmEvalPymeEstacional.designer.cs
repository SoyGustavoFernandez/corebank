namespace CRE.Presentacion
{
    partial class frmEvalPymeEstacional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalPymeEstacional));
            this.btnVincularVisita = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtModCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtIdSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdEvalCred = new GEN.ControlesBase.txtBase(this.components);
            this.ttpToolTip1 = new GEN.ControlesBase.ttpToolTip();
            this.btnCopiado = new GEN.BotonesBase.btnBlanco();
            this.btnObservacion = new GEN.BotonesBase.btnObservacion();
            this.btnImprimirFlujoCaja = new GEN.BotonesBase.btnImprimir();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnChecklist = new GEN.BotonesBase.btnDocumento();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnExcepciones = new GEN.BotonesBase.Boton();
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.tbpPropCredito = new System.Windows.Forms.TabPage();
            this.conPropuestaPymeEst = new GEN.ControlesBase.ConPropuestaPymeEst();
            this.tbpEstFinancie = new System.Windows.Forms.TabPage();
            this.conEstadosFinancierosPymeEst = new GEN.ControlesBase.ConEstadosFinancierosPymeEst();
            this.tbpEvCualitati = new System.Windows.Forms.TabPage();
            this.conEvalCualitReferencias = new CRE.ControlBase.ConEvalCualitReferencias();
            this.tabEval = new System.Windows.Forms.TabControl();
            this.btnGestObs = new GEN.BotonesBase.btnBlanco();
            this.btnTasaN = new GEN.BotonesBase.Boton();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.tbpPropCredito.SuspendLayout();
            this.tbpEstFinancie.SuspendLayout();
            this.tbpEvCualitati.SuspendLayout();
            this.tabEval.SuspendLayout();
            this.SuspendLayout();
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
            this.btnVincularVisita.Location = new System.Drawing.Point(419, 605);
            this.btnVincularVisita.Name = "btnVincularVisita";
            this.btnVincularVisita.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita.TabIndex = 1;
            this.btnVincularVisita.Text = "Vincular Visita";
            this.btnVincularVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(147, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(340, 20);
            this.txtNombre.TabIndex = 12;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(147, 11);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNroDoc.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNombre);
            this.grbBase1.Controls.Add(this.txtNroDoc);
            this.grbBase1.Location = new System.Drawing.Point(5, 5);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(497, 61);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(1, 36);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(144, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Nombre  o Razón Social";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(31, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(114, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Nro de Documento";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(4, 36);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(92, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Nro Evaluación";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 14);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(79, 13);
            this.lblBase5.TabIndex = 19;
            this.lblBase5.Text = "Nro Solicitud";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTipoCambio);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.txtOperacion);
            this.grbBase2.Controls.Add(this.txtModCredito);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtIdSolicitud);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtIdEvalCred);
            this.grbBase2.Location = new System.Drawing.Point(508, 5);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(532, 61);
            this.grbBase2.TabIndex = 18;
            this.grbBase2.TabStop = false;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Location = new System.Drawing.Point(450, 11);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(60, 20);
            this.txtTipoCambio.TabIndex = 111;
            this.txtTipoCambio.Text = "0";
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(384, 14);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(64, 13);
            this.lblBase8.TabIndex = 110;
            this.lblBase8.Text = "T. Cambio";
            // 
            // txtOperacion
            // 
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(260, 11);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(115, 20);
            this.txtOperacion.TabIndex = 109;
            this.txtOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtModCredito
            // 
            this.txtModCredito.Enabled = false;
            this.txtModCredito.Location = new System.Drawing.Point(260, 33);
            this.txtModCredito.Name = "txtModCredito";
            this.txtModCredito.Size = new System.Drawing.Size(115, 20);
            this.txtModCredito.TabIndex = 108;
            this.txtModCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(193, 14);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 25;
            this.lblBase4.Text = "Operación";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(194, 36);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(64, 13);
            this.lblBase6.TabIndex = 26;
            this.lblBase6.Text = "Modalidad";
            // 
            // txtIdSolicitud
            // 
            this.txtIdSolicitud.Enabled = false;
            this.txtIdSolicitud.Location = new System.Drawing.Point(98, 11);
            this.txtIdSolicitud.Name = "txtIdSolicitud";
            this.txtIdSolicitud.Size = new System.Drawing.Size(87, 20);
            this.txtIdSolicitud.TabIndex = 12;
            this.txtIdSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdEvalCred
            // 
            this.txtIdEvalCred.Enabled = false;
            this.txtIdEvalCred.Location = new System.Drawing.Point(98, 33);
            this.txtIdEvalCred.Name = "txtIdEvalCred";
            this.txtIdEvalCred.Size = new System.Drawing.Size(87, 20);
            this.txtIdEvalCred.TabIndex = 15;
            this.txtIdEvalCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCopiado
            // 
            this.btnCopiado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopiado.Enabled = false;
            this.btnCopiado.Image = global::CRE.Presentacion.Properties.Resources.btnTrasladar;
            this.btnCopiado.Location = new System.Drawing.Point(547, 605);
            this.btnCopiado.Name = "btnCopiado";
            this.btnCopiado.Size = new System.Drawing.Size(60, 50);
            this.btnCopiado.TabIndex = 28;
            this.btnCopiado.Text = "Copiar";
            this.btnCopiado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiado.UseVisualStyleBackColor = true;
            this.btnCopiado.Click += new System.EventHandler(this.btnCopiado_Click);
            // 
            // btnObservacion
            // 
            this.btnObservacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservacion.BackgroundImage")));
            this.btnObservacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservacion.Enabled = false;
            this.btnObservacion.Location = new System.Drawing.Point(163, 606);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(60, 50);
            this.btnObservacion.TabIndex = 27;
            this.btnObservacion.Text = "&Obs.";
            this.btnObservacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Visible = false;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // btnImprimirFlujoCaja
            // 
            this.btnImprimirFlujoCaja.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimirFlujoCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirFlujoCaja.BackgroundImage")));
            this.btnImprimirFlujoCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirFlujoCaja.Enabled = false;
            this.btnImprimirFlujoCaja.Location = new System.Drawing.Point(101, 605);
            this.btnImprimirFlujoCaja.Name = "btnImprimirFlujoCaja";
            this.btnImprimirFlujoCaja.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirFlujoCaja.TabIndex = 25;
            this.btnImprimirFlujoCaja.Text = "Flujo de Caja";
            this.btnImprimirFlujoCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirFlujoCaja.UseVisualStyleBackColor = false;
            this.btnImprimirFlujoCaja.Click += new System.EventHandler(this.btnImprimirFlujoCaja_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(928, 604);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(737, 605);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 24;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Enabled = false;
            this.btnValidar.Location = new System.Drawing.Point(737, 605);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 1;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(163, 605);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 23;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnChecklist
            // 
            this.btnChecklist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChecklist.BackgroundImage")));
            this.btnChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Location = new System.Drawing.Point(673, 605);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(60, 50);
            this.btnChecklist.TabIndex = 22;
            this.btnChecklist.Text = "Checklist";
            this.btnChecklist.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChecklist.UseVisualStyleBackColor = true;
            this.btnChecklist.Visible = false;
            this.btnChecklist.Click += new System.EventHandler(this.btnChecklist_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.SystemColors.Control;
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(801, 604);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 20;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(37, 605);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(991, 604);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(865, 604);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Enabled = false;
            this.btnExcepciones.Image = global::CRE.Presentacion.Properties.Resources.success;
            this.btnExcepciones.Location = new System.Drawing.Point(483, 605);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 1;
            this.btnExcepciones.Text = "Excepc.";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(291, 605);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 29;
            this.btnCargaArhivos.Text = "Carga de Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Enabled = false;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(227, 605);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 59;
            this.btnHabilitarSeguro.Text = "Habilitar Seguros";
            this.btnHabilitarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitarSeguro.UseVisualStyleBackColor = true;
            this.btnHabilitarSeguro.Click += new System.EventHandler(this.btnHabilitarSeguro_Click);
            // 
            // tbpPropCredito
            // 
            this.tbpPropCredito.BackColor = System.Drawing.SystemColors.Control;
            this.tbpPropCredito.Controls.Add(this.conPropuestaPymeEst);
            this.tbpPropCredito.Location = new System.Drawing.Point(4, 22);
            this.tbpPropCredito.Name = "tbpPropCredito";
            this.tbpPropCredito.Size = new System.Drawing.Size(1076, 506);
            this.tbpPropCredito.TabIndex = 3;
            this.tbpPropCredito.Text = "Propuesta de Crédito";
            // 
            // conPropuestaPymeEst
            // 
            this.conPropuestaPymeEst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conPropuestaPymeEst.Location = new System.Drawing.Point(0, 0);
            this.conPropuestaPymeEst.Name = "conPropuestaPymeEst";
            this.conPropuestaPymeEst.Size = new System.Drawing.Size(1076, 506);
            this.conPropuestaPymeEst.TabIndex = 0;
            // 
            // tbpEstFinancie
            // 
            this.tbpEstFinancie.Controls.Add(this.conEstadosFinancierosPymeEst);
            this.tbpEstFinancie.Location = new System.Drawing.Point(4, 22);
            this.tbpEstFinancie.Name = "tbpEstFinancie";
            this.tbpEstFinancie.Size = new System.Drawing.Size(1076, 506);
            this.tbpEstFinancie.TabIndex = 2;
            this.tbpEstFinancie.Text = "Estados Financieros";
            // 
            // conEstadosFinancierosPymeEst
            // 
            this.conEstadosFinancierosPymeEst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conEstadosFinancierosPymeEst.Location = new System.Drawing.Point(0, 0);
            this.conEstadosFinancierosPymeEst.Name = "conEstadosFinancierosPymeEst";
            this.conEstadosFinancierosPymeEst.Size = new System.Drawing.Size(1076, 506);
            this.conEstadosFinancierosPymeEst.TabIndex = 0;
            this.conEstadosFinancierosPymeEst.DeudasClick += new System.EventHandler(this.conEstadosFinancierosPymeEst_DeudasClick);
            // 
            // tbpEvCualitati
            // 
            this.tbpEvCualitati.Controls.Add(this.conEvalCualitReferencias);
            this.tbpEvCualitati.Location = new System.Drawing.Point(4, 22);
            this.tbpEvCualitati.Name = "tbpEvCualitati";
            this.tbpEvCualitati.Size = new System.Drawing.Size(1076, 506);
            this.tbpEvCualitati.TabIndex = 0;
            this.tbpEvCualitati.Text = "Eval. Cualitativa y Referencias";
            // 
            // conEvalCualitReferencias
            // 
            this.conEvalCualitReferencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conEvalCualitReferencias.Location = new System.Drawing.Point(0, 0);
            this.conEvalCualitReferencias.Name = "conEvalCualitReferencias";
            this.conEvalCualitReferencias.Size = new System.Drawing.Size(1076, 506);
            this.conEvalCualitReferencias.TabIndex = 0;
            // 
            // tabEval
            // 
            this.tabEval.Controls.Add(this.tbpEvCualitati);
            this.tabEval.Controls.Add(this.tbpEstFinancie);
            this.tabEval.Controls.Add(this.tbpPropCredito);
            this.tabEval.Enabled = false;
            this.tabEval.Location = new System.Drawing.Point(5, 72);
            this.tabEval.Name = "tabEval";
            this.tabEval.SelectedIndex = 0;
            this.tabEval.Size = new System.Drawing.Size(1084, 532);
            this.tabEval.TabIndex = 2;
            // 
            // btnGestObs
            // 
            this.btnGestObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestObs.BackgroundImage")));
            this.btnGestObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestObs.Enabled = false;
            this.btnGestObs.Location = new System.Drawing.Point(613, 605);
            this.btnGestObs.Name = "btnGestObs";
            this.btnGestObs.Size = new System.Drawing.Size(60, 50);
            this.btnGestObs.TabIndex = 60;
            this.btnGestObs.Text = "Observ.";
            this.btnGestObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestObs.UseVisualStyleBackColor = true;
            this.btnGestObs.Click += new System.EventHandler(this.btnGestObs_Click);
            // 
            // btnTasaN
            // 
            this.btnTasaN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTasaN.Location = new System.Drawing.Point(357, 605);
            this.btnTasaN.Name = "btnTasaN";
            this.btnTasaN.Size = new System.Drawing.Size(60, 50);
            this.btnTasaN.TabIndex = 83;
            this.btnTasaN.Text = "Solicitud Tasa ";
            this.btnTasaN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTasaN.UseVisualStyleBackColor = true;
            this.btnTasaN.Click += new System.EventHandler(this.btnTasaN_Click);
            // 
            // frmEvalPymeEstacional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 680);
            this.Controls.Add(this.btnTasaN);
            this.Controls.Add(this.btnGestObs);
            this.Controls.Add(this.btnHabilitarSeguro);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.btnVincularVisita);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnCopiado);
            this.Controls.Add(this.btnObservacion);
            this.Controls.Add(this.btnImprimirFlujoCaja);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnChecklist);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tabEval);
            this.Name = "frmEvalPymeEstacional";
            this.ShowInTaskbar = false;
            this.Text = "Evaluación Pyme Estacional";
            this.Controls.SetChildIndex(this.tabEval, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.btnChecklist, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnImprimirFlujoCaja, 0);
            this.Controls.SetChildIndex(this.btnObservacion, 0);
            this.Controls.SetChildIndex(this.btnCopiado, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.btnHabilitarSeguro, 0);
            this.Controls.SetChildIndex(this.btnGestObs, 0);
            this.Controls.SetChildIndex(this.btnTasaN, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.tbpPropCredito.ResumeLayout(false);
            this.tbpEstFinancie.ResumeLayout(false);
            this.tbpEvCualitati.ResumeLayout(false);
            this.tabEval.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtIdSolicitud;
        private GEN.ControlesBase.txtBase txtIdEvalCred;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnDocumento btnChecklist;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtModCredito;
        private GEN.ControlesBase.txtBase txtOperacion;
        private GEN.BotonesBase.btnValidar btnValidar;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnImprimir btnImprimirFlujoCaja;
        private GEN.ControlesBase.txtBase txtTipoCambio;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.ttpToolTip ttpToolTip1;
        private GEN.BotonesBase.btnObservacion btnObservacion;
        private GEN.BotonesBase.btnBlanco btnCopiado;
        private GEN.BotonesBase.Boton btnExcepciones;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;
        private System.Windows.Forms.TabPage tbpPropCredito;
        private System.Windows.Forms.TabPage tbpEstFinancie;
        private System.Windows.Forms.TabPage tbpEvCualitati;
        private ControlBase.ConEvalCualitReferencias conEvalCualitReferencias;
        private System.Windows.Forms.TabControl tabEval;
        private GEN.ControlesBase.ConPropuestaPymeEst conPropuestaPymeEst;
        private GEN.ControlesBase.ConEstadosFinancierosPymeEst conEstadosFinancierosPymeEst;
        private GEN.BotonesBase.btnBlanco btnGestObs;
        private GEN.BotonesBase.Boton btnTasaN;
    }
}