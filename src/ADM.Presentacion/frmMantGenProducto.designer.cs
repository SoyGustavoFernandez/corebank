namespace ADM.Presentacion
{
    partial class frmMantGenProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantGenProducto));
            this.cboNivelProducto = new GEN.ControlesBase.cboNivelProducto(this.components);
            this.dtgProducto = new GEN.ControlesBase.dtgBase(this.components);
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProductoPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lConfigurable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dVigenciaInicio = new GEN.ControlesBase.CalendarColumn();
            this.dVigenciaFin = new GEN.ControlesBase.CalendarColumn();
            this.idFuenteCalcMora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboProductoPadre = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtCodProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblFechaInicio = new GEN.ControlesBase.lblBase();
            this.lblFechaFin = new GEN.ControlesBase.lblBase();
            this.dtpVigenciaInicio = new GEN.ControlesBase.DatePicker();
            this.dtpVigenciaFin = new GEN.ControlesBase.DatePicker();
            this.chcIndeterminado = new GEN.ControlesBase.chcBase(this.components);
            this.chcConfigurable = new GEN.ControlesBase.chcBase(this.components);
            this.lblFuenteCalcMora = new GEN.ControlesBase.lblBase();
            this.cboFuenteCalcMora = new GEN.ControlesBase.cboFuenteCalcMora(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNivelProducto
            // 
            this.cboNivelProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelProducto.FormattingEnabled = true;
            this.cboNivelProducto.Location = new System.Drawing.Point(400, 9);
            this.cboNivelProducto.Name = "cboNivelProducto";
            this.cboNivelProducto.Size = new System.Drawing.Size(160, 21);
            this.cboNivelProducto.TabIndex = 2;
            this.cboNivelProducto.SelectedIndexChanged += new System.EventHandler(this.cboNivelProducto_SelectedIndexChanged);
            // 
            // dtgProducto
            // 
            this.dtgProducto.AllowUserToAddRows = false;
            this.dtgProducto.AllowUserToDeleteRows = false;
            this.dtgProducto.AllowUserToResizeColumns = false;
            this.dtgProducto.AllowUserToResizeRows = false;
            this.dtgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.cNomProducto,
            this.cProducto,
            this.IdProductoPadre,
            this.lVigente,
            this.lConfigurable,
            this.dVigenciaInicio,
            this.dVigenciaFin,
            this.idFuenteCalcMora});
            this.dtgProducto.Location = new System.Drawing.Point(10, 41);
            this.dtgProducto.MultiSelect = false;
            this.dtgProducto.Name = "dtgProducto";
            this.dtgProducto.ReadOnly = true;
            this.dtgProducto.RowHeadersVisible = false;
            this.dtgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProducto.Size = new System.Drawing.Size(806, 243);
            this.dtgProducto.TabIndex = 3;
            this.dtgProducto.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProducto_RowEnter);
            // 
            // IdProducto
            // 
            this.IdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdProducto.DataPropertyName = "IdProducto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IdProducto.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdProducto.FillWeight = 35.61779F;
            this.IdProducto.HeaderText = "Código";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            // 
            // cNomProducto
            // 
            this.cNomProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNomProducto.DataPropertyName = "cNomProducto";
            this.cNomProducto.HeaderText = "cNomProducto";
            this.cNomProducto.Name = "cNomProducto";
            this.cNomProducto.ReadOnly = true;
            this.cNomProducto.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 233.9253F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // IdProductoPadre
            // 
            this.IdProductoPadre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdProductoPadre.DataPropertyName = "IdProductoPadre";
            this.IdProductoPadre.HeaderText = "IdProductoPadre";
            this.IdProductoPadre.Name = "IdProductoPadre";
            this.IdProductoPadre.ReadOnly = true;
            this.IdProductoPadre.Visible = false;
            // 
            // lVigente
            // 
            this.lVigente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.FillWeight = 30.45685F;
            this.lVigente.HeaderText = "Vigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Width = 49;
            // 
            // lConfigurable
            // 
            this.lConfigurable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lConfigurable.DataPropertyName = "lConfigurable";
            this.lConfigurable.FillWeight = 50F;
            this.lConfigurable.HeaderText = "Config.";
            this.lConfigurable.Name = "lConfigurable";
            this.lConfigurable.ReadOnly = true;
            this.lConfigurable.Width = 46;
            // 
            // dVigenciaInicio
            // 
            this.dVigenciaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dVigenciaInicio.DataPropertyName = "dVigenciaInicio";
            this.dVigenciaInicio.HeaderText = "Inicio Vigencia";
            this.dVigenciaInicio.Name = "dVigenciaInicio";
            this.dVigenciaInicio.ReadOnly = true;
            this.dVigenciaInicio.Width = 82;
            // 
            // dVigenciaFin
            // 
            this.dVigenciaFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dVigenciaFin.DataPropertyName = "dVigenciaFin";
            this.dVigenciaFin.HeaderText = "Fin Vigencia";
            this.dVigenciaFin.Name = "dVigenciaFin";
            this.dVigenciaFin.ReadOnly = true;
            this.dVigenciaFin.Width = 71;
            // 
            // idFuenteCalcMora
            // 
            this.idFuenteCalcMora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idFuenteCalcMora.DataPropertyName = "idFuenteCalcMora";
            this.idFuenteCalcMora.HeaderText = "idFuenteCalcMora";
            this.idFuenteCalcMora.Name = "idFuenteCalcMora";
            this.idFuenteCalcMora.ReadOnly = true;
            this.idFuenteCalcMora.Visible = false;
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(82, 9);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(200, 21);
            this.cboModulo.TabIndex = 4;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Módulo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(349, 13);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(40, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Nivel:";
            // 
            // cboProductoPadre
            // 
            this.cboProductoPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductoPadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductoPadre.FormattingEnabled = true;
            this.cboProductoPadre.Location = new System.Drawing.Point(137, 293);
            this.cboProductoPadre.Name = "cboProductoPadre";
            this.cboProductoPadre.Size = new System.Drawing.Size(679, 21);
            this.cboProductoPadre.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 296);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(99, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Producto Padre:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 349);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(111, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Nombre Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(137, 345);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(679, 20);
            this.txtProducto.TabIndex = 10;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(388, 322);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 11;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(508, 423);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(570, 423);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(632, 423);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(694, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(756, 423);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 324);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(124, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Código de Producto:";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Enabled = false;
            this.txtCodProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProducto.Location = new System.Drawing.Point(137, 320);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(228, 20);
            this.txtCodProducto.TabIndex = 18;
            this.txtCodProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaInicio.Location = new System.Drawing.Point(12, 375);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(95, 13);
            this.lblFechaInicio.TabIndex = 19;
            this.lblFechaInicio.Text = "Inicio Vigencia:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaFin.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaFin.Location = new System.Drawing.Point(349, 375);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(80, 13);
            this.lblFechaFin.TabIndex = 20;
            this.lblFechaFin.Text = "Fin Vigencia:";
            // 
            // dtpVigenciaInicio
            // 
            this.dtpVigenciaInicio.Location = new System.Drawing.Point(137, 371);
            this.dtpVigenciaInicio.Name = "dtpVigenciaInicio";
            this.dtpVigenciaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpVigenciaInicio.TabIndex = 21;
            this.dtpVigenciaInicio.Value = new System.DateTime(2015, 5, 26, 18, 40, 22, 643);
            this.dtpVigenciaInicio.ValueChanged += new System.EventHandler(this.dtpVigenciaInicio_ValueChanged);
            // 
            // dtpVigenciaFin
            // 
            this.dtpVigenciaFin.Location = new System.Drawing.Point(430, 371);
            this.dtpVigenciaFin.Name = "dtpVigenciaFin";
            this.dtpVigenciaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpVigenciaFin.TabIndex = 22;
            this.dtpVigenciaFin.Value = new System.DateTime(2015, 5, 26, 18, 40, 22, 643);
            this.dtpVigenciaFin.ValueChanged += new System.EventHandler(this.dtpVigenciaFin_ValueChanged);
            // 
            // chcIndeterminado
            // 
            this.chcIndeterminado.AutoSize = true;
            this.chcIndeterminado.ForeColor = System.Drawing.Color.Navy;
            this.chcIndeterminado.Location = new System.Drawing.Point(640, 373);
            this.chcIndeterminado.Name = "chcIndeterminado";
            this.chcIndeterminado.Size = new System.Drawing.Size(93, 17);
            this.chcIndeterminado.TabIndex = 23;
            this.chcIndeterminado.Text = "Indeterminado";
            this.chcIndeterminado.UseVisualStyleBackColor = true;
            this.chcIndeterminado.CheckedChanged += new System.EventHandler(this.chcIndeterminado_CheckedChanged);
            // 
            // chcConfigurable
            // 
            this.chcConfigurable.AutoSize = true;
            this.chcConfigurable.Location = new System.Drawing.Point(468, 322);
            this.chcConfigurable.Name = "chcConfigurable";
            this.chcConfigurable.Size = new System.Drawing.Size(85, 17);
            this.chcConfigurable.TabIndex = 24;
            this.chcConfigurable.Text = "Configurable";
            this.chcConfigurable.UseVisualStyleBackColor = true;
            // 
            // lblFuenteCalcMora
            // 
            this.lblFuenteCalcMora.AutoSize = true;
            this.lblFuenteCalcMora.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFuenteCalcMora.ForeColor = System.Drawing.Color.Navy;
            this.lblFuenteCalcMora.Location = new System.Drawing.Point(12, 401);
            this.lblFuenteCalcMora.Name = "lblFuenteCalcMora";
            this.lblFuenteCalcMora.Size = new System.Drawing.Size(115, 13);
            this.lblFuenteCalcMora.TabIndex = 23;
            this.lblFuenteCalcMora.Text = "Fuente Calc. Mora:";
            this.lblFuenteCalcMora.Visible = false;
            // 
            // cboFuenteCalcMora
            // 
            this.cboFuenteCalcMora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuenteCalcMora.FormattingEnabled = true;
            this.cboFuenteCalcMora.Location = new System.Drawing.Point(137, 397);
            this.cboFuenteCalcMora.Name = "cboFuenteCalcMora";
            this.cboFuenteCalcMora.Size = new System.Drawing.Size(493, 21);
            this.cboFuenteCalcMora.TabIndex = 24;
            this.cboFuenteCalcMora.Visible = false;
            // 
            // frmMantGenProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 499);
            this.Controls.Add(this.cboFuenteCalcMora);
            this.Controls.Add(this.lblFuenteCalcMora);
            this.Controls.Add(this.chcConfigurable);
            this.Controls.Add(this.chcIndeterminado);
            this.Controls.Add(this.dtpVigenciaFin);
            this.Controls.Add(this.dtpVigenciaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.txtCodProducto);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboProductoPadre);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboModulo);
            this.Controls.Add(this.dtgProducto);
            this.Controls.Add(this.cboNivelProducto);
            this.Name = "frmMantGenProducto";
            this.Text = "Mantenimiento General de Productos";
            this.Load += new System.EventHandler(this.frmMantGenProducto_Load);
            this.Controls.SetChildIndex(this.cboNivelProducto, 0);
            this.Controls.SetChildIndex(this.dtgProducto, 0);
            this.Controls.SetChildIndex(this.cboModulo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboProductoPadre, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtProducto, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtCodProducto, 0);
            this.Controls.SetChildIndex(this.lblFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblFechaFin, 0);
            this.Controls.SetChildIndex(this.dtpVigenciaInicio, 0);
            this.Controls.SetChildIndex(this.dtpVigenciaFin, 0);
            this.Controls.SetChildIndex(this.chcIndeterminado, 0);
            this.Controls.SetChildIndex(this.chcConfigurable, 0);
            this.Controls.SetChildIndex(this.lblFuenteCalcMora, 0);
            this.Controls.SetChildIndex(this.cboFuenteCalcMora, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboNivelProducto cboNivelProducto;
        private GEN.ControlesBase.dtgBase dtgProducto;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboProducto cboProductoPadre;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtCodProducto;
        private GEN.ControlesBase.lblBase lblFechaInicio;
        private GEN.ControlesBase.lblBase lblFechaFin;
        private GEN.ControlesBase.DatePicker dtpVigenciaInicio;
        private GEN.ControlesBase.DatePicker dtpVigenciaFin;
        private GEN.ControlesBase.chcBase chcIndeterminado;
        private GEN.ControlesBase.chcBase chcConfigurable;   
        private GEN.ControlesBase.lblBase lblFuenteCalcMora;
        private GEN.ControlesBase.cboFuenteCalcMora cboFuenteCalcMora;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProductoPadre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lConfigurable;
        private GEN.ControlesBase.CalendarColumn dVigenciaInicio;
        private GEN.ControlesBase.CalendarColumn dVigenciaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuenteCalcMora;
    }
}

