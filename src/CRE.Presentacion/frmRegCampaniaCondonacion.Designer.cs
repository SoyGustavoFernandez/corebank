namespace CRE.Presentacion
{
    partial class frmRegCampaniaCondonacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCampaniaCondonacion));
            this.dtgCampanias = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpVigHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpVigDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbReglas = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniNuevo1 = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.nudDsctoCapital = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.nudDsctoInteres = new GEN.ControlesBase.nudBase(this.components);
            this.nudDsctoOtros = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.nudDsctoIntComp = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.nudDsctoMora = new GEN.ControlesBase.nudBase(this.components);
            this.dtgReglas = new GEN.ControlesBase.dtgBase(this.components);
            this.nudRangoMax = new GEN.ControlesBase.nudBase(this.components);
            this.nudRangoMin = new GEN.ControlesBase.nudBase(this.components);
            this.cboTipoRango = new GEN.ControlesBase.cboBase(this.components);
            this.cboCondicionContable1 = new GEN.ControlesBase.cboCondicionContable(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnMiniCancelEst1 = new GEN.BotonesBase.btnMiniCancelEst();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCampanias)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbReglas.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoCapital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoInteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoOtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoIntComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoMora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMin)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCampanias
            // 
            this.dtgCampanias.AllowUserToAddRows = false;
            this.dtgCampanias.AllowUserToDeleteRows = false;
            this.dtgCampanias.AllowUserToResizeColumns = false;
            this.dtgCampanias.AllowUserToResizeRows = false;
            this.dtgCampanias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCampanias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCampanias.Location = new System.Drawing.Point(13, 13);
            this.dtgCampanias.MultiSelect = false;
            this.dtgCampanias.Name = "dtgCampanias";
            this.dtgCampanias.ReadOnly = true;
            this.dtgCampanias.RowHeadersVisible = false;
            this.dtgCampanias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCampanias.Size = new System.Drawing.Size(400, 193);
            this.dtgCampanias.TabIndex = 2;
            this.dtgCampanias.SelectionChanged += new System.EventHandler(this.dtgCampanias_SelectionChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpVigHasta);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpVigDesde);
            this.grbBase1.Controls.Add(this.txtDescripcion);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNombre);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(419, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(300, 194);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle campaña";
            // 
            // dtpVigHasta
            // 
            this.dtpVigHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigHasta.Location = new System.Drawing.Point(110, 168);
            this.dtpVigHasta.Name = "dtpVigHasta";
            this.dtpVigHasta.Size = new System.Drawing.Size(101, 20);
            this.dtpVigHasta.TabIndex = 29;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(60, 171);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Hasta:";
            // 
            // dtpVigDesde
            // 
            this.dtpVigDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigDesde.Location = new System.Drawing.Point(110, 145);
            this.dtpVigDesde.Name = "dtpVigDesde";
            this.dtpVigDesde.Size = new System.Drawing.Size(101, 20);
            this.dtpVigDesde.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(3, 52);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(292, 86);
            this.txtDescripcion.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 149);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 28;
            this.lblBase2.Text = "Vigencia desde:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(0, 36);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 28;
            this.lblBase1.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(58, 13);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(237, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(0, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 28;
            this.lblBase3.Text = "Nombre:";
            // 
            // grbReglas
            // 
            this.grbReglas.Controls.Add(this.btnMiniCancelEst1);
            this.grbReglas.Controls.Add(this.btnMiniAgregar1);
            this.grbReglas.Controls.Add(this.btnMiniQuitar1);
            this.grbReglas.Controls.Add(this.btnMiniNuevo1);
            this.grbReglas.Controls.Add(this.grbBase3);
            this.grbReglas.Controls.Add(this.dtgReglas);
            this.grbReglas.Controls.Add(this.nudRangoMax);
            this.grbReglas.Controls.Add(this.nudRangoMin);
            this.grbReglas.Controls.Add(this.cboTipoRango);
            this.grbReglas.Controls.Add(this.cboCondicionContable1);
            this.grbReglas.Controls.Add(this.lblBase10);
            this.grbReglas.Controls.Add(this.lblBase7);
            this.grbReglas.Controls.Add(this.lblBase6);
            this.grbReglas.Controls.Add(this.lblBase5);
            this.grbReglas.Location = new System.Drawing.Point(4, 212);
            this.grbReglas.Name = "grbReglas";
            this.grbReglas.Size = new System.Drawing.Size(715, 255);
            this.grbReglas.TabIndex = 4;
            this.grbReglas.TabStop = false;
            this.grbReglas.Text = "Reglas campaña";
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(674, 48);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 67;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(674, 82);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 66;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniNuevo1
            // 
            this.btnMiniNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniNuevo1.BackgroundImage")));
            this.btnMiniNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo1.Location = new System.Drawing.Point(674, 14);
            this.btnMiniNuevo1.Name = "btnMiniNuevo1";
            this.btnMiniNuevo1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniNuevo1.TabIndex = 65;
            this.btnMiniNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo1.UseVisualStyleBackColor = true;
            this.btnMiniNuevo1.Click += new System.EventHandler(this.btnMiniNuevo1_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.nudDsctoCapital);
            this.grbBase3.Controls.Add(this.lblBase13);
            this.grbBase3.Controls.Add(this.nudDsctoInteres);
            this.grbBase3.Controls.Add(this.nudDsctoOtros);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.nudDsctoIntComp);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.nudDsctoMora);
            this.grbBase3.Location = new System.Drawing.Point(525, 41);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(143, 146);
            this.grbBase3.TabIndex = 63;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "% Descuento maximo";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(5, 21);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(47, 13);
            this.lblBase9.TabIndex = 36;
            this.lblBase9.Text = "Capital";
            // 
            // nudDsctoCapital
            // 
            this.nudDsctoCapital.DecimalPlaces = 2;
            this.nudDsctoCapital.Location = new System.Drawing.Point(75, 17);
            this.nudDsctoCapital.Name = "nudDsctoCapital";
            this.nudDsctoCapital.Size = new System.Drawing.Size(61, 20);
            this.nudDsctoCapital.TabIndex = 54;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(5, 44);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(48, 13);
            this.lblBase13.TabIndex = 37;
            this.lblBase13.Text = "Interés";
            // 
            // nudDsctoInteres
            // 
            this.nudDsctoInteres.DecimalPlaces = 2;
            this.nudDsctoInteres.Location = new System.Drawing.Point(75, 42);
            this.nudDsctoInteres.Name = "nudDsctoInteres";
            this.nudDsctoInteres.Size = new System.Drawing.Size(61, 20);
            this.nudDsctoInteres.TabIndex = 55;
            // 
            // nudDsctoOtros
            // 
            this.nudDsctoOtros.DecimalPlaces = 2;
            this.nudDsctoOtros.Location = new System.Drawing.Point(75, 117);
            this.nudDsctoOtros.Name = "nudDsctoOtros";
            this.nudDsctoOtros.Size = new System.Drawing.Size(61, 20);
            this.nudDsctoOtros.TabIndex = 58;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(5, 69);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(69, 13);
            this.lblBase11.TabIndex = 41;
            this.lblBase11.Text = "Int. Comp.";
            // 
            // nudDsctoIntComp
            // 
            this.nudDsctoIntComp.DecimalPlaces = 2;
            this.nudDsctoIntComp.Location = new System.Drawing.Point(75, 67);
            this.nudDsctoIntComp.Name = "nudDsctoIntComp";
            this.nudDsctoIntComp.Size = new System.Drawing.Size(61, 20);
            this.nudDsctoIntComp.TabIndex = 56;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(5, 119);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(38, 13);
            this.lblBase8.TabIndex = 38;
            this.lblBase8.Text = "Otros";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(5, 94);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(35, 13);
            this.lblBase12.TabIndex = 39;
            this.lblBase12.Text = "Mora";
            // 
            // nudDsctoMora
            // 
            this.nudDsctoMora.DecimalPlaces = 2;
            this.nudDsctoMora.Location = new System.Drawing.Point(75, 92);
            this.nudDsctoMora.Name = "nudDsctoMora";
            this.nudDsctoMora.Size = new System.Drawing.Size(61, 20);
            this.nudDsctoMora.TabIndex = 57;
            // 
            // dtgReglas
            // 
            this.dtgReglas.AllowUserToAddRows = false;
            this.dtgReglas.AllowUserToDeleteRows = false;
            this.dtgReglas.AllowUserToResizeColumns = false;
            this.dtgReglas.AllowUserToResizeRows = false;
            this.dtgReglas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReglas.Location = new System.Drawing.Point(3, 41);
            this.dtgReglas.MultiSelect = false;
            this.dtgReglas.Name = "dtgReglas";
            this.dtgReglas.ReadOnly = true;
            this.dtgReglas.RowHeadersVisible = false;
            this.dtgReglas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReglas.Size = new System.Drawing.Size(521, 208);
            this.dtgReglas.TabIndex = 0;
            // 
            // nudRangoMax
            // 
            this.nudRangoMax.Location = new System.Drawing.Point(594, 14);
            this.nudRangoMax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudRangoMax.Name = "nudRangoMax";
            this.nudRangoMax.Size = new System.Drawing.Size(61, 20);
            this.nudRangoMax.TabIndex = 48;
            // 
            // nudRangoMin
            // 
            this.nudRangoMin.Location = new System.Drawing.Point(487, 14);
            this.nudRangoMin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudRangoMin.Name = "nudRangoMin";
            this.nudRangoMin.Size = new System.Drawing.Size(61, 20);
            this.nudRangoMin.TabIndex = 47;
            // 
            // cboTipoRango
            // 
            this.cboTipoRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRango.FormattingEnabled = true;
            this.cboTipoRango.Location = new System.Drawing.Point(295, 14);
            this.cboTipoRango.Name = "cboTipoRango";
            this.cboTipoRango.Size = new System.Drawing.Size(133, 21);
            this.cboTipoRango.TabIndex = 29;
            this.cboTipoRango.SelectedIndexChanged += new System.EventHandler(this.cboTipoRango_SelectedIndexChanged);
            // 
            // cboCondicionContable1
            // 
            this.cboCondicionContable1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionContable1.FormattingEnabled = true;
            this.cboCondicionContable1.Location = new System.Drawing.Point(84, 14);
            this.cboCondicionContable1.Name = "cboCondicionContable1";
            this.cboCondicionContable1.Size = new System.Drawing.Size(127, 21);
            this.cboCondicionContable1.TabIndex = 1;
            this.cboCondicionContable1.SelectedIndexChanged += new System.EventHandler(this.cboCondicionContable1_SelectedIndexChanged);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(442, 17);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(43, 13);
            this.lblBase10.TabIndex = 28;
            this.lblBase10.Text = "Desde";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(553, 17);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(39, 13);
            this.lblBase7.TabIndex = 28;
            this.lblBase7.Text = "Hasta";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(224, 17);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(73, 13);
            this.lblBase6.TabIndex = 28;
            this.lblBase6.Text = "Tipo rango:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(81, 13);
            this.lblBase5.TabIndex = 28;
            this.lblBase5.Text = "Tipo cartera:";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(390, 473);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 5;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(654, 473);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(588, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(522, 473);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 8;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(456, 473);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 9;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnMiniCancelEst1
            // 
            this.btnMiniCancelEst1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst1.BackgroundImage")));
            this.btnMiniCancelEst1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst1.Location = new System.Drawing.Point(674, 116);
            this.btnMiniCancelEst1.Name = "btnMiniCancelEst1";
            this.btnMiniCancelEst1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst1.TabIndex = 69;
            this.btnMiniCancelEst1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst1.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst1.Click += new System.EventHandler(this.btnMiniCancelEst1_Click);
            // 
            // frmRegCampaniaCondonacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 548);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbReglas);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgCampanias);
            this.Name = "frmRegCampaniaCondonacion";
            this.Text = "Campañas de condonación";
            this.Load += new System.EventHandler(this.frmRegCampaniaCondonacion_Load);
            this.Controls.SetChildIndex(this.dtgCampanias, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbReglas, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCampanias)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbReglas.ResumeLayout(false);
            this.grbReglas.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoCapital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoInteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoOtros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoIntComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDsctoMora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCampanias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpVigDesde;
        private GEN.ControlesBase.dtpCorto dtpVigHasta;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbReglas;
        private GEN.ControlesBase.cboBase cboTipoRango;
        private GEN.ControlesBase.cboCondicionContable cboCondicionContable1;
        private GEN.ControlesBase.dtgBase dtgReglas;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.nudBase nudRangoMax;
        private GEN.ControlesBase.nudBase nudRangoMin;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.nudBase nudDsctoOtros;
        private GEN.ControlesBase.nudBase nudDsctoMora;
        private GEN.ControlesBase.nudBase nudDsctoIntComp;
        private GEN.ControlesBase.nudBase nudDsctoInteres;
        private GEN.ControlesBase.nudBase nudDsctoCapital;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniNuevo btnMiniNuevo1;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst1;
    }
}