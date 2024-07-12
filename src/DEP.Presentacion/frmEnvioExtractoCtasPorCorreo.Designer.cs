using System.ComponentModel;
namespace DEP.Presentacion
{
    partial class frmEnvioExtractoCtasPorCorreo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioExtractoCtasPorCorreo));
            this.dtgExtCtaGen = new GEN.ControlesBase.dtgBase(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNomGen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtDirectorioCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtDirectorioServidor = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.conLoader = new GEN.ControlesBase.conLoader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCargarFile = new GEN.BotonesBase.btnCargarFile();
            this.dtgExtCtaEnv = new GEN.ControlesBase.dtgBase(this.components);
            this.btnActGenerados = new GEN.BotonesBase.btnActualizar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.btn_Vincular = new GEN.BotonesBase.Btn_Vincular();
            this.chcTodosGen = new GEN.ControlesBase.chcBase(this.components);
            this.chcTodosEnv = new GEN.ControlesBase.chcBase(this.components);
            this.chcCorrectoEnv = new GEN.ControlesBase.chcBase(this.components);
            this.chcCorrectoGen = new GEN.ControlesBase.chcBase(this.components);
            this.grbGeneracion = new GEN.ControlesBase.grbBase(this.components);
            this.grbEnvio = new GEN.ControlesBase.grbBase(this.components);
            this.lCheck_gen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEnvExtCtas_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroCuenta_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAnioMes_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccionEnvioEstCta_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPath_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCorrecto_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMsgError_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaMod_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCheck_env = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEnvExtCtas_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroCuenta_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAnioMes_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDirecEnvEstCta_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPath_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCorrecto_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMsgError_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaMod_env = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaGen)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaEnv)).BeginInit();
            this.grbGeneracion.SuspendLayout();
            this.grbEnvio.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgExtCtaGen
            // 
            this.dtgExtCtaGen.AllowUserToAddRows = false;
            this.dtgExtCtaGen.AllowUserToDeleteRows = false;
            this.dtgExtCtaGen.AllowUserToResizeColumns = false;
            this.dtgExtCtaGen.AllowUserToResizeRows = false;
            this.dtgExtCtaGen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgExtCtaGen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExtCtaGen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lCheck_gen,
            this.Row_gen,
            this.idEnvExtCtas_gen,
            this.idCuenta_gen,
            this.cNroCuenta_gen,
            this.cNombre_gen,
            this.nAnioMes_gen,
            this.cDireccionEnvioEstCta_gen,
            this.cPath_gen,
            this.lCorrecto_gen,
            this.cMsgError_gen,
            this.dFechaReg_gen,
            this.dFechaMod_gen});
            this.dtgExtCtaGen.Location = new System.Drawing.Point(27, 39);
            this.dtgExtCtaGen.MultiSelect = false;
            this.dtgExtCtaGen.Name = "dtgExtCtaGen";
            this.dtgExtCtaGen.ReadOnly = true;
            this.dtgExtCtaGen.RowHeadersVisible = false;
            this.dtgExtCtaGen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExtCtaGen.Size = new System.Drawing.Size(691, 170);
            this.dtgExtCtaGen.TabIndex = 2;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(57, 48);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(724, 39);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(724, 42);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(187, 48);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(31, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Del:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(158, 52);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(23, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Al:";
            // 
            // txtNomGen
            // 
            this.txtNomGen.Location = new System.Drawing.Point(170, 22);
            this.txtNomGen.Name = "txtNomGen";
            this.txtNomGen.Size = new System.Drawing.Size(112, 20);
            this.txtNomGen.TabIndex = 14;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(20, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(144, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Nombre de Generación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(20, 78);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(112, 13);
            this.lblBase4.TabIndex = 16;
            this.lblBase4.Text = "Directorio Cliente:";
            // 
            // txtDirectorioCliente
            // 
            this.txtDirectorioCliente.Location = new System.Drawing.Point(147, 74);
            this.txtDirectorioCliente.Name = "txtDirectorioCliente";
            this.txtDirectorioCliente.Size = new System.Drawing.Size(307, 20);
            this.txtDirectorioCliente.TabIndex = 17;
            // 
            // txtDirectorioServidor
            // 
            this.txtDirectorioServidor.Location = new System.Drawing.Point(147, 101);
            this.txtDirectorioServidor.Name = "txtDirectorioServidor";
            this.txtDirectorioServidor.Size = new System.Drawing.Size(307, 20);
            this.txtDirectorioServidor.TabIndex = 18;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(20, 104);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(121, 13);
            this.lblBase5.TabIndex = 19;
            this.lblBase5.Text = "Directorio Servidor:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnAceptar);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dtpFechaInicio);
            this.grbBase1.Controls.Add(this.dtpFechaFin);
            this.grbBase1.Controls.Add(this.txtDirectorioServidor);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtDirectorioCliente);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtNomGen);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(796, 135);
            this.grbBase1.TabIndex = 20;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de Generación y Envío";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(288, 19);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // conLoader
            // 
            this.conLoader.Active = false;
            this.conLoader.Color = System.Drawing.SystemColors.Highlight;
            this.conLoader.InnerCircleRadius = 5;
            this.conLoader.Location = new System.Drawing.Point(20, 632);
            this.conLoader.Name = "conLoader";
            this.conLoader.NumberSpoke = 12;
            this.conLoader.OuterCircleRadius = 11;
            this.conLoader.RotationSpeed = 100;
            this.conLoader.Size = new System.Drawing.Size(43, 40);
            this.conLoader.SpokeThickness = 2;
            this.conLoader.StylePreset = GEN.ControlesBase.conLoader.StylePresets.MacOSX;
            this.conLoader.TabIndex = 20;
            this.conLoader.Text = "conLoader1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted1);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(762, 622);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnCargarFile
            // 
            this.btnCargarFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnCargarFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile.BackgroundImage")));
            this.btnCargarFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile.Location = new System.Drawing.Point(696, 622);
            this.btnCargarFile.Name = "btnCargarFile";
            this.btnCargarFile.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile.TabIndex = 22;
            this.btnCargarFile.Text = "Su&bir";
            this.btnCargarFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile.UseVisualStyleBackColor = false;
            this.btnCargarFile.Click += new System.EventHandler(this.btnCargarFile_Click);
            // 
            // dtgExtCtaEnv
            // 
            this.dtgExtCtaEnv.AllowUserToAddRows = false;
            this.dtgExtCtaEnv.AllowUserToDeleteRows = false;
            this.dtgExtCtaEnv.AllowUserToResizeColumns = false;
            this.dtgExtCtaEnv.AllowUserToResizeRows = false;
            this.dtgExtCtaEnv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgExtCtaEnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExtCtaEnv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lCheck_env,
            this.Row_env,
            this.idEnvExtCtas_env,
            this.cNroCuenta_env,
            this.cNombre_env,
            this.idCuenta_env,
            this.nAnioMes_env,
            this.cDirecEnvEstCta_env,
            this.cPath_env,
            this.lCorrecto_env,
            this.cMsgError_env,
            this.dFechaReg_env,
            this.dFechaMod_env});
            this.dtgExtCtaEnv.Location = new System.Drawing.Point(27, 42);
            this.dtgExtCtaEnv.MultiSelect = false;
            this.dtgExtCtaEnv.Name = "dtgExtCtaEnv";
            this.dtgExtCtaEnv.ReadOnly = true;
            this.dtgExtCtaEnv.RowHeadersVisible = false;
            this.dtgExtCtaEnv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExtCtaEnv.Size = new System.Drawing.Size(691, 170);
            this.dtgExtCtaEnv.TabIndex = 23;
            // 
            // btnActGenerados
            // 
            this.btnActGenerados.BackColor = System.Drawing.SystemColors.Control;
            this.btnActGenerados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActGenerados.BackgroundImage")));
            this.btnActGenerados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActGenerados.Location = new System.Drawing.Point(724, 95);
            this.btnActGenerados.Name = "btnActGenerados";
            this.btnActGenerados.Size = new System.Drawing.Size(60, 50);
            this.btnActGenerados.TabIndex = 24;
            this.btnActGenerados.Text = "Todos";
            this.btnActGenerados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActGenerados.texto = "Todos";
            this.btnActGenerados.UseVisualStyleBackColor = true;
            this.btnActGenerados.Click += new System.EventHandler(this.btnActGenerados_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted2);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted3);
            // 
            // btn_Vincular
            // 
            this.btn_Vincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Vincular.BackgroundImage")));
            this.btn_Vincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Vincular.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vincular.Image")));
            this.btn_Vincular.Location = new System.Drawing.Point(724, 98);
            this.btn_Vincular.Name = "btn_Vincular";
            this.btn_Vincular.Size = new System.Drawing.Size(60, 50);
            this.btn_Vincular.TabIndex = 25;
            this.btn_Vincular.Text = "&Vincular";
            this.btn_Vincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Vincular.UseVisualStyleBackColor = true;
            this.btn_Vincular.Visible = false;
            this.btn_Vincular.Click += new System.EventHandler(this.btn_Vincular_Click);
            // 
            // chcTodosGen
            // 
            this.chcTodosGen.AutoSize = true;
            this.chcTodosGen.Location = new System.Drawing.Point(27, 19);
            this.chcTodosGen.Name = "chcTodosGen";
            this.chcTodosGen.Size = new System.Drawing.Size(56, 17);
            this.chcTodosGen.TabIndex = 20;
            this.chcTodosGen.Text = "Todos";
            this.chcTodosGen.UseVisualStyleBackColor = true;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);
            // 
            // chcTodosEnv
            // 
            this.chcTodosEnv.AutoSize = true;
            this.chcTodosEnv.Location = new System.Drawing.Point(27, 19);
            this.chcTodosEnv.Name = "chcTodosEnv";
            this.chcTodosEnv.Size = new System.Drawing.Size(56, 17);
            this.chcTodosEnv.TabIndex = 26;
            this.chcTodosEnv.Text = "Todos";
            this.chcTodosEnv.UseVisualStyleBackColor = true;
            this.chcTodosEnv.CheckedChanged += new System.EventHandler(this.chcTodosEnv_CheckedChanged);
            // 
            // chcCorrectoEnv
            // 
            this.chcCorrectoEnv.AutoSize = true;
            this.chcCorrectoEnv.Location = new System.Drawing.Point(647, 19);
            this.chcCorrectoEnv.Name = "chcCorrectoEnv";
            this.chcCorrectoEnv.Size = new System.Drawing.Size(71, 17);
            this.chcCorrectoEnv.TabIndex = 27;
            this.chcCorrectoEnv.Text = "Correctos";
            this.chcCorrectoEnv.UseVisualStyleBackColor = true;
            this.chcCorrectoEnv.CheckedChanged += new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);
            // 
            // chcCorrectoGen
            // 
            this.chcCorrectoGen.AutoSize = true;
            this.chcCorrectoGen.Location = new System.Drawing.Point(647, 19);
            this.chcCorrectoGen.Name = "chcCorrectoGen";
            this.chcCorrectoGen.Size = new System.Drawing.Size(71, 17);
            this.chcCorrectoGen.TabIndex = 28;
            this.chcCorrectoGen.Text = "Correctos";
            this.chcCorrectoGen.UseVisualStyleBackColor = true;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            // 
            // grbGeneracion
            // 
            this.grbGeneracion.Controls.Add(this.chcCorrectoGen);
            this.grbGeneracion.Controls.Add(this.chcTodosGen);
            this.grbGeneracion.Controls.Add(this.dtgExtCtaGen);
            this.grbGeneracion.Controls.Add(this.btnGenerar);
            this.grbGeneracion.Controls.Add(this.btnActGenerados);
            this.grbGeneracion.Location = new System.Drawing.Point(12, 153);
            this.grbGeneracion.Name = "grbGeneracion";
            this.grbGeneracion.Size = new System.Drawing.Size(796, 225);
            this.grbGeneracion.TabIndex = 21;
            this.grbGeneracion.TabStop = false;
            this.grbGeneracion.Text = "Generación de Cuentas";
            // 
            // grbEnvio
            // 
            this.grbEnvio.Controls.Add(this.chcTodosEnv);
            this.grbEnvio.Controls.Add(this.btnEnviar);
            this.grbEnvio.Controls.Add(this.chcCorrectoEnv);
            this.grbEnvio.Controls.Add(this.dtgExtCtaEnv);
            this.grbEnvio.Controls.Add(this.btn_Vincular);
            this.grbEnvio.Location = new System.Drawing.Point(12, 384);
            this.grbEnvio.Name = "grbEnvio";
            this.grbEnvio.Size = new System.Drawing.Size(796, 235);
            this.grbEnvio.TabIndex = 28;
            this.grbEnvio.TabStop = false;
            this.grbEnvio.Text = "Envío de Cuentas";
            // 
            // lCheck_gen
            // 
            this.lCheck_gen.DataPropertyName = "lCheck";
            this.lCheck_gen.HeaderText = ">";
            this.lCheck_gen.Name = "lCheck_gen";
            this.lCheck_gen.ReadOnly = true;
            this.lCheck_gen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCheck_gen.Width = 19;
            // 
            // Row_gen
            // 
            this.Row_gen.DataPropertyName = "Row";
            this.Row_gen.HeaderText = "#";
            this.Row_gen.Name = "Row_gen";
            this.Row_gen.ReadOnly = true;
            this.Row_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row_gen.Visible = false;
            this.Row_gen.Width = 20;
            // 
            // idEnvExtCtas_gen
            // 
            this.idEnvExtCtas_gen.DataPropertyName = "idEnvExtCtas";
            this.idEnvExtCtas_gen.HeaderText = "idEnvExtCtas";
            this.idEnvExtCtas_gen.Name = "idEnvExtCtas_gen";
            this.idEnvExtCtas_gen.ReadOnly = true;
            this.idEnvExtCtas_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idEnvExtCtas_gen.Visible = false;
            this.idEnvExtCtas_gen.Width = 76;
            // 
            // idCuenta_gen
            // 
            this.idCuenta_gen.DataPropertyName = "idCuenta";
            this.idCuenta_gen.HeaderText = "idCuenta";
            this.idCuenta_gen.Name = "idCuenta_gen";
            this.idCuenta_gen.ReadOnly = true;
            this.idCuenta_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idCuenta_gen.Visible = false;
            this.idCuenta_gen.Width = 55;
            // 
            // cNroCuenta_gen
            // 
            this.cNroCuenta_gen.DataPropertyName = "cNroCuenta";
            this.cNroCuenta_gen.FillWeight = 203.0457F;
            this.cNroCuenta_gen.HeaderText = "Nro. Cuenta";
            this.cNroCuenta_gen.Name = "cNroCuenta_gen";
            this.cNroCuenta_gen.ReadOnly = true;
            this.cNroCuenta_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNroCuenta_gen.Width = 70;
            // 
            // cNombre_gen
            // 
            this.cNombre_gen.DataPropertyName = "cNombre";
            this.cNombre_gen.HeaderText = "Cliente";
            this.cNombre_gen.Name = "cNombre_gen";
            this.cNombre_gen.ReadOnly = true;
            this.cNombre_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNombre_gen.Width = 45;
            // 
            // nAnioMes_gen
            // 
            this.nAnioMes_gen.DataPropertyName = "nAnioMes";
            this.nAnioMes_gen.HeaderText = "Subida";
            this.nAnioMes_gen.Name = "nAnioMes_gen";
            this.nAnioMes_gen.ReadOnly = true;
            this.nAnioMes_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nAnioMes_gen.Width = 46;
            // 
            // cDireccionEnvioEstCta_gen
            // 
            this.cDireccionEnvioEstCta_gen.DataPropertyName = "cDireccionEnvioEstCta";
            this.cDireccionEnvioEstCta_gen.HeaderText = "Correo";
            this.cDireccionEnvioEstCta_gen.Name = "cDireccionEnvioEstCta_gen";
            this.cDireccionEnvioEstCta_gen.ReadOnly = true;
            this.cDireccionEnvioEstCta_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDireccionEnvioEstCta_gen.Visible = false;
            this.cDireccionEnvioEstCta_gen.Width = 44;
            // 
            // cPath_gen
            // 
            this.cPath_gen.DataPropertyName = "cPath";
            this.cPath_gen.HeaderText = "Ubicación";
            this.cPath_gen.Name = "cPath_gen";
            this.cPath_gen.ReadOnly = true;
            this.cPath_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cPath_gen.Width = 61;
            // 
            // lCorrecto_gen
            // 
            this.lCorrecto_gen.DataPropertyName = "lCorrecto";
            this.lCorrecto_gen.HeaderText = "Correcto";
            this.lCorrecto_gen.Name = "lCorrecto_gen";
            this.lCorrecto_gen.ReadOnly = true;
            this.lCorrecto_gen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCorrecto_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lCorrecto_gen.Width = 53;
            // 
            // cMsgError_gen
            // 
            this.cMsgError_gen.DataPropertyName = "cMsgError";
            this.cMsgError_gen.HeaderText = "Mensaje";
            this.cMsgError_gen.Name = "cMsgError_gen";
            this.cMsgError_gen.ReadOnly = true;
            this.cMsgError_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cMsgError_gen.Width = 53;
            // 
            // dFechaReg_gen
            // 
            this.dFechaReg_gen.DataPropertyName = "dFechaReg";
            this.dFechaReg_gen.HeaderText = "Fecha Reg.";
            this.dFechaReg_gen.Name = "dFechaReg_gen";
            this.dFechaReg_gen.ReadOnly = true;
            this.dFechaReg_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaReg_gen.Width = 69;
            // 
            // dFechaMod_gen
            // 
            this.dFechaMod_gen.DataPropertyName = "dFechaMod";
            this.dFechaMod_gen.HeaderText = "dFechaMod";
            this.dFechaMod_gen.Name = "dFechaMod_gen";
            this.dFechaMod_gen.ReadOnly = true;
            this.dFechaMod_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaMod_gen.Visible = false;
            this.dFechaMod_gen.Width = 70;
            // 
            // lCheck_env
            // 
            this.lCheck_env.DataPropertyName = "lCheck";
            this.lCheck_env.HeaderText = ">";
            this.lCheck_env.Name = "lCheck_env";
            this.lCheck_env.ReadOnly = true;
            this.lCheck_env.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCheck_env.Width = 19;
            // 
            // Row_env
            // 
            this.Row_env.DataPropertyName = "Row";
            this.Row_env.HeaderText = "#";
            this.Row_env.Name = "Row_env";
            this.Row_env.ReadOnly = true;
            this.Row_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Row_env.Visible = false;
            this.Row_env.Width = 20;
            // 
            // idEnvExtCtas_env
            // 
            this.idEnvExtCtas_env.DataPropertyName = "idEnvExtCtas";
            this.idEnvExtCtas_env.HeaderText = "idEnvExtCtas";
            this.idEnvExtCtas_env.Name = "idEnvExtCtas_env";
            this.idEnvExtCtas_env.ReadOnly = true;
            this.idEnvExtCtas_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idEnvExtCtas_env.Visible = false;
            this.idEnvExtCtas_env.Width = 76;
            // 
            // cNroCuenta_env
            // 
            this.cNroCuenta_env.DataPropertyName = "cNroCuenta";
            this.cNroCuenta_env.HeaderText = "Nro. Cuenta";
            this.cNroCuenta_env.Name = "cNroCuenta_env";
            this.cNroCuenta_env.ReadOnly = true;
            this.cNroCuenta_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNroCuenta_env.Width = 70;
            // 
            // cNombre_env
            // 
            this.cNombre_env.DataPropertyName = "cNombre";
            this.cNombre_env.HeaderText = "Cliente";
            this.cNombre_env.Name = "cNombre_env";
            this.cNombre_env.ReadOnly = true;
            this.cNombre_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNombre_env.Width = 45;
            // 
            // idCuenta_env
            // 
            this.idCuenta_env.DataPropertyName = "idCuenta";
            this.idCuenta_env.HeaderText = "idCuenta";
            this.idCuenta_env.Name = "idCuenta_env";
            this.idCuenta_env.ReadOnly = true;
            this.idCuenta_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idCuenta_env.Visible = false;
            this.idCuenta_env.Width = 55;
            // 
            // nAnioMes_env
            // 
            this.nAnioMes_env.DataPropertyName = "nAnioMes";
            this.nAnioMes_env.HeaderText = "Subida";
            this.nAnioMes_env.Name = "nAnioMes_env";
            this.nAnioMes_env.ReadOnly = true;
            this.nAnioMes_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nAnioMes_env.Width = 46;
            // 
            // cDirecEnvEstCta_env
            // 
            this.cDirecEnvEstCta_env.DataPropertyName = "cDireccionEnvioEstCta";
            this.cDirecEnvEstCta_env.HeaderText = "Correo";
            this.cDirecEnvEstCta_env.Name = "cDirecEnvEstCta_env";
            this.cDirecEnvEstCta_env.ReadOnly = true;
            this.cDirecEnvEstCta_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDirecEnvEstCta_env.Width = 44;
            // 
            // cPath_env
            // 
            this.cPath_env.DataPropertyName = "cPath";
            this.cPath_env.HeaderText = "Ubicación";
            this.cPath_env.Name = "cPath_env";
            this.cPath_env.ReadOnly = true;
            this.cPath_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cPath_env.Width = 61;
            // 
            // lCorrecto_env
            // 
            this.lCorrecto_env.DataPropertyName = "lCorrecto";
            this.lCorrecto_env.HeaderText = "Correcto";
            this.lCorrecto_env.Name = "lCorrecto_env";
            this.lCorrecto_env.ReadOnly = true;
            this.lCorrecto_env.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCorrecto_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lCorrecto_env.Width = 53;
            // 
            // cMsgError_env
            // 
            this.cMsgError_env.DataPropertyName = "cMsgError";
            this.cMsgError_env.HeaderText = "Mensaje";
            this.cMsgError_env.Name = "cMsgError_env";
            this.cMsgError_env.ReadOnly = true;
            this.cMsgError_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cMsgError_env.Width = 53;
            // 
            // dFechaReg_env
            // 
            this.dFechaReg_env.DataPropertyName = "dFechaReg";
            this.dFechaReg_env.HeaderText = "Fecha Reg.";
            this.dFechaReg_env.Name = "dFechaReg_env";
            this.dFechaReg_env.ReadOnly = true;
            this.dFechaReg_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaReg_env.Width = 69;
            // 
            // dFechaMod_env
            // 
            this.dFechaMod_env.DataPropertyName = "dFechaMod";
            this.dFechaMod_env.HeaderText = "dFechaMod";
            this.dFechaMod_env.Name = "dFechaMod_env";
            this.dFechaMod_env.ReadOnly = true;
            this.dFechaMod_env.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaMod_env.Visible = false;
            this.dFechaMod_env.Width = 70;
            // 
            // frmEnvioExtractoCtasPorCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 703);
            this.Controls.Add(this.grbEnvio);
            this.Controls.Add(this.grbGeneracion);
            this.Controls.Add(this.btnCargarFile);
            this.Controls.Add(this.conLoader);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmEnvioExtractoCtasPorCorreo";
            this.Text = "Envío de Extractos de Cuentas por Correo";
            this.Load += new System.EventHandler(this.frmEnvioExtractoCtasPorCorreo_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conLoader, 0);
            this.Controls.SetChildIndex(this.btnCargarFile, 0);
            this.Controls.SetChildIndex(this.grbGeneracion, 0);
            this.Controls.SetChildIndex(this.grbEnvio, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaGen)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaEnv)).EndInit();
            this.grbGeneracion.ResumeLayout(false);
            this.grbGeneracion.PerformLayout();
            this.grbEnvio.ResumeLayout(false);
            this.grbEnvio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgExtCtaGen;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNomGen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtDirectorioCliente;
        private GEN.ControlesBase.txtBase txtDirectorioServidor;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.conLoader conLoader;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCargarFile btnCargarFile;
        private GEN.ControlesBase.dtgBase dtgExtCtaEnv;
        private GEN.BotonesBase.btnActualizar btnActGenerados;
        private BackgroundWorker backgroundWorker2;
        private BackgroundWorker backgroundWorker3;
        private GEN.BotonesBase.Btn_Vincular btn_Vincular;
        private GEN.ControlesBase.chcBase chcTodosGen;
        private GEN.ControlesBase.chcBase chcTodosEnv;
        private GEN.ControlesBase.chcBase chcCorrectoEnv;
        private GEN.ControlesBase.chcBase chcCorrectoGen;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.grbBase grbGeneracion;
        private GEN.ControlesBase.grbBase grbEnvio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCheck_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEnvExtCtas_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroCuenta_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAnioMes_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccionEnvioEstCta_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPath_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn lCorrecto_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMsgError_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaMod_gen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCheck_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEnvExtCtas_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroCuenta_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAnioMes_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDirecEnvEstCta_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPath_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn lCorrecto_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMsgError_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg_env;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaMod_env;
    }
}