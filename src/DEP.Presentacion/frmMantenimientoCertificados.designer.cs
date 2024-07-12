namespace DEP.Presentacion
{
    partial class frmMantenimientoCertificados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCertificados));
            this.conBusCtaAho1 = new GEN.ControlesBase.conBusCtaAho();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniCancelar1 = new GEN.BotonesBase.btnMiniCancelar();
            this.btnMiniAceptar1 = new GEN.BotonesBase.btnMiniAceptar();
            this.txtCBNumCerti = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtNumFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.cboEstado = new GEN.ControlesBase.cboBase(this.components);
            this.dtgCertificado = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalleVal = new GEN.ControlesBase.dtgBase(this.components);
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleVal)).BeginInit();
            this.tbcBase1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaAho1
            // 
            this.conBusCtaAho1.Location = new System.Drawing.Point(12, 4);
            this.conBusCtaAho1.Name = "conBusCtaAho1";
            this.conBusCtaAho1.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho1.TabIndex = 2;
            this.conBusCtaAho1.ClicBusCta += new System.EventHandler(this.conBusCtaAho1_ClicBusCta);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(316, 432);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 43;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(444, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(507, 432);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 40;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(380, 432);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 39;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Enabled = false;
            this.btnBusqueda.Location = new System.Drawing.Point(19, 376);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 44;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniCancelar1);
            this.grbBase1.Controls.Add(this.btnMiniAceptar1);
            this.grbBase1.Controls.Add(this.txtCBNumCerti);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtNumFinal);
            this.grbBase1.Controls.Add(this.txtNumSerie);
            this.grbBase1.Controls.Add(this.txtNumInicio);
            this.grbBase1.Location = new System.Drawing.Point(92, 343);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(475, 83);
            this.grbBase1.TabIndex = 51;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos:";
            // 
            // btnMiniCancelar1
            // 
            this.btnMiniCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelar1.BackgroundImage")));
            this.btnMiniCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelar1.Enabled = false;
            this.btnMiniCancelar1.Location = new System.Drawing.Point(372, 47);
            this.btnMiniCancelar1.Name = "btnMiniCancelar1";
            this.btnMiniCancelar1.Size = new System.Drawing.Size(24, 22);
            this.btnMiniCancelar1.TabIndex = 28;
            this.btnMiniCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelar1.UseVisualStyleBackColor = true;
            this.btnMiniCancelar1.Click += new System.EventHandler(this.btnMiniCancelar1_Click);
            // 
            // btnMiniAceptar1
            // 
            this.btnMiniAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAceptar1.BackgroundImage")));
            this.btnMiniAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAceptar1.Enabled = false;
            this.btnMiniAceptar1.Location = new System.Drawing.Point(345, 47);
            this.btnMiniAceptar1.Name = "btnMiniAceptar1";
            this.btnMiniAceptar1.Size = new System.Drawing.Size(24, 22);
            this.btnMiniAceptar1.TabIndex = 26;
            this.btnMiniAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAceptar1.UseVisualStyleBackColor = true;
            this.btnMiniAceptar1.Click += new System.EventHandler(this.btnMiniAceptar1_Click);
            // 
            // txtCBNumCerti
            // 
            this.txtCBNumCerti.Enabled = false;
            this.txtCBNumCerti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBNumCerti.Location = new System.Drawing.Point(220, 48);
            this.txtCBNumCerti.Name = "txtCBNumCerti";
            this.txtCBNumCerti.Size = new System.Drawing.Size(107, 22);
            this.txtCBNumCerti.TabIndex = 25;
            this.txtCBNumCerti.Text = "000000";
            this.txtCBNumCerti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCBNumCerti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBNumCerti_KeyPress);
            this.txtCBNumCerti.Validated += new System.EventHandler(this.txtCBNumCerti_Validated);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(81, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(116, 13);
            this.lblBase1.TabIndex = 27;
            this.lblBase1.Text = "Nro de Certificado:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(5, 24);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(66, 13);
            this.lblBase8.TabIndex = 24;
            this.lblBase8.Text = "Nro Serie:";
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumFinal.Enabled = false;
            this.txtNumFinal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFinal.Location = new System.Drawing.Point(345, 20);
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.Size = new System.Drawing.Size(108, 22);
            this.txtNumFinal.TabIndex = 23;
            this.txtNumFinal.Text = "0000001";
            this.txtNumFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumSerie
            // 
            this.txtNumSerie.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumSerie.Enabled = false;
            this.txtNumSerie.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumSerie.Location = new System.Drawing.Point(80, 19);
            this.txtNumSerie.Name = "txtNumSerie";
            this.txtNumSerie.Size = new System.Drawing.Size(118, 22);
            this.txtNumSerie.TabIndex = 21;
            this.txtNumSerie.Text = "0000001";
            this.txtNumSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumInicio
            // 
            this.txtNumInicio.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumInicio.Enabled = false;
            this.txtNumInicio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumInicio.Location = new System.Drawing.Point(220, 20);
            this.txtNumInicio.Name = "txtNumInicio";
            this.txtNumInicio.Size = new System.Drawing.Size(107, 22);
            this.txtNumInicio.TabIndex = 22;
            this.txtNumInicio.Text = "0000001";
            this.txtNumInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.chcBase1);
            this.tabPage1.Controls.Add(this.cboEstado);
            this.tabPage1.Controls.Add(this.dtgCertificado);
            this.tabPage1.Controls.Add(this.dtgDetalleVal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 144);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Certificado";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 6);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(142, 13);
            this.lblBase4.TabIndex = 55;
            this.lblBase4.Text = "Estado de la Chequera:";
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Enabled = false;
            this.chcBase1.ForeColor = System.Drawing.Color.Red;
            this.chcBase1.Location = new System.Drawing.Point(486, 126);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 54;
            this.chcBase1.Text = "Anular";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged_1);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Enabled = false;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(6, 22);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(153, 21);
            this.cboEstado.TabIndex = 53;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged_1);
            // 
            // dtgCertificado
            // 
            this.dtgCertificado.AllowUserToAddRows = false;
            this.dtgCertificado.AllowUserToDeleteRows = false;
            this.dtgCertificado.AllowUserToResizeColumns = false;
            this.dtgCertificado.AllowUserToResizeRows = false;
            this.dtgCertificado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCertificado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCertificado.Location = new System.Drawing.Point(5, 48);
            this.dtgCertificado.MultiSelect = false;
            this.dtgCertificado.Name = "dtgCertificado";
            this.dtgCertificado.ReadOnly = true;
            this.dtgCertificado.RowHeadersVisible = false;
            this.dtgCertificado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCertificado.Size = new System.Drawing.Size(154, 72);
            this.dtgCertificado.TabIndex = 52;
            this.dtgCertificado.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgCertificado_CurrentCellDirtyStateChanged);
            this.dtgCertificado.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCertificado_RowEnter);
            // 
            // dtgDetalleVal
            // 
            this.dtgDetalleVal.AllowUserToAddRows = false;
            this.dtgDetalleVal.AllowUserToDeleteRows = false;
            this.dtgDetalleVal.AllowUserToResizeColumns = false;
            this.dtgDetalleVal.AllowUserToResizeRows = false;
            this.dtgDetalleVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleVal.Location = new System.Drawing.Point(165, 48);
            this.dtgDetalleVal.MultiSelect = false;
            this.dtgDetalleVal.Name = "dtgDetalleVal";
            this.dtgDetalleVal.ReadOnly = true;
            this.dtgDetalleVal.RowHeadersVisible = false;
            this.dtgDetalleVal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleVal.Size = new System.Drawing.Size(377, 72);
            this.dtgDetalleVal.TabIndex = 51;
            this.dtgDetalleVal.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_CellEndEdit);
            this.dtgDetalleVal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_CellValueChanged);
            this.dtgDetalleVal.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDetalleVal_CurrentCellDirtyStateChanged);
            this.dtgDetalleVal.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_RowEnter);
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(15, 116);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(556, 170);
            this.tbcBase1.TabIndex = 52;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbBase4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 144);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos de Cliente";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.dtgIntervinientes);
            this.grbBase4.Location = new System.Drawing.Point(5, 3);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(537, 119);
            this.grbBase4.TabIndex = 89;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Intervinientes de Cuenta:";
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
            this.lCliAfeITF});
            this.dtgIntervinientes.Location = new System.Drawing.Point(3, 16);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(530, 98);
            this.dtgIntervinientes.TabIndex = 6;
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
            this.idSolicitud.FillWeight = 50F;
            this.idSolicitud.HeaderText = "Cuenta";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 80F;
            this.cDocumentoID.HeaderText = "Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 250F;
            this.cNombre.HeaderText = "Nombre Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "Interviniente";
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
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 289);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 54;
            this.lblBase2.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(14, 305);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(555, 35);
            this.txtMotivo.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(17, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 55;
            this.label1.Text = "Ver Valorados Generados:";
            // 
            // frmMantenimientoCertificados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 512);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.conBusCtaAho1);
            this.Name = "frmMantenimientoCertificados";
            this.Text = "Mantenimiento de Certificados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMantenimientoCertificados_FormClosed);
            this.Load += new System.EventHandler(this.frmMantenimientoCertificados_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCertificado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleVal)).EndInit();
            this.tbcBase1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho1;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumFinal;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumSerie;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumInicio;
        private GEN.BotonesBase.btnMiniCancelar btnMiniCancelar1;
        private GEN.BotonesBase.btnMiniAceptar btnMiniAceptar1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNumCerti;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.dtgBase dtgCertificado;
        private GEN.ControlesBase.dtgBase dtgDetalleVal;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.cboBase cboEstado;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}