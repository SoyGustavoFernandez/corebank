namespace CRE.Presentacion
{
    partial class frmCargarGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbGasto = new GEN.ControlesBase.grbBase(this.components);
            this.lblPorcentaje = new GEN.ControlesBase.lblBase();
            this.cboTipoValor = new GEN.ControlesBase.cboTipoValor(this.components);
            this.lblTipoGasto = new GEN.ControlesBase.lblBase();
            this.cboGrupoGasto = new GEN.ControlesBase.cboGrupoGasto(this.components);
            this.txtMontoCarga = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoGasto = new GEN.ControlesBase.cboTipGasto(this.components);
            this.lblGrupoGasto = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAplicaConcepto = new GEN.ControlesBase.cboAplicaConcepto(this.components);
            this.lblTipoValor = new GEN.ControlesBase.lblBase();
            this.lblAfectacion = new GEN.ControlesBase.lblBase();
            this.chcAplicaTodo = new GEN.ControlesBase.chcBase(this.components);
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.dtgPlanPagos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalleGastos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblDetalleGastos = new GEN.ControlesBase.lblBase();
            this.chcConfigAsientosContables = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtCuotas = new GEN.ControlesBase.txtBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.grbGasto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGastos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(538, 427);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Visible = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(672, 427);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(605, 427);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbGasto
            // 
            this.grbGasto.Controls.Add(this.lblPorcentaje);
            this.grbGasto.Controls.Add(this.cboTipoValor);
            this.grbGasto.Controls.Add(this.lblTipoGasto);
            this.grbGasto.Controls.Add(this.cboGrupoGasto);
            this.grbGasto.Controls.Add(this.txtMontoCarga);
            this.grbGasto.Controls.Add(this.cboTipoGasto);
            this.grbGasto.Controls.Add(this.lblGrupoGasto);
            this.grbGasto.Controls.Add(this.lblBase3);
            this.grbGasto.Controls.Add(this.cboAplicaConcepto);
            this.grbGasto.Controls.Add(this.lblTipoValor);
            this.grbGasto.Controls.Add(this.lblAfectacion);
            this.grbGasto.Location = new System.Drawing.Point(460, 245);
            this.grbGasto.Name = "grbGasto";
            this.grbGasto.Size = new System.Drawing.Size(272, 147);
            this.grbGasto.TabIndex = 2;
            this.grbGasto.TabStop = false;
            this.grbGasto.Text = "Datos del Gasto:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Navy;
            this.lblPorcentaje.Location = new System.Drawing.Point(243, 120);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(19, 13);
            this.lblPorcentaje.TabIndex = 103;
            this.lblPorcentaje.Text = "%";
            // 
            // cboTipoValor
            // 
            this.cboTipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValor.FormattingEnabled = true;
            this.cboTipoValor.Location = new System.Drawing.Point(109, 67);
            this.cboTipoValor.Name = "cboTipoValor";
            this.cboTipoValor.Size = new System.Drawing.Size(157, 21);
            this.cboTipoValor.TabIndex = 2;
            this.cboTipoValor.SelectedIndexChanged += new System.EventHandler(this.cboTipoValor_SelectedIndexChanged);
            // 
            // lblTipoGasto
            // 
            this.lblTipoGasto.AutoSize = true;
            this.lblTipoGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoGasto.Location = new System.Drawing.Point(5, 46);
            this.lblTipoGasto.Name = "lblTipoGasto";
            this.lblTipoGasto.Size = new System.Drawing.Size(91, 13);
            this.lblTipoGasto.TabIndex = 58;
            this.lblTipoGasto.Text = "Tipo de Gasto:";
            // 
            // cboGrupoGasto
            // 
            this.cboGrupoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoGasto.FormattingEnabled = true;
            this.cboGrupoGasto.Location = new System.Drawing.Point(109, 19);
            this.cboGrupoGasto.Name = "cboGrupoGasto";
            this.cboGrupoGasto.Size = new System.Drawing.Size(157, 21);
            this.cboGrupoGasto.TabIndex = 0;
            this.cboGrupoGasto.SelectedIndexChanged += new System.EventHandler(this.cboGrupoGasto_SelectedIndexChanged);
            // 
            // txtMontoCarga
            // 
            this.txtMontoCarga.Enabled = false;
            this.txtMontoCarga.FormatoDecimal = false;
            this.txtMontoCarga.Location = new System.Drawing.Point(109, 116);
            this.txtMontoCarga.MaxLength = 7;
            this.txtMontoCarga.Name = "txtMontoCarga";
            this.txtMontoCarga.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoCarga.nNumDecimales = 1;
            this.txtMontoCarga.nvalor = 0D;
            this.txtMontoCarga.Size = new System.Drawing.Size(128, 20);
            this.txtMontoCarga.TabIndex = 4;
            this.txtMontoCarga.Leave += new System.EventHandler(this.txtMontoCarga_Leave);
            // 
            // cboTipoGasto
            // 
            this.cboTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGasto.FormattingEnabled = true;
            this.cboTipoGasto.Location = new System.Drawing.Point(109, 43);
            this.cboTipoGasto.Name = "cboTipoGasto";
            this.cboTipoGasto.Size = new System.Drawing.Size(157, 21);
            this.cboTipoGasto.TabIndex = 1;
            // 
            // lblGrupoGasto
            // 
            this.lblGrupoGasto.AutoSize = true;
            this.lblGrupoGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGrupoGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblGrupoGasto.Location = new System.Drawing.Point(5, 22);
            this.lblGrupoGasto.Name = "lblGrupoGasto";
            this.lblGrupoGasto.Size = new System.Drawing.Size(102, 13);
            this.lblGrupoGasto.TabIndex = 57;
            this.lblGrupoGasto.Text = "Grupo de Gasto:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(5, 119);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Valor a Cargar:";
            // 
            // cboAplicaConcepto
            // 
            this.cboAplicaConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAplicaConcepto.FormattingEnabled = true;
            this.cboAplicaConcepto.Location = new System.Drawing.Point(109, 91);
            this.cboAplicaConcepto.Name = "cboAplicaConcepto";
            this.cboAplicaConcepto.Size = new System.Drawing.Size(157, 21);
            this.cboAplicaConcepto.TabIndex = 3;
            // 
            // lblTipoValor
            // 
            this.lblTipoValor.AutoSize = true;
            this.lblTipoValor.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoValor.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoValor.Location = new System.Drawing.Point(5, 70);
            this.lblTipoValor.Name = "lblTipoValor";
            this.lblTipoValor.Size = new System.Drawing.Size(87, 13);
            this.lblTipoValor.TabIndex = 98;
            this.lblTipoValor.Text = "Tipo de valor:";
            // 
            // lblAfectacion
            // 
            this.lblAfectacion.AutoSize = true;
            this.lblAfectacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAfectacion.ForeColor = System.Drawing.Color.Navy;
            this.lblAfectacion.Location = new System.Drawing.Point(5, 94);
            this.lblAfectacion.Name = "lblAfectacion";
            this.lblAfectacion.Size = new System.Drawing.Size(71, 13);
            this.lblAfectacion.TabIndex = 99;
            this.lblAfectacion.Text = "Afectación:";
            // 
            // chcAplicaTodo
            // 
            this.chcAplicaTodo.AutoSize = true;
            this.chcAplicaTodo.Enabled = false;
            this.chcAplicaTodo.ForeColor = System.Drawing.Color.Navy;
            this.chcAplicaTodo.Location = new System.Drawing.Point(460, 219);
            this.chcAplicaTodo.Name = "chcAplicaTodo";
            this.chcAplicaTodo.Size = new System.Drawing.Size(147, 17);
            this.chcAplicaTodo.TabIndex = 2;
            this.chcAplicaTodo.Text = "Aplicar a todas las cuotas";
            this.chcAplicaTodo.UseVisualStyleBackColor = true;
            this.chcAplicaTodo.Click += new System.EventHandler(this.chcAplicaTodo_Click);
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Location = new System.Drawing.Point(6, 2);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(576, 68);
            this.conBusCuentaCli.TabIndex = 0;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(10, 75);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(92, 13);
            this.lblBase11.TabIndex = 14;
            this.lblBase11.Text = "Plan de Pagos:";
            // 
            // dtgPlanPagos
            // 
            this.dtgPlanPagos.AllowUserToAddRows = false;
            this.dtgPlanPagos.AllowUserToDeleteRows = false;
            this.dtgPlanPagos.AllowUserToResizeColumns = false;
            this.dtgPlanPagos.AllowUserToResizeRows = false;
            this.dtgPlanPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgPlanPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPlanPagos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgPlanPagos.Location = new System.Drawing.Point(12, 92);
            this.dtgPlanPagos.MultiSelect = false;
            this.dtgPlanPagos.Name = "dtgPlanPagos";
            this.dtgPlanPagos.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanPagos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgPlanPagos.RowHeadersVisible = false;
            this.dtgPlanPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanPagos.Size = new System.Drawing.Size(442, 210);
            this.dtgPlanPagos.TabIndex = 3;
            this.dtgPlanPagos.SelectionChanged += new System.EventHandler(this.dtgPlanPagos_SelectionChanged);
            // 
            // dtgDetalleGastos
            // 
            this.dtgDetalleGastos.AllowUserToAddRows = false;
            this.dtgDetalleGastos.AllowUserToDeleteRows = false;
            this.dtgDetalleGastos.AllowUserToResizeColumns = false;
            this.dtgDetalleGastos.AllowUserToResizeRows = false;
            this.dtgDetalleGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleGastos.Location = new System.Drawing.Point(12, 323);
            this.dtgDetalleGastos.MultiSelect = false;
            this.dtgDetalleGastos.Name = "dtgDetalleGastos";
            this.dtgDetalleGastos.ReadOnly = true;
            this.dtgDetalleGastos.RowHeadersVisible = false;
            this.dtgDetalleGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleGastos.Size = new System.Drawing.Size(442, 154);
            this.dtgDetalleGastos.TabIndex = 4;
            this.dtgDetalleGastos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleGastos_CellClick);
            // 
            // lblDetalleGastos
            // 
            this.lblDetalleGastos.AutoSize = true;
            this.lblDetalleGastos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDetalleGastos.ForeColor = System.Drawing.Color.Navy;
            this.lblDetalleGastos.Location = new System.Drawing.Point(10, 308);
            this.lblDetalleGastos.Name = "lblDetalleGastos";
            this.lblDetalleGastos.Size = new System.Drawing.Size(154, 13);
            this.lblDetalleGastos.TabIndex = 17;
            this.lblDetalleGastos.Text = "Detalle Gastos Cargados:";
            // 
            // chcConfigAsientosContables
            // 
            this.chcConfigAsientosContables.AutoSize = true;
            this.chcConfigAsientosContables.Font = new System.Drawing.Font("Verdana", 8F);
            this.chcConfigAsientosContables.ForeColor = System.Drawing.Color.Navy;
            this.chcConfigAsientosContables.Location = new System.Drawing.Point(460, 404);
            this.chcConfigAsientosContables.Name = "chcConfigAsientosContables";
            this.chcConfigAsientosContables.Size = new System.Drawing.Size(223, 17);
            this.chcConfigAsientosContables.TabIndex = 2;
            this.chcConfigAsientosContables.Text = "Generar Asientos al cargar Gastos";
            this.chcConfigAsientosContables.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(7, 70);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Monto:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 21);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(100, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Tipo de Crédito:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 95);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(52, 13);
            this.lblBase9.TabIndex = 16;
            this.lblBase9.Text = "Cuotas:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(7, 45);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(56, 13);
            this.lblBase10.TabIndex = 17;
            this.lblBase10.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(109, 42);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(157, 21);
            this.cboMoneda.TabIndex = 1;
            // 
            // txtCuotas
            // 
            this.txtCuotas.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuotas.Enabled = false;
            this.txtCuotas.Location = new System.Drawing.Point(109, 92);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(157, 20);
            this.txtCuotas.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(109, 67);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(157, 20);
            this.txtMonto.TabIndex = 2;
            // 
            // txtTipoCredito
            // 
            this.txtTipoCredito.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoCredito.Enabled = false;
            this.txtTipoCredito.Location = new System.Drawing.Point(109, 16);
            this.txtTipoCredito.Name = "txtTipoCredito";
            this.txtTipoCredito.Size = new System.Drawing.Size(157, 20);
            this.txtTipoCredito.TabIndex = 18;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtTipoCredito);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.txtCuotas);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Location = new System.Drawing.Point(460, 90);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(272, 119);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Crédito:";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(666, 12);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 103;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(600, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 104;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmCargarGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 505);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.chcConfigAsientosContables);
            this.Controls.Add(this.lblDetalleGastos);
            this.Controls.Add(this.dtgDetalleGastos);
            this.Controls.Add(this.chcAplicaTodo);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.dtgPlanPagos);
            this.Controls.Add(this.grbGasto);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmCargarGastos";
            this.Text = "Carga de Gastos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCargarGastos_FormClosed);
            this.Load += new System.EventHandler(this.frmCargarGastos_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbGasto, 0);
            this.Controls.SetChildIndex(this.dtgPlanPagos, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.chcAplicaTodo, 0);
            this.Controls.SetChildIndex(this.dtgDetalleGastos, 0);
            this.Controls.SetChildIndex(this.lblDetalleGastos, 0);
            this.Controls.SetChildIndex(this.chcConfigAsientosContables, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.grbGasto.ResumeLayout(false);
            this.grbGasto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGastos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbGasto;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.chcBase chcAplicaTodo;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.dtgBase dtgPlanPagos;
        private GEN.ControlesBase.txtNumRea txtMontoCarga;
        private GEN.ControlesBase.dtgBase dtgDetalleGastos;
        private GEN.ControlesBase.lblBase lblDetalleGastos;
        private GEN.ControlesBase.cboGrupoGasto cboGrupoGasto;
        private GEN.ControlesBase.cboTipGasto cboTipoGasto;
        private GEN.ControlesBase.lblBase lblGrupoGasto;
        private GEN.ControlesBase.lblBase lblTipoGasto;
        private GEN.ControlesBase.cboAplicaConcepto cboAplicaConcepto;
        private GEN.ControlesBase.lblBase lblTipoValor;
        private GEN.ControlesBase.lblBase lblAfectacion;
        private GEN.ControlesBase.chcBase chcConfigAsientosContables;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtBase txtCuotas;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.txtBase txtTipoCredito;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboTipoValor cboTipoValor;
        private GEN.ControlesBase.lblBase lblPorcentaje;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnAgregar btnAgregar;

    }
}