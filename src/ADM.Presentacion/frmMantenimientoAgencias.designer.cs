namespace ADM.Presentacion
{
    partial class frmMantenimientoAgencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoAgencias));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.dtgAgencias = new System.Windows.Forms.DataGridView();
            this.txtNroResolucion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboTipoOficina = new GEN.ControlesBase.cboBase(this.components);
            this.txtTelefono = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFechCrea = new GEN.ControlesBase.dtLargoBase(this.components);
            this.txtReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtCodigoSbs = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDireccionAge = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNomAgeCorto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNomAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.conUbigeo = new GEN.ControlesBase.ConBusUbig();
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgEstablecimiento = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtgAreas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblEsquema = new GEN.ControlesBase.lblBase();
            this.cboTipoEsquema = new GEN.ControlesBase.cboBase(this.components);
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDirección = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRefDirec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodSBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoOficina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dfechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroResolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipEsquemaCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgencias)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAreas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(288, 601);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(105, 601);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(470, 601);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(349, 601);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(227, 601);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(166, 601);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dtgAgencias
            // 
            this.dtgAgencias.AllowUserToAddRows = false;
            this.dtgAgencias.AllowUserToDeleteRows = false;
            this.dtgAgencias.AllowUserToResizeColumns = false;
            this.dtgAgencias.AllowUserToResizeRows = false;
            this.dtgAgencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAgencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAgencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAgencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAgencia,
            this.cNombreAge,
            this.cNomCorto,
            this.idUbigeo,
            this.cDirección,
            this.cRefDirec,
            this.cFono,
            this.lEstado,
            this.cCodSBS,
            this.idTipoOficina,
            this.dfechaCreacion,
            this.cNroResolucion,
            this.idTipEsquemaCaja});
            this.dtgAgencias.Location = new System.Drawing.Point(16, 427);
            this.dtgAgencias.MultiSelect = false;
            this.dtgAgencias.Name = "dtgAgencias";
            this.dtgAgencias.ReadOnly = true;
            this.dtgAgencias.RowHeadersVisible = false;
            this.dtgAgencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAgencias.Size = new System.Drawing.Size(514, 168);
            this.dtgAgencias.TabIndex = 1;
            this.dtgAgencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAgencias_CellContentClick);
            this.dtgAgencias.SelectionChanged += new System.EventHandler(this.dtgAgencias_SelectionChanged);
            // 
            // txtNroResolucion
            // 
            this.txtNroResolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroResolucion.Location = new System.Drawing.Point(118, 158);
            this.txtNroResolucion.MaxLength = 20;
            this.txtNroResolucion.Name = "txtNroResolucion";
            this.txtNroResolucion.Size = new System.Drawing.Size(121, 20);
            this.txtNroResolucion.TabIndex = 5;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(18, 161);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(100, 13);
            this.lblBase6.TabIndex = 139;
            this.lblBase6.Text = "N° Resol. Aper.:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(18, 104);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(79, 13);
            this.lblBase8.TabIndex = 135;
            this.lblBase8.Text = "Tipo Oficina:";
            // 
            // cboTipoOficina
            // 
            this.cboTipoOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOficina.FormattingEnabled = true;
            this.cboTipoOficina.Location = new System.Drawing.Point(118, 101);
            this.cboTipoOficina.Name = "cboTipoOficina";
            this.cboTipoOficina.Size = new System.Drawing.Size(121, 21);
            this.cboTipoOficina.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Location = new System.Drawing.Point(118, 186);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 6;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(18, 189);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(61, 13);
            this.lblBase5.TabIndex = 131;
            this.lblBase5.Text = "Teléfono:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(18, 134);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(100, 13);
            this.lblBase4.TabIndex = 129;
            this.lblBase4.Text = "Fecha Creación:";
            // 
            // dtpFechCrea
            // 
            this.dtpFechCrea.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechCrea.Location = new System.Drawing.Point(118, 130);
            this.dtpFechCrea.Name = "dtpFechCrea";
            this.dtpFechCrea.Size = new System.Drawing.Size(121, 20);
            this.dtpFechCrea.TabIndex = 4;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(118, 340);
            this.txtReferencia.MaxLength = 120;
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(377, 30);
            this.txtReferencia.TabIndex = 9;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(18, 343);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(73, 13);
            this.lblBase9.TabIndex = 126;
            this.lblBase9.Text = "Referencia:";
            // 
            // txtCodigoSbs
            // 
            this.txtCodigoSbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSbs.Location = new System.Drawing.Point(118, 72);
            this.txtCodigoSbs.MaxLength = 4;
            this.txtCodigoSbs.Name = "txtCodigoSbs";
            this.txtCodigoSbs.Size = new System.Drawing.Size(121, 20);
            this.txtCodigoSbs.TabIndex = 2;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 125;
            this.lblBase3.Text = "Código SBS:";
            // 
            // txtDireccionAge
            // 
            this.txtDireccionAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccionAge.Location = new System.Drawing.Point(118, 315);
            this.txtDireccionAge.MaxLength = 120;
            this.txtDireccionAge.Name = "txtDireccionAge";
            this.txtDireccionAge.Size = new System.Drawing.Size(377, 20);
            this.txtDireccionAge.TabIndex = 8;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 318);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 123;
            this.lblBase2.Text = "Dirección:";
            // 
            // txtNomAgeCorto
            // 
            this.txtNomAgeCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomAgeCorto.Location = new System.Drawing.Point(118, 44);
            this.txtNomAgeCorto.MaxLength = 20;
            this.txtNomAgeCorto.Name = "txtNomAgeCorto";
            this.txtNomAgeCorto.Size = new System.Drawing.Size(121, 20);
            this.txtNomAgeCorto.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(93, 13);
            this.lblBase1.TabIndex = 121;
            this.lblBase1.Text = "Nombre Corto:";
            // 
            // txtNomAgencia
            // 
            this.txtNomAgencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomAgencia.Location = new System.Drawing.Point(118, 16);
            this.txtNomAgencia.MaxLength = 120;
            this.txtNomAgencia.Name = "txtNomAgencia";
            this.txtNomAgencia.Size = new System.Drawing.Size(377, 20);
            this.txtNomAgencia.TabIndex = 0;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(18, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(57, 13);
            this.lblBase7.TabIndex = 119;
            this.lblBase7.Text = "Nombre:";
            // 
            // conUbigeo
            // 
            this.conUbigeo.BackColor = System.Drawing.Color.Transparent;
            this.conUbigeo.Location = new System.Drawing.Point(15, 208);
            this.conUbigeo.Name = "conUbigeo";
            this.conUbigeo.nIdNodo = 0;
            this.conUbigeo.Size = new System.Drawing.Size(232, 106);
            this.conUbigeo.TabIndex = 7;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(410, 601);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboTipoEsquema);
            this.grbBase2.Controls.Add(this.lblEsquema);
            this.grbBase2.Controls.Add(this.dtgEstablecimiento);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.dtgAreas);
            this.grbBase2.Controls.Add(this.txtNroResolucion);
            this.grbBase2.Controls.Add(this.txtReferencia);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.conUbigeo);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.cboTipoOficina);
            this.grbBase2.Controls.Add(this.txtNomAgencia);
            this.grbBase2.Controls.Add(this.txtTelefono);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtNomAgeCorto);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.dtpFechCrea);
            this.grbBase2.Controls.Add(this.txtDireccionAge);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.txtCodigoSbs);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(16, 8);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(514, 413);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Agencia";
            // 
            // dtgEstablecimiento
            // 
            this.dtgEstablecimiento.AllowUserToAddRows = false;
            this.dtgEstablecimiento.AllowUserToDeleteRows = false;
            this.dtgEstablecimiento.AllowUserToResizeColumns = false;
            this.dtgEstablecimiento.AllowUserToResizeRows = false;
            this.dtgEstablecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstablecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstablecimiento.Location = new System.Drawing.Point(283, 199);
            this.dtgEstablecimiento.MultiSelect = false;
            this.dtgEstablecimiento.Name = "dtgEstablecimiento";
            this.dtgEstablecimiento.ReadOnly = true;
            this.dtgEstablecimiento.RowHeadersVisible = false;
            this.dtgEstablecimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstablecimiento.Size = new System.Drawing.Size(212, 110);
            this.dtgEstablecimiento.TabIndex = 143;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(280, 183);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(188, 13);
            this.lblBase11.TabIndex = 142;
            this.lblBase11.Text = "Establecimientos de la Agencia:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(280, 43);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(126, 13);
            this.lblBase10.TabIndex = 141;
            this.lblBase10.Text = "Áreas de la Agencia:";
            // 
            // dtgAreas
            // 
            this.dtgAreas.AllowUserToAddRows = false;
            this.dtgAreas.AllowUserToDeleteRows = false;
            this.dtgAreas.AllowUserToResizeColumns = false;
            this.dtgAreas.AllowUserToResizeRows = false;
            this.dtgAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAreas.Location = new System.Drawing.Point(283, 58);
            this.dtgAreas.MultiSelect = false;
            this.dtgAreas.Name = "dtgAreas";
            this.dtgAreas.ReadOnly = true;
            this.dtgAreas.RowHeadersVisible = false;
            this.dtgAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAreas.Size = new System.Drawing.Size(212, 118);
            this.dtgAreas.TabIndex = 10;
            // 
            // lblEsquema
            // 
            this.lblEsquema.AutoSize = true;
            this.lblEsquema.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEsquema.ForeColor = System.Drawing.Color.Navy;
            this.lblEsquema.Location = new System.Drawing.Point(18, 381);
            this.lblEsquema.Name = "lblEsquema";
            this.lblEsquema.Size = new System.Drawing.Size(92, 13);
            this.lblEsquema.TabIndex = 144;
            this.lblEsquema.Text = "Esquema caja:";
            // 
            // cboTipoEsquema
            // 
            this.cboTipoEsquema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEsquema.FormattingEnabled = true;
            this.cboTipoEsquema.Location = new System.Drawing.Point(118, 376);
            this.cboTipoEsquema.Name = "cboTipoEsquema";
            this.cboTipoEsquema.Size = new System.Drawing.Size(377, 21);
            this.cboTipoEsquema.TabIndex = 145;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "Código";
            this.idAgencia.MinimumWidth = 50;
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            // 
            // cNombreAge
            // 
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.MinimumWidth = 140;
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            // 
            // cNomCorto
            // 
            this.cNomCorto.DataPropertyName = "cNomCorto";
            this.cNomCorto.HeaderText = "Abreviatura";
            this.cNomCorto.MinimumWidth = 75;
            this.cNomCorto.Name = "cNomCorto";
            this.cNomCorto.ReadOnly = true;
            // 
            // idUbigeo
            // 
            this.idUbigeo.DataPropertyName = "idUbigeo";
            this.idUbigeo.HeaderText = "Ubigeo";
            this.idUbigeo.Name = "idUbigeo";
            this.idUbigeo.ReadOnly = true;
            this.idUbigeo.Visible = false;
            // 
            // cDirección
            // 
            this.cDirección.DataPropertyName = "cDirección";
            this.cDirección.HeaderText = "cDirección";
            this.cDirección.Name = "cDirección";
            this.cDirección.ReadOnly = true;
            this.cDirección.Visible = false;
            // 
            // cRefDirec
            // 
            this.cRefDirec.DataPropertyName = "cRefDirec";
            this.cRefDirec.HeaderText = "cRefDirec";
            this.cRefDirec.Name = "cRefDirec";
            this.cRefDirec.ReadOnly = true;
            this.cRefDirec.Visible = false;
            // 
            // cFono
            // 
            this.cFono.DataPropertyName = "cFono";
            this.cFono.HeaderText = "Teléfono";
            this.cFono.MinimumWidth = 90;
            this.cFono.Name = "cFono";
            this.cFono.ReadOnly = true;
            // 
            // lEstado
            // 
            this.lEstado.DataPropertyName = "lEstado";
            this.lEstado.HeaderText = "lEstado";
            this.lEstado.Name = "lEstado";
            this.lEstado.ReadOnly = true;
            this.lEstado.Visible = false;
            // 
            // cCodSBS
            // 
            this.cCodSBS.DataPropertyName = "cCodSBS";
            this.cCodSBS.HeaderText = "Código SBS";
            this.cCodSBS.MinimumWidth = 80;
            this.cCodSBS.Name = "cCodSBS";
            this.cCodSBS.ReadOnly = true;
            // 
            // idTipoOficina
            // 
            this.idTipoOficina.DataPropertyName = "idTipoOficina";
            this.idTipoOficina.HeaderText = "idTipoOficina";
            this.idTipoOficina.Name = "idTipoOficina";
            this.idTipoOficina.ReadOnly = true;
            this.idTipoOficina.Visible = false;
            // 
            // dfechaCreacion
            // 
            this.dfechaCreacion.DataPropertyName = "dfechaCreacion";
            this.dfechaCreacion.HeaderText = "dfechaCreacion";
            this.dfechaCreacion.Name = "dfechaCreacion";
            this.dfechaCreacion.ReadOnly = true;
            this.dfechaCreacion.Visible = false;
            // 
            // cNroResolucion
            // 
            this.cNroResolucion.DataPropertyName = "cNroResolucion";
            this.cNroResolucion.HeaderText = "cNroResolucion";
            this.cNroResolucion.Name = "cNroResolucion";
            this.cNroResolucion.ReadOnly = true;
            this.cNroResolucion.Visible = false;
            // 
            // idTipEsquemaCaja
            // 
            this.idTipEsquemaCaja.DataPropertyName = "idTipEsquemaCaja";
            this.idTipEsquemaCaja.HeaderText = "idTipEsquemaCaja";
            this.idTipEsquemaCaja.Name = "idTipEsquemaCaja";
            this.idTipEsquemaCaja.ReadOnly = true;
            this.idTipEsquemaCaja.Visible = false;
            // 
            // frmMantenimientoAgencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 682);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgAgencias);
            this.Name = "frmMantenimientoAgencias";
            this.Text = "Mantenimiento de Agencias";
            this.Load += new System.EventHandler(this.frmMantenimientoAgencias_Load);
            this.Controls.SetChildIndex(this.dtgAgencias, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgencias)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAreas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private System.Windows.Forms.DataGridView dtgAgencias;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboBase cboTipoOficina;
        private GEN.ControlesBase.txtBase txtTelefono;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtLargoBase dtpFechCrea;
        private GEN.ControlesBase.txtBase txtReferencia;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigoSbs;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtDireccionAge;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNomAgeCorto;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNomAgencia;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.ConBusUbig conUbigeo;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.ControlesBase.txtBase txtNroResolucion;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.dtgBase dtgAreas;
        private GEN.ControlesBase.dtgBase dtgEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboBase cboTipoEsquema;
        private GEN.ControlesBase.lblBase lblEsquema;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDirección;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRefDirec;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFono;
        private System.Windows.Forms.DataGridViewTextBoxColumn lEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodSBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoOficina;
        private System.Windows.Forms.DataGridViewTextBoxColumn dfechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroResolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipEsquemaCaja;
    }
}