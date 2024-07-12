namespace CRE.Presentacion
{
    partial class frmExperienciaClienteConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExperienciaClienteConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgBaseOficinas = new System.Windows.Forms.DataGridView();
            this.OPCIONES = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGenerar1 = new GEN.BotonesBase.btnGenerar();
            this.lblTextoAviso = new System.Windows.Forms.Label();
            this.dateFecSys = new System.Windows.Forms.DateTimePicker();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblOficina = new System.Windows.Forms.Label();
            this.lblCodOficina = new System.Windows.Forms.Label();
            this.dtgBaseConfiguraciones = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar2 = new GEN.BotonesBase.btnAgregar();
            this.dtgBasePerfiles = new System.Windows.Forms.DataGridView();
            this.cboListaPerfil1 = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseOficinas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseConfiguraciones)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBasePerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(2, 299);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(341, 21);
            this.cboAgencia1.TabIndex = 2;
            this.cboAgencia1.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar1);
            this.groupBox1.Controls.Add(this.cboAgencia1);
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Controls.Add(this.dtgBaseOficinas);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 329);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administrar Agencias";
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(345, 271);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 157;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(1, 281);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(258, 13);
            this.lblBase6.TabIndex = 154;
            this.lblBase6.Text = "Seleccionar Agencia para agregar a la lista:";
            // 
            // dtgBaseOficinas
            // 
            this.dtgBaseOficinas.AllowUserToAddRows = false;
            this.dtgBaseOficinas.AllowUserToDeleteRows = false;
            this.dtgBaseOficinas.AllowUserToResizeColumns = false;
            this.dtgBaseOficinas.AllowUserToResizeRows = false;
            this.dtgBaseOficinas.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgBaseOficinas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBaseOficinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgBaseOficinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBaseOficinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OPCIONES});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBaseOficinas.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgBaseOficinas.Location = new System.Drawing.Point(6, 19);
            this.dtgBaseOficinas.Name = "dtgBaseOficinas";
            this.dtgBaseOficinas.ReadOnly = true;
            this.dtgBaseOficinas.RowHeadersVisible = false;
            this.dtgBaseOficinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBaseOficinas.Size = new System.Drawing.Size(403, 259);
            this.dtgBaseOficinas.TabIndex = 156;
            this.dtgBaseOficinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaseOficinas_CellClick);
            // 
            // OPCIONES
            // 
            this.OPCIONES.HeaderText = "OPCIONES";
            this.OPCIONES.Name = "OPCIONES";
            this.OPCIONES.ReadOnly = true;
            this.OPCIONES.Text = "Configurar";
            this.OPCIONES.UseColumnTextForButtonValue = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar1);
            this.groupBox2.Controls.Add(this.btnGrabar1);
            this.groupBox2.Controls.Add(this.btnSalir1);
            this.groupBox2.Controls.Add(this.btnGenerar1);
            this.groupBox2.Controls.Add(this.lblTextoAviso);
            this.groupBox2.Controls.Add(this.dateFecSys);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Controls.Add(this.lblOficina);
            this.groupBox2.Controls.Add(this.lblCodOficina);
            this.groupBox2.Controls.Add(this.dtgBaseConfiguraciones);
            this.groupBox2.Location = new System.Drawing.Point(3, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1028, 236);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurar Parámetros";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(779, 174);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 170;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(899, 174);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 161;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(959, 174);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGenerar1
            // 
            this.btnGenerar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar1.BackgroundImage")));
            this.btnGenerar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar1.Location = new System.Drawing.Point(839, 174);
            this.btnGenerar1.Name = "btnGenerar1";
            this.btnGenerar1.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar1.TabIndex = 169;
            this.btnGenerar1.Text = "Gene&rar";
            this.btnGenerar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar1.UseVisualStyleBackColor = true;
            this.btnGenerar1.Click += new System.EventHandler(this.btnGenerar1_Click);
            // 
            // lblTextoAviso
            // 
            this.lblTextoAviso.AutoSize = true;
            this.lblTextoAviso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoAviso.Location = new System.Drawing.Point(13, 169);
            this.lblTextoAviso.Name = "lblTextoAviso";
            this.lblTextoAviso.Size = new System.Drawing.Size(250, 13);
            this.lblTextoAviso.TabIndex = 166;
            this.lblTextoAviso.Text = "Seleccionar Celda para EDITAR % Muestra";
            this.lblTextoAviso.Visible = false;
            // 
            // dateFecSys
            // 
            this.dateFecSys.Enabled = false;
            this.dateFecSys.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecSys.Location = new System.Drawing.Point(74, 20);
            this.dateFecSys.Name = "dateFecSys";
            this.dateFecSys.Size = new System.Drawing.Size(109, 20);
            this.dateFecSys.TabIndex = 162;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 24);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 161;
            this.lblBase2.Text = "Fecha :";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOficina.Location = new System.Drawing.Point(189, 19);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(19, 20);
            this.lblOficina.TabIndex = 157;
            this.lblOficina.Text = "::";
            // 
            // lblCodOficina
            // 
            this.lblCodOficina.AutoSize = true;
            this.lblCodOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodOficina.Location = new System.Drawing.Point(80, 19);
            this.lblCodOficina.Name = "lblCodOficina";
            this.lblCodOficina.Size = new System.Drawing.Size(19, 20);
            this.lblCodOficina.TabIndex = 167;
            this.lblCodOficina.Text = "0";
            // 
            // dtgBaseConfiguraciones
            // 
            this.dtgBaseConfiguraciones.AllowUserToAddRows = false;
            this.dtgBaseConfiguraciones.AllowUserToDeleteRows = false;
            this.dtgBaseConfiguraciones.AllowUserToResizeColumns = false;
            this.dtgBaseConfiguraciones.AllowUserToResizeRows = false;
            this.dtgBaseConfiguraciones.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgBaseConfiguraciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgBaseConfiguraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBaseConfiguraciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgBaseConfiguraciones.Location = new System.Drawing.Point(6, 46);
            this.dtgBaseConfiguraciones.Name = "dtgBaseConfiguraciones";
            this.dtgBaseConfiguraciones.RowHeadersVisible = false;
            this.dtgBaseConfiguraciones.Size = new System.Drawing.Size(1016, 125);
            this.dtgBaseConfiguraciones.TabIndex = 5;
            this.dtgBaseConfiguraciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaseConfiguraciones_CellValueChanged);
            this.dtgBaseConfiguraciones.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dtgBaseConfiguraciones_ColumnAdded);
            this.dtgBaseConfiguraciones.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBaseConfiguraciones_EditingControlShowing);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 603);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1034, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ejecución de Encuestas";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1034, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alerta de Cumpleaños";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBase3);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.btnAgregar2);
            this.groupBox3.Controls.Add(this.dtgBasePerfiles);
            this.groupBox3.Controls.Add(this.cboListaPerfil1);
            this.groupBox3.Controls.Add(this.lblBase1);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(421, 470);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Administrar Perfiles";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 447);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(296, 26);
            this.lblBase3.TabIndex = 161;
            this.lblBase3.Text = "Número de veces que Enviara Alerta, [0: N veces]\r\n ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(300, 444);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 160;
            // 
            // btnAgregar2
            // 
            this.btnAgregar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar2.BackgroundImage")));
            this.btnAgregar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar2.Location = new System.Drawing.Point(349, 414);
            this.btnAgregar2.Name = "btnAgregar2";
            this.btnAgregar2.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar2.TabIndex = 159;
            this.btnAgregar2.Text = "&Agregar";
            this.btnAgregar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar2.UseVisualStyleBackColor = true;
            this.btnAgregar2.Click += new System.EventHandler(this.btnAgregar2_Click);
            // 
            // dtgBasePerfiles
            // 
            this.dtgBasePerfiles.AllowUserToAddRows = false;
            this.dtgBasePerfiles.AllowUserToDeleteRows = false;
            this.dtgBasePerfiles.AllowUserToResizeColumns = false;
            this.dtgBasePerfiles.AllowUserToResizeRows = false;
            this.dtgBasePerfiles.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgBasePerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBasePerfiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgBasePerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBasePerfiles.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgBasePerfiles.Location = new System.Drawing.Point(6, 19);
            this.dtgBasePerfiles.Name = "dtgBasePerfiles";
            this.dtgBasePerfiles.ReadOnly = true;
            this.dtgBasePerfiles.RowHeadersVisible = false;
            this.dtgBasePerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBasePerfiles.Size = new System.Drawing.Size(403, 372);
            this.dtgBasePerfiles.TabIndex = 156;
            this.dtgBasePerfiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBasePerfiles_CellClick);
            // 
            // cboListaPerfil1
            // 
            this.cboListaPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil1.FormattingEnabled = true;
            this.cboListaPerfil1.Location = new System.Drawing.Point(6, 414);
            this.cboListaPerfil1.Name = "cboListaPerfil1";
            this.cboListaPerfil1.Size = new System.Drawing.Size(337, 21);
            this.cboListaPerfil1.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 394);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(240, 13);
            this.lblBase1.TabIndex = 154;
            this.lblBase1.Text = "Seleccionar Perfil para agregar a la Lista";
            // 
            // frmExperienciaClienteConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 633);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmExperienciaClienteConfig";
            this.Text = "Experiencia del Cliente - Configuración";
            this.Load += new System.EventHandler(this.frmExperienciaClienteConfig_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseOficinas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseConfiguraciones)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBasePerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DataGridView dtgBaseOficinas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.DateTimePicker dateFecSys;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.Label lblTextoAviso;
        private System.Windows.Forms.Label lblCodOficina;
        private GEN.BotonesBase.btnGenerar btnGenerar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgBasePerfiles;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.DataGridViewButtonColumn OPCIONES;
        private GEN.BotonesBase.btnAgregar btnAgregar2;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dtgBaseConfiguraciones;
    }
}