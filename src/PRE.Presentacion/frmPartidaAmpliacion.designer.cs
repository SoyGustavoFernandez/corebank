namespace PRE.Presentacion
{
    partial class frmPartidaAmpliacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartidaAmpliacion));
            this.lblNombreMes = new System.Windows.Forms.Label();
            this.lblMesActual = new GEN.ControlesBase.lblBase();
            this.txtNombrePartida = new GEN.ControlesBase.txtBase(this.components);
            this.dtgPartidaPres = new GEN.ControlesBase.dtgBase(this.components);
            this.cboLimAplicaSaldo = new GEN.ControlesBase.cboLimAplicaSaldo(this.components);
            this.btnBuscaPartida = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblLimSaldo = new GEN.ControlesBase.lblBase();
            this.lblMovimiento = new GEN.ControlesBase.lblBase();
            this.txtMovimiento = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.dtgPartidasAmpl = new GEN.ControlesBase.dtgBase(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.conBusUsuSolicitante = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtFundamento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboNivelAprobacion = new GEN.ControlesBase.cboNivelAprobPartidaPres(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbProcesar = new GEN.ControlesBase.grbBase(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblSoliciAprobada = new System.Windows.Forms.Label();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaPres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasAmpl)).BeginInit();
            this.conBusUsuSolicitante.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbProcesar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombreMes
            // 
            this.lblNombreMes.AutoSize = true;
            this.lblNombreMes.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMes.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNombreMes.Location = new System.Drawing.Point(681, 21);
            this.lblNombreMes.Name = "lblNombreMes";
            this.lblNombreMes.Size = new System.Drawing.Size(0, 14);
            this.lblNombreMes.TabIndex = 4;
            // 
            // lblMesActual
            // 
            this.lblMesActual.AutoSize = true;
            this.lblMesActual.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMesActual.ForeColor = System.Drawing.Color.Navy;
            this.lblMesActual.Location = new System.Drawing.Point(613, 22);
            this.lblMesActual.Name = "lblMesActual";
            this.lblMesActual.Size = new System.Drawing.Size(73, 13);
            this.lblMesActual.TabIndex = 3;
            this.lblMesActual.Text = "Mes Actual:";
            // 
            // txtNombrePartida
            // 
            this.txtNombrePartida.Enabled = false;
            this.txtNombrePartida.Location = new System.Drawing.Point(68, 292);
            this.txtNombrePartida.Name = "txtNombrePartida";
            this.txtNombrePartida.ReadOnly = true;
            this.txtNombrePartida.Size = new System.Drawing.Size(214, 20);
            this.txtNombrePartida.TabIndex = 8;
            // 
            // dtgPartidaPres
            // 
            this.dtgPartidaPres.AllowUserToAddRows = false;
            this.dtgPartidaPres.AllowUserToDeleteRows = false;
            this.dtgPartidaPres.AllowUserToResizeColumns = false;
            this.dtgPartidaPres.AllowUserToResizeRows = false;
            this.dtgPartidaPres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPartidaPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidaPres.Location = new System.Drawing.Point(14, 318);
            this.dtgPartidaPres.MultiSelect = false;
            this.dtgPartidaPres.Name = "dtgPartidaPres";
            this.dtgPartidaPres.ReadOnly = true;
            this.dtgPartidaPres.RowHeadersVisible = false;
            this.dtgPartidaPres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPartidaPres.Size = new System.Drawing.Size(812, 90);
            this.dtgPartidaPres.TabIndex = 12;
            this.dtgPartidaPres.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPartidaPres_CellEndEdit);
            this.dtgPartidaPres.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgPartidaPres_CellValidating);
            this.dtgPartidaPres.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPartidaPres_EditingControlShowing);
            // 
            // cboLimAplicaSaldo
            // 
            this.cboLimAplicaSaldo.Enabled = false;
            this.cboLimAplicaSaldo.FormattingEnabled = true;
            this.cboLimAplicaSaldo.Location = new System.Drawing.Point(87, 414);
            this.cboLimAplicaSaldo.Name = "cboLimAplicaSaldo";
            this.cboLimAplicaSaldo.Size = new System.Drawing.Size(240, 21);
            this.cboLimAplicaSaldo.TabIndex = 14;
            // 
            // btnBuscaPartida
            // 
            this.btnBuscaPartida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaPartida.BackgroundImage")));
            this.btnBuscaPartida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscaPartida.Location = new System.Drawing.Point(288, 288);
            this.btnBuscaPartida.Name = "btnBuscaPartida";
            this.btnBuscaPartida.Size = new System.Drawing.Size(36, 28);
            this.btnBuscaPartida.TabIndex = 9;
            this.btnBuscaPartida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscaPartida.UseVisualStyleBackColor = true;
            this.btnBuscaPartida.Click += new System.EventHandler(this.btnBuscaPartida_Click);
            // 
            // lblLimSaldo
            // 
            this.lblLimSaldo.AutoSize = true;
            this.lblLimSaldo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblLimSaldo.ForeColor = System.Drawing.Color.Navy;
            this.lblLimSaldo.Location = new System.Drawing.Point(11, 418);
            this.lblLimSaldo.Name = "lblLimSaldo";
            this.lblLimSaldo.Size = new System.Drawing.Size(70, 13);
            this.lblLimSaldo.TabIndex = 13;
            this.lblLimSaldo.Text = "Lim. saldo:";
            // 
            // lblMovimiento
            // 
            this.lblMovimiento.AutoSize = true;
            this.lblMovimiento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMovimiento.ForeColor = System.Drawing.Color.Navy;
            this.lblMovimiento.Location = new System.Drawing.Point(621, 418);
            this.lblMovimiento.Name = "lblMovimiento";
            this.lblMovimiento.Size = new System.Drawing.Size(77, 13);
            this.lblMovimiento.TabIndex = 15;
            this.lblMovimiento.Text = "Movimiento:";
            // 
            // txtMovimiento
            // 
            this.txtMovimiento.BackColor = System.Drawing.Color.White;
            this.txtMovimiento.Enabled = false;
            this.txtMovimiento.FormatoDecimal = false;
            this.txtMovimiento.Location = new System.Drawing.Point(704, 414);
            this.txtMovimiento.Name = "txtMovimiento";
            this.txtMovimiento.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMovimiento.nNumDecimales = 4;
            this.txtMovimiento.nvalor = 0D;
            this.txtMovimiento.ReadOnly = true;
            this.txtMovimiento.Size = new System.Drawing.Size(122, 20);
            this.txtMovimiento.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(634, 444);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(568, 444);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(766, 444);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(700, 444);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 20;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dtgPartidasAmpl
            // 
            this.dtgPartidasAmpl.AllowUserToAddRows = false;
            this.dtgPartidasAmpl.AllowUserToDeleteRows = false;
            this.dtgPartidasAmpl.AllowUserToResizeColumns = false;
            this.dtgPartidasAmpl.AllowUserToResizeRows = false;
            this.dtgPartidasAmpl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPartidasAmpl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidasAmpl.Location = new System.Drawing.Point(14, 61);
            this.dtgPartidasAmpl.MultiSelect = false;
            this.dtgPartidasAmpl.Name = "dtgPartidasAmpl";
            this.dtgPartidasAmpl.ReadOnly = true;
            this.dtgPartidasAmpl.RowHeadersVisible = false;
            this.dtgPartidasAmpl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPartidasAmpl.Size = new System.Drawing.Size(369, 214);
            this.dtgPartidasAmpl.TabIndex = 5;
            this.dtgPartidasAmpl.SelectionChanged += new System.EventHandler(this.dtgPartidasAmpl_SelectionChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Gray;
            this.lblEstado.Location = new System.Drawing.Point(202, 21);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 14);
            this.lblEstado.TabIndex = 2;
            // 
            // cboPeriodoPresupuestal
            // 
            this.cboPeriodoPresupuestal.FormattingEnabled = true;
            this.cboPeriodoPresupuestal.Location = new System.Drawing.Point(75, 18);
            this.cboPeriodoPresupuestal.Name = "cboPeriodoPresupuestal";
            this.cboPeriodoPresupuestal.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoPresupuestal.TabIndex = 1;
            this.cboPeriodoPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(55, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Periodo:";
            // 
            // conBusUsuSolicitante
            // 
            this.conBusUsuSolicitante.Controls.Add(this.grbBase1);
            this.conBusUsuSolicitante.Location = new System.Drawing.Point(389, 189);
            this.conBusUsuSolicitante.Name = "conBusUsuSolicitante";
            this.conBusUsuSolicitante.Size = new System.Drawing.Size(388, 86);
            this.conBusUsuSolicitante.TabIndex = 61;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtFundamento);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtCodigo);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Location = new System.Drawing.Point(389, 61);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(398, 125);
            this.grbBase2.TabIndex = 6;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Detalle Solicitud";
            // 
            // txtFundamento
            // 
            this.txtFundamento.Enabled = false;
            this.txtFundamento.Location = new System.Drawing.Point(85, 38);
            this.txtFundamento.Multiline = true;
            this.txtFundamento.Name = "txtFundamento";
            this.txtFundamento.Size = new System.Drawing.Size(303, 87);
            this.txtFundamento.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Justificación:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(85, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(107, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Código:";
            // 
            // cboNivelAprobacion
            // 
            this.cboNivelAprobacion.Enabled = false;
            this.cboNivelAprobacion.FormattingEnabled = true;
            this.cboNivelAprobacion.Location = new System.Drawing.Point(495, 292);
            this.cboNivelAprobacion.Name = "cboNivelAprobacion";
            this.cboNivelAprobacion.Size = new System.Drawing.Size(188, 21);
            this.cboNivelAprobacion.TabIndex = 11;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(363, 296);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(126, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "Nivel de Aprobación:";
            // 
            // grbProcesar
            // 
            this.grbProcesar.Controls.Add(this.label2);
            this.grbProcesar.Controls.Add(this.btnProcesar);
            this.grbProcesar.Controls.Add(this.lblSoliciAprobada);
            this.grbProcesar.Location = new System.Drawing.Point(12, 442);
            this.grbProcesar.Name = "grbProcesar";
            this.grbProcesar.Size = new System.Drawing.Size(353, 63);
            this.grbProcesar.TabIndex = 17;
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
            this.label2.Size = new System.Drawing.Size(268, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Para ejecutar la ampliación, click en Procesar";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(287, 10);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 2;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblSoliciAprobada
            // 
            this.lblSoliciAprobada.AutoSize = true;
            this.lblSoliciAprobada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoliciAprobada.ForeColor = System.Drawing.Color.Navy;
            this.lblSoliciAprobada.Location = new System.Drawing.Point(6, 16);
            this.lblSoliciAprobada.Name = "lblSoliciAprobada";
            this.lblSoliciAprobada.Size = new System.Drawing.Size(136, 13);
            this.lblSoliciAprobada.TabIndex = 0;
            this.lblSoliciAprobada.Text = "Solicitud APROBADA";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 296);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Partida:";
            // 
            // frmPartidaAmpliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 529);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.grbProcesar);
            this.Controls.Add(this.cboNivelAprobacion);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.dtgPartidasAmpl);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboPeriodoPresupuestal);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.conBusUsuSolicitante);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblMovimiento);
            this.Controls.Add(this.txtMovimiento);
            this.Controls.Add(this.lblLimSaldo);
            this.Controls.Add(this.btnBuscaPartida);
            this.Controls.Add(this.cboLimAplicaSaldo);
            this.Controls.Add(this.dtgPartidaPres);
            this.Controls.Add(this.txtNombrePartida);
            this.Controls.Add(this.lblNombreMes);
            this.Controls.Add(this.lblMesActual);
            this.Name = "frmPartidaAmpliacion";
            this.Text = "Partidas de Ampliación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPartidaAmpliacion_FormClosing);
            this.Load += new System.EventHandler(this.frmAmpliacionPartida_Load);
            this.Controls.SetChildIndex(this.lblMesActual, 0);
            this.Controls.SetChildIndex(this.lblNombreMes, 0);
            this.Controls.SetChildIndex(this.txtNombrePartida, 0);
            this.Controls.SetChildIndex(this.dtgPartidaPres, 0);
            this.Controls.SetChildIndex(this.cboLimAplicaSaldo, 0);
            this.Controls.SetChildIndex(this.btnBuscaPartida, 0);
            this.Controls.SetChildIndex(this.lblLimSaldo, 0);
            this.Controls.SetChildIndex(this.txtMovimiento, 0);
            this.Controls.SetChildIndex(this.lblMovimiento, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.conBusUsuSolicitante, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboPeriodoPresupuestal, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.dtgPartidasAmpl, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboNivelAprobacion, 0);
            this.Controls.SetChildIndex(this.grbProcesar, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidaPres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasAmpl)).EndInit();
            this.conBusUsuSolicitante.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbProcesar.ResumeLayout(false);
            this.grbProcesar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreMes;
        private GEN.ControlesBase.lblBase lblMesActual;
        private GEN.ControlesBase.txtBase txtNombrePartida;
        private GEN.ControlesBase.dtgBase dtgPartidaPres;
        private GEN.ControlesBase.cboLimAplicaSaldo cboLimAplicaSaldo;
        private GEN.BotonesBase.btnMiniBusq btnBuscaPartida;
        private GEN.ControlesBase.lblBase lblLimSaldo;
        private GEN.ControlesBase.lblBase lblMovimiento;
        private GEN.ControlesBase.txtNumRea txtMovimiento;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.dtgBase dtgPartidasAmpl;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.ConBusCol conBusUsuSolicitante;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtFundamento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboNivelAprobPartidaPres cboNivelAprobacion;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbProcesar;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private System.Windows.Forms.Label lblSoliciAprobada;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}