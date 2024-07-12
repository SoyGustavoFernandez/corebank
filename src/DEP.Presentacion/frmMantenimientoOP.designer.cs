namespace DEP.Presentacion
{
    partial class frmMantenimientoOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoOP));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabOP = new System.Windows.Forms.TabPage();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.chcAnularTal = new GEN.ControlesBase.chcBase(this.components);
            this.chcAnularOP = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgDetalle = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.cboEstCheq = new GEN.ControlesBase.cboBase(this.components);
            this.tabCli = new System.Windows.Forms.TabPage();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumFirmas = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReqFirma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conBusCtaAho.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.tabCli.SuspendLayout();
            this.grbBase6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Controls.Add(this.txtBase1);
            this.conBusCtaAho.Controls.Add(this.grbBase2);
            this.conBusCtaAho.Controls.Add(this.txtBase2);
            this.conBusCtaAho.Controls.Add(this.grbBase3);
            this.conBusCtaAho.Location = new System.Drawing.Point(9, 10);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(580, 114);
            this.conBusCtaAho.TabIndex = 5;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase1.Location = new System.Drawing.Point(158, 82);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(395, 20);
            this.txtBase1.TabIndex = 15;
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -1);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(556, 112);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // txtBase2
            // 
            this.txtBase2.Enabled = false;
            this.txtBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase2.Location = new System.Drawing.Point(158, 82);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(395, 20);
            this.txtBase2.TabIndex = 15;
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(3, -1);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(556, 112);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Cliente";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(625, 14);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(168, 21);
            this.cboTipoCuenta.TabIndex = 113;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(525, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 112;
            this.lblBase5.Text = "Tipo de Cuenta:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(77, 133);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(199, 20);
            this.txtProducto.TabIndex = 108;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 136);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 111;
            this.lblBase6.Text = "Producto:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(329, 15);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(190, 21);
            this.cboMoneda.TabIndex = 109;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(270, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 110;
            this.lblBase7.Text = "Moneda:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.cboTipoCuenta);
            this.grbBase4.Controls.Add(this.lblBase5);
            this.grbBase4.Controls.Add(this.cboMoneda);
            this.grbBase4.Controls.Add(this.lblBase7);
            this.grbBase4.Location = new System.Drawing.Point(9, 119);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(800, 43);
            this.grbBase4.TabIndex = 114;
            this.grbBase4.TabStop = false;
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabOP);
            this.tbcBase1.Controls.Add(this.tabCli);
            this.tbcBase1.Location = new System.Drawing.Point(5, 168);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(804, 380);
            this.tbcBase1.TabIndex = 115;
            // 
            // tabOP
            // 
            this.tabOP.Controls.Add(this.lblBase3);
            this.tabOP.Controls.Add(this.txtMotivo);
            this.tabOP.Controls.Add(this.chcAnularTal);
            this.tabOP.Controls.Add(this.chcAnularOP);
            this.tabOP.Controls.Add(this.lblBase1);
            this.tabOP.Controls.Add(this.dtgDetalle);
            this.tabOP.Controls.Add(this.dtgSolicitudes);
            this.tabOP.Controls.Add(this.cboEstCheq);
            this.tabOP.Location = new System.Drawing.Point(4, 22);
            this.tabOP.Name = "tabOP";
            this.tabOP.Padding = new System.Windows.Forms.Padding(3);
            this.tabOP.Size = new System.Drawing.Size(796, 354);
            this.tabOP.TabIndex = 0;
            this.tabOP.Text = "Administración de las Ordenes de Pago";
            this.tabOP.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 311);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 147;
            this.lblBase3.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(68, 311);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(725, 36);
            this.txtMotivo.TabIndex = 146;
            // 
            // chcAnularTal
            // 
            this.chcAnularTal.AutoSize = true;
            this.chcAnularTal.Enabled = false;
            this.chcAnularTal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcAnularTal.Location = new System.Drawing.Point(160, 128);
            this.chcAnularTal.Name = "chcAnularTal";
            this.chcAnularTal.Size = new System.Drawing.Size(142, 17);
            this.chcAnularTal.TabIndex = 96;
            this.chcAnularTal.Text = "Devolución de Talonario";
            this.chcAnularTal.UseVisualStyleBackColor = true;
            this.chcAnularTal.CheckedChanged += new System.EventHandler(this.chcAnularTal_CheckedChanged);
            // 
            // chcAnularOP
            // 
            this.chcAnularOP.AutoSize = true;
            this.chcAnularOP.Enabled = false;
            this.chcAnularOP.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcAnularOP.Location = new System.Drawing.Point(8, 128);
            this.chcAnularOP.Name = "chcAnularOP";
            this.chcAnularOP.Size = new System.Drawing.Size(142, 17);
            this.chcAnularOP.TabIndex = 95;
            this.chcAnularOP.Text = "Anular Órdenes de Pago";
            this.chcAnularOP.UseVisualStyleBackColor = true;
            this.chcAnularOP.CheckedChanged += new System.EventHandler(this.chcAnularOP_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 7);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(148, 13);
            this.lblBase1.TabIndex = 94;
            this.lblBase1.Text = "Estado de los talonarios:";
            // 
            // dtgDetalle
            // 
            this.dtgDetalle.AllowUserToAddRows = false;
            this.dtgDetalle.AllowUserToDeleteRows = false;
            this.dtgDetalle.AllowUserToResizeColumns = false;
            this.dtgDetalle.AllowUserToResizeRows = false;
            this.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalle.Location = new System.Drawing.Point(6, 151);
            this.dtgDetalle.MultiSelect = false;
            this.dtgDetalle.Name = "dtgDetalle";
            this.dtgDetalle.ReadOnly = true;
            this.dtgDetalle.RowHeadersVisible = false;
            this.dtgDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalle.Size = new System.Drawing.Size(787, 154);
            this.dtgDetalle.TabIndex = 2;
            this.dtgDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalle_CellValueChanged);
            this.dtgDetalle.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDetalle_CurrentCellDirtyStateChanged);
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Location = new System.Drawing.Point(6, 30);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(787, 94);
            this.dtgSolicitudes.TabIndex = 1;
            this.dtgSolicitudes.SelectionChanged += new System.EventHandler(this.dtgSolicitudes_SelectionChanged);
            // 
            // cboEstCheq
            // 
            this.cboEstCheq.Enabled = false;
            this.cboEstCheq.FormattingEnabled = true;
            this.cboEstCheq.Location = new System.Drawing.Point(168, 4);
            this.cboEstCheq.Name = "cboEstCheq";
            this.cboEstCheq.Size = new System.Drawing.Size(203, 21);
            this.cboEstCheq.TabIndex = 0;
            this.cboEstCheq.SelectedIndexChanged += new System.EventHandler(this.cboEstCheq_SelectedIndexChanged);
            // 
            // tabCli
            // 
            this.tabCli.Controls.Add(this.grbBase6);
            this.tabCli.Location = new System.Drawing.Point(4, 22);
            this.tabCli.Name = "tabCli";
            this.tabCli.Padding = new System.Windows.Forms.Padding(3);
            this.tabCli.Size = new System.Drawing.Size(796, 354);
            this.tabCli.TabIndex = 1;
            this.tabCli.Text = "Datos de los Clientes";
            this.tabCli.UseVisualStyleBackColor = true;
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.txtNumFirmas);
            this.grbBase6.Controls.Add(this.lblBase2);
            this.grbBase6.Controls.Add(this.ptbFirma);
            this.grbBase6.Controls.Add(this.dtgIntervinientes);
            this.grbBase6.Location = new System.Drawing.Point(-2, 28);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(792, 192);
            this.grbBase6.TabIndex = 89;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "INTERVINIENTES DE LA CUENTA";
            // 
            // txtNumFirmas
            // 
            this.txtNumFirmas.Enabled = false;
            this.txtNumFirmas.Location = new System.Drawing.Point(718, 19);
            this.txtNumFirmas.Name = "txtNumFirmas";
            this.txtNumFirmas.Size = new System.Drawing.Size(69, 20);
            this.txtNumFirmas.TabIndex = 92;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(568, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(142, 13);
            this.lblBase2.TabIndex = 93;
            this.lblBase2.Text = "Nro Firmas Requeridos:";
            // 
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbFirma.Location = new System.Drawing.Point(565, 41);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(222, 137);
            this.ptbFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFirma.TabIndex = 50;
            this.ptbFirma.TabStop = false;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoInterv,
            this.idSolicitud,
            this.cDocumentoID,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF,
            this.isReqFirma,
            this.cTipoDocumento,
            this.idTipoDocumento});
            this.dtgIntervinientes.Location = new System.Drawing.Point(10, 21);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(549, 157);
            this.dtgIntervinientes.TabIndex = 3;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(612, 548);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 116;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(671, 548);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(749, 548);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 118;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 80F;
            this.idSolicitud.HeaderText = "CUENTA";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 90F;
            this.cDocumentoID.HeaderText = "DOCUMENTO";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 260F;
            this.cNombre.HeaderText = "NOMBRE CLIENTE";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.FillWeight = 70F;
            this.cTipoIntervencion.HeaderText = "INTERV.";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.FillWeight = 25F;
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lCliAfeITF.Visible = false;
            // 
            // isReqFirma
            // 
            this.isReqFirma.DataPropertyName = "isReqFirma";
            this.isReqFirma.FillWeight = 50F;
            this.isReqFirma.HeaderText = "FIRMA";
            this.isReqFirma.Name = "isReqFirma";
            this.isReqFirma.ReadOnly = true;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "cTipoDocumento";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            this.cTipoDocumento.Visible = false;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // frmMantenimientoOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 623);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmMantenimientoOP";
            this.Text = "Mantenimiento de Ordenes de Pago";
            this.Load += new System.EventHandler(this.frmMantenimientoOP_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtProducto, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            this.tabOP.ResumeLayout(false);
            this.tabOP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.tabCli.ResumeLayout(false);
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabOP;
        private System.Windows.Forms.TabPage tabCli;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.txtBase txtNumFirmas;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.PictureBox ptbFirma;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.ControlesBase.cboBase cboEstCheq;
        private GEN.ControlesBase.dtgBase dtgDetalle;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcAnularTal;
        private GEN.ControlesBase.chcBase chcAnularOP;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReqFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
    }
}