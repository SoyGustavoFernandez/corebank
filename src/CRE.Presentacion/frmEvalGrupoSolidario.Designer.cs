namespace CRE.Presentacion
{
    partial class frmEvalGrupoSolidario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalGrupoSolidario));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbPropuesta = new GEN.ControlesBase.grbBase(this.components);
            this.txtComConclusiones = new GEN.ControlesBase.txtBase(this.components);
            this.txtComGarantias = new GEN.ControlesBase.txtBase(this.components);
            this.txtComSituacionAct = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusGrupoSol1 = new GEN.ControlesBase.ConBusGrupoSol();
            this.btnExcepciones = new GEN.BotonesBase.Boton();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnImprimirEERR = new GEN.BotonesBase.btnImprimir();
            this.grbBotonesEvaluacion = new GEN.ControlesBase.grbBase(this.components);
            this.btnEvalCualitativa = new GEN.BotonesBase.btnBlanco();
            this.btnEstResultados = new GEN.BotonesBase.btnBlanco();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grbCondicionesCredito = new GEN.ControlesBase.grbBase(this.components);
            this.pnIntegrantes = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgIntegrantes = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmIntegrantes = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.conCondiCreditoGrupoSol = new GEN.ControlesBase.ConCondiCreditoGrupoSol();
            this.btnCancelarCondCredito = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnEditarCondCredito = new GEN.BotonesBase.btnMiniEditar();
            this.btnGrabarCondCredito = new GEN.BotonesBase.btnMiniAcept(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimirEvalCualit = new GEN.BotonesBase.btnImprimir();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.btnObservacion = new GEN.BotonesBase.btnObservacion();
            this.btnVincularVisita1 = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.btnExpediente = new System.Windows.Forms.Button();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbPropuesta.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBotonesEvaluacion.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbCondicionesCredito.SuspendLayout();
            this.pnIntegrantes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(240, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Resumen Situacional del Grupo Solidario";
            // 
            // grbPropuesta
            // 
            this.grbPropuesta.Controls.Add(this.txtComConclusiones);
            this.grbPropuesta.Controls.Add(this.txtComGarantias);
            this.grbPropuesta.Controls.Add(this.txtComSituacionAct);
            this.grbPropuesta.Controls.Add(this.lblBase5);
            this.grbPropuesta.Controls.Add(this.lblBase4);
            this.grbPropuesta.Controls.Add(this.lblBase1);
            this.grbPropuesta.Location = new System.Drawing.Point(630, 89);
            this.grbPropuesta.Name = "grbPropuesta";
            this.grbPropuesta.Size = new System.Drawing.Size(379, 306);
            this.grbPropuesta.TabIndex = 7;
            this.grbPropuesta.TabStop = false;
            this.grbPropuesta.Text = "Propuesta";
            // 
            // txtComConclusiones
            // 
            this.txtComConclusiones.Location = new System.Drawing.Point(9, 220);
            this.txtComConclusiones.MaxLength = 1000;
            this.txtComConclusiones.Multiline = true;
            this.txtComConclusiones.Name = "txtComConclusiones";
            this.txtComConclusiones.Size = new System.Drawing.Size(358, 72);
            this.txtComConclusiones.TabIndex = 62;
            // 
            // txtComGarantias
            // 
            this.txtComGarantias.Location = new System.Drawing.Point(9, 129);
            this.txtComGarantias.MaxLength = 1000;
            this.txtComGarantias.Multiline = true;
            this.txtComGarantias.Name = "txtComGarantias";
            this.txtComGarantias.Size = new System.Drawing.Size(358, 72);
            this.txtComGarantias.TabIndex = 61;
            // 
            // txtComSituacionAct
            // 
            this.txtComSituacionAct.Location = new System.Drawing.Point(9, 32);
            this.txtComSituacionAct.MaxLength = 1000;
            this.txtComSituacionAct.Multiline = true;
            this.txtComSituacionAct.Name = "txtComSituacionAct";
            this.txtComSituacionAct.Size = new System.Drawing.Size(358, 72);
            this.txtComSituacionAct.TabIndex = 60;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 204);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(361, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Riesgos potenciales,conclusiones y otros aspectos relevantes ";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 110);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(156, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Descripción de la garantía";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.conBusGrupoSol1);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(12, 12);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(1023, 94);
            this.grbBase3.TabIndex = 5;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Información del Grupo";
            // 
            // conBusGrupoSol1
            // 
            this.conBusGrupoSol1.Location = new System.Drawing.Point(6, 14);
            this.conBusGrupoSol1.Name = "conBusGrupoSol1";
            this.conBusGrupoSol1.Size = new System.Drawing.Size(613, 74);
            this.conBusGrupoSol1.TabIndex = 32;
            this.conBusGrupoSol1.ClicBuscar += new System.EventHandler(this.conBusGrupoSol1_ClicBuscar);
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Image = global::CRE.Presentacion.Properties.Resources.success;
            this.btnExcepciones.Location = new System.Drawing.Point(801, 625);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 102;
            this.btnExcepciones.Text = "Excepc.";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(870, 625);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 101;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(210, 625);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 100;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(144, 625);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 99;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(78, 625);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 98;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(12, 625);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 97;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnImprimirEERR
            // 
            this.btnImprimirEERR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirEERR.BackgroundImage")));
            this.btnImprimirEERR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirEERR.Location = new System.Drawing.Point(669, 625);
            this.btnImprimirEERR.Name = "btnImprimirEERR";
            this.btnImprimirEERR.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirEERR.TabIndex = 96;
            this.btnImprimirEERR.Text = "Eval. Integrant.";
            this.btnImprimirEERR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirEERR.UseVisualStyleBackColor = true;
            this.btnImprimirEERR.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBotonesEvaluacion
            // 
            this.grbBotonesEvaluacion.Controls.Add(this.btnEvalCualitativa);
            this.grbBotonesEvaluacion.Controls.Add(this.btnEstResultados);
            this.grbBotonesEvaluacion.Location = new System.Drawing.Point(630, 6);
            this.grbBotonesEvaluacion.Name = "grbBotonesEvaluacion";
            this.grbBotonesEvaluacion.Size = new System.Drawing.Size(379, 77);
            this.grbBotonesEvaluacion.TabIndex = 133;
            this.grbBotonesEvaluacion.TabStop = false;
            this.grbBotonesEvaluacion.Text = "Ingresar detalle de:";
            // 
            // btnEvalCualitativa
            // 
            this.btnEvalCualitativa.BackColor = System.Drawing.SystemColors.Control;
            this.btnEvalCualitativa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEvalCualitativa.Location = new System.Drawing.Point(6, 19);
            this.btnEvalCualitativa.Name = "btnEvalCualitativa";
            this.btnEvalCualitativa.Size = new System.Drawing.Size(60, 50);
            this.btnEvalCualitativa.TabIndex = 131;
            this.btnEvalCualitativa.Text = "Eval. Cuali.";
            this.btnEvalCualitativa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEvalCualitativa.UseVisualStyleBackColor = false;
            this.btnEvalCualitativa.Click += new System.EventHandler(this.btnEvalCualitativa_Click);
            // 
            // btnEstResultados
            // 
            this.btnEstResultados.BackColor = System.Drawing.SystemColors.Control;
            this.btnEstResultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEstResultados.Location = new System.Drawing.Point(72, 19);
            this.btnEstResultados.Name = "btnEstResultados";
            this.btnEstResultados.Size = new System.Drawing.Size(60, 50);
            this.btnEstResultados.TabIndex = 130;
            this.btnEstResultados.Text = "Eval. Integrant.";
            this.btnEstResultados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEstResultados.UseVisualStyleBackColor = false;
            this.btnEstResultados.Click += new System.EventHandler(this.btnEstResultados_Click);
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Location = new System.Drawing.Point(12, 115);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(1023, 504);
            this.tbcBase1.TabIndex = 134;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbBotonesEvaluacion);
            this.tabPage1.Controls.Add(this.grbCondicionesCredito);
            this.tabPage1.Controls.Add(this.btnCancelarCondCredito);
            this.tabPage1.Controls.Add(this.btnEditarCondCredito);
            this.tabPage1.Controls.Add(this.grbPropuesta);
            this.tabPage1.Controls.Add(this.btnGrabarCondCredito);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1015, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grupo Solidario";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grbCondicionesCredito
            // 
            this.grbCondicionesCredito.Controls.Add(this.pnIntegrantes);
            this.grbCondicionesCredito.Controls.Add(this.conCondiCreditoGrupoSol);
            this.grbCondicionesCredito.Location = new System.Drawing.Point(3, 36);
            this.grbCondicionesCredito.Name = "grbCondicionesCredito";
            this.grbCondicionesCredito.Size = new System.Drawing.Size(620, 438);
            this.grbCondicionesCredito.TabIndex = 63;
            this.grbCondicionesCredito.TabStop = false;
            this.grbCondicionesCredito.Text = "Condiciones del Crédito";
            // 
            // pnIntegrantes
            // 
            this.pnIntegrantes.Controls.Add(this.panel2);
            this.pnIntegrantes.Enabled = false;
            this.pnIntegrantes.Location = new System.Drawing.Point(4, 210);
            this.pnIntegrantes.Name = "pnIntegrantes";
            this.pnIntegrantes.Size = new System.Drawing.Size(610, 225);
            this.pnIntegrantes.TabIndex = 119;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 223);
            this.panel2.TabIndex = 78;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel4);
            this.panel12.Controls.Add(this.panel5);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(608, 221);
            this.panel12.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgIntegrantes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(608, 197);
            this.panel4.TabIndex = 25;
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgIntegrantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIntegrantes.Location = new System.Drawing.Point(0, 0);
            this.dtgIntegrantes.MultiSelect = false;
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.ReadOnly = true;
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(608, 197);
            this.dtgIntegrantes.TabIndex = 0;
            this.dtgIntegrantes.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.menuStrip1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(608, 24);
            this.panel5.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIntegrantes});
            this.menuStrip1.Location = new System.Drawing.Point(182, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmIntegrantes
            // 
            this.tsmIntegrantes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmIntegrantes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmIntegrantes.Image = global::CRE.Presentacion.Properties.Resources.btnSmallEdit;
            this.tsmIntegrantes.Name = "tsmIntegrantes";
            this.tsmIntegrantes.Size = new System.Drawing.Size(28, 20);
            this.tsmIntegrantes.Text = "toolStripMenuItem1";
            this.tsmIntegrantes.Click += new System.EventHandler(this.tsmIntegrantes_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Integrantes del Grupo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // conCondiCreditoGrupoSol
            // 
            this.conCondiCreditoGrupoSol.Enabled = false;
            this.conCondiCreditoGrupoSol.Location = new System.Drawing.Point(6, 19);
            this.conCondiCreditoGrupoSol.MonedaEnabled = false;
            this.conCondiCreditoGrupoSol.Name = "conCondiCreditoGrupoSol";
            this.conCondiCreditoGrupoSol.NivelesProductoEnabled = false;
            this.conCondiCreditoGrupoSol.PeriodoEnabled = true;
            this.conCondiCreditoGrupoSol.Size = new System.Drawing.Size(595, 178);
            this.conCondiCreditoGrupoSol.TabIndex = 119;
            this.conCondiCreditoGrupoSol.ChangeCondiCredito += new System.EventHandler(this.conCondiCreditoGrupoSol_ChangeCondiCredito);
            // 
            // btnCancelarCondCredito
            // 
            this.btnCancelarCondCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarCondCredito.BackgroundImage")));
            this.btnCancelarCondCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarCondCredito.Enabled = false;
            this.btnCancelarCondCredito.Location = new System.Drawing.Point(587, 6);
            this.btnCancelarCondCredito.Name = "btnCancelarCondCredito";
            this.btnCancelarCondCredito.Size = new System.Drawing.Size(36, 28);
            this.btnCancelarCondCredito.TabIndex = 118;
            this.btnCancelarCondCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarCondCredito.UseVisualStyleBackColor = true;
            this.btnCancelarCondCredito.Visible = false;
            this.btnCancelarCondCredito.Click += new System.EventHandler(this.btnCancelarCondCredito_Click);
            // 
            // btnEditarCondCredito
            // 
            this.btnEditarCondCredito.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarCondCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarCondCredito.BackgroundImage")));
            this.btnEditarCondCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarCondCredito.Enabled = false;
            this.btnEditarCondCredito.Location = new System.Drawing.Point(487, 6);
            this.btnEditarCondCredito.Name = "btnEditarCondCredito";
            this.btnEditarCondCredito.Size = new System.Drawing.Size(36, 28);
            this.btnEditarCondCredito.TabIndex = 116;
            this.btnEditarCondCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarCondCredito.UseVisualStyleBackColor = false;
            this.btnEditarCondCredito.Click += new System.EventHandler(this.btnEditarCondCredito_Click);
            // 
            // btnGrabarCondCredito
            // 
            this.btnGrabarCondCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarCondCredito.BackgroundImage")));
            this.btnGrabarCondCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarCondCredito.Enabled = false;
            this.btnGrabarCondCredito.Location = new System.Drawing.Point(529, 6);
            this.btnGrabarCondCredito.Name = "btnGrabarCondCredito";
            this.btnGrabarCondCredito.Size = new System.Drawing.Size(36, 28);
            this.btnGrabarCondCredito.TabIndex = 117;
            this.btnGrabarCondCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarCondCredito.UseVisualStyleBackColor = true;
            this.btnGrabarCondCredito.Click += new System.EventHandler(this.btnGrabarCondCredito_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(975, 625);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 135;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimirEvalCualit
            // 
            this.btnImprimirEvalCualit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirEvalCualit.BackgroundImage")));
            this.btnImprimirEvalCualit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirEvalCualit.Location = new System.Drawing.Point(603, 625);
            this.btnImprimirEvalCualit.Name = "btnImprimirEvalCualit";
            this.btnImprimirEvalCualit.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirEvalCualit.TabIndex = 136;
            this.btnImprimirEvalCualit.Text = "Imprimir Eval. Cualit.";
            this.btnImprimirEvalCualit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirEvalCualit.UseVisualStyleBackColor = true;
            this.btnImprimirEvalCualit.Click += new System.EventHandler(this.btnImprimirEvalCualit_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Enabled = false;
            this.btnValidar.Location = new System.Drawing.Point(503, 625);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 137;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnObservacion
            // 
            this.btnObservacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservacion.BackgroundImage")));
            this.btnObservacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservacion.Location = new System.Drawing.Point(437, 625);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(60, 50);
            this.btnObservacion.TabIndex = 138;
            this.btnObservacion.Text = "&Obs.";
            this.btnObservacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // btnVincularVisita1
            // 
            this.btnVincularVisita1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincularVisita1.BackgroundImage")));
            this.btnVincularVisita1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularVisita1.idCli = 0;
            this.btnVincularVisita1.idGrupoSolidario = 0;
            this.btnVincularVisita1.idSolicitud = 0;
            this.btnVincularVisita1.idSolicitudGrupoSol = 0;
            this.btnVincularVisita1.lIndividual = false;
            this.btnVincularVisita1.lLectura = false;
            this.btnVincularVisita1.Location = new System.Drawing.Point(293, 625);
            this.btnVincularVisita1.Name = "btnVincularVisita1";
            this.btnVincularVisita1.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita1.TabIndex = 139;
            this.btnVincularVisita1.Text = "Vincular Visita";
            this.btnVincularVisita1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita1.UseVisualStyleBackColor = true;
            // 
            // btnExpediente
            // 
            this.btnExpediente.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnTrasladar;
            this.btnExpediente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExpediente.Location = new System.Drawing.Point(359, 625);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new System.Drawing.Size(60, 50);
            this.btnExpediente.TabIndex = 140;
            this.btnExpediente.Text = "Expdte";
            this.btnExpediente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpediente.UseVisualStyleBackColor = true;
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(735, 625);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 141;
            this.btnImprimir1.Text = "Expdte";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmEvalGrupoSolidario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1047, 702);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnExpediente);
            this.Controls.Add(this.btnVincularVisita1);
            this.Controls.Add(this.btnObservacion);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnImprimirEvalCualit);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnImprimirEERR);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmEvalGrupoSolidario";
            this.Text = "Grupo Solidario - Evaluación";
            this.Shown += new System.EventHandler(this.frmEvalGrupoSolidario_Shown);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimirEERR, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimirEvalCualit, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.btnObservacion, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita1, 0);
            this.Controls.SetChildIndex(this.btnExpediente, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.grbPropuesta.ResumeLayout(false);
            this.grbPropuesta.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBotonesEvaluacion.ResumeLayout(false);
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbCondicionesCredito.ResumeLayout(false);
            this.pnIntegrantes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbPropuesta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private GEN.ControlesBase.txtBase txtComSituacionAct;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.Boton btnExcepciones;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnImprimir btnImprimirEERR;
        private GEN.ControlesBase.grbBase grbBotonesEvaluacion;
        private GEN.BotonesBase.btnBlanco btnEvalCualitativa;
        private GEN.BotonesBase.btnBlanco btnEstResultados;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.grbBase grbCondicionesCredito;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelarCondCredito;
        private GEN.BotonesBase.btnMiniEditar btnEditarCondCredito;
        private GEN.BotonesBase.btnMiniAcept btnGrabarCondCredito;
        private System.Windows.Forms.Panel pnIntegrantes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgIntegrantes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.txtBase txtComConclusiones;
        private GEN.ControlesBase.txtBase txtComGarantias;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.ConCondiCreditoGrupoSol conCondiCreditoGrupoSol;
        private GEN.BotonesBase.btnImprimir btnImprimirEvalCualit;
        private System.Windows.Forms.ToolStripMenuItem tsmIntegrantes;
        private GEN.BotonesBase.btnValidar btnValidar;
        private GEN.BotonesBase.btnObservacion btnObservacion;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol1;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita1;
        private System.Windows.Forms.Button btnExpediente;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}