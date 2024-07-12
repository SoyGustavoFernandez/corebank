namespace PRE.Presentacion
{
    partial class frmPartidaReasignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartidaReasignacion));
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtJustificacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboLimAplicaSaldoOrigen = new GEN.ControlesBase.cboLimAplicaSaldo(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblPlanificacion = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal1 = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgPartidasReasig = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboNivelAprob = new GEN.ControlesBase.cboNivelAprobPartidaPres(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtMovimientoOrigen = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtDisponibleNeto = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnBuscaPartidaOrigen = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtCodNombrePartidaOrigen = new GEN.ControlesBase.txtBase(this.components);
            this.dtgPartidaOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.nudPorcentajeOrigen = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtMovimientoDestino = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgPartidaDestino = new GEN.ControlesBase.dtgBase(this.components);
            this.btnBuscaPartidaDestino = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtCodNombrePartidaDestino = new GEN.ControlesBase.txtBase(this.components);
            this.conBusUsuSolicitante = new GEN.ControlesBase.ConBusCol();
            this.lblSoliciAprobada = new System.Windows.Forms.Label();
            this.grbProcesar = new GEN.ControlesBase.grbBase(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasReasig)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeOrigen)).BeginInit();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaDestino)).BeginInit();
            this.grbProcesar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(85, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(107, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 28;
            this.lblBase3.Text = "Código:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtJustificacion);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtCodigo);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(464, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(388, 130);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle Solicitud";
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Enabled = false;
            this.txtJustificacion.Location = new System.Drawing.Point(85, 38);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(296, 86);
            this.txtJustificacion.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 28;
            this.lblBase1.Text = "Justificación:";
            // 
            // cboLimAplicaSaldoOrigen
            // 
            this.cboLimAplicaSaldoOrigen.Enabled = false;
            this.cboLimAplicaSaldoOrigen.FormattingEnabled = true;
            this.cboLimAplicaSaldoOrigen.Location = new System.Drawing.Point(76, 134);
            this.cboLimAplicaSaldoOrigen.Name = "cboLimAplicaSaldoOrigen";
            this.cboLimAplicaSaldoOrigen.Size = new System.Drawing.Size(210, 21);
            this.cboLimAplicaSaldoOrigen.TabIndex = 34;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 137);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(70, 13);
            this.lblBase2.TabIndex = 28;
            this.lblBase2.Text = "Lim. saldo:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(658, 566);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = false;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(592, 566);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 7;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = false;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(790, 566);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(724, 566);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = false;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblPlanificacion);
            this.grbBase2.Controls.Add(this.cboPeriodoPresupuestal1);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(12, 2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(316, 38);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            // 
            // lblPlanificacion
            // 
            this.lblPlanificacion.AutoSize = true;
            this.lblPlanificacion.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanificacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPlanificacion.Location = new System.Drawing.Point(194, 16);
            this.lblPlanificacion.Name = "lblPlanificacion";
            this.lblPlanificacion.Size = new System.Drawing.Size(91, 14);
            this.lblPlanificacion.TabIndex = 3;
            this.lblPlanificacion.Text = "Planificación";
            // 
            // cboPeriodoPresupuestal1
            // 
            this.cboPeriodoPresupuestal1.FormattingEnabled = true;
            this.cboPeriodoPresupuestal1.Location = new System.Drawing.Point(67, 14);
            this.cboPeriodoPresupuestal1.Name = "cboPeriodoPresupuestal1";
            this.cboPeriodoPresupuestal1.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoPresupuestal1.TabIndex = 0;
            this.cboPeriodoPresupuestal1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 17);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(55, 13);
            this.lblBase4.TabIndex = 1;
            this.lblBase4.Text = "Periodo:";
            // 
            // dtgPartidasReasig
            // 
            this.dtgPartidasReasig.AllowUserToAddRows = false;
            this.dtgPartidasReasig.AllowUserToDeleteRows = false;
            this.dtgPartidasReasig.AllowUserToResizeColumns = false;
            this.dtgPartidasReasig.AllowUserToResizeRows = false;
            this.dtgPartidasReasig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPartidasReasig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidasReasig.Location = new System.Drawing.Point(12, 46);
            this.dtgPartidasReasig.MultiSelect = false;
            this.dtgPartidasReasig.Name = "dtgPartidasReasig";
            this.dtgPartidasReasig.ReadOnly = true;
            this.dtgPartidasReasig.RowHeadersVisible = false;
            this.dtgPartidasReasig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPartidasReasig.Size = new System.Drawing.Size(446, 180);
            this.dtgPartidasReasig.TabIndex = 1;
            this.dtgPartidasReasig.SelectionChanged += new System.EventHandler(this.dtgPartidasReasig_SelectionChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboNivelAprob);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.txtMovimientoOrigen);
            this.grbBase3.Controls.Add(this.txtDisponibleNeto);
            this.grbBase3.Controls.Add(this.btnBuscaPartidaOrigen);
            this.grbBase3.Controls.Add(this.txtCodNombrePartidaOrigen);
            this.grbBase3.Controls.Add(this.cboLimAplicaSaldoOrigen);
            this.grbBase3.Controls.Add(this.dtgPartidaOrigen);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.nudPorcentajeOrigen);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Location = new System.Drawing.Point(3, 229);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(849, 160);
            this.grbBase3.TabIndex = 4;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Partida origen";
            // 
            // cboNivelAprob
            // 
            this.cboNivelAprob.Enabled = false;
            this.cboNivelAprob.FormattingEnabled = true;
            this.cboNivelAprob.Location = new System.Drawing.Point(473, 14);
            this.cboNivelAprob.Name = "cboNivelAprob";
            this.cboNivelAprob.Size = new System.Drawing.Size(188, 21);
            this.cboNivelAprob.TabIndex = 49;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(654, 137);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(77, 13);
            this.lblBase11.TabIndex = 48;
            this.lblBase11.Text = "Movimiento:";
            // 
            // txtMovimientoOrigen
            // 
            this.txtMovimientoOrigen.BackColor = System.Drawing.Color.White;
            this.txtMovimientoOrigen.Enabled = false;
            this.txtMovimientoOrigen.FormatoDecimal = false;
            this.txtMovimientoOrigen.Location = new System.Drawing.Point(737, 133);
            this.txtMovimientoOrigen.Name = "txtMovimientoOrigen";
            this.txtMovimientoOrigen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMovimientoOrigen.nNumDecimales = 4;
            this.txtMovimientoOrigen.nvalor = 0D;
            this.txtMovimientoOrigen.ReadOnly = true;
            this.txtMovimientoOrigen.Size = new System.Drawing.Size(110, 20);
            this.txtMovimientoOrigen.TabIndex = 47;
            // 
            // txtDisponibleNeto
            // 
            this.txtDisponibleNeto.BackColor = System.Drawing.Color.White;
            this.txtDisponibleNeto.Enabled = false;
            this.txtDisponibleNeto.FormatoDecimal = false;
            this.txtDisponibleNeto.Location = new System.Drawing.Point(533, 134);
            this.txtDisponibleNeto.Name = "txtDisponibleNeto";
            this.txtDisponibleNeto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDisponibleNeto.nNumDecimales = 4;
            this.txtDisponibleNeto.nvalor = 0D;
            this.txtDisponibleNeto.ReadOnly = true;
            this.txtDisponibleNeto.Size = new System.Drawing.Size(110, 20);
            this.txtDisponibleNeto.TabIndex = 46;
            // 
            // btnBuscaPartidaOrigen
            // 
            this.btnBuscaPartidaOrigen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaPartidaOrigen.BackgroundImage")));
            this.btnBuscaPartidaOrigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscaPartidaOrigen.Location = new System.Drawing.Point(299, 11);
            this.btnBuscaPartidaOrigen.Name = "btnBuscaPartidaOrigen";
            this.btnBuscaPartidaOrigen.Size = new System.Drawing.Size(36, 28);
            this.btnBuscaPartidaOrigen.TabIndex = 0;
            this.btnBuscaPartidaOrigen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscaPartidaOrigen.UseVisualStyleBackColor = true;
            this.btnBuscaPartidaOrigen.Click += new System.EventHandler(this.btnBuscaPartidaOrigen_Click);
            // 
            // txtCodNombrePartidaOrigen
            // 
            this.txtCodNombrePartidaOrigen.Enabled = false;
            this.txtCodNombrePartidaOrigen.Location = new System.Drawing.Point(6, 15);
            this.txtCodNombrePartidaOrigen.Name = "txtCodNombrePartidaOrigen";
            this.txtCodNombrePartidaOrigen.Size = new System.Drawing.Size(287, 20);
            this.txtCodNombrePartidaOrigen.TabIndex = 1;
            // 
            // dtgPartidaOrigen
            // 
            this.dtgPartidaOrigen.AllowUserToAddRows = false;
            this.dtgPartidaOrigen.AllowUserToDeleteRows = false;
            this.dtgPartidaOrigen.AllowUserToResizeColumns = false;
            this.dtgPartidaOrigen.AllowUserToResizeRows = false;
            this.dtgPartidaOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPartidaOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidaOrigen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgPartidaOrigen.Location = new System.Drawing.Point(2, 42);
            this.dtgPartidaOrigen.MultiSelect = false;
            this.dtgPartidaOrigen.Name = "dtgPartidaOrigen";
            this.dtgPartidaOrigen.ReadOnly = true;
            this.dtgPartidaOrigen.RowHeadersVisible = false;
            this.dtgPartidaOrigen.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dtgPartidaOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPartidaOrigen.Size = new System.Drawing.Size(845, 88);
            this.dtgPartidaOrigen.TabIndex = 43;
            this.dtgPartidaOrigen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPartidaOrigen_CellEndEdit);
            this.dtgPartidaOrigen.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgPartidaOrigen_CellValidating);
            this.dtgPartidaOrigen.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPartidaOrigen_EditingControlShowing);
            // 
            // nudPorcentajeOrigen
            // 
            this.nudPorcentajeOrigen.Enabled = false;
            this.nudPorcentajeOrigen.Location = new System.Drawing.Point(362, 134);
            this.nudPorcentajeOrigen.Name = "nudPorcentajeOrigen";
            this.nudPorcentajeOrigen.Size = new System.Drawing.Size(54, 20);
            this.nudPorcentajeOrigen.TabIndex = 33;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(341, 18);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(126, 13);
            this.lblBase6.TabIndex = 28;
            this.lblBase6.Text = "Nivel de Aprobación:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(422, 137);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(105, 13);
            this.lblBase10.TabIndex = 28;
            this.lblBase10.Text = "Saldo disponible:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(299, 137);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 32;
            this.lblBase7.Text = "% Asig.:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblBase12);
            this.grbBase4.Controls.Add(this.txtMovimientoDestino);
            this.grbBase4.Controls.Add(this.dtgPartidaDestino);
            this.grbBase4.Controls.Add(this.btnBuscaPartidaDestino);
            this.grbBase4.Controls.Add(this.txtCodNombrePartidaDestino);
            this.grbBase4.Location = new System.Drawing.Point(3, 394);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(849, 160);
            this.grbBase4.TabIndex = 5;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Partida destino";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(654, 137);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(77, 13);
            this.lblBase12.TabIndex = 48;
            this.lblBase12.Text = "Movimiento:";
            // 
            // txtMovimientoDestino
            // 
            this.txtMovimientoDestino.BackColor = System.Drawing.Color.White;
            this.txtMovimientoDestino.Enabled = false;
            this.txtMovimientoDestino.FormatoDecimal = false;
            this.txtMovimientoDestino.Location = new System.Drawing.Point(737, 134);
            this.txtMovimientoDestino.Name = "txtMovimientoDestino";
            this.txtMovimientoDestino.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMovimientoDestino.nNumDecimales = 4;
            this.txtMovimientoDestino.nvalor = 0D;
            this.txtMovimientoDestino.ReadOnly = true;
            this.txtMovimientoDestino.Size = new System.Drawing.Size(110, 20);
            this.txtMovimientoDestino.TabIndex = 47;
            // 
            // dtgPartidaDestino
            // 
            this.dtgPartidaDestino.AllowDrop = true;
            this.dtgPartidaDestino.AllowUserToAddRows = false;
            this.dtgPartidaDestino.AllowUserToDeleteRows = false;
            this.dtgPartidaDestino.AllowUserToResizeColumns = false;
            this.dtgPartidaDestino.AllowUserToResizeRows = false;
            this.dtgPartidaDestino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPartidaDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidaDestino.Location = new System.Drawing.Point(2, 42);
            this.dtgPartidaDestino.MultiSelect = false;
            this.dtgPartidaDestino.Name = "dtgPartidaDestino";
            this.dtgPartidaDestino.ReadOnly = true;
            this.dtgPartidaDestino.RowHeadersVisible = false;
            this.dtgPartidaDestino.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dtgPartidaDestino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPartidaDestino.Size = new System.Drawing.Size(845, 88);
            this.dtgPartidaDestino.TabIndex = 53;
            this.dtgPartidaDestino.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPartidaDestino_CellEndEdit);
            this.dtgPartidaDestino.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgPartidaDestino_CellValidating);
            this.dtgPartidaDestino.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPartidaDestino_EditingControlShowing);
            // 
            // btnBuscaPartidaDestino
            // 
            this.btnBuscaPartidaDestino.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaPartidaDestino.BackgroundImage")));
            this.btnBuscaPartidaDestino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscaPartidaDestino.Location = new System.Drawing.Point(299, 11);
            this.btnBuscaPartidaDestino.Name = "btnBuscaPartidaDestino";
            this.btnBuscaPartidaDestino.Size = new System.Drawing.Size(36, 28);
            this.btnBuscaPartidaDestino.TabIndex = 0;
            this.btnBuscaPartidaDestino.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscaPartidaDestino.UseVisualStyleBackColor = true;
            this.btnBuscaPartidaDestino.Click += new System.EventHandler(this.btnBuscaPartidaDestino_Click);
            // 
            // txtCodNombrePartidaDestino
            // 
            this.txtCodNombrePartidaDestino.Enabled = false;
            this.txtCodNombrePartidaDestino.Location = new System.Drawing.Point(6, 14);
            this.txtCodNombrePartidaDestino.Name = "txtCodNombrePartidaDestino";
            this.txtCodNombrePartidaDestino.Size = new System.Drawing.Size(287, 20);
            this.txtCodNombrePartidaDestino.TabIndex = 1;
            // 
            // conBusUsuSolicitante
            // 
            this.conBusUsuSolicitante.Location = new System.Drawing.Point(464, 142);
            this.conBusUsuSolicitante.Name = "conBusUsuSolicitante";
            this.conBusUsuSolicitante.Size = new System.Drawing.Size(388, 86);
            this.conBusUsuSolicitante.TabIndex = 3;
            // 
            // lblSoliciAprobada
            // 
            this.lblSoliciAprobada.AutoSize = true;
            this.lblSoliciAprobada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoliciAprobada.ForeColor = System.Drawing.Color.Navy;
            this.lblSoliciAprobada.Location = new System.Drawing.Point(6, 16);
            this.lblSoliciAprobada.Name = "lblSoliciAprobada";
            this.lblSoliciAprobada.Size = new System.Drawing.Size(136, 13);
            this.lblSoliciAprobada.TabIndex = 50;
            this.lblSoliciAprobada.Text = "Solicitud APROBADA";
            // 
            // grbProcesar
            // 
            this.grbProcesar.Controls.Add(this.label2);
            this.grbProcesar.Controls.Add(this.btnProcesar1);
            this.grbProcesar.Controls.Add(this.lblSoliciAprobada);
            this.grbProcesar.Location = new System.Drawing.Point(5, 554);
            this.grbProcesar.Name = "grbProcesar";
            this.grbProcesar.Size = new System.Drawing.Size(353, 63);
            this.grbProcesar.TabIndex = 6;
            this.grbProcesar.TabStop = false;
            this.grbProcesar.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "para ejecutar la reasignación, click en Procesar";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(287, 10);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 0;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // frmPartidaReasignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 641);
            this.Controls.Add(this.grbProcesar);
            this.Controls.Add(this.conBusUsuSolicitante);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.dtgPartidasReasig);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmPartidaReasignacion";
            this.Text = "Partidas de reasignación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPartidaReasignacion_FormClosing);
            this.Load += new System.EventHandler(this.frmPartidaReasignacion_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.dtgPartidasReasig, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.conBusUsuSolicitante, 0);
            this.Controls.SetChildIndex(this.grbProcesar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasReasig)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeOrigen)).EndInit();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaDestino)).EndInit();
            this.grbProcesar.ResumeLayout(false);
            this.grbProcesar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtJustificacion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.Label lblPlanificacion;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgPartidasReasig;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.dtgBase dtgPartidaOrigen;
        private GEN.ControlesBase.cboLimAplicaSaldo cboLimAplicaSaldoOrigen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.nudBase nudPorcentajeOrigen;
        private GEN.ControlesBase.txtNumRea txtDisponibleNeto;
        private GEN.BotonesBase.btnMiniBusq btnBuscaPartidaOrigen;
        private GEN.ControlesBase.txtBase txtCodNombrePartidaOrigen;
        private GEN.ControlesBase.dtgBase dtgPartidaDestino;
        private GEN.BotonesBase.btnMiniBusq btnBuscaPartidaDestino;
        private GEN.ControlesBase.txtBase txtCodNombrePartidaDestino;
        private GEN.ControlesBase.txtNumRea txtMovimientoOrigen;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtNumRea txtMovimientoDestino;
        private GEN.ControlesBase.ConBusCol conBusUsuSolicitante;
        private GEN.ControlesBase.cboNivelAprobPartidaPres cboNivelAprob;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.Label lblSoliciAprobada;
        private GEN.ControlesBase.grbBase grbProcesar;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
    }
}