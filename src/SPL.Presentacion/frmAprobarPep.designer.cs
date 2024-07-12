namespace SPL.Presentacion
{
    partial class frmAprobarPep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobarPep));
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtFechaFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtFechaIni = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtInstitucion = new GEN.ControlesBase.txtBase(this.components);
            this.chConfirm = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtCargo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtPorcentaje = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipDocumento1 = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.txtDocumento = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtMaterno = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtPaterno = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtNombres = new GEN.ControlesBase.txtCBLetra(this.components);
            this.dtFecNac = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtgFamiliares = new GEN.ControlesBase.dtgBase(this.components);
            this.idFam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnDenegar = new GEN.BotonesBase.btnDenegar();
            this.btnBusSolicitud1 = new GEN.BotonesBase.btnBusSolicitud();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliares)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(3, 239);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(69, 13);
            this.lblBase13.TabIndex = 10;
            this.lblBase13.Text = "Familiares:";
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
            this.grbBase2.Location = new System.Drawing.Point(6, 131);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(675, 100);
            this.grbBase2.TabIndex = 9;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Otros:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(551, 41);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(116, 20);
            this.dtFechaFin.TabIndex = 11;
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIni.Location = new System.Drawing.Point(551, 19);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(116, 20);
            this.dtFechaIni.TabIndex = 9;
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
            // txtInstitucion
            // 
            this.txtInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInstitucion.Location = new System.Drawing.Point(86, 19);
            this.txtInstitucion.MaxLength = 1000;
            this.txtInstitucion.Name = "txtInstitucion";
            this.txtInstitucion.Size = new System.Drawing.Size(355, 20);
            this.txtInstitucion.TabIndex = 1;
            this.txtInstitucion.Tag = "Nombre de la Institución";
            // 
            // chConfirm
            // 
            this.chConfirm.AutoSize = true;
            this.chConfirm.Location = new System.Drawing.Point(128, 72);
            this.chConfirm.Name = "chConfirm";
            this.chConfirm.Size = new System.Drawing.Size(35, 17);
            this.chConfirm.TabIndex = 5;
            this.chConfirm.Text = "Si";
            this.chConfirm.UseVisualStyleBackColor = true;
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
            // txtCargo
            // 
            this.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Location = new System.Drawing.Point(86, 41);
            this.txtCargo.MaxLength = 1000;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(355, 20);
            this.txtCargo.TabIndex = 3;
            this.txtCargo.Tag = "Cargo";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(449, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(98, 13);
            this.lblBase7.TabIndex = 8;
            this.lblBase7.Text = "Fecha de Inicio:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(449, 44);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(83, 13);
            this.lblBase8.TabIndex = 10;
            this.lblBase8.Text = "Fecha de Fin:";
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
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblEstado);
            this.grbBase1.Controls.Add(this.lblBase16);
            this.grbBase1.Controls.Add(this.cboTipDocumento1);
            this.grbBase1.Controls.Add(this.lblBase15);
            this.grbBase1.Controls.Add(this.txtDocumento);
            this.grbBase1.Controls.Add(this.txtMaterno);
            this.grbBase1.Controls.Add(this.txtPaterno);
            this.grbBase1.Controls.Add(this.txtNombres);
            this.grbBase1.Controls.Add(this.dtFecNac);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase12);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(6, 6);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(601, 118);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos personales:";
            // 
            // cboTipDocumento1
            // 
            this.cboTipDocumento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocumento1.Enabled = false;
            this.cboTipDocumento1.FormattingEnabled = true;
            this.cboTipDocumento1.Location = new System.Drawing.Point(447, 17);
            this.cboTipDocumento1.Name = "cboTipDocumento1";
            this.cboTipDocumento1.Size = new System.Drawing.Size(148, 21);
            this.cboTipDocumento1.TabIndex = 15;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(378, 18);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(63, 13);
            this.lblBase15.TabIndex = 14;
            this.lblBase15.Text = "Tip. Doc.:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(447, 39);
            this.txtDocumento.MaxLength = 8;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(148, 20);
            this.txtDocumento.TabIndex = 9;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaterno
            // 
            this.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterno.Location = new System.Drawing.Point(143, 36);
            this.txtMaterno.MaxLength = 50;
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(199, 20);
            this.txtMaterno.TabIndex = 3;
            this.txtMaterno.Tag = "Apellido Materno";
            // 
            // txtPaterno
            // 
            this.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaterno.Location = new System.Drawing.Point(143, 15);
            this.txtPaterno.MaxLength = 50;
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(199, 20);
            this.txtPaterno.TabIndex = 2;
            this.txtPaterno.Tag = "Apellido Paterno";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(143, 58);
            this.txtNombres.MaxLength = 50;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(199, 20);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.Tag = "Nombres";
            // 
            // dtFecNac
            // 
            this.dtFecNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecNac.Location = new System.Drawing.Point(143, 79);
            this.dtFecNac.Name = "dtFecNac";
            this.dtFecNac.Size = new System.Drawing.Size(139, 20);
            this.dtFecNac.TabIndex = 4;
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
            this.lblBase3.Location = new System.Drawing.Point(365, 42);
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
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(6, 420);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(675, 57);
            this.txtObservaciones.TabIndex = 13;
            this.txtObservaciones.Tag = "Observaciones";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(3, 406);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(96, 13);
            this.lblBase10.TabIndex = 12;
            this.lblBase10.Text = "Observaciones:";
            // 
            // dtgFamiliares
            // 
            this.dtgFamiliares.AllowUserToAddRows = false;
            this.dtgFamiliares.AllowUserToDeleteRows = false;
            this.dtgFamiliares.AllowUserToResizeColumns = false;
            this.dtgFamiliares.AllowUserToResizeRows = false;
            this.dtgFamiliares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFamiliares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFamiliares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFam});
            this.dtgFamiliares.Location = new System.Drawing.Point(6, 255);
            this.dtgFamiliares.MultiSelect = false;
            this.dtgFamiliares.Name = "dtgFamiliares";
            this.dtgFamiliares.ReadOnly = true;
            this.dtgFamiliares.RowHeadersVisible = false;
            this.dtgFamiliares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFamiliares.Size = new System.Drawing.Size(667, 144);
            this.dtgFamiliares.TabIndex = 11;
            // 
            // idFam
            // 
            this.idFam.DataPropertyName = "idFam";
            this.idFam.HeaderText = "idFam";
            this.idFam.Name = "idFam";
            this.idFam.ReadOnly = true;
            this.idFam.Visible = false;
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(6, 499);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(675, 57);
            this.txtSustento.TabIndex = 15;
            this.txtSustento.Tag = "Observaciones";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(7, 483);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(183, 13);
            this.lblBase14.TabIndex = 14;
            this.lblBase14.Text = "Sustento Aprobación/Rechazo:";
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Enabled = false;
            this.btnAprobar.Location = new System.Drawing.Point(481, 564);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 18;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(620, 564);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar.BackgroundImage")));
            this.btnDenegar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar.Enabled = false;
            this.btnDenegar.Location = new System.Drawing.Point(541, 564);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar.TabIndex = 20;
            this.btnDenegar.Text = "&Denegar";
            this.btnDenegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // btnBusSolicitud1
            // 
            this.btnBusSolicitud1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusSolicitud1.BackgroundImage")));
            this.btnBusSolicitud1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusSolicitud1.Location = new System.Drawing.Point(613, 21);
            this.btnBusSolicitud1.Name = "btnBusSolicitud1";
            this.btnBusSolicitud1.Size = new System.Drawing.Size(60, 50);
            this.btnBusSolicitud1.TabIndex = 21;
            this.btnBusSolicitud1.Text = "&Buscar Solicitud";
            this.btnBusSolicitud1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusSolicitud1.UseVisualStyleBackColor = true;
            this.btnBusSolicitud1.Click += new System.EventHandler(this.btnBusSolicitud1_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstado.Location = new System.Drawing.Point(450, 64);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 17;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(357, 65);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(85, 13);
            this.lblBase16.TabIndex = 16;
            this.lblBase16.Text = "Vigencia PEP:";
            // 
            // frmAprobarPep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 645);
            this.Controls.Add(this.btnBusSolicitud1);
            this.Controls.Add(this.btnDenegar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.dtgFamiliares);
            this.Name = "frmAprobarPep";
            this.Text = "Aprobar PEP";
            this.Load += new System.EventHandler(this.frmAprobarPep_Load);
            this.Controls.SetChildIndex(this.dtgFamiliares, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.lblBase14, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnDenegar, 0);
            this.Controls.SetChildIndex(this.btnBusSolicitud1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtLargoBase dtFechaFin;
        private GEN.ControlesBase.dtLargoBase dtFechaIni;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtInstitucion;
        private GEN.ControlesBase.chcBase chConfirm;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtCargo;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtPorcentaje;
        private GEN.ControlesBase.grbBase grbBase1;
        public GEN.ControlesBase.txtCBNumerosEnteros txtDocumento;
        private GEN.ControlesBase.txtCBLetra txtMaterno;
        private GEN.ControlesBase.txtCBLetra txtPaterno;
        private GEN.ControlesBase.txtCBLetra txtNombres;
        private GEN.ControlesBase.dtLargoBase dtFecNac;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.dtgBase dtgFamiliares;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnDenegar btnDenegar;
        private GEN.BotonesBase.btnBusSolicitud btnBusSolicitud1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFam;
        private GEN.ControlesBase.cboTipDocumento cboTipDocumento1;
        private GEN.ControlesBase.lblBase lblBase15;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.lblBase lblBase16;
    }
}