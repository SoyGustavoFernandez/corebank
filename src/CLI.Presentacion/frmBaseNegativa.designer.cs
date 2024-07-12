namespace CLI.Presentacion
{
    partial class frmBaseNegativa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseNegativa));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.dtgBaseNegativa = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdBaseNegativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNomCompletos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtidMotivoBloq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.chcNoCliente = new GEN.ControlesBase.chcBase(this.components);
            this.grbDatos = new GEN.ControlesBase.grbBase(this.components);
            this.cboModuloEdit = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNomRazonSocial = new GEN.ControlesBase.txtBase(this.components);
            this.lblNomRazonSocial = new GEN.ControlesBase.lblBase();
            this.cboTipoPersona = new System.Windows.Forms.ComboBox();
            this.lblTipoPersona = new GEN.ControlesBase.lblBase();
            this.txtApMaterno = new GEN.ControlesBase.txtBase(this.components);
            this.txtApPaterno = new GEN.ControlesBase.txtBase(this.components);
            this.lblMaterno = new GEN.ControlesBase.lblBase();
            this.lblPaterno = new GEN.ControlesBase.lblBase();
            this.cboMotivoBloqueo = new GEN.ControlesBase.cboMotivoBloqueo(this.components);
            this.lblDescripcion = new GEN.ControlesBase.lblBase();
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            this.cboTipoDocumento = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusClienteBN = new GEN.BotonesBase.btnBusCliente();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseNegativa)).BeginInit();
            this.grbDatos.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 35);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Módulo:";
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(83, 32);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(297, 21);
            this.cboModulo.TabIndex = 3;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // dtgBaseNegativa
            // 
            this.dtgBaseNegativa.AllowUserToAddRows = false;
            this.dtgBaseNegativa.AllowUserToDeleteRows = false;
            this.dtgBaseNegativa.AllowUserToResizeColumns = false;
            this.dtgBaseNegativa.AllowUserToResizeRows = false;
            this.dtgBaseNegativa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBaseNegativa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBaseNegativa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBaseNegativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBaseNegativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdBaseNegativa,
            this.dtgtxtIdCli,
            this.dtgtxtIdTipoDocumento,
            this.dtgtxtTipoDocumento,
            this.dtgtxtDocumentoID,
            this.dtgtxtNomCompletos,
            this.dtgtxtNombre,
            this.dtgtxtApellidoPaterno,
            this.dtgtxtApellidoMaterno,
            this.dtgtxtMotivo,
            this.dtgtxtidMotivoBloq,
            this.dtgtxtFechaReg,
            this.dtgtxtIdUsuarioReg,
            this.dtgtxtUsuarioReg,
            this.idTipoPersona,
            this.idModulo});
            this.dtgBaseNegativa.Location = new System.Drawing.Point(10, 76);
            this.dtgBaseNegativa.MultiSelect = false;
            this.dtgBaseNegativa.Name = "dtgBaseNegativa";
            this.dtgBaseNegativa.ReadOnly = true;
            this.dtgBaseNegativa.RowHeadersVisible = false;
            this.dtgBaseNegativa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBaseNegativa.Size = new System.Drawing.Size(492, 138);
            this.dtgBaseNegativa.TabIndex = 4;
            this.dtgBaseNegativa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaseNegativa_CellContentClick);
            this.dtgBaseNegativa.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaseNegativa_RowEnter);
            this.dtgBaseNegativa.SelectionChanged += new System.EventHandler(this.dtgBaseNegativa_SelectionChanged);
            // 
            // dtgtxtIdBaseNegativa
            // 
            this.dtgtxtIdBaseNegativa.DataPropertyName = "idBaseNegativa";
            this.dtgtxtIdBaseNegativa.HeaderText = "idBaseNegativa";
            this.dtgtxtIdBaseNegativa.Name = "dtgtxtIdBaseNegativa";
            this.dtgtxtIdBaseNegativa.ReadOnly = true;
            this.dtgtxtIdBaseNegativa.Visible = false;
            // 
            // dtgtxtIdCli
            // 
            this.dtgtxtIdCli.DataPropertyName = "idCli";
            this.dtgtxtIdCli.HeaderText = "idCli";
            this.dtgtxtIdCli.Name = "dtgtxtIdCli";
            this.dtgtxtIdCli.ReadOnly = true;
            this.dtgtxtIdCli.Visible = false;
            // 
            // dtgtxtIdTipoDocumento
            // 
            this.dtgtxtIdTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.dtgtxtIdTipoDocumento.HeaderText = "idTipoDocumento";
            this.dtgtxtIdTipoDocumento.Name = "dtgtxtIdTipoDocumento";
            this.dtgtxtIdTipoDocumento.ReadOnly = true;
            this.dtgtxtIdTipoDocumento.Visible = false;
            // 
            // dtgtxtTipoDocumento
            // 
            this.dtgtxtTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.dtgtxtTipoDocumento.HeaderText = "Tipo Documento";
            this.dtgtxtTipoDocumento.MinimumWidth = 110;
            this.dtgtxtTipoDocumento.Name = "dtgtxtTipoDocumento";
            this.dtgtxtTipoDocumento.ReadOnly = true;
            // 
            // dtgtxtDocumentoID
            // 
            this.dtgtxtDocumentoID.DataPropertyName = "cDocumentoID";
            this.dtgtxtDocumentoID.HeaderText = "Nro de Documento";
            this.dtgtxtDocumentoID.MinimumWidth = 120;
            this.dtgtxtDocumentoID.Name = "dtgtxtDocumentoID";
            this.dtgtxtDocumentoID.ReadOnly = true;
            // 
            // dtgtxtNomCompletos
            // 
            this.dtgtxtNomCompletos.DataPropertyName = "cNomCompleto";
            this.dtgtxtNomCompletos.FillWeight = 300F;
            this.dtgtxtNomCompletos.HeaderText = "Nombres";
            this.dtgtxtNomCompletos.MinimumWidth = 200;
            this.dtgtxtNomCompletos.Name = "dtgtxtNomCompletos";
            this.dtgtxtNomCompletos.ReadOnly = true;
            // 
            // dtgtxtNombre
            // 
            this.dtgtxtNombre.DataPropertyName = "cNombre";
            this.dtgtxtNombre.HeaderText = "cNombre";
            this.dtgtxtNombre.Name = "dtgtxtNombre";
            this.dtgtxtNombre.ReadOnly = true;
            this.dtgtxtNombre.Visible = false;
            // 
            // dtgtxtApellidoPaterno
            // 
            this.dtgtxtApellidoPaterno.DataPropertyName = "cApellidoPaterno";
            this.dtgtxtApellidoPaterno.HeaderText = "cApellidoPaterno";
            this.dtgtxtApellidoPaterno.Name = "dtgtxtApellidoPaterno";
            this.dtgtxtApellidoPaterno.ReadOnly = true;
            this.dtgtxtApellidoPaterno.Visible = false;
            // 
            // dtgtxtApellidoMaterno
            // 
            this.dtgtxtApellidoMaterno.DataPropertyName = "cApellidoMaterno";
            this.dtgtxtApellidoMaterno.HeaderText = "cApellidoMaterno";
            this.dtgtxtApellidoMaterno.Name = "dtgtxtApellidoMaterno";
            this.dtgtxtApellidoMaterno.ReadOnly = true;
            this.dtgtxtApellidoMaterno.Visible = false;
            // 
            // dtgtxtMotivo
            // 
            this.dtgtxtMotivo.DataPropertyName = "cMotivo";
            this.dtgtxtMotivo.HeaderText = "cMotivo";
            this.dtgtxtMotivo.Name = "dtgtxtMotivo";
            this.dtgtxtMotivo.ReadOnly = true;
            this.dtgtxtMotivo.Visible = false;
            // 
            // dtgtxtidMotivoBloq
            // 
            this.dtgtxtidMotivoBloq.DataPropertyName = "idMotivoBloq";
            this.dtgtxtidMotivoBloq.HeaderText = "idMotivoBloq";
            this.dtgtxtidMotivoBloq.Name = "dtgtxtidMotivoBloq";
            this.dtgtxtidMotivoBloq.ReadOnly = true;
            this.dtgtxtidMotivoBloq.Visible = false;
            // 
            // dtgtxtFechaReg
            // 
            this.dtgtxtFechaReg.DataPropertyName = "dFechaReg";
            this.dtgtxtFechaReg.HeaderText = "dFechaReg";
            this.dtgtxtFechaReg.Name = "dtgtxtFechaReg";
            this.dtgtxtFechaReg.ReadOnly = true;
            this.dtgtxtFechaReg.Visible = false;
            // 
            // dtgtxtIdUsuarioReg
            // 
            this.dtgtxtIdUsuarioReg.DataPropertyName = "idUsuarioReg";
            this.dtgtxtIdUsuarioReg.HeaderText = "idUsuarioReg";
            this.dtgtxtIdUsuarioReg.Name = "dtgtxtIdUsuarioReg";
            this.dtgtxtIdUsuarioReg.ReadOnly = true;
            this.dtgtxtIdUsuarioReg.Visible = false;
            // 
            // dtgtxtUsuarioReg
            // 
            this.dtgtxtUsuarioReg.DataPropertyName = "cUsuarioReg";
            this.dtgtxtUsuarioReg.HeaderText = "cUsuarioReg";
            this.dtgtxtUsuarioReg.Name = "dtgtxtUsuarioReg";
            this.dtgtxtUsuarioReg.ReadOnly = true;
            this.dtgtxtUsuarioReg.Visible = false;
            // 
            // idTipoPersona
            // 
            this.idTipoPersona.DataPropertyName = "idTipoPersona";
            this.idTipoPersona.HeaderText = "idTipoPersona";
            this.idTipoPersona.Name = "idTipoPersona";
            this.idTipoPersona.ReadOnly = true;
            this.idTipoPersona.Visible = false;
            // 
            // idModulo
            // 
            this.idModulo.DataPropertyName = "idModulo";
            this.idModulo.HeaderText = "idModulo";
            this.idModulo.Name = "idModulo";
            this.idModulo.ReadOnly = true;
            this.idModulo.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(101, 532);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(342, 532);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(221, 532);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(431, 532);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // chcNoCliente
            // 
            this.chcNoCliente.AutoSize = true;
            this.chcNoCliente.Enabled = false;
            this.chcNoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcNoCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcNoCliente.Location = new System.Drawing.Point(13, 11);
            this.chcNoCliente.Name = "chcNoCliente";
            this.chcNoCliente.Size = new System.Drawing.Size(127, 17);
            this.chcNoCliente.TabIndex = 20;
            this.chcNoCliente.Text = "NO ES CLIENTE?";
            this.chcNoCliente.UseVisualStyleBackColor = true;
            this.chcNoCliente.CheckedChanged += new System.EventHandler(this.chcCliRem_CheckedChanged);
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.cboModuloEdit);
            this.grbDatos.Controls.Add(this.lblBase3);
            this.grbDatos.Controls.Add(this.txtNomRazonSocial);
            this.grbDatos.Controls.Add(this.lblNomRazonSocial);
            this.grbDatos.Controls.Add(this.cboTipoPersona);
            this.grbDatos.Controls.Add(this.lblTipoPersona);
            this.grbDatos.Controls.Add(this.txtApMaterno);
            this.grbDatos.Controls.Add(this.txtApPaterno);
            this.grbDatos.Controls.Add(this.lblMaterno);
            this.grbDatos.Controls.Add(this.lblPaterno);
            this.grbDatos.Controls.Add(this.cboMotivoBloqueo);
            this.grbDatos.Controls.Add(this.lblDescripcion);
            this.grbDatos.Controls.Add(this.btnBusCliente);
            this.grbDatos.Controls.Add(this.cboTipoDocumento);
            this.grbDatos.Controls.Add(this.chcNoCliente);
            this.grbDatos.Controls.Add(this.lblBase2);
            this.grbDatos.Controls.Add(this.txtDescripcion);
            this.grbDatos.Controls.Add(this.txtNombre);
            this.grbDatos.Controls.Add(this.txtNroDoc);
            this.grbDatos.Controls.Add(this.lblBase32);
            this.grbDatos.Controls.Add(this.lblBase9);
            this.grbDatos.Controls.Add(this.lblBase11);
            this.grbDatos.Location = new System.Drawing.Point(11, 213);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(492, 312);
            this.grbDatos.TabIndex = 56;
            this.grbDatos.TabStop = false;
            // 
            // cboModuloEdit
            // 
            this.cboModuloEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuloEdit.Enabled = false;
            this.cboModuloEdit.FormattingEnabled = true;
            this.cboModuloEdit.Location = new System.Drawing.Point(139, 36);
            this.cboModuloEdit.Name = "cboModuloEdit";
            this.cboModuloEdit.Size = new System.Drawing.Size(219, 21);
            this.cboModuloEdit.TabIndex = 59;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 36);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 58;
            this.lblBase3.Text = "Módulo:";
            // 
            // txtNomRazonSocial
            // 
            this.txtNomRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomRazonSocial.Location = new System.Drawing.Point(139, 137);
            this.txtNomRazonSocial.Name = "txtNomRazonSocial";
            this.txtNomRazonSocial.Size = new System.Drawing.Size(340, 20);
            this.txtNomRazonSocial.TabIndex = 53;
            // 
            // lblNomRazonSocial
            // 
            this.lblNomRazonSocial.AutoSize = true;
            this.lblNomRazonSocial.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNomRazonSocial.ForeColor = System.Drawing.Color.Navy;
            this.lblNomRazonSocial.Location = new System.Drawing.Point(13, 140);
            this.lblNomRazonSocial.Name = "lblNomRazonSocial";
            this.lblNomRazonSocial.Size = new System.Drawing.Size(120, 13);
            this.lblNomRazonSocial.TabIndex = 67;
            this.lblNomRazonSocial.Text = "Nom./Razon Social:";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(139, 62);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(219, 21);
            this.cboTipoPersona.TabIndex = 50;
            this.cboTipoPersona.SelectedIndexChanged += new System.EventHandler(this.cboTipoPersona_SelectedIndexChanged);
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.AutoSize = true;
            this.lblTipoPersona.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoPersona.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoPersona.Location = new System.Drawing.Point(13, 65);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(86, 13);
            this.lblTipoPersona.TabIndex = 65;
            this.lblTipoPersona.Text = "Tipo Persona:";
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApMaterno.Location = new System.Drawing.Point(139, 209);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(180, 20);
            this.txtApMaterno.TabIndex = 56;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApPaterno.Location = new System.Drawing.Point(139, 185);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(180, 20);
            this.txtApPaterno.TabIndex = 55;
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMaterno.ForeColor = System.Drawing.Color.Navy;
            this.lblMaterno.Location = new System.Drawing.Point(13, 212);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(81, 13);
            this.lblMaterno.TabIndex = 61;
            this.lblMaterno.Text = "Ap. Materno:";
            // 
            // lblPaterno
            // 
            this.lblPaterno.AutoSize = true;
            this.lblPaterno.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPaterno.ForeColor = System.Drawing.Color.Navy;
            this.lblPaterno.Location = new System.Drawing.Point(13, 188);
            this.lblPaterno.Name = "lblPaterno";
            this.lblPaterno.Size = new System.Drawing.Size(79, 13);
            this.lblPaterno.TabIndex = 60;
            this.lblPaterno.Text = "Ap. Paterno:";
            // 
            // cboMotivoBloqueo
            // 
            this.cboMotivoBloqueo.FormattingEnabled = true;
            this.cboMotivoBloqueo.Location = new System.Drawing.Point(139, 233);
            this.cboMotivoBloqueo.Name = "cboMotivoBloqueo";
            this.cboMotivoBloqueo.Size = new System.Drawing.Size(340, 21);
            this.cboMotivoBloqueo.TabIndex = 57;
            this.cboMotivoBloqueo.MouseHover += new System.EventHandler(this.cboMotivoBloqueo_MouseHover);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 261);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcion.TabIndex = 58;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(419, 61);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 59;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(139, 87);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(219, 21);
            this.cboTipoDocumento.TabIndex = 51;
            this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumento_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 236);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 52;
            this.lblBase2.Text = "Motivo:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(139, 258);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(340, 44);
            this.txtDescripcion.TabIndex = 58;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(139, 161);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 54;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(139, 113);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 52;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDoc_KeyPress);
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(13, 116);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(105, 13);
            this.lblBase32.TabIndex = 40;
            this.lblBase32.Text = "Nro. Documento:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(13, 91);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(105, 13);
            this.lblBase9.TabIndex = 41;
            this.lblBase9.Text = "Tipo Documento:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(13, 164);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(63, 13);
            this.lblBase11.TabIndex = 46;
            this.lblBase11.Text = "Nombres:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(281, 532);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(161, 532);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 57;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnBusClienteBN);
            this.grbBase1.Location = new System.Drawing.Point(394, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(108, 70);
            this.grbBase1.TabIndex = 58;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Consultar Cliente";
            // 
            // btnBusClienteBN
            // 
            this.btnBusClienteBN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusClienteBN.BackgroundImage")));
            this.btnBusClienteBN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusClienteBN.Location = new System.Drawing.Point(36, 14);
            this.btnBusClienteBN.Name = "btnBusClienteBN";
            this.btnBusClienteBN.Size = new System.Drawing.Size(60, 50);
            this.btnBusClienteBN.TabIndex = 70;
            this.btnBusClienteBN.Text = "Cliente";
            this.btnBusClienteBN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusClienteBN.UseVisualStyleBackColor = true;
            this.btnBusClienteBN.Click += new System.EventHandler(this.btnBusClienteBN_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(10, 3);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(376, 70);
            this.grbBase2.TabIndex = 59;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Filtro por Módulo";
            // 
            // frmBaseNegativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 608);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.dtgBaseNegativa);
            this.Controls.Add(this.cboModulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmBaseNegativa";
            this.Text = "Base Negativa";
            this.Load += new System.EventHandler(this.frmBaseNegativa_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboModulo, 0);
            this.Controls.SetChildIndex(this.dtgBaseNegativa, 0);
            this.Controls.SetChildIndex(this.grbDatos, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseNegativa)).EndInit();
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.dtgBase dtgBaseNegativa;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.chcBase chcNoCliente;
        private GEN.ControlesBase.grbBase grbDatos;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase11;
        public GEN.ControlesBase.txtBase txtNombre;
        public GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.cboTipDocumento cboTipoDocumento;
        public GEN.BotonesBase.btnBusCliente btnBusCliente;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.ControlesBase.lblBase lblDescripcion;
        private GEN.ControlesBase.cboMotivoBloqueo cboMotivoBloqueo;
        private GEN.ControlesBase.lblBase lblMaterno;
        private GEN.ControlesBase.lblBase lblPaterno;
        private GEN.ControlesBase.txtBase txtApMaterno;
        private GEN.ControlesBase.txtBase txtApPaterno;
        private GEN.ControlesBase.lblBase lblTipoPersona;
        private System.Windows.Forms.ComboBox cboTipoPersona;
        private GEN.ControlesBase.txtBase txtNomRazonSocial;
        private GEN.ControlesBase.lblBase lblNomRazonSocial;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.cboModulo cboModuloEdit;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnBusCliente btnBusClienteBN;
        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdBaseNegativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNomCompletos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtidMotivoBloq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModulo;
    }
}

