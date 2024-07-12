namespace PRE.Presentacion
{
    partial class frmPartidaPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartidaPresupuesto));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblPlanificacion = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal1 = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgPartidasPres = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtNombrePartida = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboSigno = new GEN.ControlesBase.cboBase(this.components);
            this.cboNivelAprobPartida = new GEN.ControlesBase.cboNivelAprobPartidaPres(this.components);
            this.cboLimAplicaSaldo1 = new GEN.ControlesBase.cboLimAplicaSaldo(this.components);
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.nudPorcentaje = new GEN.ControlesBase.nudBase(this.components);
            this.chcAfectacionSaldo = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgCuentasCont = new GEN.ControlesBase.dtgBase(this.components);
            this.cboNivel = new GEN.ControlesBase.cboNivelMenu(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboEstructuraPresupuesto = new GEN.ControlesBase.cboEstructuraPresupuesto(this.components);
            this.btnImportExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasPres)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).BeginInit();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasCont)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblPlanificacion);
            this.grbBase1.Controls.Add(this.cboPeriodoPresupuestal1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(316, 38);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
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
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Periodo:";
            // 
            // dtgPartidasPres
            // 
            this.dtgPartidasPres.AllowUserToAddRows = false;
            this.dtgPartidasPres.AllowUserToDeleteRows = false;
            this.dtgPartidasPres.AllowUserToResizeColumns = false;
            this.dtgPartidasPres.AllowUserToResizeRows = false;
            this.dtgPartidasPres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPartidasPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPartidasPres.Location = new System.Drawing.Point(18, 56);
            this.dtgPartidasPres.MultiSelect = false;
            this.dtgPartidasPres.Name = "dtgPartidasPres";
            this.dtgPartidasPres.ReadOnly = true;
            this.dtgPartidasPres.RowHeadersVisible = false;
            this.dtgPartidasPres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPartidasPres.Size = new System.Drawing.Size(752, 291);
            this.dtgPartidasPres.TabIndex = 2;
            this.dtgPartidasPres.SelectionChanged += new System.EventHandler(this.dtgPartidasPres_SelectionChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(586, 530);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = false;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(718, 530);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(388, 530);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 6;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = false;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(454, 530);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 7;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = false;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(520, 530);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = false;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtNombrePartida
            // 
            this.txtNombrePartida.Location = new System.Drawing.Point(63, 41);
            this.txtNombrePartida.MaxLength = 249;
            this.txtNombrePartida.Name = "txtNombrePartida";
            this.txtNombrePartida.Size = new System.Drawing.Size(395, 20);
            this.txtNombrePartida.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Nombre:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Controls.Add(this.cboSigno);
            this.grbBase3.Controls.Add(this.cboNivelAprobPartida);
            this.grbBase3.Controls.Add(this.cboLimAplicaSaldo1);
            this.grbBase3.Controls.Add(this.txtCodigo);
            this.grbBase3.Controls.Add(this.nudPorcentaje);
            this.grbBase3.Controls.Add(this.chcAfectacionSaldo);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtNombrePartida);
            this.grbBase3.Location = new System.Drawing.Point(314, 391);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(464, 133);
            this.grbBase3.TabIndex = 4;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Detalles";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(376, 19);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(82, 13);
            this.lblBase8.TabIndex = 21;
            this.lblBase8.Text = "a estructuras";
            // 
            // cboSigno
            // 
            this.cboSigno.FormattingEnabled = true;
            this.cboSigno.Location = new System.Drawing.Point(297, 14);
            this.cboSigno.Name = "cboSigno";
            this.cboSigno.Size = new System.Drawing.Size(76, 21);
            this.cboSigno.TabIndex = 20;
            // 
            // cboNivelAprobPartida
            // 
            this.cboNivelAprobPartida.FormattingEnabled = true;
            this.cboNivelAprobPartida.Location = new System.Drawing.Point(337, 67);
            this.cboNivelAprobPartida.Name = "cboNivelAprobPartida";
            this.cboNivelAprobPartida.Size = new System.Drawing.Size(121, 21);
            this.cboNivelAprobPartida.TabIndex = 4;
            // 
            // cboLimAplicaSaldo1
            // 
            this.cboLimAplicaSaldo1.FormattingEnabled = true;
            this.cboLimAplicaSaldo1.Location = new System.Drawing.Point(205, 101);
            this.cboLimAplicaSaldo1.Name = "cboLimAplicaSaldo1";
            this.cboLimAplicaSaldo1.Size = new System.Drawing.Size(208, 21);
            this.cboLimAplicaSaldo1.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(63, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(107, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // nudPorcentaje
            // 
            this.nudPorcentaje.Location = new System.Drawing.Point(92, 67);
            this.nudPorcentaje.Name = "nudPorcentaje";
            this.nudPorcentaje.Size = new System.Drawing.Size(64, 20);
            this.nudPorcentaje.TabIndex = 2;
            // 
            // chcAfectacionSaldo
            // 
            this.chcAfectacionSaldo.AutoSize = true;
            this.chcAfectacionSaldo.Location = new System.Drawing.Point(217, 69);
            this.chcAfectacionSaldo.Name = "chcAfectacionSaldo";
            this.chcAfectacionSaldo.Size = new System.Drawing.Size(124, 17);
            this.chcAfectacionSaldo.TabIndex = 3;
            this.chcAfectacionSaldo.Text = "Nivel de aprobación:";
            this.chcAfectacionSaldo.UseVisualStyleBackColor = true;
            this.chcAfectacionSaldo.CheckedChanged += new System.EventHandler(this.chcAfectacionSaldo_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(5, 70);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(93, 13);
            this.lblBase7.TabIndex = 19;
            this.lblBase7.Text = "% Asignación: ";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(5, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 19;
            this.lblBase3.Text = "Código:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 104);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(194, 13);
            this.lblBase4.TabIndex = 19;
            this.lblBase4.Text = "Limite de aplicación sobre saldo:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.btnMiniQuitar1);
            this.grbBase4.Controls.Add(this.btnMiniAgregar1);
            this.grbBase4.Controls.Add(this.dtgCuentasCont);
            this.grbBase4.Location = new System.Drawing.Point(12, 353);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(296, 218);
            this.grbBase4.TabIndex = 5;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Cuentas Contables";
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(254, 53);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 1;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(254, 19);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 0;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // dtgCuentasCont
            // 
            this.dtgCuentasCont.AllowUserToAddRows = false;
            this.dtgCuentasCont.AllowUserToDeleteRows = false;
            this.dtgCuentasCont.AllowUserToResizeColumns = false;
            this.dtgCuentasCont.AllowUserToResizeRows = false;
            this.dtgCuentasCont.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentasCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentasCont.Location = new System.Drawing.Point(6, 19);
            this.dtgCuentasCont.MultiSelect = false;
            this.dtgCuentasCont.Name = "dtgCuentasCont";
            this.dtgCuentasCont.ReadOnly = true;
            this.dtgCuentasCont.RowHeadersVisible = false;
            this.dtgCuentasCont.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentasCont.Size = new System.Drawing.Size(242, 193);
            this.dtgCuentasCont.TabIndex = 0;
            // 
            // cboNivel
            // 
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(360, 364);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(121, 21);
            this.cboNivel.TabIndex = 3;
            this.cboNivel.SelectedIndexChanged += new System.EventHandler(this.cboNivel_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(314, 367);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(40, 13);
            this.lblBase6.TabIndex = 19;
            this.lblBase6.Text = "Nivel:";
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(652, 530);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 10;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = false;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(334, 29);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Ver por:";
            // 
            // cboEstructuraPresupuesto
            // 
            this.cboEstructuraPresupuesto.FormattingEnabled = true;
            this.cboEstructuraPresupuesto.Location = new System.Drawing.Point(388, 26);
            this.cboEstructuraPresupuesto.Name = "cboEstructuraPresupuesto";
            this.cboEstructuraPresupuesto.Size = new System.Drawing.Size(155, 21);
            this.cboEstructuraPresupuesto.TabIndex = 21;
            this.cboEstructuraPresupuesto.SelectedIndexChanged += new System.EventHandler(this.cboEstructuraPresupuesto_SelectedIndexChanged);
            // 
            // btnImportExcel1
            // 
            this.btnImportExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportExcel1.BackgroundImage")));
            this.btnImportExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportExcel1.Location = new System.Drawing.Point(710, 4);
            this.btnImportExcel1.Name = "btnImportExcel1";
            this.btnImportExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnImportExcel1.TabIndex = 22;
            this.btnImportExcel1.Text = "E&xcel";
            this.btnImportExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportExcel1.UseVisualStyleBackColor = true;
            this.btnImportExcel1.Click += new System.EventHandler(this.btnImportExcel1_Click);
            // 
            // frmPartidaPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 605);
            this.Controls.Add(this.btnImportExcel1);
            this.Controls.Add(this.cboEstructuraPresupuesto);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.dtgPartidasPres);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmPartidaPresupuesto";
            this.Text = "Partidas Presupuestales";
            this.Load += new System.EventHandler(this.frmPartidaPresupuesto_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.cboNivel, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.Controls.SetChildIndex(this.dtgPartidasPres, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboEstructuraPresupuesto, 0);
            this.Controls.SetChildIndex(this.btnImportExcel1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPartidasPres)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).EndInit();
            this.grbBase4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasCont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal1;
        private GEN.ControlesBase.dtgBase dtgPartidasPres;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtBase txtNombrePartida;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.chcBase chcAfectacionSaldo;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.ControlesBase.dtgBase dtgCuentasCont;
        private GEN.ControlesBase.cboNivelMenu cboNivel;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.Label lblPlanificacion;
        private GEN.ControlesBase.nudBase nudPorcentaje;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboLimAplicaSaldo cboLimAplicaSaldo1;
        private GEN.ControlesBase.cboNivelAprobPartidaPres cboNivelAprobPartida;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboSigno;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboEstructuraPresupuesto cboEstructuraPresupuesto;
        private GEN.BotonesBase.btnExporExcel btnImportExcel1;
    }
}