namespace ADM.Presentacion
{
    partial class frmMovimientoOficina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientoOficina));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoMovOficina1 = new GEN.ControlesBase.cboTipoMovOficina(this.components);
            this.cboTipoOficina = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroPersonal = new GEN.ControlesBase.txtBase(this.components);
            this.chcCNT = new GEN.ControlesBase.chcBase(this.components);
            this.txtNroCajCor = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroCajeros = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidad1 = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.cboEntidad1 = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtResSBS = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.dtpFecRes = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.dtpFecNoti = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboAgeSup = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboAgencias2 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.dtgMovimientos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbMovimientos = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.grbRegistrarMovimiento = new GEN.ControlesBase.grbBase(this.components);
            this.txtMail = new GEN.ControlesBase.txtEmail(this.components);
            this.txttelefono = new GEN.ControlesBase.txtTelefCel(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).BeginInit();
            this.grbMovimientos.SuspendLayout();
            this.grbRegistrarMovimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Oficina";
            // 
            // cboTipoMovOficina1
            // 
            this.cboTipoMovOficina1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovOficina1.FormattingEnabled = true;
            this.cboTipoMovOficina1.Location = new System.Drawing.Point(392, 25);
            this.cboTipoMovOficina1.Name = "cboTipoMovOficina1";
            this.cboTipoMovOficina1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoMovOficina1.TabIndex = 1;
            this.cboTipoMovOficina1.SelectedIndexChanged += new System.EventHandler(this.cboTipoMovOficina1_SelectedIndexChanged);
            // 
            // cboTipoOficina
            // 
            this.cboTipoOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOficina.Enabled = false;
            this.cboTipoOficina.FormattingEnabled = true;
            this.cboTipoOficina.Location = new System.Drawing.Point(103, 52);
            this.cboTipoOficina.Name = "cboTipoOficina";
            this.cboTipoOficina.Size = new System.Drawing.Size(147, 21);
            this.cboTipoOficina.TabIndex = 5;
            this.cboTipoOficina.SelectedIndexChanged += new System.EventHandler(this.cboTipoOficina_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(79, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Tipo Oficina:";
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conBusUbig1.Location = new System.Drawing.Point(18, 117);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 134);
            this.conBusUbig1.TabIndex = 3;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(392, 120);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(218, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(276, 127);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(65, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Dirección:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(276, 227);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(181, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Of. Supervisora / Dependiente";
            // 
            // txtNroPersonal
            // 
            this.txtNroPersonal.Location = new System.Drawing.Point(462, 163);
            this.txtNroPersonal.Name = "txtNroPersonal";
            this.txtNroPersonal.Size = new System.Drawing.Size(56, 20);
            this.txtNroPersonal.TabIndex = 7;
            this.txtNroPersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chcCNT
            // 
            this.chcCNT.AutoSize = true;
            this.chcCNT.Location = new System.Drawing.Point(279, 254);
            this.chcCNT.Name = "chcCNT";
            this.chcCNT.Size = new System.Drawing.Size(164, 17);
            this.chcCNT.TabIndex = 9;
            this.chcCNT.Text = "Lleva su propia contabilidad?";
            this.chcCNT.UseVisualStyleBackColor = true;
            // 
            // txtNroCajCor
            // 
            this.txtNroCajCor.Location = new System.Drawing.Point(462, 203);
            this.txtNroCajCor.Name = "txtNroCajCor";
            this.txtNroCajCor.Size = new System.Drawing.Size(56, 20);
            this.txtNroCajCor.TabIndex = 9;
            this.txtNroCajCor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNroCajeros
            // 
            this.txtNroCajeros.Location = new System.Drawing.Point(462, 183);
            this.txtNroCajeros.Name = "txtNroCajeros";
            this.txtNroCajeros.Size = new System.Drawing.Size(56, 20);
            this.txtNroCajeros.TabIndex = 8;
            this.txtNroCajeros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(276, 167);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(107, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Nro. de personal:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(276, 187);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(154, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Nro. Cajeros Automáticos";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(276, 207);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(173, 13);
            this.lblBase7.TabIndex = 18;
            this.lblBase7.Text = "Nro. Cajeros Corresponsales";
            // 
            // cboTipoEntidad1
            // 
            this.cboTipoEntidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntidad1.Enabled = false;
            this.cboTipoEntidad1.FormattingEnabled = true;
            this.cboTipoEntidad1.Location = new System.Drawing.Point(103, 275);
            this.cboTipoEntidad1.Name = "cboTipoEntidad1";
            this.cboTipoEntidad1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoEntidad1.TabIndex = 11;
            this.cboTipoEntidad1.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad1_SelectedIndexChanged);
            // 
            // cboEntidad1
            // 
            this.cboEntidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad1.Enabled = false;
            this.cboEntidad1.FormattingEnabled = true;
            this.cboEntidad1.Location = new System.Drawing.Point(103, 302);
            this.cboEntidad1.Name = "cboEntidad1";
            this.cboEntidad1.Size = new System.Drawing.Size(327, 21);
            this.cboEntidad1.TabIndex = 12;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(18, 278);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(77, 13);
            this.lblBase8.TabIndex = 21;
            this.lblBase8.Text = "Tipo Entidad";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(18, 305);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(49, 13);
            this.lblBase9.TabIndex = 22;
            this.lblBase9.Text = "Entidad";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(276, 29);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(105, 13);
            this.lblBase10.TabIndex = 23;
            this.lblBase10.Text = "Tipo Movimiento:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(276, 55);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(78, 13);
            this.lblBase11.TabIndex = 24;
            this.lblBase11.Text = "Res. SBS N°";
            // 
            // txtResSBS
            // 
            this.txtResSBS.Enabled = false;
            this.txtResSBS.FormatoDecimal = false;
            this.txtResSBS.Location = new System.Drawing.Point(392, 52);
            this.txtResSBS.Name = "txtResSBS";
            this.txtResSBS.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtResSBS.nNumDecimales = 4;
            this.txtResSBS.nvalor = 0D;
            this.txtResSBS.Size = new System.Drawing.Size(75, 20);
            this.txtResSBS.TabIndex = 25;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(473, 55);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(45, 13);
            this.lblBase12.TabIndex = 26;
            this.lblBase12.Text = "Fecha:";
            // 
            // dtpFecRes
            // 
            this.dtpFecRes.Enabled = false;
            this.dtpFecRes.Location = new System.Drawing.Point(523, 52);
            this.dtpFecRes.Name = "dtpFecRes";
            this.dtpFecRes.Size = new System.Drawing.Size(87, 20);
            this.dtpFecRes.TabIndex = 27;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(276, 83);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(109, 13);
            this.lblBase13.TabIndex = 28;
            this.lblBase13.Text = "Fecha Notificación";
            // 
            // dtpFecNoti
            // 
            this.dtpFecNoti.Location = new System.Drawing.Point(392, 77);
            this.dtpFecNoti.Name = "dtpFecNoti";
            this.dtpFecNoti.Size = new System.Drawing.Size(87, 20);
            this.dtpFecNoti.TabIndex = 3;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(514, 480);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 13;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(580, 480);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboAgeSup
            // 
            this.cboAgeSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeSup.FormattingEnabled = true;
            this.cboAgeSup.Location = new System.Drawing.Point(462, 223);
            this.cboAgeSup.Name = "cboAgeSup";
            this.cboAgeSup.Size = new System.Drawing.Size(121, 21);
            this.cboAgeSup.TabIndex = 10;
            // 
            // cboAgencias2
            // 
            this.cboAgencias2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias2.FormattingEnabled = true;
            this.cboAgencias2.Location = new System.Drawing.Point(103, 25);
            this.cboAgencias2.Name = "cboAgencias2";
            this.cboAgencias2.Size = new System.Drawing.Size(121, 21);
            this.cboAgencias2.TabIndex = 0;
            this.cboAgencias2.SelectedIndexChanged += new System.EventHandler(this.cboAgencias2_SelectedIndexChanged);
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(276, 107);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(60, 13);
            this.lblBase14.TabIndex = 30;
            this.lblBase14.Text = "Telefono:";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(276, 147);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(43, 13);
            this.lblBase15.TabIndex = 32;
            this.lblBase15.Text = "Email:";
            // 
            // dtgMovimientos
            // 
            this.dtgMovimientos.AllowUserToAddRows = false;
            this.dtgMovimientos.AllowUserToDeleteRows = false;
            this.dtgMovimientos.AllowUserToResizeColumns = false;
            this.dtgMovimientos.AllowUserToResizeRows = false;
            this.dtgMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimientos.Location = new System.Drawing.Point(6, 30);
            this.dtgMovimientos.MultiSelect = false;
            this.dtgMovimientos.Name = "dtgMovimientos";
            this.dtgMovimientos.ReadOnly = true;
            this.dtgMovimientos.RowHeadersVisible = false;
            this.dtgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovimientos.Size = new System.Drawing.Size(559, 104);
            this.dtgMovimientos.TabIndex = 30;
            this.dtgMovimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMovimientos_CellContentClick);
            this.dtgMovimientos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMovimientos_RowEnter);
            // 
            // grbMovimientos
            // 
            this.grbMovimientos.Controls.Add(this.btnMiniAgregar1);
            this.grbMovimientos.Controls.Add(this.btnMiniQuitar1);
            this.grbMovimientos.Controls.Add(this.dtgMovimientos);
            this.grbMovimientos.Location = new System.Drawing.Point(15, 334);
            this.grbMovimientos.Name = "grbMovimientos";
            this.grbMovimientos.Size = new System.Drawing.Size(625, 140);
            this.grbMovimientos.TabIndex = 31;
            this.grbMovimientos.TabStop = false;
            this.grbMovimientos.Text = "Movimientos Registrados";
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(571, 30);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 33;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(571, 64);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 31;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // grbRegistrarMovimiento
            // 
            this.grbRegistrarMovimiento.Controls.Add(this.txtMail);
            this.grbRegistrarMovimiento.Controls.Add(this.txttelefono);
            this.grbRegistrarMovimiento.Controls.Add(this.cboTipoOficina);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase1);
            this.grbRegistrarMovimiento.Controls.Add(this.cboTipoMovOficina1);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase2);
            this.grbRegistrarMovimiento.Controls.Add(this.conBusUbig1);
            this.grbRegistrarMovimiento.Controls.Add(this.txtDireccion);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase3);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase15);
            this.grbRegistrarMovimiento.Controls.Add(this.txtNroPersonal);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase4);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase14);
            this.grbRegistrarMovimiento.Controls.Add(this.chcCNT);
            this.grbRegistrarMovimiento.Controls.Add(this.txtNroCajCor);
            this.grbRegistrarMovimiento.Controls.Add(this.cboAgencias2);
            this.grbRegistrarMovimiento.Controls.Add(this.txtNroCajeros);
            this.grbRegistrarMovimiento.Controls.Add(this.cboAgeSup);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase5);
            this.grbRegistrarMovimiento.Controls.Add(this.dtpFecNoti);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase6);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase13);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase7);
            this.grbRegistrarMovimiento.Controls.Add(this.dtpFecRes);
            this.grbRegistrarMovimiento.Controls.Add(this.cboTipoEntidad1);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase12);
            this.grbRegistrarMovimiento.Controls.Add(this.cboEntidad1);
            this.grbRegistrarMovimiento.Controls.Add(this.txtResSBS);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase8);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase11);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase9);
            this.grbRegistrarMovimiento.Controls.Add(this.lblBase10);
            this.grbRegistrarMovimiento.Location = new System.Drawing.Point(12, 1);
            this.grbRegistrarMovimiento.Name = "grbRegistrarMovimiento";
            this.grbRegistrarMovimiento.Size = new System.Drawing.Size(628, 327);
            this.grbRegistrarMovimiento.TabIndex = 32;
            this.grbRegistrarMovimiento.TabStop = false;
            this.grbRegistrarMovimiento.Text = "Registrar Movimientos";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(392, 140);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(218, 20);
            this.txtMail.TabIndex = 34;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(392, 100);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(218, 20);
            this.txttelefono.TabIndex = 33;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(314, 480);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 35;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(380, 480);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 34;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(448, 480);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 33;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmMovimientoOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 565);
            this.Controls.Add(this.grbRegistrarMovimiento);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbMovimientos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmMovimientoOficina";
            this.Text = "Movimiento oficinas";
            this.Load += new System.EventHandler(this.frmMovimientoOficina_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbMovimientos, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.grbRegistrarMovimiento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientos)).EndInit();
            this.grbMovimientos.ResumeLayout(false);
            this.grbRegistrarMovimiento.ResumeLayout(false);
            this.grbRegistrarMovimiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoMovOficina cboTipoMovOficina1;
        private GEN.ControlesBase.cboBase cboTipoOficina;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNroPersonal;
        private GEN.ControlesBase.chcBase chcCNT;
        private GEN.ControlesBase.txtBase txtNroCajCor;
        private GEN.ControlesBase.txtBase txtNroCajeros;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad1;
        private GEN.ControlesBase.cboEntidad cboEntidad1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtResSBS;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.dtpCorto dtpFecRes;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.dtpCorto dtpFecNoti;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboAgencias cboAgeSup;
        private GEN.ControlesBase.cboAgencias cboAgencias2;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.dtgBase dtgMovimientos;
        private GEN.ControlesBase.grbBase grbMovimientos;
        private GEN.ControlesBase.grbBase grbRegistrarMovimiento;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtEmail txtMail;
        private GEN.ControlesBase.txtTelefCel txttelefono;
    }
}