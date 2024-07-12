namespace DEP.Presentacion
{
    partial class frmEnvioExtractoCtasADomicilio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioExtractoCtasADomicilio));
            this.chcCorrectoGen = new GEN.ControlesBase.chcBase(this.components);
            this.chcTodosGen = new GEN.ControlesBase.chcBase(this.components);
            this.btnActGenerados = new GEN.BotonesBase.btnActualizar();
            this.btnCargarFile = new GEN.BotonesBase.btnCargarFile();
            this.conLoader = new GEN.ControlesBase.conLoader();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtDirectorioServidor = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDirectorioCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNomGen = new GEN.ControlesBase.txtBase(this.components);
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.dtgExtCtaGen = new GEN.ControlesBase.dtgBase(this.components);
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaGen)).BeginInit();
            this.SuspendLayout();
            // 
            // chcCorrectoGen
            // 
            this.chcCorrectoGen.AutoSize = true;
            this.chcCorrectoGen.Location = new System.Drawing.Point(632, 153);
            this.chcCorrectoGen.Name = "chcCorrectoGen";
            this.chcCorrectoGen.Size = new System.Drawing.Size(71, 17);
            this.chcCorrectoGen.TabIndex = 43;
            this.chcCorrectoGen.Text = "Correctos";
            this.chcCorrectoGen.UseVisualStyleBackColor = true;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            // 
            // chcTodosGen
            // 
            this.chcTodosGen.AutoSize = true;
            this.chcTodosGen.Location = new System.Drawing.Point(12, 153);
            this.chcTodosGen.Name = "chcTodosGen";
            this.chcTodosGen.Size = new System.Drawing.Size(56, 17);
            this.chcTodosGen.TabIndex = 33;
            this.chcTodosGen.Text = "Todos";
            this.chcTodosGen.UseVisualStyleBackColor = true;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);
            // 
            // btnActGenerados
            // 
            this.btnActGenerados.BackColor = System.Drawing.SystemColors.Control;
            this.btnActGenerados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActGenerados.BackgroundImage")));
            this.btnActGenerados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActGenerados.Location = new System.Drawing.Point(709, 229);
            this.btnActGenerados.Name = "btnActGenerados";
            this.btnActGenerados.Size = new System.Drawing.Size(60, 50);
            this.btnActGenerados.TabIndex = 39;
            this.btnActGenerados.Text = "Todos";
            this.btnActGenerados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActGenerados.texto = "Todos";
            this.btnActGenerados.UseVisualStyleBackColor = true;
            this.btnActGenerados.Click += new System.EventHandler(this.btnActGenerados_Click);
            // 
            // btnCargarFile
            // 
            this.btnCargarFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnCargarFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile.BackgroundImage")));
            this.btnCargarFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile.Location = new System.Drawing.Point(643, 548);
            this.btnCargarFile.Name = "btnCargarFile";
            this.btnCargarFile.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile.TabIndex = 37;
            this.btnCargarFile.Text = "Su&bir";
            this.btnCargarFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile.UseVisualStyleBackColor = false;
            this.btnCargarFile.Click += new System.EventHandler(this.btnCargarFile_Click);
            // 
            // conLoader
            // 
            this.conLoader.Active = false;
            this.conLoader.Color = System.Drawing.SystemColors.Highlight;
            this.conLoader.InnerCircleRadius = 5;
            this.conLoader.Location = new System.Drawing.Point(12, 571);
            this.conLoader.Name = "conLoader";
            this.conLoader.NumberSpoke = 12;
            this.conLoader.OuterCircleRadius = 11;
            this.conLoader.RotationSpeed = 100;
            this.conLoader.Size = new System.Drawing.Size(35, 23);
            this.conLoader.SpokeThickness = 2;
            this.conLoader.StylePreset = GEN.ControlesBase.conLoader.StylePresets.MacOSX;
            this.conLoader.TabIndex = 34;
            this.conLoader.Text = "conLoader1";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(709, 548);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 36;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
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
            this.grbBase1.Size = new System.Drawing.Size(764, 135);
            this.grbBase1.TabIndex = 35;
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
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(57, 48);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(187, 48);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // txtDirectorioServidor
            // 
            this.txtDirectorioServidor.Location = new System.Drawing.Point(147, 101);
            this.txtDirectorioServidor.Name = "txtDirectorioServidor";
            this.txtDirectorioServidor.Size = new System.Drawing.Size(307, 20);
            this.txtDirectorioServidor.TabIndex = 18;
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
            // txtDirectorioCliente
            // 
            this.txtDirectorioCliente.Location = new System.Drawing.Point(147, 74);
            this.txtDirectorioCliente.Name = "txtDirectorioCliente";
            this.txtDirectorioCliente.Size = new System.Drawing.Size(307, 20);
            this.txtDirectorioCliente.TabIndex = 17;
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
            // txtNomGen
            // 
            this.txtNomGen.Location = new System.Drawing.Point(170, 22);
            this.txtNomGen.Name = "txtNomGen";
            this.txtNomGen.Size = new System.Drawing.Size(112, 20);
            this.txtNomGen.TabIndex = 14;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(709, 173);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 31;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
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
            this.dtgExtCtaGen.Location = new System.Drawing.Point(12, 173);
            this.dtgExtCtaGen.MultiSelect = false;
            this.dtgExtCtaGen.Name = "dtgExtCtaGen";
            this.dtgExtCtaGen.ReadOnly = true;
            this.dtgExtCtaGen.RowHeadersVisible = false;
            this.dtgExtCtaGen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExtCtaGen.Size = new System.Drawing.Size(691, 369);
            this.dtgExtCtaGen.TabIndex = 29;
            // 
            // lCheck_gen
            // 
            this.lCheck_gen.DataPropertyName = "lCheck";
            this.lCheck_gen.HeaderText = ">";
            this.lCheck_gen.Name = "lCheck_gen";
            this.lCheck_gen.ReadOnly = true;
            this.lCheck_gen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCheck_gen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lCheck_gen.Width = 38;
            // 
            // Row_gen
            // 
            this.Row_gen.DataPropertyName = "Row";
            this.Row_gen.HeaderText = "#";
            this.Row_gen.Name = "Row_gen";
            this.Row_gen.ReadOnly = true;
            this.Row_gen.Visible = false;
            this.Row_gen.Width = 39;
            // 
            // idEnvExtCtas_gen
            // 
            this.idEnvExtCtas_gen.DataPropertyName = "idEnvExtCtas";
            this.idEnvExtCtas_gen.HeaderText = "idEnvExtCtas";
            this.idEnvExtCtas_gen.Name = "idEnvExtCtas_gen";
            this.idEnvExtCtas_gen.ReadOnly = true;
            this.idEnvExtCtas_gen.Visible = false;
            this.idEnvExtCtas_gen.Width = 95;
            // 
            // idCuenta_gen
            // 
            this.idCuenta_gen.DataPropertyName = "idCuenta";
            this.idCuenta_gen.HeaderText = "idCuenta";
            this.idCuenta_gen.Name = "idCuenta_gen";
            this.idCuenta_gen.ReadOnly = true;
            this.idCuenta_gen.Visible = false;
            this.idCuenta_gen.Width = 74;
            // 
            // cNroCuenta_gen
            // 
            this.cNroCuenta_gen.DataPropertyName = "cNroCuenta";
            this.cNroCuenta_gen.FillWeight = 203.0457F;
            this.cNroCuenta_gen.HeaderText = "Nro. Cuenta";
            this.cNroCuenta_gen.Name = "cNroCuenta_gen";
            this.cNroCuenta_gen.ReadOnly = true;
            this.cNroCuenta_gen.Width = 89;
            // 
            // cNombre_gen
            // 
            this.cNombre_gen.DataPropertyName = "cNombre";
            this.cNombre_gen.HeaderText = "Cliente";
            this.cNombre_gen.Name = "cNombre_gen";
            this.cNombre_gen.ReadOnly = true;
            this.cNombre_gen.Width = 64;
            // 
            // nAnioMes_gen
            // 
            this.nAnioMes_gen.DataPropertyName = "nAnioMes";
            this.nAnioMes_gen.HeaderText = "Subida";
            this.nAnioMes_gen.Name = "nAnioMes_gen";
            this.nAnioMes_gen.ReadOnly = true;
            this.nAnioMes_gen.Width = 65;
            // 
            // cDireccionEnvioEstCta_gen
            // 
            this.cDireccionEnvioEstCta_gen.DataPropertyName = "cDireccionEnvioEstCta";
            this.cDireccionEnvioEstCta_gen.HeaderText = "Correo";
            this.cDireccionEnvioEstCta_gen.Name = "cDireccionEnvioEstCta_gen";
            this.cDireccionEnvioEstCta_gen.ReadOnly = true;
            this.cDireccionEnvioEstCta_gen.Visible = false;
            this.cDireccionEnvioEstCta_gen.Width = 63;
            // 
            // cPath_gen
            // 
            this.cPath_gen.DataPropertyName = "cPath";
            this.cPath_gen.HeaderText = "Ubicación";
            this.cPath_gen.Name = "cPath_gen";
            this.cPath_gen.ReadOnly = true;
            this.cPath_gen.Width = 80;
            // 
            // lCorrecto_gen
            // 
            this.lCorrecto_gen.DataPropertyName = "lCorrecto";
            this.lCorrecto_gen.HeaderText = "Correcto";
            this.lCorrecto_gen.Name = "lCorrecto_gen";
            this.lCorrecto_gen.ReadOnly = true;
            this.lCorrecto_gen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCorrecto_gen.Width = 72;
            // 
            // cMsgError_gen
            // 
            this.cMsgError_gen.DataPropertyName = "cMsgError";
            this.cMsgError_gen.HeaderText = "Mensaje";
            this.cMsgError_gen.Name = "cMsgError_gen";
            this.cMsgError_gen.ReadOnly = true;
            this.cMsgError_gen.Width = 72;
            // 
            // dFechaReg_gen
            // 
            this.dFechaReg_gen.DataPropertyName = "dFechaReg";
            this.dFechaReg_gen.HeaderText = "Fecha Reg.";
            this.dFechaReg_gen.Name = "dFechaReg_gen";
            this.dFechaReg_gen.ReadOnly = true;
            this.dFechaReg_gen.Width = 88;
            // 
            // dFechaMod_gen
            // 
            this.dFechaMod_gen.DataPropertyName = "dFechaMod";
            this.dFechaMod_gen.HeaderText = "dFechaMod";
            this.dFechaMod_gen.Name = "dFechaMod_gen";
            this.dFechaMod_gen.ReadOnly = true;
            this.dFechaMod_gen.Visible = false;
            this.dFechaMod_gen.Width = 89;
            // 
            // frmEnvioExtractoCtasADomicilio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 627);
            this.Controls.Add(this.chcCorrectoGen);
            this.Controls.Add(this.chcTodosGen);
            this.Controls.Add(this.btnActGenerados);
            this.Controls.Add(this.btnCargarFile);
            this.Controls.Add(this.conLoader);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtgExtCtaGen);
            this.Name = "frmEnvioExtractoCtasADomicilio";
            this.Text = "Envío de Extractos de Cuentas a Domicilio";
            this.Load += new System.EventHandler(this.frmEnvioExtractoCtasADomicilio_Load);
            this.Controls.SetChildIndex(this.dtgExtCtaGen, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conLoader, 0);
            this.Controls.SetChildIndex(this.btnCargarFile, 0);
            this.Controls.SetChildIndex(this.btnActGenerados, 0);
            this.Controls.SetChildIndex(this.chcTodosGen, 0);
            this.Controls.SetChildIndex(this.chcCorrectoGen, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtCtaGen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chcBase chcCorrectoGen;
        private GEN.ControlesBase.chcBase chcTodosGen;
        private GEN.BotonesBase.btnActualizar btnActGenerados;
        private GEN.BotonesBase.btnCargarFile btnCargarFile;
        private GEN.ControlesBase.conLoader conLoader;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.txtBase txtDirectorioServidor;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtDirectorioCliente;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNomGen;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.ControlesBase.dtgBase dtgExtCtaGen;
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;

    }
}