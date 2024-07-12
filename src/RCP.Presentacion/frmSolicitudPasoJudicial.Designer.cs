namespace RCP.Presentacion
{
    partial class frmSolicitudPasoJudicial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudPasoJudicial));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtgCarteraCreditos = new GEN.ControlesBase.dtgBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNombreCliente = new GEN.ControlesBase.txtNumRea();
            this.conDatCredito1 = new GEN.ControlesBase.conDatCredito();
            this.dtFechaDesembolso = new GEN.ControlesBase.dtLargoBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda();
            this.cboProducto1 = new GEN.ControlesBase.cboProducto();
            this.txtCodSolicitud = new GEN.ControlesBase.txtNumRea();
            this.txtTasaVigente = new GEN.ControlesBase.txtNumRea();
            this.txtNumCuotas = new GEN.ControlesBase.txtNumRea();
            this.txtMonDesembolsado = new GEN.ControlesBase.txtNumRea();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase();
            this.btnMiniCancelEst1 = new GEN.BotonesBase.btnMiniCancelEst();
            this.lblBase44 = new GEN.ControlesBase.lblBase();
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase();
            this.btnQuitDoc = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgrDoc = new GEN.BotonesBase.btnMiniAgregar();
            this.grbBase3 = new GEN.ControlesBase.grbBase();
            this.txtMotivoTransferencia = new GEN.ControlesBase.txtBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lSolJudicial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIntervCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDistrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAnexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDirPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDireccionRecupera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.conDatCredito1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtgCarteraCreditos);
            this.groupBox6.Location = new System.Drawing.Point(7, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(873, 180);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cartera";
            // 
            // dtgCarteraCreditos
            // 
            this.dtgCarteraCreditos.AllowUserToAddRows = false;
            this.dtgCarteraCreditos.AllowUserToDeleteRows = false;
            this.dtgCarteraCreditos.AllowUserToResizeColumns = false;
            this.dtgCarteraCreditos.AllowUserToResizeRows = false;
            this.dtgCarteraCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCarteraCreditos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCarteraCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarteraCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lSolJudicial,
            this.idCuenta,
            this.idCli,
            this.idIntervCre,
            this.idTipoInterv,
            this.cTipoIntervencion,
            this.cNombre,
            this.nAtraso,
            this.cSimbolo,
            this.nSaldoCapital,
            this.nTotalPagar,
            this.cUbigeo,
            this.cTipoDir,
            this.idDireccion,
            this.cDireccion,
            this.cDepartamento,
            this.cProvincia,
            this.cDistrito,
            this.cAnexo,
            this.cObservacion,
            this.lDirPrincipal,
            this.lDireccionRecupera});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCarteraCreditos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCarteraCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCarteraCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCarteraCreditos.MultiSelect = false;
            this.dtgCarteraCreditos.Name = "dtgCarteraCreditos";
            this.dtgCarteraCreditos.ReadOnly = true;
            this.dtgCarteraCreditos.RowHeadersVisible = false;
            this.dtgCarteraCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarteraCreditos.Size = new System.Drawing.Size(867, 161);
            this.dtgCarteraCreditos.TabIndex = 0;
            this.dtgCarteraCreditos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgCarteraCreditos_CellMouseClick);
            this.dtgCarteraCreditos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCarteraCreditos_KeyDown);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtNombreCliente);
            this.grbBase1.Controls.Add(this.conDatCredito1);
            this.grbBase1.Location = new System.Drawing.Point(12, 191);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(868, 113);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle del Crédito";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(56, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(122, 13);
            this.lblBase2.TabIndex = 72;
            this.lblBase2.Text = "Nombre del Cliente:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.FormatoDecimal = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(184, 16);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNombreCliente.nNumDecimales = 2;
            this.txtNombreCliente.nvalor = 0D;
            this.txtNombreCliente.Size = new System.Drawing.Size(370, 20);
            this.txtNombreCliente.TabIndex = 38;
            // 
            // conDatCredito1
            // 
            this.conDatCredito1.Controls.Add(this.dtFechaDesembolso);
            this.conDatCredito1.Controls.Add(this.cboMoneda1);
            this.conDatCredito1.Controls.Add(this.cboProducto1);
            this.conDatCredito1.Controls.Add(this.txtCodSolicitud);
            this.conDatCredito1.Controls.Add(this.txtTasaVigente);
            this.conDatCredito1.Controls.Add(this.txtNumCuotas);
            this.conDatCredito1.Controls.Add(this.txtMonDesembolsado);
            this.conDatCredito1.Location = new System.Drawing.Point(41, 34);
            this.conDatCredito1.Name = "conDatCredito1";
            this.conDatCredito1.Size = new System.Drawing.Size(596, 73);
            this.conDatCredito1.TabIndex = 7;
            // 
            // dtFechaDesembolso
            // 
            this.dtFechaDesembolso.Enabled = false;
            this.dtFechaDesembolso.Location = new System.Drawing.Point(143, 28);
            this.dtFechaDesembolso.Name = "dtFechaDesembolso";
            this.dtFechaDesembolso.Size = new System.Drawing.Size(195, 20);
            this.dtFechaDesembolso.TabIndex = 40;
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DisplayMember = "cMoneda";
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(405, 50);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(108, 21);
            this.cboMoneda1.TabIndex = 39;
            this.cboMoneda1.ValueMember = "idMoneda";
            // 
            // cboProducto1
            // 
            this.cboProducto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto1.DropDownWidth = 350;
            this.cboProducto1.Enabled = false;
            this.cboProducto1.FormattingEnabled = true;
            this.cboProducto1.Location = new System.Drawing.Point(92, 73);
            this.cboProducto1.Name = "cboProducto1";
            this.cboProducto1.Size = new System.Drawing.Size(421, 21);
            this.cboProducto1.TabIndex = 38;
            // 
            // txtCodSolicitud
            // 
            this.txtCodSolicitud.Enabled = false;
            this.txtCodSolicitud.FormatoDecimal = false;
            this.txtCodSolicitud.Location = new System.Drawing.Point(448, 28);
            this.txtCodSolicitud.Name = "txtCodSolicitud";
            this.txtCodSolicitud.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCodSolicitud.nNumDecimales = 4;
            this.txtCodSolicitud.nvalor = 0D;
            this.txtCodSolicitud.Size = new System.Drawing.Size(65, 20);
            this.txtCodSolicitud.TabIndex = 37;
            // 
            // txtTasaVigente
            // 
            this.txtTasaVigente.Enabled = false;
            this.txtTasaVigente.FormatoDecimal = false;
            this.txtTasaVigente.Location = new System.Drawing.Point(143, 50);
            this.txtTasaVigente.Name = "txtTasaVigente";
            this.txtTasaVigente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaVigente.nNumDecimales = 4;
            this.txtTasaVigente.nvalor = 0D;
            this.txtTasaVigente.Size = new System.Drawing.Size(195, 20);
            this.txtTasaVigente.TabIndex = 37;
            // 
            // txtNumCuotas
            // 
            this.txtNumCuotas.CausesValidation = false;
            this.txtNumCuotas.Enabled = false;
            this.txtNumCuotas.FormatoDecimal = false;
            this.txtNumCuotas.Location = new System.Drawing.Point(448, 6);
            this.txtNumCuotas.Name = "txtNumCuotas";
            this.txtNumCuotas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumCuotas.nNumDecimales = 0;
            this.txtNumCuotas.nvalor = 0D;
            this.txtNumCuotas.Size = new System.Drawing.Size(65, 20);
            this.txtNumCuotas.TabIndex = 37;
            // 
            // txtMonDesembolsado
            // 
            this.txtMonDesembolsado.Enabled = false;
            this.txtMonDesembolsado.FormatoDecimal = false;
            this.txtMonDesembolsado.Location = new System.Drawing.Point(143, 6);
            this.txtMonDesembolsado.Name = "txtMonDesembolsado";
            this.txtMonDesembolsado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonDesembolsado.nNumDecimales = 2;
            this.txtMonDesembolsado.nvalor = 0D;
            this.txtMonDesembolsado.Size = new System.Drawing.Size(195, 20);
            this.txtMonDesembolsado.TabIndex = 37;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(737, 478);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(803, 478);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniCancelEst1);
            this.grbBase2.Controls.Add(this.lblBase44);
            this.grbBase2.Controls.Add(this.dtgDocumentos);
            this.grbBase2.Controls.Add(this.btnQuitDoc);
            this.grbBase2.Controls.Add(this.btnAgrDoc);
            this.grbBase2.Location = new System.Drawing.Point(10, 310);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(446, 162);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Agregar Archivos";
            // 
            // btnMiniCancelEst1
            // 
            this.btnMiniCancelEst1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst1.BackgroundImage")));
            this.btnMiniCancelEst1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst1.Location = new System.Drawing.Point(401, 122);
            this.btnMiniCancelEst1.Name = "btnMiniCancelEst1";
            this.btnMiniCancelEst1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst1.TabIndex = 17;
            this.btnMiniCancelEst1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst1.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst1.Click += new System.EventHandler(this.btnMiniCancelEst1_Click);
            // 
            // lblBase44
            // 
            this.lblBase44.AutoSize = true;
            this.lblBase44.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase44.ForeColor = System.Drawing.Color.Navy;
            this.lblBase44.Location = new System.Drawing.Point(6, 24);
            this.lblBase44.Name = "lblBase44";
            this.lblBase44.Size = new System.Drawing.Size(136, 13);
            this.lblBase44.TabIndex = 71;
            this.lblBase44.Text = "Documentos adjuntos:";
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Location = new System.Drawing.Point(9, 40);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(386, 110);
            this.dtgDocumentos.TabIndex = 70;
            // 
            // btnQuitDoc
            // 
            this.btnQuitDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitDoc.BackgroundImage")));
            this.btnQuitDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitDoc.Location = new System.Drawing.Point(401, 73);
            this.btnQuitDoc.Name = "btnQuitDoc";
            this.btnQuitDoc.Size = new System.Drawing.Size(36, 28);
            this.btnQuitDoc.TabIndex = 69;
            this.btnQuitDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitDoc.UseVisualStyleBackColor = true;
            this.btnQuitDoc.Click += new System.EventHandler(this.btnQuitDoc_Click);
            // 
            // btnAgrDoc
            // 
            this.btnAgrDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgrDoc.BackgroundImage")));
            this.btnAgrDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgrDoc.Location = new System.Drawing.Point(401, 40);
            this.btnAgrDoc.Name = "btnAgrDoc";
            this.btnAgrDoc.Size = new System.Drawing.Size(36, 28);
            this.btnAgrDoc.TabIndex = 68;
            this.btnAgrDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgrDoc.UseVisualStyleBackColor = true;
            this.btnAgrDoc.Click += new System.EventHandler(this.btnAgrDoc_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtMotivoTransferencia);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Location = new System.Drawing.Point(462, 310);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(418, 162);
            this.grbBase3.TabIndex = 16;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Motivo Pase a Judicial";
            // 
            // txtMotivoTransferencia
            // 
            this.txtMotivoTransferencia.Location = new System.Drawing.Point(6, 40);
            this.txtMotivoTransferencia.Multiline = true;
            this.txtMotivoTransferencia.Name = "txtMotivoTransferencia";
            this.txtMotivoTransferencia.Size = new System.Drawing.Size(406, 110);
            this.txtMotivoTransferencia.TabIndex = 72;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Justificación:";
            // 
            // lSolJudicial
            // 
            this.lSolJudicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lSolJudicial.DataPropertyName = "lSolJudicial";
            this.lSolJudicial.FillWeight = 50F;
            this.lSolJudicial.HeaderText = "Solicitado";
            this.lSolJudicial.Name = "lSolJudicial";
            this.lSolJudicial.ReadOnly = true;
            this.lSolJudicial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lSolJudicial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lSolJudicial.Width = 77;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 66;
            // 
            // idCli
            // 
            this.idCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "Cliente";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Width = 64;
            // 
            // idIntervCre
            // 
            this.idIntervCre.DataPropertyName = "idIntervCre";
            this.idIntervCre.HeaderText = "idIntervCre";
            this.idIntervCre.Name = "idIntervCre";
            this.idIntervCre.ReadOnly = true;
            this.idIntervCre.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "Tipo";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            this.cTipoIntervencion.Width = 51;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Nombre Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 95;
            // 
            // nAtraso
            // 
            this.nAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 62;
            // 
            // cSimbolo
            // 
            this.cSimbolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.HeaderText = "Moneda";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            this.cSimbolo.Width = 71;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 87;
            // 
            // nTotalPagar
            // 
            this.nTotalPagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nTotalPagar.DataPropertyName = "nTotalPagar";
            this.nTotalPagar.HeaderText = "Total Pago";
            this.nTotalPagar.Name = "nTotalPagar";
            this.nTotalPagar.ReadOnly = true;
            this.nTotalPagar.Width = 76;
            // 
            // cUbigeo
            // 
            this.cUbigeo.DataPropertyName = "cUbigeo";
            this.cUbigeo.HeaderText = "Ubigeo";
            this.cUbigeo.Name = "cUbigeo";
            this.cUbigeo.ReadOnly = true;
            this.cUbigeo.Visible = false;
            // 
            // cTipoDir
            // 
            this.cTipoDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoDir.DataPropertyName = "cTipoDir";
            this.cTipoDir.HeaderText = "Tipo Dir.";
            this.cTipoDir.Name = "cTipoDir";
            this.cTipoDir.ReadOnly = true;
            this.cTipoDir.Width = 51;
            // 
            // idDireccion
            // 
            this.idDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDireccion.DataPropertyName = "idDireccion";
            this.idDireccion.HeaderText = "idDireccion";
            this.idDireccion.Name = "idDireccion";
            this.idDireccion.ReadOnly = true;
            this.idDireccion.Visible = false;
            this.idDireccion.Width = 83;
            // 
            // cDireccion
            // 
            this.cDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "Direccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Width = 75;
            // 
            // cDepartamento
            // 
            this.cDepartamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDepartamento.DataPropertyName = "cDepartamento";
            this.cDepartamento.HeaderText = "Departamento";
            this.cDepartamento.Name = "cDepartamento";
            this.cDepartamento.ReadOnly = true;
            this.cDepartamento.Width = 99;
            // 
            // cProvincia
            // 
            this.cProvincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cProvincia.DataPropertyName = "cProvincia";
            this.cProvincia.HeaderText = "Provincia";
            this.cProvincia.Name = "cProvincia";
            this.cProvincia.ReadOnly = true;
            this.cProvincia.Width = 75;
            // 
            // cDistrito
            // 
            this.cDistrito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDistrito.DataPropertyName = "cDistrito";
            this.cDistrito.HeaderText = "Distrito";
            this.cDistrito.Name = "cDistrito";
            this.cDistrito.ReadOnly = true;
            this.cDistrito.Width = 64;
            // 
            // cAnexo
            // 
            this.cAnexo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cAnexo.DataPropertyName = "cAnexo";
            this.cAnexo.HeaderText = "Anexo";
            this.cAnexo.Name = "cAnexo";
            this.cAnexo.ReadOnly = true;
            this.cAnexo.Width = 62;
            // 
            // cObservacion
            // 
            this.cObservacion.DataPropertyName = "cObservacion";
            this.cObservacion.HeaderText = "cObservacion";
            this.cObservacion.Name = "cObservacion";
            this.cObservacion.ReadOnly = true;
            this.cObservacion.Visible = false;
            // 
            // lDirPrincipal
            // 
            this.lDirPrincipal.DataPropertyName = "lDirPrincipal";
            this.lDirPrincipal.HeaderText = "lDirPrincipal";
            this.lDirPrincipal.Name = "lDirPrincipal";
            this.lDirPrincipal.ReadOnly = true;
            this.lDirPrincipal.Visible = false;
            // 
            // lDireccionRecupera
            // 
            this.lDireccionRecupera.DataPropertyName = "lDireccionRecupera";
            this.lDireccionRecupera.HeaderText = "lDireccionRecupera";
            this.lDireccionRecupera.Name = "lDireccionRecupera";
            this.lDireccionRecupera.ReadOnly = true;
            this.lDireccionRecupera.Visible = false;
            // 
            // frmSolicitudPasoJudicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 558);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.groupBox6);
            this.Name = "frmSolicitudPasoJudicial";
            this.Text = "Solicitud Paso a Judicial";
            this.Load += new System.EventHandler(this.frmSolicitudPasoJudicial_Load);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.conDatCredito1.ResumeLayout(false);
            this.conDatCredito1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private GEN.ControlesBase.dtgBase dtgCarteraCreditos;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.conDatCredito conDatCredito1;
        private GEN.ControlesBase.dtLargoBase dtFechaDesembolso;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.cboProducto cboProducto1;
        private GEN.ControlesBase.txtNumRea txtCodSolicitud;
        private GEN.ControlesBase.txtNumRea txtTasaVigente;
        private GEN.ControlesBase.txtNumRea txtNumCuotas;
        private GEN.ControlesBase.txtNumRea txtMonDesembolsado;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase44;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.BotonesBase.btnMiniQuitar btnQuitDoc;
        private GEN.BotonesBase.btnMiniAgregar btnAgrDoc;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtMotivoTransferencia;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtNombreCliente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSolJudicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIntervCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDistrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAnexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn lDirPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn lDireccionRecupera;
    }
}