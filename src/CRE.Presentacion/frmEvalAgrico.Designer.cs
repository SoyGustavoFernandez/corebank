namespace CRE.Presentacion
{
    partial class frmEvalAgrico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalAgrico));
            this.tabEval = new System.Windows.Forms.TabControl();
            this.tbpEvCualitati = new System.Windows.Forms.TabPage();
            this.conEvalCualitReferencias = new CRE.ControlBase.ConEvalCualitReferencias();
            this.tbpEstFinancie = new System.Windows.Forms.TabPage();
            this.conEstadosFinancieros = new CRE.ControlBase.ConEstadosFinancierosAgrico();
            this.tbpCondCredito = new System.Windows.Forms.TabPage();
            this.grbCultivos = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboVariedadCultivoEval1 = new GEN.ControlesBase.cboVariedadCultivoEval(this.components);
            this.cboCultivoEval1 = new GEN.ControlesBase.cboCultivoEval(this.components);
            this.plMsjBloqueo = new System.Windows.Forms.Panel();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.conCondiCredito = new CRE.ControlBase.ConCondiCredito();
            this.tbpPropCredito = new System.Windows.Forms.TabPage();
            this.conPropuesta = new CRE.ControlBase.ConPropuesta();
            this.btnGestObs = new GEN.BotonesBase.btnBlanco();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtModCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtIdSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdEvalCred = new GEN.ControlesBase.txtBase(this.components);
            this.btnChecklist = new GEN.BotonesBase.btnDocumento();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnImprimirFlujoCaja = new GEN.BotonesBase.btnImprimir();
            this.btnObservacion1 = new GEN.BotonesBase.btnObservacion();
            this.btnCopiado = new GEN.BotonesBase.btnBlanco();
            this.btnExcepciones = new GEN.BotonesBase.Boton();
            this.btnVincularVisita1 = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.btnTasaN = new GEN.BotonesBase.Boton();
            this.tabEval.SuspendLayout();
            this.tbpEvCualitati.SuspendLayout();
            this.tbpEstFinancie.SuspendLayout();
            this.tbpCondCredito.SuspendLayout();
            this.grbCultivos.SuspendLayout();
            this.plMsjBloqueo.SuspendLayout();
            this.tbpPropCredito.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEval
            // 
            this.tabEval.Controls.Add(this.tbpEvCualitati);
            this.tabEval.Controls.Add(this.tbpEstFinancie);
            this.tabEval.Controls.Add(this.tbpCondCredito);
            this.tabEval.Controls.Add(this.tbpPropCredito);
            this.tabEval.Enabled = false;
            this.tabEval.Location = new System.Drawing.Point(5, 72);
            this.tabEval.Name = "tabEval";
            this.tabEval.SelectedIndex = 0;
            this.tabEval.Size = new System.Drawing.Size(1120, 532);
            this.tabEval.TabIndex = 2;
            this.tabEval.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabEval_Selected);
            // 
            // tbpEvCualitati
            // 
            this.tbpEvCualitati.Controls.Add(this.conEvalCualitReferencias);
            this.tbpEvCualitati.Location = new System.Drawing.Point(4, 22);
            this.tbpEvCualitati.Name = "tbpEvCualitati";
            this.tbpEvCualitati.Size = new System.Drawing.Size(1112, 506);
            this.tbpEvCualitati.TabIndex = 0;
            this.tbpEvCualitati.Text = "Eval. Cualitativa y Referencias";
            // 
            // conEvalCualitReferencias
            // 
            this.conEvalCualitReferencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conEvalCualitReferencias.Location = new System.Drawing.Point(0, 0);
            this.conEvalCualitReferencias.Name = "conEvalCualitReferencias";
            this.conEvalCualitReferencias.Size = new System.Drawing.Size(1112, 506);
            this.conEvalCualitReferencias.TabIndex = 0;
            this.conEvalCualitReferencias.ActualizarEvalCualitativoClick += new System.EventHandler(this.conEvalCualitReferencias_ActualizarEvalCualitativoClick);
            // 
            // tbpEstFinancie
            // 
            this.tbpEstFinancie.Controls.Add(this.conEstadosFinancieros);
            this.tbpEstFinancie.Location = new System.Drawing.Point(4, 22);
            this.tbpEstFinancie.Name = "tbpEstFinancie";
            this.tbpEstFinancie.Size = new System.Drawing.Size(1112, 506);
            this.tbpEstFinancie.TabIndex = 2;
            this.tbpEstFinancie.Text = "Estados Financieros";
            // 
            // conEstadosFinancieros
            // 
            this.conEstadosFinancieros.BalanceGeneralEnabled = true;
            this.conEstadosFinancieros.ButtonDeudas = true;
            this.conEstadosFinancieros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conEstadosFinancieros.ListBalanceGeneral = null;
            this.conEstadosFinancieros.Location = new System.Drawing.Point(0, 0);
            this.conEstadosFinancieros.Name = "conEstadosFinancieros";
            this.conEstadosFinancieros.Size = new System.Drawing.Size(1112, 506);
            this.conEstadosFinancieros.TabIndex = 0;
            this.conEstadosFinancieros.VisibleButtonDeudas = true;
            this.conEstadosFinancieros.DeudasClick += new System.EventHandler(this.conEstadosFinancieros_DeudasClick);
            this.conEstadosFinancieros.ActividadAgricolaClick += new System.EventHandler(this.conEstadosFinancieros_ActividadAgricolaClick);
            // 
            // tbpCondCredito
            // 
            this.tbpCondCredito.Controls.Add(this.grbCultivos);
            this.tbpCondCredito.Controls.Add(this.plMsjBloqueo);
            this.tbpCondCredito.Controls.Add(this.conCondiCredito);
            this.tbpCondCredito.Location = new System.Drawing.Point(4, 22);
            this.tbpCondCredito.Name = "tbpCondCredito";
            this.tbpCondCredito.Size = new System.Drawing.Size(1112, 506);
            this.tbpCondCredito.TabIndex = 1;
            this.tbpCondCredito.Text = "Condiciones del Crédito";
            this.tbpCondCredito.UseVisualStyleBackColor = true;
            // 
            // grbCultivos
            // 
            this.grbCultivos.Controls.Add(this.lblBase9);
            this.grbCultivos.Controls.Add(this.lblBase7);
            this.grbCultivos.Controls.Add(this.cboVariedadCultivoEval1);
            this.grbCultivos.Controls.Add(this.cboCultivoEval1);
            this.grbCultivos.Location = new System.Drawing.Point(347, 268);
            this.grbCultivos.Name = "grbCultivos";
            this.grbCultivos.Size = new System.Drawing.Size(307, 79);
            this.grbCultivos.TabIndex = 4;
            this.grbCultivos.TabStop = false;
            this.grbCultivos.Text = "Cultivos";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 50);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 3;
            this.lblBase9.Text = "Variedad:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(16, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(52, 13);
            this.lblBase7.TabIndex = 2;
            this.lblBase7.Text = "Cultivo:";
            // 
            // cboVariedadCultivoEval1
            // 
            this.cboVariedadCultivoEval1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVariedadCultivoEval1.FormattingEnabled = true;
            this.cboVariedadCultivoEval1.Location = new System.Drawing.Point(69, 47);
            this.cboVariedadCultivoEval1.Name = "cboVariedadCultivoEval1";
            this.cboVariedadCultivoEval1.Size = new System.Drawing.Size(232, 21);
            this.cboVariedadCultivoEval1.TabIndex = 1;
            // 
            // cboCultivoEval1
            // 
            this.cboCultivoEval1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCultivoEval1.FormattingEnabled = true;
            this.cboCultivoEval1.Location = new System.Drawing.Point(69, 19);
            this.cboCultivoEval1.Name = "cboCultivoEval1";
            this.cboCultivoEval1.Size = new System.Drawing.Size(232, 21);
            this.cboCultivoEval1.TabIndex = 0;
            this.cboCultivoEval1.SelectedIndexChanged += new System.EventHandler(this.cboCultivoEval1_SelectedIndexChanged);
            // 
            // plMsjBloqueo
            // 
            this.plMsjBloqueo.BackColor = System.Drawing.SystemColors.Info;
            this.plMsjBloqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plMsjBloqueo.Controls.Add(this.lblBaseCustom1);
            this.plMsjBloqueo.Location = new System.Drawing.Point(759, 319);
            this.plMsjBloqueo.Name = "plMsjBloqueo";
            this.plMsjBloqueo.Size = new System.Drawing.Size(223, 83);
            this.plMsjBloqueo.TabIndex = 2;
            this.plMsjBloqueo.Visible = false;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Brown;
            this.lblBaseCustom1.Location = new System.Drawing.Point(14, 14);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(192, 52);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "Condiciones de crédito estará bloqueado mientras no esté vinculado con una solici" +
    "tud de crédito.";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conCondiCredito
            // 
            this.conCondiCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCondiCredito.lHabilitarActividad = false;
            this.conCondiCredito.lHabilitarCondicionesCredito = true;
            this.conCondiCredito.lHabilitarDestinoCredito = true;
            this.conCondiCredito.lHabilitarRCC = true;
            this.conCondiCredito.lMostrarBtnPropDesembolsos = false;
            this.conCondiCredito.lMostrarCondicionesCredito = true;
            this.conCondiCredito.lMostrarDestinoCredito = true;
            this.conCondiCredito.lMostrarRCC = false;
            this.conCondiCredito.Location = new System.Drawing.Point(0, 0);
            this.conCondiCredito.Name = "conCondiCredito";
            this.conCondiCredito.Size = new System.Drawing.Size(1112, 506);
            this.conCondiCredito.TabIndex = 0;
            this.conCondiCredito.PlazoChanged += new System.EventHandler(this.conCondiCredito_PlazoChanged);
            // 
            // tbpPropCredito
            // 
            this.tbpPropCredito.Controls.Add(this.conPropuesta);
            this.tbpPropCredito.Location = new System.Drawing.Point(4, 22);
            this.tbpPropCredito.Name = "tbpPropCredito";
            this.tbpPropCredito.Size = new System.Drawing.Size(1112, 506);
            this.tbpPropCredito.TabIndex = 3;
            this.tbpPropCredito.Text = "Propuesta de Crédito";
            this.tbpPropCredito.UseVisualStyleBackColor = true;
            // 
            // conPropuesta
            // 
            this.conPropuesta.ConActSecundariaEnabled = true;
            this.conPropuesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conPropuesta.Location = new System.Drawing.Point(0, 0);
            this.conPropuesta.Name = "conPropuesta";
            this.conPropuesta.Size = new System.Drawing.Size(1112, 506);
            this.conPropuesta.TabIndex = 0;
            this.conPropuesta.TxtAntecedentesEnabled = true;
            this.conPropuesta.TxtConclusionesEnabled = true;
            this.conPropuesta.TxtDestPrestamoEnabled = true;
            this.conPropuesta.TxtEntFamiliarEnabled = true;
            this.conPropuesta.TxtGarantiasEnabled = true;
            this.conPropuesta.TxtIndFinancierosEnabled = true;
            // 
            // btnGestObs
            // 
            this.btnGestObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGestObs.BackgroundImage")));
            this.btnGestObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGestObs.Enabled = false;
            this.btnGestObs.Location = new System.Drawing.Point(617, 605);
            this.btnGestObs.Name = "btnGestObs";
            this.btnGestObs.Size = new System.Drawing.Size(60, 50);
            this.btnGestObs.TabIndex = 3;
            this.btnGestObs.Text = "Observ.";
            this.btnGestObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestObs.UseVisualStyleBackColor = true;
            this.btnGestObs.Click += new System.EventHandler(this.btnGestObs_Click);
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
            this.grbBase2.Controls.Add(this.txtOperacion);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.txtModCredito);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtIdSolicitud);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtIdEvalCred);
            this.grbBase2.Location = new System.Drawing.Point(508, 5);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(527, 61);
            this.grbBase2.TabIndex = 18;
            this.grbBase2.TabStop = false;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Location = new System.Drawing.Point(450, 11);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(60, 20);
            this.txtTipoCambio.TabIndex = 113;
            this.txtTipoCambio.Text = "0";
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(384, 14);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(64, 13);
            this.lblBase8.TabIndex = 112;
            this.lblBase8.Text = "T. Cambio";
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
            // btnChecklist
            // 
            this.btnChecklist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChecklist.BackgroundImage")));
            this.btnChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Location = new System.Drawing.Point(745, 605);
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
            this.btnBusqueda.Location = new System.Drawing.Point(873, 605);
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
            this.btnImprimir.Location = new System.Drawing.Point(8, 605);
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
            this.btnGrabar.Location = new System.Drawing.Point(1065, 605);
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
            this.btnNuevo.Location = new System.Drawing.Point(937, 605);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(231, 605);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 23;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Enabled = false;
            this.btnValidar.Location = new System.Drawing.Point(681, 605);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 1;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(808, 605);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 24;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Visible = false;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(1001, 605);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnImprimirFlujoCaja
            // 
            this.btnImprimirFlujoCaja.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimirFlujoCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirFlujoCaja.BackgroundImage")));
            this.btnImprimirFlujoCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirFlujoCaja.Enabled = false;
            this.btnImprimirFlujoCaja.Location = new System.Drawing.Point(74, 605);
            this.btnImprimirFlujoCaja.Name = "btnImprimirFlujoCaja";
            this.btnImprimirFlujoCaja.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirFlujoCaja.TabIndex = 25;
            this.btnImprimirFlujoCaja.Text = "Flujo de Caja";
            this.btnImprimirFlujoCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirFlujoCaja.UseVisualStyleBackColor = false;
            this.btnImprimirFlujoCaja.Visible = false;
            this.btnImprimirFlujoCaja.Click += new System.EventHandler(this.btnImprimirFlujoCaja_Click);
            // 
            // btnObservacion1
            // 
            this.btnObservacion1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservacion1.BackgroundImage")));
            this.btnObservacion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservacion1.Enabled = false;
            this.btnObservacion1.Location = new System.Drawing.Point(165, 605);
            this.btnObservacion1.Name = "btnObservacion1";
            this.btnObservacion1.Size = new System.Drawing.Size(60, 50);
            this.btnObservacion1.TabIndex = 29;
            this.btnObservacion1.Text = "&Obs.";
            this.btnObservacion1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservacion1.UseVisualStyleBackColor = true;
            this.btnObservacion1.Visible = false;
            this.btnObservacion1.Click += new System.EventHandler(this.btnObservacion1_Click);
            // 
            // btnCopiado
            // 
            this.btnCopiado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopiado.Enabled = false;
            this.btnCopiado.Image = global::CRE.Presentacion.Properties.Resources.btnTrasladar;
            this.btnCopiado.Location = new System.Drawing.Point(809, 605);
            this.btnCopiado.Name = "btnCopiado";
            this.btnCopiado.Size = new System.Drawing.Size(60, 50);
            this.btnCopiado.TabIndex = 29;
            this.btnCopiado.Text = "Copiar";
            this.btnCopiado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiado.UseVisualStyleBackColor = true;
            this.btnCopiado.Visible = false;
            this.btnCopiado.Click += new System.EventHandler(this.btnCopiado_Click);
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Enabled = false;
            this.btnExcepciones.Image = global::CRE.Presentacion.Properties.Resources.success;
            this.btnExcepciones.Location = new System.Drawing.Point(553, 605);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 30;
            this.btnExcepciones.Text = "Excepc.";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnVincularVisita1
            // 
            this.btnVincularVisita1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincularVisita1.BackgroundImage")));
            this.btnVincularVisita1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularVisita1.idCli = 0;
            this.btnVincularVisita1.idGrupoSolidario = 0;
            this.btnVincularVisita1.idSolicitud = 0;
            this.btnVincularVisita1.idSolicitudGrupoSol = 0;
            this.btnVincularVisita1.lIndividual = true;
            this.btnVincularVisita1.lLectura = false;
            this.btnVincularVisita1.Location = new System.Drawing.Point(489, 605);
            this.btnVincularVisita1.Name = "btnVincularVisita1";
            this.btnVincularVisita1.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita1.TabIndex = 32;
            this.btnVincularVisita1.Text = "Vincular Visita";
            this.btnVincularVisita1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita1.UseVisualStyleBackColor = true;
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(361, 605);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 33;
            this.btnCargaArhivos.Text = "Carga de Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Enabled = false;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(297, 605);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 63;
            this.btnHabilitarSeguro.Text = "Habilitar Seguros";
            this.btnHabilitarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitarSeguro.UseVisualStyleBackColor = true;
            this.btnHabilitarSeguro.Click += new System.EventHandler(this.btnHabilitarSeguro_Click);
            // 
            // btnTasaN
            // 
            this.btnTasaN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTasaN.Location = new System.Drawing.Point(423, 606);
            this.btnTasaN.Name = "btnTasaN";
            this.btnTasaN.Size = new System.Drawing.Size(60, 50);
            this.btnTasaN.TabIndex = 79;
            this.btnTasaN.Text = "Solicitud Tasa ";
            this.btnTasaN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTasaN.UseVisualStyleBackColor = true;
            this.btnTasaN.Click += new System.EventHandler(this.boton1_Click);
            // 
            // frmEvalAgrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 680);
            this.Controls.Add(this.btnTasaN);
            this.Controls.Add(this.btnGestObs);
            this.Controls.Add(this.btnHabilitarSeguro);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.btnVincularVisita1);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnCopiado);
            this.Controls.Add(this.btnObservacion1);
            this.Controls.Add(this.btnImprimirFlujoCaja);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnChecklist);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tabEval);
            this.Controls.Add(this.btnVincular);
            this.Name = "frmEvalAgrico";
            this.ShowInTaskbar = false;
            this.Text = "Evaluación Agrícola";
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.tabEval, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.btnChecklist, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnImprimirFlujoCaja, 0);
            this.Controls.SetChildIndex(this.btnObservacion1, 0);
            this.Controls.SetChildIndex(this.btnCopiado, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita1, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.btnHabilitarSeguro, 0);
            this.Controls.SetChildIndex(this.btnGestObs, 0);
            this.Controls.SetChildIndex(this.btnTasaN, 0);
            this.tabEval.ResumeLayout(false);
            this.tbpEvCualitati.ResumeLayout(false);
            this.tbpEstFinancie.ResumeLayout(false);
            this.tbpCondCredito.ResumeLayout(false);
            this.grbCultivos.ResumeLayout(false);
            this.grbCultivos.PerformLayout();
            this.plMsjBloqueo.ResumeLayout(false);
            this.tbpPropCredito.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabEval;
        private System.Windows.Forms.TabPage tbpCondCredito;
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
        private System.Windows.Forms.TabPage tbpEstFinancie;
        private System.Windows.Forms.TabPage tbpPropCredito;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnDocumento btnChecklist;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private CRE.ControlBase.ConCondiCredito conCondiCredito;
        private System.Windows.Forms.TabPage tbpEvCualitati;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtModCredito;
        private GEN.ControlesBase.txtBase txtOperacion;
        private CRE.ControlBase.ConEvalCualitReferencias conEvalCualitReferencias;
        private CRE.ControlBase.ConPropuesta conPropuesta;
        private GEN.BotonesBase.btnValidar btnValidar;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnImprimir btnImprimirFlujoCaja;
        private GEN.ControlesBase.txtBase txtTipoCambio;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.Panel plMsjBloqueo;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnObservacion btnObservacion1;
        private GEN.BotonesBase.btnBlanco btnCopiado;
        private GEN.BotonesBase.Boton btnExcepciones;
        private ControlBase.ConEstadosFinancierosAgrico conEstadosFinancieros;
        private GEN.ControlesBase.grbBase grbCultivos;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboVariedadCultivoEval cboVariedadCultivoEval1;
        private GEN.ControlesBase.cboCultivoEval cboCultivoEval1;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita1;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;
        private GEN.BotonesBase.btnBlanco btnGestObs;
        private GEN.BotonesBase.Boton btnTasaN;
    }
}