namespace DEP.Presentacion
{
    partial class frmEnvioValorado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioValorado));
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgSolOP = new GEN.ControlesBase.dtgBase(this.components);
            this.tbcValorados = new GEN.ControlesBase.tbcBase(this.components);
            this.tabOP = new System.Windows.Forms.TabPage();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.conBusColOp = new GEN.ControlesBase.ConBusCol();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtDescriOP = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalirOP = new GEN.BotonesBase.btnSalir();
            this.btnCanOP = new GEN.BotonesBase.btnCancelar();
            this.btnTransOP = new GEN.BotonesBase.btnTransferir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.tabCertificado = new System.Windows.Forms.TabPage();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.conBusColConstancia = new GEN.ControlesBase.ConBusCol();
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtDescriCert = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.nudCantidad = new GEN.ControlesBase.nudBase(this.components);
            this.btnProcesarCer = new GEN.BotonesBase.btnProcesar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgeCert = new GEN.ControlesBase.cboAgencias(this.components);
            this.nudFinValorado = new GEN.ControlesBase.nudBase(this.components);
            this.nudIniValorado = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.nudStock = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalirCer = new GEN.BotonesBase.btnSalir();
            this.btnCanCer = new GEN.BotonesBase.btnCancelar();
            this.btnTransCer = new GEN.BotonesBase.btnTransferir();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgCertificado = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).BeginInit();
            this.tbcValorados.SuspendLayout();
            this.tabOP.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.tabCertificado.SuspendLayout();
            this.conBusColConstancia.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinValorado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIniValorado)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(130, 24);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(231, 21);
            this.cboAgencias.TabIndex = 132;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 27);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(108, 13);
            this.lblBase1.TabIndex = 131;
            this.lblBase1.Text = "Agencias destino:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(407, 11);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 133;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ordenes de Pago Listos para su Envió";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgSolOP
            // 
            this.dtgSolOP.AllowUserToAddRows = false;
            this.dtgSolOP.AllowUserToDeleteRows = false;
            this.dtgSolOP.AllowUserToResizeColumns = false;
            this.dtgSolOP.AllowUserToResizeRows = false;
            this.dtgSolOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolOP.Location = new System.Drawing.Point(6, 100);
            this.dtgSolOP.MultiSelect = false;
            this.dtgSolOP.Name = "dtgSolOP";
            this.dtgSolOP.ReadOnly = true;
            this.dtgSolOP.RowHeadersVisible = false;
            this.dtgSolOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolOP.Size = new System.Drawing.Size(654, 259);
            this.dtgSolOP.TabIndex = 134;
            // 
            // tbcValorados
            // 
            this.tbcValorados.Controls.Add(this.tabOP);
            this.tbcValorados.Controls.Add(this.tabCertificado);
            this.tbcValorados.Location = new System.Drawing.Point(9, 6);
            this.tbcValorados.Name = "tbcValorados";
            this.tbcValorados.SelectedIndex = 0;
            this.tbcValorados.Size = new System.Drawing.Size(679, 611);
            this.tbcValorados.TabIndex = 0;
            // 
            // tabOP
            // 
            this.tabOP.Controls.Add(this.lblBase9);
            this.tabOP.Controls.Add(this.conBusColOp);
            this.tabOP.Controls.Add(this.lblBase7);
            this.tabOP.Controls.Add(this.txtDescriOP);
            this.tabOP.Controls.Add(this.btnSalirOP);
            this.tabOP.Controls.Add(this.btnCanOP);
            this.tabOP.Controls.Add(this.btnTransOP);
            this.tabOP.Controls.Add(this.label1);
            this.tabOP.Controls.Add(this.dtgSolOP);
            this.tabOP.Controls.Add(this.grbBase3);
            this.tabOP.Location = new System.Drawing.Point(4, 22);
            this.tabOP.Name = "tabOP";
            this.tabOP.Padding = new System.Windows.Forms.Padding(3);
            this.tabOP.Size = new System.Drawing.Size(671, 585);
            this.tabOP.TabIndex = 0;
            this.tabOP.Text = "Envío de ordenes de pago";
            this.tabOP.UseVisualStyleBackColor = true;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(11, 366);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(138, 13);
            this.lblBase9.TabIndex = 3;
            this.lblBase9.Text = "Responsable recepción";
            // 
            // conBusColOp
            // 
            this.conBusColOp.Location = new System.Drawing.Point(6, 365);
            this.conBusColOp.Name = "conBusColOp";
            this.conBusColOp.Size = new System.Drawing.Size(387, 86);
            this.conBusColOp.TabIndex = 2;
            this.conBusColOp.BuscarUsuario += new System.EventHandler(this.conBusColOp_BuscarUsuario);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(9, 456);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(78, 13);
            this.lblBase7.TabIndex = 143;
            this.lblBase7.Text = "Descripción:";
            // 
            // txtDescriOP
            // 
            this.txtDescriOP.Enabled = false;
            this.txtDescriOP.Location = new System.Drawing.Point(6, 473);
            this.txtDescriOP.Multiline = true;
            this.txtDescriOP.Name = "txtDescriOP";
            this.txtDescriOP.Size = new System.Drawing.Size(654, 52);
            this.txtDescriOP.TabIndex = 4;
            // 
            // btnSalirOP
            // 
            this.btnSalirOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirOP.BackgroundImage")));
            this.btnSalirOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirOP.Location = new System.Drawing.Point(600, 531);
            this.btnSalirOP.Name = "btnSalirOP";
            this.btnSalirOP.Size = new System.Drawing.Size(60, 50);
            this.btnSalirOP.TabIndex = 7;
            this.btnSalirOP.Text = "&Salir";
            this.btnSalirOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirOP.UseVisualStyleBackColor = true;
            this.btnSalirOP.Click += new System.EventHandler(this.btnSalirOP_Click);
            // 
            // btnCanOP
            // 
            this.btnCanOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCanOP.BackgroundImage")));
            this.btnCanOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCanOP.Location = new System.Drawing.Point(533, 531);
            this.btnCanOP.Name = "btnCanOP";
            this.btnCanOP.Size = new System.Drawing.Size(60, 50);
            this.btnCanOP.TabIndex = 6;
            this.btnCanOP.Text = "&Cancelar";
            this.btnCanOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCanOP.UseVisualStyleBackColor = true;
            this.btnCanOP.Click += new System.EventHandler(this.btnCanOP_Click);
            // 
            // btnTransOP
            // 
            this.btnTransOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransOP.BackgroundImage")));
            this.btnTransOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTransOP.Enabled = false;
            this.btnTransOP.Location = new System.Drawing.Point(474, 531);
            this.btnTransOP.Name = "btnTransOP";
            this.btnTransOP.Size = new System.Drawing.Size(60, 50);
            this.btnTransOP.TabIndex = 5;
            this.btnTransOP.Text = "&Transferir";
            this.btnTransOP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransOP.UseVisualStyleBackColor = true;
            this.btnTransOP.Click += new System.EventHandler(this.btnTransOP_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.btnProcesar);
            this.grbBase3.Controls.Add(this.cboAgencias);
            this.grbBase3.Location = new System.Drawing.Point(14, 6);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(520, 67);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Buscar";
            // 
            // tabCertificado
            // 
            this.tabCertificado.Controls.Add(this.lblBase10);
            this.tabCertificado.Controls.Add(this.conBusColConstancia);
            this.tabCertificado.Controls.Add(this.lblBase8);
            this.tabCertificado.Controls.Add(this.txtDescriCert);
            this.tabCertificado.Controls.Add(this.grbBase2);
            this.tabCertificado.Controls.Add(this.nudFinValorado);
            this.tabCertificado.Controls.Add(this.nudIniValorado);
            this.tabCertificado.Controls.Add(this.lblBase3);
            this.tabCertificado.Controls.Add(this.lblBase2);
            this.tabCertificado.Controls.Add(this.grbBase1);
            this.tabCertificado.Controls.Add(this.btnSalirCer);
            this.tabCertificado.Controls.Add(this.btnCanCer);
            this.tabCertificado.Controls.Add(this.btnTransCer);
            this.tabCertificado.Controls.Add(this.label2);
            this.tabCertificado.Controls.Add(this.dtgCertificado);
            this.tabCertificado.Location = new System.Drawing.Point(4, 22);
            this.tabCertificado.Name = "tabCertificado";
            this.tabCertificado.Padding = new System.Windows.Forms.Padding(3);
            this.tabCertificado.Size = new System.Drawing.Size(671, 585);
            this.tabCertificado.TabIndex = 1;
            this.tabCertificado.Text = "Envío de constancias";
            this.tabCertificado.UseVisualStyleBackColor = true;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(13, 372);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(138, 13);
            this.lblBase10.TabIndex = 3;
            this.lblBase10.Text = "Responsable recepción";
            // 
            // conBusColConstancia
            // 
            this.conBusColConstancia.Controls.Add(this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7);
            this.conBusColConstancia.Location = new System.Drawing.Point(8, 371);
            this.conBusColConstancia.Name = "conBusColConstancia";
            this.conBusColConstancia.Size = new System.Drawing.Size(387, 86);
            this.conBusColConstancia.TabIndex = 152;
            this.conBusColConstancia.BuscarUsuario += new System.EventHandler(this.conBusColConstancia_BuscarUsuario);
            // 
            // object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7
            // 
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.Location = new System.Drawing.Point(0, 0);
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.Name = "object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7";
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.Size = new System.Drawing.Size(387, 86);
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.TabIndex = 0;
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.TabStop = false;
            this.object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7.Text = "Datos del Colaborador";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(13, 460);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(78, 13);
            this.lblBase8.TabIndex = 151;
            this.lblBase8.Text = "Descripción:";
            // 
            // txtDescriCert
            // 
            this.txtDescriCert.Enabled = false;
            this.txtDescriCert.Location = new System.Drawing.Point(8, 476);
            this.txtDescriCert.Multiline = true;
            this.txtDescriCert.Name = "txtDescriCert";
            this.txtDescriCert.Size = new System.Drawing.Size(654, 52);
            this.txtDescriCert.TabIndex = 4;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.nudCantidad);
            this.grbBase2.Controls.Add(this.btnProcesarCer);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboAgeCert);
            this.grbBase2.Location = new System.Drawing.Point(8, 64);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(654, 66);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Filtro para Generar";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(392, 29);
            this.nudCantidad.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(122, 20);
            this.nudCantidad.TabIndex = 151;
            // 
            // btnProcesarCer
            // 
            this.btnProcesarCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesarCer.BackgroundImage")));
            this.btnProcesarCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesarCer.Location = new System.Drawing.Point(550, 12);
            this.btnProcesarCer.Name = "btnProcesarCer";
            this.btnProcesarCer.Size = new System.Drawing.Size(60, 50);
            this.btnProcesarCer.TabIndex = 151;
            this.btnProcesarCer.Text = "&Procesar";
            this.btnProcesarCer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesarCer.UseVisualStyleBackColor = true;
            this.btnProcesarCer.Click += new System.EventHandler(this.btnProcesarCer_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(325, 31);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(63, 13);
            this.lblBase6.TabIndex = 152;
            this.lblBase6.Text = "Cantidad:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(5, 31);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(102, 13);
            this.lblBase5.TabIndex = 150;
            this.lblBase5.Text = "Agencia destino:";
            // 
            // cboAgeCert
            // 
            this.cboAgeCert.FormattingEnabled = true;
            this.cboAgeCert.Location = new System.Drawing.Point(111, 28);
            this.cboAgeCert.Name = "cboAgeCert";
            this.cboAgeCert.Size = new System.Drawing.Size(208, 21);
            this.cboAgeCert.TabIndex = 150;
            // 
            // nudFinValorado
            // 
            this.nudFinValorado.Enabled = false;
            this.nudFinValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFinValorado.Location = new System.Drawing.Point(308, 28);
            this.nudFinValorado.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudFinValorado.Name = "nudFinValorado";
            this.nudFinValorado.Size = new System.Drawing.Size(122, 20);
            this.nudFinValorado.TabIndex = 146;
            // 
            // nudIniValorado
            // 
            this.nudIniValorado.Enabled = false;
            this.nudIniValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudIniValorado.Location = new System.Drawing.Point(106, 28);
            this.nudIniValorado.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudIniValorado.Name = "nudIniValorado";
            this.nudIniValorado.Size = new System.Drawing.Size(112, 20);
            this.nudIniValorado.TabIndex = 145;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(246, 30);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(58, 13);
            this.lblBase3.TabIndex = 148;
            this.lblBase3.Text = "Fin Folio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(31, 30);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(73, 13);
            this.lblBase2.TabIndex = 147;
            this.lblBase2.Text = "Inicio Folio:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.nudStock);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(8, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(654, 51);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Stock de Certificados en Almacén";
            // 
            // nudStock
            // 
            this.nudStock.Enabled = false;
            this.nudStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudStock.Location = new System.Drawing.Point(488, 19);
            this.nudStock.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(122, 20);
            this.nudStock.TabIndex = 149;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(438, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 150;
            this.lblBase4.Text = "Stock:";
            // 
            // btnSalirCer
            // 
            this.btnSalirCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirCer.BackgroundImage")));
            this.btnSalirCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirCer.Location = new System.Drawing.Point(600, 531);
            this.btnSalirCer.Name = "btnSalirCer";
            this.btnSalirCer.Size = new System.Drawing.Size(60, 50);
            this.btnSalirCer.TabIndex = 7;
            this.btnSalirCer.Text = "&Salir";
            this.btnSalirCer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirCer.UseVisualStyleBackColor = true;
            this.btnSalirCer.Click += new System.EventHandler(this.btnSalirCer_Click);
            // 
            // btnCanCer
            // 
            this.btnCanCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCanCer.BackgroundImage")));
            this.btnCanCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCanCer.Location = new System.Drawing.Point(533, 531);
            this.btnCanCer.Name = "btnCanCer";
            this.btnCanCer.Size = new System.Drawing.Size(60, 50);
            this.btnCanCer.TabIndex = 6;
            this.btnCanCer.Text = "&Cancelar";
            this.btnCanCer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCanCer.UseVisualStyleBackColor = true;
            this.btnCanCer.Click += new System.EventHandler(this.btnCanCer_Click);
            // 
            // btnTransCer
            // 
            this.btnTransCer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransCer.BackgroundImage")));
            this.btnTransCer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTransCer.Enabled = false;
            this.btnTransCer.Location = new System.Drawing.Point(474, 531);
            this.btnTransCer.Name = "btnTransCer";
            this.btnTransCer.Size = new System.Drawing.Size(60, 50);
            this.btnTransCer.TabIndex = 5;
            this.btnTransCer.Text = "&Transferir";
            this.btnTransCer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransCer.UseVisualStyleBackColor = true;
            this.btnTransCer.Click += new System.EventHandler(this.btnTransCer_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(8, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(655, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Certificados o Constancias Listos para su Envió";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgCertificado
            // 
            this.dtgCertificado.AllowUserToAddRows = false;
            this.dtgCertificado.AllowUserToDeleteRows = false;
            this.dtgCertificado.AllowUserToResizeColumns = false;
            this.dtgCertificado.AllowUserToResizeRows = false;
            this.dtgCertificado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCertificado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCertificado.Location = new System.Drawing.Point(8, 158);
            this.dtgCertificado.MultiSelect = false;
            this.dtgCertificado.Name = "dtgCertificado";
            this.dtgCertificado.ReadOnly = true;
            this.dtgCertificado.RowHeadersVisible = false;
            this.dtgCertificado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCertificado.Size = new System.Drawing.Size(654, 205);
            this.dtgCertificado.TabIndex = 136;
            // 
            // frmEnvioValorado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 664);
            this.Controls.Add(this.tbcValorados);
            this.Name = "frmEnvioValorado";
            this.Text = "Envío de valorados";
            this.Load += new System.EventHandler(this.frmEnvioValorado_Load);
            this.Controls.SetChildIndex(this.tbcValorados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).EndInit();
            this.tbcValorados.ResumeLayout(false);
            this.tabOP.ResumeLayout(false);
            this.tabOP.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.tabCertificado.ResumeLayout(false);
            this.tabCertificado.PerformLayout();
            this.conBusColConstancia.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinValorado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIniValorado)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencia cboAgencias;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.dtgBase dtgSolOP;
        private GEN.ControlesBase.tbcBase tbcValorados;
        private System.Windows.Forms.TabPage tabOP;
        private GEN.BotonesBase.btnSalir btnSalirOP;
        private GEN.BotonesBase.btnCancelar btnCanOP;
        private GEN.BotonesBase.btnTransferir btnTransOP;
        private System.Windows.Forms.TabPage tabCertificado;
        private GEN.BotonesBase.btnSalir btnSalirCer;
        private GEN.BotonesBase.btnCancelar btnCanCer;
        private GEN.BotonesBase.btnTransferir btnTransCer;
        private System.Windows.Forms.Label label2;
        private GEN.ControlesBase.dtgBase dtgCertificado;
        private GEN.ControlesBase.nudBase nudFinValorado;
        private GEN.ControlesBase.nudBase nudIniValorado;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.nudBase nudStock;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.nudBase nudCantidad;
        private GEN.BotonesBase.btnProcesar btnProcesarCer;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgeCert;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtDescriOP;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtDescriCert;
        private GEN.ControlesBase.ConBusCol conBusColOp;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.ConBusCol conBusColConstancia;
        private GEN.ControlesBase.grbBase object_62f9fe5d_7e9f_41c4_9771_4976d3da47f7;
    }
}