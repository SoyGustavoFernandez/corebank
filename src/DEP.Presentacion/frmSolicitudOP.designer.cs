namespace DEP.Presentacion
{
    partial class frmSolicitudOP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudOP));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumFirmas = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboLimitesVal = new GEN.ControlesBase.cboLimitesVal(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.nudNroTalon = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboModSolicitud = new GEN.ControlesBase.cboBase(this.components);
            this.cboModPago = new GEN.ControlesBase.cboBase(this.components);
            this.txtDescripcionSol = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReqFirma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conBusCtaAho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.grbBase6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroTalon)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Location = new System.Drawing.Point(8, 7);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(580, 114);
            this.conBusCtaAho.TabIndex = 3;
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
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbFirma.Location = new System.Drawing.Point(499, 41);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(215, 137);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIntervinientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoInterv,
            this.idSolicitud,
            this.cTipoDocumento,
            this.cDocumentoID,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF,
            this.isReqFirma,
            this.idTipoDocumento});
            this.dtgIntervinientes.Location = new System.Drawing.Point(6, 21);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(490, 157);
            this.dtgIntervinientes.TabIndex = 3;
            this.dtgIntervinientes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntervinientes_CellValueChanged);
            this.dtgIntervinientes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgIntervinientes_CurrentCellDirtyStateChanged);
            this.dtgIntervinientes.SelectionChanged += new System.EventHandler(this.dtgIntervinientes_SelectionChanged);
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.txtNumFirmas);
            this.grbBase6.Controls.Add(this.lblBase2);
            this.grbBase6.Controls.Add(this.ptbFirma);
            this.grbBase6.Controls.Add(this.dtgIntervinientes);
            this.grbBase6.Location = new System.Drawing.Point(8, 172);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(720, 192);
            this.grbBase6.TabIndex = 88;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "INTERVINIENTES DE LA CUENTA";
            // 
            // txtNumFirmas
            // 
            this.txtNumFirmas.Enabled = false;
            this.txtNumFirmas.Location = new System.Drawing.Point(645, 19);
            this.txtNumFirmas.Name = "txtNumFirmas";
            this.txtNumFirmas.Size = new System.Drawing.Size(69, 20);
            this.txtNumFirmas.TabIndex = 92;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(499, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(142, 13);
            this.lblBase2.TabIndex = 93;
            this.lblBase2.Text = "Nro Firmas Requeridos:";
            // 
            // cboLimitesVal
            // 
            this.cboLimitesVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimitesVal.FormattingEnabled = true;
            this.cboLimitesVal.Location = new System.Drawing.Point(256, 375);
            this.cboLimitesVal.Name = "cboLimitesVal";
            this.cboLimitesVal.Size = new System.Drawing.Size(136, 21);
            this.cboLimitesVal.TabIndex = 90;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(186, 379);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(67, 13);
            this.lblBase1.TabIndex = 89;
            this.lblBase1.Text = "Canti.O/P:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(13, 379);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(95, 13);
            this.lblBase8.TabIndex = 91;
            this.lblBase8.Text = "Nro Talonarios:";
            // 
            // nudNroTalon
            // 
            this.nudNroTalon.Location = new System.Drawing.Point(111, 375);
            this.nudNroTalon.Name = "nudNroTalon";
            this.nudNroTalon.Size = new System.Drawing.Size(50, 20);
            this.nudNroTalon.TabIndex = 92;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 414);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(121, 13);
            this.lblBase3.TabIndex = 93;
            this.lblBase3.Text = "Modalidad Solicitud:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(408, 379);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(121, 13);
            this.lblBase4.TabIndex = 94;
            this.lblBase4.Text = "Modalidad Pago OP:";
            // 
            // cboModSolicitud
            // 
            this.cboModSolicitud.FormattingEnabled = true;
            this.cboModSolicitud.Location = new System.Drawing.Point(136, 410);
            this.cboModSolicitud.Name = "cboModSolicitud";
            this.cboModSolicitud.Size = new System.Drawing.Size(140, 21);
            this.cboModSolicitud.TabIndex = 95;
            this.cboModSolicitud.SelectedIndexChanged += new System.EventHandler(this.cboModSolicitud_SelectedIndexChanged);
            // 
            // cboModPago
            // 
            this.cboModPago.FormattingEnabled = true;
            this.cboModPago.Location = new System.Drawing.Point(532, 375);
            this.cboModPago.Name = "cboModPago";
            this.cboModPago.Size = new System.Drawing.Size(190, 21);
            this.cboModPago.TabIndex = 96;
            // 
            // txtDescripcionSol
            // 
            this.txtDescripcionSol.Enabled = false;
            this.txtDescripcionSol.Location = new System.Drawing.Point(367, 410);
            this.txtDescripcionSol.Name = "txtDescripcionSol";
            this.txtDescripcionSol.Size = new System.Drawing.Size(355, 20);
            this.txtDescripcionSol.TabIndex = 97;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(469, 450);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 98;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(597, 450);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 99;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(661, 450);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 100;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboTipoCuenta);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Location = new System.Drawing.Point(8, 115);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(720, 43);
            this.grbBase2.TabIndex = 107;
            this.grbBase2.TabStop = false;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(287, 414);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 108;
            this.lblBase9.Text = "Descripción:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(8, 361);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(720, 83);
            this.grbBase3.TabIndex = 108;
            this.grbBase3.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(533, 450);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 109;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(288, 134);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 103;
            this.lblBase7.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(346, 130);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(120, 21);
            this.cboMoneda.TabIndex = 102;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(5, 20);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 104;
            this.lblBase6.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(68, 16);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(195, 20);
            this.txtProducto.TabIndex = 101;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(469, 20);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 105;
            this.lblBase5.Text = "Tipo de Cuenta:";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(569, 16);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(145, 21);
            this.cboTipoCuenta.TabIndex = 106;
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
            this.idSolicitud.HeaderText = "CUENTA";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "TIPO DOC.";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            this.cTipoDocumento.Width = 45;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.HeaderText = "DOCUMENTO";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            this.cDocumentoID.Width = 80;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "NOMBRE CLIENTE";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 190;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "INTERV.";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            this.cTipoIntervencion.Width = 107;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lCliAfeITF.Visible = false;
            this.lCliAfeITF.Width = 5;
            // 
            // isReqFirma
            // 
            this.isReqFirma.DataPropertyName = "isReqFirma";
            this.isReqFirma.HeaderText = "RECOGER";
            this.isReqFirma.Name = "isReqFirma";
            this.isReqFirma.ReadOnly = true;
            this.isReqFirma.Width = 65;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // frmSolicitudOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 528);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtDescripcionSol);
            this.Controls.Add(this.cboModPago);
            this.Controls.Add(this.cboModSolicitud);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.nudNroTalon);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.cboLimitesVal);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmSolicitudOP";
            this.Text = "Solicitud de Ordenes de Pago";
            this.Load += new System.EventHandler(this.frmSolicitudOP_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboLimitesVal, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.nudNroTalon, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboModSolicitud, 0);
            this.Controls.SetChildIndex(this.cboModPago, 0);
            this.Controls.SetChildIndex(this.txtDescripcionSol, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroTalon)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.PictureBox ptbFirma;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.cboLimitesVal cboLimitesVal;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtNumFirmas;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.nudBase nudNroTalon;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboModSolicitud;
        private GEN.ControlesBase.cboBase cboModPago;
        private GEN.ControlesBase.txtBase txtDescripcionSol;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReqFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
    }
}