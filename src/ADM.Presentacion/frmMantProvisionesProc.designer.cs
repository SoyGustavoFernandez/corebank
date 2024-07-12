namespace ADM.Presentacion
{
    partial class frmMantProvisionesProc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantProvisionesProc));
            this.dtgTasaProvision = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgPeriodosProvision = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.cboMesesInicio = new GEN.ControlesBase.cboMeses(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtAnioFin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAnioInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboMesesFin = new GEN.ControlesBase.cboMeses(this.components);
            this.btnArchivar = new GEN.BotonesBase.Boton();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboEstPeriodoProv = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTasaMes6 = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasaMes4 = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasaMes2 = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblDescMes = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtTasaMensual = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTasaProvision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodosProvision)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgTasaProvision
            // 
            this.dtgTasaProvision.AllowUserToAddRows = false;
            this.dtgTasaProvision.AllowUserToDeleteRows = false;
            this.dtgTasaProvision.AllowUserToResizeColumns = false;
            this.dtgTasaProvision.AllowUserToResizeRows = false;
            this.dtgTasaProvision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTasaProvision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTasaProvision.Location = new System.Drawing.Point(18, 39);
            this.dtgTasaProvision.MultiSelect = false;
            this.dtgTasaProvision.Name = "dtgTasaProvision";
            this.dtgTasaProvision.ReadOnly = true;
            this.dtgTasaProvision.RowHeadersVisible = false;
            this.dtgTasaProvision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTasaProvision.Size = new System.Drawing.Size(239, 156);
            this.dtgTasaProvision.TabIndex = 5;
            this.dtgTasaProvision.SelectionChanged += new System.EventHandler(this.dtgTasaProvision_SelectionChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(333, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Mes 2:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(437, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(19, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "%";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(333, 111);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Mes 6:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(333, 81);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Mes 4:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(437, 81);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(19, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "%";
            // 
            // dtgPeriodosProvision
            // 
            this.dtgPeriodosProvision.AllowUserToAddRows = false;
            this.dtgPeriodosProvision.AllowUserToDeleteRows = false;
            this.dtgPeriodosProvision.AllowUserToResizeColumns = false;
            this.dtgPeriodosProvision.AllowUserToResizeRows = false;
            this.dtgPeriodosProvision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPeriodosProvision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPeriodosProvision.Location = new System.Drawing.Point(260, 63);
            this.dtgPeriodosProvision.MultiSelect = false;
            this.dtgPeriodosProvision.Name = "dtgPeriodosProvision";
            this.dtgPeriodosProvision.ReadOnly = true;
            this.dtgPeriodosProvision.RowHeadersVisible = false;
            this.dtgPeriodosProvision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPeriodosProvision.Size = new System.Drawing.Size(218, 152);
            this.dtgPeriodosProvision.TabIndex = 7;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(264, 490);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 2;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(449, 490);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(387, 490);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(326, 490);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // cboMesesInicio
            // 
            this.cboMesesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesesInicio.FormattingEnabled = true;
            this.cboMesesInicio.Location = new System.Drawing.Point(25, 31);
            this.cboMesesInicio.Name = "cboMesesInicio";
            this.cboMesesInicio.Size = new System.Drawing.Size(109, 21);
            this.cboMesesInicio.TabIndex = 0;
            this.cboMesesInicio.SelectedIndexChanged += new System.EventHandler(this.cboMesesInicio_SelectedIndexChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase11);
            this.grbBase1.Controls.Add(this.grbBase3);
            this.grbBase1.Controls.Add(this.btnArchivar);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboEstPeriodoProv);
            this.grbBase1.Controls.Add(this.dtgPeriodosProvision);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 13);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(497, 235);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Periodos de la Provisión ";
            // 
            // lblBase11
            // 
            this.lblBase11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(0, 0);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(497, 19);
            this.lblBase11.TabIndex = 4;
            this.lblBase11.Text = "PERIODOS DE LA PROVISIÓN PROCÍCLICA";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtAnioFin);
            this.grbBase3.Controls.Add(this.txtAnioInicio);
            this.grbBase3.Controls.Add(this.lblBase14);
            this.grbBase3.Controls.Add(this.cboMesesInicio);
            this.grbBase3.Controls.Add(this.lblBase15);
            this.grbBase3.Controls.Add(this.cboMesesFin);
            this.grbBase3.Location = new System.Drawing.Point(18, 113);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(201, 102);
            this.grbBase3.TabIndex = 1;
            this.grbBase3.TabStop = false;
            // 
            // txtAnioFin
            // 
            this.txtAnioFin.Location = new System.Drawing.Point(137, 72);
            this.txtAnioFin.MaxLength = 4;
            this.txtAnioFin.Name = "txtAnioFin";
            this.txtAnioFin.Size = new System.Drawing.Size(48, 20);
            this.txtAnioFin.TabIndex = 3;
            // 
            // txtAnioInicio
            // 
            this.txtAnioInicio.Location = new System.Drawing.Point(137, 31);
            this.txtAnioInicio.MaxLength = 4;
            this.txtAnioInicio.Name = "txtAnioInicio";
            this.txtAnioInicio.Size = new System.Drawing.Size(48, 20);
            this.txtAnioInicio.TabIndex = 1;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(25, 15);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(107, 13);
            this.lblBase14.TabIndex = 4;
            this.lblBase14.Text = "Inicio (mes/año):";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(25, 57);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(92, 13);
            this.lblBase15.TabIndex = 5;
            this.lblBase15.Text = "Fin (mes/año):";
            // 
            // cboMesesFin
            // 
            this.cboMesesFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesesFin.FormattingEnabled = true;
            this.cboMesesFin.Location = new System.Drawing.Point(25, 72);
            this.cboMesesFin.Name = "cboMesesFin";
            this.cboMesesFin.Size = new System.Drawing.Size(109, 21);
            this.cboMesesFin.TabIndex = 2;
            // 
            // btnArchivar
            // 
            this.btnArchivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArchivar.Location = new System.Drawing.Point(159, 63);
            this.btnArchivar.Name = "btnArchivar";
            this.btnArchivar.Size = new System.Drawing.Size(60, 50);
            this.btnArchivar.TabIndex = 2;
            this.btnArchivar.Text = "Archivar (Periodo finaliz.)";
            this.btnArchivar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArchivar.UseVisualStyleBackColor = true;
            this.btnArchivar.Click += new System.EventHandler(this.btnArchivar_Click);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(277, 36);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(184, 13);
            this.lblBase9.TabIndex = 6;
            this.lblBase9.Text = "HISTORIAL DE LOS PERIODOS";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(67, 36);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(111, 13);
            this.lblBase7.TabIndex = 5;
            this.lblBase7.Text = "PERIODO ACTUAL";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(15, 63);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(118, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Estado del Periodo:";
            // 
            // cboEstPeriodoProv
            // 
            this.cboEstPeriodoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstPeriodoProv.FormattingEnabled = true;
            this.cboEstPeriodoProv.Location = new System.Drawing.Point(18, 79);
            this.cboEstPeriodoProv.Name = "cboEstPeriodoProv";
            this.cboEstPeriodoProv.Size = new System.Drawing.Size(119, 21);
            this.cboEstPeriodoProv.TabIndex = 0;
            this.cboEstPeriodoProv.SelectedIndexChanged += new System.EventHandler(this.cboEstPeriodoProv_SelectedIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTasaMes6);
            this.grbBase2.Controls.Add(this.txtTasaMes4);
            this.grbBase2.Controls.Add(this.txtTasaMes2);
            this.grbBase2.Controls.Add(this.lblDescMes);
            this.grbBase2.Controls.Add(this.lblBase12);
            this.grbBase2.Controls.Add(this.txtTasaMensual);
            this.grbBase2.Controls.Add(this.lblBase13);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.dtgTasaProvision);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(12, 271);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(497, 213);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Tasas de Provisión";
            this.grbBase2.Enter += new System.EventHandler(this.grbBase2_Enter);
            // 
            // txtTasaMes6
            // 
            this.txtTasaMes6.FormatoDecimal = false;
            this.txtTasaMes6.Location = new System.Drawing.Point(382, 108);
            this.txtTasaMes6.Name = "txtTasaMes6";
            this.txtTasaMes6.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMes6.nNumDecimales = 4;
            this.txtTasaMes6.nvalor = 0D;
            this.txtTasaMes6.Size = new System.Drawing.Size(50, 20);
            this.txtTasaMes6.TabIndex = 2;
            // 
            // txtTasaMes4
            // 
            this.txtTasaMes4.FormatoDecimal = false;
            this.txtTasaMes4.Location = new System.Drawing.Point(381, 78);
            this.txtTasaMes4.Name = "txtTasaMes4";
            this.txtTasaMes4.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMes4.nNumDecimales = 4;
            this.txtTasaMes4.nvalor = 0D;
            this.txtTasaMes4.Size = new System.Drawing.Size(50, 20);
            this.txtTasaMes4.TabIndex = 1;
            // 
            // txtTasaMes2
            // 
            this.txtTasaMes2.FormatoDecimal = false;
            this.txtTasaMes2.Location = new System.Drawing.Point(382, 48);
            this.txtTasaMes2.Name = "txtTasaMes2";
            this.txtTasaMes2.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMes2.nNumDecimales = 4;
            this.txtTasaMes2.nvalor = 0D;
            this.txtTasaMes2.Size = new System.Drawing.Size(50, 20);
            this.txtTasaMes2.TabIndex = 0;
            // 
            // lblDescMes
            // 
            this.lblDescMes.AutoSize = true;
            this.lblDescMes.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescMes.ForeColor = System.Drawing.Color.Navy;
            this.lblDescMes.Location = new System.Drawing.Point(293, 149);
            this.lblDescMes.Name = "lblDescMes";
            this.lblDescMes.Size = new System.Drawing.Size(0, 13);
            this.lblDescMes.TabIndex = 12;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(438, 175);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(19, 13);
            this.lblBase12.TabIndex = 14;
            this.lblBase12.Text = "%";
            // 
            // txtTasaMensual
            // 
            this.txtTasaMensual.Location = new System.Drawing.Point(382, 172);
            this.txtTasaMensual.MaxLength = 5;
            this.txtTasaMensual.Name = "txtTasaMensual";
            this.txtTasaMensual.Size = new System.Drawing.Size(50, 20);
            this.txtTasaMensual.TabIndex = 3;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(292, 175);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(86, 13);
            this.lblBase13.TabIndex = 13;
            this.lblBase13.Text = "Tasa del Mes:";
            // 
            // lblBase10
            // 
            this.lblBase10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(0, 1);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(497, 19);
            this.lblBase10.TabIndex = 4;
            this.lblBase10.Text = "TASAS DE LA PROVISIÓN PROCÍCLICA";
            this.lblBase10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(438, 111);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(19, 13);
            this.lblBase8.TabIndex = 11;
            this.lblBase8.Text = "%";
            // 
            // frmMantProvisionesProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 567);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Name = "frmMantProvisionesProc";
            this.Text = "Mantenimiento de Provisiones Procíclicas";
            this.Load += new System.EventHandler(this.frmMantProvisionesProc_Load);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTasaProvision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodosProvision)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgTasaProvision;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgPeriodosProvision;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboMeses cboMesesInicio;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboMeses cboMesesFin;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.Boton btnArchivar;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboEstPeriodoProv;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAnioFin;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAnioInicio;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtTasaMensual;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblDescMes;
        private GEN.ControlesBase.txtNumRea txtTasaMes6;
        private GEN.ControlesBase.txtNumRea txtTasaMes4;
        private GEN.ControlesBase.txtNumRea txtTasaMes2;
    }
}