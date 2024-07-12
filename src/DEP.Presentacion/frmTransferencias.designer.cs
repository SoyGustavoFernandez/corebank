namespace DEP.Presentacion
{
    partial class frmTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferencias));
            this.conBusCtaAhoOrigen = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase8 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoCuentaOrigen = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.lblBase45 = new GEN.ControlesBase.lblBase();
            this.txtNumFirOri = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase40 = new GEN.ControlesBase.lblBase();
            this.lblBase46 = new GEN.ControlesBase.lblBase();
            this.txtSaldoDisp = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtProductoOrigen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase43 = new GEN.ControlesBase.lblBase();
            this.cboMonedaOrigen = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase48 = new GEN.ControlesBase.lblBase();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.dtgCuentasPago = new GEN.ControlesBase.dtgBase(this.components);
            this.conSplaf1 = new GEN.ControlesBase.conSplaf();
            this.txtTotalOpeTrans = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase51 = new GEN.ControlesBase.lblBase();
            this.txtITFRet = new GEN.ControlesBase.txtBase(this.components);
            this.txtComisionRetiro = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase47 = new GEN.ControlesBase.lblBase();
            this.conSolesDolar = new GEN.ControlesBase.ConSolesDolar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoTransfer = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase9 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodMon = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodMod = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodIns = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroCta = new GEN.ControlesBase.txtBase(this.components);
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase28 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.grbTransferencia = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtInscripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCtaAhoOrigen.SuspendLayout();
            this.grbBase8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasPago)).BeginInit();
            this.grbBase9.SuspendLayout();
            this.grbTransferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCtaAhoOrigen
            // 
            this.conBusCtaAhoOrigen.Controls.Add(this.txtNombre);
            this.conBusCtaAhoOrigen.Controls.Add(this.grbBase1);
            this.conBusCtaAhoOrigen.Location = new System.Drawing.Point(11, 13);
            this.conBusCtaAhoOrigen.Name = "conBusCtaAhoOrigen";
            this.conBusCtaAhoOrigen.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAhoOrigen.TabIndex = 10;
            this.conBusCtaAhoOrigen.ClicBusCta += new System.EventHandler(this.conBusCtaAhoOrigen_ClicBusCta);
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
            // grbBase8
            // 
            this.grbBase8.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbBase8.Controls.Add(this.cboTipoCuentaOrigen);
            this.grbBase8.Controls.Add(this.lblBase45);
            this.grbBase8.Controls.Add(this.txtNumFirOri);
            this.grbBase8.Controls.Add(this.lblBase40);
            this.grbBase8.Controls.Add(this.lblBase46);
            this.grbBase8.Controls.Add(this.txtSaldoDisp);
            this.grbBase8.Controls.Add(this.txtProductoOrigen);
            this.grbBase8.Controls.Add(this.lblBase43);
            this.grbBase8.Controls.Add(this.cboMonedaOrigen);
            this.grbBase8.Controls.Add(this.lblBase48);
            this.grbBase8.Location = new System.Drawing.Point(11, 130);
            this.grbBase8.Name = "grbBase8";
            this.grbBase8.Size = new System.Drawing.Size(560, 68);
            this.grbBase8.TabIndex = 43;
            this.grbBase8.TabStop = false;
            this.grbBase8.Text = "Datos de la Cuenta:";
            // 
            // cboTipoCuentaOrigen
            // 
            this.cboTipoCuentaOrigen.Enabled = false;
            this.cboTipoCuentaOrigen.FormattingEnabled = true;
            this.cboTipoCuentaOrigen.Location = new System.Drawing.Point(358, 42);
            this.cboTipoCuentaOrigen.Name = "cboTipoCuentaOrigen";
            this.cboTipoCuentaOrigen.Size = new System.Drawing.Size(145, 21);
            this.cboTipoCuentaOrigen.TabIndex = 49;
            // 
            // lblBase45
            // 
            this.lblBase45.AutoSize = true;
            this.lblBase45.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase45.ForeColor = System.Drawing.Color.Navy;
            this.lblBase45.Location = new System.Drawing.Point(261, 45);
            this.lblBase45.Name = "lblBase45";
            this.lblBase45.Size = new System.Drawing.Size(99, 13);
            this.lblBase45.TabIndex = 48;
            this.lblBase45.Text = "Tipo de Cuenta:";
            // 
            // txtNumFirOri
            // 
            this.txtNumFirOri.Enabled = false;
            this.txtNumFirOri.Location = new System.Drawing.Point(165, 43);
            this.txtNumFirOri.Name = "txtNumFirOri";
            this.txtNumFirOri.Size = new System.Drawing.Size(69, 20);
            this.txtNumFirOri.TabIndex = 46;
            // 
            // lblBase40
            // 
            this.lblBase40.AutoSize = true;
            this.lblBase40.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase40.ForeColor = System.Drawing.Color.Navy;
            this.lblBase40.Location = new System.Drawing.Point(14, 46);
            this.lblBase40.Name = "lblBase40";
            this.lblBase40.Size = new System.Drawing.Size(142, 13);
            this.lblBase40.TabIndex = 47;
            this.lblBase40.Text = "Nro Firmas Requeridos:";
            // 
            // lblBase46
            // 
            this.lblBase46.AutoSize = true;
            this.lblBase46.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase46.ForeColor = System.Drawing.Color.Navy;
            this.lblBase46.Location = new System.Drawing.Point(364, 20);
            this.lblBase46.Name = "lblBase46";
            this.lblBase46.Size = new System.Drawing.Size(66, 13);
            this.lblBase46.TabIndex = 45;
            this.lblBase46.Text = "Sald.Disp:";
            // 
            // txtSaldoDisp
            // 
            this.txtSaldoDisp.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoDisp.Enabled = false;
            this.txtSaldoDisp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDisp.FormatoDecimal = true;
            this.txtSaldoDisp.Location = new System.Drawing.Point(430, 17);
            this.txtSaldoDisp.Name = "txtSaldoDisp";
            this.txtSaldoDisp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSaldoDisp.nNumDecimales = 2;
            this.txtSaldoDisp.nvalor = 0D;
            this.txtSaldoDisp.Size = new System.Drawing.Size(121, 22);
            this.txtSaldoDisp.TabIndex = 29;
            this.txtSaldoDisp.Text = "0.00";
            this.txtSaldoDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProductoOrigen
            // 
            this.txtProductoOrigen.Enabled = false;
            this.txtProductoOrigen.Location = new System.Drawing.Point(66, 17);
            this.txtProductoOrigen.Name = "txtProductoOrigen";
            this.txtProductoOrigen.Size = new System.Drawing.Size(127, 20);
            this.txtProductoOrigen.TabIndex = 0;
            // 
            // lblBase43
            // 
            this.lblBase43.AutoSize = true;
            this.lblBase43.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase43.ForeColor = System.Drawing.Color.Navy;
            this.lblBase43.Location = new System.Drawing.Point(5, 19);
            this.lblBase43.Name = "lblBase43";
            this.lblBase43.Size = new System.Drawing.Size(62, 13);
            this.lblBase43.TabIndex = 12;
            this.lblBase43.Text = "Producto:";
            // 
            // cboMonedaOrigen
            // 
            this.cboMonedaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaOrigen.Enabled = false;
            this.cboMonedaOrigen.FormattingEnabled = true;
            this.cboMonedaOrigen.Location = new System.Drawing.Point(249, 17);
            this.cboMonedaOrigen.Name = "cboMonedaOrigen";
            this.cboMonedaOrigen.Size = new System.Drawing.Size(114, 21);
            this.cboMonedaOrigen.TabIndex = 1;
            // 
            // lblBase48
            // 
            this.lblBase48.AutoSize = true;
            this.lblBase48.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase48.ForeColor = System.Drawing.Color.Navy;
            this.lblBase48.Location = new System.Drawing.Point(195, 20);
            this.lblBase48.Name = "lblBase48";
            this.lblBase48.Size = new System.Drawing.Size(56, 13);
            this.lblBase48.TabIndex = 1;
            this.lblBase48.Text = "Moneda:";
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(514, 205);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 45;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Enabled = false;
            this.btnQuitar1.Location = new System.Drawing.Point(514, 261);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 46;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // dtgCuentasPago
            // 
            this.dtgCuentasPago.AllowUserToAddRows = false;
            this.dtgCuentasPago.AllowUserToDeleteRows = false;
            this.dtgCuentasPago.AllowUserToResizeColumns = false;
            this.dtgCuentasPago.AllowUserToResizeRows = false;
            this.dtgCuentasPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentasPago.Location = new System.Drawing.Point(11, 332);
            this.dtgCuentasPago.MultiSelect = false;
            this.dtgCuentasPago.Name = "dtgCuentasPago";
            this.dtgCuentasPago.ReadOnly = true;
            this.dtgCuentasPago.RowHeadersVisible = false;
            this.dtgCuentasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentasPago.Size = new System.Drawing.Size(563, 129);
            this.dtgCuentasPago.TabIndex = 49;
            this.dtgCuentasPago.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentasPago_CellValueChanged);
            this.dtgCuentasPago.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCuentasPago_EditingControlShowing);
            // 
            // conSplaf1
            // 
            this.conSplaf1.AutoSize = true;
            this.conSplaf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.conSplaf1.ForeColor = System.Drawing.Color.Red;
            this.conSplaf1.Location = new System.Drawing.Point(257, 351);
            this.conSplaf1.Name = "conSplaf1";
            this.conSplaf1.Size = new System.Drawing.Size(0, 20);
            this.conSplaf1.TabIndex = 71;
            // 
            // txtTotalOpeTrans
            // 
            this.txtTotalOpeTrans.Enabled = false;
            this.txtTotalOpeTrans.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalOpeTrans.FormatoDecimal = false;
            this.txtTotalOpeTrans.Location = new System.Drawing.Point(273, 546);
            this.txtTotalOpeTrans.Name = "txtTotalOpeTrans";
            this.txtTotalOpeTrans.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalOpeTrans.nNumDecimales = 4;
            this.txtTotalOpeTrans.nvalor = 0D;
            this.txtTotalOpeTrans.ReadOnly = true;
            this.txtTotalOpeTrans.Size = new System.Drawing.Size(100, 22);
            this.txtTotalOpeTrans.TabIndex = 70;
            this.txtTotalOpeTrans.Text = "0.00";
            this.txtTotalOpeTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase51
            // 
            this.lblBase51.AutoSize = true;
            this.lblBase51.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase51.ForeColor = System.Drawing.Color.Navy;
            this.lblBase51.Location = new System.Drawing.Point(219, 471);
            this.lblBase51.Name = "lblBase51";
            this.lblBase51.Size = new System.Drawing.Size(46, 13);
            this.lblBase51.TabIndex = 69;
            this.lblBase51.Text = "Monto:";
            // 
            // txtITFRet
            // 
            this.txtITFRet.BackColor = System.Drawing.SystemColors.Control;
            this.txtITFRet.Enabled = false;
            this.txtITFRet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtITFRet.Location = new System.Drawing.Point(273, 517);
            this.txtITFRet.Name = "txtITFRet";
            this.txtITFRet.Size = new System.Drawing.Size(100, 22);
            this.txtITFRet.TabIndex = 68;
            this.txtITFRet.Text = "0.00";
            this.txtITFRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtComisionRetiro
            // 
            this.txtComisionRetiro.BackColor = System.Drawing.SystemColors.Control;
            this.txtComisionRetiro.Enabled = false;
            this.txtComisionRetiro.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComisionRetiro.Location = new System.Drawing.Point(273, 492);
            this.txtComisionRetiro.Name = "txtComisionRetiro";
            this.txtComisionRetiro.Size = new System.Drawing.Size(100, 22);
            this.txtComisionRetiro.TabIndex = 65;
            this.txtComisionRetiro.Text = "0.00";
            this.txtComisionRetiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase47
            // 
            this.lblBase47.AutoSize = true;
            this.lblBase47.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase47.ForeColor = System.Drawing.Color.Navy;
            this.lblBase47.Location = new System.Drawing.Point(213, 496);
            this.lblBase47.Name = "lblBase47";
            this.lblBase47.Size = new System.Drawing.Size(52, 13);
            this.lblBase47.TabIndex = 64;
            this.lblBase47.Text = "Comis.:";
            // 
            // conSolesDolar
            // 
            this.conSolesDolar.Location = new System.Drawing.Point(160, 491);
            this.conSolesDolar.Name = "conSolesDolar";
            this.conSolesDolar.Size = new System.Drawing.Size(55, 48);
            this.conSolesDolar.TabIndex = 63;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(451, 517);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 62;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(514, 517);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 61;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(387, 517);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 60;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(101, 13);
            this.lblBase1.TabIndex = 47;
            this.lblBase1.Text = "Transferencia a:";
            // 
            // cboTipoTransfer
            // 
            this.cboTipoTransfer.Enabled = false;
            this.cboTipoTransfer.FormattingEnabled = true;
            this.cboTipoTransfer.Location = new System.Drawing.Point(120, 16);
            this.cboTipoTransfer.Name = "cboTipoTransfer";
            this.cboTipoTransfer.Size = new System.Drawing.Size(168, 21);
            this.cboTipoTransfer.TabIndex = 48;
            this.cboTipoTransfer.SelectedIndexChanged += new System.EventHandler(this.cboTipoTransfer_SelectedIndexChanged);
            // 
            // grbBase9
            // 
            this.grbBase9.Controls.Add(this.txtCodMon);
            this.grbBase9.Controls.Add(this.txtCodMod);
            this.grbBase9.Controls.Add(this.txtCodAge);
            this.grbBase9.Controls.Add(this.txtCodIns);
            this.grbBase9.Controls.Add(this.txtNroCta);
            this.grbBase9.Controls.Add(this.txtCliente);
            this.grbBase9.Controls.Add(this.lblBase4);
            this.grbBase9.Controls.Add(this.lblBase28);
            this.grbBase9.Controls.Add(this.lblBase3);
            this.grbBase9.Controls.Add(this.txtEstado);
            this.grbBase9.Controls.Add(this.btnBusqueda);
            this.grbBase9.Location = new System.Drawing.Point(8, 38);
            this.grbBase9.Name = "grbBase9";
            this.grbBase9.Size = new System.Drawing.Size(480, 71);
            this.grbBase9.TabIndex = 53;
            this.grbBase9.TabStop = false;
            this.grbBase9.Text = "Datos de la cuenta:";
            // 
            // txtCodMon
            // 
            this.txtCodMon.Enabled = false;
            this.txtCodMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMon.Location = new System.Drawing.Point(148, 16);
            this.txtCodMon.Name = "txtCodMon";
            this.txtCodMon.Size = new System.Drawing.Size(13, 20);
            this.txtCodMon.TabIndex = 65;
            // 
            // txtCodMod
            // 
            this.txtCodMod.Enabled = false;
            this.txtCodMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMod.Location = new System.Drawing.Point(128, 16);
            this.txtCodMod.Name = "txtCodMod";
            this.txtCodMod.Size = new System.Drawing.Size(20, 20);
            this.txtCodMod.TabIndex = 62;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(101, 16);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 63;
            // 
            // txtCodIns
            // 
            this.txtCodIns.Enabled = false;
            this.txtCodIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodIns.Location = new System.Drawing.Point(75, 16);
            this.txtCodIns.Name = "txtCodIns";
            this.txtCodIns.Size = new System.Drawing.Size(27, 20);
            this.txtCodIns.TabIndex = 64;
            // 
            // txtNroCta
            // 
            this.txtNroCta.Enabled = false;
            this.txtNroCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCta.Location = new System.Drawing.Point(161, 16);
            this.txtNroCta.MaxLength = 9;
            this.txtNroCta.Name = "txtNroCta";
            this.txtNroCta.Size = new System.Drawing.Size(80, 20);
            this.txtNroCta.TabIndex = 61;
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(75, 45);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(336, 20);
            this.txtCliente.TabIndex = 60;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 48);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 59;
            this.lblBase4.Text = "Cliente:";
            // 
            // lblBase28
            // 
            this.lblBase28.AutoSize = true;
            this.lblBase28.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase28.ForeColor = System.Drawing.Color.Navy;
            this.lblBase28.Location = new System.Drawing.Point(12, 19);
            this.lblBase28.Name = "lblBase28";
            this.lblBase28.Size = new System.Drawing.Size(57, 13);
            this.lblBase28.TabIndex = 56;
            this.lblBase28.Text = "Cuenta :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(244, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 58;
            this.lblBase3.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(295, 16);
            this.txtEstado.MaxLength = 15;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(116, 20);
            this.txtEstado.TabIndex = 53;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Enabled = false;
            this.btnBusqueda.Location = new System.Drawing.Point(414, 15);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 49;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // grbTransferencia
            // 
            this.grbTransferencia.Controls.Add(this.grbBase9);
            this.grbTransferencia.Controls.Add(this.cboTipoTransfer);
            this.grbTransferencia.Controls.Add(this.lblBase1);
            this.grbTransferencia.Location = new System.Drawing.Point(11, 197);
            this.grbTransferencia.Name = "grbTransferencia";
            this.grbTransferencia.Size = new System.Drawing.Size(494, 118);
            this.grbTransferencia.TabIndex = 50;
            this.grbTransferencia.TabStop = false;
            this.grbTransferencia.Text = "Datos de Transferencia";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(236, 521);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(30, 13);
            this.lblBase5.TabIndex = 67;
            this.lblBase5.Text = "ITF:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 471);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(122, 13);
            this.lblBase2.TabIndex = 74;
            this.lblBase2.Text = "Inscripción a pagar:";
            this.lblBase2.Visible = false;
            this.lblBase2.Click += new System.EventHandler(this.lblBase2_Click);
            // 
            // txtInscripcion
            // 
            this.txtInscripcion.Enabled = false;
            this.txtInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInscripcion.Location = new System.Drawing.Point(14, 490);
            this.txtInscripcion.Name = "txtInscripcion";
            this.txtInscripcion.Size = new System.Drawing.Size(107, 20);
            this.txtInscripcion.TabIndex = 73;
            this.txtInscripcion.Text = "0.00";
            this.txtInscripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInscripcion.Visible = false;
            this.txtInscripcion.TextChanged += new System.EventHandler(this.txtInscripcion_TextChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(187, 550);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(78, 13);
            this.lblBase6.TabIndex = 75;
            this.lblBase6.Text = "Monto Total:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Enabled = false;
            this.txtMonto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(273, 464);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 22);
            this.txtMonto.TabIndex = 76;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 593);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtInscripcion);
            this.Controls.Add(this.conSplaf1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtTotalOpeTrans);
            this.Controls.Add(this.lblBase51);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtITFRet);
            this.Controls.Add(this.txtComisionRetiro);
            this.Controls.Add(this.lblBase47);
            this.Controls.Add(this.conSolesDolar);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbTransferencia);
            this.Controls.Add(this.dtgCuentasPago);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.grbBase8);
            this.Controls.Add(this.conBusCtaAhoOrigen);
            this.Name = "frmTransferencias";
            this.Text = "Transferencias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransferencias_FormClosed);
            this.Load += new System.EventHandler(this.frmTransferencias_Load);
            this.Controls.SetChildIndex(this.conBusCtaAhoOrigen, 0);
            this.Controls.SetChildIndex(this.grbBase8, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.dtgCuentasPago, 0);
            this.Controls.SetChildIndex(this.grbTransferencia, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conSolesDolar, 0);
            this.Controls.SetChildIndex(this.lblBase47, 0);
            this.Controls.SetChildIndex(this.txtComisionRetiro, 0);
            this.Controls.SetChildIndex(this.txtITFRet, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase51, 0);
            this.Controls.SetChildIndex(this.txtTotalOpeTrans, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.conSplaf1, 0);
            this.Controls.SetChildIndex(this.txtInscripcion, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonto, 0);
            this.conBusCtaAhoOrigen.ResumeLayout(false);
            this.conBusCtaAhoOrigen.PerformLayout();
            this.grbBase8.ResumeLayout(false);
            this.grbBase8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasPago)).EndInit();
            this.grbBase9.ResumeLayout(false);
            this.grbBase9.PerformLayout();
            this.grbTransferencia.ResumeLayout(false);
            this.grbTransferencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAhoOrigen;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase8;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuentaOrigen;
        private GEN.ControlesBase.lblBase lblBase45;
        private GEN.ControlesBase.txtBase txtNumFirOri;
        private GEN.ControlesBase.lblBase lblBase40;
        private GEN.ControlesBase.lblBase lblBase46;
        private GEN.ControlesBase.txtNumRea txtSaldoDisp;
        private GEN.ControlesBase.txtBase txtProductoOrigen;
        private GEN.ControlesBase.lblBase lblBase43;
        private GEN.ControlesBase.cboMoneda cboMonedaOrigen;
        private GEN.ControlesBase.lblBase lblBase48;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.ControlesBase.dtgBase dtgCuentasPago;
        private GEN.ControlesBase.conSplaf conSplaf1;
        private GEN.ControlesBase.txtNumRea txtTotalOpeTrans;
        private GEN.ControlesBase.lblBase lblBase51;
        private GEN.ControlesBase.txtBase txtITFRet;
        private GEN.ControlesBase.txtBase txtComisionRetiro;
        private GEN.ControlesBase.lblBase lblBase47;
        private GEN.ControlesBase.ConSolesDolar conSolesDolar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoTransfer;
        private GEN.ControlesBase.grbBase grbBase9;
        public GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase28;
        private GEN.ControlesBase.lblBase lblBase3;
        public GEN.ControlesBase.txtBase txtEstado;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.grbBase grbTransferencia;
        private GEN.ControlesBase.lblBase lblBase5;
        public GEN.ControlesBase.txtBase txtCodMon;
        public GEN.ControlesBase.txtBase txtCodMod;
        public GEN.ControlesBase.txtBase txtCodAge;
        public GEN.ControlesBase.txtBase txtCodIns;
        public GEN.ControlesBase.txtBase txtNroCta;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtInscripcion;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtMonto;
    }
}