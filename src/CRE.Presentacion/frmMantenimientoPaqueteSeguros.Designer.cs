namespace CRE.Presentacion
{
    partial class frmMantenimientoPaqueteSeguros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPaqueteSeguros));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.txtCorreo = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombrePaquete = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtLinkPaqueteSeguro = new GEN.ControlesBase.txtBase(this.components);
            this.txtPrecioPaqueteSeguro = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtNombrePaqueteSeguro = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.cboDetalleGasto1 = new GEN.ControlesBase.cboDetalleGasto(this.components);
            this.dtgPaqueteSegComplementario = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniQuitarPerfil = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregarPerfil = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitarEstable = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregarEstable = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgPaqueteSegPerfil = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgPaqueteSegEstablecimiento = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.ttpToolTipCorreo = new GEN.ControlesBase.ttpToolTip();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegComplementario)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegEstablecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcBase1);
            this.grbBase1.Controls.Add(this.txtCorreo);
            this.grbBase1.Controls.Add(this.txtNombrePaquete);
            this.grbBase1.Controls.Add(this.lblBase13);
            this.grbBase1.Controls.Add(this.cboMoneda1);
            this.grbBase1.Controls.Add(this.txtLinkPaqueteSeguro);
            this.grbBase1.Controls.Add(this.txtPrecioPaqueteSeguro);
            this.grbBase1.Controls.Add(this.txtNombrePaqueteSeguro);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(13, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(587, 147);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos generales";
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(496, 70);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 4;
            this.chcBase1.Text = "Activo";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(153, 94);
            this.txtCorreo.Multiline = true;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(426, 44);
            this.txtCorreo.TabIndex = 5;
            // 
            // txtNombrePaquete
            // 
            this.txtNombrePaquete.Location = new System.Drawing.Point(72, 40);
            this.txtNombrePaquete.Name = "txtNombrePaquete";
            this.txtNombrePaquete.Size = new System.Drawing.Size(190, 20);
            this.txtNombrePaquete.TabIndex = 2;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(7, 43);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(31, 13);
            this.lblBase13.TabIndex = 12;
            this.lblBase13.Text = "Plan";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(269, 68);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(114, 21);
            this.cboMoneda1.TabIndex = 3;
            // 
            // txtLinkPaqueteSeguro
            // 
            this.txtLinkPaqueteSeguro.Location = new System.Drawing.Point(185, 95);
            this.txtLinkPaqueteSeguro.Name = "txtLinkPaqueteSeguro";
            this.txtLinkPaqueteSeguro.Size = new System.Drawing.Size(394, 20);
            this.txtLinkPaqueteSeguro.TabIndex = 8;
            this.txtLinkPaqueteSeguro.TextChanged += new System.EventHandler(this.txtLinkPaqueteSeguro_TextChanged);
            // 
            // txtPrecioPaqueteSeguro
            // 
            this.txtPrecioPaqueteSeguro.Format = "n2";
            this.txtPrecioPaqueteSeguro.Location = new System.Drawing.Point(72, 67);
            this.txtPrecioPaqueteSeguro.Name = "txtPrecioPaqueteSeguro";
            this.txtPrecioPaqueteSeguro.Size = new System.Drawing.Size(107, 20);
            this.txtPrecioPaqueteSeguro.TabIndex = 7;
            this.txtPrecioPaqueteSeguro.TextChanged += new System.EventHandler(this.txtPrecioPaqueteSeguro_TextChanged);
            // 
            // txtNombrePaqueteSeguro
            // 
            this.txtNombrePaqueteSeguro.Location = new System.Drawing.Point(72, 14);
            this.txtNombrePaqueteSeguro.Name = "txtNombrePaqueteSeguro";
            this.txtNombrePaqueteSeguro.Size = new System.Drawing.Size(507, 20);
            this.txtNombrePaqueteSeguro.TabIndex = 1;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(423, 72);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(50, 13);
            this.lblBase6.TabIndex = 5;
            this.lblBase6.Text = "Estado:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(206, 74);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Moneda:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 98);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(139, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Correo enviar reportes";
            this.lblBase4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 98);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(32, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "link:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 71);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(47, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Precio:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nombre:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Controls.Add(this.btnMiniEditar1);
            this.grbBase2.Controls.Add(this.cboDetalleGasto1);
            this.grbBase2.Controls.Add(this.dtgPaqueteSegComplementario);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Location = new System.Drawing.Point(13, 169);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(587, 188);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Configuración";
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(545, 92);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 8;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitarSeguro_Click);
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(548, 58);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 7;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditarSeguro_Click);
            // 
            // cboDetalleGasto1
            // 
            this.cboDetalleGasto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetalleGasto1.FormattingEnabled = true;
            this.cboDetalleGasto1.Location = new System.Drawing.Point(133, 19);
            this.cboDetalleGasto1.Name = "cboDetalleGasto1";
            this.cboDetalleGasto1.Size = new System.Drawing.Size(371, 21);
            this.cboDetalleGasto1.TabIndex = 6;
            // 
            // dtgPaqueteSegComplementario
            // 
            this.dtgPaqueteSegComplementario.AllowUserToAddRows = false;
            this.dtgPaqueteSegComplementario.AllowUserToDeleteRows = false;
            this.dtgPaqueteSegComplementario.AllowUserToResizeColumns = false;
            this.dtgPaqueteSegComplementario.AllowUserToResizeRows = false;
            this.dtgPaqueteSegComplementario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPaqueteSegComplementario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPaqueteSegComplementario.Location = new System.Drawing.Point(18, 59);
            this.dtgPaqueteSegComplementario.MultiSelect = false;
            this.dtgPaqueteSegComplementario.Name = "dtgPaqueteSegComplementario";
            this.dtgPaqueteSegComplementario.ReadOnly = true;
            this.dtgPaqueteSegComplementario.RowHeadersVisible = false;
            this.dtgPaqueteSegComplementario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPaqueteSegComplementario.Size = new System.Drawing.Size(524, 123);
            this.dtgPaqueteSegComplementario.TabIndex = 2;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(15, 42);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(164, 13);
            this.lblBase8.TabIndex = 1;
            this.lblBase8.Text = "Seguros Complementarios:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(15, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(117, 13);
            this.lblBase7.TabIndex = 0;
            this.lblBase7.Text = "Seguro obligatorio:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.btnMiniQuitarPerfil);
            this.grbBase3.Controls.Add(this.btnMiniAgregarPerfil);
            this.grbBase3.Controls.Add(this.btnMiniQuitarEstable);
            this.grbBase3.Controls.Add(this.btnMiniAgregarEstable);
            this.grbBase3.Controls.Add(this.dtgPaqueteSegPerfil);
            this.grbBase3.Controls.Add(this.dtgPaqueteSegEstablecimiento);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Location = new System.Drawing.Point(13, 365);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(587, 291);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Disponibilidad";
            // 
            // btnMiniQuitarPerfil
            // 
            this.btnMiniQuitarPerfil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarPerfil.BackgroundImage")));
            this.btnMiniQuitarPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarPerfil.Location = new System.Drawing.Point(543, 205);
            this.btnMiniQuitarPerfil.Name = "btnMiniQuitarPerfil";
            this.btnMiniQuitarPerfil.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarPerfil.TabIndex = 12;
            this.btnMiniQuitarPerfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarPerfil.UseVisualStyleBackColor = true;
            this.btnMiniQuitarPerfil.Click += new System.EventHandler(this.btnMiniQuitarPerfil_Click);
            // 
            // btnMiniAgregarPerfil
            // 
            this.btnMiniAgregarPerfil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarPerfil.BackgroundImage")));
            this.btnMiniAgregarPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarPerfil.Location = new System.Drawing.Point(543, 175);
            this.btnMiniAgregarPerfil.Name = "btnMiniAgregarPerfil";
            this.btnMiniAgregarPerfil.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarPerfil.TabIndex = 11;
            this.btnMiniAgregarPerfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarPerfil.UseVisualStyleBackColor = true;
            this.btnMiniAgregarPerfil.Click += new System.EventHandler(this.btnMiniAgregarPerfil_Click);
            // 
            // btnMiniQuitarEstable
            // 
            this.btnMiniQuitarEstable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarEstable.BackgroundImage")));
            this.btnMiniQuitarEstable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarEstable.Location = new System.Drawing.Point(543, 67);
            this.btnMiniQuitarEstable.Name = "btnMiniQuitarEstable";
            this.btnMiniQuitarEstable.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarEstable.TabIndex = 10;
            this.btnMiniQuitarEstable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarEstable.UseVisualStyleBackColor = true;
            this.btnMiniQuitarEstable.Click += new System.EventHandler(this.btnMiniQuitarEstablecimiento_Click);
            // 
            // btnMiniAgregarEstable
            // 
            this.btnMiniAgregarEstable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarEstable.BackgroundImage")));
            this.btnMiniAgregarEstable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarEstable.Location = new System.Drawing.Point(543, 38);
            this.btnMiniAgregarEstable.Name = "btnMiniAgregarEstable";
            this.btnMiniAgregarEstable.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarEstable.TabIndex = 9;
            this.btnMiniAgregarEstable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarEstable.UseVisualStyleBackColor = true;
            this.btnMiniAgregarEstable.Click += new System.EventHandler(this.btnMiniAgregarEstablecimiento_Click);
            // 
            // dtgPaqueteSegPerfil
            // 
            this.dtgPaqueteSegPerfil.AllowUserToAddRows = false;
            this.dtgPaqueteSegPerfil.AllowUserToDeleteRows = false;
            this.dtgPaqueteSegPerfil.AllowUserToResizeColumns = false;
            this.dtgPaqueteSegPerfil.AllowUserToResizeRows = false;
            this.dtgPaqueteSegPerfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPaqueteSegPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPaqueteSegPerfil.Location = new System.Drawing.Point(13, 175);
            this.dtgPaqueteSegPerfil.MultiSelect = false;
            this.dtgPaqueteSegPerfil.Name = "dtgPaqueteSegPerfil";
            this.dtgPaqueteSegPerfil.ReadOnly = true;
            this.dtgPaqueteSegPerfil.RowHeadersVisible = false;
            this.dtgPaqueteSegPerfil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPaqueteSegPerfil.Size = new System.Drawing.Size(529, 110);
            this.dtgPaqueteSegPerfil.TabIndex = 7;
            // 
            // dtgPaqueteSegEstablecimiento
            // 
            this.dtgPaqueteSegEstablecimiento.AllowUserToAddRows = false;
            this.dtgPaqueteSegEstablecimiento.AllowUserToDeleteRows = false;
            this.dtgPaqueteSegEstablecimiento.AllowUserToResizeColumns = false;
            this.dtgPaqueteSegEstablecimiento.AllowUserToResizeRows = false;
            this.dtgPaqueteSegEstablecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPaqueteSegEstablecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPaqueteSegEstablecimiento.Location = new System.Drawing.Point(13, 38);
            this.dtgPaqueteSegEstablecimiento.MultiSelect = false;
            this.dtgPaqueteSegEstablecimiento.Name = "dtgPaqueteSegEstablecimiento";
            this.dtgPaqueteSegEstablecimiento.ReadOnly = true;
            this.dtgPaqueteSegEstablecimiento.RowHeadersVisible = false;
            this.dtgPaqueteSegEstablecimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPaqueteSegEstablecimiento.Size = new System.Drawing.Size(529, 110);
            this.dtgPaqueteSegEstablecimiento.TabIndex = 6;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(10, 159);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(194, 13);
            this.lblBase12.TabIndex = 3;
            this.lblBase12.Text = "Perfiles habilitados para la venta";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(10, 22);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(96, 13);
            this.lblBase11.TabIndex = 2;
            this.lblBase11.Text = "Zona y Agencia";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(10, 22);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(36, 13);
            this.lblBase10.TabIndex = 1;
            this.lblBase10.Text = "Zona";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(472, 662);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 13;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(538, 662);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoPaqueteSeguros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 749);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoPaqueteSeguros";
            this.Text = "Detalle Plan de Seguro";
            this.Load += new System.EventHandler(this.frmMantenimientoPaqueteSeguros_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegComplementario)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPaqueteSegEstablecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.txtBase txtLinkPaqueteSeguro;
        private GEN.ControlesBase.txtNumerico txtPrecioPaqueteSeguro;
        private GEN.ControlesBase.txtBase txtNombrePaqueteSeguro;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgPaqueteSegComplementario;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgPaqueteSegPerfil;
        private GEN.ControlesBase.dtgBase dtgPaqueteSegEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtNombrePaquete;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboDetalleGasto cboDetalleGasto1;
        private GEN.ControlesBase.ttpToolTip ttpToolTipCorreo;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarPerfil;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarPerfil;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarEstable;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarEstable;
        private GEN.ControlesBase.txtBase txtCorreo;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
    }
}