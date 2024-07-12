namespace SPL.Presentacion
{
    partial class frmPep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPep));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtInstitucion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtCargo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtPorcentaje = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.dtgFamiliares = new GEN.ControlesBase.dtgBase(this.components);
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cApePaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cApeMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNumDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdVinculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsFamiliaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.chConfirm = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipDocumento1 = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtDocumento = new GEN.ControlesBase.txtCBDNI(this.components);
            this.txtMaterno = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtPaterno = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtNombres = new GEN.ControlesBase.txtCBLetra(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.dtFecNac = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtFechaFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtFechaIni = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsFamiliaBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(71, 65);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(63, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nombres:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(29, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Apellido Paterno:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(365, 39);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(77, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Documento:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 83);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(129, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Fecha de nacimiento:";
            // 
            // txtInstitucion
            // 
            this.txtInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInstitucion.Location = new System.Drawing.Point(86, 19);
            this.txtInstitucion.MaxLength = 1000;
            this.txtInstitucion.Name = "txtInstitucion";
            this.txtInstitucion.Size = new System.Drawing.Size(341, 20);
            this.txtInstitucion.TabIndex = 0;
            this.txtInstitucion.Tag = "Nombre de la Institución";
            this.txtInstitucion.TextChanged += new System.EventHandler(this.txtInstitucion_TextChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(71, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Institución:";
            // 
            // txtCargo
            // 
            this.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Location = new System.Drawing.Point(86, 41);
            this.txtCargo.MaxLength = 1000;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(341, 20);
            this.txtCargo.TabIndex = 1;
            this.txtCargo.Tag = "Cargo";
            this.txtCargo.TextChanged += new System.EventHandler(this.txtCargo_TextChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 44);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Cargo:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(436, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(136, 13);
            this.lblBase7.TabIndex = 8;
            this.lblBase7.Text = "Fecha de inicio cargo :";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(436, 44);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(117, 13);
            this.lblBase8.TabIndex = 10;
            this.lblBase8.Text = "Fecha de fin cargo:";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorcentaje.Enabled = false;
            this.txtPorcentaje.Location = new System.Drawing.Point(278, 68);
            this.txtPorcentaje.MaxLength = 1000;
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(389, 20);
            this.txtPorcentaje.TabIndex = 7;
            this.txtPorcentaje.Tag = "Nombre de empresa";
            this.txtPorcentaje.TextChanged += new System.EventHandler(this.txtPorcentaje_TextChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(166, 71);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(111, 13);
            this.lblBase9.TabIndex = 6;
            this.lblBase9.Text = "Nombre empresa:";
            // 
            // dtgFamiliares
            // 
            this.dtgFamiliares.AllowUserToAddRows = false;
            this.dtgFamiliares.AllowUserToDeleteRows = false;
            this.dtgFamiliares.AllowUserToResizeColumns = false;
            this.dtgFamiliares.AllowUserToResizeRows = false;
            this.dtgFamiliares.AutoGenerateColumns = false;
            this.dtgFamiliares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFamiliares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFamiliares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDescripcion,
            this.cNombres,
            this.cApePaterno,
            this.cApeMaterno,
            this.cTipoDoc,
            this.nNumDoc,
            this.nIdVinculo,
            this.idFam,
            this.idTipoDoc,
            this.Column1});
            this.dtgFamiliares.DataSource = this.clsFamiliaBindingSource;
            this.dtgFamiliares.Location = new System.Drawing.Point(7, 241);
            this.dtgFamiliares.MultiSelect = false;
            this.dtgFamiliares.Name = "dtgFamiliares";
            this.dtgFamiliares.ReadOnly = true;
            this.dtgFamiliares.RowHeadersVisible = false;
            this.dtgFamiliares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFamiliares.Size = new System.Drawing.Size(609, 144);
            this.dtgFamiliares.TabIndex = 3;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Tipo Vínculo";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cNombres
            // 
            this.cNombres.DataPropertyName = "cNombres";
            this.cNombres.HeaderText = "Nombres";
            this.cNombres.Name = "cNombres";
            this.cNombres.ReadOnly = true;
            // 
            // cApePaterno
            // 
            this.cApePaterno.DataPropertyName = "cApePaterno";
            this.cApePaterno.HeaderText = "Apellido Paterno";
            this.cApePaterno.Name = "cApePaterno";
            this.cApePaterno.ReadOnly = true;
            // 
            // cApeMaterno
            // 
            this.cApeMaterno.DataPropertyName = "cApeMaterno";
            this.cApeMaterno.HeaderText = "Apellido Materno";
            this.cApeMaterno.Name = "cApeMaterno";
            this.cApeMaterno.ReadOnly = true;
            // 
            // cTipoDoc
            // 
            this.cTipoDoc.DataPropertyName = "cTipoDoc";
            this.cTipoDoc.HeaderText = "Tipo Documento";
            this.cTipoDoc.Name = "cTipoDoc";
            this.cTipoDoc.ReadOnly = true;
            // 
            // nNumDoc
            // 
            this.nNumDoc.DataPropertyName = "nNumDoc";
            this.nNumDoc.HeaderText = "Nro Documento";
            this.nNumDoc.Name = "nNumDoc";
            this.nNumDoc.ReadOnly = true;
            // 
            // nIdVinculo
            // 
            this.nIdVinculo.DataPropertyName = "nIdVinculo";
            this.nIdVinculo.HeaderText = "nIdVinculo";
            this.nIdVinculo.Name = "nIdVinculo";
            this.nIdVinculo.ReadOnly = true;
            this.nIdVinculo.Visible = false;
            // 
            // idFam
            // 
            this.idFam.DataPropertyName = "idFam";
            this.idFam.HeaderText = "idFam";
            this.idFam.Name = "idFam";
            this.idFam.ReadOnly = true;
            this.idFam.Visible = false;
            // 
            // idTipoDoc
            // 
            this.idTipoDoc.DataPropertyName = "idFam";
            this.idTipoDoc.HeaderText = "tipodoc";
            this.idTipoDoc.Name = "idTipoDoc";
            this.idTipoDoc.ReadOnly = true;
            this.idTipoDoc.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idFam";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // clsFamiliaBindingSource
            // 
            this.clsFamiliaBindingSource.DataSource = typeof(EntityLayer.clsFamiliar);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(622, 238);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 4;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(622, 294);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 5;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(498, 469);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 12;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(4, 392);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(96, 13);
            this.lblBase10.TabIndex = 6;
            this.lblBase10.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(7, 406);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(675, 57);
            this.txtObservaciones.TabIndex = 7;
            this.txtObservaciones.Tag = "Observaciones";
            this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(622, 469);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(11, 72);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(119, 13);
            this.lblBase11.TabIndex = 4;
            this.lblBase11.Text = ">25% en empresa:";
            // 
            // chConfirm
            // 
            this.chConfirm.AutoSize = true;
            this.chConfirm.Location = new System.Drawing.Point(126, 71);
            this.chConfirm.Name = "chConfirm";
            this.chConfirm.Size = new System.Drawing.Size(35, 17);
            this.chConfirm.TabIndex = 5;
            this.chConfirm.Text = "Si";
            this.chConfirm.UseVisualStyleBackColor = true;
            this.chConfirm.CheckedChanged += new System.EventHandler(this.chConfirm_CheckedChanged);
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(27, 43);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(107, 13);
            this.lblBase12.TabIndex = 6;
            this.lblBase12.Text = "Apellido Materno:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipDocumento1);
            this.grbBase1.Controls.Add(this.lblEstado);
            this.grbBase1.Controls.Add(this.txtDocumento);
            this.grbBase1.Controls.Add(this.txtMaterno);
            this.grbBase1.Controls.Add(this.txtPaterno);
            this.grbBase1.Controls.Add(this.txtNombres);
            this.grbBase1.Controls.Add(this.btnBusqueda1);
            this.grbBase1.Controls.Add(this.dtFecNac);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase12);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Controls.Add(this.lblBase15);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(7, 5);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(675, 110);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos personales:";
            // 
            // cboTipDocumento1
            // 
            this.cboTipDocumento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocumento1.FormattingEnabled = true;
            this.cboTipDocumento1.Location = new System.Drawing.Point(447, 13);
            this.cboTipDocumento1.Name = "cboTipDocumento1";
            this.cboTipDocumento1.Size = new System.Drawing.Size(155, 21);
            this.cboTipDocumento1.TabIndex = 13;
            this.cboTipDocumento1.SelectedIndexChanged += new System.EventHandler(this.cboTipDocumento1_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstado.Location = new System.Drawing.Point(450, 62);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 12;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(447, 36);
            this.txtDocumento.MaxLength = 8;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(155, 20);
            this.txtDocumento.TabIndex = 9;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtMaterno
            // 
            this.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterno.Location = new System.Drawing.Point(143, 36);
            this.txtMaterno.MaxLength = 50;
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(199, 20);
            this.txtMaterno.TabIndex = 1;
            this.txtMaterno.Tag = "Apellido Materno";
            this.txtMaterno.TextChanged += new System.EventHandler(this.txtMaterno_TextChanged);
            // 
            // txtPaterno
            // 
            this.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaterno.Location = new System.Drawing.Point(143, 15);
            this.txtPaterno.MaxLength = 50;
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(199, 20);
            this.txtPaterno.TabIndex = 0;
            this.txtPaterno.Tag = "Apellido Paterno";
            this.txtPaterno.TextChanged += new System.EventHandler(this.txtPaterno_TextChanged);
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(143, 58);
            this.txtNombres.MaxLength = 50;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(199, 20);
            this.txtNombres.TabIndex = 2;
            this.txtNombres.Tag = "Nombres";
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(608, 18);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 5;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // dtFecNac
            // 
            this.dtFecNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecNac.Location = new System.Drawing.Point(143, 79);
            this.dtFecNac.Name = "dtFecNac";
            this.dtFecNac.Size = new System.Drawing.Size(139, 20);
            this.dtFecNac.TabIndex = 3;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(357, 63);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(85, 13);
            this.lblBase14.TabIndex = 0;
            this.lblBase14.Text = "Vigencia PEP:";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(378, 14);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(63, 13);
            this.lblBase15.TabIndex = 0;
            this.lblBase15.Text = "Tip. Doc.:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtFechaFin);
            this.grbBase2.Controls.Add(this.dtFechaIni);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtInstitucion);
            this.grbBase2.Controls.Add(this.chConfirm);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.txtCargo);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.txtPorcentaje);
            this.grbBase2.Location = new System.Drawing.Point(7, 117);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(675, 100);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Otros:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(565, 41);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(102, 20);
            this.dtFechaFin.TabIndex = 3;
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIni.Location = new System.Drawing.Point(565, 19);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(102, 20);
            this.dtFechaIni.TabIndex = 2;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(4, 225);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(69, 13);
            this.lblBase13.TabIndex = 2;
            this.lblBase13.Text = "Familiares:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(374, 469);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(436, 469);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(560, 469);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Enabled = false;
            this.btnEliminar1.Location = new System.Drawing.Point(308, 469);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 15;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(242, 469);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 16;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click_1);
            // 
            // frmPep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 547);
            this.ControlBox = false;
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.dtgFamiliares);
            this.Name = "frmPep";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Registro de PEP";
            this.Load += new System.EventHandler(this.frmPep_Load);
            this.Shown += new System.EventHandler(this.frmPep_Shown);
            this.Controls.SetChildIndex(this.dtgFamiliares, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsFamiliaBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtInstitucion;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtCargo;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtPorcentaje;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.dtgBase dtgFamiliares;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.chcBase chConfirm;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.dtLargoBase dtFecNac;
        private GEN.ControlesBase.dtLargoBase dtFechaFin;
        private GEN.ControlesBase.dtLargoBase dtFechaIni;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.BindingSource clsFamiliaBindingSource;
        private GEN.ControlesBase.txtCBLetra txtMaterno;
        private GEN.ControlesBase.txtCBLetra txtPaterno;
        private GEN.ControlesBase.txtCBLetra txtNombres;
        public GEN.ControlesBase.txtCBDNI txtDocumento;
        public GEN.BotonesBase.btnBusqueda btnBusqueda1;
        public GEN.BotonesBase.btnEditar btnEditar;
        public GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.cboTipDocumento cboTipDocumento1;
        private GEN.ControlesBase.lblBase lblBase15;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn cApePaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cApeMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNumDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdVinculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFam;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}