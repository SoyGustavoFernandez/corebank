namespace GRH.Presentacion
{
    partial class frmMantenimientoHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoHorario));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtToleranciaSalida = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAntesSalida = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtToleranciaIngreso = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAntesIngreso = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.CBVigente = new GEN.ControlesBase.chcBase(this.components);
            this.cboDiasSemSalida = new GEN.ControlesBase.cboDiasSemana(this.components);
            this.cboDiasSemIngreso = new GEN.ControlesBase.cboDiasSemana(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.CBMarcaSalida = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtHoraSalida = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.CBMarcaIngreso = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtHoraIngreso = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgHorario = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.cboTipoHorario1 = new GEN.ControlesBase.cboTipoHorario(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.CBHorNocturno = new GEN.ControlesBase.chcBase(this.components);
            this.btnMiniGrabar = new GEN.BotonesBase.Boton2();
            this.btnMiniEliminar = new GEN.BotonesBase.Boton2();
            this.txtNombHorario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnMiniNuevo = new GEN.BotonesBase.Boton2();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHorario)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtToleranciaSalida);
            this.grbBase1.Controls.Add(this.txtAntesSalida);
            this.grbBase1.Controls.Add(this.txtToleranciaIngreso);
            this.grbBase1.Controls.Add(this.txtAntesIngreso);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.cboDiasSemSalida);
            this.grbBase1.Controls.Add(this.cboDiasSemIngreso);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.CBMarcaSalida);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.dtHoraSalida);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.CBMarcaIngreso);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtHoraIngreso);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 99);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(561, 179);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle del Horario";
            // 
            // txtToleranciaSalida
            // 
            this.txtToleranciaSalida.Location = new System.Drawing.Point(444, 104);
            this.txtToleranciaSalida.MaxLength = 3;
            this.txtToleranciaSalida.Name = "txtToleranciaSalida";
            this.txtToleranciaSalida.Size = new System.Drawing.Size(95, 20);
            this.txtToleranciaSalida.TabIndex = 8;
            // 
            // txtAntesSalida
            // 
            this.txtAntesSalida.Location = new System.Drawing.Point(444, 78);
            this.txtAntesSalida.MaxLength = 3;
            this.txtAntesSalida.Name = "txtAntesSalida";
            this.txtAntesSalida.Size = new System.Drawing.Size(95, 20);
            this.txtAntesSalida.TabIndex = 7;
            // 
            // txtToleranciaIngreso
            // 
            this.txtToleranciaIngreso.Location = new System.Drawing.Point(166, 104);
            this.txtToleranciaIngreso.MaxLength = 3;
            this.txtToleranciaIngreso.Name = "txtToleranciaIngreso";
            this.txtToleranciaIngreso.Size = new System.Drawing.Size(95, 20);
            this.txtToleranciaIngreso.TabIndex = 3;
            // 
            // txtAntesIngreso
            // 
            this.txtAntesIngreso.Location = new System.Drawing.Point(166, 78);
            this.txtAntesIngreso.MaxLength = 3;
            this.txtAntesIngreso.Name = "txtAntesIngreso";
            this.txtAntesIngreso.Size = new System.Drawing.Size(95, 20);
            this.txtAntesIngreso.TabIndex = 2;
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(477, 152);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 10;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // cboDiasSemSalida
            // 
            this.cboDiasSemSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiasSemSalida.FormattingEnabled = true;
            this.cboDiasSemSalida.Location = new System.Drawing.Point(444, 24);
            this.cboDiasSemSalida.Name = "cboDiasSemSalida";
            this.cboDiasSemSalida.Size = new System.Drawing.Size(95, 21);
            this.cboDiasSemSalida.TabIndex = 5;
            // 
            // cboDiasSemIngreso
            // 
            this.cboDiasSemIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiasSemIngreso.FormattingEnabled = true;
            this.cboDiasSemIngreso.Location = new System.Drawing.Point(166, 24);
            this.cboDiasSemIngreso.Name = "cboDiasSemIngreso";
            this.cboDiasSemIngreso.Size = new System.Drawing.Size(95, 21);
            this.cboDiasSemIngreso.TabIndex = 0;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(305, 107);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(136, 13);
            this.lblBase3.TabIndex = 23;
            this.lblBase3.Text = "Min. Tolerancia Salida:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(305, 81);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(128, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Min. Antes de Salida:";
            // 
            // CBMarcaSalida
            // 
            this.CBMarcaSalida.AutoSize = true;
            this.CBMarcaSalida.ForeColor = System.Drawing.Color.Navy;
            this.CBMarcaSalida.Location = new System.Drawing.Point(308, 132);
            this.CBMarcaSalida.Name = "CBMarcaSalida";
            this.CBMarcaSalida.Size = new System.Drawing.Size(91, 17);
            this.CBMarcaSalida.TabIndex = 9;
            this.CBMarcaSalida.Text = "Marcar Salida";
            this.CBMarcaSalida.UseVisualStyleBackColor = true;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(305, 55);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(96, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Hora de Salida:";
            // 
            // dtHoraSalida
            // 
            this.dtHoraSalida.CustomFormat = "hh:mm tt";
            this.dtHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraSalida.Location = new System.Drawing.Point(444, 51);
            this.dtHoraSalida.Name = "dtHoraSalida";
            this.dtHoraSalida.ShowUpDown = true;
            this.dtHoraSalida.Size = new System.Drawing.Size(95, 20);
            this.dtHoraSalida.TabIndex = 6;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(305, 27);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(88, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Día de Salida:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(21, 107);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(145, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Min. Tolerancia Ingreso:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(21, 81);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(137, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Min. Antes de Ingreso:";
            // 
            // CBMarcaIngreso
            // 
            this.CBMarcaIngreso.AutoSize = true;
            this.CBMarcaIngreso.ForeColor = System.Drawing.Color.Navy;
            this.CBMarcaIngreso.Location = new System.Drawing.Point(24, 132);
            this.CBMarcaIngreso.Name = "CBMarcaIngreso";
            this.CBMarcaIngreso.Size = new System.Drawing.Size(97, 17);
            this.CBMarcaIngreso.TabIndex = 4;
            this.CBMarcaIngreso.Text = "Marcar Ingreso";
            this.CBMarcaIngreso.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Hora de Ingreso:";
            // 
            // dtHoraIngreso
            // 
            this.dtHoraIngreso.CustomFormat = "hh:mm tt";
            this.dtHoraIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraIngreso.Location = new System.Drawing.Point(166, 51);
            this.dtHoraIngreso.Name = "dtHoraIngreso";
            this.dtHoraIngreso.ShowUpDown = true;
            this.dtHoraIngreso.Size = new System.Drawing.Size(95, 20);
            this.dtHoraIngreso.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 27);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(97, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Día de Ingreso:";
            // 
            // dtgHorario
            // 
            this.dtgHorario.AllowUserToAddRows = false;
            this.dtgHorario.AllowUserToDeleteRows = false;
            this.dtgHorario.AllowUserToResizeColumns = false;
            this.dtgHorario.AllowUserToResizeRows = false;
            this.dtgHorario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHorario.Location = new System.Drawing.Point(11, 288);
            this.dtgHorario.MultiSelect = false;
            this.dtgHorario.Name = "dtgHorario";
            this.dtgHorario.ReadOnly = true;
            this.dtgHorario.RowHeadersVisible = false;
            this.dtgHorario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHorario.Size = new System.Drawing.Size(561, 150);
            this.dtgHorario.TabIndex = 4;
            this.dtgHorario.SelectionChanged += new System.EventHandler(this.dtgHorario_SelectionChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(21, 24);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(179, 13);
            this.lblBase9.TabIndex = 0;
            this.lblBase9.Text = "Seleccione el Tipo de Horario:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(446, 446);
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
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(380, 446);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(512, 446);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(248, 446);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(314, 446);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // cboTipoHorario1
            // 
            this.cboTipoHorario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoHorario1.FormattingEnabled = true;
            this.cboTipoHorario1.Location = new System.Drawing.Point(45, 47);
            this.cboTipoHorario1.Name = "cboTipoHorario1";
            this.cboTipoHorario1.Size = new System.Drawing.Size(181, 21);
            this.cboTipoHorario1.TabIndex = 1;
            this.cboTipoHorario1.SelectedIndexChanged += new System.EventHandler(this.cboTipoHorario1_SelectedIndexChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.cboTipoHorario1);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(12, 11);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(275, 82);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Configuración de Horarios";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.CBHorNocturno);
            this.grbBase2.Controls.Add(this.btnMiniGrabar);
            this.grbBase2.Controls.Add(this.btnMiniEliminar);
            this.grbBase2.Controls.Add(this.txtNombHorario);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.btnMiniNuevo);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(293, 11);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(279, 82);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Creación de Tipos de Horarios";
            // 
            // CBHorNocturno
            // 
            this.CBHorNocturno.AutoSize = true;
            this.CBHorNocturno.Enabled = false;
            this.CBHorNocturno.ForeColor = System.Drawing.Color.Navy;
            this.CBHorNocturno.Location = new System.Drawing.Point(27, 58);
            this.CBHorNocturno.Name = "CBHorNocturno";
            this.CBHorNocturno.Size = new System.Drawing.Size(107, 17);
            this.CBHorNocturno.TabIndex = 2;
            this.CBHorNocturno.Text = "Horario Nocturno";
            this.CBHorNocturno.UseVisualStyleBackColor = true;
            // 
            // btnMiniGrabar
            // 
            this.btnMiniGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniGrabar.Enabled = false;
            this.btnMiniGrabar.Location = new System.Drawing.Point(208, 33);
            this.btnMiniGrabar.Name = "btnMiniGrabar";
            this.btnMiniGrabar.Size = new System.Drawing.Size(50, 21);
            this.btnMiniGrabar.TabIndex = 4;
            this.btnMiniGrabar.Text = "Grabar";
            this.btnMiniGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniGrabar.UseVisualStyleBackColor = true;
            this.btnMiniGrabar.Click += new System.EventHandler(this.btnMiniGrabar_Click);
            // 
            // btnMiniEliminar
            // 
            this.btnMiniEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEliminar.Enabled = false;
            this.btnMiniEliminar.Location = new System.Drawing.Point(208, 54);
            this.btnMiniEliminar.Name = "btnMiniEliminar";
            this.btnMiniEliminar.Size = new System.Drawing.Size(50, 21);
            this.btnMiniEliminar.TabIndex = 5;
            this.btnMiniEliminar.Text = "Eliminar";
            this.btnMiniEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEliminar.UseVisualStyleBackColor = true;
            this.btnMiniEliminar.Click += new System.EventHandler(this.btnMiniEliminar_Click);
            // 
            // txtNombHorario
            // 
            this.txtNombHorario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombHorario.Enabled = false;
            this.txtNombHorario.Location = new System.Drawing.Point(27, 35);
            this.txtNombHorario.MaxLength = 60;
            this.txtNombHorario.Name = "txtNombHorario";
            this.txtNombHorario.Size = new System.Drawing.Size(170, 20);
            this.txtNombHorario.TabIndex = 1;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(24, 19);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(103, 13);
            this.lblBase10.TabIndex = 0;
            this.lblBase10.Text = "Nombre Horario:";
            // 
            // btnMiniNuevo
            // 
            this.btnMiniNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo.Location = new System.Drawing.Point(208, 12);
            this.btnMiniNuevo.Name = "btnMiniNuevo";
            this.btnMiniNuevo.Size = new System.Drawing.Size(50, 21);
            this.btnMiniNuevo.TabIndex = 3;
            this.btnMiniNuevo.Text = "Nuevo";
            this.btnMiniNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo.UseVisualStyleBackColor = true;
            this.btnMiniNuevo.Click += new System.EventHandler(this.btnMiniNuevo_Click);
            // 
            // frmMantenimientoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 526);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgHorario);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoHorario";
            this.Text = "Mantenimiento de Horarios";
            this.Load += new System.EventHandler(this.frmMantenimientoHorario_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgHorario, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHorario)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.chcBase CBMarcaSalida;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtpCorto dtHoraSalida;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.chcBase CBMarcaIngreso;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtHoraIngreso;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgHorario;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.cboDiasSemana cboDiasSemSalida;
        private GEN.ControlesBase.cboDiasSemana cboDiasSemIngreso;
        private GEN.ControlesBase.cboTipoHorario cboTipoHorario1;
        private GEN.ControlesBase.chcBase CBVigente;
        private GEN.ControlesBase.txtCBNumerosEnteros txtToleranciaSalida;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAntesSalida;
        private GEN.ControlesBase.txtCBNumerosEnteros txtToleranciaIngreso;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAntesIngreso;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtNombHorario;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.Boton2 btnMiniGrabar;
        private GEN.BotonesBase.Boton2 btnMiniEliminar;
        private GEN.BotonesBase.Boton2 btnMiniNuevo;
        private GEN.ControlesBase.chcBase CBHorNocturno;
    }
}