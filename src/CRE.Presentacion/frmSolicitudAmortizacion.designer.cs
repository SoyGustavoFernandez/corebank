namespace CRE.Presentacion
{
    partial class frmSolicitudAmortizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudAmortizacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDistribucion = new GEN.ControlesBase.grbBase(this.components);
            this.txtIntCompAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotalAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtGastosAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMoraAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtInteresAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCapitalAmo = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtIntComp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCredito = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtGastos = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCapital = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.dtgAmortizacion = new GEN.ControlesBase.dtgBase(this.components);
            this.idCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapitalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nInteresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIntComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOtros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amortizacion = new System.Windows.Forms.BindingSource(this.components);
            this.btnAsignar = new GEN.BotonesBase.btnContinuar();
            this.btnQuitar = new GEN.BotonesBase.btnRegresar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtIntCompSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotalSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtGastosSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMoraSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtInteresSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCapitalSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.grbDistribucion.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAmortizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amortizacion)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(837, 396);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(705, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
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
            this.btnGrabar.Location = new System.Drawing.Point(771, 396);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(19, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 84);
            this.conBusCli.TabIndex = 2;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Location = new System.Drawing.Point(19, 102);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(769, 106);
            this.dtgCreditos.TabIndex = 3;
            this.dtgCreditos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditos_CellClick);
            // 
            // grbDistribucion
            // 
            this.grbDistribucion.Controls.Add(this.txtIntCompAmo);
            this.grbDistribucion.Controls.Add(this.txtTotalAmo);
            this.grbDistribucion.Controls.Add(this.txtGastosAmo);
            this.grbDistribucion.Controls.Add(this.txtMoraAmo);
            this.grbDistribucion.Controls.Add(this.txtInteresAmo);
            this.grbDistribucion.Controls.Add(this.txtCapitalAmo);
            this.grbDistribucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDistribucion.Location = new System.Drawing.Point(187, 219);
            this.grbDistribucion.Name = "grbDistribucion";
            this.grbDistribucion.Size = new System.Drawing.Size(106, 204);
            this.grbDistribucion.TabIndex = 9;
            this.grbDistribucion.TabStop = false;
            this.grbDistribucion.Text = "Amortización";
            // 
            // txtIntCompAmo
            // 
            this.txtIntCompAmo.Enabled = false;
            this.txtIntCompAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntCompAmo.FormatoDecimal = false;
            this.txtIntCompAmo.Location = new System.Drawing.Point(9, 88);
            this.txtIntCompAmo.MaxLength = 11;
            this.txtIntCompAmo.Name = "txtIntCompAmo";
            this.txtIntCompAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIntCompAmo.nNumDecimales = 2;
            this.txtIntCompAmo.nvalor = 0D;
            this.txtIntCompAmo.Size = new System.Drawing.Size(88, 22);
            this.txtIntCompAmo.TabIndex = 2;
            this.txtIntCompAmo.Text = "0.00";
            this.txtIntCompAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIntCompAmo.Leave += new System.EventHandler(this.txtIntCompAmo_Leave);
            // 
            // txtTotalAmo
            // 
            this.txtTotalAmo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotalAmo.Enabled = false;
            this.txtTotalAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmo.FormatoDecimal = false;
            this.txtTotalAmo.Location = new System.Drawing.Point(9, 172);
            this.txtTotalAmo.Name = "txtTotalAmo";
            this.txtTotalAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalAmo.nNumDecimales = 2;
            this.txtTotalAmo.nvalor = 0D;
            this.txtTotalAmo.Size = new System.Drawing.Size(88, 22);
            this.txtTotalAmo.TabIndex = 18;
            this.txtTotalAmo.Text = "0.00";
            this.txtTotalAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGastosAmo
            // 
            this.txtGastosAmo.Enabled = false;
            this.txtGastosAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastosAmo.FormatoDecimal = false;
            this.txtGastosAmo.Location = new System.Drawing.Point(9, 136);
            this.txtGastosAmo.MaxLength = 11;
            this.txtGastosAmo.Name = "txtGastosAmo";
            this.txtGastosAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtGastosAmo.nNumDecimales = 2;
            this.txtGastosAmo.nvalor = 0D;
            this.txtGastosAmo.Size = new System.Drawing.Size(88, 22);
            this.txtGastosAmo.TabIndex = 4;
            this.txtGastosAmo.Text = "0.00";
            this.txtGastosAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastosAmo.Leave += new System.EventHandler(this.txtGastosAmo_Leave);
            // 
            // txtMoraAmo
            // 
            this.txtMoraAmo.Enabled = false;
            this.txtMoraAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoraAmo.FormatoDecimal = false;
            this.txtMoraAmo.Location = new System.Drawing.Point(9, 112);
            this.txtMoraAmo.MaxLength = 11;
            this.txtMoraAmo.Name = "txtMoraAmo";
            this.txtMoraAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMoraAmo.nNumDecimales = 2;
            this.txtMoraAmo.nvalor = 0D;
            this.txtMoraAmo.Size = new System.Drawing.Size(88, 22);
            this.txtMoraAmo.TabIndex = 3;
            this.txtMoraAmo.Text = "0.00";
            this.txtMoraAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoraAmo.Leave += new System.EventHandler(this.txtMoraAmo_Leave);
            // 
            // txtInteresAmo
            // 
            this.txtInteresAmo.Enabled = false;
            this.txtInteresAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInteresAmo.FormatoDecimal = false;
            this.txtInteresAmo.Location = new System.Drawing.Point(9, 64);
            this.txtInteresAmo.MaxLength = 11;
            this.txtInteresAmo.Name = "txtInteresAmo";
            this.txtInteresAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInteresAmo.nNumDecimales = 2;
            this.txtInteresAmo.nvalor = 0D;
            this.txtInteresAmo.Size = new System.Drawing.Size(88, 22);
            this.txtInteresAmo.TabIndex = 1;
            this.txtInteresAmo.Text = "0.00";
            this.txtInteresAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteresAmo.Leave += new System.EventHandler(this.txtInteresAmo_Leave);
            // 
            // txtCapitalAmo
            // 
            this.txtCapitalAmo.Enabled = false;
            this.txtCapitalAmo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalAmo.FormatoDecimal = false;
            this.txtCapitalAmo.Location = new System.Drawing.Point(9, 40);
            this.txtCapitalAmo.MaxLength = 11;
            this.txtCapitalAmo.Name = "txtCapitalAmo";
            this.txtCapitalAmo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCapitalAmo.nNumDecimales = 2;
            this.txtCapitalAmo.nvalor = 0D;
            this.txtCapitalAmo.Size = new System.Drawing.Size(88, 22);
            this.txtCapitalAmo.TabIndex = 0;
            this.txtCapitalAmo.Text = "0.00";
            this.txtCapitalAmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapitalAmo.Leave += new System.EventHandler(this.txtCapitalAmo_Leave);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtIntComp);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtSaldoCredito);
            this.grbBase2.Controls.Add(this.txtGastos);
            this.grbBase2.Controls.Add(this.txtMora);
            this.grbBase2.Controls.Add(this.txtInteres);
            this.grbBase2.Controls.Add(this.txtCapital);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase12);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.lblBase17);
            this.grbBase2.Controls.Add(this.lblBase18);
            this.grbBase2.Enabled = false;
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.Location = new System.Drawing.Point(12, 219);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(175, 204);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Montos a la fecha";
            // 
            // txtIntComp
            // 
            this.txtIntComp.Enabled = false;
            this.txtIntComp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntComp.FormatoDecimal = false;
            this.txtIntComp.Location = new System.Drawing.Point(82, 88);
            this.txtIntComp.Name = "txtIntComp";
            this.txtIntComp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIntComp.nNumDecimales = 2;
            this.txtIntComp.nvalor = 0D;
            this.txtIntComp.Size = new System.Drawing.Size(89, 22);
            this.txtIntComp.TabIndex = 20;
            this.txtIntComp.Text = "0.00";
            this.txtIntComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 93);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(74, 13);
            this.lblBase1.TabIndex = 19;
            this.lblBase1.Text = "Int. Comp.:";
            // 
            // txtSaldoCredito
            // 
            this.txtSaldoCredito.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSaldoCredito.Enabled = false;
            this.txtSaldoCredito.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoCredito.FormatoDecimal = false;
            this.txtSaldoCredito.Location = new System.Drawing.Point(82, 172);
            this.txtSaldoCredito.Name = "txtSaldoCredito";
            this.txtSaldoCredito.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSaldoCredito.nNumDecimales = 2;
            this.txtSaldoCredito.nvalor = 0D;
            this.txtSaldoCredito.Size = new System.Drawing.Size(89, 22);
            this.txtSaldoCredito.TabIndex = 18;
            this.txtSaldoCredito.Text = "0.00";
            this.txtSaldoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGastos
            // 
            this.txtGastos.Enabled = false;
            this.txtGastos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastos.FormatoDecimal = false;
            this.txtGastos.Location = new System.Drawing.Point(82, 136);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtGastos.nNumDecimales = 2;
            this.txtGastos.nvalor = 0D;
            this.txtGastos.Size = new System.Drawing.Size(89, 22);
            this.txtGastos.TabIndex = 18;
            this.txtGastos.Text = "0.00";
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMora
            // 
            this.txtMora.Enabled = false;
            this.txtMora.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMora.FormatoDecimal = false;
            this.txtMora.Location = new System.Drawing.Point(82, 112);
            this.txtMora.Name = "txtMora";
            this.txtMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMora.nNumDecimales = 2;
            this.txtMora.nvalor = 0D;
            this.txtMora.Size = new System.Drawing.Size(89, 22);
            this.txtMora.TabIndex = 18;
            this.txtMora.Text = "0.00";
            this.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInteres
            // 
            this.txtInteres.Enabled = false;
            this.txtInteres.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInteres.FormatoDecimal = false;
            this.txtInteres.Location = new System.Drawing.Point(82, 64);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInteres.nNumDecimales = 2;
            this.txtInteres.nvalor = 0D;
            this.txtInteres.Size = new System.Drawing.Size(89, 22);
            this.txtInteres.TabIndex = 18;
            this.txtInteres.Text = "0.00";
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCapital
            // 
            this.txtCapital.Enabled = false;
            this.txtCapital.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapital.FormatoDecimal = false;
            this.txtCapital.Location = new System.Drawing.Point(82, 40);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCapital.nNumDecimales = 2;
            this.txtCapital.nvalor = 0D;
            this.txtCapital.Size = new System.Drawing.Size(89, 22);
            this.txtCapital.TabIndex = 17;
            this.txtCapital.Text = "0.00";
            this.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(5, 141);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(51, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Gastos:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(5, 177);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(34, 13);
            this.lblBase12.TabIndex = 12;
            this.lblBase12.Text = "Total";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(5, 117);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(40, 13);
            this.lblBase15.TabIndex = 11;
            this.lblBase15.Text = "Mora:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(5, 69);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(53, 13);
            this.lblBase17.TabIndex = 9;
            this.lblBase17.Text = "Interés:";
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(5, 45);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(52, 13);
            this.lblBase18.TabIndex = 7;
            this.lblBase18.Text = "Capital:";
            // 
            // dtgAmortizacion
            // 
            this.dtgAmortizacion.AllowUserToAddRows = false;
            this.dtgAmortizacion.AllowUserToDeleteRows = false;
            this.dtgAmortizacion.AllowUserToResizeColumns = false;
            this.dtgAmortizacion.AllowUserToResizeRows = false;
            this.dtgAmortizacion.AutoGenerateColumns = false;
            this.dtgAmortizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAmortizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuentaDataGridViewTextBoxColumn,
            this.nCapitalDataGridViewTextBoxColumn,
            this.nInteresDataGridViewTextBoxColumn,
            this.nIntComp,
            this.nMora,
            this.nOtros});
            this.dtgAmortizacion.DataSource = this.Amortizacion;
            this.dtgAmortizacion.Location = new System.Drawing.Point(466, 243);
            this.dtgAmortizacion.MultiSelect = false;
            this.dtgAmortizacion.Name = "dtgAmortizacion";
            this.dtgAmortizacion.ReadOnly = true;
            this.dtgAmortizacion.RowHeadersVisible = false;
            this.dtgAmortizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAmortizacion.Size = new System.Drawing.Size(431, 139);
            this.dtgAmortizacion.TabIndex = 10;
            // 
            // idCuentaDataGridViewTextBoxColumn
            // 
            this.idCuentaDataGridViewTextBoxColumn.DataPropertyName = "idCuenta";
            this.idCuentaDataGridViewTextBoxColumn.HeaderText = "Cod.Cuenta";
            this.idCuentaDataGridViewTextBoxColumn.Name = "idCuentaDataGridViewTextBoxColumn";
            this.idCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCuentaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nCapitalDataGridViewTextBoxColumn
            // 
            this.nCapitalDataGridViewTextBoxColumn.DataPropertyName = "nCapital";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.nCapitalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nCapitalDataGridViewTextBoxColumn.HeaderText = "Capital";
            this.nCapitalDataGridViewTextBoxColumn.Name = "nCapitalDataGridViewTextBoxColumn";
            this.nCapitalDataGridViewTextBoxColumn.ReadOnly = true;
            this.nCapitalDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nInteresDataGridViewTextBoxColumn
            // 
            this.nInteresDataGridViewTextBoxColumn.DataPropertyName = "nInteres";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.nInteresDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nInteresDataGridViewTextBoxColumn.HeaderText = "Interés";
            this.nInteresDataGridViewTextBoxColumn.Name = "nInteresDataGridViewTextBoxColumn";
            this.nInteresDataGridViewTextBoxColumn.ReadOnly = true;
            this.nInteresDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nIntComp
            // 
            this.nIntComp.DataPropertyName = "nIntComp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.nIntComp.DefaultCellStyle = dataGridViewCellStyle3;
            this.nIntComp.HeaderText = "Int.Comp.";
            this.nIntComp.Name = "nIntComp";
            this.nIntComp.ReadOnly = true;
            // 
            // nMora
            // 
            this.nMora.DataPropertyName = "nMora";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.nMora.DefaultCellStyle = dataGridViewCellStyle4;
            this.nMora.HeaderText = "Mora";
            this.nMora.Name = "nMora";
            this.nMora.ReadOnly = true;
            // 
            // nOtros
            // 
            this.nOtros.DataPropertyName = "nOtros";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.nOtros.DefaultCellStyle = dataGridViewCellStyle5;
            this.nOtros.HeaderText = "Gastos";
            this.nOtros.Name = "nOtros";
            this.nOtros.ReadOnly = true;
            // 
            // Amortizacion
            // 
            this.Amortizacion.DataSource = typeof(EntityLayer.clsCuota);
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAsignar.BackgroundImage")));
            this.btnAsignar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAsignar.Location = new System.Drawing.Point(399, 263);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(60, 50);
            this.btnAsignar.TabIndex = 8;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(399, 332);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtIntCompSol);
            this.grbBase1.Controls.Add(this.txtTotalSol);
            this.grbBase1.Controls.Add(this.txtGastosSol);
            this.grbBase1.Controls.Add(this.txtMoraSol);
            this.grbBase1.Controls.Add(this.txtInteresSol);
            this.grbBase1.Controls.Add(this.txtCapitalSol);
            this.grbBase1.Enabled = false;
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.Location = new System.Drawing.Point(293, 219);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(100, 204);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Convertido Soles";
            // 
            // txtIntCompSol
            // 
            this.txtIntCompSol.Enabled = false;
            this.txtIntCompSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntCompSol.FormatoDecimal = false;
            this.txtIntCompSol.Location = new System.Drawing.Point(6, 88);
            this.txtIntCompSol.Name = "txtIntCompSol";
            this.txtIntCompSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIntCompSol.nNumDecimales = 2;
            this.txtIntCompSol.nvalor = 0D;
            this.txtIntCompSol.Size = new System.Drawing.Size(88, 22);
            this.txtIntCompSol.TabIndex = 19;
            this.txtIntCompSol.Text = "0.00";
            this.txtIntCompSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalSol
            // 
            this.txtTotalSol.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotalSol.Enabled = false;
            this.txtTotalSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSol.FormatoDecimal = false;
            this.txtTotalSol.Location = new System.Drawing.Point(6, 172);
            this.txtTotalSol.Name = "txtTotalSol";
            this.txtTotalSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalSol.nNumDecimales = 2;
            this.txtTotalSol.nvalor = 0D;
            this.txtTotalSol.Size = new System.Drawing.Size(88, 22);
            this.txtTotalSol.TabIndex = 18;
            this.txtTotalSol.Text = "0.00";
            this.txtTotalSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGastosSol
            // 
            this.txtGastosSol.Enabled = false;
            this.txtGastosSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastosSol.FormatoDecimal = false;
            this.txtGastosSol.Location = new System.Drawing.Point(6, 136);
            this.txtGastosSol.Name = "txtGastosSol";
            this.txtGastosSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtGastosSol.nNumDecimales = 2;
            this.txtGastosSol.nvalor = 0D;
            this.txtGastosSol.Size = new System.Drawing.Size(88, 22);
            this.txtGastosSol.TabIndex = 18;
            this.txtGastosSol.Text = "0.00";
            this.txtGastosSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMoraSol
            // 
            this.txtMoraSol.Enabled = false;
            this.txtMoraSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoraSol.FormatoDecimal = false;
            this.txtMoraSol.Location = new System.Drawing.Point(6, 112);
            this.txtMoraSol.Name = "txtMoraSol";
            this.txtMoraSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMoraSol.nNumDecimales = 2;
            this.txtMoraSol.nvalor = 0D;
            this.txtMoraSol.Size = new System.Drawing.Size(88, 22);
            this.txtMoraSol.TabIndex = 18;
            this.txtMoraSol.Text = "0.00";
            this.txtMoraSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInteresSol
            // 
            this.txtInteresSol.Enabled = false;
            this.txtInteresSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInteresSol.FormatoDecimal = false;
            this.txtInteresSol.Location = new System.Drawing.Point(6, 64);
            this.txtInteresSol.Name = "txtInteresSol";
            this.txtInteresSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInteresSol.nNumDecimales = 2;
            this.txtInteresSol.nvalor = 0D;
            this.txtInteresSol.Size = new System.Drawing.Size(88, 22);
            this.txtInteresSol.TabIndex = 18;
            this.txtInteresSol.Text = "0.00";
            this.txtInteresSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCapitalSol
            // 
            this.txtCapitalSol.Enabled = false;
            this.txtCapitalSol.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalSol.FormatoDecimal = false;
            this.txtCapitalSol.Location = new System.Drawing.Point(6, 40);
            this.txtCapitalSol.Name = "txtCapitalSol";
            this.txtCapitalSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCapitalSol.nNumDecimales = 2;
            this.txtCapitalSol.nvalor = 0D;
            this.txtCapitalSol.Size = new System.Drawing.Size(88, 22);
            this.txtCapitalSol.TabIndex = 17;
            this.txtCapitalSol.Text = "0.00";
            this.txtCapitalSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dFechaPago";
            this.dataGridViewTextBoxColumn1.HeaderText = "dFechaPago";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 11;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(639, 396);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmSolicitudAmortizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 497);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.dtgAmortizacion);
            this.Controls.Add(this.grbDistribucion);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.dtgCreditos);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmSolicitudAmortizacion";
            this.Text = "Solicitud de Amortización por Refinanciamiento";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.dtgCreditos, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbDistribucion, 0);
            this.Controls.SetChildIndex(this.dtgAmortizacion, 0);
            this.Controls.SetChildIndex(this.btnAsignar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.grbDistribucion.ResumeLayout(false);
            this.grbDistribucion.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAmortizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amortizacion)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.ControlesBase.grbBase grbDistribucion;
        private GEN.ControlesBase.txtNumRea txtTotalAmo;
        private GEN.ControlesBase.txtNumRea txtGastosAmo;
        private GEN.ControlesBase.txtNumRea txtMoraAmo;
        private GEN.ControlesBase.txtNumRea txtInteresAmo;
        private GEN.ControlesBase.txtNumRea txtCapitalAmo;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtNumRea txtSaldoCredito;
        private GEN.ControlesBase.txtNumRea txtGastos;
        private GEN.ControlesBase.txtNumRea txtMora;
        private GEN.ControlesBase.txtNumRea txtInteres;
        private GEN.ControlesBase.txtNumRea txtCapital;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.lblBase lblBase18;
        private GEN.ControlesBase.dtgBase dtgAmortizacion;
        private GEN.BotonesBase.btnContinuar btnAsignar;
        private GEN.BotonesBase.btnRegresar btnQuitar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtTotalSol;
        private GEN.ControlesBase.txtNumRea txtGastosSol;
        private GEN.ControlesBase.txtNumRea txtMoraSol;
        private GEN.ControlesBase.txtNumRea txtInteresSol;
        private GEN.ControlesBase.txtNumRea txtCapitalSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource Amortizacion;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOtrosDataGridViewTextBoxColumn;
        private GEN.ControlesBase.txtNumRea txtIntCompAmo;
        private GEN.ControlesBase.txtNumRea txtIntComp;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtIntCompSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapitalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nInteresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIntComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMora;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOtros;

    }
}

